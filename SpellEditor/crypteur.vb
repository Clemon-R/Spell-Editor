Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Public Class crypteur
    Public Shared Function Crypte_md5(ByVal chaine_crypter As String) As String
        ' Conversion de la chaîne en tableau de bytes :
        Dim tab_byte() As Byte
        tab_byte = Encoding.ASCII.GetBytes(chaine_crypter)

        ' Calcul du hash MD5 :
        Dim md5 As New Security.Cryptography.MD5CryptoServiceProvider()
        tab_byte = md5.ComputeHash(tab_byte)

        'StringBuilder sert à concatener une chaîne de caractères rapidement en traitement
        Dim sb As New StringBuilder()
        Dim i As Integer
        Dim resultat As String

        For i = 0 To (tab_byte.Length) - 1
            sb.AppendFormat("{0:X2}", tab_byte(i))
        Next i
        resultat = sb.ToString.ToLower()

        Return resultat
    End Function

    Public Shared Function CrypteFile_md5(ByVal fileName As String) As String
        Using fs As FileStream = File.OpenRead(fileName)
            Dim md5Algorithm As MD5 = MD5.Create()
            Dim hashBytes As Byte() = md5Algorithm.ComputeHash(fs)
            'StringBuilder sert à concatener une chaîne de caractères rapidement en traitement
            Dim sb As New StringBuilder()
            Dim i As Integer
            Dim resultat As String

            For i = 0 To (hashBytes.Length) - 1
                sb.AppendFormat("{0:X2}", hashBytes(i))
            Next i
            resultat = sb.ToString.ToLower()
            Return resultat
        End Using
    End Function
End Class
