Public Class Product
  Inherits System.Windows.Forms.Form

  Const STATE_AVAILABLE As Char = "A"
  Const STATE_DISABLE As Char = "B"

  Const TYPE_TITLE_LABEL_TEXT_ON_IDLE_STATE As String = "Type:"
  Const TYPE_TITLE_LABEL_TEXT_ON_NEW_STATE As String = "Choose Type:"

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
  End Sub

  Private Sub SwitchOnOffInputControls(ByVal state As Boolean)
    txt_name.Enabled = state

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

    If (_mProductsRecordList.Count <> 0) Then
      If (IsDBNull(_mProductsRecordList.Item(_mActProductsRegPos)("pro_name")) <> True) Then
        txt_name.Text = _mProductsRecordList.Item(_mActProductsRegPos)("pro_name")

        _mState = _mProductsRecordList.Item(_mActProductsRegPos)("state")
        If (_mState = STATE_AVAILABLE) Then
          rad_state_a.Checked = True
        Else
          rad_state_b.Checked = True
        End If

        lab_type_value.Text = _mTypesValues(_mProductsRecordList.Item(_mActProductsRegPos)("id_type"))

        FillStockDataById(_mProductsRecordList(_mActProductsRegPos)("id"))
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
    _mProductsRecordList(_mActProductsRegPos)("stock") = lab_stock.Text
    _mProductsRecordList(_mActProductsRegPos)("state") = _mState
  End Sub

  Private Sub AddNewRecordToRecordList()
    Dim fields As Hashtable = New Hashtable()
    Dim itemsCount As Integer = _mProductsRecordList.Count
    Dim id As Integer = 1

    If (itemsCount > 0) Then
      id = _mProductsRecordList(itemsCount - 1)("id") + 1
    End If

    fields("id") = id
    fields("pro_name") = txt_name.Text
    fields("id_type") = _mTypesValues.Keys(drp_types.SelectedIndex)
    fields("stock") = lab_stock.Text
    fields("state") = _mState

    _mProductsRecordList.Add(fields)
  End Sub

  Private Function ValidateInputs() As Boolean
    If _mUtils.CheckExpressionByPatternMatching(txt_name.Text, "^[a-zA-Z]+$") = False Then
      MsgBox("Error: Invalid Name")
      Return False
    End If

    Return True
  End Function

  Private Sub CustomResetControls()
    lab_stock.Text = 0
    txt_name.Text = ""
    rad_state_a.Checked = True
    rad_state_b.Checked = False
  End Sub

  Private Sub FillStockDataById(ByRef id As Integer)
    Dim rd As OleDb.OleDbDataReader = Nothing

    _mStock = 0
    dat_stock.Rows.Clear()

    _mProductsDao.GetDistributionById(id, rd)
    While rd.Read()
      dat_stock.Rows.Add(rd.Item("sector_name"), rd.Item("sector_hall"), rd.Item("stock"))
      _mStock += rd.Item("stock")
    End While
    rd.Close()

    lab_stock.Text = _mStock
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

    If (_mTypesRecordList.Count > 0) Then
      FillTypesDropDownMenu()
    Else
      btn_new.Enabled = False
      btn_update.Enabled = False
      MsgBox("Message: Product Types Must be loaded first before Products.")
    End If

    UpdateControls()
    UpdateProductsMenu()
  End Sub

  Private Sub drp_products_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles drp_products.SelectedIndexChanged
    _mProductsDao.SetRegisterPos(drp_products.SelectedIndex)
    _mActProductsRegPos = drp_products.SelectedIndex

    UpdateControls()
  End Sub

  Private Sub drp_types_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles drp_types.SelectedIndexChanged
    _mActTypesRegPos = drp_types.SelectedIndex
  End Sub

  Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
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

  Private Sub btn_next_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_next.Click
    Dim futRegPos As Integer = 0
    Dim eleRecordsCount As Integer = _mProductsRecordList.Count

    futRegPos = _mActProductsRegPos + 1
    _mActProductsRegPos = _mUtils.UpdateRegisterPos(futRegPos, eleRecordsCount)
    drp_products.SelectedIndex = _mActProductsRegPos
  End Sub

  Private Sub btn_prev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_prev.Click
    Dim futRegPos As Integer = 0
    Dim eleRecordsCount As Integer = _mProductsRecordList.Count

    futRegPos = _mActProductsRegPos - 1
    _mActProductsRegPos = _mUtils.UpdateRegisterPos(futRegPos, eleRecordsCount)
    drp_products.SelectedIndex = _mActProductsRegPos
  End Sub

End Class
