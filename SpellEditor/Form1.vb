Imports MySql.Data.MySqlClient
Imports ClemEditor.Bdd
Imports ClemEditor.Sort
Imports ClemEditor.Sort.Level
Imports ClemEditor.Types
Imports ClemEditor.Types.Item
Imports System.IO

Public Class Form1
    Public db As MySqlConnection = Nothing
    Private liste_spell As New List(Of Sort)
    Public liste_type As New List(Of Item)
    Private sort_load As Sort = Nothing
    Private level_edited As Integer = 1
    Private nombre_de_level As Integer = 5
    Public Shared genere_sql As String
    Public Shared genere_swf As String
    Private stopit As Boolean = False
    Public Shared loadFinish As Boolean = False
    Public taile_zone = New String() {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "a", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "-", "_"}
#Region "Base_de_donner"
#Region "Connexion"
    Public Sub validation_connection() Handles valideconnection.Click
        If host.Text.Length < 1 Or dbb.Text.Length < 1 Or user.Text.Length < 1 Then
            MsgBox("Veuillez completer tout les champs obligatoire !", MsgBoxStyle.Exclamation)
            Return
        ElseIf Not IsNothing(db) Then
            valideconnection.Enabled = False
            MsgBox("Vous êtes déjà connecter a une base de donné !", MsgBoxStyle.Exclamation)
            Return
        End If
        db = Bdd.Connection(host.Text, user.Text, dbb.Text, mdp.Text)
        If Not IsNothing(db) Then
            infos_bdd.Text = "Connexion - Statut : Connecté"
            valideconnection.Enabled = False
            validedeconnexion.Enabled = True
            sorts.Visible = True
        Else
            infos_bdd.Text = "Connexion - Statut : Déconnecté"
        End If
    End Sub
    Private Sub validedeconnexion_Click() Handles validedeconnexion.Click
        If IsNothing(db) Then
            validedeconnexion.Enabled = False
            MsgBox("Vous êtes déjà déconnecter !", MsgBoxStyle.Exclamation)
            Return
        End If
        Try
            db.Close()
            db = Nothing
            validedeconnexion.Enabled = False
            valideconnection.Enabled = True
            sorts.Visible = False
            spells.Items.Clear()
            chargersorts.Enabled = True
            reloadsort.Enabled = False
            infos_bdd.Text = "Connexion - Statut : Déconnecté"
        Catch ex As MySqlException
            MsgBox("Une erreur ses produite !", MsgBoxStyle.Exclamation)
            Return
        Catch ex As Exception
            MsgBox("Une erreur ses produite !", MsgBoxStyle.Exclamation)
            Return
        End Try
    End Sub
#End Region
#Region "Chargement"
    Private id_sort As Integer = -1
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim reader As MySqlDataReader
        If id_sort > 0 Then
            reader = Bdd.Lire("SELECT * FROM sorts WHERE id='" & id_sort & "';", db)
            id_sort = -1
        Else
            reader = Bdd.Lire("SELECT * FROM sorts ORDER BY id DESC;", db)
        End If
        If Not IsNothing(reader) Then
            While reader.Read()
                If stopit Then
                    Continue While
                End If
                Dim spell As New Sort
                Dim animation() As String = reader.GetString("spriteInfos").ToString.Split(",")
                With spell
                    .id = reader.GetString("id").ToString
                    .nom = reader.GetString("nom").ToString
                    .sprite = reader.GetString("sprite").ToString
                    .effect_target = reader.GetString("effectTarget").ToString
                    .infos = animation(1)
                    .infos_frame = animation(0)
                    .cible = animation(2)
                End With
                spell.AddLevel(1, reader.GetString("lvl1").ToString)
                spell.AddLevel(2, reader.GetString("lvl2").ToString)
                spell.AddLevel(3, reader.GetString("lvl3").ToString)
                spell.AddLevel(4, reader.GetString("lvl4").ToString)
                spell.AddLevel(5, reader.GetString("lvl5").ToString)
                If Not IsNothing(reader.GetString("lvl6").ToString) And reader.GetString("lvl6").ToString <> "-1" Then
                    spell.AddLevel(6, reader.GetString("lvl6").ToString)
                End If
                liste_spell.Add(spell)
                SetSpell(spell.id & "-" & spell.nom, spells)
            End While
        Else
            MsgBox("Aucun sort trouver !", MsgBoxStyle.Information)
        End If
        reader.Close()
        SetEnabled(True, reloadsort)
        loadFinish = True
    End Sub
    Private Sub chargersorts_Click() Handles chargersorts.Click
        stops.Enabled = True
        chargersorts.Enabled = False
        stopit = False
        BackgroundWorker1.RunWorkerAsync()
    End Sub
    Public Sub chargersort(ByVal id As Integer)
        stops.Enabled = True
        chargersorts.Enabled = False
        stopit = False
        id_sort = id
        BackgroundWorker1.RunWorkerAsync()
    End Sub
#End Region
#End Region
#Region "Generer"
    Function genereSQL_Zone(ByVal objet As Object)
        Dim liste As String = ""
        For Each effect As effect In objet
            Dim type As Item = getTypebyid(effect.type_id)
            If IsNothing(type) Then
                Continue For
            End If
            liste &= effect.zone
        Next
        Return liste
    End Function
    Function genereSQL_Effect(ByVal objet As Object)
        Dim liste As String = ""
        For Each effect As effect In objet
            Dim type As Item = getTypebyid(effect.type_id)
            If IsNothing(type) Then
                Continue For
            End If
            Dim effet As String = ""
            If type.complex = "true" Then
                effet = effect.type_id
                effet &= ";" & effect.jet_min
                effet &= ";" & effect.jet_max
                effet &= ";" & effect.etat
                effet &= ";" & effect.dure
                effet &= ";" & effect.reussite
                If liste = "" Then
                    liste = effet
                Else
                    liste &= "|" & effet
                End If
            Else
                effet = effect.type_id
                effet &= ";" & effect.jet_min
                effet &= ";" & effect.jet_max
                effet &= ";" & effect.etat
                effet &= ";" & effect.dure
                effet &= ";" & effect.reussite
                If effect.jet_max = "-1" Then
                    effet &= ";0d0+" & effect.jet_min
                Else
                    effet &= ";1d" & (effect.jet_max - (effect.jet_min - 1)) & "+" & (effect.jet_min - 1)
                End If
                If liste = "" Then
                    liste = effet
                Else
                    liste &= "|" & effet
                End If
            End If
        Next
        Return liste
    End Function
    Function genereSWF_Effect(ByVal objet As Object)
        Dim liste As String = ""
        For Each effect As effect In objet
            Dim type As Item = getTypebyid(effect.type_id)
            If IsNothing(type) Then
                Continue For
            End If
            Dim effet As String = "["
            If type.complex = "true" Then
                effet &= effect.type_id
                effet &= ", " & effect.jet_min
                effet &= ", " & effect.jet_max
                effet &= ", " & effect.etat
                effet &= ", " & effect.dure
                effet &= ", " & effect.reussite
                effet &= "]"
                If liste = "" Then
                    liste = effet
                Else
                    liste &= ", " & effet
                End If
            Else
                effet &= effect.type_id
                effet &= ", " & effect.jet_min
                effet &= ", " & effect.jet_max
                effet &= ", " & effect.etat
                effet &= ", " & effect.dure
                effet &= ", " & effect.reussite
                If effect.jet_max = "-1" Then
                    effet &= ", " & Chr(34) & "0d0+" & effect.jet_min & Chr(34)
                Else
                    effet &= ", " & Chr(34) & "1d" & (effect.jet_max - (effect.jet_min - 1)) & "+" & (effect.jet_min - 1) & Chr(34)
                End If
                effet &= "]"
                If liste = "" Then
                    liste = effet
                Else
                    liste &= ", " & effet
                End If
            End If
        Next
        Return liste
    End Function
    Function genereSql()
        If nombre_de_level < 5 Or nombre_de_level > 6 Then
            MsgBox("Une erreur ses produite au niveau des level.", MsgBoxStyle.Exclamation)
            Return Nothing
        End If
        Dim requete As String = ""
        Dim spriteinfos = sort_load.infos_frame & "," & sort_load.infos & "," & sort_load.cible
        requete = "DELETE FROM sorts WHERE id='" & sort_load.id & "';" & vbNewLine & "INSERT INTO sorts(id,nom,sprite,spriteInfos,effectTarget,lvl1,lvl2,lvl3,lvl4,lvl5,lvl6) VALUES ('" & sort_load.id & "', '" & sort_load.nom & "', '" & sort_load.sprite & "', '" & spriteinfos & "', '" & sort_load.effect_target & "', "
        Dim levels = ""
        For Each level As Level In sort_load.liste_level
            Dim ec_end_turn As String = level.ec_end.ToString
            Dim lvl_sql As String = ""
            lvl_sql &= genereSQL_Effect(level.liste_effect_normal)
            If level.liste_effect_cc.Count = 0 Then
                lvl_sql &= ",-1"
            Else
                lvl_sql &= "," & genereSQL_Effect(level.liste_effect_cc)
            End If
            lvl_sql &= ", " & level.pa
            lvl_sql &= ", " & level.po_min
            lvl_sql &= ", " & level.po_max
            lvl_sql &= ", " & level.cc
            lvl_sql &= ", " & level.ec
            lvl_sql &= ", " & level.launch_ligne.ToString.ToLower
            lvl_sql &= ", " & level.ligne_de_vue.ToString.ToLower
            lvl_sql &= ", " & level.cellule.ToString.ToLower
            lvl_sql &= ", " & level.po_modif.ToString.ToLower
            lvl_sql &= ", 0"
            lvl_sql &= ", " & level.launch_tour
            lvl_sql &= ", " & level.launch_joueur
            lvl_sql &= ", " & level.launch_nombre
            lvl_sql &= ", " & genereSQL_Zone(level.liste_effect_normal) & genereSQL_Zone(level.liste_effect_cc)
            lvl_sql &= ", " & level.etat_requie
            lvl_sql &= ", " & level.etat_interdit
            lvl_sql &= ", " & level.level
            lvl_sql &= ", " & level.ec_end.ToString.ToLower
            If levels = "" Then
                levels = "'" & lvl_sql & "'"
            Else
                levels &= ", '" & lvl_sql & "'"
            End If
        Next
        If sort_load.liste_level.Count = 5 Then
            levels &= ", '-1'"
        End If
        requete &= levels & ");"
        Return requete
    End Function
    Function genereSwf()
        If nombre_de_level < 5 Or nombre_de_level > 6 Then
            MsgBox("Une erreur ses produite au niveau des level.", MsgBoxStyle.Exclamation)
            Return Nothing
        End If
        Dim requete As String = ""
        requete = "S[" & sort_load.id & "] = {n: " & Chr(34) & sort_load.nom & Chr(34) & ", d: " & Chr(34) & description.Text & Chr(34) & ", "
        Dim levels = ""
        Dim a = 1
        For Each level As Level In sort_load.liste_level
            Dim ec_end_turn As String = level.ec_end.ToString
            Dim etat_requier = ""
            If level.etat_requie = "-1" Then
                etat_requier = level.etat_requie
            End If
            Dim lvl_swf As String = "l" & a & ": "
            lvl_swf &= "[[" & genereSWF_Effect(level.liste_effect_normal) & "]"
            If genereSWF_Effect(level.liste_effect_cc).ToString.Length > 0 Then
                lvl_swf &= ", [" & genereSWF_Effect(level.liste_effect_cc) & "]"
            Else
                lvl_swf &= ", null"
            End If
            lvl_swf &= ", " & level.pa
            lvl_swf &= ", " & level.po_min
            lvl_swf &= ", " & level.po_max
            lvl_swf &= ", " & level.cc
            lvl_swf &= ", " & level.ec
            lvl_swf &= ", " & level.launch_ligne.ToString.ToLower
            lvl_swf &= ", " & level.ligne_de_vue.ToString.ToLower
            lvl_swf &= ", " & level.cellule.ToString.ToLower
            lvl_swf &= ", " & level.po_modif.ToString.ToLower
            lvl_swf &= ", 0"
            lvl_swf &= ", " & level.launch_tour
            lvl_swf &= ", " & level.launch_joueur
            lvl_swf &= ", " & level.launch_nombre
            lvl_swf &= ", " & Chr(34) & genereSQL_Zone(level.liste_effect_normal) & genereSQL_Zone(level.liste_effect_cc) & Chr(34)
            If etat_requier <> "-1" Then
                lvl_swf &= ", [" & etat_requier.Replace(";", ",") & "]"
            Else
                lvl_swf &= ", []"
            End If
            lvl_swf &= ", [" & level.etat_interdit.Replace(";", ",") & "]"
            lvl_swf &= ", " & level.level
            lvl_swf &= ", " & level.ec_end.ToString.ToLower
            lvl_swf &= "]"
            lvl_swf = lvl_swf.Replace("-1", "null")
            a += 1
            If levels = "" Then
                levels = lvl_swf
            Else
                levels &= ", " & lvl_swf
            End If
        Next
        requete &= levels & "};"
        Return requete
    End Function
#End Region
#Region "Fonction"
    Private Sub TestPath(ByVal fileName As String, ByVal outputDir As String)
        If File.Exists(fileName) = False Then
            MsgBox("Input swf file doesn't exist", "Error", MessageBoxButtons.OK)
            Return
        ElseIf Directory.Exists(outputDir) = False Then
            MsgBox("Output directory doesn't exist", "Error", MessageBoxButtons.OK)
            Return
        End If
    End Sub
    Function getTypebyid(ByVal id As Integer)
        For Each i As Item In liste_type
            If i.type = id Then
                Return i
            End If
        Next
        Return Nothing
    End Function
    Function getTypebyname(ByVal name As String)
        For Each i As Item In liste_type
            If i.name = name Then
                Return i
            End If
        Next
        Return Nothing
    End Function
    Private Sub save_level(ByVal spell As Sort, ByVal level As Integer)
        Dim sort As Level = spell.getLevel(level)
        If IsNothing(sort) Then
            spell.AddLevel(level, "")
        End If
        sort.pa = pa.Text
        sort.po_min = po_min.Text
        sort.po_max = po_max.Text
        If cc_active.Checked = True Then
            sort.cc = cc.Text
        Else
            sort.cc = 0
        End If
        If ec_active.Checked = True Then
            sort.ec = ec.Text
        Else
            sort.ec = 0
        End If
        If launch.Checked Then
            sort.launch_ligne = True
        End If
        If ligne.Checked Then
            sort.ligne_de_vue = True
        End If
        If cellule.Checked Then
            sort.cellule = True
        End If
        If po_modif.Checked Then
            sort.po_modif = True
        End If
        If ec_end.Checked Then
            sort.ec_end = True
        End If
        sort.launch_tour = lancer_par_tour.Text
        sort.launch_joueur = lancer_par_joueur.Text
        sort.launch_nombre = nombre_de_lancer.Text
        sort.level = level_requie.Text
        sort.etat_interdit = etat_interdit.Text
        sort.etat_requie = etat_requie.Text
    End Sub
    Function getTypeZone()
        If zone.SelectedItem = "Case" Then
            Return "Pa"
        ElseIf zone.SelectedItem = "Zone" Then
            Return "C" & getTaille(nbr_zone.Text)
        ElseIf zone.SelectedItem = "Croix" Then
            Return "X" & getTaille(nbr_zone.Text)
        ElseIf zone.SelectedItem = "Ligne" Then
            Return "L" & getTaille(nbr_zone.Text)
        End If
        Return Nothing
    End Function
    Function getEffectTarget(ByVal no_allie As Boolean, ByVal no_fighter As Boolean, ByVal no_target As Boolean, ByVal just_invoc As Boolean, ByVal no_invoc As Boolean, ByVal just_fighter As Boolean)
        Dim finish As Boolean = True
        Dim a As Integer = 0
        While finish = True
            a += 1
            If ((a And 1) = 1) <> no_allie Then
                Continue While
            End If
            If (((a >> 1) And 1) = 1) <> no_fighter Then
                Continue While
            End If
            If (((a >> 2) And 1) = 1) <> no_target Then
                Continue While
            End If
            If (((a >> 3) And 1) = 1) <> just_invoc Then
                Continue While
            End If
            If (((a >> 4) And 1) = 1) <> no_invoc Then
                Continue While
            End If
            If (((a >> 5) And 1) = 1) <> just_fighter Then
                Continue While
            End If
            finish = False
            Return a
        End While
        Return ""
    End Function

    Function getSpellById(ByVal id As Integer)
        For Each i As Sort In liste_spell
            If i.id = id Then
                Return i
            End If
        Next
        Return Nothing
    End Function
    Function getSpellByList(ByVal item As String)
        Try
            Dim infos() As String = item.Split("-")
            Return getSpellById(infos(0))
        Catch ex As Exception
            MsgBox("Impossible de charger se sort.", MsgBoxStyle.Exclamation)
            Return Nothing
        End Try
    End Function
    Private Sub changeLevel(ByVal spell As Sort, ByVal level As Integer, ByVal precedent As Integer)
        Dim sort As Level = spell.getLevel(level)
        If IsNothing(sort) Then
            If Not IsNothing(spell.getLevel(precedent)) Then
                spell.AddLevel(level, spell.getLevel(precedent))
            Else
                spell.AddLevel(level, "")
            End If
            'MsgBox("Il n'y a pas de level " & level, MsgBoxStyle.Exclamation)
            Return
        End If
        Dim lvl As Level = spell.getLevel(level)
        If (IsNothing(lvl)) Then
            Return
        End If
        pa.Text = lvl.pa
        po_min.Text = sort.po_min
        po_max.Text = sort.po_max
        If sort.cc > 1 Then
            cc.Visible = True
            cc_active.Checked = True
            cc.Text = sort.cc
        Else
            cc.Visible = False
            cc_active.Checked = False
            cc.Text = sort.cc
        End If
        If sort.ec > 1 Then
            ec.Visible = True
            ec_active.Checked = True
            ec.Text = sort.ec
        Else
            ec.Visible = False
            ec_active.Checked = False
            ec.Text = sort.ec
        End If
        launch.Checked = sort.launch_ligne
        ligne.Checked = sort.ligne_de_vue
        cellule.Checked = sort.cellule
        po_modif.Checked = sort.po_modif
        lancer_par_tour.Text = sort.launch_tour
        lancer_par_joueur.Text = sort.launch_joueur
        nombre_de_lancer.Text = sort.launch_nombre
        level_requie.Text = sort.level
        ec_end.Checked = sort.ec_end
        etat_requie.Text = sort.etat_requie
        etat_interdit.Text = sort.etat_interdit
        loadEffet(sort, sort.liste_effect_normal, infos_effet)
        loadEffet(sort, sort.liste_effect_cc, infos_effet_cc)
    End Sub
    Dim item As Object
    Private Sub FormClose() Handles MyBase.FormClosed
        db = Nothing
    End Sub
    Private Sub SetSpell(value As String, objet As Object)
        If objet.InvokeRequired Then
            item = objet
            Dim d As New SetTextCallback(AddressOf SetSpell1)
            Invoke(d, New Object() {value})
        Else
            objet.items.add = value
        End If
    End Sub
    Private Sub SetSpell1(value As String)
        item.items.add(value)
    End Sub
    Delegate Sub SetTextCallback(ByVal value As String)
    Private Sub SetVisible(value As Boolean, objet As Object)
        If objet.InvokeRequired Then
            item = objet
            Dim d As New SetBooleanCallback(AddressOf SetVisible1)
            Invoke(d, New Object() {value})
        Else
            objet.visible = value
        End If
    End Sub
    Private Sub SetVisible1(value As Boolean)
        item.visible = value
    End Sub
    Private Sub SetEnabled(value As Boolean, objet As Object)
        If objet.InvokeRequired Then
            item = objet
            Dim d As New SetBooleanCallback(AddressOf SetEnabled1)
            Invoke(d, New Object() {value})
        Else
            objet.enabled = value
        End If
    End Sub
    Private Sub SetEnabled1(value As Boolean)
        item.enabled = value
    End Sub
    Delegate Sub SetBooleanCallback(ByVal value As Boolean)
    Private Sub loadEffet(ByVal spell As Level, ByVal liste As Object, ByVal formulaire As ListBox)
        formulaire.Items.Clear()
        For Each value As effect In liste
            Dim types As Types.Item = getTypebyid(value.type_id)
            If IsNothing(types) Then
                Continue For
            End If
            Dim detail() As String = types.verif.Split(",")
            Dim jet1() As String = detail(0).Split(":")
            Dim jet2() As String = detail(1).Split(":")
            Dim etat() As String = types.etat.Split(",")
            Dim infos = types.name & " : "
            If jet1(0) = "true" And value.jet_min > 0 Then
                infos &= jet1(1) & " : " & value.jet_min & " "
            End If
            If jet2(0) = "true" And value.jet_max > 0 Then
                infos &= jet2(1) & " : " & value.jet_max & " "
            End If
            If etat(0) = "true" Then
                infos &= etat(1) & " : " & value.etat & " "
            End If
            formulaire.Items.Add(infos)
        Next
    End Sub
    Private Sub spells_SelectedIndexChanged() Handles spells.DoubleClick
        Try
            Dim spell As Sort = getSpellByList(spells.SelectedItem)
            If Not IsNothing(spell) Then
                If spell.id <= 0 Then
                    MsgBox("Impossible de charger se sort.", MsgBoxStyle.Exclamation)
                    Return
                End If
                nom.Text = spell.nom
                id.Text = spell.id
                sprite.Text = spell.sprite
                animation.Text = spell.infos
                dure_anime.Text = spell.infos_frame
                If spell.cible = "0" Then
                    ComboBox1.Text = "Cible"
                Else
                    ComboBox1.Text = "Cible + Lanceur"
                End If
                level_edited = 1
                levelmanager.Text = 1
                sort_load = spell
                nombre_de_level = spell.liste_level.Count
                rate_level.Text = spell.liste_level.Count
                id.ReadOnly = False
                ComboBox1.Enabled = True
                dure_anime.Enabled = True
                t.Visible = False
                Button1.Enabled = True
                nom.ReadOnly = False
                sprite.ReadOnly = False
                animation.ReadOnly = False
                rate_level.Enabled = True
                genere.Visible = False
                GroupBox7.Visible = False
                TabPage1.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Source)
        End Try
        
    End Sub
    Public Sub LoadSpell(ByVal value As Integer)
        Dim spell As Sort = getSpellById(value)
        If Not IsNothing(spell) Then
            If spell.id <= 0 Then
                MsgBox("Impossible de charger se sort.", MsgBoxStyle.Exclamation)
                Return
            End If
            nom.Text = spell.nom
            id.Text = spell.id
            sprite.Text = spell.sprite
            animation.Text = spell.infos
            dure_anime.Text = spell.infos_frame
            If spell.cible = "0" Then
                ComboBox1.Text = "Cible"
            Else
                ComboBox1.Text = "Cible + Lanceur"
            End If
            level_edited = 1
            levelmanager.Text = 1
            sort_load = spell
            nombre_de_level = spell.liste_level.Count
            id.ReadOnly = False
            ComboBox1.Enabled = True
            dure_anime.Enabled = True
            t.Visible = False
            Button1.Enabled = True
            nom.ReadOnly = False
            sprite.ReadOnly = False
            animation.ReadOnly = False
            rate_level.Enabled = True
            genere.Visible = False
            GroupBox7.Visible = False
            TabPage1.Show()
        End If
    End Sub
#End Region
#Region "Boutton"
    Private Sub etat_Click(sender As Object, e As EventArgs) Handles etat.Click
        My.Forms.etat.Show()
    End Sub

    Private Sub up_Click(sender As Object, e As EventArgs) Handles up.Click
        Dim choose = infos_effet.SelectedItem
        If infos_effet.Items.Count > 1 And choose <> Nothing Then
            Dim a = 0
            Dim pos = -1
            For Each value In infos_effet.Items
                If value.ToString.Equals(choose) Then
                    pos = a
                End If
                a += 1
            Next
            If pos > 0 Then
                Dim level As Level = sort_load.getLevel(level_edited)
                Dim effet As effect = level.liste_effect_normal.Item(pos)
                Dim effet2 As effect = level.liste_effect_normal.Item(pos - 1)
                level.liste_effect_normal.Item(pos) = effet2
                level.liste_effect_normal.Item(pos - 1) = effet
                loadEffet(level, level.liste_effect_normal, infos_effet)
                infos_effet.SelectedItem = choose
            End If
        End If
    End Sub

    Private Sub down_Click(sender As Object, e As EventArgs) Handles down.Click
        Dim choose = infos_effet.SelectedItem
        If infos_effet.Items.Count > 1 And choose <> Nothing Then
            Dim a = 0
            Dim pos = -1
            Dim level As Level = sort_load.getLevel(level_edited)
            For Each value In infos_effet.Items
                If value.ToString.Equals(choose) Then
                    pos = a
                End If
                a += 1
            Next
            If pos < (level.liste_effect_normal.Count - 1) Then
                Dim effet As effect = level.liste_effect_normal.Item(pos)
                Dim effet2 As effect = level.liste_effect_normal.Item(pos + 1)
                If Not IsNothing(effet2) Then
                    level.liste_effect_normal.Item(pos) = effet2
                    level.liste_effect_normal.Item(pos + 1) = effet
                    loadEffet(level, level.liste_effect_normal, infos_effet)
                    infos_effet.SelectedItem = choose
                End If
            End If
        End If
    End Sub

    Private Sub up_cc_Click(sender As Object, e As EventArgs) Handles up_cc.Click
        Dim choose = infos_effet_cc.SelectedItem
        If infos_effet_cc.Items.Count > 1 And choose <> Nothing Then
            Dim a = 0
            Dim pos = -1
            For Each value In infos_effet_cc.Items
                If value.ToString.Equals(choose) Then
                    pos = a
                End If
                a += 1
            Next
            If pos > 0 Then
                Dim level As Level = sort_load.getLevel(level_edited)
                Dim effet As effect = level.liste_effect_cc.Item(pos)
                Dim effet2 As effect = level.liste_effect_cc.Item(pos - 1)
                level.liste_effect_cc.Item(pos) = effet2
                level.liste_effect_cc.Item(pos - 1) = effet
                loadEffet(level, level.liste_effect_cc, infos_effet_cc)
                infos_effet_cc.SelectedItem = choose
            End If
        End If
    End Sub

    Private Sub down_cc_Click(sender As Object, e As EventArgs) Handles down_cc.Click
        Dim choose = infos_effet_cc.SelectedItem
        If infos_effet_cc.Items.Count > 1 And choose <> Nothing Then
            Dim a = 0
            Dim pos = -1
            Dim level As Level = sort_load.getLevel(level_edited)
            For Each value In infos_effet_cc.Items
                If value.ToString.Equals(choose) Then
                    pos = a
                End If
                a += 1
            Next
            If pos < (level.liste_effect_cc.Count - 1) Then
                Dim effet As effect = level.liste_effect_cc.Item(pos)
                Dim effet2 As effect = level.liste_effect_cc.Item(pos + 1)
                If Not IsNothing(effet2) Then
                    level.liste_effect_cc.Item(pos) = effet2
                    level.liste_effect_cc.Item(pos + 1) = effet
                    loadEffet(level, level.liste_effect_cc, infos_effet_cc)
                    infos_effet_cc.SelectedItem = choose
                End If
            End If
        End If
    End Sub
    Private Sub stops_Click(sender As Object, e As EventArgs) Handles stops.Click
        stops.Enabled = False
        stopit = True
    End Sub

    Private Sub dure_anime_TextChanged(sender As Object, e As EventArgs) Handles dure_anime.TextChanged
        If Not IsNumeric(dure_anime.Text) Then
            dure_anime.Text = 0
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.TextChanged
        If Not ComboBox1.Items.Contains(ComboBox1.Text) Then
            ComboBox1.Text = "Cible"
        End If
    End Sub
    Private Sub jet_min_TextChanged(sender As Object, e As EventArgs) Handles jet_min.TextChanged
        If Not IsNumeric(jet_min.Text) Then
            jet_min.Text = -1
        End If
    End Sub

    Private Sub jet_max_TextChanged(sender As Object, e As EventArgs) Handles jet_max.TextChanged
        If Not IsNumeric(jet_max.Text) Then
            jet_max.Text = -1
        End If
    End Sub

    Private Sub etats_TextChanged(sender As Object, e As EventArgs) Handles etats.TextChanged
        If Not IsNumeric(etats.Text) Then
            etats.Text = -1
        End If
    End Sub

    Private Sub dure_TextChanged(sender As Object, e As EventArgs) Handles dure.TextChanged
        If Not IsNumeric(dure.Text) Then
            dure.Text = -1
        End If
    End Sub

    Private Sub reussite_TextChanged(sender As Object, e As EventArgs) Handles reussite.TextChanged
        If Not IsNumeric(reussite.Text) Then
            reussite.Text = -1
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles genere.Click
        genere_sql = genereSql()
        genere_swf = genereSwf()
        System.IO.File.WriteAllText("sort_" & nom.Text & ".txt", "//Sort " & nom.Text & vbNewLine & "SQL" & vbNewLine & genere_sql & vbNewLine & vbNewLine & "SWF" & vbNewLine & genere_swf)
        Generer.Show()
    End Sub
    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        save_level(sort_load, level_edited)
        If sort_load.liste_level.Count = nombre_de_level Then
            genere.Enabled = True
        End If
    End Sub
    Private Sub QuitterAltF4ToolStripMenuItem1_Click() Handles QuitterAltF4ToolStripMenuItem1.Click
        Me.Close()
    End Sub
    Private Sub AProposToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AProposToolStripMenuItem.Click
        MsgBox("Application by Clemon", MsgBoxStyle.Information)
    End Sub
    Private Sub levelmanger() Handles levelmanager.TextChanged
        If Not IsNumeric(levelmanager.Text) Then
            levelmanager.Text = 1
        End If
    End Sub
    Private Sub type_secu() Handles type.TextChanged
        If Not type.Items.Contains(type.Text) Then
            type.Text = ""
        End If
    End Sub
    Private Sub rate_level_secu() Handles rate_level.TextChanged
        If Not IsNumeric(rate_level.Text) Then
            rate_level.Text = 5
        End If
    End Sub
    Private Sub pa_TextChanged(sender As Object, e As EventArgs) Handles pa.TextChanged
        If Not IsNumeric(pa.Text) Then
            pa.Text = 0
        End If
    End Sub
    Private Sub po_min_TextChanged(sender As Object, e As EventArgs) Handles po_min.TextChanged
        If Not IsNumeric(po_min.Text) Then
            po_min.Text = 0
        End If
    End Sub

    Private Sub po_max_TextChanged(sender As Object, e As EventArgs) Handles po_max.TextChanged
        If Not IsNumeric(po_max.Text) Then
            po_max.Text = 0
        End If
    End Sub

    Private Sub lancer_par_tour_TextChanged(sender As Object, e As EventArgs) Handles lancer_par_tour.TextChanged
        If Not IsNumeric(lancer_par_tour.Text) Then
            lancer_par_tour.Text = 0
        End If
    End Sub

    Private Sub lancer_par_joueur_TextChanged(sender As Object, e As EventArgs) Handles lancer_par_joueur.TextChanged
        If Not IsNumeric(lancer_par_joueur.Text) Then
            lancer_par_joueur.Text = 0
        End If
    End Sub

    Private Sub nombre_de_lancer_TextChanged(sender As Object, e As EventArgs) Handles nombre_de_lancer.TextChanged
        If Not IsNumeric(nombre_de_lancer.Text) Then
            nombre_de_lancer.Text = 0
        End If
    End Sub

    Private Sub nom_TextChanged(sender As Object, e As EventArgs) Handles nom.TextChanged
        If IsNumeric(nom.Text) Then
            nom.Text = "Undefined"
        End If
    End Sub
    Private Sub cc_active1_CheckedChanged(sender As Object, e As EventArgs) Handles cc_active.CheckedChanged
        If cc_active.Checked = False Then
            cc.Visible = False
            cc.Text = 0
            Label14.Visible = False
        Else
            cc.Visible = True
            cc.Text = 2
            Label14.Visible = True
        End If
    End Sub

    Private Sub cc1_TextChanged(sender As Object, e As EventArgs) Handles cc.TextChanged
        If Not IsNumeric(cc.Text) Then
            cc.Text = 2
        End If
    End Sub

    Private Sub ec1_TextChanged(sender As Object, e As EventArgs) Handles ec.TextChanged
        If Not IsNumeric(ec.Text) Then
            ec.Text = 2
        End If
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles ec_active.CheckedChanged
        If ec_active.Checked = False Then
            ec.Visible = False
            ec.Text = 0
            ec_end.Visible = False
            ec_end.Checked = False
            Label13.Visible = False
        Else
            ec.Visible = True
            ec.Text = 2
            ec_end.Visible = True
            Label13.Visible = True
        End If
    End Sub

    Private Sub id_TextChanged(sender As Object, e As EventArgs) Handles id.TextChanged
        If Not IsNumeric(id.Text) Then
            id.Text = 0
        End If
    End Sub

    Private Sub sprite_TextChanged(sender As Object, e As EventArgs) Handles sprite.TextChanged
        If Not IsNumeric(sprite.Text) Then
            sprite.Text = -1
        End If
    End Sub

    Private Sub animation_TextChanged(sender As Object, e As EventArgs) Handles animation.TextChanged
        If Not IsNumeric(animation.Text) Then
            animation.Text = 0
        End If
    End Sub

    Private Sub level_requie_TextChanged(sender As Object, e As EventArgs) Handles level_requie.TextChanged
        If Not IsNumeric(level_requie.Text) Then
            level_requie.Text = 0
        End If
    End Sub

    Private Sub rate_level_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rate_level.SelectedIndexChanged
        nombre_de_level = rate_level.SelectedItem
        If nombre_de_level = 5 Then
            levelmanager.Items.Remove("6")
        ElseIf nombre_de_level = 6 Then
            If Not levelmanager.Items.Contains("6") Then
                levelmanager.Items.Add("6")
            End If
        End If
    End Sub
    Private Sub reloadsort_Click(sender As Object, e As EventArgs) Handles reloadsort.Click
        spells.Items.Clear()
        chargersorts_Click()
    End Sub
    Private Sub levelmanager_SelectedIndexChanged(sender As Object, e As EventArgs) Handles levelmanager.SelectedIndexChanged
        If Not IsNothing(sort_load) Then
            If levelmanager.SelectedItem = "1" Then
                GroupBox6.Enabled = True
            Else
                GroupBox6.Enabled = False
            End If
            save_level(sort_load, level_edited)
            changeLevel(sort_load, levelmanager.SelectedItem, level_edited)
            t.Text = "Level " & levelmanager.SelectedItem
            level_edited = levelmanager.SelectedItem
            If sort_load.liste_level.Count = nombre_de_level Then
                genere.Enabled = True
            End If
        End If
    End Sub

    Public Sub Button1_Click() Handles Button1.Click
        t.Visible = True
        Button1.Enabled = False
        If IsNothing(sort_load) Then
            sort_load = New Sort
            sort_load.AddLevel(1, "")
            sort_load.id = id.Text
        End If
        sort_load.nom = nom.Text
        sort_load.sprite = sprite.Text
        sort_load.infos = animation.Text
        sort_load.infos_frame = dure_anime.Text
        If ComboBox1.SelectedItem = "Cible" Then
            sort_load.cible = "0"
        Else
            sort_load.cible = "1"
        End If
        ComboBox1.Enabled = False
        dure_anime.Enabled = False
        id.ReadOnly = True
        nom.ReadOnly = True
        sprite.ReadOnly = True
        animation.ReadOnly = True
        rate_level.Enabled = False
        genere.Visible = True
        GroupBox7.Visible = True
        If sort_load.liste_level.Count = nombre_de_level Then
            genere.Enabled = True
        End If
        level_edited = 1
        levelmanager.Text = "1"
        changeLevel(sort_load, 1, 0)
    End Sub
    Private Sub type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles type.SelectedIndexChanged
        Dim type_array As Item = getTypebyname(type.SelectedItem)
        If IsNothing(type_array) Then
            Return
        End If
        Dim detail() As String = type_array.verif.Split(",")
        Dim jet1() As String = detail(0).Split(":")
        Dim jet2() As String = detail(1).Split(":")
        Dim jet As String = detail(2)
        Dim etat() As String = type_array.etat.Split(",")
        If jet1(0) = "true" Then
            Label22.Visible = True
            Label22.Text = jet1(1)
            jet_min.Visible = True
            jet_min.Text = -1
        Else
            Label22.Visible = False
            jet_min.Visible = False
            jet_min.Text = -1
        End If
        If jet2(0) = "true" Then
            Label23.Visible = True
            Label23.Text = jet2(1)
            jet_max.Visible = True
            jet_max.Text = -1
        Else
            Label23.Visible = False
            jet_max.Visible = False
            jet_max.Text = -1
        End If
        If jet = "true" Then
            jet_fix.Visible = True
            jet_fix.Checked = False
        Else
            jet_fix.Visible = False
        End If
        If etat(0) = "true" Then
            Label24.Visible = True
            Label24.Text = etat(1)
            etats.Visible = True
            etats.Text = -1
        Else
            Label24.Visible = False
            etats.Visible = False
            etats.Text = -1
        End If
    End Sub
    Private Sub jet_fix_CheckedChanged(sender As Object, e As EventArgs) Handles jet_fix.CheckedChanged
        If jet_fix.Checked = "false" Then
            Label23.Visible = True
            jet_max.Visible = True
            jet_max.Text = -1
        Else
            Label23.Visible = False
            jet_max.Visible = False
            jet_max.Text = -1
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim level As Level = sort_load.getLevel(level_edited)
        If level.liste_effect_normal.Count <= 0 Then
            Return
        End If
        If IsNothing(infos_effet.SelectedItem) Then
            Dim nbr As Integer = level.liste_effect_normal.Count - 1
            level.liste_effect_normal.RemoveAt(nbr)
            If Not IsNothing(sort_load.effect_target) And level_edited = 1 Then
                Dim effect() As String = sort_load.effect_target.Split(";")
                If effect.Count > 1 Or level.liste_effect_normal.Count = 1 Then
                    Dim nbr_effect As Integer = effect.Count - 1
                    Dim a = 0
                    Dim liste = ""
                    While a < nbr_effect
                        If liste = "" Then
                            liste = effect(a)
                        Else
                            liste &= ";" & effect(a)
                        End If
                        a += 1
                    End While
                    sort_load.effect_target = liste
                End If
            End If
            loadEffet(level, level.liste_effect_normal, infos_effet)
        Else
            Dim choose = infos_effet.SelectedItem
            Dim a = 0
            Dim pos = -1
            For Each value In infos_effet.Items
                If value.ToString.Equals(choose) Then
                    pos = a
                End If
                a += 1
            Next
            level.liste_effect_normal.RemoveAt(pos)
            If Not IsNothing(sort_load.effect_target) And level_edited = 1 Then
                a = 0
                Dim liste = ""
                For Each value In sort_load.effect_target.Split(";")
                    If a = pos Then
                        Continue For
                    Else
                        If liste = "" Then
                            liste = value
                        Else
                            liste &= ";" & value
                        End If
                    End If
                    a += 1
                Next
                sort_load.effect_target = liste
            End If
            loadEffet(level, level.liste_effect_normal, infos_effet)
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim level As Level = sort_load.getLevel(level_edited)
        If level.addEffect(level.liste_effect_normal) Then
            loadEffet(level, level.liste_effect_normal, infos_effet)
            If level_edited = 1 Then
                If Not sort_load.effect_target = Nothing Then
                    If CheckBox6.Checked Or CheckBox7.Checked Or CheckBox8.Checked Or CheckBox9.Checked Or CheckBox10.Checked Or CheckBox11.Checked Then
                        sort_load.effect_target &= ";" & getEffectTarget(CheckBox6.Checked, CheckBox7.Checked, CheckBox8.Checked, CheckBox9.Checked, CheckBox10.Checked, CheckBox11.Checked)
                    End If
                Else
                    If CheckBox6.Checked Or CheckBox7.Checked Or CheckBox8.Checked Or CheckBox9.Checked Or CheckBox10.Checked Or CheckBox11.Checked Then
                        If level.liste_effect_normal.Count > 1 Then
                            For Each value As effect In level.liste_effect_normal
                                sort_load.effect_target &= "0;"
                            Next
                        End If
                        sort_load.effect_target &= getEffectTarget(CheckBox6.Checked, CheckBox7.Checked, CheckBox8.Checked, CheckBox9.Checked, CheckBox10.Checked, CheckBox11.Checked)
                    End If
                End If
            End If
        End If
    End Sub
    Function getTaille(ByVal value As Integer)
        Return taile_zone(value)
    End Function
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles nbr_zone.TextChanged
        If Not IsNumeric(nbr_zone.Text) Then
            nbr_zone.Text = 1
        ElseIf nbr_zone.Text < 1 Then
            nbr_zone.Text = 1
        ElseIf nbr_zone.Text > 63 Then
            nbr_zone.Text = 63
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles add_cc.Click
        If cc_active.Checked = False Then
            If Not infos_effet_cc.Items.Contains("Coup de critique desactiver") Then
                infos_effet_cc.Items.Add("Coup de critique desactiver")
            End If
            Return
        End If
        Dim level As Level = sort_load.getLevel(level_edited)
        If level.addEffect(level.liste_effect_cc) Then
            loadEffet(level, level.liste_effect_cc, infos_effet_cc)
        End If
    End Sub
    Private Sub supr_cc_Click(sender As Object, e As EventArgs) Handles supr_cc.Click
        Dim level As Level = sort_load.getLevel(level_edited)
        If level.liste_effect_cc.Count <= 0 Then
            Return
        End If
        If IsNothing(infos_effet_cc.SelectedItem) Then
            Dim nbr As Integer = level.liste_effect_cc.Count - 1
            level.liste_effect_cc.RemoveAt(nbr)
            loadEffet(level, level.liste_effect_cc, infos_effet_cc)
        Else
            Dim choose = infos_effet_cc.SelectedItem
            Dim a = 0
            Dim pos = -1
            For Each value In infos_effet_cc.Items
                If value.ToString.Equals(choose) Then
                    pos = a
                End If
                a += 1
            Next
            level.liste_effect_cc.RemoveAt(pos)
            loadEffet(level, level.liste_effect_cc, infos_effet_cc)
        End If
    End Sub
#End Region

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Types.loadConfig()
        Types.charger()
        ClemEditor.Etats.loadConfig()
        ClemEditor.Etats.charger()
    End Sub

    Private Sub EtatIDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EtatIDToolStripMenuItem.Click
        Etat_ID.Show()
    End Sub
End Class