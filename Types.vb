Public Class Types
  Inherits System.Windows.Forms.Form

  Private _mTypesRecordList As ArrayList
  Private _mTypesDao As TypesDao
  Private _mUtils As Utils
  Private _mActTypesRegPos As Integer

  Private Sub SwitchOnOffControlSaveButtons(ByVal state As Boolean)
    btn_save.Enabled = state
    btn_save.Visible = state

    btn_cancel.Enabled = state
    btn_cancel.Visible = state

    txt_name.Enabled = True
    txt_codint.Enabled = True

    If state = True Then
      btn_new.Enabled = False
    Else
      btn_new.Enabled = True
    End If
  End Sub

  Private Sub SwitchOnOffControlDataButtons(ByVal state As Boolean)
    ' DropDown Controllers
    drp_types.Enabled = state

    ' Buttons Controllers
    btn_next.Enabled = state
    btn_prev.Enabled = state

    btn_update.Enabled = state
    btn_delete.Enabled = state
  End Sub

  Private Sub SwitchOnOffInputControls(ByVal state As Boolean)
    txt_name.Enabled = state
    txt_codint.Enabled = state
  End Sub

  Private Sub UpdateControls()
    _mUtils.ResetControls(Me)

    If (_mTypesRecordList.Count <> 0) Then
      If (IsDBNull(_mTypesRecordList.Item(_mActTypesRegPos)("typ_name")) <> True) Then
        txt_name.Text = _mTypesRecordList.Item(_mActTypesRegPos)("typ_name")
        txt_codint.Text = _mTypesRecordList.Item(_mActTypesRegPos)("codint")
      End If

      SwitchOnOffInputControls(True)
      SwitchOnOffControlDataButtons(True)
    Else
      SwitchOnOffControlDataButtons(False)
      SwitchOnOffInputControls(False)
    End If
  End Sub

  Private Sub UpdateTypesMenu()
    Dim i As Integer = 0
    Dim recordsCount As Integer = 0

    drp_types.Items.Clear()
    recordsCount = _mTypesRecordList.Count

    If recordsCount <> 0 Then
      While i < recordsCount
        drp_types.Items.Add(_mTypesRecordList.Item(i)("typ_name"))
        i += 1
      End While
      drp_types.SelectedIndex = _mActTypesRegPos
    Else
      drp_types.Enabled = False
    End If
  End Sub

  Private Sub AddEmptyElementInTypesMenu()
    drp_types.Items.Add("")
    drp_types.SelectedIndex = drp_types.Items.Count - 1
  End Sub

  Private Sub UpdateRecordListData()
    _mTypesRecordList(_mActTypesRegPos)("typ_name") = txt_name.Text
    _mTypesRecordList(_mActTypesRegPos)("codint") = txt_codint.Text
  End Sub

  Private Sub AddNewRecordToRecordList()
    Dim fields As Hashtable = New Hashtable()
    Dim itemsCount As Integer = _mTypesRecordList.Count
    Dim id As Integer = 1

    If (itemsCount > 0) Then
      id = _mTypesRecordList(itemsCount - 1)("id") + 1
    End If

    fields("id") = id
    fields("typ_name") = txt_name.Text
    fields("codint") = txt_codint.Text

    _mTypesRecordList.Add(fields)
  End Sub

  Private Function ValidateInputs() As Boolean
    Dim valid As Boolean = True

    If _mUtils.CheckExpressionByPatternMatching(txt_name.Text, "^[a-zA-Z]+$") = False Then
      MsgBox("Error: Invalid Name")
      valid = False
    End If

    If _mUtils.CheckExpressionByPatternMatching(txt_codint.Text, "[A-Z]{4}-[0-9]{2}\/[A-Z]{1}[0-9]{1}") = False Then
      MsgBox("Error: Invalid Internal Code")
      valid = False
    End If

    Return valid
  End Function

  '/-------------------------- EventHandlers Methods --------------------------/
  Private Sub Types_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    _mTypesDao = TypesDao.GetInstance()
    _mUtils = New Utils()
    _mTypesRecordList = _mTypesDao.GetRecords()
    _mActTypesRegPos = _mTypesDao.GetRegisterPos()

    UpdateControls()
    UpdateTypesMenu()
  End Sub

  Private Sub drp_types_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles drp_types.SelectedIndexChanged
    _mTypesDao.SetRegisterPos(drp_types.SelectedIndex)
    _mActTypesRegPos = drp_types.SelectedIndex
    UpdateControls()
  End Sub

  Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
    Me.Hide()
    Form1.Show()
    Form1.Focus()
  End Sub

  Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
    If ValidateInputs() = True Then

      UpdateRecordListData()
      _mTypesDao.SetRecordList(_mTypesRecordList)

      UpdateTypesMenu()
      _mTypesDao.SaveRecord(False)

      ' Back To Normal Menu Behavior
      SwitchOnOffControlDataButtons(True)
    End If
  End Sub

  Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
    If ValidateInputs() = True Then

      AddNewRecordToRecordList()
      _mTypesDao.SetRecordList(_mTypesRecordList)

      UpdateTypesMenu()
      _mTypesDao.SaveRecord(True)

      ' Back To Normal Menu Behavior
      SwitchOnOffControlSaveButtons(False)
    End If

    UpdateControls()
  End Sub

  Private Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
    SwitchOnOffControlSaveButtons(False)
    UpdateControls()
  End Sub

  Private Sub btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new.Click
    _mUtils.ResetControls(Me)
    SwitchOnOffControlSaveButtons(True)
    SwitchOnOffControlDataButtons(False)
  End Sub

  Private Sub btn_next_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_next.Click
    Dim futRegPos As Integer = 0
    Dim eleRecordsCount As Integer = _mTypesRecordList.Count

    futRegPos = _mActTypesRegPos + 1
    _mActTypesRegPos = _mUtils.UpdateRegisterPos(futRegPos, eleRecordsCount)
    drp_types.SelectedIndex = _mActTypesRegPos
  End Sub

  Private Sub btn_prev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_prev.Click
    Dim futRegPos As Integer = _mActTypesRegPos - 1
    Dim eleRecordsCount As Integer = _mTypesRecordList.Count

    _mActTypesRegPos = _mUtils.UpdateRegisterPos(futRegPos, eleRecordsCount)
    drp_types.SelectedIndex = _mActTypesRegPos
  End Sub

  Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
    Dim hasConstraints As Boolean = False
    Dim id As Integer = _mTypesRecordList.Item(_mActTypesRegPos)("id")

    ' Validation against database
    hasConstraints = _mTypesDao.HasConstraints(id)

    If (hasConstraints = False) Then
      _mTypesDao.SetRegisterPos(_mActTypesRegPos)
      _mTypesRecordList.RemoveAt(_mActTypesRegPos)

      drp_types.Items.RemoveAt(_mActTypesRegPos)
      _mTypesDao.EraseRecord()

      If _mActTypesRegPos = _mTypesRecordList.Count Then
        _mActTypesRegPos -= 1
      End If

      ' Back To Normal Menu Behavior
      SwitchOnOffControlDataButtons(True)

      UpdateControls()
      UpdateTypesMenu()
    Else
      MsgBox("Error: Can't erase a Product Type currently related to a Product.")
    End If
  End Sub

End Class
