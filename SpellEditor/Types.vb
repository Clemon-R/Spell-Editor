Imports System.IO
Public Class Types
    Public Shared liste As New List(Of Item)

    Public Shared Sub charger()
        For Each i As Item In liste
            Dim z As New Item
            With z
                .name = i.name
                .type = i.type
                .verif = i.verif
                .complex = i.complex
                .etat = i.etat
            End With
            Form1.liste_type.Add(z)
            Form1.type.Items.Add(i.name)
        Next
    End Sub

    Public Shared Sub loadConfig()
        Try
            If IO.File.Exists("Types.txt") Then
                liste.Clear()
                Dim r As New IO.StreamReader("Types.txt", System.Text.Encoding.UTF8)
                Dim l As String
                Do
                    l = r.ReadLine
                    If Not l = Nothing Then
                        Dim s() As String = l.Split("|")
                        Dim i As New Item
                        With i
                            .name = s(0)
                            .type = s(1)
                            .verif = s(2)
                            .complex = s(3)
                            .etat = s(4)
                        End With
                        liste.Add(i)
                    End If
                Loop Until l = Nothing
                r.Close()
            Else
                MsgBox("Il manque le fichier Types.txt !", MsgBoxStyle.Critical)
                Form1.Close()
            End If
        Catch ex As Exception
            MsgBox("Problème avec le fichier Types.txt !", MsgBoxStyle.Critical)
            Form1.Close()
        End Try
    End Sub

    Public Class Item
        Public name As String
        Public type As String
        Public verif As String
        Public complex As String
        Public etat As String
    End Class
End Class
