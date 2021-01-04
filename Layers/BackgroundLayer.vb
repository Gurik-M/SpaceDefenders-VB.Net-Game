Imports FinalGameProject
Imports FinalGameProject.SpaceDefenders
Public Class BackgroundLayer
    Inherits Layer

    Public Sub New(game As GameEngine)
        MyBase.New(game)
    End Sub

    Protected Friend Overrides Sub ChangeLevel(level As Integer)
        bodies.Clear()

    End Sub

    Public Overrides Sub PaintNextFrame(gfx As Graphics)
        MyBase.PaintNextFrame(gfx)

        Dim x As Integer = game.GetXCount
        Dim y As Integer = game.GetYCount
        Dim size As Integer = game.GetTileSize

        ''vertical lines
        'Dim i As Integer
        'i = 1
        'While i < x
        '    gfx.DrawLine(Pens.Gray, i * size, 0, i * size, y * size)

        '    i += 1
        'End While

        '' horizontal lines
        'Dim j As Integer
        'j = 1
        'While j < y
        '    gfx.DrawLine(Pens.Gray, 0, j * size, x * size, j * size)
        '    j += 1
        'End While

        'If game.debugEnabled Then
        '    i = 0
        '    While i < x
        '        j = 0
        '        While j < y
        '            gfx.DrawString("(" + Str(i) + "," + Str(j) + ")", SystemFonts.DefaultFont, Brushes.Gray, i * size, j * size)

        '            j += 1
        '        End While
        '        i += 1
        '    End While
        'End If

    End Sub

End Class
