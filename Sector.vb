﻿Public Class Sector
  Inherits System.Windows.Forms.Form

  Private _mSectorsRecordList As ArrayList
  Private _mSectorsDao As SectorsDao
  Private _mUtils As Utils
  Private _mActSectorsRegPos As Integer

  Private Sub SwitchOnOffControlSaveButtons(ByVal state As Boolean)
    btn_save.Enabled = state
    btn_save.Visible = state

    btn_cancel.Enabled = state
    btn_cancel.Visible = state

    txt_name.Enabled = True
    txt_hall.Enabled = True

    If state = True Then
      btn_new.Enabled = False
    Else
      btn_new.Enabled = True
    End If
  End Sub

  Private Sub SwitchOnOffControlDataButtons(ByVal state As Boolean)
    ' DropDown Controllers
    drp_sectors.Enabled = state

    ' Buttons Controllers
    btn_delete.Enabled = state
    btn_next.Enabled = state
    btn_prev.Enabled = state

    btn_update.Enabled = state
    btn_delete.Enabled = state
  End Sub

  Private Sub SwitchOnOffInputControls(ByVal state As Boolean)
    txt_name.Enabled = state
    txt_hall.Enabled = state
  End Sub

  Private Sub UpdateControls()
    _mUtils.ResetControls(Me)

    If (_mSectorsRecordList.Count <> 0) Then
      If (IsDBNull(_mSectorsRecordList.Item(_mActSectorsRegPos)("sec_name")) <> True) Then
        txt_name.Text = _mSectorsRecordList.Item(_mActSectorsRegPos)("sec_name")
        txt_hall.Text = _mSectorsRecordList.Item(_mActSectorsRegPos)("hall")
      End If

      SwitchOnOffInputControls(True)
      SwitchOnOffControlDataButtons(True)
    Else
      SwitchOnOffControlDataButtons(False)
      SwitchOnOffInputControls(False)
    End If
  End Sub

  Private Sub UpdateSectorsMenu()
    Dim i As Integer = 0
    Dim recordsCount As Integer = 0

    drp_sectors.Items.Clear()
    recordsCount = _mSectorsRecordList.Count

    If recordsCount <> 0 Then
      While i < recordsCount
        drp_sectors.Items.Add(_mSectorsRecordList.Item(i)("sec_name"))
        i += 1
      End While
      drp_sectors.SelectedIndex = i - 1
      _mActSectorsRegPos = i - 1
    Else
      drp_sectors.Enabled = False
    End If
  End Sub

  Private Sub AddEmptyElementInSectorsMenu()
    drp_sectors.Items.Add("")
    drp_sectors.SelectedIndex = drp_sectors.Items.Count - 1
  End Sub

  Private Sub UpdateRecordListData()
    _mSectorsRecordList(_mActSectorsRegPos)("sec_name") = txt_name.Text
    _mSectorsRecordList(_mActSectorsRegPos)("hall") = txt_hall.Text
  End Sub

  Private Sub AddNewRecordToRecordList()
    Dim fields As Hashtable = New Hashtable()
    Dim itemsCount As Integer = _mSectorsRecordList.Count
    Dim id As Integer = 1

    If (itemsCount > 0) Then
      id = _mSectorsRecordList(itemsCount - 1)("id") + 1
    End If

    fields("id") = id
    fields("sec_name") = txt_name.Text
    fields("hall") = txt_hall.Text

    _mSectorsRecordList.Add(fields)
  End Sub

  Private Function ValidateInputs() As Boolean
    Dim valid As Boolean = True
    If _mUtils.CheckExpressionByPatternMatching(txt_name.Text, "^[a-zA-Z]+$") = False Then
      MsgBox("Error: Invalid Name")
      valid = False
    End If

    If _mUtils.CheckExpressionByPatternMatching(txt_hall.Text, "^[0-9]+$") = False Then
      MsgBox("Error: Invalid Warehouse Row")
      valid = False
    End If

    Return valid
  End Function

  '/-------------------------- EventHandlers Methods --------------------------/
  Private Sub Sectors_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    _mSectorsDao = SectorsDao.GetInstance()
    _mUtils = New Utils()
    _mSectorsRecordList = _mSectorsDao.GetRecords()
    _mActSectorsRegPos = _mSectorsDao.GetRegisterPos()

    UpdateControls()
    UpdateSectorsMenu()
  End Sub

    Private Sub drp_sectors_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles drp_sectors.SelectedIndexChanged
    _mSectorsDao.SetRegisterPos(drp_sectors.SelectedIndex)
    _mActSectorsRegPos = drp_sectors.SelectedIndex
    UpdateControls()
  End Sub
  Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
    Me.Hide()
    Form1.Show()
    Form1.Focus()
  End Sub

  Private Sub btn_clean_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
    _mUtils.ResetControls(Me)
  End Sub

  Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
    If ValidateInputs() = True Then

      UpdateRecordListData()
      _mSectorsDao.SetRecordList(_mSectorsRecordList)

      UpdateSectorsMenu()
      _mSectorsDao.SaveRecord(False)

      ' Back To Normal Menu Behavior
      SwitchOnOffControlDataButtons(True)
    End If
  End Sub

  Private Sub btn_save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_save.Click
    If ValidateInputs() = True Then

      AddNewRecordToRecordList()
      _mSectorsDao.SetRecordList(_mSectorsRecordList)

      UpdateSectorsMenu()
      _mSectorsDao.SaveRecord(True)

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
    Dim eleRecordsCount As Integer = _mSectorsRecordList.Count

    futRegPos = _mActSectorsRegPos + 1
    _mActSectorsRegPos = _mUtils.UpdateRegisterPos(futRegPos, eleRecordsCount)
    drp_sectors.SelectedIndex = _mActSectorsRegPos
  End Sub

  Private Sub btn_prev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_prev.Click
    Dim futRegPos As Integer = _mActSectorsRegPos - 1
    Dim eleRecordsCount As Integer = _mSectorsRecordList.Count

    _mActSectorsRegPos = _mUtils.UpdateRegisterPos(futRegPos, eleRecordsCount)
    drp_sectors.SelectedIndex = _mActSectorsRegPos
  End Sub

  Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
    Dim hasConstraints As Boolean = False
    Dim id As Integer = _mSectorsRecordList.Item(_mActSectorsRegPos)("id")

    ' Validation against database
    hasConstraints = _mSectorsDao.HasConstraints(id)

    If (hasConstraints = False) Then
      _mSectorsDao.SetRegisterPos(_mActSectorsRegPos)
      _mSectorsRecordList.RemoveAt(_mActSectorsRegPos)

      drp_sectors.Items.RemoveAt(_mActSectorsRegPos)
      _mSectorsDao.EraseRecord()

      If _mActSectorsRegPos = _mSectorsRecordList.Count Then
        _mActSectorsRegPos -= 1
      End If

      ' Back To Normal Menu Behavior
      SwitchOnOffControlDataButtons(True)

      UpdateControls()
      UpdateSectorsMenu()
    Else
      MsgBox("Error: Can't erase a Sector currently related to a Product.")
    End If
  End Sub

End Class
