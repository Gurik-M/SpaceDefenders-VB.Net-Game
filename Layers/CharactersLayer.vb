Imports FinalGameProject

Public Class CharactersLayer
    Inherits Layer


    Public Sub New(game As GameEngine)
        MyBase.New(game)
    End Sub

    Protected Friend Overrides Sub ChangeLevel(level As Integer)
        bodies.Clear()
        Dim r As System.Random = New System.Random()
        Dim x_coordinate As Integer
        Dim y_coordinate As Integer
        x_coordinate = Math.Floor(Rnd() * 16)
        y_coordinate = Math.Floor(Rnd() * 6)

        ' Add Mario at (7,3) just for the first attempt.
        bodies.Add(New Character(game, 7, 16))
        bodies.Add(New BadGuy(game, x_coordinate, y_coordinate))

    End Sub

End Class

