Imports System.Runtime.InteropServices
Imports System.Collections
Public Class frmmain

    Public MatchRefreshRate As Boolean
    Public LastRefreshRate As Byte
    Public ChannelString As String
    Public ChannelTimeout As Integer

    <DllImportAttribute("user32.dll")> _
    Private Shared Function RegisterRawInputDevices _
                (ByVal RIDs() As RAWINPUTDEVICE, _
                ByVal uiNumDevices As Integer, _
                ByVal cbSize As Integer) As Boolean
    End Function
    Private Thread_StartMusic As Threading.Thread = Nothing

    Dim th As New Threading.Thread(AddressOf LoadSlingBoxes2)
    Private Function LookupKey(ByVal intKeyCode As Integer) As MCEButton
        Select Case intKeyCode
            Case 13
                Return MCEButton.OK
            Case 27
                Return MCEButton.Clear
            Case 37
                Return MCEButton.MoveLeft
            Case 38
                Return MCEButton.MoveUp
            Case 39
                Return MCEButton.MoveRight
            Case 40
                Return MCEButton.MoveDown
            Case 48
                Return MCEButton.Number0
            Case 49
                Return MCEButton.Number1
            Case 50
                Return MCEButton.Number2
            Case 51
                Return MCEButton.Number3
            Case 52
                Return MCEButton.Number4
            Case 53
                Return MCEButton.Number5
            Case 54
                Return MCEButton.Number6
            Case 55
                Return MCEButton.Number7
            Case 56
                Return MCEButton.Number8
            Case 57
                Return MCEButton.Number9
            Case 58
                Return MCEButton.Number0
            Case Else

                Return MCEButton.Unknown
        End Select
    End Function

    Private Function LookupAppCommand(ByVal intAppCode As Integer) As MCEButton
        Select Case intAppCode
            Case 65536
                Return MCEButton.Back
            Case 720896
                Return MCEButton.Skip
            Case 786432
                Return MCEButton.Replay
            Case 851968
                Return MCEButton.[Stop]
            Case 271450112
                Return MCEButton.Play
            Case 271515648
                Return MCEButton.Pause
            Case 271581184
                Return MCEButton.Record
            Case 271646720
                Return MCEButton.Forward
            Case 271712256
                Return MCEButton.Rewind
            Case 271777792
                Return MCEButton.ChannelUp
            Case 271843328
                Return MCEButton.ChannelDown
            Case Else

                Return MCEButton.Unknown
        End Select
    End Function

    Private Function LookupRaw(ByVal intRawByte1 As Byte, ByVal intRawByte2 As Byte) As MCEButton

        Select Case intRawByte2
            Case 9
                Return MCEButton.MoreInfo
            Case 36
                If intRawByte1 = 1 OrElse intRawByte1 = 3 Then
                    Return MCEButton.DVDMenu
                Else
                    Return MCEButton.Unknown
                End If
            Case 32

            Case 37
                Return MCEButton.LiveTV
            Case 70
                Return MCEButton.MyTV
            Case 71
                Return MCEButton.MyMusic
            Case 72
                Return MCEButton.RecordedTV
            Case 73
                Return MCEButton.MyPictures
            Case 74
                Return MCEButton.MyVideos
            Case 75
                Return MCEButton.DVDAngle
            Case 76
                Return MCEButton.DVDAudio
            Case 77
                Return MCEButton.DVDSubtitle
            Case 128
                Return MCEButton.OEM1
            Case 129
                Return MCEButton.OEM2
            Case 141
                Return MCEButton.Guide
            Case 226
                Return MCEButton.Mute
            Case 233
                Return MCEButton.VolumeUp
            Case 234
                Return MCEButton.VolumeDown
            Case Else

                Return MCEButton.Unknown
        End Select
    End Function

    Private Const WM_KEYDOWN As Integer = &H100
    Private Const WM_APPCOMMAND As Integer = &H319
    Private Const WM_INPUT As Integer = &HFF
    Private Const RID_INPUT As Integer = &H10000003
    Private Const RIM_TYPEMOUSE As Integer = 0
    Private Const RIM_TYPEKEYBOARD As Integer = 1
    Private Const RIM_TYPEHID As Integer = 2
    Private _button As MCEButton
    Private _intChar As Integer
    Private notdrawn As Boolean

    Public Enum MCEButton
        Unknown

        OK
        MoveUp
        MoveLeft
        MoveRight
        MoveDown
        Back
        Number1
        Number2
        Number3
        Number4
        Number5
        Number6
        Number7
        Number8
        Number9
        Number0
        Clear
        Enter

        Pause
        Play
        Record
        Replay
        Rewind
        Forward
        Skip
        ChannelDown
        ChannelUp
        [Stop]

        MoreInfo
        DVDAngle
        DVDAudio
        DVDMenu
        DVDSubtitle
        Guide
        Mute
        MyTV
        MyMusic
        MyPictures
        MyVideos
        RecordedTV
        OEM1
        OEM2
        LiveTV
        VolumeDown
        VolumeUp
    End Enum

    <DllImportAttribute("user32.dll")> _
    Private Shared Function GetRawInputData _
            (ByVal hRawInput As IntPtr, _
            ByVal uiCommand As Integer, _
            ByVal pData As IntPtr, _
            ByRef byRefpcbSize As Integer, _
            ByVal cbSizeHeader As Integer) As Integer
    End Function

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure RAWINPUTDEVICE
        <MarshalAs(UnmanagedType.U2)> _
        Public usUsagePage As Short
        <MarshalAs(UnmanagedType.U2)> _
        Public usUsage As Short
        <MarshalAs(UnmanagedType.U4)> _
        Public dwFlags As Integer
        Public hwndTarget As IntPtr
    End Structure

    Private Structure RAWINPUT
        Dim header As RAWINPUTHEADER
        Dim hid As RAWHID
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure RAWINPUTHEADER
        <MarshalAs(UnmanagedType.U4)> _
        Dim dwType As Integer
        <MarshalAs(UnmanagedType.U4)> _
        Dim dwSize As Integer
        Dim hDevice As IntPtr
        <MarshalAs(UnmanagedType.U4)> _
        Dim wParam As Integer
    End Structure

    Private Structure RAWHID
        Dim dwSizeHid As Integer
        Dim dwCount As Integer

    End Structure

    Private Sub frmmain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Static IsClosing As Boolean
        'If IsClosing Then Return

        IsClosing = True
        Timer1Second.Enabled = False
        Timer250ml.Enabled = False
        Timer20ml.Enabled = False
        TimerFadeOut.Enabled = False
        TimerFadeStart.Enabled = False
        TimerPlayList.Enabled = False
        TimerStatus.Enabled = False

        Try
            If Slingbox_Current.FinderID <> "" Then
                Reg.SetValue(CRegistry.RootKey.HKEY_CURRENT_USER, "Software\SlingFront", "ResumeLastSlingBox", Slingbox_Current.FinderID, True)

            Else

                Reg.SetValue(CRegistry.RootKey.HKEY_CURRENT_USER, "Software\SlingFront", "ResumeLastSlingBox", "", True)
            End If
        Catch ex As Exception
            Reg.SetValue(CRegistry.RootKey.HKEY_CURRENT_USER, "Software\SlingFront", "ResumeLastSlingBox", "", True)
        End Try
        Try
            Player.Stop()

        Catch ex As Exception

        End Try
        Try

            Try
                If frmonscreen.Created Then
                    frmonscreen.Close()
                End If
            Catch
            End Try

            Try
                SaveSettings()
            Catch
            End Try
            Try
                Me.StopMusic(True)
            Catch
            End Try

        Catch ex As Exception

        End Try
        Try
            Application.Exit()
        Catch
        End Try

    End Sub
    Private Sub ShutdownSlingSDK()
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmmain_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

    End Sub

    Private Sub frmmain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Player.Enabled = False

    End Sub
    Public Function CMD_ChanDown() As Boolean

        Player.RemoteControl.ChannelDown()

    End Function

    Public Function CMD_ChanUp() As Boolean

        Player.RemoteControl.ChannelUp()

    End Function
    Private Function CMD_SendCustomIR(ByVal K As UInteger) As Boolean

    End Function
    Private Function CMD_SendIRKey(ByVal K As IRControlKey) As Boolean

        Player.RemoteControl.SendCommand(K)

    End Function
    Private Function CMD_SetChannel(ByVal C As String) As Boolean
        Player.RemoteControl.SetChannel(C)
    End Function
    Public Function StartSlingBox() As Boolean
        Return StartSlingBox(Slingbox_Current, False)
    End Function
    Private Function StartSlingBox(ByRef SBOX As StructSlingboxInfo, NoRemote As Boolean) As Boolean
        Try
            OkToExit = False

            StopSlingBox()
            SBOX.HasConnected = False
            SBOX.IsConnected = False

            SetStatus("Initializing Core...")

            SetStatus("Loading Slingboxes...")

            SetStatus("Connecting...")

            Player.CurrentBox.FinderID = SBOX.FinderID

            If Len(SBOX.Password) > 15 Then
                If Mid(SBOX.Password, 1, 3) = "E1:" Then
                    Player.DecryptPasswordForNextConnection()

                End If

            End If

            Dim inetServer As System.Net.IPHostEntry
            Dim IP As String = ""
            Player.StreamingProxy.Password = ""
            Player.StreamingProxy.Port = 0
            Player.StreamingProxy.ServerIpAddress = ""
            Player.StreamingProxy.UseBrowserProxy = 0
            Player.StreamingProxy.Username = ""
            Player.StreamingProxy.Apply()
            Try
                If ini_config.ReadInteger("proxy", "type", 0) = 1 Then
                    Player.StreamingProxy.UseBrowserProxy = 1
                    Player.StreamingProxy.Apply()
                Else
                    If ini_config.ReadInteger("Proxy", "Port", 0) > 0 And ini_config.ReadInteger("proxy", "type", 0) = 2 And ini_config.ReadString("Proxy", "Address", "") <> "" Then

                        Try
                            inetServer = System.Net.Dns.Resolve(Replace(Replace(LCase(ini_config.ReadString("Proxy", "Address", "")), "http://", ""), "https://", ""))
                            For Each addr As System.Net.IPAddress In inetServer.AddressList
                                Try
                                    IP = addr.ToString

                                    If UBound(Split(IP, ".")) = 3 Then
                                        Exit For
                                    Else
                                        IP = ""
                                    End If
                                Catch ex As Exception

                                End Try
                            Next
                        Catch
                        End Try

                    End If
                End If

                If IP <> "" Then

                    Player.StreamingProxy.ServerIpAddress = ini_config.ReadString("Proxy", "Address", "")
                    If Crypt.DecryptCode2(ini_config.ReadString("Proxy", "User", "")) <> "" Then
                        Player.StreamingProxy.Username = Crypt.DecryptCode2(ini_config.ReadString("Proxy", "User", ""))
                        Player.StreamingProxy.Password = Crypt.DecryptCode2(ini_config.ReadString("Proxy", "Password", ""))
                    End If

                    Player.StreamingProxy.Port = ini_config.ReadInteger("Proxy", "port", 0)

                    Player.StreamingProxy.UseBrowserProxy = 2

                    Player.StreamingProxy.Apply()

                Else

                End If
            Catch
                Player.StreamingProxy.Password = ""
                Player.StreamingProxy.Port = 0
                Player.StreamingProxy.ServerIpAddress = ""
                Player.StreamingProxy.UseBrowserProxy = 0
                Player.StreamingProxy.Username = ""
                Player.StreamingProxy.Apply()
            End Try

            Player.CurrentBox.Password = SBOX.Password

            Player.PlayerProps.BufferLength = 600
            If SBOX.AccountIsAdmin Then
                Player.CurrentBox.Username = "admin"
            Else

                Player.CurrentBox.Username = "guest"

            End If

            Player.StreamSettings.RestoreToDefaults()
            Dim VideoResolution As StreamVideoResolution
            If SBOX.Encoding.Quality = StreamQuality.Auto Then
                VideoResolution = StreamVideoResolution.VideoResolutionAuto
            ElseIf SBOX.Encoding.Quality = StreamQuality.Minimum Then
                VideoResolution = StreamVideoResolution.Video256x192
            ElseIf SBOX.Encoding.Quality = StreamQuality.Good Then
                VideoResolution = StreamVideoResolution.Video320x240
            ElseIf SBOX.Encoding.Quality = StreamQuality.Better Then
                VideoResolution = StreamVideoResolution.Video640x480
            ElseIf SBOX.Encoding.Quality = StreamQuality.Best Then
                VideoResolution = StreamVideoResolution.VideoHD1920x544
            Else
                VideoResolution = StreamVideoResolution.VideoHD1920x1080
                Player.StreamSettings.FPS = CType(60, UShort)
            End If
            If SBOX.Encoding.Quality = StreamQuality.Auto Or SBOX.Encoding.Bitrate = StreamBitrate.Auto Then
                Player.StreamSettings.Type = CType(1, UShort)
                Player.StreamSettings.LANVideoRes = CType(VideoResolution, UShort)
                Player.StreamSettings.WANVideoRes = CType(VideoResolution, UShort)
            Else
                Player.StreamSettings.Type = CType(2, UShort)
                Player.StreamSettings.ManualVideoRes = CType(VideoResolution, UShort)
                Player.StreamSettings.AudioBitrate = CType(96, UShort)
                Player.StreamSettings.VideoBitrate = CType(128, UShort)
            End If

            Aspect(SBOX)
            Try
                Player.StreamSettings.Apply()
            Catch
                Player.StreamSettings.RestoreToDefaults()
            End Try

            If Player.CurrentBox.IsAvailable = 1 Then
            Else
                SetStatus("SlingBox Not Available.")

                OkToExit = True
                Return False
            End If
            SetStatus("Connecting...")

            If SBOX.AccountIsAdmin Then
                Player.Start(1)
            Else
                Player.Start(0)
            End If

            Last_Admin = SBOX.AccountIsAdmin
            Last_Password = SBOX.Password
            Last_FinderID = SBOX.FinderID

            ForceForegroundWindow(Me.Handle)

            Timer20ml.Enabled = False

            For i As Integer = 0 To 45 * 100
                If Not Me.Created Then Return False

                If IsPlaying() Then
                    Exit For
                End If
                Application.DoEvents()
                System.Threading.Thread.Sleep(10)
                If Player.StatusCode = 0 AndAlso i > 20 Then
                    Exit For
                End If

            Next

            ForceForegroundWindow(Me.Handle)
            If Not IsPlaying() Then
                Player.Stop()
                Sleep(50)
                Application.DoEvents()
                Sleep(50)
                Application.DoEvents()
                Timer20ml.Enabled = True
                Dim nosignal As Boolean = False

                Menu_Main.DrawMenus(True, False, Me)
                If nosignal Then
                    SetStatus("No Video Signal.")
                Else
                    SetStatus("Cannot login to Slingbox.")
                End If

                OkToExit = True
                Return False
            End If

            Try

            Catch ex As Exception

            End Try

            SetStatus("Configuring Player...")

            'If Not PopUpMenu.Visible Then
            Player.Height = Me.ClientRectangle.Height
            'Else
            '    Player.Height = Me.ClientRectangle.Height - PopUpMenu.Height
            'End If

            Me.CMD_SetAspect(SBOX)

            If IsPlaying() Or LCase(Player.status) = "no video signal" Then
                SBOX.HasConnected = True
                SBOX.IsConnected = True
                SBOX.LastConnected = Now()

                If ini_config.ReadInteger("General_Settings", "RefreshRate", 0) = 0 Then
                    MatchRefreshRate = False
                Else
                    MatchRefreshRate = True
                End If
                LastRefreshRate = 0

                ChannelString = ""
                ChannelTimeout = 0

                'Try
                '    Player.SUA.Start(1)
                '    ' MsgBox(Player.SUA.GetChannelAt(4).ToString)

                'Catch ex As Exception
                '    MsgBox(ex.Message)
                'End Try

                If SBOX.UsingRemote And Not NoRemote Then
                    Player.RemoteControl.Show = 1
                End If

                Try
                    SBOX.IRCodes = Player.CurrentVideoInput.IRKeyCodes
                    SBOX.IRDigits = Player.CurrentVideoInput.IRDigits
                Catch

                End Try

                Slingbox_Current = SBOX
                SaveSlingbox(Slingbox_Current)
                OkToExit = True

                SetStatus("Started...")
                ''ReDim Slingbox_Current.IRCodes(CInt(Player.CurrentVideoInput.IRKeysCount))
                'For i As Integer = 0 To CInt(Player.CurrentVideoInput.IRKeysCount) - 1

                'Next

                md.StatusTimerCount = 0
                Me.TimerStatus.Enabled = True
                'If Not Me.PopUpMenu.Visible AndAlso 1 = 2 Then
                '    Me.PopUpMenu.Visible = True

                '    Player.Height = Me.ClientRectangle.Height - PopUpMenu.Height

                '    Me.CMD_SetAspect(SBOX)
                'End If
                StopMusic(False)
                Timer20ml.Enabled = True
                Return True

            End If

            SetStatus("Unable to stream.")
            OkToExit = True
        Catch exx As Exception
            SetStatus("Unable to Connect.")
            OkToExit = True
        End Try
        Timer20ml.Enabled = True
        Return False
    End Function
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub StopSlingBox()
        md.OkToExit = False
        Dim DoneSomething As Boolean = False
        Try
            Player.Stop()
        Catch
        End Try
        md.OkToExit = True

        Slingbox_Current.IsConnected = False

        Return

    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmonscreen.Show()
    End Sub

    Private Sub frmmain_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub frmmain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        Resizeme()

    End Sub

    Sub Resizeme()
        Try
            lblStatus.Font.Dispose()
            lblStatus.Font = New Font(New FontFamily("Arial"), CSng(Me.ClientRectangle.Width / 42), FontStyle.Regular, GraphicsUnit.Pixel)
        Catch
        End Try
        Player.Left = 0
        Player.Top = 0
        Player.Width = Me.ClientRectangle.Width

        'PopUpMenu.Height = CInt(Me.ClientRectangle.Height / 9)
        Vol.Width = CInt(Me.ClientRectangle.Width / 5)
        Vol.Left = Me.ClientRectangle.Width - Vol.Width - CInt((Me.ClientRectangle.Height / 9) / 4)
        Vol.Height = CInt((Me.ClientRectangle.Height / 9) / 2)
        Vol.Top = CInt((Me.ClientRectangle.Height - CInt(Me.ClientRectangle.Height / 9)) + ((Me.ClientRectangle.Height / 9) / 4))
        'If Not PopUpMenu.Visible Then
        Player.Height = Me.ClientRectangle.Height
        'Else
        '    Player.Height = Me.ClientRectangle.Height - PopUpMenu.Height
        'End If

        Try

        Catch
        End Try

        Try

        Catch
        End Try
    End Sub

    Private Sub frmmain_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd

    End Sub
    'Shared Sub Main(ByVal CmdArgs() As String)

    '    Dim ArgNum As Integer
    '    Dim splitstr() As String
    '    Dim laen As Integer

    '    If CmdArgs.Length > 0 Then

    '    End If

    '    Dim b As New frmmain
    'End Sub

    Public Sub New()
        Application.EnableVisualStyles()
        SetAllowUnsafeHeaderParsing()
        CheckForIllegalCrossThreadCalls = False
        If Not IO.File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\Sling Media\WebSlingPlayer ActiveX\SlingPlayerAX.dll") Then
            If MsgBox("Slingplayer ActiveX control is not installed." + vbNewLine + vbNewLine + "Do you want to download the SlingPlayer Active Control?", MsgBoxStyle.OkCancel Or MsgBoxStyle.Question) = MsgBoxResult.Ok Then
                Dim tmpfilename As String = IO.Path.GetTempPath + "\SlingPlayerActiveXControl.exe"
                Dim wc As New Net.WebClient
                wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)")
                Try
                    wc.DownloadFile("http://autoupdate.sling.com/plugin_binary/downloads/msi/1.5.15.770/WBSP_IE_Setup.exe", tmpfilename)
                    Try
                        Shell("cmd /c " + Chr(34) + tmpfilename + Chr(34), AppWinStyle.Hide, False)

                    Catch ex As Exception

                    End Try
                Catch ex As Exception

                    MsgBox("Error Downloading File. Please watch your SlingBox as slingbox.com using Internet Explorer.", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly)
                End Try

            End If
            End
            End

        End If

        Try
            If Not System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\SlingFront") Then
                System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\SlingFront")

            End If
            If Not System.IO.Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\SlingFront\SlingBoxes") Then
                System.IO.Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\SlingFront\SlingBoxes")

            End If

            Crypt.SYC(SYC.SymmProvEnum.DES)

        Catch
            Return
        End Try
        Reg.CreateKey(CRegistry.RootKey.HKEY_CURRENT_USER, "Software\SlingFront")

        ini_config = New IniReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\SlingFront\Settings.ini")
        ini_config.Write("General", "Created", 1)
        ini_slingboxes = New IniReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\SlingFront\SlingBoxes.ini")
        ini_internal = New IniReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\SlingFront\Internal.ini")

        ini_internal.Write("General", "Created", 1)

        If ini_config.ReadString("Login", "Email", "") = "" And ini_config.ReadString("Login", "Password", "") = "" Then
            ini_config.Write("Login", "Email", "")
            ini_config.Write("Login", "Password", "")
            ini_config.Write("Login", "Info", "This is your slinbox.com login email address and password")
        End If

        InitializeComponent()
        MainFormRef = Me

        Thread_CloseMediaCenter = New Threading.Thread(AddressOf ThreadMCE)

        Thread_CloseMediaCenter.Start()

        Player.StreamingProxy.UseBrowserProxy = 0
        Player.StreamSettings.EnableDXVA = Player.DXVACapability

        Player.StreamingProxy.Apply()

        Me.Left = 0
        Me.Top = 0
        Me.Width = Screen.PrimaryScreen.Bounds.Width
        Me.Height = Screen.PrimaryScreen.Bounds.Height
        Me.Visible = False

        frmonscreen.Left = 0
        frmonscreen.Top = 0
        frmonscreen.Width = Screen.PrimaryScreen.Bounds.Width
        frmonscreen.Height = Screen.PrimaryScreen.Bounds.Height
        frmonscreen.Opacity = 0

        frmonscreen.Show()
        Try
            frmonscreen.ComboMusic.SelectedIndex = ini_config.ReadInteger("General_Settings", "MenuMusic", 0)
        Catch ex As Exception

        End Try
        Try
            frmonscreen.ComboStartup.SelectedIndex = ini_config.ReadInteger("General_Settings", "OnStartup", 0)
        Catch ex As Exception

        End Try
        Try
            frmonscreen.ComboRefreshRate.SelectedIndex = ini_config.ReadInteger("General_Settings", "RefreshRate", 0)
        Catch ex As Exception

        End Try

        BakImage = My.Resources.bak

        frmonscreen.ComboQuality.Items.Clear()
        For Each i As Integer In [Enum].GetValues(GetType(StreamQuality))
            frmonscreen.ComboQuality.Items.Add(CType(i, StreamQuality).ToString)
        Next

        frmonscreen.ComboBitrate.Items.Clear()
        For Each i As Integer In [Enum].GetValues(GetType(StreamBitrate))
            frmonscreen.ComboBitrate.Items.Add(CType(i, StreamBitrate).ToString)
        Next

        frmonscreen.ComboChannelDigits.Items.Clear()
        frmonscreen.ComboChannelDigits.Items.Add("Unbuffered")
        frmonscreen.ComboChannelDigits.Items.Add("2 Digit Buffer")
        frmonscreen.ComboChannelDigits.Items.Add("3 Digit Buffer")

        Keyboard.SetDefaultKeys()
        frmonscreen.ComboControl.Sorted = True

        frmonscreen.ComboControl.Items.Add("AppVolUp")
        frmonscreen.ComboControl.Items.Add("AppVolDown")
        frmonscreen.ComboControl.Items.Add("AppStreamInfo")
        frmonscreen.ComboControl.Items.Add("AppNextSlingBox")
        ' frmonscreen.ComboControl.Items.Add("AppPopupMenu")
        frmonscreen.ComboControl.Items.Add("AppMainMenu")
        frmonscreen.ComboControl.Items.Add("AppQuit")
        frmonscreen.ComboControl.Items.Add("AppPlayPause")
        frmonscreen.ComboControl.Items.Add("AppDisconnect")
        frmonscreen.ComboControl.Items.Add("AppSkipFwd")
        frmonscreen.ComboControl.Items.Add("AppSkipBack")
        frmonscreen.ComboControl.Items.Add("AppQualityAuto")
        frmonscreen.ComboControl.Items.Add("AppQualityMinimum")
        frmonscreen.ComboControl.Items.Add("AppQualityGood")
        frmonscreen.ComboControl.Items.Add("AppQualityBetter")
        frmonscreen.ComboControl.Items.Add("AppQualityBest")
        frmonscreen.ComboControl.Items.Add("AppQualityBestHD")
        frmonscreen.ComboControl.Items.Add("AppInput")
        frmonscreen.ComboControl.Items.Add("AppZoom")
        frmonscreen.ComboControl.Items.Add("AppShowRemote")

        frmonscreen.ComboControl.Items.Add("Power")
        frmonscreen.ComboControl.Items.Add("PowerOn")
        frmonscreen.ComboControl.Items.Add("PowerOff")
        frmonscreen.ComboControl.Items.Add("ChannelUp")
        frmonscreen.ComboControl.Items.Add("ChannelDown")
        frmonscreen.ComboControl.Items.Add("VolumeUp")
        frmonscreen.ComboControl.Items.Add("VolumeDown")
        frmonscreen.ComboControl.Items.Add("Mute")
        frmonscreen.ComboControl.Items.Add("Enter")
        frmonscreen.ComboControl.Items.Add("Hundred")
        frmonscreen.ComboControl.Items.Add("LastChannel")
        frmonscreen.ComboControl.Items.Add("TvVcr")
        frmonscreen.ComboControl.Items.Add("External")
        frmonscreen.ComboControl.Items.Add("Play")
        frmonscreen.ComboControl.Items.Add("Stop")
        frmonscreen.ComboControl.Items.Add("Pause")
        frmonscreen.ComboControl.Items.Add("Rewind")
        frmonscreen.ComboControl.Items.Add("FastForward")
        frmonscreen.ComboControl.Items.Add("Record")
        frmonscreen.ComboControl.Items.Add("SkipForward")
        frmonscreen.ComboControl.Items.Add("SkipBack")
        frmonscreen.ComboControl.Items.Add("Live")
        frmonscreen.ComboControl.Items.Add("Menu")
        frmonscreen.ComboControl.Items.Add("Setup")
        frmonscreen.ComboControl.Items.Add("Guide")
        frmonscreen.ComboControl.Items.Add("Cancel")
        frmonscreen.ComboControl.Items.Add("Exit")
        frmonscreen.ComboControl.Items.Add("Up")
        frmonscreen.ComboControl.Items.Add("Down")
        frmonscreen.ComboControl.Items.Add("Left")
        frmonscreen.ComboControl.Items.Add("Right")
        frmonscreen.ComboControl.Items.Add("Select")
        frmonscreen.ComboControl.Items.Add("PageUp")
        frmonscreen.ComboControl.Items.Add("PageDown")
        frmonscreen.ComboControl.Items.Add("Favorite")
        frmonscreen.ComboControl.Items.Add("Info")
        frmonscreen.ComboControl.Items.Add("Format")
        frmonscreen.ComboControl.Items.Add("Subtitle")
        frmonscreen.ComboControl.Items.Add("Surround")
        frmonscreen.ComboControl.Items.Add("Slow")
        frmonscreen.ComboControl.Items.Add("Eject")
        frmonscreen.ComboControl.Items.Add("Random")
        frmonscreen.ComboControl.Items.Add("Pip")
        frmonscreen.ComboControl.Items.Add("PipFormat")
        frmonscreen.ComboControl.Items.Add("PipFreeze")
        frmonscreen.ComboControl.Items.Add("PipSwap")
        frmonscreen.ComboControl.Items.Add("PipMove")
        frmonscreen.ComboControl.Items.Add("PipSource")
        frmonscreen.ComboControl.Items.Add("PipChanUp")
        frmonscreen.ComboControl.Items.Add("PipChanDown")
        frmonscreen.ComboControl.Items.Add("PipMulti")
        frmonscreen.ComboControl.Items.Add("Custom10")
        frmonscreen.ComboControl.Items.Add("Custom11")
        frmonscreen.ComboControl.Items.Add("Custom12")
        frmonscreen.ComboControl.Items.Add("Custom13")
        frmonscreen.ComboControl.Items.Add("Custom14")
        frmonscreen.ComboControl.Items.Add("Custom15")
        frmonscreen.ComboControl.Items.Add("Custom16")
        frmonscreen.ComboControl.Items.Add("Custom17")
        frmonscreen.ComboControl.Items.Add("Custom18")
        frmonscreen.ComboControl.Items.Add("Custom19")
        frmonscreen.ComboControl.Items.Add("Custom20")
        frmonscreen.ComboControl.Items.Add("Custom21")
        frmonscreen.ComboControl.Items.Add("Red")
        frmonscreen.ComboControl.Items.Add("Green")
        frmonscreen.ComboControl.Items.Add("Yellow")
        frmonscreen.ComboControl.Items.Add("Blue")
        frmonscreen.ComboControl.Items.Add("White")
        frmonscreen.ComboControl.Items.Add("Custom27")
        frmonscreen.ComboControl.Items.Add("Custom28")
        frmonscreen.ComboControl.Items.Add("Custom29")

        frmonscreen.ComboControl.MaxDropDownItems = 7
        frmonscreen.ComboControl.SelectedIndex = 0
        System.Windows.Forms.Cursor.Current.Hide()
        TimerFadeStart.Enabled = True

    End Sub

    Private Sub TimerFadeStart_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerFadeStart.Tick
        If Not Me.Created Then Return
        FadeStart()

    End Sub
    Sub FadeStart()
        If frmonscreen.Opacity = 0 Then
            TimerFadeStart.Enabled = False
            TimerFadeStart.Interval = 5
            frmonscreen.lblStatus.Visible = True
            SetDate()

            SetStatus("Loading SlingBoxes...")

            th.IsBackground = False
            th.Priority = Threading.ThreadPriority.Normal
            th.Start()

            TimerFadeStart.Enabled = True
            StartMusic()
        End If
        If frmonscreen.Opacity < 1 Then
            frmonscreen.Opacity += 0.01
            Return
        End If
        If th.IsAlive Then
            Return
        End If
        InitRemote()
        If Not Thread_StartMusic Is Nothing Then
            Do While Thread_StartMusic.IsAlive
                Sleep(6)
            Loop
            If Bass.BASS_ChannelIsActive(Music_Stream) = Bass.PlayingMode.Stopped Then
            Else
                TimerPlayList.Enabled = True
            End If
        End If

        If Not LoggedIn And Not frmonscreen.Panel1.Visible Then
            frmonscreen.Panel1.Visible = True

            frmonscreen.txtEmail.Text = Crypt.DecryptCode4(ini_config.ReadString("Login", "Email", ""))
            frmonscreen.txtPassword.Text = ""

            frmonscreen.txtEmail.SelectionStart = Len(frmonscreen.txtEmail.Text)

            frmonscreen.Panel1.Focus()
            SendKeys.Send("{TAB}")

            Me.Timer20ml.Enabled = True
            TimerFadeStart.Enabled = False

            SetStatus("Please Login.")
            Application.DoEvents()
            StartMusic()
            Return
        End If
        If frmonscreen.Panel1.Visible Then
            TimerFadeStart.Enabled = False
            Return
        End If
        If (Slingbox_Current.FinderID = "" And (Slingbox_Current.IP = "" Or (Slingbox_Current.IP <> "" And Slingbox_Current.Port = 0))) Or ini_config.ReadInteger("General_Settings", "OnStartup", 0) = 1 Then
            TimerFadeStart.Enabled = False
            Me.Timer20ml.Enabled = True
            StartMainMenu()
            Return
        End If
        TimerFadeStart.Enabled = False
        If Not StartSlingBox() Then
            TimerFadeStart.Enabled = False
            Me.Timer20ml.Enabled = True
            StartMainMenu()

            Return
        End If

        Application.DoEvents()

        TimerFadeOut.Enabled = True
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Sub SetStatus(ByVal s As String, Optional ByVal TempStatusShowWait As Integer = DefaultStatusShowWait)

        If Not Me.lblStatus.AutoSize Then
            Try
                Me.lblStatus.AutoSize = True

                Application.DoEvents()
            Catch
            End Try

        End If

        frmonscreen.lblStatus.Text = s
        Me.lblStatus.Text = s
        If Not frmonscreen.Visible Then

            If Not Me.lblStatus.Visible Then
                Me.lblStatus.Visible = True
            End If
        End If

        Application.DoEvents()

        StatusTimerCount = 0
        TimerStatus.Enabled = False
        StatusShowWait = TempStatusShowWait
    End Sub

    Private Sub Timer1Second_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1Second.Tick
        If Not Me.Created Then Return
        If frmonscreen.Opacity > 0.1 Then SetDate()
        Try
            If Player.StatusCode <> 0 And (frmonscreen.Opacity > 0 OrElse (LCase(Player.status) = "no video signal" And frmonscreen.Opacity = 0)) And Not (TimerStatus.Enabled And lblStatus.Text <> "") Then
                SetStatus(Player.status + "...")
            End If
        Catch ex As Exception

        End Try

        If Not TimerStatus.Enabled Then
            If md.StatusTimerCount < md.StatusShowWait Then
                md.StatusTimerCount += 1
                If md.StatusTimerCount = md.StatusShowWait And lblStatus.Visible Then
                    Try
                        TimerStatus.Enabled = False
                        Me.lblStatus.Visible = False

                    Catch
                    End Try

                End If
            End If
        Else
            If md.StatusTimerCount < md.StatusShowWait2 Then
                md.StatusTimerCount += 1
                If md.StatusTimerCount = md.StatusShowWait2 Then
                    Try
                        TimerStatus.Enabled = False
                        Me.lblStatus.Visible = False

                    Catch
                    End Try

                End If
            End If
        End If

        If Len(ChannelString) > 0 Then
            ChannelTimeout += 1
            If Not TimerStatus.Enabled And Not Me.lblStatus.Visible Then
                If ChannelTimeout >= 10 Then
                    ChannelString = ""
                    ChannelTimeout = 0
                Else
                    SetStatus(ChannelString, 5)
                End If
            End If
        End If

        If md.VolumeTimerCount < md.VolumeShowWait Then
            md.VolumeTimerCount += 1
            If md.VolumeTimerCount = md.VolumeShowWait Then
                Try
                    If Vol.Visible Then
                        Me.Vol.Visible = False
                    End If

                Catch
                End Try
                Try
                    If frmonscreen.Vol.Visible Then
                        frmonscreen.Vol.Visible = False
                    End If

                Catch
                End Try

            End If
        End If

    End Sub

    Private Sub Timer250ml_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer250ml.Tick
        If Not Me.Created Then Return
        If MatchRefreshRate And (Player.StatusCode = 4 Or Player.StatusCode = 5) Then
            Dim StreamFramerate As Integer
            Dim RefreshRate(4) As Byte
            Dim ArrayCount As Integer
            StreamFramerate = Player.PlayerProps.StreamFramerate
            If Player.PlayerProps.StreamVideoWidth = 1920 And Player.PlayerProps.StreamVideoHeight = 1080 And StreamFramerate <= 3000 Then
                StreamFramerate = StreamFramerate * 2
            End If
            ArrayCount = 0
            If StreamFramerate = 2500 Then
                RefreshRate(ArrayCount) = 50
                ArrayCount = ArrayCount + 1
            ElseIf StreamFramerate = 5000 Then
                RefreshRate(ArrayCount) = 50
                ArrayCount = ArrayCount + 1
            ElseIf StreamFramerate = 2997 Then
                RefreshRate(ArrayCount) = 59
                ArrayCount = ArrayCount + 1
                RefreshRate(ArrayCount) = 60
                ArrayCount = ArrayCount + 1
            ElseIf StreamFramerate = 5994 Then
                RefreshRate(ArrayCount) = 59
                ArrayCount = ArrayCount + 1
                RefreshRate(ArrayCount) = 60
                ArrayCount = ArrayCount + 1
            ElseIf StreamFramerate = 3000 Then
                RefreshRate(ArrayCount) = 60
                ArrayCount = ArrayCount + 1
                RefreshRate(ArrayCount) = 59
                ArrayCount = ArrayCount + 1
            ElseIf StreamFramerate >= 5999 And StreamFramerate <= 6001 Then
                RefreshRate(ArrayCount) = 60
                ArrayCount = ArrayCount + 1
                RefreshRate(ArrayCount) = 59
                ArrayCount = ArrayCount + 1
            End If
            If ArrayCount > 0 And RefreshRate(0) <> LastRefreshRate Then
                For i As Integer = 0 To ArrayCount - 1
                    If SetRefreshRate(RefreshRate(i)) Then
                        Exit For
                    End If
                Next
                LastRefreshRate = RefreshRate(0)
            End If
        End If

    End Sub

    Private Sub SetDate()

        Dim n As DateTime = Now
        Dim s As String
        s = n.ToString("F")

        frmonscreen.lblDate.Text = s
        frmonscreen.lblDate.Top = 0
        frmonscreen.lblDate.Left = Me.ClientRectangle.Width - frmonscreen.lblDate.Width

        If Not frmonscreen.lblDate.Visible Then
            frmonscreen.lblDate.Visible = True
        End If

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmonscreen.Opacity = 0.76
        frmonscreen.Show()
    End Sub

    Private Sub Timer5ml_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer20ml.Tick
        If Not Me.Created Then Return
        Dim tstart As Integer = Environment.TickCount
        ProcessKeyboard()
        'If Environment.TickCount - tstart > 3 Then Beep()

        If md.Mouse_LastPos.X <> 0 And md.Mouse_LastPos.Y <> 0 Then
            If Mouse_LastPos <> GetMousePos() Then
                If Not md.Mouse_Visible Then
                    md.Mouse_Visible = True
                    System.Windows.Forms.Cursor.Current.Show()
                    PopupMenuTimerCount = 0
                    'If Not Me.PopUpMenu.Visible And Not frmonscreen.Visible Then
                    '    Me.PopUpMenu.Visible = True
                    'End If
                End If
                md.Mouse_TimerCount = 0
            Else
                If md.Mouse_Visible Then
                    If md.Mouse_TimerCount < 1200 Then
                        md.Mouse_TimerCount += 1
                    End If
                    If md.Mouse_TimerCount > 250 Then
                        md.Mouse_Visible = False
                        System.Windows.Forms.Cursor.Current.Hide()
                        'If Me.PopUpMenu.Visible Then
                        '    Me.PopUpMenu.Visible = False
                        'End If
                    End If
                End If
            End If

        End If
        md.Mouse_LastPos = GetMousePos()
    End Sub
    Sub DrawVolume(ByVal Volume As Integer)
        md.VolumeTimerCount = 0

        If Not frmonscreen.Visible Then
            If Not Vol.Image Is Nothing Then
                Vol.Image.Dispose()
            End If
            Vol.Image = New Bitmap(Vol.Width, Vol.Height)
            Dim W As Integer = CInt(((Vol.Image.Width - 2) / (255)) * Volume)
            Dim g As Graphics = Graphics.FromImage(Vol.Image)
            g.DrawRectangle(Pens.White, New Rectangle(0, 0, Vol.Image.Width - 1, Vol.Image.Height - 1))
            g.FillRectangle(New SolidBrush(Color.FromArgb(200, 255, 255, 255)), New Rectangle(1, 1, W, Vol.Image.Height - 2))
            g.Dispose()
            Vol.Visible = True
        End If

        If frmonscreen.Visible Then

            If Not frmonscreen.Vol.Image Is Nothing Then
                frmonscreen.Vol.Image.Dispose()
            End If
            frmonscreen.Vol.Image = New Bitmap(frmonscreen.Vol.Width, frmonscreen.Vol.Height)
            Dim W As Integer = CInt(((frmonscreen.Vol.Image.Width - 2) / (255)) * Volume)
            Dim g2 As Graphics = Graphics.FromImage(frmonscreen.Vol.Image)
            g2.DrawRectangle(Pens.White, New Rectangle(0, 0, frmonscreen.Vol.Image.Width - 1, frmonscreen.Vol.Image.Height - 1))
            g2.FillRectangle(New SolidBrush(Color.FromArgb(200, 255, 255, 255)), New Rectangle(1, 1, W, frmonscreen.Vol.Image.Height - 2))
            g2.Dispose()
            frmonscreen.Vol.Visible = True
        End If

    End Sub
    Sub CMD_VolDown()
        Dim va As Integer

        va = GetMasterVolume()

        va -= 10
        If va < 0 Then va = 0

        SetMasterVolume(va)

        DrawVolume(va)

    End Sub
    Sub CMD_VolUp()
        Dim va As Integer

        va = GetMasterVolume()

        va += 10
        If va > 255 Then va = 255

        SetMasterVolume(va)

        DrawVolume(va)
    End Sub

    Sub Volume()
        DrawVolume(GetMasterVolume())
    End Sub
    Sub HideMouse()
        If md.Mouse_Visible Then
            md.Mouse_Visible = False
            System.Windows.Forms.Cursor.Current.Hide()
        End If

    End Sub
    Sub ProcessKeyboard()
        If Not frmonscreen.Created Then Me.Close()
        If Not Me.Created Then Return

        '
        ' SlingFront Windows controls
        '
        If frmonscreen.Panel1.Visible Or frmonscreen.Panel2.Visible Or frmonscreen.Panel3.Visible Or frmonscreen.Panel4.Visible Or frmonscreen.Panel5.Visible Then
            If IsKeyDown(Keyboard.KeyboardControls.AppQuit) Then
                Me.Close()
                Return
            End If
            If IsKeyDown(Keys.BrowserBack) Then
                If InStr(LCase(frmonscreen.ActiveControl.GetType.ToString), "text") > 0 Then
                    Dim txtbox As TextBox = CType(frmonscreen.ActiveControl, TextBox)
                    If Len(txtbox.Text) > 0 Then
                        If Len(txtbox.Text) = 1 Then
                            txtbox.Text = ""
                        Else
                            txtbox.Text = Mid(txtbox.Text, 1, Len(txtbox.Text) - 1)
                            txtbox.SelectionStart = Len(txtbox.Text)
                        End If
                    End If
                    Return
                End If
            End If
            If IsKeyDown(Keyboard.KeyboardControls.Left) And Keyboard.KeyboardControls.Left <> Keys.Left Then
                If InStr(LCase(frmonscreen.ActiveControl.GetType.ToString), "text") > 0 Then
                    Dim txtbox As TextBox = CType(frmonscreen.ActiveControl, TextBox)
                    If Len(txtbox.Text) > 0 And txtbox.SelectionStart > 0 Then
                        txtbox.SelectionStart -= 1
                    End If
                End If
                Return
            End If
            If IsKeyDown(Keyboard.KeyboardControls.Select) And Keyboard.KeyboardControls.Select <> Keys.Return And Keyboard.KeyboardControls.Select <> Keys.Enter Then
                If InStr(LCase(frmonscreen.ActiveControl.GetType.ToString), "button") > 0 Then
                    Dim but As Button = CType(frmonscreen.ActiveControl, Button)
                    but.PerformClick()
                End If
                Return
            End If
            If IsKeyDown(Keyboard.KeyboardControls.Right) And Keyboard.KeyboardControls.Right <> Keys.Right Then
                If InStr(LCase(frmonscreen.ActiveControl.GetType.ToString), "text") > 0 Then
                    Dim txtbox As TextBox = CType(frmonscreen.ActiveControl, TextBox)
                    If Len(txtbox.Text) > 0 And txtbox.SelectionStart < Len(txtbox.Text) Then
                        txtbox.SelectionStart += 1
                    End If
                End If
                Return
            End If
            Dim cb_open As Boolean
            cb_open = False
            If Not frmonscreen.ActiveControl Is Nothing Then
                If InStr(LCase(frmonscreen.ActiveControl.GetType.ToString), "combobox") > 0 Then
                    Dim cb As ComboBox = CType(frmonscreen.ActiveControl, ComboBox)
                    If cb.DroppedDown Then
                        cb_open = True
                    End If
                End If
            End If
            If IsKeyDown(Keyboard.KeyboardControls.Down) And Not cb_open Then
                If frmonscreen.Panel1.Visible Then
                    frmonscreen.Panel1.SelectNextControl(frmonscreen.ActiveControl, True, True, False, False)
                ElseIf frmonscreen.Panel2.Visible Then
                    frmonscreen.Panel2.SelectNextControl(frmonscreen.ActiveControl, True, True, False, False)
                ElseIf frmonscreen.Panel3.Visible Then
                    frmonscreen.Panel3.SelectNextControl(frmonscreen.ActiveControl, True, True, False, False)
                ElseIf frmonscreen.Panel4.Visible Then
                    frmonscreen.Panel4.SelectNextControl(frmonscreen.ActiveControl, True, True, False, False)
                Else
                    frmonscreen.Panel5.SelectNextControl(frmonscreen.ActiveControl, True, True, False, False)
                End If
                Return
            End If
            If IsKeyDown(Keyboard.KeyboardControls.Up) And Not cb_open Then
                If frmonscreen.Panel1.Visible Then
                    frmonscreen.Panel1.SelectNextControl(frmonscreen.ActiveControl, False, True, False, False)
                ElseIf frmonscreen.Panel2.Visible Then
                    frmonscreen.Panel2.SelectNextControl(frmonscreen.ActiveControl, False, True, False, False)
                ElseIf frmonscreen.Panel3.Visible Then
                    frmonscreen.Panel3.SelectNextControl(frmonscreen.ActiveControl, False, True, False, False)
                ElseIf frmonscreen.Panel4.Visible Then
                    frmonscreen.Panel4.SelectNextControl(frmonscreen.ActiveControl, False, True, False, False)
                Else
                    frmonscreen.Panel5.SelectNextControl(frmonscreen.ActiveControl, False, True, False, False)
                End If
                Return
            End If
            Dim kurkey As Keys
            If IsKeyDown(Keyboard.KeyboardControls.ChannelUp) Then
                kurkey = Keyboard.KeyboardControls.ChannelUp
            Else
                If IsKeyDown(Keyboard.KeyboardControls.ChannelDown) Then
                    kurkey = Keyboard.KeyboardControls.ChannelDown
                Else
                End If
            End If
            If kurkey = Keyboard.KeyboardControls.ChannelUp Or kurkey = Keyboard.KeyboardControls.ChannelDown Then
                If InStr(LCase(frmonscreen.ActiveControl.GetType.ToString), "text") > 0 Then
                    Dim txtbox As TextBox = CType(frmonscreen.ActiveControl, TextBox)
                    If Len(txtbox.Text) < 1 Then
                        txtbox.Text = Chr(32)
                        txtbox.SelectionStart = 0
                    Else
                        If txtbox.SelectionStart = Len(txtbox.Text) Then
                            txtbox.Text += Mid(txtbox.Text, Len(txtbox.Text))
                            txtbox.SelectionStart = Len(txtbox.Text) - 1
                        Else
                            Dim curchar As String = Mid(txtbox.Text, txtbox.SelectionStart + 1, 1)
                            If kurkey = Keyboard.KeyboardControls.ChannelUp Then
                                curchar = Chr(Asc(curchar) + 1)
                                If Asc(curchar) > 127 Then
                                    curchar = Chr(32)
                                End If
                            Else
                                curchar = Chr(Asc(curchar) - 1)
                                If Asc(curchar) < 32 Then
                                    curchar = Chr(127)
                                End If
                            End If
                            If Len(txtbox.Text) = 1 Then
                                txtbox.Text = curchar
                            Else
                                Dim selstart As Integer = txtbox.SelectionStart
                                Dim starttext As String = Mid(txtbox.Text, 1, txtbox.SelectionStart)
                                Dim endtext As String = ""
                                If Len(txtbox.Text) > txtbox.SelectionStart + 1 Then
                                    endtext = Mid(txtbox.Text, txtbox.SelectionStart + 2)
                                End If
                                txtbox.Text = starttext + curchar + endtext
                                txtbox.SelectionStart = selstart
                            End If
                        End If
                    End If
                End If
            End If
        End If
        If frmonscreen.Panel1.Visible Then
            Return
        End If

        '
        ' SlingFront AppQuit key
        '
        If IsKeyDown(Keyboard.KeyboardControls.AppQuit) Then
            If frmonscreen.Opacity < 0.3 And IsPlaying() Then
                StartMainMenu()
                SetStatus("Main Menu")
                Player.Hide()
                Return
            Else
                Me.Close()
                Return
            End If
        End If

        '
        ' SlingFront AppMainMenu key
        '
        If frmonscreen.Panel2.Visible Or frmonscreen.Panel3.Visible Or frmonscreen.Panel4.Visible Or frmonscreen.Panel5.Visible Then
            If IsKeyDown(Keyboard.KeyboardControls.AppMainMenu) OrElse IsKeyDown(Keys.BrowserBack) Then
                StartMainMenu()
                SetStatus("Main Menu")
                Return
            End If
            Return
        Else
            If IsKeyDown(Keyboard.KeyboardControls.AppMainMenu) OrElse IsKeyDown(Keys.BrowserBack) Then
                StartMainMenu()
                SetStatus("Main Menu")
                Player.Hide()
                Return
            End If
        End If

        '
        ' SlingFront main menu
        '
        If frmonscreen.Visible Then
            If frmonscreen.Opacity > 0.1 Then
                If Not Menu_Main Is Nothing Then
                    If Menu_Main.Count > 0 Then
                        If Menu_Main._Orientation = SlingFront.Menu.Orientation.Horizontal Then
                            If Menu_Main.MouseMenus(MousePosX, MousePosY, Me) And IsKeyDown(Keys.LButton) Then SelectMenuItemButton(Menu_Main)
                            If Menu_Main.MenuItem(Menu_Main.SelectedIndex).MenuItem.Type = MenuItem.MenuType_Type.Button Then
                                If IsKeyDown(Keyboard.KeyboardControls.Down) Then
                                    HideMouse()
                                    If Menu_Main.SelectNextMenuItem() Then
                                        Menu_Main.DrawMenus(True, False, Me)
                                    End If
                                    Return
                                End If
                                If IsKeyDown(Keyboard.KeyboardControls.Up) Then
                                    HideMouse()
                                    If Menu_Main.SelectPreviousMenuItem() Then
                                        Menu_Main.DrawMenus(True, False, Me)
                                    End If
                                    Return
                                End If
                                If IsKeyDown(Keyboard.KeyboardControls.Select) Then
                                    HideMouse()
                                    SelectMenuItemButton(Menu_Main)
                                End If
                            End If
                        End If
                    End If
                    Return
                End If
            End If
        End If

        '
        ' SlingFront AppVolUpDown keys
        '
        If IsKeyDown(Keys.VolumeUp) Or IsKeyDown(Keys.VolumeDown) Then
            Volume()
        End If
        If IsKeyDown(Keyboard.KeyboardControls.AppVolUp) Then
            CMD_VolUp()
        End If
        If IsKeyDown(Keyboard.KeyboardControls.AppVolDown) Then
            CMD_VolDown()
        End If

        '
        ' SlingFront AppDisconnect key
        '
        If IsKeyDown(Keyboard.KeyboardControls.AppDisconnect) Then
            If IsPlaying() Then
                SetStatus("Disconnect")
                StopSlingBox()
                StartMainMenu()
                SetStatus("Main Menu")
                Return
            End If
        End If

        If Slingbox_Current.IsConnected Then
            If Player.StatusCode = 0 Then
                SetStatus("Disconnect")
                StopSlingBox()
                StartMainMenu()
                SetStatus("Main Menu")
                Return
            End If
        End If

        If Not IsPlaying() Then
            Return
        End If

        '
        ' SlingFront AppStreamInfo key
        '
        If IsKeyDown(Keyboard.KeyboardControls.AppStreamInfo) Then
            md.StatusTimerCount = 0
            Me.TimerStatus.Enabled = True
            Return
        End If

        '
        ' SlingFront AppNextSlingbox Key
        '
        If IsKeyDown(Keyboard.KeyboardControls.AppNextSlingBox) Then
            CMD_NextSlingBox()
            Return
        End If

        '
        ' SlingFront AppPlayPause key
        '
        If IsKeyDown(Keyboard.KeyboardControls.AppPlayPause) Then
            If MainFormRef.Opacity = 1 Then
                Try
                    If Player.StatusCode = 5 Then
                        Player.Pause()
                    Else
                        If Player.StatusCode = 7 Then
                            Player.Play()
                        End If
                    End If
                Catch ex As Exception
                End Try
            End If
        End If

        '
        ' SlingFront AppSkipFwd key
        '
        If IsKeyDown(Keyboard.KeyboardControls.AppSkipFwd) Then
            Try
                If IsPlaying() Then
                    If Player.StatusCode = 5 Then
                        Timer20ml.Enabled = False
                        Player.Position += CUInt(3000)
                        For i As Integer = 0 To 50
                            Sleep(10)
                            Application.DoEvents()
                        Next
                        Timer20ml.Enabled = True
                    End If
                End If
            Catch ex As Exception
            End Try
            Return
        End If

        '
        ' SlingFront AppSkipBack key
        '
        If IsKeyDown(Keyboard.KeyboardControls.AppSkipBack) Then
            Try
                If IsPlaying() Then
                    If Player.StatusCode = 5 Then
                        Timer20ml.Enabled = False
                        Player.Position -= CUInt(3000)
                        For i As Integer = 0 To 50
                            Sleep(10)
                            Application.DoEvents()
                        Next
                        Timer20ml.Enabled = True
                    End If
                End If
            Catch ex As Exception
            End Try
            Return
        End If

        '
        ' SlingFront AppQuality keys
        '
        Dim NewStreamQuality As StreamQuality
        NewStreamQuality = Slingbox_Current.Encoding.Quality
        If IsKeyDown(Keyboard.KeyboardControls.AppQualityAuto) Then
            NewStreamQuality = StreamQuality.Auto
        ElseIf IsKeyDown(Keyboard.KeyboardControls.AppQualityMinimum) Then
            NewStreamQuality = StreamQuality.Minimum
        ElseIf IsKeyDown(Keyboard.KeyboardControls.AppQualityGood) Then
            NewStreamQuality = StreamQuality.Good
        ElseIf IsKeyDown(Keyboard.KeyboardControls.AppQualityBetter) Then
            NewStreamQuality = StreamQuality.Better
        ElseIf IsKeyDown(Keyboard.KeyboardControls.AppQualityBest) Then
            NewStreamQuality = StreamQuality.Best
        ElseIf IsKeyDown(Keyboard.KeyboardControls.AppQualityBestHD) Then
            NewStreamQuality = StreamQuality.BestHD
        End If
        If Slingbox_Current.Encoding.Quality <> NewStreamQuality Then
            Slingbox_Current.Encoding.Quality = NewStreamQuality
            For i As Integer = 0 To UBound(Slingboxes)
                If Slingboxes(i).FinderID = Slingbox_Current.FinderID Then
                    Slingboxes(i) = Slingbox_Current
                End If
            Next
            SaveSlingbox(Slingbox_Current)
            Dim VideoResolution As StreamVideoResolution
            If Slingbox_Current.Encoding.Quality = StreamQuality.Auto Then
                VideoResolution = StreamVideoResolution.VideoResolutionAuto
            ElseIf Slingbox_Current.Encoding.Quality = StreamQuality.Minimum Then
                VideoResolution = StreamVideoResolution.Video256x192
            ElseIf Slingbox_Current.Encoding.Quality = StreamQuality.Good Then
                VideoResolution = StreamVideoResolution.Video320x240
            ElseIf Slingbox_Current.Encoding.Quality = StreamQuality.Better Then
                VideoResolution = StreamVideoResolution.Video640x480
            ElseIf Slingbox_Current.Encoding.Quality = StreamQuality.Best Then
                VideoResolution = StreamVideoResolution.VideoHD1920x544
            Else
                VideoResolution = StreamVideoResolution.VideoHD1920x1080
                Player.StreamSettings.FPS = CType(60, UShort)
            End If
            If Slingbox_Current.Encoding.Quality = StreamQuality.Auto Or Slingbox_Current.Encoding.Bitrate = StreamBitrate.Auto Then
                Player.StreamSettings.Type = CType(1, UShort)
                Player.StreamSettings.LANVideoRes = CType(VideoResolution, UShort)
                Player.StreamSettings.WANVideoRes = CType(VideoResolution, UShort)
            Else
                Player.StreamSettings.Type = CType(2, UShort)
                Player.StreamSettings.ManualVideoRes = CType(VideoResolution, UShort)
                Player.StreamSettings.AudioBitrate = CType(96, UShort)
                Player.StreamSettings.VideoBitrate = CType(128, UShort)
            End If
            If Slingbox_Current.Encoding.Bitrate = StreamBitrate.Auto Then
                Player.StreamSettings.Apply()
                md.StatusTimerCount = 0
                Me.TimerStatus.Enabled = True
            Else
                Player.Stop()
                frmonscreen.Opacity = 1
                If StartSlingBox() Then
                    frmonscreen.Opacity = 0
                End If
            End If
            Return
        End If

        '
        ' SlingFront AppInput key
        '
        If IsKeyDown(Keyboard.KeyboardControls.AppInput) Then
            CMD_Input()
            md.StatusTimerCount = 0
            Me.TimerStatus.Enabled = True
            Return
        End If

        '
        ' SlingFront AppZoom key
        '
        If IsKeyDown(Keyboard.KeyboardControls.AppZoom) Then
            CMD_IncAspect(Slingbox_Current)
        End If

        '
        ' SlingBox AppShowRemote key
        '
        If IsKeyDown(Keyboard.KeyboardControls.AppShowRemote) Then
            If Player.RemoteControl.Show = 1 Then
                Player.RemoteControl.Show = 0
                Slingbox_Current.UsingRemote = False
            Else
                Player.RemoteControl.Show = 1
                MousePosX = 20
                MousePosY = 20
                Slingbox_Current.UsingRemote = True
            End If
        End If

        '
        ' SlingFront remote navigation
        '
        Dim ShowingRemote As Boolean = False
        Try
            If Player.RemoteControl.Show = 1 Then
                ShowingRemote = True
            End If
        Catch ex As Exception
        End Try
        If ShowingRemote Then
            If IsKeyDown(Keyboard.KeyboardControls.Down) Then
                MousePosY += 4
                Return
            End If
            If IsKeyDown(Keyboard.KeyboardControls.Up) Then
                MousePosY -= 4
                Return
            End If
            If IsKeyDown(Keyboard.KeyboardControls.Left) Then
                MousePosX -= 4
                Return
            End If
            If IsKeyDown(Keyboard.KeyboardControls.Right) Then
                MousePosX += 4
                Return
            End If
            If IsKeyDown(Keyboard.KeyboardControls.Select) Then
                mouse_event(MOUSEEVENTF_MOVE + MOUSEEVENTF_LEFTDOWN + MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
                Return
            End If
        End If

        '
        ' Remote STB commands
        '
        If IsKeyDown(Keyboard.KeyboardControls.Power) Then
            Me.CMD_SendIRKey(IRControlKey.Power)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.PowerOn) Then
            Me.CMD_SendIRKey(IRControlKey.PowerOn)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.PowerOff) Then
            Me.CMD_SendIRKey(IRControlKey.PowerOff)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.ChannelUp) Then
            CMD_ChanUp()
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.ChannelDown) Then
            CMD_ChanDown()
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.VolumeUp) Then
            Me.CMD_SendIRKey(IRControlKey.VolumeUp)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.VolumeDown) Then
            Me.CMD_SendIRKey(IRControlKey.VolumeDown)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Mute) Then
            Me.CMD_SendIRKey(IRControlKey.Mute)
            Return
        End If
        If Slingbox_Current.ChannelDigits > 1 Then
            Dim appended As Boolean
            appended = False
            If IsKeyDown(Keys.D0) Then
                ChannelString = ChannelString + "0"
                appended = True
            End If
            If IsKeyDown(Keys.D1) Then
                ChannelString = ChannelString + "1"
                appended = True
            End If
            If IsKeyDown(Keys.D2) Then
                ChannelString = ChannelString + "2"
                appended = True
            End If
            If IsKeyDown(Keys.D3) Then
                ChannelString = ChannelString + "3"
                appended = True
            End If
            If IsKeyDown(Keys.D4) Then
                ChannelString = ChannelString + "4"
                appended = True
            End If
            If IsKeyDown(Keys.D5) Then
                ChannelString = ChannelString + "5"
                appended = True
            End If
            If IsKeyDown(Keys.D6) Then
                ChannelString = ChannelString + "6"
                appended = True
            End If
            If IsKeyDown(Keys.D7) Then
                ChannelString = ChannelString + "7"
                appended = True
            End If
            If IsKeyDown(Keys.D8) Then
                ChannelString = ChannelString + "8"
                appended = True
            End If
            If IsKeyDown(Keys.D9) Then
                ChannelString = ChannelString + "9"
                appended = True
            End If
            If appended = True Then
                SetStatus(ChannelString, 5)
                If Len(ChannelString) >= Slingbox_Current.ChannelDigits Then
                    CMD_SetChannel(Microsoft.VisualBasic.Left(ChannelString, Slingbox_Current.ChannelDigits))
                    ChannelString = ""
                End If
                ChannelTimeout = 0
            End If
        Else
            If IsKeyDown(Keys.D0) Then CMD_SendIRKey(IRControlKey.Num_0)
            If IsKeyDown(Keys.D1) Then CMD_SendIRKey(IRControlKey.Num_1)
            If IsKeyDown(Keys.D2) Then CMD_SendIRKey(IRControlKey.Num_2)
            If IsKeyDown(Keys.D3) Then CMD_SendIRKey(IRControlKey.Num_3)
            If IsKeyDown(Keys.D4) Then CMD_SendIRKey(IRControlKey.Num_4)
            If IsKeyDown(Keys.D5) Then CMD_SendIRKey(IRControlKey.Num_5)
            If IsKeyDown(Keys.D6) Then CMD_SendIRKey(IRControlKey.Num_6)
            If IsKeyDown(Keys.D7) Then CMD_SendIRKey(IRControlKey.Num_7)
            If IsKeyDown(Keys.D8) Then CMD_SendIRKey(IRControlKey.Num_8)
            If IsKeyDown(Keys.D9) Then CMD_SendIRKey(IRControlKey.Num_9)
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Enter) Then
            Me.CMD_SendIRKey(IRControlKey.Enter)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Hundred) Then
            Me.CMD_SendIRKey(IRControlKey.Hundred)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.LastChannel) Then
            Me.CMD_SendIRKey(IRControlKey.LastChannel)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.TvVcr) Then
            Me.CMD_SendIRKey(IRControlKey.TvVcr)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.External) Then
            Me.CMD_SendIRKey(IRControlKey.External)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Play) Then
            CMD_SendIRKey(IRControlKey.Play)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Stop) Then
            CMD_SendIRKey(IRControlKey.Stop)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Pause) Then
            CMD_SendIRKey(IRControlKey.Pause)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Rewind) Then
            CMD_SendIRKey(IRControlKey.Rewind)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.FastForward) Then
            CMD_SendIRKey(IRControlKey.FastForward)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Record) Then
            CMD_SendIRKey(IRControlKey.Record)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.SkipForward) Then
            CMD_SendIRKey(IRControlKey.SkipForward)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.SkipBack) Then
            CMD_SendIRKey(IRControlKey.SkipBack)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Live) Then
            CMD_SendIRKey(IRControlKey.Live)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Menu) Then
            CMD_SendIRKey(IRControlKey.Menu)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Setup) Then
            CMD_SendIRKey(IRControlKey.Setup)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Guide) Then
            CMD_SendIRKey(IRControlKey.Guide)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Cancel) Then
            CMD_SendIRKey(IRControlKey.Cancel)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Exit) Then
            CMD_SendIRKey(IRControlKey.Exit)
            Return
        End If
        If Not ShowingRemote Then
            If IsKeyDown(Keyboard.KeyboardControls.Up) Then
                CMD_SendIRKey(IRControlKey.Up)
                Return
            End If
            If IsKeyDown(Keyboard.KeyboardControls.Down) Then
                CMD_SendIRKey(IRControlKey.Down)
                Return
            End If
            If IsKeyDown(Keyboard.KeyboardControls.Left) Then
                CMD_SendIRKey(IRControlKey.Left)
                Return
            End If
            If IsKeyDown(Keyboard.KeyboardControls.Right) Then
                CMD_SendIRKey(IRControlKey.Right)
                Return
            End If
            If IsKeyDown(Keyboard.KeyboardControls.Select) Then
                CMD_SendIRKey(IRControlKey.Select)
                Return
            End If
        End If
        If IsKeyDown(Keyboard.KeyboardControls.PageUp) Then
            CMD_SendIRKey(IRControlKey.PageUp)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.PageDown) Then
            CMD_SendIRKey(IRControlKey.PageDown)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Favorite) Then
            CMD_SendIRKey(IRControlKey.Favorite)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Info) Then
            Me.CMD_SendIRKey(IRControlKey.Info)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Format) Then
            Me.CMD_SendIRKey(IRControlKey.Format)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Subtitle) Then
            Me.CMD_SendIRKey(IRControlKey.Subtitle)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Surround) Then
            Me.CMD_SendIRKey(IRControlKey.Surround)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Slow) Then
            Me.CMD_SendIRKey(IRControlKey.Slow)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Eject) Then
            Me.CMD_SendIRKey(IRControlKey.Eject)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Random) Then
            Me.CMD_SendIRKey(IRControlKey.Random)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Pip) Then
            Me.CMD_SendIRKey(IRControlKey.Pip)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.PipFormat) Then
            Me.CMD_SendIRKey(IRControlKey.PipFormat)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.PipFreeze) Then
            Me.CMD_SendIRKey(IRControlKey.PipFreeze)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.PipSwap) Then
            Me.CMD_SendIRKey(IRControlKey.PipSwap)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.PipMove) Then
            Me.CMD_SendIRKey(IRControlKey.PipMove)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.PipSource) Then
            Me.CMD_SendIRKey(IRControlKey.PipSource)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.PipChanUp) Then
            Me.CMD_SendIRKey(IRControlKey.PipChanUp)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.PipChanDown) Then
            Me.CMD_SendIRKey(IRControlKey.PipChanDown)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.PipMulti) Then
            Me.CMD_SendIRKey(IRControlKey.PipMulti)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Custom10) Then
            Me.CMD_SendIRKey(IRControlKey.Custom10)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Custom11) Then
            Me.CMD_SendIRKey(IRControlKey.Custom11)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Custom12) Then
            Me.CMD_SendIRKey(IRControlKey.Custom12)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Custom13) Then
            Me.CMD_SendIRKey(IRControlKey.Custom13)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Custom14) Then
            Me.CMD_SendIRKey(IRControlKey.Custom14)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Custom15) Then
            Me.CMD_SendIRKey(IRControlKey.Custom15)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Custom16) Then
            Me.CMD_SendIRKey(IRControlKey.Custom16)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Custom17) Then
            Me.CMD_SendIRKey(IRControlKey.Custom17)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Custom18) Then
            Me.CMD_SendIRKey(IRControlKey.Custom18)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Custom19) Then
            Me.CMD_SendIRKey(IRControlKey.Custom19)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Custom20) Then
            Me.CMD_SendIRKey(IRControlKey.Custom20)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Custom21) Then
            Me.CMD_SendIRKey(IRControlKey.Custom21)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Red) Then
            If InStr(Player.CurrentVideoInput.Name, "DirecTV Satellite") > 0 Then
                CMD_SendIRKey(IRControlKey.Custom11)
            Else
                CMD_SendIRKey(IRControlKey.Red)
            End If
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Green) Then
            If InStr(Player.CurrentVideoInput.Name, "DirecTV Satellite") > 0 Then
                CMD_SendIRKey(IRControlKey.Custom12)
            Else
                CMD_SendIRKey(IRControlKey.Green)
            End If
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Yellow) Then
            If InStr(Player.CurrentVideoInput.Name, "DirecTV Satellite") > 0 Then
                CMD_SendIRKey(IRControlKey.Custom13)
            Else
                CMD_SendIRKey(IRControlKey.Yellow)
            End If
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Blue) Then
            If InStr(Player.CurrentVideoInput.Name, "DirecTV Satellite") > 0 Then
                CMD_SendIRKey(IRControlKey.Custom14)
            Else
                CMD_SendIRKey(IRControlKey.Blue)
            End If
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.White) Then
            CMD_SendIRKey(IRControlKey.White)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Custom27) Then
            Me.CMD_SendIRKey(IRControlKey.Custom27)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Custom28) Then
            Me.CMD_SendIRKey(IRControlKey.Custom28)
            Return
        End If
        If IsKeyDown(Keyboard.KeyboardControls.Custom29) Then
            Me.CMD_SendIRKey(IRControlKey.Custom29)
            Return
        End If

    End Sub
    Public Property MousePosX As Integer
        Get
            Return System.Windows.Forms.Cursor.Current.Position.X
        End Get
        Set(value As Integer)
            Dim pt As Point = System.Windows.Forms.Cursor.Current.Position
            pt.X = value
            System.Windows.Forms.Cursor.Current.Position = pt
        End Set
    End Property
    Public Property MousePosY As Integer
        Get
            Return System.Windows.Forms.Cursor.Current.Position.Y
        End Get
        Set(value As Integer)
            Dim pt As Point = System.Windows.Forms.Cursor.Current.Position
            pt.Y = value
            System.Windows.Forms.Cursor.Current.Position = pt
        End Set
    End Property
    Private Sub Aspect(ByRef SBOX As StructSlingboxInfo)

        Dim w As Integer = Me.ClientRectangle.Width
        Dim h As Integer = Me.ClientRectangle.Height

        Try
            Select Case SBOX.Aspect
                Case Is = Enum_Aspect.Aspect_43
                    Player.PlayerProps.CropBorder = 0

                    Player.PlayerProps.AspectRatio = CType(SBOX.Aspect, UInteger)

                    Player.Left = 0
                    Player.Top = 0
                    Player.Width = w
                    Player.Height = h
                    SetStatus("Zoom - 4:3")
                Case Is = Enum_Aspect.Aspect_169

                    Player.PlayerProps.CropBorder = 0
                    Player.PlayerProps.AspectRatio = CType(SBOX.Aspect, UInteger)

                    Player.Left = 0
                    Player.Top = 0
                    Player.Width = w
                    Player.Height = h

                    SetStatus("Zoom - 16:9")
                Case Else

                    Player.PlayerProps.AspectRatio = CType(SBOX.Aspect, UInteger)
                    Player.Top = 0
                    Player.Height = h

                    If Screen.PrimaryScreen.WorkingArea.Width / Screen.PrimaryScreen.WorkingArea.Height < 1.5 Then
                        Player.PlayerProps.CropBorder = 0
                    Else
                        Player.PlayerProps.CropBorder = 1
                    End If
                    Player.Left = 0 - CInt(((Me.ClientRectangle.Width * 1.33) - Me.ClientRectangle.Width) / 2)
                    Player.Width = CInt(Me.ClientRectangle.Width * 1.33)

                    SetStatus("Zoom - Anamorphic")

            End Select
        Catch

        End Try
    End Sub
    Private Sub CMD_IncAspect(ByRef SBOX As StructSlingboxInfo)
        Try

            Dim w As Integer = Me.ClientRectangle.Width
            Dim h As Integer = Me.ClientRectangle.Height

            Select Case SBOX.Aspect
                Case Is = Enum_Aspect.Aspect_Anamorphic
                    SBOX.Aspect = Enum_Aspect.Aspect_43
                Case Is = Enum_Aspect.Aspect_43
                    SBOX.Aspect = Enum_Aspect.Aspect_169
                Case Else
                    SBOX.Aspect = Enum_Aspect.Aspect_Anamorphic

            End Select
            Aspect(SBOX)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub CMD_SetAspect(ByRef SBOX As StructSlingboxInfo)
        Try

            Select Case SBOX.Aspect
                Case Is = Enum_Aspect.Aspect_Anamorphic

                    SetStatus("Zoom - Anamorphic")
                Case Is = Enum_Aspect.Aspect_43

                    SetStatus("Zoom - 4:3")

                Case Else
                    Dim w As Integer = Me.ClientRectangle.Width
                    Dim h As Integer = Me.ClientRectangle.Height

                    SetStatus("Zoom - 16:9")

            End Select

        Catch ex As Exception
        End Try

    End Sub

    Private Sub PopUpMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Public Function CMD_Input() As Boolean

        Dim CurrentInput As UInteger = Player.CurrentVideoInput.ID

        CurrentInput += CUInt(1)

        If CurrentInput > Player.VideoInputEnum.Count - 1 Then

            CurrentInput = 0
        End If

        Try
            Player.ChangeVideoInput(CurrentInput)
        Catch

            Player.ChangeVideoInput(0)

        End Try

    End Function

    Private Sub TimerStatus_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerStatus.Tick
        If Not Me.Created Then Return
        Dim strstatus As String = ""
        Static LastStringStatus As String

        If Not Me.lblStatus.Visible Then
            Me.lblStatus.Visible = True
        End If
        Try

            strstatus = ""

            Try
                Dim n As String = Slingbox_Current.Name
                strstatus += n + vbNewLine
            Catch ex As Exception

            End Try
            strstatus += Player.PlayerProps.AudioCodecType & " audio at " & Player.PlayerProps.AudioBitrate & " kb/s"
            strstatus += vbNewLine

            strstatus += Player.PlayerProps.StreamVideoWidth & "x" & Player.PlayerProps.StreamVideoHeight & " " & Player.PlayerProps.VideoCodecType & " video at " & Player.PlayerProps.VideoBitrate & " kb/s"
            strstatus += vbNewLine

            Dim a As String
            Select Case Slingbox_Current.Aspect
                Case Is = Enum_Aspect.Aspect_169
                    a = "Zoom - 16:9"
                Case Enum_Aspect.Aspect_43
                    a = "Zoom - 4:3"
                Case Else
                    a = "Zoom - Anamorphic"

            End Select
            strstatus += CDbl(Player.PlayerProps.StreamFramerate / 100) & " fps. " & a
            strstatus += vbNewLine
            strstatus += "Buffer " + Player.PlayerProps.Precharge + " Speed " + Player.PlayerProps.PlaySpeed

            If Player.CurrentVideoInput.Name <> "" Then
                strstatus += vbNewLine

                strstatus += Player.CurrentVideoInput.Name
            End If

            'If Player.CurrentVideoInput.DeviceModel <> "" Then

            '    strstatus += vbNewLine

            '    strstatus += Player.CurrentVideoInput.DeviceModel
            'End If

            If strstatus <> LastStringStatus Then
                LastStringStatus = strstatus
                lblStatus.Text = strstatus
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub StartMainMenu()
        If frmonscreen.Panel2.Visible Then
            frmonscreen.Panel2.Visible = False

        End If
        If frmonscreen.Panel1.Visible Then
            frmonscreen.Panel1.Visible = False

        End If
        If frmonscreen.Panel3.Visible Then
            frmonscreen.Panel3.Visible = False

        End If
        If frmonscreen.Panel4.Visible Then
            frmonscreen.Panel4.Visible = False

        End If

        If frmonscreen.Panel5.Visible Then
            frmonscreen.Panel5.Visible = False

        End If
        md.CreateMainMenu()
        frmonscreen.Focus()
        frmonscreen.Show()
        Application.DoEvents()
        Try
            If IsPlaying() Or LCase(Player.status) = "no video signal" Then
                frmonscreen.Opacity = 0.76
            Else
                frmonscreen.Opacity = 1
                StartMusic()
            End If
        Catch ex As Exception
            frmonscreen.Opacity = 1
            StartMusic()

        End Try


        frmonscreen.lblStatus.Visible = True
        SetStatus("Main Menu")

        Menu_Main.DrawMenus(True, True, frmonscreen)

    End Sub
    Sub StartMusic()
        If ini_config.ReadInteger("General_Settings", "MenuMusic", 0) <> 0 Then
            Return
        End If
        If Thread_StartMusic Is Nothing Then
        Else
            Do While Thread_StartMusic.IsAlive
                Sleep(10)
            Loop
        End If
        If TimerPlayList.Enabled Then Return
        If IsPlaying() Then
            Return
        End If
        If Thread_StartMusic Is Nothing Then

            Thread_StartMusic = New Threading.Thread(AddressOf StartMusicThread)
            Thread_StartMusic.Start()
        Else
            StartMusicThread()
        End If
    End Sub

    Sub StartMusicThread()
        If UBound(md.Music_Playlist) < 0 Then
            If Music_Loaded Then Return
            Music_Loaded = True
            If Not System.IO.Directory.Exists(Application.StartupPath & "\Media\MenuMusic") Then
                Return
            End If

            Dim FS() As String = System.IO.Directory.GetFiles(Application.StartupPath & "\Media\MenuMusic")
            If UBound(FS) < 0 Then Return
            Dim AL As New ArrayList
            For Each s As String In FS
                Select Case LCase(System.IO.Path.GetExtension(s))
                    Case Is = ".mp3", "mp3", ".ogg", "ogg", ".wav", "wav", ".aif", "aif"
                        AL.Add(s)

                End Select

            Next
            If AL.Count < 1 Then Return
            ReDim md.Music_Playlist(AL.Count - 1)
            For i As Integer = 0 To AL.Count - 1
                md.Music_Playlist(i) = AL(i).ToString
            Next

            If Not InitBass(Me) Then Return

        End If
        If Bass.BASS_ChannelIsActive(Music_Stream) = Bass.PlayingMode.Stopped Then
        Else
            Return

        End If

        md.Music_Track = ini_internal.ReadInteger("Music", "Track", 0)
        md.Music_Pos = ini_internal.ReadLong("Music", "Position", 0)
        If Music_Track > UBound(md.Music_Playlist) Then Music_Track = 0
        Music_Stream = Bass.BASS_StreamCreateFile(Bass.BassBool.BassFalse, Music_Playlist(md.Music_Track), 0, 0, Bass.StreamCreateFile.BASS_STREAM_AUTOFREE)
        Bass.BASS_ChannelPlay(Music_Stream)
        If Music_Stream <> 0 Then
            Bass.BASS_ChannelSetPosition(Music_Stream, md.Music_Pos, 0)

        Else
            ReDim md.Music_Playlist(-1)
        End If

    End Sub
    Sub StopMusic(ByVal ForExit As Boolean)
        If Not Thread_StartMusic Is Nothing Then
            Do While Thread_StartMusic.IsAlive
                Sleep(10)
            Loop
        Else

        End If
        If Not Music_Loaded Then Return
        If UBound(Music_Playlist) < 0 Then Return
        TimerPlayList.Enabled = False

        Me.TimerPlayList.Enabled = False
        If Not Bass.BASS_ChannelIsActive(Music_Stream) = Bass.PlayingMode.Stopped Then
            ini_internal.Write("Music", "Track", md.Music_Track)
            ini_internal.Write("Music", "Position", Bass.BASS_ChannelGetPosition(Music_Stream, 0))

            Bass.BASS_ChannelStop(Music_Stream)
            Bass.BASS_StreamFree(Music_Stream)
            Music_Stream = 0
        End If

        If ForExit Then
            Bass.BASS_Stop()
            Bass.BASS_Free()

        End If
    End Sub

    Private Sub TimerPlayList_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerPlayList.Tick
        If Not Me.Created Then Return
        If Not Thread_StartMusic Is Nothing Then
            If Thread_StartMusic.IsAlive Then Return
        Else
            Return
        End If
        If Music_Stream = 0 Then Return

        If Not Bass.BASS_ChannelIsActive(Music_Stream) = Bass.PlayingMode.Playing Then
            Music_Track += 1
            If Music_Track > UBound(Music_Playlist) Then
                Music_Track = 1
            End If
            Music_Stream = Bass.BASS_StreamCreateFile(Bass.BassBool.BassFalse, Music_Playlist(Music_Track), 0, 0, Bass.StreamCreateFile.BASS_STREAM_AUTOFREE)
            Bass.BASS_ChannelPlay(Music_Stream)
        End If
    End Sub

    Sub LoadPanelEditSlingBox()
        Player.Stop()

        LoadSlingbox(Slingbox_Edit)
        frmonscreen.lblSlingBoxSettings.Text = "Edit SlingBox " + Slingbox_Edit.Name + ":"

        frmonscreen.ComboQuality.SelectedIndex = CInt(Slingbox_Edit.Encoding.Quality)
        frmonscreen.ComboBitrate.SelectedIndex = CInt(Slingbox_Edit.Encoding.Bitrate)
        frmonscreen.ComboChannelDigits.SelectedIndex = Slingbox_Edit.ChannelDigits - 1

        frmonscreen.Panel5.Visible = True
        frmonscreen.Refresh()
        frmonscreen.Panel5.Focus()
        SendKeys.Send("{TAB}")

    End Sub

    Sub LoadProxyPanel()

        Try
            frmonscreen.ProxyComboType.SelectedIndex = ini_config.ReadInteger("Proxy", "Type", 0)
        Catch
            frmonscreen.ProxyComboType.SelectedIndex = 0
        End Try
        frmonscreen.ProxyTxtAddress.Text = ini_config.ReadString("Proxy", "address", "")
        frmonscreen.ProxytxtPassword.Text = Crypt.DecryptCode2(ini_config.ReadString("Proxy", "Password", ""))
        frmonscreen.ProxyTxtPort.Text = ini_config.ReadInteger("Proxy", "Port", 0).ToString
        frmonscreen.ProxytxtUserName.Text = Crypt.DecryptCode2(ini_config.ReadString("Proxy", "User", ""))

        frmonscreen.Panel3.Visible = True
        frmonscreen.Refresh()
        frmonscreen.Panel3.Focus()
        SendKeys.Send("{TAB}")
    End Sub

    Sub SelectMenuItemButton(ByVal Menu As Menu)
        Select Case Menu.MenuItem(Menu.SelectedIndex).MenuItem.ButtonType

            Case MenuItem.MenuType_Button.Button_Exit

                Me.Close()
            Case MenuItem.MenuType_Button.Button_Menu_ProxySettings
                LoadProxyPanel()

            Case MenuItem.MenuType_Button.Button_Menu_EditSlingbox
                Slingbox_Edit = Slingboxes(CInt(Menu.MenuItem(Menu.SelectedIndex).MenuItem.Cmd.CMD_Integer))
                LoadPanelEditSlingBox()
            Case MenuItem.MenuType_Button.Button_Menu_Keyboard_Controls
                frmonscreen.Panel2.Visible = True
                frmonscreen.Refresh()
                frmonscreen.Panel2.Focus()
                SendKeys.Send("{TAB}")
            Case MenuItem.MenuType_Button.Button_Menu_GeneralSettings
                frmonscreen.Panel4.Visible = True
                frmonscreen.Refresh()
                frmonscreen.Panel4.Focus()
                SendKeys.Send("{TAB}")

            Case MenuItem.MenuType_Button.Button_Menu_Account
                frmonscreen.Panel1.Visible = True
                frmonscreen.txtEmail.Text = Crypt.DecryptCode4(ini_config.ReadString("Login", "Email", ""))
                frmonscreen.txtPassword.Text = ""

                frmonscreen.Refresh()
                frmonscreen.Panel1.Focus()
                SendKeys.Send("{TAB}")

                Me.Timer20ml.Enabled = True
                TimerFadeStart.Enabled = False

                SetStatus("Please Login.")
                Application.DoEvents()
                StartMusic()
            Case MenuItem.MenuType_Button.Button_Menu_Remote

                If IsPlaying() Then
                    TimerFadeOut.Enabled = True
                Else
                    If StartSlingBox(Slingbox_Current, True) Then
                        TimerFadeOut.Enabled = True
                    Else

                    End If

                End If
                If Player.RemoteControl.Show = 1 Then
                    Slingbox_Current.UsingRemote = False
                    Player.RemoteControl.Show = 0
                Else
                    MousePosX = 20
                    MousePosY = 20
                    Player.RemoteControl.Show = 1
                    Slingbox_Current.UsingRemote = True
                End If
                TimerFadeOut.Enabled = True
            Case MenuItem.MenuType_Button.Button_Menu_Slingboxes
                CreateSlingBoxMenu()
            Case MenuItem.MenuType_Button.Button_Menu_EditSlingboxes
                CreateEditSlingBoxMenu()
            Case MenuItem.MenuType_Button.Button_Slingbox
                If StartSlingBox(Slingboxes(CInt(Menu.MenuItem(Menu.SelectedIndex).MenuItem.Cmd.CMD_Integer)), False) Then
                    TimerFadeOut.Enabled = True
                End If
            Case MenuItem.MenuType_Button.Button_PlayPause
                If IsPlaying() Then
                    TimerFadeOut.Enabled = True
                Else
                    If StartSlingBox(Slingbox_Current, False) Then
                        TimerFadeOut.Enabled = True
                    Else

                    End If

                End If
            Case MenuItem.MenuType_Button.Button_MainMenu
                StartMainMenu()
            Case MenuItem.MenuType_Button.Button_Menu_Settings
                CreateSettingsMenu()
        End Select

    End Sub

    Private Sub Player_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub TimerFadeOut_Tick(sender As Object, e As EventArgs) Handles TimerFadeOut.Tick
        If Not Me.Created Then Return
        If frmonscreen.Opacity > 0 Then
            If frmonscreen.Opacity - 0.08 <= 0 Then
                frmonscreen.Opacity = 0
                frmonscreen.Visible = False
            Else
                frmonscreen.Opacity -= 0.08
            End If

            Return
        End If
        Player.Show()

        TimerFadeOut.Enabled = False
        frmonscreen.lblStatus.Visible = False
        frmonscreen.Hide()
        Me.Timer20ml.Enabled = True
        TimerFadeStart.Enabled = False
    End Sub

    Private Sub InitRemote()
        Try
            Dim objRID(1) As RAWINPUTDEVICE

            objRID(0).usUsagePage = &HFFBCS
            objRID(0).usUsage = &H88
            objRID(0).dwFlags = 0
            objRID(0).hwndTarget = Handle

            objRID(1).usUsagePage = &HC
            objRID(1).usUsage = &H1
            objRID(1).dwFlags = 0
            objRID(1).hwndTarget = Handle
            If RegisterRawInputDevices(objRID, objRID.Length, Marshal.SizeOf(objRID(0))) Then

            Else

            End If
        Catch
        End Try

    End Sub

    <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Protected Overrides Sub WndProc(ByRef m As Message)
        Dim kp As String = ""

        Try

            Const WM_APPCOMMAND As Integer = &H319

            Const DBT_DEVICECHANGE As Integer = &H219
            Dim InUse As Boolean = False

            Dim remoteprevused As Boolean

            Select Case (m.Msg)

                Case DBT_DEVICECHANGE

                Case WM_APPCOMMAND
                    Select Case m.LParam.ToString
                        Case "271777792"
                            InUse = True
                            remoteprevused = True
                            kp = "CHUP"

                        Case "271843328"
                            InUse = True
                            remoteprevused = True
                            kp = "CHDOWN"

                        Case Else
                            _button = LookupAppCommand(m.LParam.ToInt32)
                            If _button <> MCEButton.Unknown Then
                                Select Case _button
                                    Case Is = MCEButton.DVDMenu
                                        InUse = True
                                        remoteprevused = True
                                        kp = "MENU"
                                    Case Is = MCEButton.ChannelDown
                                        InUse = True
                                        remoteprevused = True
                                        kp = "CHDOWN"
                                    Case Is = MCEButton.ChannelUp
                                        InUse = True
                                        remoteprevused = True
                                        kp = "CHUP"
                                    Case Is = MCEButton.Back
                                        InUse = True
                                        remoteprevused = True
                                        kp = "BACK"

                                    Case Is = MCEButton.Stop
                                        InUse = True
                                        remoteprevused = True
                                        kp = "STOP"
                                    Case Is = MCEButton.Play
                                        InUse = True
                                        remoteprevused = True
                                        kp = "PLAY"
                                    Case Is = MCEButton.Rewind
                                        InUse = True
                                        remoteprevused = True
                                        kp = "REWIND"
                                    Case Is = MCEButton.Forward
                                        InUse = True
                                        remoteprevused = True
                                        kp = "FORWARD"
                                    Case Is = MCEButton.Replay
                                        InUse = True
                                        remoteprevused = True
                                        kp = "REPLAY"

                                    Case Is = MCEButton.Skip
                                        InUse = True
                                        remoteprevused = True
                                        kp = "SKIP"

                                    Case Is = MCEButton.Pause
                                        InUse = True
                                        remoteprevused = True
                                        kp = "PAUSE"
                                    Case Is = MCEButton.Guide
                                        InUse = True
                                        remoteprevused = True
                                        kp = "GUIDE"
                                    Case Is = MCEButton.MoreInfo
                                        InUse = True
                                        remoteprevused = True
                                        kp = "INFO"

                                End Select
                            End If

                    End Select

                Case WM_INPUT
                    Dim pcbSize As Integer

                    GetRawInputData(m.LParam, RID_INPUT, IntPtr.Zero, pcbSize, Marshal.SizeOf(GetType(RAWINPUTHEADER)))
                    Dim buffer As IntPtr
                    Try

                        buffer = Marshal.AllocHGlobal(pcbSize)
                        GetRawInputData(m.LParam, RID_INPUT, buffer, pcbSize, Marshal.SizeOf(GetType(RAWINPUTHEADER)))

                        Dim raw As RAWINPUT
                        raw = CType(Marshal.PtrToStructure(buffer, GetType(RAWINPUT)), RAWINPUT)
                        If raw.header.dwType <> RIM_TYPEHID Then
                            Exit Try
                        End If

                        Dim bRawData(raw.hid.dwSizeHid - 1) As Byte
                        Dim pRawData As Integer
                        pRawData = buffer.ToInt32() + Marshal.SizeOf(GetType(RAWINPUT))
                        Marshal.Copy(New IntPtr(pRawData), bRawData, 0, raw.hid.dwSizeHid)

                        _button = LookupRaw(bRawData(0), bRawData(1))

                        If _button <> MCEButton.Unknown Then

                            If _button = MCEButton.DVDMenu Then
                                kp = "MENU"
                                InUse = True
                                remoteprevused = True

                            End If

                            If _button = MCEButton.MoreInfo Then
                                kp = "INFO"
                                InUse = True
                                remoteprevused = True

                            End If

                            If _button = MCEButton.Guide Then
                                kp = "GUIDE"
                                InUse = True
                                remoteprevused = True

                            End If
                            If _button = MCEButton.ChannelDown Then
                                InUse = True
                                remoteprevused = True
                                kp = "CHDOWN"
                            End If

                            If _button = MCEButton.ChannelUp Then
                                InUse = True
                                remoteprevused = True
                                kp = "CHUP"
                            End If
                        End If
                    Finally
                        If Not buffer.Equals(IntPtr.Zero) Then Marshal.FreeHGlobal(buffer)
                    End Try
                Case Else

            End Select

            If kp <> "" Then

                Select Case kp
                    Case Is = "PLAY", "PAUSE", "GUIDE", "INFO", "STOP", "CHUP", "CHDOWN", "MENU", "SKIP", "REPLAY", "REWIND", "FORWARD"
                        If IsPlaying() Then
                            Select Case kp
                                Case Is = "REWIND"
                                    CMD_SendIRKey(IRControlKey.Rewind)
                                Case Is = "FORWARD"
                                    CMD_SendIRKey(IRControlKey.FastForward)
                                Case Is = "CHDOWN"
                                    CMD_ChanDown()
                                Case Is = "CHUP"
                                    CMD_ChanUp()
                                Case Is = "GUIDE"
                                    CMD_SendIRKey(IRControlKey.Guide)
                                Case Is = "MENU"
                                    CMD_SendIRKey(IRControlKey.Menu)
                                Case Is = "REPLAY"

                                    Try
                                        If IsPlaying() Then

                                            If Player.StatusCode = 5 Then
                                                Timer20ml.Enabled = False
                                                Player.Position -= CUInt(3000)
                                                For i As Integer = 0 To 50
                                                    Sleep(10)
                                                    Application.DoEvents()
                                                Next
                                                Timer20ml.Enabled = True
                                            End If

                                        End If

                                    Catch ex As Exception

                                    End Try

                                Case Is = "SKIP"

                                    Try
                                        If IsPlaying() Then

                                            If Player.StatusCode = 5 Then
                                                Timer20ml.Enabled = False
                                                Player.Position += CUInt(3000)
                                                For i As Integer = 0 To 50
                                                    Sleep(10)
                                                    Application.DoEvents()
                                                Next
                                                Timer20ml.Enabled = True
                                            End If

                                        End If

                                    Catch ex As Exception

                                    End Try
                                Case Is = "INFO"

                                    CMD_SendIRKey(IRControlKey.Info)
                                Case Is = "STOP"
                                    SetStatus("Disconnect")
                                    StopSlingBox()

                                    StartMainMenu()
                                    SetStatus("Main Menu")
                                Case Is = "PLAY"
                                    If MainFormRef.Opacity = 1 Then
                                        Player.Play()
                                    End If
                                Case Is = "PAUSE"
                                    If MainFormRef.Opacity = 0 Then
                                        Player.Pause()
                                    End If

                            End Select
                        End If
                End Select

            Else

            End If
        Catch
        End Try
        If Not kp = "GUIDE" Then
            MyBase.WndProc(m)
        Else

        End If

    End Sub
    Private Sub ThreadMCE()

        Do While MainFormRef.Created
            Sleep(20)

            Dim procs() As Process = Process.GetProcessesByName("ehshell")

            For Each p As Process In procs
                Try
                    p.Kill()
                Catch ex As Exception

                End Try

            Next

        Loop

    End Sub
    Private Sub Player_onStatusChange(sender As Object, e As EventArgs) Handles Player.onStatusChange

    End Sub

    Private Sub Vol_Click(sender As Object, e As EventArgs) Handles Vol.Click

    End Sub
End Class