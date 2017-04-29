Public Class Etat_ID
    Public list_etats As New Dictionary(Of Integer, String)
    Private Sub Etat_ID_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim a As UInteger = 0
        While a < list_etats.Count
            list.Items.Add(list_etats.Keys(a) & " : " & list_etats.Values(a))
            a += 1
        End While
    End Sub
End Class