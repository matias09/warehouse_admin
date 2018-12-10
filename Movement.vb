Public Class Movement
  Inherits System.Windows.Forms.Form

  Private _mMovementsRecordList As ArrayList
  Private _mMovementsDao As MovementDao
  Private _mActMovementsRegPos As Integer

  ' Products
  Private _mProductsValues As Dictionary(Of Integer, String)
  Private _mProductsRecordList As ArrayList
  Private _mProductsDao As ProductsDao
  Private _mActProductsRegPos As Integer

  ' Sectors
  Private _mSectorsValues As Dictionary(Of Integer, String)
  Private _mSectorsRecordList As ArrayList
  Private _mSectorsDao As SectorsDao
  Private _mActSectorsRegPos As Integer

  Private _mUtils As Utils

  Private Sub SwitchOnOffControlSaveButtons(ByVal state As Boolean)
    btn_save.Enabled = state
    btn_save.Visible = state

    btn_cancel.Enabled = state
    btn_cancel.Visible = state

    If state = True Then
      btn_new.Enabled = False
    Else
      btn_new.Enabled = True
    End If
  End Sub

  Private Sub SwitchOnOffControlInputsForNewData(ByVal state As Boolean)
    ' DropDown Controllers
    drp_products.Enabled = state
    drp_sectors.Enabled = state

    ' Radio Buttons
    rad_add.Enabled = state
    rad_remove.Enabled = state

    ' Text Buttons Controllers
    txt_amount.Enabled = state

    ' Date Time Picker
    date_time_picker.Enabled = state
  End Sub

  Private Sub SwitchOnOffControlDataButtons(ByVal state As Boolean)
    ' DropDown Controllers
    drp_movements.Enabled = state

    ' Buttons Controllers
    btn_next.Enabled = state
    btn_prev.Enabled = state
  End Sub

  Private Sub FillProductsDropDownMenu()
    Dim recordsCount As Integer = 0

    recordsCount = _mProductsRecordList.Count
    'Console.WriteLine("records count : " & recordsCount)

    If recordsCount <> 0 Then
      Dim i As Integer = 0

      While i < recordsCount
        If (_mProductsValues.ContainsKey(_mProductsRecordList.Item(i)("id")) = False) Then
          _mProductsValues.Add(
            _mProductsRecordList.Item(i)("id"),
            _mProductsRecordList.Item(i)("pro_name")
          )
        End If

        drp_products.Items.Add(_mProductsRecordList.Item(i)("pro_name"))
        i += 1
      End While

      'Console.WriteLine("Movement::FillProductsDropDownMenu - Filltype reg pos : " & _mActProductsRegPos)
      drp_products.SelectedIndex = _mActProductsRegPos
    Else
      drp_products.Enabled = False
    End If
  End Sub

  Private Sub FillSectorsDropDownMenu()
    Dim recordsCount As Integer = 0

    recordsCount = _mSectorsRecordList.Count

    If recordsCount <> 0 Then
      Dim i As Integer = 0

      While i < recordsCount
        If (_mSectorsValues.ContainsKey(_mSectorsRecordList.Item(i)("id")) = False) Then
          _mSectorsValues.Add(
            _mSectorsRecordList.Item(i)("id"),
            _mSectorsRecordList.Item(i)("sec_name")
          )
        End If

        drp_sectors.Items.Add(_mSectorsRecordList.Item(i)("sec_name"))
        i += 1
      End While

      drp_sectors.SelectedIndex = _mActSectorsRegPos
    Else
      drp_sectors.Enabled = False
    End If
  End Sub

  Private Sub UpdateControls()
    _mUtils.ResetControls(Me)
    ResetErrorLabel()

    If (_mMovementsRecordList.Count <> 0) Then
      If (IsDBNull(_mMovementsRecordList.Item(_mActMovementsRegPos)("id")) <> True) Then
        SwitchOnOffControlDataButtons(True)

        Dim p_id As Integer = _mMovementsRecordList.Item(_mActMovementsRegPos)("id_product")
        Dim s_id As Integer = _mMovementsRecordList.Item(_mActMovementsRegPos)("id_sector")

       'Console.WriteLine("------------------------------------------------------------")
       'Console.WriteLine("id : " & _mMovementsRecordList.Item(_mActMovementsRegPos)("id"))
       'Console.WriteLine("id_product : " & _mMovementsRecordList.Item(_mActMovementsRegPos)("id_product"))
       'Console.WriteLine("product : " & _mProductsValues.Item(p_id))
       'Console.WriteLine("id_sector : " & _mMovementsRecordList.Item(_mActMovementsRegPos)("id_sector"))
       'Console.WriteLine("sector : " & _mSectorsValues.Item(s_id))
       'Console.WriteLine("count : " & _mMovementsRecordList.Item(_mActMovementsRegPos)("count"))
       'Console.WriteLine("operation : " & _mMovementsRecordList.Item(_mActMovementsRegPos)("operation"))
       'Console.WriteLine("move_date : " & _mMovementsRecordList.Item(_mActMovementsRegPos)("mov_date"))
       'Console.WriteLine("------------------------------------------------------------")

        date_time_picker.Value = _mMovementsRecordList.Item(_mActMovementsRegPos)("mov_date")
        drp_products.SelectedItem = _mProductsValues.Item(p_id)
        drp_sectors.SelectedItem = _mSectorsValues.Item(s_id)
        txt_amount.Text = _mMovementsRecordList.Item(_mActMovementsRegPos)("count")

        If _mMovementsRecordList.Item(_mActMovementsRegPos)("operation") = "A" Then
          rad_add.Checked = True
          rad_remove.Checked = False
          Else
          rad_add.Checked = False
          rad_remove.Checked = True
        End If
      End If
    Else
      SwitchOnOffControlDataButtons(False)
    End If
  End Sub

  Private Sub UpdateMovementsMenu()
    Dim i As Integer = 0
    Dim recordsCount As Integer = 0

    drp_movements.Items.Clear()
    recordsCount = _mMovementsRecordList.Count

    If recordsCount <> 0 Then
      While i < recordsCount
        drp_movements.Items.Add(_mMovementsRecordList.Item(i)("id"))
        i += 1
      End While
      drp_movements.SelectedIndex = _mActMovementsRegPos
    Else
      drp_movements.Enabled = False
    End If
  End Sub

  Private Sub AddNewRecordToRecordList()
    Dim fields As Hashtable = New Hashtable()
    Dim id As Integer = 1

    If _mMovementsRecordList.Count <> 0 Then
      id = _mMovementsRecordList.Item(_mMovementsRecordList.Count - 1)("id") + 1
    End If

Console.WriteLine("id : " & id)

    fields("id") = id
    fields("id_product") = _mProductsValues.Keys(drp_products.SelectedIndex)
    fields("id_sector") = _mSectorsValues.Keys(drp_sectors.SelectedIndex)
    fields("count") = txt_amount.Text
    fields("mov_date") = date_time_picker.Value.ToUniversalTime()

    If (rad_add.Checked = True) Then
      fields("operation") = "A"
    Else
      fields("operation") = "B"
    End If

      Console.WriteLine("Before save date : " & date_time_picker.Value.ToUniversalTime())
      _mMovementsDao.insert(fields)

    _mMovementsRecordList.Add(fields)
  End Sub

  Private Sub ResetErrorLabel()
    lab_error_msg.Visible = False
  End Sub

  Private Sub ShowErrorLabel(ByRef msg As String)
    lab_error_msg.Text = msg
    lab_error_msg.Visible = True
  End Sub

  Private Function ValidateInputs() As Boolean
    ''Console.WriteLine("------ Movements: Inside ValidateInputs() ------")
    If _mUtils.CheckExpressionByPatternMatching(txt_amount.Text, "^[0-9]+$") = False Then
      Console.WriteLine("------ Movements: Inside ValidateInputs() -> IF 1 ------")
      ShowErrorLabel("Error: Stock Invalido")
      Return False
    End If

    Return True
  End Function

  Private Sub CustomResetControls()
    drp_products.SelectedIndex = 0
    drp_sectors.SelectedIndex = 0
    txt_amount.Text = 0
    rad_add.Checked = True
    rad_remove.Checked = False
  End Sub

  '/-------------------------- EventHandlers Methods --------------------------/
  Private Sub Movements_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    _mMovementsDao = MovementDao.GetInstance()
    _mMovementsRecordList = _mMovementsDao.GetRecords()
    _mActMovementsRegPos = _mMovementsDao.GetRegisterPos()

    _mSectorsDao = SectorsDao.GetInstance()
    _mSectorsValues = New Dictionary(Of Integer, String)
    _mSectorsRecordList = _mSectorsDao.GetRecords()
    _mActSectorsRegPos = _mSectorsDao.GetRegisterPos()

    _mProductsDao = ProductsDao.GetInstance()
    _mProductsValues = New Dictionary(Of Integer, String)
    _mProductsRecordList = _mProductsDao.GetRecords()
    _mActProductsRegPos = _mProductsDao.GetRegisterPos()

    _mUtils = New Utils()

    ResetErrorLabel()
    FillProductsDropDownMenu()
    FillSectorsDropDownMenu()

    UpdateControls()
    UpdateMovementsMenu()
  End Sub

  Private Sub drp_movements_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles drp_movements.SelectedIndexChanged
    _mMovementsDao.SetRegisterPos(drp_movements.SelectedIndex)
    _mActMovementsRegPos = drp_movements.SelectedIndex

    UpdateControls()
  End Sub

  Private Sub drp_sectors_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles drp_sectors.SelectedIndexChanged
    _mActSectorsRegPos = drp_sectors.SelectedIndex
  End Sub

  Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
    'Console.WriteLine("Movements - I press Exit button")
    ResetErrorLabel()
    Me.Hide()
    Form1.Show()
    Form1.Focus()
  End Sub

  Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
    If ValidateInputs() = True Then
      ResetErrorLabel()

      AddNewRecordToRecordList()
      _mMovementsDao.SetRecordList(_mMovementsRecordList)

      UpdateMovementsMenu()

      '_mMovementsDao.SaveRecord(True)

      ' Back To Normal Menu Behavior
      SwitchOnOffControlSaveButtons(False)
      SwitchOnOffControlInputsForNewData(False)

      UpdateControls()
    End If
  End Sub

  Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
    SwitchOnOffControlSaveButtons(False)
    UpdateControls()
  End Sub

  Private Sub btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new.Click
    CustomResetControls()
    SwitchOnOffControlSaveButtons(True)
    SwitchOnOffControlDataButtons(False)
    SwitchOnOffControlInputsForNewData(True)

    ' focus on the sectors movement menu
    drp_products.Focus()
  End Sub

  Private Sub btn_next_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_next.Click
    Dim futRegPos As Integer = 0
    Dim eleRecordsCount As Integer = _mMovementsRecordList.Count

    futRegPos = _mActMovementsRegPos + 1
    _mActMovementsRegPos = _mUtils.UpdateRegisterPos(futRegPos, eleRecordsCount)
    drp_movements.SelectedIndex = _mActMovementsRegPos
  End Sub

  Private Sub btn_prev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_prev.Click
    Dim futRegPos As Integer = 0
    Dim eleRecordsCount As Integer = _mMovementsRecordList.Count

    futRegPos = _mActMovementsRegPos - 1
    _mActMovementsRegPos = _mUtils.UpdateRegisterPos(futRegPos, eleRecordsCount)
    drp_movements.SelectedIndex = _mActMovementsRegPos
  End Sub

Private Sub date_time_picker_ValueChanged(sender As Object, e As EventArgs) Handles date_time_picker.ValueChanged
  Console.WriteLine("Date Time Picker value : " & date_time_picker.Value.ToString("dd/MM/yyyy"))
End Sub
End Class