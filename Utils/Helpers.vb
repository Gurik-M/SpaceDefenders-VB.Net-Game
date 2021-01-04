Public MustInherit Class Helpers

    Public Shared Function Transpose(input As Char(,)) As Char(,)
        ' When typing in an array in the format above, it gets written in (y,x) format.
        ' Running it through this switches the x&y co-ordinates so that it makes sense in the real world.
        '
        ' You only need to use this when creating a level.

        Dim xLen As Integer = input.GetLength(0)
        Dim yLen As Integer = input.GetLength(1)
        Dim output(yLen, xLen) As Char
        Dim y As Integer = 0
        While y < yLen
            Dim x As Integer = 0
            While x < xLen
                output(y, x) = input(x, y)
                x += 1
            End While
            y += 1
        End While
        Return output
    End Function

    Public Shared Function GetPath(folder As String, filename As String) As String
        Dim input As String = Application.StartupPath
        Dim debug As String = System.IO.Path.Combine("bin", "Debug")
        Dim release As String = System.IO.Path.Combine("bin", "Release")
        If input.EndsWith(debug) Then
            input = input.Replace(debug, "")
        ElseIf input.EndsWith(release) Then
            input = input.Replace(release, "")
        End If
        input = System.IO.Path.Combine(input, folder, filename)
        Return input
    End Function


End Class
