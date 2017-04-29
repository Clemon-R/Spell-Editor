<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class etat
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(etat))
        Me.type = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.list_etat = New System.Windows.Forms.ListBox()
        Me.type_etat = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.add_etat = New System.Windows.Forms.Button()
        Me.supr_etat = New System.Windows.Forms.Button()
        Me.lbl_etat = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'type
        '
        Me.type.FormattingEnabled = True
        Me.type.Items.AddRange(New Object() {"Requie", "Interdit"})
        Me.type.Location = New System.Drawing.Point(94, 35)
        Me.type.Name = "type"
        Me.type.Size = New System.Drawing.Size(121, 21)
        Me.type.TabIndex = 0
        Me.type.Text = "Requie"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Type : "
        '
        'list_etat
        '
        Me.list_etat.FormattingEnabled = True
        Me.list_etat.Location = New System.Drawing.Point(12, 121)
        Me.list_etat.Name = "list_etat"
        Me.list_etat.Size = New System.Drawing.Size(268, 121)
        Me.list_etat.TabIndex = 2
        '
        'type_etat
        '
        Me.type_etat.FormattingEnabled = True
        Me.type_etat.Location = New System.Drawing.Point(94, 62)
        Me.type_etat.Name = "type_etat"
        Me.type_etat.Size = New System.Drawing.Size(121, 21)
        Me.type_etat.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Etat : "
        '
        'add_etat
        '
        Me.add_etat.Location = New System.Drawing.Point(13, 92)
        Me.add_etat.Name = "add_etat"
        Me.add_etat.Size = New System.Drawing.Size(75, 23)
        Me.add_etat.TabIndex = 5
        Me.add_etat.Text = "Ajouter"
        Me.add_etat.UseVisualStyleBackColor = True
        '
        'supr_etat
        '
        Me.supr_etat.Location = New System.Drawing.Point(205, 92)
        Me.supr_etat.Name = "supr_etat"
        Me.supr_etat.Size = New System.Drawing.Size(75, 23)
        Me.supr_etat.TabIndex = 6
        Me.supr_etat.Text = "Supprimer"
        Me.supr_etat.UseVisualStyleBackColor = True
        '
        'lbl_etat
        '
        Me.lbl_etat.AutoSize = True
        Me.lbl_etat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_etat.Location = New System.Drawing.Point(12, 9)
        Me.lbl_etat.Name = "lbl_etat"
        Me.lbl_etat.Size = New System.Drawing.Size(82, 15)
        Me.lbl_etat.TabIndex = 7
        Me.lbl_etat.Text = "Etat Requie"
        '
        'etat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 252)
        Me.Controls.Add(Me.lbl_etat)
        Me.Controls.Add(Me.supr_etat)
        Me.Controls.Add(Me.add_etat)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.type_etat)
        Me.Controls.Add(Me.list_etat)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.type)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "etat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Etat"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents type As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents list_etat As System.Windows.Forms.ListBox
    Friend WithEvents type_etat As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents add_etat As System.Windows.Forms.Button
    Friend WithEvents supr_etat As System.Windows.Forms.Button
    Friend WithEvents lbl_etat As System.Windows.Forms.Label
End Class
