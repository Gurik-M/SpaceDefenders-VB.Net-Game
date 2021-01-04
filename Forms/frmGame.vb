Imports System.ComponentModel
Imports FinalGameProject

Public Class frmGame
    Friend game As GameEngine
    Friend manager As FrameManager
    Const DEBUG_SIZE As Integer = 100

    Private Sub frmPaint_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            game = New SpaceDefenders()
            Me.Text = game.GetTitle()
            Dim w As Integer = game.GetXCount() * game.GetTileSize()
            Dim h As Integer = game.GetYCount() * game.GetTileSize() + DEBUG_SIZE
            Const borders As Integer = 16
            Me.Width = w + borders
            Me.Height = h + borders

            pbcCanvas.Width = w
            pbcCanvas.Height = h

            manager = pbcCanvas.GetFrameManager()
        Catch ex As Exception
            Console.WriteLine(ex.ToString())
            manager.LogException(ex)
        End Try

        manager.Start(tmrRepaint.Interval, game)
        frmDebug.Show()
        moveDebugForm()
    End Sub

    Private Sub moveDebugForm()
        frmDebug.Left = Me.Left + Me.Width + 10
        frmDebug.Top = Me.Top
    End Sub

    Private Sub tmrRepaint_Tick(sender As Object, e As EventArgs) Handles tmrRepaint.Tick
        pbcCanvas.Invalidate()
    End Sub

    Private Sub frmPaint_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        pbcCanvas.GetFrameManager.kill = True
        frmDebug.sendClose = False
        frmDebug.Close()

        frmWelcome.Show()
    End Sub

    Private Sub frmPaint_Move(sender As Object, e As EventArgs) Handles Me.Move
        moveDebugForm()
    End Sub


    Private Sub frmPaint_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            Dim i As Integer = 0, j As Integer = 0
            Dim layers As List(Of Layer) = manager.GetGame.layers
            While j < layers.Count
                Dim listeners As List(Of Body) = layers(j).bodies

                i = 0
                While i < listeners.Count
                    Dim l As IKeyboardListener = listeners(i)
                    If l IsNot Nothing Then
                        l.KeyDown(e.KeyCode)
                    End If
                    i += 1
                End While

                j += 1
            End While

            e.Handled = True

        Catch ex As Exception
            manager.LogException(ex)
        End Try
    End Sub

    Private Sub frmPaint_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Try

            Dim i As Integer = 0, j As Integer = 0
            Dim layers As List(Of Layer) = manager.GetGame.layers
            While j < layers.Count
                Dim listeners As List(Of Body) = layers(j).bodies

                i = 0
                While i < listeners.Count
                    Dim l As IKeyboardListener = listeners(i)
                    If l IsNot Nothing Then
                        l.KeyUp(e.KeyCode)
                    End If
                    i += 1
                End While

                j += 1
            End While
            e.Handled = True

        Catch ex As Exception
            manager.LogException(ex)
        End Try
    End Sub

End Class
