Public Class SpriteAlreadyUsedException
    Inherits Exception

    Public ReadOnly id As Char
    Public ReadOnly FirstFile As String
    Public ReadOnly SecondFile As String

    Public Sub New(ch As Char, f As String, s As String)
        Me.id = ch
        Me.FirstFile = f
        Me.SecondFile = s
    End Sub

    Public Overrides Function ToString() As String
        Return "Cannot give body id:" + id + " sprite with filename: " + SecondFile + ", because it already has a sprite with filename: " + FirstFile + "." +
            vbCrLf + MyBase.ToString()
    End Function

End Class
