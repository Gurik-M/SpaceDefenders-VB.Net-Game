Imports FinalGameProject

Public Class BadGuy
    Inherits Body
    Public Sub New(g As GameEngine, x As Integer, y As Integer)
        MyBase.New(g, x, y)
    End Sub

    Public Overrides Function SpriteId() As Char
        Return SpaceDefenders.B
    End Function

    Protected Friend Overrides Function Collission(ahead As Body, dx As Integer, dy As Integer) As Boolean
        If ahead IsNot Nothing Then

            Dim found As Char
            found = ahead.SpriteId()
            If found = SpaceDefenders.C Then
                MessageBox.Show("OH NO!!")
                MessageBox.Show("You've Crashed Into The Enemy Ship and You're Ship is Destroyed! You have been killed.")
                MessageBox.Show("You have been killed.")
                MessageBox.Show("Click ok to redeem yourself")
                game.Remove(ahead)
                game.score = 0

                game.GameOver()
                Return True
            End If
        End If
        Return False
    End Function
    Public Overrides Sub Animate()
        Move(Direction.Down)
        If location.Y = 17 Then
            game.score -= 1
            game.Remove(Me)
        End If
        If game.score = 65 Then
            game.Remove(Me)
        End If
    End Sub
    Public Overrides Function GetAnimationDelay() As Integer
        Return 10
    End Function
End Class
