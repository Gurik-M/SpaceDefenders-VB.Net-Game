Public Interface IMouseListener
    Sub MouseMoved(x As Integer, y As Integer)
    Sub MouseDown(button As Integer, x As Integer, y As Integer)
    Sub MouseUp(button As Integer, x As Integer, y As Integer)
    Sub MouseDrag(buttons As Integer, x As Integer, y As Integer)
    Sub MouseEnter()
    Sub MouseLeave()
End Interface
