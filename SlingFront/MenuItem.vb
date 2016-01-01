Public Class MenuItem

    Private Image_Unselected As Bitmap
    Public Image_Selected As Bitmap
    Public MenuItem As Struct_MenuItem
    Private _MainForm As frmmain
    Private _MenuForm As frmonscreen
    Private _Display As Struct_Menu_DisplayProperties
    Private _Font As Font

    Public Structure Struct_MenuItem

        Dim Type As MenuType_Type
        Dim ButtonType As MenuType_Button
        Dim SettingType As MenuType_Setting

        Dim AddSpace As Boolean
        Dim Text As String

        Dim Cmd As Struct_Menu_CMD
        Dim Ini As Struct_MenuIni
        Dim IsOver As Boolean
        Dim IsSelected As Boolean
    End Structure
    Public Structure Struct_Menu_CMD
        Dim CMD_Text As String
        Dim CMD_Object As Object
        Dim CMD_Integer As Integer
    End Structure
    Public Structure Struct_Menu_DisplayProperties
        Dim Size As Size
        Dim SelectedColor As Color
        Dim UnSelectedColor As Color
        Dim BorderColor As Color

        Dim FontColor As Color
        Dim BorderSize As Integer
    End Structure

    Public Enum IniSettingType
        Set_boolean = 0
        Set_integer = 1
        Set_String = 2

    End Enum

    Public Structure Struct_MenuIni
        Dim Enabled As Boolean
        Dim DefaultValue As Object

        Dim IniClass As IniReader
        Dim Section As String
        Dim Setting As String
        Dim ValueType As IniSettingType
    End Structure
    Public Enum MenuType_Type
        Button = 0
        Setting = 1
    End Enum
    Public Enum MenuType_Setting
        Setting_String = 0
    End Enum

    Public Enum MenuType_Button
        Button = 0
        Button_Slingbox = 1
        Button_Menu = 2
        Button_IRCode = 3
        Button_Input = 4
        Button_Aspect = 5
        Button_PlayPause = 6
        Button_Stop = 7
        Button_MainMenu = 8
        Button_Save = 9
        Button_Cancel = 10
        Button_Menu_Slingboxes = 11

        Button_Guide = 12
        Button_Info = 13
        Button_Menu_Encoding = 14
        Button_ExitMainMenu = 15
        Button_Menu_Remote = 16
        Button_Exit = 17
        Button_Menu_Settings = 18
        Button_Menu_EditSlingboxes = 19
        Button_Menu_EditSlingbox = 20
        Button_Menu_AddSlingbox = 21
        Button_Menu_Keyboard_Controls = 22
        Button_Menu_ProxySettings = 23
        Button_Menu_Account = 24
        Button_Menu_GeneralSettings = 25

    End Enum

    Private Sub MenuItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Public Sub SelectMenu()
        Me.MenuItem.IsOver = True

    End Sub
    Public Sub DeSelectMenu()
        Me.MenuItem.IsOver = False

    End Sub

    Public Sub New(ByRef MenuItem As Struct_MenuItem, ByRef MainForm As frmmain, ByRef MenuForm As frmonscreen, ByRef Font As Font, ByVal Display As Struct_Menu_DisplayProperties)

        InitializeComponent()
        Me.Size = Display.Size

        Me._MainForm = MainForm
        Me._MenuForm = MenuForm
        Me.MenuItem = MenuItem
        _Font = Font
        _Display = Display
        Dim G_Selected As Graphics
        Dim G_Unselected As Graphics
        Me.Image_Selected = New Bitmap(Display.Size.Width, Display.Size.Height)
        Me.Image_Unselected = New Bitmap(Display.Size.Width, Display.Size.Height)

        Dim BorderBrush As New SolidBrush(Display.BorderColor)
        Dim UnSelectedBrush As New SolidBrush(Display.UnSelectedColor)
        Dim SelectedBrush As New SolidBrush(Display.SelectedColor)

        G_Selected = Graphics.FromImage(Image_Selected)
        G_Unselected = Graphics.FromImage(Image_Unselected)
        G_Selected.Clear(Display.SelectedColor)
        G_Unselected.Clear(Display.UnSelectedColor)
        G_Selected.DrawRectangle(New Pen(Display.BorderColor, Display.BorderSize), New Rectangle(0, 0, Display.Size.Width - Display.BorderSize, Display.Size.Height - Display.BorderSize))
        G_Unselected.DrawRectangle(New Pen(Display.BorderColor, Display.BorderSize), New Rectangle(0, 0, Display.Size.Width - Display.BorderSize, Display.Size.Height - Display.BorderSize))

        G_Selected.DrawString(MenuItem.Text, _Font, New SolidBrush(Display.FontColor), Display.BorderSize + 2, Display.BorderSize + 2)
        G_Unselected.DrawString(MenuItem.Text, _Font, New SolidBrush(Display.FontColor), Display.BorderSize + 2, Display.BorderSize + 2)

        G_Selected.Dispose()
        G_Unselected.Dispose()

    End Sub
    Public Sub Draw(ByVal x As Integer, ByVal y As Integer, ByVal g As Graphics)
        If Me.MenuItem.IsOver Then
            g.DrawImage(Me.Image_Selected, x, y)
        Else
            g.DrawImage(Me.Image_Unselected, x, y)
        End If
    End Sub
End Class