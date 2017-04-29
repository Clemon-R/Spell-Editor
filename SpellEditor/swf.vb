Imports SwfDotNet.IO
Imports SwfDotNet.IO.ByteCode
Imports SwfDotNet.IO.ByteCode.Actions
Imports SwfDotNet.IO.Tags
Public Class swf
    Public Shared Function decompile(ByVal string_0 As String)
        Dim swf As SwfDotNet.IO.Swf = New SwfDotNet.IO.SwfReader(string_0).ReadSwf
        Dim enumerator As IEnumerator = swf.Tags.GetEnumerator
        Do While enumerator.MoveNext
            Dim current As BaseTag = DirectCast(enumerator.Current, BaseTag)
            If (current.ActionRecCount <> 0) Then
                Dim str As String = Nothing
                Dim enumerator2 As IEnumerator = current.GetEnumerator
                Do While enumerator2.MoveNext
                    Dim enumerator3 As IEnumerator = New Decompiler(swf.Version).Decompile(DirectCast(enumerator2.Current, Byte())).GetEnumerator
                    Try
                        Do While enumerator3.MoveNext
                            str = (str & DirectCast(enumerator3.Current, BaseAction).ToString & ChrW(13) & ChrW(10))
                        Loop
                        Continue Do
                    Finally
                        If TypeOf enumerator3 Is IDisposable Then
                            TryCast(enumerator3, IDisposable).Dispose()
                        End If
                    End Try
                Loop
                MsgBox(str)
            End If
        Loop
        Return Nothing
    End Function
End Class
