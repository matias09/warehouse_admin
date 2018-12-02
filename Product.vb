Public Class Product
  Inherits System.Windows.Forms.Form

  Const STATE_AVAILABLE As Char = "A"
  Const STATE_DISABLE As Char = "B"

  Const TYPE_TITLE_LABEL_TEXT_ON_IDLE_STATE As String = "Tipo:"
  Const TYPE_TITLE_LABEL_TEXT_ON_NEW_STATE As String = "Elegir Tipo:"

  Private _mProductsRecordList As ArrayList
  Private _mProductsDao As ProductsDao
  Private _mActProductsRegPos As Integer

  Private _mTypesValues As Dictionary(Of Integer, String)
  Private _mTypesRecordList As ArrayList
  Private _mTypesDao As TypesDao
  Private _mActTypesRegPos As Integer

  Private _mUtils As Utils
  Private _mState As Char
  Private _mStock As Integer

  Private Sub SwitchOnOffTypeControls(ByVal state As Boolean)
    If (state = True) Then
      drp_types.Visible = True
      lab_type_title.Text = TYPE_TITLE_LABEL_TEXT_ON_NEW_STATE

      lab_type_value.Visible = False
    Else
      drp_types.Visible = False
      lab_type_title.Text = TYPE_TITLE_LABEL_TEXT_ON_IDLE_STATE

      lab_type_value.Visible = True
    End If
  End Sub

  Private Sub SwitchOnOffControlSaveButtons(ByVal state As Boolean)
    btn_save.Enabled = state
    btn_save.Visible = state

    btn_cancel.Enabled = state
    btn_cancel.Visible = state

    txt_name.Enabled = True
    txt_stock.Enabled = True

    If state = True Then
      btn_new.Enabled = False
    Else
      btn_new.Enabled = True
    End If
  End Sub

  Private Sub SwitchOnOffControlDataButtons(ByVal state As Boolean)
    ' DropDown Controllers
    drp_products.Enabled = state

    ' Buttons Controllers
    btn_next.Enabled = state
    btn_prev.Enabled = state

    btn_update.Enabled = state
    btn_delete.Enabled = state
  End Sub

  Private Sub SwitchOnOffInputControls(ByVal state As Boolean)
    txt_name.Enabled = state

    If (state = True And rad_state_b.Checked = False) Then
      txt_stock.Enabled = True
    Else
      txt_stock.Enabled = False
    End If

    If (state = True And _mStock = 0) Then
      rad_state_a.Enabled = True
      rad_state_b.Enabled = True
    Else
      rad_state_a.Enabled = False
      rad_state_b.Enabled = False
    End If
  End Sub

  Private Sub FillTypesDropDownMenu()
    Dim recordsCount As Integer = 0

    recordsCount = _mTypesRecordList.Count

    If recordsCount <> 0 Then
      Dim i As Integer = 0
      While i < recordsCount
        If (_mTypesValues.ContainsKey(_mTypesRecordList.Item(i)("id")) = False) Then
          _mTypesValues.Add(_mTypesRecordList.Item(i)("id"), _mTypesRecordList.Item(i)("typ_name"))
        End If

        drp_types.Items.Add(_mTypesRecordList.Item(i)("typ_name"))
        i += 1
      End While


      'Console.WriteLine("Product::FillTypesDropDownMenu - Filltype reg pos : " & _mActTypesRegPos)
      drp_types.SelectedIndex = _mActTypesRegPos
    Else
      drp_types.Enabled = False
    End If
  End Sub

  Private Sub UpdateObjectState()
    If (rad_state_a.Checked = True) Then
      _mState = STATE_AVAILABLE
    Else
      _mState = STATE_DISABLE
    End If
  End Sub

  Private Sub UpdateControls()
    _mUtils.ResetControls(Me)
    ResetErrorLabel()

    If (_mProductsRecordList.Count <> 0) Then
      If (IsDBNull(_mProductsRecordList.Item(_mActProductsRegPos)("pro_name")) <> True) Then
        txt_name.Text = _mProductsRecordList.Item(_mActProductsRegPos)("pro_name")

        _mStock = _mProductsRecordList.Item(_mActProductsRegPos)("stock")
        txt_stock.Text = _mStock

        _mState = _mProductsRecordList.Item(_mActProductsRegPos)("state")
        If (_mState = STATE_AVAILABLE) Then
          rad_state_a.Checked = True
        Else
          rad_state_b.Checked = True
        End If

        lab_type_value.Text = _mTypesValues(_mProductsRecordList.Item(_mActProductsRegPos)("id_type"))

        SwitchOnOffInputControls(True)
        SwitchOnOffControlDataButtons(True)
      End If
    Else
      lab_type_value.Text = ""
      SwitchOnOffControlDataButtons(False)
      SwitchOnOffInputControls(False)
    End If
  End Sub

  Private Sub UpdateProductsMenu()
    Dim i As Integer = 0
    Dim recordsCount As Integer = 0

    drp_products.Items.Clear()
    recordsCount = _mProductsRecordList.Count

    If recordsCount <> 0 Then
      While i < recordsCount
        drp_products.Items.Add(_mProductsRecordList.Item(i)("pro_name"))
        i += 1
      End While
      drp_products.SelectedIndex = _mActProductsRegPos
    Else
      drp_products.Enabled = False
    End If
  End Sub

  Private Sub UpdateRecordListData()
    _mProductsRecordList(_mActProductsRegPos)("pro_name") = txt_name.Text
    _mProductsRecordList(_mActProductsRegPos)("stock") = txt_stock.Text
    _mProductsRecordList(_mActProductsRegPos)("state") = _mState
  End Sub

  Private Sub AddNewRecordToRecordList()
    Dim fields As Hashtable = New Hashtable()

    'Console.WriteLine(" Ids " & _mTypesValues.Keys().Count)
    'Console.WriteLine(" Id from element selected : " & _mTypesValues.Keys(drp_types.SelectedIndex))

    fields("pro_name") = txt_name.Text
    fields("id_type") = _mTypesValues.Keys(drp_types.SelectedIndex)
    fields("stock") = txt_stock.Text
    fields("state") = _mState

    _mProductsRecordList.Add(fields)
  End Sub

  Private Sub ResetErrorLabel()
    lab_error_msg.Visible = False
  End Sub

  Private Sub ShowErrorLabel(ByRef msg As String)
    lab_error_msg.Text = msg
    lab_error_msg.Visible = True
  End Sub

  Private Function ValidateInputs() As Boolean
    ''Console.WriteLine("------ Products: Inside ValidateInputs() ------")
    If _mUtils.CheckExpressionByPatternMatching(txt_name.Text, "^[a-zA-Z]+$") = False Then
      Console.WriteLine("------ Products: Inside ValidateInputs() -> IF 1 ------")
      ShowErrorLabel("Error: Nombre Invalido")
      Return False
    End If

    If _mUtils.CheckExpressionByPatternMatching(txt_stock.Text, "^[0-9]+$") = False Then
      Console.WriteLine("------ Products: Inside ValidateInputs() -> IF 2 ------")
      ShowErrorLabel("Error: Stock Invalido")
      Return False
    End If

    Return True
  End Function

  Private Sub CustomResetControls()
    drp_types.SelectedIndex = 0
    txt_name.Text = ""
    txt_stock.Text = 0
    rad_state_a.Checked = True
    rad_state_b.Checked = False
  End Sub

  Private Sub FillStockDataById(ByRef id As Integer)
    Dim rd As OleDb.OleDbDataReader = Nothing

    dat_stock.Rows.Clear()

    _mProductsDao.GetDistributionById(id, rd)
    While rd.Read()
      'MsgBox(rd.Item("id") & "  -  " & rd.Item(1) & "  -  " & rd.Item(2))
      dat_stock.Rows.Add(rd.Item("sector_name"), rd.Item("sector_hall"), rd.Item("stock"))
    End While
    rd.Close()

  End Sub

  '/-------------------------- EventHandlers Methods --------------------------/
  Private Sub Products_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    _mProductsDao = ProductsDao.GetInstance()
    _mProductsRecordList = _mProductsDao.GetRecords()
    _mActProductsRegPos = _mProductsDao.GetRegisterPos()

    _mTypesDao = TypesDao.GetInstance()
    _mTypesValues = New Dictionary(Of Integer, String)
    _mTypesRecordList = _mTypesDao.GetRecords()
    _mActTypesRegPos = _mTypesDao.GetRegisterPos()

    _mUtils = New Utils()

    ResetErrorLabel()
    FillTypesDropDownMenu()

    UpdateControls()
    UpdateProductsMenu()
  End Sub

  Private Sub drp_products_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles drp_products.SelectedIndexChanged
    _mProductsDao.SetRegisterPos(drp_products.SelectedIndex)
    _mActProductsRegPos = drp_products.SelectedIndex
    FillStockDataById(_mTypesRecordList(_mActProductsRegPos)("id"))
    UpdateControls()
  End Sub

  Private Sub drp_types_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles drp_types.SelectedIndexChanged
    _mActTypesRegPos = drp_types.SelectedIndex
  End Sub

  Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
    'Console.WriteLine("Products - I press Exit button")
    ResetErrorLabel()
    Me.Hide()
    Form1.Show()
    Form1.Focus()
  End Sub

  Private Sub btn_stock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_stock.Click
    If dat_stock.Visible = False Then
      dat_stock.Visible = True
    Else
      dat_stock.Visible = False
    End If
  End Sub

  Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
    If ValidateInputs() = True Then
      ResetErrorLabel()
      UpdateObjectState()

      UpdateRecordListData()
      _mProductsDao.SetRecordList(_mProductsRecordList)

      UpdateProductsMenu()
      _mProductsDao.SaveRecord(False)

      ' Back To Normal Menu Behavior
      SwitchOnOffControlDataButtons(True)

      UpdateControls()
    End If
  End Sub

  Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
    If ValidateInputs() = True Then
      ResetErrorLabel()
      UpdateObjectState()

      AddNewRecordToRecordList()
      _mProductsDao.SetRecordList(_mProductsRecordList)

      UpdateProductsMenu()
      _mProductsDao.SaveRecord(True)

      ' Back To Normal Menu Behavior
      SwitchOnOffControlSaveButtons(False)
      SwitchOnOffTypeControls(False)

      UpdateControls()
    End If
  End Sub

  Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
    SwitchOnOffControlSaveButtons(False)
    SwitchOnOffTypeControls(False)
    UpdateControls()
  End Sub

  Private Sub btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new.Click
    CustomResetControls()
    SwitchOnOffControlSaveButtons(True)
    SwitchOnOffInputControls(True)
    SwitchOnOffTypeControls(True)
    SwitchOnOffControlDataButtons(False)

    ' focus on the types product menu
    drp_types.Focus()
  End Sub

  Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
    _mProductsDao.SetRegisterPos(_mActProductsRegPos)
    _mProductsRecordList.RemoveAt(_mActProductsRegPos)

    drp_products.Items.RemoveAt(_mActProductsRegPos)
    _mProductsDao.EraseRecord()

    If _mActProductsRegPos <> 0 Then
      _mActProductsRegPos -= 1
    End If

    ' Back To Normal Menu Behavior
    SwitchOnOffControlDataButtons(True)

    UpdateControls()
    UpdateProductsMenu()
  End Sub

  Private Sub btn_next_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_next.Click
    Dim futRegPos As Integer = 0
    Dim eleRecordsCount As Integer = _mProductsRecordList.Count

    futRegPos = _mActProductsRegPos + 1
    _mActProductsRegPos = _mUtils.UpdateRegisterPos(futRegPos, eleRecordsCount)
    drp_products.SelectedIndex = _mActProductsRegPos
  End Sub

  Private Sub btn_prev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_prev.Click
    Dim futRegPos As Integer = _mActProductsRegPos - 1
    Dim eleRecordsCount As Integer = _mProductsRecordList.Count

    _mActProductsRegPos = _mUtils.UpdateRegisterPos(futRegPos, eleRecordsCount)
    drp_products.SelectedIndex = _mActProductsRegPos
  End Sub

  Private Sub rad_state_b_CheckedChanged(sender As Object, e As EventArgs) Handles rad_state_b.CheckedChanged
    If rad_state_b.Checked = True Then
      _mStock = 0
      txt_stock.Text = 0
      txt_stock.Enabled = False
    Else
      txt_stock.Enabled = True
    End If
  End Sub

End Class
