﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Product
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
    Me.lab_error_msg = New System.Windows.Forms.Label()
    Me.txt_stock = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
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
    Me.Label2 = New System.Windows.Forms.Label()
    Me.rad_state_a = New System.Windows.Forms.RadioButton()
    Me.rad_state_b = New System.Windows.Forms.RadioButton()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.drp_products = New System.Windows.Forms.ComboBox()
    Me.drp_types = New System.Windows.Forms.ComboBox()
    Me.lab_type_title = New System.Windows.Forms.Label()
    Me.lab_type_value = New System.Windows.Forms.Label()
    Me.SuspendLayout()
    '
    'lab_error_msg
    '
    Me.lab_error_msg.AutoSize = True
    Me.lab_error_msg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
    Me.lab_error_msg.ForeColor = System.Drawing.Color.Crimson
    Me.lab_error_msg.Location = New System.Drawing.Point(98, 136)
    Me.lab_error_msg.Name = "lab_error_msg"
    Me.lab_error_msg.Size = New System.Drawing.Size(89, 13)
    Me.lab_error_msg.TabIndex = 101
    Me.lab_error_msg.Text = "Error Msg . . . "
    '
    'txt_stock
    '
    Me.txt_stock.Location = New System.Drawing.Point(95, 89)
    Me.txt_stock.MaxLength = 10
    Me.txt_stock.Name = "txt_stock"
    Me.txt_stock.Size = New System.Drawing.Size(42, 20)
    Me.txt_stock.TabIndex = 12
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(9, 96)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(38, 13)
    Me.Label3.TabIndex = 100
    Me.Label3.Text = "Stock:"
    '
    'txt_name
    '
    Me.txt_name.Location = New System.Drawing.Point(95, 63)
    Me.txt_name.MaxLength = 90
    Me.txt_name.Name = "txt_name"
    Me.txt_name.Size = New System.Drawing.Size(179, 20)
    Me.txt_name.TabIndex = 10
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(9, 70)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(47, 13)
    Me.Label1.TabIndex = 98
    Me.Label1.Text = "Nombre:"
    '
    'btn_clean
    '
    Me.btn_clean.Location = New System.Drawing.Point(104, 200)
    Me.btn_clean.Name = "btn_clean"
    Me.btn_clean.Size = New System.Drawing.Size(75, 23)
    Me.btn_clean.TabIndex = 24
    Me.btn_clean.Text = "Limpiar"
    Me.btn_clean.UseVisualStyleBackColor = True
    '
    'btn_delete
    '
    Me.btn_delete.Location = New System.Drawing.Point(199, 200)
    Me.btn_delete.Name = "btn_delete"
    Me.btn_delete.Size = New System.Drawing.Size(75, 23)
    Me.btn_delete.TabIndex = 25
    Me.btn_delete.Text = "Eliminar"
    Me.btn_delete.UseVisualStyleBackColor = True
    '
    'btn_update
    '
    Me.btn_update.Location = New System.Drawing.Point(10, 200)
    Me.btn_update.Name = "btn_update"
    Me.btn_update.Size = New System.Drawing.Size(75, 23)
    Me.btn_update.TabIndex = 23
    Me.btn_update.Text = "Actualizar"
    Me.btn_update.UseVisualStyleBackColor = True
    '
    'btn_new
    '
    Me.btn_new.Location = New System.Drawing.Point(10, 162)
    Me.btn_new.Name = "btn_new"
    Me.btn_new.Size = New System.Drawing.Size(75, 23)
    Me.btn_new.TabIndex = 20
    Me.btn_new.Text = "Nuevo"
    Me.btn_new.UseVisualStyleBackColor = True
    '
    'btn_exit
    '
    Me.btn_exit.Location = New System.Drawing.Point(104, 233)
    Me.btn_exit.Name = "btn_exit"
    Me.btn_exit.Size = New System.Drawing.Size(75, 23)
    Me.btn_exit.TabIndex = 102
    Me.btn_exit.Text = "Salir"
    Me.btn_exit.UseVisualStyleBackColor = True
    '
    'btn_prev
    '
    Me.btn_prev.Location = New System.Drawing.Point(199, 162)
    Me.btn_prev.Name = "btn_prev"
    Me.btn_prev.Size = New System.Drawing.Size(75, 23)
    Me.btn_prev.TabIndex = 22
    Me.btn_prev.Text = "Anterior"
    Me.btn_prev.UseVisualStyleBackColor = True
    '
    'btn_next
    '
    Me.btn_next.Location = New System.Drawing.Point(104, 162)
    Me.btn_next.Name = "btn_next"
    Me.btn_next.Size = New System.Drawing.Size(75, 23)
    Me.btn_next.TabIndex = 21
    Me.btn_next.Text = "Sigiente"
    Me.btn_next.UseVisualStyleBackColor = True
    '
    'btn_cancel
    '
    Me.btn_cancel.Enabled = False
    Me.btn_cancel.Location = New System.Drawing.Point(198, 162)
    Me.btn_cancel.Name = "btn_cancel"
    Me.btn_cancel.Size = New System.Drawing.Size(75, 23)
    Me.btn_cancel.TabIndex = 29
    Me.btn_cancel.Text = "Cancelar"
    Me.btn_cancel.UseVisualStyleBackColor = True
    Me.btn_cancel.Visible = False
    '
    'btn_save
    '
    Me.btn_save.Enabled = False
    Me.btn_save.Location = New System.Drawing.Point(103, 162)
    Me.btn_save.Name = "btn_save"
    Me.btn_save.Size = New System.Drawing.Size(75, 23)
    Me.btn_save.TabIndex = 28
    Me.btn_save.Text = "Guardar"
    Me.btn_save.UseVisualStyleBackColor = True
    Me.btn_save.Visible = False
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(9, 117)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(43, 13)
    Me.Label2.TabIndex = 107
    Me.Label2.Text = "Estado:"
    '
    'rad_state_a
    '
    Me.rad_state_a.AutoSize = True
    Me.rad_state_a.Checked = True
    Me.rad_state_a.Location = New System.Drawing.Point(95, 115)
    Me.rad_state_a.Name = "rad_state_a"
    Me.rad_state_a.Size = New System.Drawing.Size(32, 17)
    Me.rad_state_a.TabIndex = 13
    Me.rad_state_a.TabStop = True
    Me.rad_state_a.Text = "A"
    Me.rad_state_a.UseVisualStyleBackColor = True
    '
    'rad_state_b
    '
    Me.rad_state_b.AutoSize = True
    Me.rad_state_b.Location = New System.Drawing.Point(133, 113)
    Me.rad_state_b.Name = "rad_state_b"
    Me.rad_state_b.Size = New System.Drawing.Size(32, 17)
    Me.rad_state_b.TabIndex = 14
    Me.rad_state_b.TabStop = True
    Me.rad_state_b.Text = "B"
    Me.rad_state_b.UseVisualStyleBackColor = True
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(5, 9)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(82, 13)
    Me.Label6.TabIndex = 99
    Me.Label6.Text = "Elegir Producto:"
    '
    'drp_products
    '
    Me.drp_products.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.drp_products.FormattingEnabled = True
    Me.drp_products.Location = New System.Drawing.Point(95, 6)
    Me.drp_products.Name = "drp_products"
    Me.drp_products.Size = New System.Drawing.Size(179, 21)
    Me.drp_products.TabIndex = 2
    '
    'drp_types
    '
    Me.drp_types.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
    Me.drp_types.FormattingEnabled = True
    Me.drp_types.Location = New System.Drawing.Point(95, 33)
    Me.drp_types.Name = "drp_types"
    Me.drp_types.Size = New System.Drawing.Size(179, 21)
    Me.drp_types.TabIndex = 1
    Me.drp_types.Visible = False
    '
    'lab_type_title
    '
    Me.lab_type_title.AutoSize = True
    Me.lab_type_title.Location = New System.Drawing.Point(5, 36)
    Me.lab_type_title.Name = "lab_type_title"
    Me.lab_type_title.Size = New System.Drawing.Size(31, 13)
    Me.lab_type_title.TabIndex = 113
    Me.lab_type_title.Text = "Tipo:"
    '
    'lab_type_value
    '
    Me.lab_type_value.AutoSize = True
    Me.lab_type_value.Location = New System.Drawing.Point(98, 36)
    Me.lab_type_value.Name = "lab_type_value"
    Me.lab_type_value.Size = New System.Drawing.Size(0, 13)
    Me.lab_type_value.TabIndex = 114
    '
    'Product
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(284, 261)
    Me.Controls.Add(Me.lab_type_value)
    Me.Controls.Add(Me.drp_types)
    Me.Controls.Add(Me.lab_type_title)
    Me.Controls.Add(Me.rad_state_b)
    Me.Controls.Add(Me.rad_state_a)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.btn_cancel)
    Me.Controls.Add(Me.btn_save)
    Me.Controls.Add(Me.btn_prev)
    Me.Controls.Add(Me.btn_next)
    Me.Controls.Add(Me.lab_error_msg)
    Me.Controls.Add(Me.txt_stock)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.drp_products)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.txt_name)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.btn_clean)
    Me.Controls.Add(Me.btn_delete)
    Me.Controls.Add(Me.btn_update)
    Me.Controls.Add(Me.btn_new)
    Me.Controls.Add(Me.btn_exit)
    Me.Name = "Product"
    Me.Text = "Productos"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents lab_error_msg As System.Windows.Forms.Label
  Friend WithEvents txt_stock As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
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
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents rad_state_a As System.Windows.Forms.RadioButton
  Friend WithEvents rad_state_b As System.Windows.Forms.RadioButton
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents drp_products As System.Windows.Forms.ComboBox
  Friend WithEvents drp_types As System.Windows.Forms.ComboBox
  Friend WithEvents lab_type_title As System.Windows.Forms.Label
  Friend WithEvents lab_type_value As System.Windows.Forms.Label
End Class
