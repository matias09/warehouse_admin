<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Types
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
    Me.btn_clean = New System.Windows.Forms.Button()
    Me.btn_update = New System.Windows.Forms.Button()
    Me.btn_prev = New System.Windows.Forms.Button()
    Me.btn_next = New System.Windows.Forms.Button()
    Me.btn_new = New System.Windows.Forms.Button()
    Me.btn_exit = New System.Windows.Forms.Button()
    Me.drp_types = New System.Windows.Forms.ComboBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.txt_name = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.txt_codint = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.btn_save = New System.Windows.Forms.Button()
    Me.btn_cancel = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'btn_clean
    '
    Me.btn_clean.Location = New System.Drawing.Point(98, 173)
    Me.btn_clean.Name = "btn_clean"
    Me.btn_clean.Size = New System.Drawing.Size(75, 23)
    Me.btn_clean.TabIndex = 8
    Me.btn_clean.Text = "Limpiar"
    Me.btn_clean.UseVisualStyleBackColor = True
    '
    'btn_update
    '
    Me.btn_update.Location = New System.Drawing.Point(4, 173)
    Me.btn_update.Name = "btn_update"
    Me.btn_update.Size = New System.Drawing.Size(75, 23)
    Me.btn_update.TabIndex = 7
    Me.btn_update.Text = "Actualizar"
    Me.btn_update.UseVisualStyleBackColor = True
    '
    'btn_prev
    '
    Me.btn_prev.Location = New System.Drawing.Point(193, 135)
    Me.btn_prev.Name = "btn_prev"
    Me.btn_prev.Size = New System.Drawing.Size(75, 23)
    Me.btn_prev.TabIndex = 6
    Me.btn_prev.Text = "Anterior"
    Me.btn_prev.UseVisualStyleBackColor = True
    '
    'btn_next
    '
    Me.btn_next.Location = New System.Drawing.Point(98, 135)
    Me.btn_next.Name = "btn_next"
    Me.btn_next.Size = New System.Drawing.Size(75, 23)
    Me.btn_next.TabIndex = 5
    Me.btn_next.Text = "Sigiente"
    Me.btn_next.UseVisualStyleBackColor = True
    '
    'btn_new
    '
    Me.btn_new.Location = New System.Drawing.Point(4, 135)
    Me.btn_new.Name = "btn_new"
    Me.btn_new.Size = New System.Drawing.Size(75, 23)
    Me.btn_new.TabIndex = 4
    Me.btn_new.Text = "Nuevo"
    Me.btn_new.UseVisualStyleBackColor = True
    '
    'btn_exit
    '
    Me.btn_exit.Location = New System.Drawing.Point(193, 173)
    Me.btn_exit.Name = "btn_exit"
    Me.btn_exit.Size = New System.Drawing.Size(75, 23)
    Me.btn_exit.TabIndex = 90
    Me.btn_exit.Text = "Salir"
    Me.btn_exit.UseVisualStyleBackColor = True
    '
    'drp_types
    '
    Me.drp_types.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.drp_types.FormattingEnabled = True
    Me.drp_types.Location = New System.Drawing.Point(89, 12)
    Me.drp_types.Name = "drp_types"
    Me.drp_types.Size = New System.Drawing.Size(179, 21)
    Me.drp_types.TabIndex = 1
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(15, 15)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(60, 13)
    Me.Label6.TabIndex = 61
    Me.Label6.Text = "Elegir Tipo:"
    '
    'txt_name
    '
    Me.txt_name.Location = New System.Drawing.Point(89, 50)
    Me.txt_name.MaxLength = 90
    Me.txt_name.Name = "txt_name"
    Me.txt_name.Size = New System.Drawing.Size(179, 20)
    Me.txt_name.TabIndex = 2
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(19, 57)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(47, 13)
    Me.Label1.TabIndex = 60
    Me.Label1.Text = "Nombre:"
    '
    'txt_codint
    '
    Me.txt_codint.Location = New System.Drawing.Point(89, 86)
    Me.txt_codint.MaxLength = 10
    Me.txt_codint.Name = "txt_codint"
    Me.txt_codint.Size = New System.Drawing.Size(179, 20)
    Me.txt_codint.TabIndex = 3
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(19, 93)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(58, 13)
    Me.Label3.TabIndex = 63
    Me.Label3.Text = "Codigo Int:"
    '
    'btn_save
    '
    Me.btn_save.Enabled = False
    Me.btn_save.Location = New System.Drawing.Point(98, 135)
    Me.btn_save.Name = "btn_save"
    Me.btn_save.Size = New System.Drawing.Size(75, 23)
    Me.btn_save.TabIndex = 20
    Me.btn_save.Text = "Guardar"
    Me.btn_save.UseVisualStyleBackColor = True
    Me.btn_save.Visible = False
    '
    'btn_cancel
    '
    Me.btn_cancel.Enabled = False
    Me.btn_cancel.Location = New System.Drawing.Point(193, 135)
    Me.btn_cancel.Name = "btn_cancel"
    Me.btn_cancel.Size = New System.Drawing.Size(75, 23)
    Me.btn_cancel.TabIndex = 21
    Me.btn_cancel.Text = "Cancelar"
    Me.btn_cancel.UseVisualStyleBackColor = True
    Me.btn_cancel.Visible = False
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(89, 112)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(112, 13)
    Me.Label2.TabIndex = 91
    Me.Label2.Text = "Formato: XXXX-99/X9"
    '
    'Types
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(284, 203)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.btn_cancel)
    Me.Controls.Add(Me.btn_save)
    Me.Controls.Add(Me.txt_codint)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.drp_types)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.txt_name)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.btn_clean)
    Me.Controls.Add(Me.btn_update)
    Me.Controls.Add(Me.btn_prev)
    Me.Controls.Add(Me.btn_next)
    Me.Controls.Add(Me.btn_new)
    Me.Controls.Add(Me.btn_exit)
    Me.Name = "Types"
    Me.Text = "Types"
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub
    Friend WithEvents btn_clean As System.Windows.Forms.Button
    Friend WithEvents btn_update As System.Windows.Forms.Button
    Friend WithEvents btn_prev As System.Windows.Forms.Button
    Friend WithEvents btn_next As System.Windows.Forms.Button
    Friend WithEvents btn_new As System.Windows.Forms.Button
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents drp_types As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_name As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txt_codint As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents btn_save As System.Windows.Forms.Button
  Friend WithEvents btn_cancel As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
