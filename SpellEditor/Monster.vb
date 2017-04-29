Public Class Monster
    Public id As Integer
    Public name As String
    Public gfx As Integer
    Public align As Integer
    Public capturable As Integer
    Public kamas_min As Integer
    Public kamas_max As Integer
    Public IA As Integer
    Public liste_grades As New List(Of Grade)

    Public Function getGrade(grade As Integer)
        For Each g As Grade In liste_grades
            If g.grade = grade Then
                Return g
            End If
        Next
        Return Nothing
    End Function
    Public Sub addGrades(ByVal grades As String, stats As String, spells As String, pdvs As String, points As String, inits As String, exps As String, objet As Object)
        Dim a As Integer = 0
        Dim b As Integer = 1
        Dim nbr As Integer = grades.Split("|").Count
        While a < nbr
            Try
                Dim grade As New Grade
                Dim infos1 As String = grades.Split("|")(a)
                Dim infos2 As String = stats.Split("|")(a)
                Dim infos3 As String = exps.Split("|")(a)
                Dim infos4 As String = pdvs.Split("|")(a)
                Dim infos5 As String = points.Split("|")(a)
                Dim infos6 As String = ""
                Try
                    infos6 = spells.Split("|")(a)
                Catch ex As Exception
                End Try
                If infos1 <> "" Then
                    With grade
                        .grade = b
                        .vierge = False
                        .level = infos1.Split("@")(0)
                        .xp = infos3
                        .pdv = infos4
                        .pa = infos5.Split(";")(0)
                        .pm = infos5.Split(";")(1)
                        .res_neutre = infos1.Split("@")(1).Split(";")(0)
                        .res_terre = infos1.Split("@")(1).Split(";")(1)
                        .res_feu = infos1.Split("@")(1).Split(";")(2)
                        .res_eau = infos1.Split("@")(1).Split(";")(3)
                        .res_air = infos1.Split("@")(1).Split(";")(4)
                        .res_pa = infos1.Split("@")(1).Split(";")(5)
                        .res_pm = infos1.Split("@")(1).Split(";")(6)
                        .fo = infos2.Split(",")(0)
                        .cha = infos2.Split(",")(1)
                        .feu = infos2.Split(",")(2)
                        .age = infos2.Split(",")(3)
                        .init = infos2.Split(",")(4)
                    End With
                    Try
                        For Each Sort As String In infos6.Split(";")
                            Dim s As New Monster.Grade.sort
                            With s
                                .id = Sort.Split("@")(0)
                                .nv = Sort.Split("@")(1)
                            End With
                            grade.liste_sorts.Add(s)
                        Next
                    Catch ex As Exception
                    End Try
                    b += 1
                    objet.Add(grade)
                End If
            Catch ex As Exception
            End Try
                a += 1
        End While
    End Sub
    Public Class Grade
        Public grade As Integer
        Public vierge As Boolean = True
        Public level As Integer
        Public xp As Integer
        Public pdv As Integer
        Public pa As Integer
        Public pm As Integer
        Public res_feu As Integer
        Public res_neutre As Integer
        Public res_air As Integer
        Public res_terre As Integer
        Public res_eau As Integer
        Public res_pa As Integer
        Public res_pm As Integer
        Public init As Integer
        Public feu As Integer
        Public air As Integer
        Public age As Integer
        Public cha As Integer
        Public fo As Integer
        Public liste_sorts As New List(Of sort)
        Public Class sort
            Public id As Integer
            Public nv As Integer
        End Class
    End Class
End Class
