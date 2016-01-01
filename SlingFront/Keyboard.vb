Module Keyboard
    Public Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Integer
    Public KeyboardControls As StructKeyboardControls

    Public Structure StructKeyboardControls

        ' Application controls
        Dim AppVolUp As Keys
        Dim AppVolDown As Keys
        Dim AppStreamInfo As Keys
        Dim AppNextSlingBox As Keys
        ' Dim AppPopupMenu As Keys
        Dim AppMainMenu As Keys
        Dim AppQuit As Keys
        Dim AppPlayPause As Keys
        Dim AppDisconnect As Keys
        Dim AppSkipFwd As Keys
        Dim AppSkipBack As Keys
        Dim AppQualityAuto As Keys
        Dim AppQualityMinimum As Keys
        Dim AppQualityGood As Keys
        Dim AppQualityBetter As Keys
        Dim AppQualityBest As Keys
        Dim AppQualityBestHD As Keys
        Dim AppInput As Keys
        Dim AppZoom As Keys
        Dim AppShowRemote As Keys

        ' Remote STB controls
        Dim Power As Keys
        Dim PowerOn As Keys
        Dim PowerOff As Keys
        Dim ChannelUp As Keys
        Dim ChannelDown As Keys
        Dim VolumeUp As Keys
        Dim VolumeDown As Keys
        Dim Mute As Keys
        Dim Enter As Keys
        Dim Hundred As Keys
        Dim LastChannel As Keys
        Dim TvVcr As Keys
        Dim External As Keys
        Dim Play As Keys
        Dim [Stop] As Keys
        Dim Pause As Keys
        Dim Rewind As Keys
        Dim FastForward As Keys
        Dim Record As Keys
        Dim SkipForward As Keys
        Dim SkipBack As Keys
        Dim Live As Keys
        Dim Menu As Keys
        Dim Setup As Keys
        Dim Guide As Keys
        Dim Cancel As Keys
        Dim [Exit] As Keys
        Dim Up As Keys
        Dim Down As Keys
        Dim Left As Keys
        Dim Right As Keys
        Dim [Select] As Keys
        Dim PageUp As Keys
        Dim PageDown As Keys
        Dim Favorite As Keys
        Dim Info As Keys
        Dim Format As Keys
        Dim Subtitle As Keys
        Dim Surround As Keys
        Dim Slow As Keys
        Dim Eject As Keys
        Dim Random As Keys
        Dim Pip As Keys
        Dim PipFormat As Keys
        Dim PipFreeze As Keys
        Dim PipSwap As Keys
        Dim PipMove As Keys
        Dim PipSource As Keys
        Dim PipChanUp As Keys
        Dim PipChanDown As Keys
        Dim PipMulti As Keys
        Dim Custom10 As Keys
        Dim Custom11 As Keys
        Dim Custom12 As Keys
        Dim Custom13 As Keys
        Dim Custom14 As Keys
        Dim Custom15 As Keys
        Dim Custom16 As Keys
        Dim Custom17 As Keys
        Dim Custom18 As Keys
        Dim Custom19 As Keys
        Dim Custom20 As Keys
        Dim Custom21 As Keys
        Dim Red As Keys
        Dim Green As Keys
        Dim Yellow As Keys
        Dim Blue As Keys
        Dim White As Keys
        Dim Custom27 As Keys
        Dim Custom28 As Keys
        Dim Custom29 As Keys

    End Structure

    Public Sub SetDefaultKeys()

        KeyboardControls.AppVolUp = Keys.Add
        KeyboardControls.AppVolDown = Keys.Subtract
        KeyboardControls.AppStreamInfo = Keys.LShiftKey
        KeyboardControls.AppNextSlingBox = Keys.N
        ' KeyboardControls.AppPopupMenu = Keys.X
        KeyboardControls.AppMainMenu = Keys.Home
        KeyboardControls.AppQuit = Keys.Escape
        KeyboardControls.AppPlayPause = Keys.LControlKey
        KeyboardControls.AppDisconnect = Keys.LMenu
        KeyboardControls.AppSkipFwd = Keys.S
        KeyboardControls.AppSkipBack = Keys.A
        KeyboardControls.AppQualityAuto = Keys.Q
        KeyboardControls.AppQualityMinimum = Keys.OemPeriod
        KeyboardControls.AppQualityGood = Keys.OemQuestion
        KeyboardControls.AppQualityBetter = Keys.W
        KeyboardControls.AppQualityBest = Keys.X
        KeyboardControls.AppQualityBestHD = Keys.Oemcomma
        KeyboardControls.AppInput = Keys.RControlKey
        KeyboardControls.AppZoom = Keys.Z
        KeyboardControls.AppShowRemote = Keys.R

        KeyboardControls.Power = Keys.P
        KeyboardControls.PowerOn = Keys.None
        KeyboardControls.PowerOff = Keys.None
        KeyboardControls.ChannelUp = Keys.PageUp
        KeyboardControls.ChannelDown = Keys.PageDown
        KeyboardControls.VolumeUp = Keys.None
        KeyboardControls.VolumeDown = Keys.None
        KeyboardControls.Mute = Keys.None
        KeyboardControls.Enter = Keys.None
        KeyboardControls.Hundred = Keys.None
        KeyboardControls.LastChannel = Keys.None
        KeyboardControls.TvVcr = Keys.None
        KeyboardControls.External = Keys.None
        KeyboardControls.Play = Keys.B
        KeyboardControls.[Stop] = Keys.C
        KeyboardControls.Pause = Keys.D
        KeyboardControls.Rewind = Keys.H
        KeyboardControls.FastForward = Keys.J
        KeyboardControls.Record = Keys.K
        KeyboardControls.SkipForward = Keys.None
        KeyboardControls.SkipBack = Keys.None
        KeyboardControls.Live = Keys.None
        KeyboardControls.Menu = Keys.M
        KeyboardControls.Setup = Keys.None
        KeyboardControls.Guide = Keys.G
        KeyboardControls.Cancel = Keys.Back
        KeyboardControls.Exit = Keys.None
        KeyboardControls.Up = Keys.Up
        KeyboardControls.Down = Keys.Down
        KeyboardControls.Left = Keys.Left
        KeyboardControls.Right = Keys.Right
        KeyboardControls.Select = Keys.Enter
        KeyboardControls.PageUp = Keys.L
        KeyboardControls.PageDown = Keys.O
        KeyboardControls.Favorite = Keys.V
        KeyboardControls.Info = Keys.I
        KeyboardControls.Format = Keys.None
        KeyboardControls.Subtitle = Keys.None
        KeyboardControls.Surround = Keys.None
        KeyboardControls.Slow = Keys.None
        KeyboardControls.Eject = Keys.None
        KeyboardControls.Random = Keys.None
        KeyboardControls.Pip = Keys.None
        KeyboardControls.PipFormat = Keys.None
        KeyboardControls.PipFreeze = Keys.None
        KeyboardControls.PipSwap = Keys.None
        KeyboardControls.PipMove = Keys.None
        KeyboardControls.PipSource = Keys.None
        KeyboardControls.PipChanUp = Keys.None
        KeyboardControls.PipChanDown = Keys.None
        KeyboardControls.PipMulti = Keys.None
        KeyboardControls.Custom10 = Keys.None
        KeyboardControls.Custom11 = Keys.None
        KeyboardControls.Custom12 = Keys.None
        KeyboardControls.Custom13 = Keys.None
        KeyboardControls.Custom14 = Keys.None
        KeyboardControls.Custom15 = Keys.None
        KeyboardControls.Custom16 = Keys.None
        KeyboardControls.Custom17 = Keys.None
        KeyboardControls.Custom18 = Keys.None
        KeyboardControls.Custom19 = Keys.None
        KeyboardControls.Custom20 = Keys.None
        KeyboardControls.Custom21 = Keys.None
        KeyboardControls.Red = Keys.E
        KeyboardControls.Green = Keys.F
        KeyboardControls.Yellow = Keys.T
        KeyboardControls.Blue = Keys.Y
        KeyboardControls.White = Keys.U
        KeyboardControls.Custom27 = Keys.None
        KeyboardControls.Custom28 = Keys.None
        KeyboardControls.Custom29 = Keys.None

        Dim Ini_Keys As New IniReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\SlingFront\Keyboard_Mappings_v2.ini")
        If Not IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\SlingFront\Keyboard_Mappings_v2.ini") Then
            Dim sw As IO.StreamWriter = IO.File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\SlingFront\Keyboard_Mappings_v2.ini")
            sw.WriteLine("")
            sw.WriteLine("# This is where you can remap the keys used by the front end.")
            sw.WriteLine("# See Virtual_KeyCodes.txt for the codes")
            sw.WriteLine("")
            sw.Close()
            Dim sw2 As IO.StreamWriter = IO.File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\SlingFront\Virtual_KeyCodes.txt")
            Dim k As Integer

            For Each k In [Enum].GetValues(GetType(Keys))
                Dim keyname As String = Microsoft.VisualBasic.Left(CType(k, Keys).ToString + "                          ", 20)
                sw2.WriteLine(keyname + vbTab + k.ToString)

            Next
            sw2.Close()

            Ini_Keys.Write("Key_Codes", "AppVolUp", KeyboardControls.AppVolUp)
            Ini_Keys.Write("Key_Codes", "AppVolDown", KeyboardControls.AppVolDown)
            Ini_Keys.Write("Key_Codes", "AppStreamInfo", KeyboardControls.AppStreamInfo)
            Ini_Keys.Write("Key_Codes", "AppNextSlingBox", KeyboardControls.AppNextSlingBox)
            ' Ini_Keys.Write("Key_Codes", "AppPopupMenu", KeyboardControls.AppPopupMenu)
            Ini_Keys.Write("Key_Codes", "AppMainMenu", KeyboardControls.AppMainMenu)
            Ini_Keys.Write("Key_Codes", "AppQuit", KeyboardControls.AppQuit)
            Ini_Keys.Write("Key_Codes", "AppPlayPause", KeyboardControls.AppPlayPause)
            Ini_Keys.Write("Key_Codes", "AppDisconnect", KeyboardControls.AppDisconnect)
            Ini_Keys.Write("Key_Codes", "AppSkipFwd", KeyboardControls.AppSkipFwd)
            Ini_Keys.Write("Key_Codes", "AppSkipBack", KeyboardControls.AppSkipBack)
            Ini_Keys.Write("Key_Codes", "AppQualityAuto", KeyboardControls.AppQualityAuto)
            Ini_Keys.Write("Key_Codes", "AppQualityMinimum", KeyboardControls.AppQualityMinimum)
            Ini_Keys.Write("Key_Codes", "AppQualityGood", KeyboardControls.AppQualityGood)
            Ini_Keys.Write("Key_Codes", "AppQualityBetter", KeyboardControls.AppQualityBetter)
            Ini_Keys.Write("Key_Codes", "AppQualityBest", KeyboardControls.AppQualityBest)
            Ini_Keys.Write("Key_Codes", "AppQualityBestHD", KeyboardControls.AppQualityBestHD)
            Ini_Keys.Write("Key_Codes", "AppInput", KeyboardControls.AppInput)
            Ini_Keys.Write("Key_Codes", "AppZoom", KeyboardControls.AppZoom)
            Ini_Keys.Write("Key_Codes", "AppShowRemote", KeyboardControls.AppShowRemote)

            Ini_Keys.Write("Key_Codes", "Power", KeyboardControls.Power)
            Ini_Keys.Write("Key_Codes", "PowerOn", KeyboardControls.PowerOn)
            Ini_Keys.Write("Key_Codes", "PowerOff", KeyboardControls.PowerOff)
            Ini_Keys.Write("Key_Codes", "ChannelUp", KeyboardControls.ChannelUp)
            Ini_Keys.Write("Key_Codes", "ChannelDown", KeyboardControls.ChannelDown)
            Ini_Keys.Write("Key_Codes", "VolumeUp", KeyboardControls.VolumeUp)
            Ini_Keys.Write("Key_Codes", "VolumeDown", KeyboardControls.VolumeDown)
            Ini_Keys.Write("Key_Codes", "Mute", KeyboardControls.Mute)
            Ini_Keys.Write("Key_Codes", "Enter", KeyboardControls.Enter)
            Ini_Keys.Write("Key_Codes", "Hundred", KeyboardControls.Hundred)
            Ini_Keys.Write("Key_Codes", "LastChannel", KeyboardControls.LastChannel)
            Ini_Keys.Write("Key_Codes", "TvVcr", KeyboardControls.TvVcr)
            Ini_Keys.Write("Key_Codes", "External", KeyboardControls.External)
            Ini_Keys.Write("Key_Codes", "Play", KeyboardControls.Play)
            Ini_Keys.Write("Key_Codes", "Stop", KeyboardControls.Stop)
            Ini_Keys.Write("Key_Codes", "Pause", KeyboardControls.Pause)
            Ini_Keys.Write("Key_Codes", "Rewind", KeyboardControls.Rewind)
            Ini_Keys.Write("Key_Codes", "FastForward", KeyboardControls.FastForward)
            Ini_Keys.Write("Key_Codes", "Record", KeyboardControls.Record)
            Ini_Keys.Write("Key_Codes", "SkipForward", KeyboardControls.SkipForward)
            Ini_Keys.Write("Key_Codes", "SkipBack", KeyboardControls.SkipBack)
            Ini_Keys.Write("Key_Codes", "Live", KeyboardControls.Live)
            Ini_Keys.Write("Key_Codes", "Menu", KeyboardControls.Menu)
            Ini_Keys.Write("Key_Codes", "Setup", KeyboardControls.Setup)
            Ini_Keys.Write("Key_Codes", "Guide", KeyboardControls.Guide)
            Ini_Keys.Write("Key_Codes", "Cancel", KeyboardControls.Cancel)
            Ini_Keys.Write("Key_Codes", "Exit", KeyboardControls.Exit)
            Ini_Keys.Write("Key_Codes", "Up", KeyboardControls.Up)
            Ini_Keys.Write("Key_Codes", "Down", KeyboardControls.Down)
            Ini_Keys.Write("Key_Codes", "Left", KeyboardControls.Left)
            Ini_Keys.Write("Key_Codes", "Right", KeyboardControls.Right)
            Ini_Keys.Write("Key_Codes", "Select", KeyboardControls.Select)
            Ini_Keys.Write("Key_Codes", "PageUp", KeyboardControls.PageUp)
            Ini_Keys.Write("Key_Codes", "PageDown", KeyboardControls.PageDown)
            Ini_Keys.Write("Key_Codes", "Favorite", KeyboardControls.Favorite)
            Ini_Keys.Write("Key_Codes", "Info", KeyboardControls.Info)
            Ini_Keys.Write("Key_Codes", "Format", KeyboardControls.Format)
            Ini_Keys.Write("Key_Codes", "Subtitle", KeyboardControls.Subtitle)
            Ini_Keys.Write("Key_Codes", "Surround", KeyboardControls.Surround)
            Ini_Keys.Write("Key_Codes", "Slow", KeyboardControls.Slow)
            Ini_Keys.Write("Key_Codes", "Eject", KeyboardControls.Eject)
            Ini_Keys.Write("Key_Codes", "Random", KeyboardControls.Random)
            Ini_Keys.Write("Key_Codes", "Pip", KeyboardControls.Pip)
            Ini_Keys.Write("Key_Codes", "PipFormat", KeyboardControls.PipFormat)
            Ini_Keys.Write("Key_Codes", "PipFreeze", KeyboardControls.PipFreeze)
            Ini_Keys.Write("Key_Codes", "PipSwap", KeyboardControls.PipSwap)
            Ini_Keys.Write("Key_Codes", "PipMove", KeyboardControls.PipMove)
            Ini_Keys.Write("Key_Codes", "PipSource", KeyboardControls.PipSource)
            Ini_Keys.Write("Key_Codes", "PipChanUp", KeyboardControls.PipChanUp)
            Ini_Keys.Write("Key_Codes", "PipChanDown", KeyboardControls.PipChanDown)
            Ini_Keys.Write("Key_Codes", "PipMulti", KeyboardControls.PipMulti)
            Ini_Keys.Write("Key_Codes", "Custom10", KeyboardControls.Custom10)
            Ini_Keys.Write("Key_Codes", "Custom11", KeyboardControls.Custom11)
            Ini_Keys.Write("Key_Codes", "Custom12", KeyboardControls.Custom12)
            Ini_Keys.Write("Key_Codes", "Custom13", KeyboardControls.Custom13)
            Ini_Keys.Write("Key_Codes", "Custom14", KeyboardControls.Custom14)
            Ini_Keys.Write("Key_Codes", "Custom15", KeyboardControls.Custom15)
            Ini_Keys.Write("Key_Codes", "Custom16", KeyboardControls.Custom16)
            Ini_Keys.Write("Key_Codes", "Custom17", KeyboardControls.Custom17)
            Ini_Keys.Write("Key_Codes", "Custom18", KeyboardControls.Custom18)
            Ini_Keys.Write("Key_Codes", "Custom19", KeyboardControls.Custom19)
            Ini_Keys.Write("Key_Codes", "Custom20", KeyboardControls.Custom20)
            Ini_Keys.Write("Key_Codes", "Custom21", KeyboardControls.Custom21)
            Ini_Keys.Write("Key_Codes", "Red", KeyboardControls.Red)
            Ini_Keys.Write("Key_Codes", "Green", KeyboardControls.Green)
            Ini_Keys.Write("Key_Codes", "Yellow", KeyboardControls.Yellow)
            Ini_Keys.Write("Key_Codes", "Blue", KeyboardControls.Blue)
            Ini_Keys.Write("Key_Codes", "White", KeyboardControls.White)
            Ini_Keys.Write("Key_Codes", "Custom27", KeyboardControls.Custom27)
            Ini_Keys.Write("Key_Codes", "Custom28", KeyboardControls.Custom28)
            Ini_Keys.Write("Key_Codes", "Custom29", KeyboardControls.Custom29)

        End If

        Ini_Keys.ReadSetKeyCode("Key_Codes", "AppVolUp", KeyboardControls.AppVolUp)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "AppVolDown", KeyboardControls.AppVolDown)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "AppStreamInfo", KeyboardControls.AppStreamInfo)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "AppNextSlingBox", KeyboardControls.AppNextSlingBox)
        '  Ini_Keys.ReadSetKeyCode("Key_Codes", "AppPopupMenu", KeyboardControls.AppPopupMenu)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "AppMainMenu", KeyboardControls.AppMainMenu)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "AppQuit", KeyboardControls.AppQuit)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "AppPlayPause", KeyboardControls.AppPlayPause)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "AppDisconnect", KeyboardControls.AppDisconnect)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "AppSkipFwd", KeyboardControls.AppSkipFwd)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "AppSkipBack", KeyboardControls.AppSkipBack)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "AppQualityAuto", KeyboardControls.AppQualityAuto)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "AppQualityMinimum", KeyboardControls.AppQualityMinimum)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "AppQualityGood", KeyboardControls.AppQualityGood)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "AppQualityBetter", KeyboardControls.AppQualityBetter)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "AppQualityBest", KeyboardControls.AppQualityBest)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "AppQualityBestHD", KeyboardControls.AppQualityBestHD)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "AppInput", KeyboardControls.AppInput)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "AppZoom", KeyboardControls.AppZoom)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "AppShowRemote", KeyboardControls.AppShowRemote)

        Ini_Keys.ReadSetKeyCode("Key_Codes", "Power", KeyboardControls.Power)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "PowerOn", KeyboardControls.PowerOn)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "PowerOff", KeyboardControls.PowerOff)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "ChannelUp", KeyboardControls.ChannelUp)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "ChannelDown", KeyboardControls.ChannelDown)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "VolumeUp", KeyboardControls.VolumeUp)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "VolumeDown", KeyboardControls.VolumeDown)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Mute", KeyboardControls.Mute)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Enter", KeyboardControls.Enter)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Hundred", KeyboardControls.Hundred)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "LastChannel", KeyboardControls.LastChannel)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "TvVcr", KeyboardControls.TvVcr)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "External", KeyboardControls.External)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Play", KeyboardControls.Play)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Stop", KeyboardControls.Stop)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Pause", KeyboardControls.Pause)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Rewind", KeyboardControls.Rewind)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "FastForward", KeyboardControls.FastForward)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Record", KeyboardControls.Record)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "SkipForward", KeyboardControls.SkipForward)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "SkipBack", KeyboardControls.SkipBack)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Live", KeyboardControls.Live)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Menu", KeyboardControls.Menu)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Setup", KeyboardControls.Setup)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Guide", KeyboardControls.Guide)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Cancel", KeyboardControls.Cancel)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Exit", KeyboardControls.Exit)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Up", KeyboardControls.Up)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Down", KeyboardControls.Down)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Left", KeyboardControls.Left)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Right", KeyboardControls.Right)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Select", KeyboardControls.Select)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "PageUp", KeyboardControls.PageUp)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "PageDown", KeyboardControls.PageDown)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Favorite", KeyboardControls.Favorite)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Info", KeyboardControls.Info)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Format", KeyboardControls.Format)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Subtitle", KeyboardControls.Subtitle)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Surround", KeyboardControls.Surround)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Slow", KeyboardControls.Slow)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Eject", KeyboardControls.Eject)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Random", KeyboardControls.Random)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Pip", KeyboardControls.Pip)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "PipFormat", KeyboardControls.PipFormat)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "PipFreeze", KeyboardControls.PipFreeze)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "PipSwap", KeyboardControls.PipSwap)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "PipMove", KeyboardControls.PipMove)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "PipSource", KeyboardControls.PipSource)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "PipChanUp", KeyboardControls.PipChanUp)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "PipChanDown", KeyboardControls.PipChanDown)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "PipMulti", KeyboardControls.PipMulti)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Custom10", KeyboardControls.Custom10)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Custom11", KeyboardControls.Custom11)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Custom12", KeyboardControls.Custom12)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Custom13", KeyboardControls.Custom13)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Custom14", KeyboardControls.Custom14)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Custom15", KeyboardControls.Custom15)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Custom16", KeyboardControls.Custom16)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Custom17", KeyboardControls.Custom17)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Custom18", KeyboardControls.Custom18)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Custom19", KeyboardControls.Custom19)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Custom20", KeyboardControls.Custom20)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Custom21", KeyboardControls.Custom21)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Red", KeyboardControls.Red)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Green", KeyboardControls.Green)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Yellow", KeyboardControls.Yellow)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Blue", KeyboardControls.Blue)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "White", KeyboardControls.White)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Custom27", KeyboardControls.Custom27)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Custom28", KeyboardControls.Custom28)
        Ini_Keys.ReadSetKeyCode("Key_Codes", "Custom29", KeyboardControls.Custom29)

    End Sub
    Public Function GetValidKey(ky As Integer) As Integer

        For Each k As Integer In [Enum].GetValues(GetType(Keys))
            If ky = k Then Return ky
        Next
        Return 0

    End Function
    Public Function IsKeyDown(ByVal K As Keys) As Boolean

        If K <> Keys.None And GetAsyncKeyState(K) = -32767 Then
            Return True
        End If

        Return False
    End Function

End Module