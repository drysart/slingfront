Imports SlingFront.MenuItem
Public Class Menu
    Public _G As Graphics
    Public Enum Orientation
        Horizontal = 0
        Vertical = 0
    End Enum
    Private _FrmMain As frmmain
    Private _FrmOnScreen As frmonscreen
    Public _Orientation As Orientation

    Private _Font As Font
    Private _MenuItems(-1) As MenuItem
    Private _Display As Struct_Menu_DisplayProperties
    Private _Area As Rectangle
    Private _LastSelectedIndex As Integer = -1

    Private _Width As Integer
    Private _Height As Integer

    Public Sub New(ByVal Area As Rectangle, ByRef F_Main As frmmain, ByRef F_Menu As frmonscreen, ByVal Orientation As Orientation, ByVal FontFamily As String, ByVal Display As Struct_Menu_DisplayProperties)

        _Orientation = Orientation
        _FrmMain = F_Main
        _FrmOnScreen = F_Menu
        _Area = Area
        _Display = Display

        Dim FSize As Single = 70
        _Font = New Font(New FontFamily(FontFamily), FSize, FontStyle.Regular, GraphicsUnit.Pixel)
        Dim b As New Bitmap(F_Main.Width, F_Main.Height)
        Dim g As Graphics = Graphics.FromImage(b)
        Do While g.MeasureString("AbcdWewieouwoifjoijoiewrEREJFJWQEOIQWPFJGLKVOIEROQWPOdjfirjfuihvjknvoqwo", _Font, New SizeF(b.Width, b.Height), New StringFormat(StringFormatFlags.NoWrap)).Height > Display.Size.Height - (Display.BorderSize * 2)
            FSize -= CSng(0.5)
            _Font.Dispose()
            _Font = Nothing
            _Font = New Font(New FontFamily(FontFamily), FSize, FontStyle.Regular, GraphicsUnit.Pixel)
        Loop
        g.Dispose()
        b.Dispose()

    End Sub
    Public Sub AddMenu(ByVal MI As Struct_MenuItem)
        ReDim Preserve _MenuItems(UBound(_MenuItems) + 1)
        _MenuItems(UBound(_MenuItems)) = New MenuItem(MI, _FrmMain, _FrmOnScreen, _Font, _Display)
        If UBound(_MenuItems) = 0 Then
            Me.SelectedIndex = 0
        End If
    End Sub

    Public ReadOnly Property Count() As Integer
        Get
            Return UBound(_MenuItems) + 1

        End Get
    End Property
    Public Property SelectedIndex() As Integer

        Get
            For i As Integer = 0 To UBound(_MenuItems)
                If _MenuItems(i).MenuItem.IsOver Then
                    Return i
                End If
            Next
            Return -1
        End Get
        Set(ByVal value As Integer)
            For i As Integer = 0 To UBound(_MenuItems)
                _MenuItems(i).DeSelectMenu()
            Next
            _MenuItems(value).SelectMenu()
        End Set
    End Property
    Public Property MenuItem(ByVal i As Integer) As MenuItem
        Get
            Return _MenuItems(i)
        End Get
        Set(ByVal value As MenuItem)
            _MenuItems(i) = value
        End Set
    End Property

    Public Sub Dispose()
        For i As Integer = 0 To UBound(_MenuItems)
            Try
                _MenuItems(i).Dispose()
                _MenuItems(i) = Nothing

            Catch
            End Try

        Next

        ReDim _MenuItems(-1)

    End Sub
    Public Sub SelectItem()

    End Sub

    Public Function SelectPreviousMenuItem() As Boolean
        If Me.SelectedIndex > 0 Then
            Me.SelectedIndex -= 1
            Return True
        End If
        Return False
    End Function
    Public Function SelectNextMenuItem() As Boolean
        If Me.SelectedIndex < Me.Count - 1 Then
            Me.SelectedIndex += 1
            Return True
        End If
        Return False
    End Function
    Public Function MouseMenus(x As Integer, y As Integer, ByVal F As Form) As Boolean
        If Not MainFormRef.Created Then Return False
        If Not frmonscreen.Created Then Return False

        If md.Mouse_Visible = False Then Return False

        Static LastSelected As Integer
        Static LastSelectedText As String
        If LastSelected > -1 And LastSelected <= UBound(_MenuItems) Then

            If _MenuItems(LastSelected).MenuItem.Text <> LastSelectedText Then

                LastSelectedText = _MenuItems(LastSelected).MenuItem.Text
                LastSelected = -1
            End If

        Else
            LastSelected = -1
        End If

        Dim PlusY As Integer = 0
        For i As Integer = 0 To UBound(_MenuItems)

            If _MenuItems(i).MenuItem.AddSpace Then
                PlusY += CInt(Me._Display.Size.Height + Me._Display.Size.Height / 10)
            End If

            Dim r As New Rectangle(_Area.X, _Area.Y + PlusY, _MenuItems(i).Image_Selected.Width, _MenuItems(i).Image_Selected.Height)
            If x >= r.X And x <= r.X + r.Width And y >= r.Y And y <= r.Y + r.Height Then
                Me.SelectedIndex = i
                If LastSelected <> Me.SelectedIndex Then
                    DrawMenus(True, False, F)
                    LastSelected = Me.SelectedIndex
                End If
                Return True
            End If

            PlusY += CInt(Me._Display.Size.Height + Me._Display.Size.Height / 10)
        Next
        Return False
    End Function
    Public Sub DrawMenus(ByVal Force As Boolean, ByVal DrawBackground As Boolean, ByVal F As Form)
        If Not MainFormRef.Created Then Return
        If Not frmonscreen.Created Then Return

        If frmonscreen.Panel1.Visible Then Return
        If frmonscreen.Panel2.Visible Then Return

        If _G Is Nothing Then

            _G = F.CreateGraphics
            DrawBackground = True

        End If

        Try
            If DrawBackground Then

                _G.DrawImage(BakImage, 0, 0, frmmain.ClientRectangle.Width, frmmain.ClientRectangle.Height)

            End If
        Catch
            Return
        End Try
        Dim PlusY As Integer = 0
        For i As Integer = 0 To UBound(_MenuItems)
            If _MenuItems(i).MenuItem.AddSpace Then
                PlusY += CInt(Me._Display.Size.Height + Me._Display.Size.Height / 10)
            End If

            _MenuItems(i).Draw(_Area.X, _Area.Y + PlusY, _G)
            PlusY += CInt(Me._Display.Size.Height + Me._Display.Size.Height / 10)
        Next
    End Sub

End Class