<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mobs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mobs))
        Me.guid = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nom = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.skin_id = New System.Windows.Forms.TextBox()
        Me.align = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.capture = New System.Windows.Forms.ComboBox()
        Me.infos_generale = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.intelligence = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.kamas_max = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.kamas_min = New System.Windows.Forms.TextBox()
        Me.valider = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.genere = New System.Windows.Forms.Button()
        Me.panel_grade = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.supr_spell = New System.Windows.Forms.Button()
        Me.add_spell = New System.Windows.Forms.Button()
        Me.liste_sort = New System.Windows.Forms.ListBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.level_sort = New System.Windows.Forms.ComboBox()
        Me.id_sort = New System.Windows.Forms.TextBox()
        Me.save = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.age = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cha = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.fo = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.int = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.init = New System.Windows.Forms.TextBox()
        Me.generale = New System.Windows.Forms.GroupBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.pm = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.pa = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.pdv = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.xp = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.level = New System.Windows.Forms.TextBox()
        Me.add_grade = New System.Windows.Forms.Button()
        Me.resistance = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.res_pm = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.res_pa = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.res_age = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.res_cha = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.res_fo = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.res_int = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.res_neutre = New System.Windows.Forms.TextBox()
        Me.edited = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.panel_mob = New System.Windows.Forms.GroupBox()
        Me.stops = New System.Windows.Forms.Button()
        Me.reloadmob = New System.Windows.Forms.Button()
        Me.chargermobs = New System.Windows.Forms.Button()
        Me.liste_mobs = New System.Windows.Forms.ListBox()
        Me.infos_bdd = New System.Windows.Forms.GroupBox()
        Me.validedeconnexion = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.valideconnection = New System.Windows.Forms.Button()
        Me.mdp = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dbb = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.user = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.host = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.QuitterAltF4ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitterAltF4ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.AProposToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.infos_generale.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.panel_grade.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.generale.SuspendLayout()
        Me.resistance.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.panel_mob.SuspendLayout()
        Me.infos_bdd.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'guid
        '
        Me.guid.Location = New System.Drawing.Point(68, 15)
        Me.guid.Name = "guid"
        Me.guid.Size = New System.Drawing.Size(100, 20)
        Me.guid.TabIndex = 0
        Me.guid.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(48, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nom"
        '
        'nom
        '
        Me.nom.Location = New System.Drawing.Point(68, 41)
        Me.nom.Name = "nom"
        Me.nom.Size = New System.Drawing.Size(100, 20)
        Me.nom.TabIndex = 1
        Me.nom.Text = "Undefined"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Skin ID"
        '
        'skin_id
        '
        Me.skin_id.Location = New System.Drawing.Point(68, 67)
        Me.skin_id.Name = "skin_id"
        Me.skin_id.Size = New System.Drawing.Size(100, 20)
        Me.skin_id.TabIndex = 2
        Me.skin_id.Text = "0"
        '
        'align
        '
        Me.align.FormattingEnabled = True
        Me.align.Items.AddRange(New Object() {"Neutre", "Bontarien", "Brakmarien"})
        Me.align.Location = New System.Drawing.Point(68, 93)
        Me.align.Name = "align"
        Me.align.Size = New System.Drawing.Size(100, 21)
        Me.align.TabIndex = 3
        Me.align.Text = "Neutre"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Alignement"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 123)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Capturable"
        '
        'capture
        '
        Me.capture.FormattingEnabled = True
        Me.capture.Items.AddRange(New Object() {"Oui", "Non"})
        Me.capture.Location = New System.Drawing.Point(68, 120)
        Me.capture.Name = "capture"
        Me.capture.Size = New System.Drawing.Size(100, 21)
        Me.capture.TabIndex = 4
        Me.capture.Text = "Oui"
        '
        'infos_generale
        '
        Me.infos_generale.Controls.Add(Me.Label13)
        Me.infos_generale.Controls.Add(Me.intelligence)
        Me.infos_generale.Controls.Add(Me.Label12)
        Me.infos_generale.Controls.Add(Me.kamas_max)
        Me.infos_generale.Controls.Add(Me.Label11)
        Me.infos_generale.Controls.Add(Me.kamas_min)
        Me.infos_generale.Controls.Add(Me.valider)
        Me.infos_generale.Controls.Add(Me.Label5)
        Me.infos_generale.Controls.Add(Me.capture)
        Me.infos_generale.Controls.Add(Me.Label4)
        Me.infos_generale.Controls.Add(Me.align)
        Me.infos_generale.Controls.Add(Me.Label3)
        Me.infos_generale.Controls.Add(Me.skin_id)
        Me.infos_generale.Controls.Add(Me.Label2)
        Me.infos_generale.Controls.Add(Me.nom)
        Me.infos_generale.Controls.Add(Me.Label1)
        Me.infos_generale.Controls.Add(Me.guid)
        Me.infos_generale.Location = New System.Drawing.Point(9, 6)
        Me.infos_generale.Name = "infos_generale"
        Me.infos_generale.Size = New System.Drawing.Size(177, 250)
        Me.infos_generale.TabIndex = 10
        Me.infos_generale.TabStop = False
        Me.infos_generale.Text = "Information Générale"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(5, 202)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(61, 13)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Intelligence"
        '
        'intelligence
        '
        Me.intelligence.Location = New System.Drawing.Point(68, 199)
        Me.intelligence.Name = "intelligence"
        Me.intelligence.Size = New System.Drawing.Size(100, 20)
        Me.intelligence.TabIndex = 7
        Me.intelligence.Text = "1"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(5, 176)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 13)
        Me.Label12.TabIndex = 14
        Me.Label12.Text = "Kamas max"
        '
        'kamas_max
        '
        Me.kamas_max.Location = New System.Drawing.Point(68, 173)
        Me.kamas_max.Name = "kamas_max"
        Me.kamas_max.Size = New System.Drawing.Size(100, 20)
        Me.kamas_max.TabIndex = 6
        Me.kamas_max.Text = "0"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 150)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Kamas min"
        '
        'kamas_min
        '
        Me.kamas_min.Location = New System.Drawing.Point(68, 147)
        Me.kamas_min.Name = "kamas_min"
        Me.kamas_min.Size = New System.Drawing.Size(100, 20)
        Me.kamas_min.TabIndex = 5
        Me.kamas_min.Text = "0"
        '
        'valider
        '
        Me.valider.Location = New System.Drawing.Point(68, 221)
        Me.valider.Name = "valider"
        Me.valider.Size = New System.Drawing.Size(75, 23)
        Me.valider.TabIndex = 8
        Me.valider.Text = "Valider"
        Me.valider.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(-1, 26)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(810, 333)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.genere)
        Me.TabPage1.Controls.Add(Me.panel_grade)
        Me.TabPage1.Controls.Add(Me.infos_generale)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(802, 307)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Editeur"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'genere
        '
        Me.genere.Location = New System.Drawing.Point(9, 262)
        Me.genere.Name = "genere"
        Me.genere.Size = New System.Drawing.Size(75, 23)
        Me.genere.TabIndex = 12
        Me.genere.Text = "Générer"
        Me.genere.UseVisualStyleBackColor = True
        Me.genere.Visible = False
        '
        'panel_grade
        '
        Me.panel_grade.Controls.Add(Me.GroupBox2)
        Me.panel_grade.Controls.Add(Me.save)
        Me.panel_grade.Controls.Add(Me.GroupBox1)
        Me.panel_grade.Controls.Add(Me.generale)
        Me.panel_grade.Controls.Add(Me.add_grade)
        Me.panel_grade.Controls.Add(Me.resistance)
        Me.panel_grade.Controls.Add(Me.edited)
        Me.panel_grade.Controls.Add(Me.Label14)
        Me.panel_grade.Location = New System.Drawing.Point(192, 6)
        Me.panel_grade.Name = "panel_grade"
        Me.panel_grade.Size = New System.Drawing.Size(602, 298)
        Me.panel_grade.TabIndex = 11
        Me.panel_grade.TabStop = False
        Me.panel_grade.Text = "Grade 1"
        Me.panel_grade.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.supr_spell)
        Me.GroupBox2.Controls.Add(Me.add_spell)
        Me.GroupBox2.Controls.Add(Me.liste_sort)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.level_sort)
        Me.GroupBox2.Controls.Add(Me.id_sort)
        Me.GroupBox2.Location = New System.Drawing.Point(363, 164)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(221, 125)
        Me.GroupBox2.TabIndex = 36
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sorts"
        '
        'supr_spell
        '
        Me.supr_spell.Location = New System.Drawing.Point(90, 97)
        Me.supr_spell.Name = "supr_spell"
        Me.supr_spell.Size = New System.Drawing.Size(75, 23)
        Me.supr_spell.TabIndex = 37
        Me.supr_spell.Text = "Supprimer"
        Me.supr_spell.UseVisualStyleBackColor = True
        '
        'add_spell
        '
        Me.add_spell.Location = New System.Drawing.Point(9, 97)
        Me.add_spell.Name = "add_spell"
        Me.add_spell.Size = New System.Drawing.Size(75, 23)
        Me.add_spell.TabIndex = 36
        Me.add_spell.Text = "Ajouter"
        Me.add_spell.UseVisualStyleBackColor = True
        '
        'liste_sort
        '
        Me.liste_sort.FormattingEnabled = True
        Me.liste_sort.Location = New System.Drawing.Point(11, 41)
        Me.liste_sort.Name = "liste_sort"
        Me.liste_sort.Size = New System.Drawing.Size(201, 56)
        Me.liste_sort.TabIndex = 35
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(8, 18)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(26, 13)
        Me.Label32.TabIndex = 34
        Me.Label32.Text = "Sort"
        '
        'level_sort
        '
        Me.level_sort.FormattingEnabled = True
        Me.level_sort.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6"})
        Me.level_sort.Location = New System.Drawing.Point(134, 15)
        Me.level_sort.Name = "level_sort"
        Me.level_sort.Size = New System.Drawing.Size(77, 21)
        Me.level_sort.TabIndex = 33
        Me.level_sort.Text = "1"
        '
        'id_sort
        '
        Me.id_sort.Location = New System.Drawing.Point(37, 15)
        Me.id_sort.Name = "id_sort"
        Me.id_sort.Size = New System.Drawing.Size(91, 20)
        Me.id_sort.TabIndex = 31
        Me.id_sort.Text = "0"
        '
        'save
        '
        Me.save.Location = New System.Drawing.Point(233, 15)
        Me.save.Name = "save"
        Me.save.Size = New System.Drawing.Size(73, 23)
        Me.save.TabIndex = 32
        Me.save.Text = "Enresgitrer"
        Me.save.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.age)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.cha)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.fo)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.int)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.init)
        Me.GroupBox1.Location = New System.Drawing.Point(363, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(221, 149)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Stats"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(6, 98)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(35, 13)
        Me.Label25.TabIndex = 26
        Me.Label25.Text = "Agilité"
        '
        'age
        '
        Me.age.Location = New System.Drawing.Point(9, 114)
        Me.age.Name = "age"
        Me.age.Size = New System.Drawing.Size(100, 20)
        Me.age.TabIndex = 15
        Me.age.Text = "0"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(112, 57)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(44, 13)
        Me.Label26.TabIndex = 24
        Me.Label26.Text = "Chance"
        '
        'cha
        '
        Me.cha.Location = New System.Drawing.Point(115, 73)
        Me.cha.Name = "cha"
        Me.cha.Size = New System.Drawing.Size(100, 20)
        Me.cha.TabIndex = 14
        Me.cha.Text = "0"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(6, 57)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 13)
        Me.Label27.TabIndex = 22
        Me.Label27.Text = "Force"
        '
        'fo
        '
        Me.fo.Location = New System.Drawing.Point(9, 73)
        Me.fo.Name = "fo"
        Me.fo.Size = New System.Drawing.Size(100, 20)
        Me.fo.TabIndex = 13
        Me.fo.Text = "0"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(112, 16)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(61, 13)
        Me.Label28.TabIndex = 20
        Me.Label28.Text = "Intelligence"
        '
        'int
        '
        Me.int.Location = New System.Drawing.Point(115, 32)
        Me.int.Name = "int"
        Me.int.Size = New System.Drawing.Size(100, 20)
        Me.int.TabIndex = 12
        Me.int.Text = "0"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(6, 16)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(46, 13)
        Me.Label29.TabIndex = 18
        Me.Label29.Text = "Initiative"
        '
        'init
        '
        Me.init.Location = New System.Drawing.Point(9, 32)
        Me.init.Name = "init"
        Me.init.Size = New System.Drawing.Size(100, 20)
        Me.init.TabIndex = 11
        Me.init.Text = "0"
        '
        'generale
        '
        Me.generale.Controls.Add(Me.Label31)
        Me.generale.Controls.Add(Me.pm)
        Me.generale.Controls.Add(Me.Label30)
        Me.generale.Controls.Add(Me.pa)
        Me.generale.Controls.Add(Me.Label24)
        Me.generale.Controls.Add(Me.pdv)
        Me.generale.Controls.Add(Me.Label23)
        Me.generale.Controls.Add(Me.xp)
        Me.generale.Controls.Add(Me.Label22)
        Me.generale.Controls.Add(Me.level)
        Me.generale.Location = New System.Drawing.Point(6, 44)
        Me.generale.Name = "generale"
        Me.generale.Size = New System.Drawing.Size(124, 240)
        Me.generale.TabIndex = 11
        Me.generale.TabStop = False
        Me.generale.Text = "Générale"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(3, 179)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(22, 13)
        Me.Label31.TabIndex = 40
        Me.Label31.Text = "Pm"
        '
        'pm
        '
        Me.pm.Location = New System.Drawing.Point(6, 195)
        Me.pm.Name = "pm"
        Me.pm.Size = New System.Drawing.Size(100, 20)
        Me.pm.TabIndex = 39
        Me.pm.Text = "0"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(3, 138)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(20, 13)
        Me.Label30.TabIndex = 38
        Me.Label30.Text = "Pa"
        '
        'pa
        '
        Me.pa.Location = New System.Drawing.Point(6, 154)
        Me.pa.Name = "pa"
        Me.pa.Size = New System.Drawing.Size(100, 20)
        Me.pa.TabIndex = 37
        Me.pa.Text = "0"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(3, 97)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(63, 13)
        Me.Label24.TabIndex = 36
        Me.Label24.Text = "Point de vie"
        '
        'pdv
        '
        Me.pdv.Location = New System.Drawing.Point(6, 113)
        Me.pdv.Name = "pdv"
        Me.pdv.Size = New System.Drawing.Size(100, 20)
        Me.pdv.TabIndex = 35
        Me.pdv.Text = "0"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(3, 56)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(60, 13)
        Me.Label23.TabIndex = 34
        Me.Label23.Text = "Expérience"
        '
        'xp
        '
        Me.xp.Location = New System.Drawing.Point(6, 72)
        Me.xp.Name = "xp"
        Me.xp.Size = New System.Drawing.Size(100, 20)
        Me.xp.TabIndex = 33
        Me.xp.Text = "0"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(3, 15)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(33, 13)
        Me.Label22.TabIndex = 32
        Me.Label22.Text = "Level"
        '
        'level
        '
        Me.level.Location = New System.Drawing.Point(6, 31)
        Me.level.Name = "level"
        Me.level.Size = New System.Drawing.Size(100, 20)
        Me.level.TabIndex = 31
        Me.level.Text = "0"
        '
        'add_grade
        '
        Me.add_grade.Location = New System.Drawing.Point(127, 15)
        Me.add_grade.Name = "add_grade"
        Me.add_grade.Size = New System.Drawing.Size(100, 23)
        Me.add_grade.TabIndex = 10
        Me.add_grade.Text = "Ajouter un grade"
        Me.add_grade.UseVisualStyleBackColor = True
        '
        'resistance
        '
        Me.resistance.Controls.Add(Me.Label20)
        Me.resistance.Controls.Add(Me.res_pm)
        Me.resistance.Controls.Add(Me.Label21)
        Me.resistance.Controls.Add(Me.res_pa)
        Me.resistance.Controls.Add(Me.Label19)
        Me.resistance.Controls.Add(Me.res_age)
        Me.resistance.Controls.Add(Me.Label17)
        Me.resistance.Controls.Add(Me.res_cha)
        Me.resistance.Controls.Add(Me.Label18)
        Me.resistance.Controls.Add(Me.res_fo)
        Me.resistance.Controls.Add(Me.Label16)
        Me.resistance.Controls.Add(Me.res_int)
        Me.resistance.Controls.Add(Me.Label15)
        Me.resistance.Controls.Add(Me.res_neutre)
        Me.resistance.Location = New System.Drawing.Point(136, 44)
        Me.resistance.Name = "resistance"
        Me.resistance.Size = New System.Drawing.Size(221, 186)
        Me.resistance.TabIndex = 2
        Me.resistance.TabStop = False
        Me.resistance.Text = "Résistances"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(112, 139)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(33, 13)
        Me.Label20.TabIndex = 30
        Me.Label20.Text = "Pm %"
        '
        'res_pm
        '
        Me.res_pm.Location = New System.Drawing.Point(115, 155)
        Me.res_pm.Name = "res_pm"
        Me.res_pm.Size = New System.Drawing.Size(100, 20)
        Me.res_pm.TabIndex = 17
        Me.res_pm.Text = "0"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 139)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(31, 13)
        Me.Label21.TabIndex = 28
        Me.Label21.Text = "Pa %"
        '
        'res_pa
        '
        Me.res_pa.Location = New System.Drawing.Point(9, 155)
        Me.res_pa.Name = "res_pa"
        Me.res_pa.Size = New System.Drawing.Size(100, 20)
        Me.res_pa.TabIndex = 16
        Me.res_pa.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 98)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(35, 13)
        Me.Label19.TabIndex = 26
        Me.Label19.Text = "Agilité"
        '
        'res_age
        '
        Me.res_age.Location = New System.Drawing.Point(9, 114)
        Me.res_age.Name = "res_age"
        Me.res_age.Size = New System.Drawing.Size(100, 20)
        Me.res_age.TabIndex = 15
        Me.res_age.Text = "0"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(112, 57)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(44, 13)
        Me.Label17.TabIndex = 24
        Me.Label17.Text = "Chance"
        '
        'res_cha
        '
        Me.res_cha.Location = New System.Drawing.Point(115, 73)
        Me.res_cha.Name = "res_cha"
        Me.res_cha.Size = New System.Drawing.Size(100, 20)
        Me.res_cha.TabIndex = 14
        Me.res_cha.Text = "0"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 57)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(34, 13)
        Me.Label18.TabIndex = 22
        Me.Label18.Text = "Force"
        '
        'res_fo
        '
        Me.res_fo.Location = New System.Drawing.Point(9, 73)
        Me.res_fo.Name = "res_fo"
        Me.res_fo.Size = New System.Drawing.Size(100, 20)
        Me.res_fo.TabIndex = 13
        Me.res_fo.Text = "0"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(109, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(61, 13)
        Me.Label16.TabIndex = 20
        Me.Label16.Text = "Intelligence"
        '
        'res_int
        '
        Me.res_int.Location = New System.Drawing.Point(112, 32)
        Me.res_int.Name = "res_int"
        Me.res_int.Size = New System.Drawing.Size(100, 20)
        Me.res_int.TabIndex = 12
        Me.res_int.Text = "0"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(39, 13)
        Me.Label15.TabIndex = 18
        Me.Label15.Text = "Neutre"
        '
        'res_neutre
        '
        Me.res_neutre.Location = New System.Drawing.Point(6, 32)
        Me.res_neutre.Name = "res_neutre"
        Me.res_neutre.Size = New System.Drawing.Size(100, 20)
        Me.res_neutre.TabIndex = 11
        Me.res_neutre.Text = "0"
        '
        'edited
        '
        Me.edited.FormattingEnabled = True
        Me.edited.Items.AddRange(New Object() {"1"})
        Me.edited.Location = New System.Drawing.Point(77, 15)
        Me.edited.Name = "edited"
        Me.edited.Size = New System.Drawing.Size(44, 21)
        Me.edited.TabIndex = 9
        Me.edited.Text = "1"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 18)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(65, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Grade editer"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.panel_mob)
        Me.TabPage2.Controls.Add(Me.infos_bdd)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(802, 307)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Base de donné"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'panel_mob
        '
        Me.panel_mob.Controls.Add(Me.stops)
        Me.panel_mob.Controls.Add(Me.reloadmob)
        Me.panel_mob.Controls.Add(Me.chargermobs)
        Me.panel_mob.Controls.Add(Me.liste_mobs)
        Me.panel_mob.Location = New System.Drawing.Point(197, 6)
        Me.panel_mob.Name = "panel_mob"
        Me.panel_mob.Size = New System.Drawing.Size(397, 258)
        Me.panel_mob.TabIndex = 4
        Me.panel_mob.TabStop = False
        Me.panel_mob.Text = "Charger des mobs"
        Me.panel_mob.Visible = False
        '
        'stops
        '
        Me.stops.Enabled = False
        Me.stops.Location = New System.Drawing.Point(109, 229)
        Me.stops.Name = "stops"
        Me.stops.Size = New System.Drawing.Size(47, 23)
        Me.stops.TabIndex = 5
        Me.stops.Text = "Stop"
        Me.stops.UseVisualStyleBackColor = True
        '
        'reloadmob
        '
        Me.reloadmob.Enabled = False
        Me.reloadmob.Location = New System.Drawing.Point(162, 229)
        Me.reloadmob.Name = "reloadmob"
        Me.reloadmob.Size = New System.Drawing.Size(116, 23)
        Me.reloadmob.TabIndex = 3
        Me.reloadmob.Text = "Recharger les mobs"
        Me.reloadmob.UseVisualStyleBackColor = True
        '
        'chargermobs
        '
        Me.chargermobs.Location = New System.Drawing.Point(284, 229)
        Me.chargermobs.Name = "chargermobs"
        Me.chargermobs.Size = New System.Drawing.Size(107, 23)
        Me.chargermobs.TabIndex = 2
        Me.chargermobs.Text = "Charger les mobs"
        Me.chargermobs.UseVisualStyleBackColor = True
        '
        'liste_mobs
        '
        Me.liste_mobs.FormattingEnabled = True
        Me.liste_mobs.HorizontalScrollbar = True
        Me.liste_mobs.Location = New System.Drawing.Point(6, 16)
        Me.liste_mobs.Name = "liste_mobs"
        Me.liste_mobs.Size = New System.Drawing.Size(385, 212)
        Me.liste_mobs.TabIndex = 1
        '
        'infos_bdd
        '
        Me.infos_bdd.Controls.Add(Me.validedeconnexion)
        Me.infos_bdd.Controls.Add(Me.Label6)
        Me.infos_bdd.Controls.Add(Me.valideconnection)
        Me.infos_bdd.Controls.Add(Me.mdp)
        Me.infos_bdd.Controls.Add(Me.Label7)
        Me.infos_bdd.Controls.Add(Me.dbb)
        Me.infos_bdd.Controls.Add(Me.Label8)
        Me.infos_bdd.Controls.Add(Me.user)
        Me.infos_bdd.Controls.Add(Me.Label9)
        Me.infos_bdd.Controls.Add(Me.host)
        Me.infos_bdd.Controls.Add(Me.Label10)
        Me.infos_bdd.Location = New System.Drawing.Point(9, 6)
        Me.infos_bdd.Name = "infos_bdd"
        Me.infos_bdd.Size = New System.Drawing.Size(182, 209)
        Me.infos_bdd.TabIndex = 3
        Me.infos_bdd.TabStop = False
        Me.infos_bdd.Text = "Connexion - Statut : Déconnecté"
        '
        'validedeconnexion
        '
        Me.validedeconnexion.Enabled = False
        Me.validedeconnexion.Location = New System.Drawing.Point(9, 177)
        Me.validedeconnexion.Name = "validedeconnexion"
        Me.validedeconnexion.Size = New System.Drawing.Size(81, 23)
        Me.validedeconnexion.TabIndex = 5
        Me.validedeconnexion.Text = "Déconnexion"
        Me.validedeconnexion.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "* Obligatoire"
        '
        'valideconnection
        '
        Me.valideconnection.Location = New System.Drawing.Point(93, 177)
        Me.valideconnection.Name = "valideconnection"
        Me.valideconnection.Size = New System.Drawing.Size(75, 23)
        Me.valideconnection.TabIndex = 5
        Me.valideconnection.Text = "Connexion"
        Me.valideconnection.UseVisualStyleBackColor = True
        '
        'mdp
        '
        Me.mdp.Location = New System.Drawing.Point(25, 143)
        Me.mdp.Name = "mdp"
        Me.mdp.Size = New System.Drawing.Size(125, 20)
        Me.mdp.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(51, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Mot de passe"
        '
        'dbb
        '
        Me.dbb.Location = New System.Drawing.Point(25, 105)
        Me.dbb.Name = "dbb"
        Me.dbb.Size = New System.Drawing.Size(125, 20)
        Me.dbb.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(44, 89)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Base de donné *"
        '
        'user
        '
        Me.user.Location = New System.Drawing.Point(25, 69)
        Me.user.Name = "user"
        Me.user.Size = New System.Drawing.Size(125, 20)
        Me.user.TabIndex = 2
        Me.user.Text = "root"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(59, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Utilisateur *"
        '
        'host
        '
        Me.host.Location = New System.Drawing.Point(25, 32)
        Me.host.Name = "host"
        Me.host.Size = New System.Drawing.Size(125, 20)
        Me.host.TabIndex = 1
        Me.host.Text = "localhost"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(72, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Host *"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuitterAltF4ToolStripMenuItem, Me.AProposToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(809, 24)
        Me.MenuStrip1.TabIndex = 12
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'QuitterAltF4ToolStripMenuItem
        '
        Me.QuitterAltF4ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuitterAltF4ToolStripMenuItem1})
        Me.QuitterAltF4ToolStripMenuItem.Name = "QuitterAltF4ToolStripMenuItem"
        Me.QuitterAltF4ToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.QuitterAltF4ToolStripMenuItem.Text = "Fichier"
        '
        'QuitterAltF4ToolStripMenuItem1
        '
        Me.QuitterAltF4ToolStripMenuItem1.Name = "QuitterAltF4ToolStripMenuItem1"
        Me.QuitterAltF4ToolStripMenuItem1.Size = New System.Drawing.Size(163, 22)
        Me.QuitterAltF4ToolStripMenuItem1.Text = "Quitter (Alt + F4)"
        '
        'AProposToolStripMenuItem
        '
        Me.AProposToolStripMenuItem.Name = "AProposToolStripMenuItem"
        Me.AProposToolStripMenuItem.Size = New System.Drawing.Size(67, 20)
        Me.AProposToolStripMenuItem.Text = "A propos"
        '
        'BackgroundWorker1
        '
        '
        'Mobs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 355)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(825, 394)
        Me.Name = "Mobs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mobs"
        Me.infos_generale.ResumeLayout(False)
        Me.infos_generale.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.panel_grade.ResumeLayout(False)
        Me.panel_grade.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.generale.ResumeLayout(False)
        Me.generale.PerformLayout()
        Me.resistance.ResumeLayout(False)
        Me.resistance.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.panel_mob.ResumeLayout(False)
        Me.infos_bdd.ResumeLayout(False)
        Me.infos_bdd.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents guid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents nom As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents skin_id As System.Windows.Forms.TextBox
    Friend WithEvents align As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents capture As System.Windows.Forms.ComboBox
    Friend WithEvents infos_generale As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents QuitterAltF4ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitterAltF4ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AProposToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents panel_mob As System.Windows.Forms.GroupBox
    Friend WithEvents reloadmob As System.Windows.Forms.Button
    Friend WithEvents chargermobs As System.Windows.Forms.Button
    Friend WithEvents liste_mobs As System.Windows.Forms.ListBox
    Friend WithEvents infos_bdd As System.Windows.Forms.GroupBox
    Friend WithEvents validedeconnexion As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents valideconnection As System.Windows.Forms.Button
    Friend WithEvents mdp As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dbb As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents user As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents host As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents valider As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents kamas_max As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents kamas_min As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents intelligence As System.Windows.Forms.TextBox
    Friend WithEvents panel_grade As System.Windows.Forms.GroupBox
    Friend WithEvents edited As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents add_grade As System.Windows.Forms.Button
    Friend WithEvents resistance As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents res_age As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents res_cha As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents res_fo As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents res_int As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents res_neutre As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents res_pm As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents res_pa As System.Windows.Forms.TextBox
    Friend WithEvents generale As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents level As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents age As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cha As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents fo As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents int As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents init As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents xp As System.Windows.Forms.TextBox
    Friend WithEvents save As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents pdv As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents pm As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents pa As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents level_sort As System.Windows.Forms.ComboBox
    Friend WithEvents id_sort As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents supr_spell As System.Windows.Forms.Button
    Friend WithEvents add_spell As System.Windows.Forms.Button
    Friend WithEvents liste_sort As System.Windows.Forms.ListBox
    Friend WithEvents genere As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents stops As System.Windows.Forms.Button
End Class
