Imports System.Text.RegularExpressions

Public Class Utils
  Public Sub ChangeFocusForm(ByRef actualForm As Form, ByVal toForm As String)
    actualForm.Hide()
    If (toForm = "Product") Then
      Product.Show()
      Product.Focus()
    ElseIf (toForm = "Types") Then
      Types.Show()
      Types.Focus()
    ElseIf (toForm = "Sector") Then
      Sector.Show()
      Sector.Focus()
    ElseIf (toForm = "Movement") Then
      Movement.Show()
      Movement.Focus()
    End If
  End Sub

  Public Sub ResetControls(ByRef form As Form)
    Dim cControl As Control
    For Each cControl In form.Controls
      If (TypeOf cControl Is TextBox) Then
        cControl.Text = ""
      End If
    Next cControl
  End Sub

  Public Sub EnableControls(ByRef form As Form)
    Dim cControl As Control
    For Each cControl In form.Controls
      cControl.Enabled = True
    Next cControl
  End Sub

  Public Sub DisableControls(ByRef form As Form)
    Dim cControl As Control
    For Each cControl In form.Controls
      cControl.Enabled = False
    Next cControl
  End Sub

  Public Function UpdateRegisterPos(ByVal futRegPos As Integer, ByVal eleRecordsCount As Integer) As Integer
    If (futRegPos = eleRecordsCount) Then
      futRegPos = 0
    ElseIf (futRegPos < 0) Then
      futRegPos = eleRecordsCount - 1
    End If

    Return futRegPos
  End Function

  Public Function CheckExpressionByPatternMatching(ByRef str As String, ByRef pattern As String) As Boolean
    ' Check is the given str match with the pattern provided
    If Regex.IsMatch(str, pattern) = True Then
      Return True
    End If

    Return False
  End Function
End Class
