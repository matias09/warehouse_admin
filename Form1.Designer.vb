<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
    Me.btn_exit = New System.Windows.Forms.Button()
    Me.btn_products = New System.Windows.Forms.Button()
    Me.btn_types = New System.Windows.Forms.Button()
    Me.btn_sectors = New System.Windows.Forms.Button()
    Me.btn_mov_updates = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'btn_exit
    '
    Me.btn_exit.Location = New System.Drawing.Point(111, 227)
    Me.btn_exit.Name = "btn_exit"
    Me.btn_exit.Size = New System.Drawing.Size(75, 23)
    Me.btn_exit.TabIndex = 90
    Me.btn_exit.Text = "Salir"
    Me.btn_exit.UseVisualStyleBackColor = True
    '
    'btn_products
    '
    Me.btn_products.Location = New System.Drawing.Point(99, 31)
    Me.btn_products.Name = "btn_products"
    Me.btn_products.Size = New System.Drawing.Size(96, 23)
    Me.btn_products.TabIndex = 1
    Me.btn_products.Text = "Productos"
    Me.btn_products.UseVisualStyleBackColor = True
    '
    'btn_types
    '
    Me.btn_types.Location = New System.Drawing.Point(99, 74)
    Me.btn_types.Name = "btn_types"
    Me.btn_types.Size = New System.Drawing.Size(96, 23)
    Me.btn_types.TabIndex = 2
    Me.btn_types.Text = "Tipos"
    Me.btn_types.UseVisualStyleBackColor = True
    '
    'btn_sectors
    '
    Me.btn_sectors.Location = New System.Drawing.Point(99, 118)
    Me.btn_sectors.Name = "btn_sectors"
    Me.btn_sectors.Size = New System.Drawing.Size(96, 23)
    Me.btn_sectors.TabIndex = 3
    Me.btn_sectors.Text = "Sectores"
    Me.btn_sectors.UseVisualStyleBackColor = True
    '
    'btn_mov_updates
    '
    Me.btn_mov_updates.AutoSize = True
    Me.btn_mov_updates.Location = New System.Drawing.Point(66, 162)
    Me.btn_mov_updates.Name = "btn_mov_updates"
    Me.btn_mov_updates.Size = New System.Drawing.Size(160, 23)
    Me.btn_mov_updates.TabIndex = 4
    Me.btn_mov_updates.Text = "Actualizacion de Movimientos"
    Me.btn_mov_updates.UseVisualStyleBackColor = True
    '
    'Form1
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(284, 262)
    Me.Controls.Add(Me.btn_mov_updates)
    Me.Controls.Add(Me.btn_sectors)
    Me.Controls.Add(Me.btn_types)
    Me.Controls.Add(Me.btn_products)
    Me.Controls.Add(Me.btn_exit)
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
    Friend WithEvents btn_exit As System.Windows.Forms.Button
    Friend WithEvents btn_products As System.Windows.Forms.Button
    Friend WithEvents btn_types As System.Windows.Forms.Button
    Friend WithEvents btn_sectors As System.Windows.Forms.Button
    Friend WithEvents btn_mov_updates As System.Windows.Forms.Button

End Class
