Imports ClemEditor.Types.Item
Imports ClemEditor.Types
Public Class Sort
    Public id As Integer
    Public nom As String
    Public sprite As String
    Public infos As String
    Public infos_frame As String
    Public cible As String
    Public liste_level As New List(Of Level)
    Public effect_target As String = Nothing

    Public Shadows Sub AddLevel(ByVal numero As Integer, ByVal level As String)
        Dim l As New Level
        l.id_lvl = numero
        l.ConvertLvl(level)
        liste_level.Add(l)
    End Sub

    Public Shadows Sub AddLevel(ByVal numero As Integer, ByVal e As Level)
        Dim l As New Level
        l.Equals(e)
        l.id_lvl = numero
        l.level = e.level
        l.pa = e.pa
        l.po_min = e.po_min
        l.po_max = e.po_max
        l.cc = e.cc
        l.ec = e.cc
        l.launch_ligne = e.launch_ligne
        l.ligne_de_vue = e.ligne_de_vue
        l.cellule = e.cellule
        l.po_modif = e.po_modif
        l.ec_end = e.ec_end
        l.launch_tour = e.launch_tour
        l.launch_nombre = e.launch_nombre
        l.launch_joueur = e.launch_joueur
        l.etat_interdit = e.etat_interdit
        l.etat_requie = e.etat_requie
        l.liste_effect_cc = e.liste_effect_cc.Clone
        l.liste_effect_normal = e.liste_effect_normal.Clone
        liste_level.Add(l)
    End Sub

    Public Shadows Function getLevel(ByVal level As Integer)
        For Each i As Level In liste_level
            If i.id_lvl = level Then
                Return i
            End If
        Next
        Return Nothing
    End Function
    Public Class Level
        Public id_lvl As Integer
        Public level As Integer
        Public pa As Integer
        Public po_min As Integer
        Public po_max As Integer
        Public cc As Integer
        Public ec As Integer
        Public launch_ligne As Boolean = False
        Public ligne_de_vue As Boolean = False
        Public cellule As Boolean = False
        Public po_modif As Boolean = False
        Public ec_end As Boolean = False
        Public launch_tour As Integer
        Public launch_joueur As Integer
        Public launch_nombre As Integer
        Public etat_requie As String = "-1"
        Public etat_interdit As String = "18; 19; 3; 1; 41"
        Public Shadows liste_effect_normal As New ArrayList
        Public Shadows liste_effect_cc As New ArrayList

        Public Shadows Sub ConvertLvl(ByVal lvl As String)
            Try
                lvl = lvl.Replace(" ", "")
                Dim infos() As String = lvl.Split(",")
                convertType_cc(infos(1))
                convertType_normal(infos(0))
                pa = infos(2)
                po_min = infos(3)
                po_max = infos(4)
                cc = infos(5)
                ec = infos(6)
                If infos(7) = "true" Then
                    launch_ligne = True
                End If
                If infos(8) = "true" Then
                    ligne_de_vue = True
                End If
                If infos(9) = "true" Then
                    cellule = True
                End If
                If infos(10) = "true" Then
                    po_modif = True
                End If
                launch_tour = infos(12)
                launch_joueur = infos(13)
                launch_nombre = infos(14)
                level = infos(18)
                etat_requie = infos(16)
                etat_interdit = infos(17)
                If infos(19) = "true" Then
                    ec_end = True
                End If
                Dim nbr_cc As Integer = liste_effect_cc.Count * 2
                Dim nbr As Integer = infos(15).Length
                If nbr_cc > 1 Then
                    Dim liste_cc As String = infos(15).Substring(nbr - nbr_cc)
                    Dim a = 0
                    For Each b As effect In liste_effect_cc
                        With b
                            .zone = liste_cc.Substring(a, 2)
                        End With
                        a += 2
                    Next
                End If
                Dim liste_normal As String = infos(15).Substring(0, nbr - nbr_cc)
                Dim z = 0
                For Each b As effect In liste_effect_normal
                    With b
                        .zone = liste_normal.Substring(z, 2)
                    End With
                    z += 2
                Next
            Catch ex As Exception
            End Try
        End Sub
        Private Sub convertType_normal(ByVal effect As String)
            Dim all() As String = effect.Split("|")
            For Each value As String In all
                Dim infos() As String = value.Split(";")
                Dim effet As New effect
                With effet
                    .type_id = infos(0)
                    .jet_min = infos(1)
                    .jet_max = infos(2)
                    .etat = infos(3)
                    .dure = infos(4)
                    .reussite = infos(5)
                End With
                liste_effect_normal.Add(effet)
            Next
        End Sub
        Private Sub convertType_cc(ByVal effect As String)
            If effect = "-1" Then
                Return
            End If
            Dim all() As String = effect.Split("|")
            For Each value As String In all
                Dim infos() As String = value.Split(";")
                Dim effet As New effect
                With effet
                    .type_id = infos(0)
                    .jet_min = infos(1)
                    .jet_max = infos(2)
                    .etat = infos(3)
                    .dure = infos(4)
                    .reussite = infos(5)
                End With
                liste_effect_cc.Add(effet)
            Next
        End Sub
        Public Function addEffect(ByVal objet As Object)
            Dim e As New effect
            Dim types As Item = Form1.getTypebyname(Form1.type.SelectedItem)
            If IsNothing(types) Then
                Return False
            End If
            With e
                .type_id = types.type
                .jet_min = Form1.jet_min.Text
                .jet_max = Form1.jet_max.Text
                .etat = Form1.etats.Text
                .dure = Form1.dure.Text
                .reussite = Form1.reussite.Text
                .zone = Form1.getTypeZone()
            End With
            objet.add(e)
            Return True
        End Function
        Public Class effect
            Public type_id As Integer
            Public jet_min As Integer
            Public jet_max As Integer
            Public etat As Integer
            Public dure As Integer
            Public reussite As Integer
            Public zone As String = Nothing
        End Class
    End Class
End Class
