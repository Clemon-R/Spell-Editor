Imports System.Net
Imports System.IO
Public Class license
    Dim client As New WebClient
    Dim ip As String = Nothing
    Private Sub license_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim key As String = Nothing
        If (File.Exists("key.spell")) Then
            If (File.ReadAllText("key.spell").Length > 0) Then
                key = File.ReadAllText("key.spell")
            End If
        End If
        Try
            Dim test As String = client.DownloadString("http://127.0.0.1/verification.php?key=" & key)
            MsgBox("Problèmes détecter !", MsgBoxStyle.Exclamation)
            Me.Close()
            Return
        Catch ex As Exception
            Try
                If (IO.File.Exists(My.Application.Info.AssemblyName & "_old.exe")) Then
                    IO.File.Delete(My.Application.Info.AssemblyName & "_old.exe")
                End If
                Try
                    Dim md5 As String = client.DownloadString(Configuration.owner & "updater.php")
                    If (md5.Length > 0) Then
                        Dim source As String = crypteur.CrypteFile_md5(My.Application.Info.AssemblyName & ".exe")
                        If (Not source.Equals(md5)) Then
                            My.Computer.FileSystem.RenameFile(My.Application.Info.AssemblyName & ".exe", My.Application.Info.AssemblyName & "_old.exe")
                            client.DownloadFile(Configuration.owner & My.Application.Info.AssemblyName & ".exe", My.Application.Info.AssemblyName & ".exe")
                            Process.Start(My.Application.Info.AssemblyName & ".exe")
                            Me.Close()
                            Return
                        End If
                    End If
                Catch eex As Exception
                    MsgBox("Problème lors de la mise à jour, le nom de l'éxécutable doit rester ClemEditor.exe", MsgBoxStyle.Exclamation)
                    Me.Close()
                    Return
                End Try
                If (Not IsNothing(key)) Then
                    Dim reponse As String = client.DownloadString(Configuration.owner & "verification.php?key=" & key)
                    If (reponse.Equals("oui")) Then
                        Accueil.Show()
                        Me.Close()
                        Return
                    Else
                        If (File.Exists("key.spell")) Then
                            File.Delete("key.spell")
                        End If
                        MsgBox("Clef invalide !")
                        Return
                    End If
                End If
            Catch exdd As Exception
                MsgBox("Bug sur récupération d'ip !", MsgBoxStyle.Exclamation)
                Me.Close()
                Return
            End Try
        End Try
    End Sub

    Private Sub valide_Click(sender As Object, e As EventArgs) Handles valide.Click
        Dim key As String = clef.Text
        If (key.Length > 0) Then
            Try
                Dim test As String = client.DownloadString(Configuration.owner & "verification.php?key=" & key)
                If (test.Equals("oui")) Then
                    File.WriteAllText("key.spell", key)
                    MsgBox("Clef valide !", MsgBoxStyle.Information)
                    Accueil.Show()
                    Me.Close()
                Else
                    MsgBox("Clef invalide !", MsgBoxStyle.Information)
                    clef.Text = ""
                End If
            Catch ex As Exception
                MsgBox("Problème avec le serveur !", MsgBoxStyle.Information)
                Me.Close()
                Return
            End Try
        Else
            MsgBox("Vous n'avez entrer aucune clef !", MsgBoxStyle.Information)
        End If
    End Sub
End Class