Public Class Form1

  Private _mUtils As Utils


  Private Sub DEBUG_DisableSomeButtons()
    btn_products.Enabled = False
    btn_mov_updates.Enabled = False
  End Sub

  Private Sub DEBUG_CloseAllHandlers()
  End Sub

  '/-------------------------- EventHandlers Methods --------------------------/
  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Console.WriteLine("Dentro de Menu Principal")
    DEBUG_DisableSomeButtons()

    _mUtils = New Utils()
  End Sub

  Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exit.Click
    DEBUG_CloseAllHandlers()
    Me.DestroyHandle()
  End Sub

  Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
    DEBUG_CloseAllHandlers()
    Me.DestroyHandle()
  End Sub

  'Private Sub BtnProducts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_products.Click
  '    _mUtils.ChangeFocusForm(Me, "Productos")
  'End Sub

  Private Sub btnTypes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_types.Click
    _mUtils.ChangeFocusForm(Me, "Types")
  End Sub

  Private Sub btn_Sectors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sectors.Click
    _mUtils.ChangeFocusForm(Me, "Sector")
  End Sub

  'Private Sub btn_MovUpdates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mov_updates.Click
  '    _mUtils.ChangeFocusForm(Me, "Actualizacion_Movimientos")
  'End Sub
End Class