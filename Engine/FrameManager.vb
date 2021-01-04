Imports FinalGameProject

Public Class FrameManager

    Public kill As Boolean = False
    Dim delay As Integer = 50
    Dim renderWorker As System.Threading.Thread

    Dim current As Image
    Dim readyFrames As Queue(Of Image) = New Queue(Of Image)
    Dim availableFrames As Queue(Of Image) = New Queue(Of Image)
    Dim graphicsStorage As Hashtable = New Hashtable()

    Private frameSize As Rectangle
    Const MAX_TO_KEEP = 10
    Public Const RES = 96

    Private game As GameEngine
    Private debugY As Integer = -1

    Dim exceptionList As List(Of ExceptionStamp) = New List(Of ExceptionStamp)

    Friend Sub LogException(ex As Exception)
        exceptionList.Add(New ExceptionStamp(ex))
    End Sub


    Sub New(width As Integer, height As Integer)
        SetSize(width, height)
    End Sub

    Public Sub Start(delay As Integer, game As GameEngine)
        Me.delay = delay
        Me.game = game
        Me.debugY = game.GetYCount * game.GetTileSize

        If renderWorker Is Nothing Then
            renderWorker = New System.Threading.Thread(AddressOf RenderJob)
            renderWorker.Start()
        End If
    End Sub

    Public Function GetCurrent() As Image
        Dim target As Image = Nothing
        Dim oldCurrent As Image = current
        While readyFrames.Count > 0
            If target IsNot Nothing Then
                If readyFrames.Count > 3 Then
                    graphicsStorage.Remove(target)
                Else
                    availableFrames.Enqueue(target)
                End If
            End If
            target = readyFrames.Dequeue
        End While

        If target IsNot Nothing Then
            current = target
            availableFrames.Enqueue(oldCurrent)
        End If
        Return current
    End Function


    Private Function CreateFrame() As Image
        Dim frame As Bitmap
        Dim frameGfx As Graphics
        frame = New Bitmap(frameSize.Width, frameSize.Height)
        frame.SetResolution(RES, RES)
        frameGfx = Graphics.FromImage(frame)
        ' TODO this is where we set black background
        frameGfx.FillRectangle(Brushes.Black, 0, 0, frameSize.Width, frameSize.Height)
        graphicsStorage.Add(frame, frameGfx)

        Return frame
    End Function

    Friend Sub RenderNextFrame()
        ' prep work
        Dim nextFrame As Image = Nothing
        Dim gfx As Graphics = Nothing
        If availableFrames.Count > 0 Then
            nextFrame = availableFrames.Dequeue

            While availableFrames.Count > MAX_TO_KEEP
                Dim remove As Image = availableFrames.Dequeue
                If Not remove Is Nothing Then
                    graphicsStorage.Remove(remove)
                End If
            End While
        End If
        If nextFrame Is Nothing Then
            nextFrame = CreateFrame()
        End If
        Try
            gfx = graphicsStorage(nextFrame)
        Catch e As Exception
        End Try

        If gfx Is Nothing Then
            gfx = Graphics.FromImage(nextFrame)
            graphicsStorage.Add(nextFrame, gfx)
        End If

        ' TODO this is where we set black background #2
        gfx.FillRectangle(Brushes.Black, frameSize)

        If game IsNot Nothing Then
            game.Animate()
            Dim layers As List(Of Layer) = game.layers

            Dim i As Integer = 0
            While i < layers.Count
                Dim layer As Layer = layers(i)
                layer.CreateMap()
                layer.PaintNextFrame(gfx)
                i += 1
            End While
        End If

        ' frame is done, put it in the queue to be displayed by PictureBoxConsumer
        readyFrames.Enqueue(nextFrame)
    End Sub

    Public Sub SetSize(width As Integer, height As Integer)
        Me.frameSize.Width = width
        Me.frameSize.Height = height

        readyFrames.Clear()
        availableFrames.Clear()

        current = CreateFrame()
    End Sub


    Private Sub RenderJob()
        While Not kill
            RenderNextFrame()
            Threading.Thread.Sleep(delay)
        End While
    End Sub

    Friend Function GetGame() As GameEngine
        Return game
    End Function

    Public Function GetDebugY() As Integer
        Return debugY
    End Function
    Public Function GetDebugInfo() As String
        'Return "hello"

        Dim frames As String = "N/A"
        Dim avail As String = "N/A"
        If readyFrames IsNot Nothing Then
            frames = Str(readyFrames.Count).Trim
        End If
        If availableFrames IsNot Nothing Then
            avail = Str(availableFrames.Count).Trim
        End If

        Dim exceptions As String = If(exceptionList.Count > 0, "Exceptions" + vbCrLf, "")
        For i As Integer = 0 To exceptionList.Count - 1 Step 1
            Dim stamp As ExceptionStamp = exceptionList(i)

            exceptions += stamp.t.ToLongTimeString() + ": " + stamp.ex.GetType.ToString() + vbCrLf
        Next

        Return "Frames Ready: " + frames + " Buffers Available: " + avail + vbCrLf + exceptions
    End Function
End Class
