Imports System.ComponentModel
Imports FinalGameProject

Public Class frmDebug
    '' DON'T TOUCH ANYTHING ABOVE THE LINE
    Protected Friend sendClose As Boolean = True
    Private mouseToConsole As Body

    Private Sub frmDebug_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If sendClose Then
            sendClose = False
            frmGame.Close()
        End If
    End Sub
    '' OKAY, YOU CAN CHANGE STUFF BELOW THE LINE
    '' -----------------------------------------

    Private Sub tmrGame_Tick(sender As Object, e As EventArgs) Handles tmrGame.Tick
        lblScore.Text = Str(frmGame.manager.GetGame.GetScore()).Trim
    End Sub

    Private Sub chkFps_CheckedChanged(sender As Object, e As EventArgs) Handles chkFps.CheckedChanged
        Dim game As GameEngine = frmGame.game
        If game IsNot Nothing Then
            game.EnableDebugInfo(chkFps.Checked)
        End If
    End Sub

    Private Sub btnNewGame_Click(sender As Object, e As EventArgs) Handles btnNewGame.Click
        frmGame.game.NewGame()
    End Sub

    Private Sub btnRestartLevel_Click(sender As Object, e As EventArgs) Handles btnRestartLevel.Click
        frmGame.game.RestartLevel()
    End Sub

    Private Sub btnGameOver_Click(sender As Object, e As EventArgs) Handles btnGameOver.Click
        frmGame.game.GameOver()
    End Sub

    Private Sub chkMouseConsole_CheckedChanged(sender As Object, e As EventArgs) Handles chkMouseConsole.CheckedChanged
        Dim game As GameEngine = frmGame.game
        If game IsNot Nothing Then
            If mouseToConsole Is Nothing Then
                mouseToConsole = New InputsToConsole(game)
            End If
            Dim bodies As List(Of Body) = game.layers(0).bodies
            If chkMouseConsole.Checked Then
                If Not bodies.Contains(mouseToConsole) Then
                    bodies.Add(mouseToConsole)
                End If
            Else
                    bodies.Remove(mouseToConsole)
            End If
        End If
    End Sub
End Class