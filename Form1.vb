Public Class Form1
  Private _mUtils As Utils

  '/-------------------------- EventHandlers Methods --------------------------/
  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    _mUtils = New Utils()
  End Sub

  Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
    Me.DestroyHandle()
  End Sub

  Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
    Me.DestroyHandle()
  End Sub

  Private Sub BtnProducts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_products.Click
    _mUtils.ChangeFocusForm(Me, "Product")
  End Sub

  Private Sub btnTypes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_types.Click
    _mUtils.ChangeFocusForm(Me, "Types")
  End Sub

  Private Sub btn_Sectors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sectors.Click
    _mUtils.ChangeFocusForm(Me, "Sector")
  End Sub

  Private Sub btn_MovUpdates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mov_updates.Click
    _mUtils.ChangeFocusForm(Me, "Movement")
  End Sub
End Class