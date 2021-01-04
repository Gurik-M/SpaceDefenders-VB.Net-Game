Imports FinalGameProject

Public Class InputsToConsole
    Inherits Body

    Public Sub New(g As GameEngine)
        MyBase.New(g, 0, 0)
    End Sub

    Public Sub Output(prefix As String, x As Integer, y As Integer)
        Console.WriteLine(prefix + " (" + Str(x).Trim + ", " + Str(y).Trim + ")")
    End Sub
    Public Sub Output(prefix As String, c As Char)
        Console.WriteLine(prefix + " (" + c + ")")
    End Sub

    Public Overrides Sub MouseDown(button As Integer, x As Integer, y As Integer)
        Output("BD:" + Str(button).Trim, x, y)
    End Sub

    Public Overrides Sub MouseDrag(buttons As Integer, x As Integer, y As Integer)
        Output("Dr:" + Str(buttons).Trim, x, y)
    End Sub

    Public Overrides Sub MouseEnter()
        Output("  En", -1, -1)
    End Sub

    Public Overrides Sub MouseLeave()
        Output("  Lv", -1, -1)
    End Sub

    Public Overrides Sub MouseMoved(x As Integer, y As Integer)
        Output("   M", x, y)
    End Sub

    Public Overrides Sub MouseUp(button As Integer, x As Integer, y As Integer)
        Output("BU:" + Str(button).Trim, x, y)
    End Sub

    Public Overrides Sub KeyDown(keyCode As Keys)
        Output("KD:", keyCode.ToString)
    End Sub

    Public Overrides Sub KeyUp(keyCode As Keys)
        Output("KU:", keyCode.ToString)
    End Sub

    Public Overrides Function SpriteId() As Char
        Return "-"
    End Function

    Protected Friend Overrides Function Collission(ahead As Body, dx As Integer, dy As Integer) As Boolean
        Return False
    End Function
End Class
