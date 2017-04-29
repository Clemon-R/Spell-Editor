Imports MySql.Data.MySqlClient
Public Class Bdd
    Public Shared Function Connection(ByVal host As String, ByVal utilisateur As String, ByVal bdd As String, ByVal mdp As String)
        Dim connStr As String = "SERVER=" & host & ";DATABASE=" & bdd & ";UID=" & utilisateur & ";PASSWORD=" & mdp
        Dim connecting As New MySqlConnection(connStr)
        Try
            connecting.Open()
            Return connecting
        Catch e As MySqlException
            Return Nothing
        End Try
        Return Nothing
    End Function
    Public Shared Function Lire(ByVal requete As String, ByVal db As MySqlConnection)
        Try
            Dim command As MySqlCommand = db.CreateCommand()
            Dim reader As MySqlDataReader
            command.CommandText = requete & ""
            reader = command.ExecuteReader()
            Return reader
        Catch ex As MySqlException
            MsgBox("Une erreur mysql : " & ex.Message, MsgBoxStyle.Exclamation)
            Return Nothing
        End Try
    End Function
End Class
