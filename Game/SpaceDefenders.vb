Imports FinalGameProject

' TODO LATER: Rename this class after you decide what your game concept is
Public Class SpaceDefenders
    Inherits GameEngine

    ' TODO #2.1 Make one Char for each Body that you create. This will let us show the graphics, and do Collision detection.
    ' Write a short comment before each one, so you know what it represents.

    ' Space Backdrop
    Public Shared ReadOnly S As Char = "-"c
    ' Character
    Public Shared ReadOnly C As Char = "C"c
    ' Bad Guy
    Public Shared ReadOnly B As Char = "B"c
    ' Laser Bullet
    Public Shared ReadOnly W As Char = "W"c
    ' Powerup
    Public Shared ReadOnly P As Char = "P"c

    Public background As BackgroundLayer
    Public characters As CharactersLayer


    Dim animationTick As Integer = 0
    Dim spawn_timer As Integer = 65


    Protected Friend Overrides Sub CreateLayers()
        ' You can add more Layers here. They render in (first = bottom)-->(last = top) order.
        ' Therefore, you can think of the layer's index as the z-index.
        background = New BackgroundLayer(Me)
        layers.Add(background)

        characters = New CharactersLayer(Me)
        layers.Add(characters)
    End Sub

    Protected Friend Overrides Sub LoadSprites()
        ' TODO #2.2 Load your sprites here, by calling AddSprite(). Watch out for capitals, as well as the extension: JPG vs. JPEG vs. GIF vs. PNG.
        ' For best performance, make sure the sprites are 96 pixels/inch in Photoshop (Image - Image Size - Turn off Resample)
        AddSprite(SpaceDefenders.C, "images", "spaceship.png")
        AddSprite(SpaceDefenders.B, "images", "enemyShip.png")
        AddSprite(SpaceDefenders.W, "images", "laserBullet.png")
        AddSprite(SpaceDefenders.P, "images", "powerup.png")
    End Sub

    Public Overrides Sub Animate()
        MyBase.Animate()

        Dim r As System.Random = New System.Random()
        Dim x_coordinate As Integer
        Dim y_coordinate As Integer
        x_coordinate = Math.Floor(Rnd() * 16)
        y_coordinate = Math.Floor(Rnd() * 6)

        Dim x_coordinate_p As Integer
        Dim y_coordinate_p As Integer
        x_coordinate_p = Math.Floor(Rnd() * 16)
        y_coordinate_p = Math.Floor(Rnd() * 6)

        Dim powerup_timer As Boolean = False

        animationTick += 1
        If animationTick >= spawn_timer Then
            characters.bodies.Add(New BadGuy(Me, x_coordinate, y_coordinate))
            animationTick = 0
        End If

        If score = 0 Then
            spawn_timer = 65
        ElseIf score = 10 Then
            spawn_timer = 55
            score += 1
            characters.bodies.Add(New powerup(Me, x_coordinate_p, y_coordinate_p))
        ElseIf score = 15 Then
            spawn_timer = 45
        ElseIf score = 20 Then
            spawn_timer = 35
            score += 1
            characters.bodies.Add(New powerup(Me, x_coordinate_p, y_coordinate_p))
        ElseIf score = 25 Then
            spawn_timer = 27
        ElseIf score = 30 Then
            spawn_timer = 19
            score += 1
            characters.bodies.Add(New powerup(Me, x_coordinate_p, y_coordinate_p))
        ElseIf score = 40 Then
            spawn_timer = 15
            score += 1
            characters.bodies.Add(New powerup(Me, x_coordinate_p, y_coordinate_p))
        ElseIf score = 65 Then
            MessageBox.Show("Game Over!'")
            MessageBox.Show("You've Successfully Destroyed the Enemy Fleet!")
            MessageBox.Show("Good Job!")
            MessageBox.Show("Click ok to play again...")
            spawn_timer = 65
            score = 0
            GameOver()
        End If
    End Sub

    Public Overrides Function ToString() As String
        Return "Space Invaders"
    End Function

    Protected Friend Overrides Function GetTitle() As String
        Return "Space Invaders"
    End Function

    Protected Friend Overrides Function GetTileSize() As Integer
        Return 50
    End Function
    Protected Friend Overrides Function GetXCount() As Integer
        Return 17
    End Function
    Protected Friend Overrides Function GetYCount() As Integer
        Return 18
    End Function

End Class
