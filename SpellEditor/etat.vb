Public Class etat
    Private state As Boolean = False
    Public list_etats As New Dictionary(Of Integer, String)

    Private Sub type_SelectedIndexChanged(sender As Object, e As EventArgs) Handles type.SelectedIndexChanged
        If (type.SelectedIndex = 0) Then
            If (state = True) Then
                saveEtat()
            End If
            lbl_etat.Text = "Etat Requie"
            state = False
        Else
            If (state = False) Then
                saveEtat()
            End If
            lbl_etat.Text = "Etat Interdit"
            state = True
        End If
        loadEtat()
    End Sub

    Private Sub saveEtat()
        Dim list As String = ""
        Dim a As Integer = 0
        While a < list_etat.Items.Count
            Dim id As Integer = getIdEtat(list_etat.Items(a).ToString)
            If (list.Length > 0) Then
                list &= ";" & id
            Else
                list &= id
            End If
            a += 1
        End While
        If (list.Length = 0) Then
            list = "-1"
        End If
        If (state = True) Then
            My.Forms.Form1.etat_interdit.Text = list
        Else
            My.Forms.Form1.etat_requie.Text = list
        End If
    End Sub

    Private Function getIdEtat(ByVal name As String) As Integer
        If (list_etats.ContainsValue(name)) Then
            Dim a As Integer = 0
            While a < list_etats.Count
                Dim nom As String = list_etats.Values(a)
                If (nom.Equals(name)) Then
                    Return list_etats.Keys(a)
                End If
                a += 1
            End While
        End If
        Return -1
    End Function

    Private Sub loadEtat()
        list_etat.Items.Clear()
        Dim list As String = ""
        If (state = True) Then
            list = My.Forms.Form1.etat_interdit.Text
        Else
            list = My.Forms.Form1.etat_requie.Text
        End If
        If (IsNothing(list) Or list.Equals("-1")) Then
            Return
        End If
        Dim e() As String = list.Split(";")
        Dim nbr As Integer = e.Count
        Dim a As Integer = 0
        ' MsgBox(list & " " & nbr)
        While a < nbr
            Dim id As Integer = e(a)
            If (id = -1) Then
                a = a + 1
                Continue While
            End If
            Dim name As String = getNameEtat(id)
            'MsgBox(name)
            If (IsNothing(name)) Then
                a = a + 1
                Continue While
            End If
            list_etat.Items.Add(name)
            a = a + 1
        End While
    End Sub

    Private Function getNameEtat(ByVal id As Integer) As String
        'MsgBox(id)
        If (list_etats.ContainsKey(id)) Then
            Return list_etats(id)
        End If
        Return Nothing
    End Function

    Private Sub etat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadEtat()
    End Sub
    Private Sub mybase_exit() Handles MyBase.FormClosing
        saveEtat()
    End Sub

    Private Sub add_etat_Click(sender As Object, e As EventArgs) Handles add_etat.Click
        Dim name As String = type_etat.Text
        If (list_etat.Items.Contains(name)) Then
            MsgBox("Etat déjà présent !", MsgBoxStyle.Exclamation)
            Return
        End If
        list_etat.Items.Add(type_etat.SelectedItem.ToString)
    End Sub

    Private Sub supr_etat_Click(sender As Object, e As EventArgs) Handles supr_etat.Click
        If (list_etat.Items.Count = 0) Then
            Return
        End If
        Dim name As String = list_etat.SelectedItem.ToString
        Dim id As Integer = list_etat.Items.IndexOf(name)
        list_etat.Items.RemoveAt(id)
        If (id > 0) Then
            list_etat.SelectedIndex = id - 1
        ElseIf (list_etat.Items.Count > 0) Then
            list_etat.SelectedIndex = 0
        End If
    End Sub
End Class