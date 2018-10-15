Imports System.Text.RegularExpressions

Public Class Types
    Inherits System.Windows.Forms.Form

    Private _mTypesRecordList As ArrayList
    Private _mTypesDao As TypesDao
    Private _mUtils As Utils
    Private _mActTypesRegPos As Integer

    '/-------------------------- Set Methods --------------------------/
    Private Sub SwitchOnOffControlDataButtons(ByVal state As Boolean)
        btn_new.Enabled = state
        btn_clean.Enabled = state
        btn_next.Enabled = state
        btn_prev.Enabled = state
        btn_update.Enabled = state
        btn_delete.Enabled = state
        btn_exit.Enabled = state
    End Sub

    Private Sub SwitchOnOffInputControls(ByVal state As Boolean)
        txt_name.Enabled = state
        txt_codint.Enabled = state
    End Sub

    Private Sub UpdateControls()
        If (_mTypesRecordList.Count <> 0) Then

            If btn_delete.Enabled = False Then
                SwitchOnOffControlDataButtons(True)
                SwitchOnOffInputControls(True)
            End If

            If (IsDBNull(_mTypesRecordList.Item(_mActTypesRegPos)("typ_name")) <> True) Then
                txt_name.Text = _mTypesRecordList.Item(_mActTypesRegPos)("typ_name")
                txt_codint.Text = _mTypesRecordList.Item(_mActTypesRegPos)("codint")
            End If
        Else
            _mUtils.ResetControls(Me)
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

    Private Sub AddNewEmptyRecordToRecordList()
        Dim fields As Hashtable = New Hashtable()

        fields("typ_name") = ""
        fields("precio") = 0

        _mTypesRecordList.Add(fields)
    End Sub

    Private Sub ResetErrorLabel()
        lab_type_error_msg.Visible = False
    End Sub

    Private Sub ShowErrorLabel(ByRef msg As String)
        lab_type_error_msg.Text = msg
        lab_type_error_msg.Visible = True
    End Sub

    Private Function ValidateInputs() As Boolean
        Dim valid As Boolean = True
        'Console.WriteLine("------ Types: Inside ValidateInputs() ------")
        If Regex.IsMatch(txt_name.Text, "^[a-zA-Z]+$") = False Then
            Console.WriteLine("------ Types: Inside ValidateInputs() -> IF 1 ------")
            ShowErrorLabel("Error: Nombre Invalido")
            valid = False
        End If

        If Regex.IsMatch(txt_codint.Text, "[A-Z]{4}-[0-9]{2}\/[A-Z]{1}[0-9]{1}") = False Then
            Console.WriteLine("------ Types: Inside ValidateInputs() -> IF 2 ------")
            lab_type_error_msg.Text = "Error: COD INT Invalido"
            valid = False
        End If

        Return valid
    End Function

    '/-------------------------- EventHandlers Methods --------------------------/
    Private Sub Types_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Console.WriteLine("Inside of Types Form")
        _mTypesDao = TypesDao.GetInstance()
        _mUtils = New Utils()
        _mTypesRecordList = _mTypesDao.GetRecords()
        _mActTypesRegPos = _mTypesDao.GetRegisterPos()

        ResetErrorLabel()
        UpdateControls()
        UpdateTypesMenu()
    End Sub

    Private Sub drp_types_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles drp_types.SelectedIndexChanged
        _mTypesDao.SetRegisterPos(drp_types.SelectedIndex)
        _mActTypesRegPos = drp_types.SelectedIndex
        UpdateControls()
    End Sub

    Private Sub Types_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        Console.WriteLine("Types - Closing Form")
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            Form1.Show()
            Form1.Focus()
        End If
    End Sub

    Private Sub btn_exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
        Console.WriteLine("Types - Presione Exit button")
        Me.Hide()
        Form1.Show()
        Form1.Focus()
    End Sub

    Private Sub btn_clean_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clean.Click
        _mUtils.ResetControls(Me)
    End Sub

    Private Sub btn_update_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_update.Click
        If ValidateInputs() = True Then
            ResetErrorLabel()

            UpdateRecordListData()
            _mTypesDao.SetRecordList(_mTypesRecordList)

            UpdateTypesMenu()
            _mTypesDao.SaveRecord()

            ' Back To Normal Menu Behavior
            SwitchOnOffControlDataButtons(True)
        End If
    End Sub

    Private Sub btn_new_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_new.Click
        SwitchOnOffControlDataButtons(False)
        btn_update.Enabled = True
        btn_delete.Enabled = True

        AddNewEmptyRecordToRecordList()
        _mTypesDao.CreateNewEmptyRecord()
        AddEmptyElementInTypesMenu()
    End Sub

    Private Sub btn_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_delete.Click
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
End Class