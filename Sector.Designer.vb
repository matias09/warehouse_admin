<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Sector
  Inherits System.Windows.Forms.Form

  'Form reemplaza a Dispose para limpiar la lista de componentes.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Requerido por el Diseñador de Windows Forms
  Private components As System.ComponentModel.IContainer

  'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
  'Se puede modificar usando el Diseñador de Windows Forms.  
  'No lo modifique con el editor de código.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.lab_sector_error_msg = New System.Windows.Forms.Label()
    Me.txt_hall = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.drp_sectors = New System.Windows.Forms.ComboBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.txt_name = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.btn_clean = New System.Windows.Forms.Button()
    Me.btn_delete = New System.Windows.Forms.Button()
    Me.btn_update = New System.Windows.Forms.Button()
    Me.btn_new = New System.Windows.Forms.Button()
    Me.btn_exit = New System.Windows.Forms.Button()
    Me.btn_prev = New System.Windows.Forms.Button()
    Me.btn_next = New System.Windows.Forms.Button()
    Me.btn_cancel = New System.Windows.Forms.Button()
    Me.btn_save = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'lab_sector_error_msg
    '
    Me.lab_sector_error_msg.AutoSize = True
    Me.lab_sector_error_msg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
    Me.lab_sector_error_msg.ForeColor = System.Drawing.Color.Crimson
    Me.lab_sector_error_msg.Location = New System.Drawing.Point(98, 110)
    Me.lab_sector_error_msg.Name = "lab_sector_error_msg"
    Me.lab_sector_error_msg.Size = New System.Drawing.Size(143, 13)
    Me.lab_sector_error_msg.TabIndex = 101
    Me.lab_sector_error_msg.Text = "Error: Codigo Incorrecto"
    '
    'txt_hall
    '
    Me.txt_hall.Location = New System.Drawing.Point(95, 86)
    Me.txt_hall.MaxLength = 10
    Me.txt_hall.Name = "txt_hall"
    Me.txt_hall.Size = New System.Drawing.Size(179, 20)
    Me.txt_hall.TabIndex = 3
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(25, 93)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(40, 13)
    Me.Label3.TabIndex = 100
    Me.Label3.Text = "Pasillo:"
    '
    'drp_sectors
    '
    Me.drp_sectors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.drp_sectors.FormattingEnabled = True
    Me.drp_sectors.Location = New System.Drawing.Point(95, 12)
    Me.drp_sectors.Name = "drp_sectors"
    Me.drp_sectors.Size = New System.Drawing.Size(179, 21)
    Me.drp_sectors.TabIndex = 1
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(21, 15)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(70, 13)
    Me.Label6.TabIndex = 99
    Me.Label6.Text = "Elegir Sector:"
    '
    'txt_name
    '
    Me.txt_name.Location = New System.Drawing.Point(95, 50)
    Me.txt_name.MaxLength = 90
    Me.txt_name.Name = "txt_name"
    Me.txt_name.Size = New System.Drawing.Size(179, 20)
    Me.txt_name.TabIndex = 2
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(25, 57)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(47, 13)
    Me.Label1.TabIndex = 98
    Me.Label1.Text = "Nombre:"
    '
    'btn_clean
    '
    Me.btn_clean.Location = New System.Drawing.Point(104, 174)
    Me.btn_clean.Name = "btn_clean"
    Me.btn_clean.Size = New System.Drawing.Size(75, 23)
    Me.btn_clean.TabIndex = 15
    Me.btn_clean.Text = "Limpiar"
    Me.btn_clean.UseVisualStyleBackColor = True
    '
    'btn_delete
    '
    Me.btn_delete.Location = New System.Drawing.Point(199, 174)
    Me.btn_delete.Name = "btn_delete"
    Me.btn_delete.Size = New System.Drawing.Size(75, 23)
    Me.btn_delete.TabIndex = 16
    Me.btn_delete.Text = "Eliminar"
    Me.btn_delete.UseVisualStyleBackColor = True
    '
    'btn_update
    '
    Me.btn_update.Location = New System.Drawing.Point(10, 174)
    Me.btn_update.Name = "btn_update"
    Me.btn_update.Size = New System.Drawing.Size(75, 23)
    Me.btn_update.TabIndex = 14
    Me.btn_update.Text = "Actualizar"
    Me.btn_update.UseVisualStyleBackColor = True
    '
    'btn_new
    '
    Me.btn_new.Location = New System.Drawing.Point(10, 136)
    Me.btn_new.Name = "btn_new"
    Me.btn_new.Size = New System.Drawing.Size(75, 23)
    Me.btn_new.TabIndex = 10
    Me.btn_new.Text = "Nuevo"
    Me.btn_new.UseVisualStyleBackColor = True
    '
    'btn_exit
    '
    Me.btn_exit.Location = New System.Drawing.Point(104, 226)
    Me.btn_exit.Name = "btn_exit"
    Me.btn_exit.Size = New System.Drawing.Size(75, 23)
    Me.btn_exit.TabIndex = 100
    Me.btn_exit.Text = "Salir"
    Me.btn_exit.UseVisualStyleBackColor = True
    '
    'btn_prev
    '
    Me.btn_prev.Location = New System.Drawing.Point(198, 136)
    Me.btn_prev.Name = "btn_prev"
    Me.btn_prev.Size = New System.Drawing.Size(75, 23)
    Me.btn_prev.TabIndex = 12
    Me.btn_prev.Text = "Anterior"
    Me.btn_prev.UseVisualStyleBackColor = True
    '
    'btn_next
    '
    Me.btn_next.Location = New System.Drawing.Point(105, 136)
    Me.btn_next.Name = "btn_next"
    Me.btn_next.Size = New System.Drawing.Size(75, 23)
    Me.btn_next.TabIndex = 11
    Me.btn_next.Text = "Sigiente"
    Me.btn_next.UseVisualStyleBackColor = True
    '
    'btn_cancel
    '
    Me.btn_cancel.Enabled = False
    Me.btn_cancel.Location = New System.Drawing.Point(198, 136)
    Me.btn_cancel.Name = "btn_cancel"
    Me.btn_cancel.Size = New System.Drawing.Size(75, 23)
    Me.btn_cancel.TabIndex = 21
    Me.btn_cancel.Text = "Cancelar"
    Me.btn_cancel.UseVisualStyleBackColor = True
    Me.btn_cancel.Visible = False
    '
    'btn_save
    '
    Me.btn_save.Enabled = False
    Me.btn_save.Location = New System.Drawing.Point(104, 136)
    Me.btn_save.Name = "btn_save"
    Me.btn_save.Size = New System.Drawing.Size(75, 23)
    Me.btn_save.TabIndex = 20
    Me.btn_save.Text = "Guardar"
    Me.btn_save.UseVisualStyleBackColor = True
    Me.btn_save.Visible = False
    '
    'Sector
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(284, 261)
    Me.Controls.Add(Me.btn_cancel)
    Me.Controls.Add(Me.btn_save)
    Me.Controls.Add(Me.btn_prev)
    Me.Controls.Add(Me.btn_next)
    Me.Controls.Add(Me.lab_sector_error_msg)
    Me.Controls.Add(Me.txt_hall)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.drp_sectors)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.txt_name)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.btn_clean)
    Me.Controls.Add(Me.btn_delete)
    Me.Controls.Add(Me.btn_update)
    Me.Controls.Add(Me.btn_new)
    Me.Controls.Add(Me.btn_exit)
    Me.Name = "Sector"
    Me.Text = "Sectores"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents lab_sector_error_msg As System.Windows.Forms.Label
  Friend WithEvents txt_hall As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents drp_sectors As System.Windows.Forms.ComboBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents txt_name As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents btn_clean As System.Windows.Forms.Button
  Friend WithEvents btn_delete As System.Windows.Forms.Button
  Friend WithEvents btn_update As System.Windows.Forms.Button
  Friend WithEvents btn_new As System.Windows.Forms.Button
  Friend WithEvents btn_exit As System.Windows.Forms.Button
  Friend WithEvents btn_prev As System.Windows.Forms.Button
  Friend WithEvents btn_next As System.Windows.Forms.Button
  Friend WithEvents btn_cancel As System.Windows.Forms.Button
  Friend WithEvents btn_save As System.Windows.Forms.Button
End Class
