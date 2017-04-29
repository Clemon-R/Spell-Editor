Imports MySql.Data.MySqlClient
Imports ClemEditor.Monster

Public Class Mobs
    Private db As MySqlConnection = Nothing
    Private list_mob As New List(Of Monster)
    Private mob As Monster = Nothing
    Private grade_edited As Integer = 1
    Public genere_sql As String = ""
    Public genere_swf As String = ""
    Private stopit As Boolean = False
#Region "Base de donné"
#Region "Connexion"
    Private Sub valideconnection_Click(sender As Object, e As EventArgs) Handles valideconnection.Click
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
            panel_mob.Visible = True
        Else
            infos_bdd.Text = "Connexion - Statut : Déconnecté"
        End If
    End Sub

    Private Sub validedeconnexion_Click(sender As Object, e As EventArgs) Handles validedeconnexion.Click
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
            panel_mob.Visible = True
        Else
            infos_bdd.Text = "Connexion - Statut : Déconnecté"
        End If
    End Sub
#End Region
#Region "Charger"
    Private Sub chargermobs_Click() Handles chargermobs.Click
        stops.Enabled = True
        stopit = False
        chargermobs.Enabled = False
        BackgroundWorker1.RunWorkerAsync()
    End Sub
    Private Sub reloadmob_Click(sender As Object, e As EventArgs) Handles reloadmob.Click
        liste_mobs.Items.Clear()
        chargermobs_Click()
    End Sub
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim reader As MySqlDataReader = Bdd.Lire("SELECT * FROM monsters ORDER BY id DESC;", db)
        If Not IsNothing(reader) Then
            While reader.Read()
                If stopit Then
                    Continue While
                End If
                Dim mob As New Monster
                With mob
                    .id = reader.GetString("id").ToString
                    .name = reader.GetString("name").ToString
                    .gfx = reader.GetString("gfxID").ToString
                    .align = reader.GetString("align").ToString
                    .capturable = reader.GetString("capturable").ToString
                    .IA = reader.GetString("AI_Type").ToString
                    .kamas_min = reader.GetString("minKamas").ToString
                    .kamas_max = reader.GetString("maxKamas").ToString
                End With
                mob.addGrades(reader.GetString("grades").ToString, reader.GetString("stats").ToString, reader.GetString("spells").ToString, reader.GetString("pdvs").ToString, reader.GetString("points").ToString, reader.GetString("inits").ToString, reader.GetString("exps").ToString, mob.liste_grades)
                list_mob.Add(mob)
                SetSpell(mob.id & "-" & mob.name, liste_mobs)
            End While
        End If
        reader.Close()
        SetEnabled(True, reloadmob)
    End Sub
    Private Sub stops_Click(sender As Object, e As EventArgs) Handles stops.Click
        stops.Enabled = False
        stopit = True
    End Sub
#End Region
#End Region
#Region "Fonction"

    Dim item As Object
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
    Private Sub loadGrade(num As Integer)
        Dim grade As Grade = mob.getGrade(num)
        If IsNothing(grade) Then
            Return
        End If
        If grade.vierge Then
            Return
        End If
        Try
            level.Text = grade.level
            res_neutre.Text = grade.res_neutre
            res_age.Text = grade.res_air
            res_cha.Text = grade.res_eau
            res_fo.Text = grade.res_terre
            res_int.Text = grade.res_feu
            res_pa.Text = grade.res_pa
            res_pm.Text = grade.res_pm
            fo.Text = grade.fo
            init.Text = grade.init
            int.Text = grade.feu
            age.Text = grade.age
            cha.Text = grade.cha
            xp.Text = grade.xp
            pdv.Text = grade.pdv
            pa.Text = grade.pa
            pm.Text = grade.pm
            liste_sort.Items.Clear()
            For Each Sort As Monster.Grade.sort In grade.liste_sorts
                liste_sort.Items.Add("Sort id : " & Sort.id & " Level : " & Sort.nv)
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub saveGrade(num As Integer)
        Dim grade As Grade = mob.getGrade(num)
        grade.vierge = False
        Try
            grade.level = level.Text
            grade.res_neutre = res_neutre.Text
            grade.res_air = res_age.Text
            grade.res_eau = res_cha.Text
            grade.res_terre = res_fo.Text
            grade.res_feu = res_int.Text
            grade.res_pa = res_pa.Text
            grade.res_pm = res_pm.Text
            grade.fo = fo.Text
            grade.feu = int.Text
            grade.age = age.Text
            grade.cha = cha.Text
            grade.init = init.Text
            grade.xp = xp.Text
            grade.pdv = pdv.Text
            grade.pm = pm.Text
            grade.pa = pa.Text
            grade.liste_sorts.Clear()
            For Each value As String In liste_sort.Items
                Dim s As New Monster.Grade.sort
                s.id = value.Substring(10).Split(" ")(0)
                s.nv = value.Substring(19 + s.id.ToString.Length)
                grade.liste_sorts.Add(s)
            Next
        Catch ex As Exception
        End Try
    End Sub
    Function getMobbyid(id As Integer)
        For Each mob As Monster In list_mob
            If mob.id = id Then
                Return mob
            End If
        Next
        Return Nothing
    End Function
    Private Sub loadMob()
        guid.Text = mob.id
        nom.Text = mob.name
        skin_id.Text = mob.gfx
        Select Case mob.align
            Case -1 Or 0
                align.Text = "Neutre"
            Case 1
                align.Text = "Bontarien"
            Case 2
                align.Text = "Brakmarien"
            Case Else
                align.Text = "Neutre"
        End Select
        Select Case mob.capturable
            Case 1
                capture.Text = "Oui"
            Case Else
                capture.Text = "Non"
        End Select
        kamas_min.Text = mob.kamas_min
        kamas_max.Text = mob.kamas_max
        intelligence.Text = mob.IA
        edited.Items.Clear()
        If Not IsNothing(mob.liste_grades) And mob.liste_grades.Count > 0 Then
            Dim a = 0
            For Each e As Grade In mob.liste_grades
                a += 1
                edited.Items.Add(a)
            Next
        End If
    End Sub
    Private Sub saveMob()
        mob.id = guid.Text
        mob.name = nom.Text
        mob.gfx = skin_id.Text
        Select Case align.Text
            Case "Neutre"
                mob.align = -1
            Case "Bontarien"
                mob.align = 1
            Case "Brakmarien"
                mob.align = 2
        End Select
        Select Case capture.Text
            Case "Oui"
                mob.capturable = 1
            Case Else
                mob.capturable = 0
        End Select
        mob.kamas_min = kamas_min.Text
        mob.kamas_max = kamas_max.Text
        mob.IA = intelligence.Text
    End Sub
    Private Sub liste_mobs_SelectedIndexChanged() Handles liste_mobs.DoubleClick
        Dim id As Integer = liste_mobs.SelectedItem.ToString.Split("-")(0)
        mob = getMobbyid(id)
        If Not IsNothing(mob) Then
            loadMob()
            infos_generale.Enabled = True
            grade_edited = 1
            panel_grade.Visible = False
            genere.Visible = False
            TabPage1.Show()
        Else
            MsgBox("Une erreur ses produite !", MsgBoxStyle.Exclamation)
        End If
    End Sub
#End Region
#Region "Boutton"
    Private Sub loadSort() Handles liste_sort.DoubleClick
        If IsNothing(db) Then
            Return
        End If
        Dim id As Integer = Integer.Parse(liste_sort.SelectedItem.ToString.Substring(10).Split(" ")(0))
        Form1.Close()
        Form1.Show()
        Form1.host.Text = Me.host.Text
        Form1.dbb.Text = Me.dbb.Text
        Form1.user.Text = Me.user.Text
        Form1.mdp.Text = Me.mdp.Text
        Form1.validation_connection()
        Form1.chargersort(id)
        Form1.TabPage2.Show()
    End Sub
    Private Sub genere_Click(sender As Object, e As EventArgs) Handles genere.Click
        If IsNothing(mob) Then
            MsgBox("Vous devez avoir créer un monstre !", MsgBoxStyle.Exclamation)
        End If
        genereSql()
        genereSwf()
        System.IO.File.WriteAllText("Monstre_" & mob.name & ".txt", "//Monstre " & mob.name & vbNewLine & "SQL" & vbNewLine & genere_sql & vbNewLine & vbNewLine & "SWF" & vbNewLine & genere_swf)
        Genere2.Show()
    End Sub
    Private Sub edited_SelectedIndexChanged(sender As Object, e As EventArgs) Handles edited.TextChanged
        If Not IsNumeric(edited.Text) Then
            edited.Text = grade_edited
        End If
    End Sub

    Private Sub edited_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles edited.SelectedIndexChanged
        If Not IsNothing(mob) Then
            saveGrade(grade_edited)
            loadGrade(edited.SelectedItem)
            grade_edited = edited.SelectedItem
            panel_grade.Text = "Grade " & grade_edited
        End If
    End Sub

    Private Sub res_neutre_TextChanged(sender As Object, e As EventArgs) Handles res_neutre.TextChanged
        If Not IsNumeric(res_neutre.Text) Then
            res_neutre.Text = 0
        End If
    End Sub

    Private Sub res_int_TextChanged(sender As Object, e As EventArgs) Handles res_int.TextChanged
        If Not IsNumeric(res_int.Text) Then
            res_int.Text = 0
        End If
    End Sub

    Private Sub res_fo_TextChanged(sender As Object, e As EventArgs) Handles res_fo.TextChanged
        If Not IsNumeric(res_fo.Text) Then
            res_fo.Text = 0
        End If
    End Sub

    Private Sub res_cha_TextChanged(sender As Object, e As EventArgs) Handles res_cha.TextChanged
        If Not IsNumeric(res_cha.Text) Then
            res_cha.Text = 0
        End If
    End Sub

    Private Sub res_age_TextChanged(sender As Object, e As EventArgs) Handles res_age.TextChanged
        If Not IsNumeric(res_age.Text) Then
            res_age.Text = 0
        End If
    End Sub

    Private Sub res_pa_TextChanged(sender As Object, e As EventArgs) Handles res_pa.TextChanged
        If Not IsNumeric(res_pa.Text) Then
            res_pa.Text = 0
        End If
    End Sub

    Private Sub res_pm_TextChanged(sender As Object, e As EventArgs) Handles res_pm.TextChanged
        If Not IsNumeric(res_pm.Text) Then
            res_pm.Text = 0
        End If
    End Sub

    Private Sub level_TextChanged(sender As Object, e As EventArgs) Handles level.TextChanged
        If Not IsNumeric(level.Text) Then
            level.Text = 0
        End If
    End Sub

    Private Sub neu_TextChanged(sender As Object, e As EventArgs) Handles init.TextChanged
        If Not IsNumeric(init.Text) Then
            init.Text = 0
        End If
    End Sub

    Private Sub int_TextChanged(sender As Object, e As EventArgs) Handles int.TextChanged
        If Not IsNumeric(int.Text) Then
            int.Text = 0
        End If
    End Sub

    Private Sub fo_TextChanged(sender As Object, e As EventArgs) Handles fo.TextChanged
        If Not IsNumeric(fo.Text) Then
            fo.Text = 0
        End If
    End Sub

    Private Sub cha_TextChanged(sender As Object, e As EventArgs) Handles cha.TextChanged
        If Not IsNumeric(cha.Text) Then
            cha.Text = 0
        End If
    End Sub

    Private Sub age_TextChanged(sender As Object, e As EventArgs) Handles age.TextChanged
        If Not IsNumeric(age.Text) Then
            age.Text = 0
        End If
    End Sub

    Private Sub xp_TextChanged(sender As Object, e As EventArgs) Handles xp.TextChanged
        If Not IsNumeric(xp.Text) Then
            xp.Text = 0
        End If
    End Sub

    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        saveGrade(grade_edited)
    End Sub

    Private Sub pdv_TextChanged(sender As Object, e As EventArgs) Handles pdv.TextChanged
        If Not IsNumeric(pdv.Text) Then
            pdv.Text = 0
        End If
    End Sub

    Private Sub pa_TextChanged(sender As Object, e As EventArgs) Handles pa.TextChanged
        If Not IsNumeric(pa.Text) Then
            pa.Text = 0
        End If
    End Sub

    Private Sub pm_TextChanged(sender As Object, e As EventArgs) Handles pm.TextChanged
        If Not IsNumeric(pm.Text) Then
            pm.Text = 0
        End If
    End Sub

    Private Sub level_sort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles level_sort.TextChanged
        If Not level_sort.Items.Contains(level_sort.Text) Then
            level_sort.Text = 1
        End If
    End Sub

    Private Sub id_sort_TextChanged(sender As Object, e As EventArgs) Handles id_sort.TextChanged
        If Not IsNumeric(id_sort.Text) Then
            id_sort.Text = 0
        End If
    End Sub

    Private Sub supr_spell_Click(sender As Object, e As EventArgs) Handles supr_spell.Click
        liste_sort.Items.Remove(liste_sort.SelectedItem)
    End Sub

    Private Sub add_spell_Click(sender As Object, e As EventArgs) Handles add_spell.Click
        liste_sort.Items.Add("Sort id : " & id_sort.Text & " Level : " & level_sort.Text)
    End Sub
    Private Sub skin_id_TextChanged(sender As Object, e As EventArgs) Handles skin_id.TextChanged
        If Not IsNumeric(skin_id.Text) Then
            skin_id.Text = 0
        End If
    End Sub

    Private Sub nom_TextChanged(sender As Object, e As EventArgs) Handles nom.TextChanged
        If IsNumeric(nom.Text) Then
            nom.Text = "Undefined"
        End If
    End Sub

    Private Sub align_SelectedIndexChanged(sender As Object, e As EventArgs) Handles align.TextChanged
        If Not align.Items.Contains(align.Text) Then
            align.Text = "Neutre"
        End If
    End Sub

    Private Sub capture_SelectedIndexChanged(sender As Object, e As EventArgs) Handles capture.SelectedIndexChanged
        If Not capture.Items.Contains(capture.Text) Then
            capture.Text = "Oui"
        End If
    End Sub

    Private Sub guid_TextChanged(sender As Object, e As EventArgs) Handles guid.TextChanged
        If Not IsNumeric(guid.Text) Then
            guid.Text = 0
        End If
    End Sub

    Private Sub AProposToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AProposToolStripMenuItem.Click
        MsgBox("Application by Clemon", MsgBoxStyle.Information)
    End Sub

    Private Sub QuitterAltF4ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles QuitterAltF4ToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub valider_Click(sender As Object, e As EventArgs) Handles valider.Click
        infos_generale.Enabled = False
        grade_edited = 1
        If IsNothing(mob) Then
            mob = New Monster
            Dim grade As New Grade
            grade.grade = 1
            mob.liste_grades.Add(grade)
        End If
        saveMob()
        loadGrade(grade_edited)
        panel_grade.Visible = True
        genere.Visible = True
        edited.Text = grade_edited
        panel_grade.Text = "Grade " & grade_edited
    End Sub

    Private Sub kamas_min_TextChanged(sender As Object, e As EventArgs) Handles kamas_min.TextChanged
        If Not IsNumeric(kamas_min.Text) Then
            kamas_min.Text = 0
        End If
    End Sub

    Private Sub kamas_max_TextChanged(sender As Object, e As EventArgs) Handles kamas_max.TextChanged
        If Not IsNumeric(kamas_max.Text) Then
            kamas_max.Text = 0
        End If
    End Sub

    Private Sub intelligence_TextChanged(sender As Object, e As EventArgs) Handles intelligence.TextChanged
        If Not IsNumeric(intelligence.Text) Then
            intelligence.Text = 1
        End If
    End Sub

    Private Sub add_grade_Click() Handles add_grade.Click
        Dim grade As New Grade
        grade.grade = mob.liste_grades.Count + 1
        mob.liste_grades.Add(grade)
        edited.Items.Clear()
        If Not IsNothing(mob.liste_grades) And mob.liste_grades.Count > 0 Then
            Dim a = 0
            For Each e As Grade In mob.liste_grades
                a += 1
                edited.Items.Add(a)
            Next
        End If
    End Sub
#End Region
#Region "Generer"
    Private Sub genereSwf()
        Dim requete As String = "M[" & mob.id & "] = {n: " & Chr(34) & mob.name & Chr(34) & ", b: -1, a: -1, k: false, g: " & mob.gfx & ", "
        Dim a = 1
        Dim liste As String = ""
        For Each Grade As Grade In mob.liste_grades
            If liste <> "" Then
                liste &= ", "
            End If
            liste &= "g" & a & ": {r: [" & Grade.res_neutre & ", " & Grade.res_terre & ", " & Grade.res_feu & ", " & Grade.res_eau & ", " & Grade.res_air & ", " & Grade.res_pa & ", " & Grade.res_pm & "], l: " & Grade.level & "}"
            a += 1
        Next
        requete &= liste
        requete &= "};"
        genere_swf = requete
    End Sub
    Private Sub genereSql()
        Dim grades As String = ""
        Dim stats As String = ""
        Dim inits As String = ""
        Dim spells As String = ""
        Dim pdvs As String = ""
        Dim points As String = ""
        Dim exps As String = ""
        For Each Grade As Grade In mob.liste_grades
            If grades <> "" Then
                grades &= "|"
            End If
            grades &= Grade.level & "@" & Grade.res_neutre & ";" & Grade.res_terre & ";" & Grade.res_feu & ";" & Grade.res_eau & ";" & Grade.res_air & ";" & Grade.res_pa & ";" & Grade.res_pm
            If stats <> "" Then
                stats &= "|"
            End If
            stats &= Grade.fo & "," & Grade.cha & "," & Grade.feu & "," & Grade.age & "," & Grade.init
            If inits <> "" Then
                inits &= "|"
            End If
            inits &= Grade.init
            If spells <> "" Then
                spells &= "|"
            End If
            Dim liste As String = ""
            For Each Sort As Monster.Grade.sort In Grade.liste_sorts
                If liste <> "" Then
                    liste &= ";"
                End If
                liste &= Sort.id & "@" & Sort.nv
            Next
            spells &= liste
            If pdvs <> "" Then
                pdvs &= "|"
            End If
            pdvs &= Grade.pdv
            If points <> "" Then
                points &= "|"
            End If
            points &= Grade.pa & ";" & Grade.pm
            If exps <> "" Then
                exps &= "|"
            End If
            exps &= Grade.xp
        Next
        Dim requete As String = ""
        requete = "DELETE FROM monsters WHERE id='" & mob.id & "';" & vbNewLine
        requete &= "INSERT INTO monsters(id,name,gfxID,align,capturable,AI_Type,minKamas,maxKamas,grades,stats,spells,pdvs,points,inits,exps) VALUES ('" & mob.id & "','" & mob.name & "','" & mob.gfx & "','" & mob.align & "','" & mob.capturable & "','" & mob.IA & "','" & mob.kamas_min & "','" & mob.kamas_max & "','" & grades & "','" & stats & "','" & spells & "','" & pdvs & "','" & points & "','" & inits & "','" & exps & "');"
        genere_sql = requete
    End Sub
#End Region
End Class