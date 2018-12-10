<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Movement
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
    Me.zzlabel = New System.Windows.Forms.Label()
    Me.zzlabel2 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.drp_movements = New System.Windows.Forms.ComboBox()
    Me.drp_products = New System.Windows.Forms.ComboBox()
    Me.drp_sectors = New System.Windows.Forms.ComboBox()
    Me.txt_amount = New System.Windows.Forms.TextBox()
    Me.rad_add = New System.Windows.Forms.RadioButton()
    Me.rad_remove = New System.Windows.Forms.RadioButton()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.btn_cancel = New System.Windows.Forms.Button()
    Me.btn_save = New System.Windows.Forms.Button()
    Me.btn_new = New System.Windows.Forms.Button()
    Me.btn_exit = New System.Windows.Forms.Button()
    Me.btn_prev = New System.Windows.Forms.Button()
    Me.btn_next = New System.Windows.Forms.Button()
    Me.btn_delete = New System.Windows.Forms.Button()
    Me.lab_error_msg = New System.Windows.Forms.Label()
    Me.date_time_picker = New System.Windows.Forms.DateTimePicker()
    Me.SuspendLayout()
    '
    'zzlabel
    '
    Me.zzlabel.AutoSize = True
    Me.zzlabel.Location = New System.Drawing.Point(15, 14)
    Me.zzlabel.Name = "zzlabel"
    Me.zzlabel.Size = New System.Drawing.Size(67, 13)
    Me.zzlabel.TabIndex = 0
    Me.zzlabel.Text = "Movimiento :"
    '
    'zzlabel2
    '
    Me.zzlabel2.AutoSize = True
    Me.zzlabel2.Location = New System.Drawing.Point(15, 42)
    Me.zzlabel2.Name = "zzlabel2"
    Me.zzlabel2.Size = New System.Drawing.Size(43, 13)
    Me.zzlabel2.TabIndex = 1
    Me.zzlabel2.Text = "Fecha :"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(15, 73)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(56, 13)
    Me.Label1.TabIndex = 3
    Me.Label1.Text = "Producto :"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(15, 101)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(55, 13)
    Me.Label2.TabIndex = 4
    Me.Label2.Text = "Sectores :"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(15, 132)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(55, 13)
    Me.Label3.TabIndex = 5
    Me.Label3.Text = "Cantidad :"
    '
    'drp_movements
    '
    Me.drp_movements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.drp_movements.Location = New System.Drawing.Point(88, 6)
    Me.drp_movements.Name = "drp_movements"
    Me.drp_movements.Size = New System.Drawing.Size(178, 21)
    Me.drp_movements.TabIndex = 1
    '
    'drp_products
    '
    Me.drp_products.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.drp_products.Enabled = False
    Me.drp_products.FormattingEnabled = True
    Me.drp_products.Location = New System.Drawing.Point(88, 65)
    Me.drp_products.Name = "drp_products"
    Me.drp_products.Size = New System.Drawing.Size(178, 21)
    Me.drp_products.TabIndex = 3
    '
    'drp_sectors
    '
    Me.drp_sectors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.drp_sectors.Enabled = False
    Me.drp_sectors.FormattingEnabled = True
    Me.drp_sectors.Location = New System.Drawing.Point(88, 93)
    Me.drp_sectors.Name = "drp_sectors"
    Me.drp_sectors.Size = New System.Drawing.Size(178, 21)
    Me.drp_sectors.TabIndex = 4
    '
    'txt_amount
    '
    Me.txt_amount.Enabled = False
    Me.txt_amount.Location = New System.Drawing.Point(88, 125)
    Me.txt_amount.Name = "txt_amount"
    Me.txt_amount.Size = New System.Drawing.Size(178, 20)
    Me.txt_amount.TabIndex = 5
    '
    'rad_add
    '
    Me.rad_add.AutoSize = True
    Me.rad_add.Enabled = False
    Me.rad_add.Location = New System.Drawing.Point(88, 155)
    Me.rad_add.Name = "rad_add"
    Me.rad_add.Size = New System.Drawing.Size(52, 17)
    Me.rad_add.TabIndex = 6
    Me.rad_add.TabStop = True
    Me.rad_add.Text = "ALTA"
    Me.rad_add.UseVisualStyleBackColor = True
    '
    'rad_remove
    '
    Me.rad_remove.AutoSize = True
    Me.rad_remove.Enabled = False
    Me.rad_remove.Location = New System.Drawing.Point(155, 155)
    Me.rad_remove.Name = "rad_remove"
    Me.rad_remove.Size = New System.Drawing.Size(51, 17)
    Me.rad_remove.TabIndex = 7
    Me.rad_remove.TabStop = True
    Me.rad_remove.Text = "BAJA"
    Me.rad_remove.UseVisualStyleBackColor = True
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(15, 155)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(62, 13)
    Me.Label4.TabIndex = 7
    Me.Label4.Text = "Operacion :"
    '
    'btn_cancel
    '
    Me.btn_cancel.Enabled = False
    Me.btn_cancel.Location = New System.Drawing.Point(191, 231)
    Me.btn_cancel.Name = "btn_cancel"
    Me.btn_cancel.Size = New System.Drawing.Size(75, 23)
    Me.btn_cancel.TabIndex = 60
    Me.btn_cancel.Text = "Cancelar"
    Me.btn_cancel.UseVisualStyleBackColor = True
    Me.btn_cancel.Visible = False
    '
    'btn_save
    '
    Me.btn_save.Enabled = False
    Me.btn_save.Location = New System.Drawing.Point(104, 231)
    Me.btn_save.Name = "btn_save"
    Me.btn_save.Size = New System.Drawing.Size(75, 23)
    Me.btn_save.TabIndex = 50
    Me.btn_save.Text = "Guardar"
    Me.btn_save.UseVisualStyleBackColor = True
    Me.btn_save.Visible = False
    '
    'btn_new
    '
    Me.btn_new.Location = New System.Drawing.Point(18, 231)
    Me.btn_new.Name = "btn_new"
    Me.btn_new.Size = New System.Drawing.Size(75, 23)
    Me.btn_new.TabIndex = 20
    Me.btn_new.Text = "Nuevo"
    Me.btn_new.UseVisualStyleBackColor = True
    '
    'btn_exit
    '
    Me.btn_exit.Location = New System.Drawing.Point(191, 269)
    Me.btn_exit.Name = "btn_exit"
    Me.btn_exit.Size = New System.Drawing.Size(75, 23)
    Me.btn_exit.TabIndex = 80
    Me.btn_exit.Text = "Salir"
    Me.btn_exit.UseVisualStyleBackColor = True
    '
    'btn_prev
    '
    Me.btn_prev.Location = New System.Drawing.Point(191, 231)
    Me.btn_prev.Name = "btn_prev"
    Me.btn_prev.Size = New System.Drawing.Size(75, 23)
    Me.btn_prev.TabIndex = 40
    Me.btn_prev.Text = "Anterior"
    Me.btn_prev.UseVisualStyleBackColor = True
    '
    'btn_next
    '
    Me.btn_next.Location = New System.Drawing.Point(104, 231)
    Me.btn_next.Name = "btn_next"
    Me.btn_next.Size = New System.Drawing.Size(75, 23)
    Me.btn_next.TabIndex = 30
    Me.btn_next.Text = "Sigiente"
    Me.btn_next.UseVisualStyleBackColor = True
    '
    'btn_delete
    '
    Me.btn_delete.Location = New System.Drawing.Point(18, 269)
    Me.btn_delete.Name = "btn_delete"
    Me.btn_delete.Size = New System.Drawing.Size(75, 23)
    Me.btn_delete.TabIndex = 70
    Me.btn_delete.Text = "Eliminar"
    Me.btn_delete.UseVisualStyleBackColor = True
    '
    'lab_error_msg
    '
    Me.lab_error_msg.AutoSize = True
    Me.lab_error_msg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
    Me.lab_error_msg.ForeColor = System.Drawing.Color.Crimson
    Me.lab_error_msg.Location = New System.Drawing.Point(15, 185)
    Me.lab_error_msg.Name = "lab_error_msg"
    Me.lab_error_msg.Size = New System.Drawing.Size(89, 13)
    Me.lab_error_msg.TabIndex = 110
    Me.lab_error_msg.Text = "Error Msg . . . "
    '
    'date_time_picker
    '
    Me.date_time_picker.Cursor = System.Windows.Forms.Cursors.No
    Me.date_time_picker.CustomFormat = "dd/MM/yyyy"
    Me.date_time_picker.Enabled = False
    Me.date_time_picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom
    Me.date_time_picker.Location = New System.Drawing.Point(88, 35)
    Me.date_time_picker.Name = "date_time_picker"
    Me.date_time_picker.Size = New System.Drawing.Size(178, 20)
    Me.date_time_picker.TabIndex = 2
    Me.date_time_picker.Value = New Date(2018, 12, 8, 0, 0, 0, 0)
    '
    'Movement
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(276, 298)
    Me.Controls.Add(Me.btn_cancel)
    Me.Controls.Add(Me.btn_save)
    Me.Controls.Add(Me.date_time_picker)
    Me.Controls.Add(Me.lab_error_msg)
    Me.Controls.Add(Me.btn_prev)
    Me.Controls.Add(Me.btn_next)
    Me.Controls.Add(Me.btn_delete)
    Me.Controls.Add(Me.btn_new)
    Me.Controls.Add(Me.btn_exit)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.rad_remove)
    Me.Controls.Add(Me.rad_add)
    Me.Controls.Add(Me.txt_amount)
    Me.Controls.Add(Me.drp_sectors)
    Me.Controls.Add(Me.drp_products)
    Me.Controls.Add(Me.drp_movements)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.zzlabel2)
    Me.Controls.Add(Me.zzlabel)
    Me.Name = "Movement"
    Me.Text = "Movement"
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub
    Friend WithEvents zzlabel As System.Windows.Forms.Label
    Friend WithEvents zzlabel2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents drp_movements As System.Windows.Forms.ComboBox
    Friend WithEvents drp_products As System.Windows.Forms.ComboBox
    Friend WithEvents drp_sectors As System.Windows.Forms.ComboBox
    Friend WithEvents txt_amount As System.Windows.Forms.TextBox
    Friend WithEvents rad_add As System.Windows.Forms.RadioButton
    Friend WithEvents rad_remove As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btn_cancel As System.Windows.Forms.Button
    Friend WithEvents btn_save As System.Windows.Forms.Button
    Friend WithEvents btn_new As System.Windows.Forms.Button
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents btn_prev As System.Windows.Forms.Button
    Friend WithEvents btn_next As System.Windows.Forms.Button
    Friend WithEvents btn_delete As System.Windows.Forms.Button
    Friend WithEvents lab_error_msg As System.Windows.Forms.Label
    Friend WithEvents date_time_picker As System.Windows.Forms.DateTimePicker
End Class
