Public Class Etats
    Public Shared liste As New List(Of Item)

    Public Shared Sub charger()
        Dim first As Boolean = True
        For Each i As Item In liste
            Dim z As New Item
            With z
                .name = i.name
                .id = i.id
            End With
            If (first = True) Then
                My.Forms.etat.type_etat.Text = i.name
                first = False
            End If
            My.Forms.etat.list_etats.Add(i.id, i.name)
            My.Forms.etat.type_etat.Items.Add(i.name)
            My.Forms.Etat_ID.list_etats.Add(i.id, i.name)
        Next
    End Sub

    Public Shared Sub loadConfig()
        Try
            If IO.File.Exists("Etats.txt") Then
                liste.Clear()
                Dim r As New IO.StreamReader("Etats.txt", System.Text.Encoding.UTF8)
                Dim l As String
                Do
                    l = r.ReadLine
                    If Not l = Nothing Then
                        Dim s() As String = l.Split("|")
                        Dim i As New Item
                        With i
                            .name = s(1)
                            .id = CInt(s(0))
                        End With
                        liste.Add(i)
                    End If
                Loop Until l = Nothing
                r.Close()
            Else
                MsgBox("Il manque le fichier Etats.txt !", MsgBoxStyle.Critical)
                My.Forms.etat.Close()
            End If
        Catch ex As Exception
            MsgBox("Problème avec le fichier Etats.txt !", MsgBoxStyle.Critical)
            My.Forms.etat.Close()
        End Try
    End Sub

    Public Class Item
        Public name As String
        Public id As Integer
    End Class
End Class
