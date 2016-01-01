Imports System.IO

Imports System.Collections
Imports System.Text
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports System.Reflection
Imports System.Net
Imports System.Web

Module md
    Public Declare Auto Function GetWindowThreadProcessId Lib "user32" (ByVal hwnd As IntPtr, _
                       ByRef lpdwProcessId As Integer) As Integer

    <DllImport("user32.dll")> _
    Public Function GetWindowThreadProcessId(hWnd As IntPtr, ProcessId As IntPtr) As UInteger
    End Function

    <DllImport("kernel32.dll")> _
    Public Function GetCurrentThreadId() As UInteger
    End Function

    ''' The GetForegroundWindow function returns a handle to the
    ''' foreground window.
    <DllImport("user32.dll")> _
    Public Function GetForegroundWindow() As IntPtr
    End Function

    <DllImport("user32.dll")> _
    Public Function AttachThreadInput(idAttach As UInteger, idAttachTo As UInteger, fAttach As Boolean) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)> _
    Public Function BringWindowToTop(hWnd As IntPtr) As Boolean
    End Function

    <DllImport("user32.dll", SetLastError:=True)> _
    Public Function BringWindowToTop(hWnd As HandleRef) As Boolean
    End Function
    <DllImport("user32.dll")> _
    Public Function ShowWindow(hWnd As IntPtr, nCmdShow As UInteger) As Boolean
    End Function
    Public Sub ForceForegroundWindow(hWnd As IntPtr)
        Dim foreThread As UInteger = GetWindowThreadProcessId(GetForegroundWindow(), IntPtr.Zero)
        Dim appThread As UInteger = GetCurrentThreadId()
        Const SW_SHOW As UInteger = 5

        If foreThread <> appThread Then
            AttachThreadInput(foreThread, appThread, True)
            BringWindowToTop(hWnd)
            ShowWindow(hWnd, SW_SHOW)
            AttachThreadInput(foreThread, appThread, False)
        Else
            BringWindowToTop(hWnd)
            ShowWindow(hWnd, SW_SHOW)
        End If
    End Sub

    Public Thread_CloseMediaCenter As System.Threading.Thread

    Public LoggedIn As Boolean = False
    Public Reg As New CRegistry

    Public Mouse_LastPos As Point
    Public Mouse_Visible As Boolean
    Public Mouse_TimerCount As Integer
    Public BakImage As Bitmap
    Public _BakImage As Bitmap
    Public Menu_Main As Menu

    Public Slingboxes() As StructSlingboxInfo

    Public Crypt As New SYC

    Public IRKey_LastCount As Integer

    Public MainFormRef As frmmain

    Public ini_config As IniReader
    Public ini_slingboxes As IniReader
    Public ini_internal As IniReader

    Public Music_Playlist(-1) As String
    Public Music_Track As Integer
    Public Music_Pos As Long
    Public Music_Loaded As Boolean
    Public Music_Stream As Integer

    Public OkToExit As Boolean = False

    Public StatusTimerCount As Integer
    Public VolumeTimerCount As Integer

    Public StatusShowWait As Integer
    Public Const DefaultStatusShowWait As Integer = 20
    Public Const VolumeShowWait As Integer = 5
    Public Const StatusShowWait2 As Integer = 12

    Public PopupMenuTimerCount As Integer

    Public Const PopupMenuShowWait As Integer = 7

    Public Last_FinderID As String
    Public Last_Admin As Boolean
    Public Last_Password As String

    Public MusicOn As Boolean
    Public Sub Sleep(ByVal MS As Integer)
        System.Threading.Thread.Sleep(MS)
    End Sub

    Public Function SetMasterVolume(ByVal V As Integer) As Integer
        If System.Environment.OSVersion.Version.Major >= 6 Then
            If vistavol Is Nothing Then
                If Not InitVistaVolumeControl() Then Return 0
            End If
            If Not vistavol Is Nothing Then vistavol.VolumeScalar = CSng((V / 255))
            Return 0
        Else
            Functions_.SetMasterVolume(V)
        End If

    End Function
    Public Function GetMasterVolume() As Integer
        If System.Environment.OSVersion.Version.Major >= 6 Then
            If vistavol Is Nothing Then
                If Not InitVistaVolumeControl() Then Return 0
            End If
            If Not vistavol Is Nothing Then
                Return CInt(vistavol.VolumeScalar() * 255)
            Else
                Return 0
            End If

        Else
            Return Functions_.GetMasterVolume()
        End If

    End Function

    Function GetAppVolume() As Integer

        Dim MasterVol As Integer = md.GetMasterVolume

        Return MasterVol

    End Function
    Function SetAppVolume(ByVal V As Integer) As Boolean

        Dim MasterVol As Integer = md.GetMasterVolume

        If MasterVol < 255 Then
            MasterVol += 10
            If MasterVol > 255 Then MasterVol = 255
            SetMasterVolume(MasterVol)

        End If
    End Function

    Public vistavol As EndpointVolume
    Function InitVistaVolumeControl() As Boolean
        Try
            vistavol = New EndpointVolume(EndpointVolume.EDataFlow.eRender)
        Catch ex As Exception
            vistavol = Nothing
            Return False
        End Try
        Return True
    End Function
    Public Function GetMousePos() As Point
        Return System.Windows.Forms.Cursor.Current.Position
    End Function
    Public Function CMD_NextSlingBox() As Boolean

        If UBound(Slingboxes) <= 0 Then Return False
        If Slingbox_Current.FinderID = "" Then
            Return False
        End If
        Dim i As Integer = Slingbox_Current.ArrayNbr

        i += 1
        If i > UBound(Slingboxes) Then i = 0
        MainFormRef.Player.Stop()
        frmonscreen.Opacity = 1
        Slingbox_Current = Slingboxes(i)
        If Not frmmain.StartSlingBox Then
        Else
            frmonscreen.Opacity = 0
        End If

    End Function

    Sub SetDefaultSlingbox_()

        Slingbox_Current.AccountIsAdmin = False
        Slingbox_Current.Aspect = Enum_Aspect.Aspect_43

        SaveSlingbox(Slingbox_Current)

        LoadSlingbox(Slingbox_Current)

    End Sub
    Public Bass_HasInit As Boolean = False
    Public Bass_InitSuccess As Boolean = False
    Public Function GetSlingBoxFilename(ByVal S As slingboxrelated.StructSlingboxInfo) As String
        If S.FinderID = "" Then Return ""
        If S.FinderID = "" And S.Port <= 0 Then Return ""
        Dim FileName As String = S.FinderID
        Return FileName

    End Function

    Public Function LoadSlingbox(ByRef S As StructSlingboxInfo, ByVal FileName As String) As Boolean
        If Len(FileName) < 5 Then Return False

        Try
            S.FinderID = Path.GetFileNameWithoutExtension(FileName)

        Catch ex As Exception
            Return False
        End Try
        Return LoadSlingbox(S)

    End Function

    Public Function LoadSlingbox(ByVal FinderID As String, ByRef S As StructSlingboxInfo) As Boolean
        If Len(FinderID) < 5 Then Return False

        Try
            S.FinderID = FinderID

        Catch ex As Exception
            Return False
        End Try
        Return LoadSlingbox(S)

    End Function

    Public Function LoadSlingboxes() As Boolean
        Dim Path As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\SlingFront\SlingBoxes"
        Dim Fs() As String = IO.Directory.GetFiles(Path, "*.ini")

        Dim C As Integer = -1
        ReDim Slingboxes(-1)

        For Each s As String In Fs
            Dim sb As StructSlingboxInfo
            If LoadSlingbox(sb, IO.Path.GetFileName(s)) Then
                C += 1
                ReDim Preserve Slingboxes(C)
                Slingboxes(C) = sb
            End If

        Next
    End Function

    Public Function SetAllowUnsafeHeaderParsing() As Boolean

        Dim aNetAssembly As Assembly = Assembly.GetAssembly(GetType(System.Net.Configuration.SettingsSection))
        If aNetAssembly IsNot Nothing Then

            Dim aSettingsType As Type = aNetAssembly.[GetType]("System.Net.Configuration.SettingsSectionInternal")
            If aSettingsType IsNot Nothing Then

                Dim anInstance As Object = aSettingsType.InvokeMember("Section", BindingFlags.[Static] Or BindingFlags.GetProperty Or BindingFlags.NonPublic, Nothing, Nothing, New Object() {})
                If anInstance IsNot Nothing Then

                    Dim aUseUnsafeHeaderParsing As FieldInfo = aSettingsType.GetField("useUnsafeHeaderParsing", BindingFlags.NonPublic Or BindingFlags.Instance)
                    If aUseUnsafeHeaderParsing IsNot Nothing Then
                        aUseUnsafeHeaderParsing.SetValue(anInstance, True)
                        Return True
                    End If
                End If
            End If
        End If
        Return False
    End Function
    Public Sub LoadSlingBoxes2()
        LoadSlingBoxes2(False)
    End Sub
    Public Sub LoadSlingBoxes2(Force As Boolean)
        Dim c As Integer = -1
        ReDim Slingboxes(-1)

        Static buf As String

        Dim s As Integer = 1
        Dim e As Integer
        If Force Then buf = ""
        If buf = "" Then
            Dim wc As New CookieAwareWebClient

            Dim nv As New Specialized.NameValueCollection
            Dim email As String = ini_config.ReadString("Login", "Email", "")
            Dim password As String = ini_config.ReadString("Login", "Password", "")

            password = Crypt.DecryptCode3(password)
            email = Crypt.DecryptCode4(email)

            nv.Add("emailAddress", email)
            nv.Add("password", password)
            Dim ascc As String = ""
            LoggedIn = True
            Try
                If password <> "" Then
                    wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)")
                    Dim b() As Byte = wc.UploadValues("https://accounts.sling.com/accounts/sling/login/loginForm", nv)

                    ascc = wc.DownloadString("https://accounts.sling.com/accounts/sling/login/loginForm?emailAddress=" + HttpUtility.UrlEncode(email) + "&password=" + HttpUtility.UrlEncode(password))

                End If

                If Not InStr(LCase(ascc), "hi, " + LCase(email)) > 0 And Not InStr(LCase(ascc), "hi,&nbsp;" + LCase(email)) > 0 Then

                    LoggedIn = False

                End If
            Catch
                If Crypt.DecryptCode3(ini_config.ReadString("Login", "LastSuccess", "")) <> "" And LCase(Crypt.DecryptCode3(ini_config.ReadString("Login", "LastSuccess", ""))) = LCase(email + password) Then
                    LoggedIn = True
                Else
                    LoggedIn = False
                End If

            End Try

            If Not LoggedIn Then

                Return
            End If
            ini_config.Write("Login", "LastSuccess", Crypt.EncryptCode3(LCase(email + password)))

            wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)")

            Dim success As Boolean = False
            Dim timeouts As Integer = 0
            Do While success = False
                Try
                    buf = wc.DownloadString("https://newwatchsecure.slingbox.com/watch/slingAccounts/account_boxes_js")
                    success = True
                Catch ex As WebException
                    If ex.Status = WebExceptionStatus.Timeout Then
                        timeouts = timeouts + 1
                        If timeouts = 3 Then
                            Return
                        End If
                    Else
                        Return
                    End If
                Catch
                    Return
                End Try
            Loop

        End If

        s = InStr(s, buf, "{")
        If s > 0 Then
            s += 1
            s = InStr(s, buf, "{") + 1
        End If
        Do While InStr(s, buf, "{") > 0
            Try
                s = InStr(s, buf, "{") + 1
                Dim sb As New StructSlingboxInfo
                Dim s2 As Integer = s
                Dim user As String = ""
                s2 = InStr(s, buf, "username"":")
                If s2 > 0 And (s2 < InStr(s, buf, "{") Or InStr(s, buf, "{") = 0) Then

                    s2 = InStr(s2, buf, ":") + 2

                    If Not Mid(buf, s2 - 1, 1) = Chr(34) Then
                        s2 -= 1
                        e = InStr(s2, buf, ",")
                    Else
                        e = InStr(s2, buf, """")
                    End If
                    user = Mid(buf, s2, e - s2)

                Else

                    s2 = s
                    If InStr(s, buf, """adminPassword"":") > 0 And (InStr(s, buf, """adminPassword"":") < InStr(s, buf, "{") Or InStr(s, buf, "{") = 0) Then
                        user = "admin"

                    Else

                        user = "guest"
                    End If
                End If

                If user = "admin" Then
                    sb.AccountIsAdmin = True
                Else
                    sb.AccountIsAdmin = False
                End If

                s2 = InStr(s, buf, Chr(34) + "finderId" + Chr(34) + ":")
                s2 = InStr(s2, buf, ":") + 2

                e = InStr(s2, buf, """")
                Dim finderid As String = Mid(buf, s2, e - s2)

                s2 = InStr(s, buf, """displayName"":")
                s2 = InStr(s2, buf, ":") + 2
                If Not Mid(buf, s2 - 1, 1) = Chr(34) Then
                    s2 -= 1
                    e = InStr(s2, buf, ",")
                Else
                    e = InStr(s2, buf, """")
                End If

                Dim name As String = Mid(buf, s2, e - s2)

                If sb.AccountIsAdmin Then
                    s2 = InStr(s, buf, """adminPassword"":")

                Else
                    s2 = InStr(s, buf, """userPassword"":")
                End If
                s2 = InStr(s2, buf, ":") + 2
                If Not Mid(buf, s2 - 1, 1) = Chr(34) Then
                    s2 -= 1
                    e = InStr(s2, buf, ",")
                Else
                    e = InStr(s2, buf, """")
                End If

                Dim password As String = Mid(buf, s2, e - s2)

                sb.User = user
                sb.Password = password
                sb.FinderID = finderid
                sb.Name = name

                Try
                    sb.UsingRemote = ini_slingboxes.ReadBoolean("Player", "UsingRemote", False)
                Catch ex As Exception

                End Try

                Try
                    sb.Aspect = CType(ini_slingboxes.ReadInteger("Player", "Aspect", CInt(slingboxrelated.Enum_Aspect.Aspect_169)), slingboxrelated.Enum_Aspect)
                Catch
                    sb.Aspect = Enum_Aspect.Aspect_43
                End Try

                LoadSlingbox(sb)

                SetValidSlingboxName(sb.Name)
                c += 1
                ReDim Preserve Slingboxes(c)
                sb.ArrayNbr = c
                Slingboxes(c) = sb
                Dim LastSlingBox As String = Reg.GetValueString(CRegistry.RootKey.HKEY_CURRENT_USER, "Software\SlingFront", "ResumeLastSlingBox", "")
                If LCase(Replace(LastSlingBox, "-", "")) = LCase(Replace(sb.FinderID, "-", "")) Then
                    Slingbox_Current = sb
                End If
            Catch ex As Exception

            End Try
        Loop
        Do While InStr(s, buf, "<Device dbid=") > 0
            s = InStr(s, buf, "<Device dbid=") + 1
            Dim sb As New StructSlingboxInfo

            Dim s2 As Integer = s
            s2 = InStr(s, buf, " id=""")
            s2 = InStr(s2, buf, """") + 1
            e = InStr(s2, buf, """")
            If e > s2 Then
                sb.FinderID = Mid(buf, s2, e - s2)
                Dim id As String = sb.FinderID
                If Not InStr(id, "-") > 0 Then
                    Try
                        sb.FinderID = Mid(id, 1, 8) + "-" + Mid(id, 9, 4) + "-" + Mid(id, 13, 8) + "-" + Mid(id, 21, 4) + "-" + Mid(id, 25, 8)
                    Catch ex As Exception

                    End Try
                End If

                Dim FileName As String = GetSlingBoxFilename(sb)
                If FileName <> "" Then

                    Dim Path As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\SlingFront\SlingBoxes"
                    ini_slingboxes = New IniReader(Path & "\" & FileName & ".ini")

                    Try
                        sb.UsingRemote = ini_slingboxes.ReadBoolean("Player", "UsingRemote", False)
                    Catch ex As Exception

                    End Try

                    Try
                        sb.Aspect = CType(ini_slingboxes.ReadInteger("Player", "Aspect", CInt(slingboxrelated.Enum_Aspect.Aspect_169)), slingboxrelated.Enum_Aspect)
                    Catch
                        sb.Aspect = Enum_Aspect.Aspect_43
                    End Try

                    Try
                        sb.Encoding.Resolution = CType(ini_slingboxes.ReadInteger("Encoding", "Resolution", CInt(StreamVideoResolution.VideoResolutionAuto)), StreamVideoResolution)
                    Catch
                        sb.Encoding.Resolution = StreamVideoResolution.VideoResolutionAuto
                    End Try
                    Try
                        sb.Encoding.Quality = CType(ini_slingboxes.ReadInteger("Encoding", "Quality", CInt(StreamQuality.Auto)), StreamQuality)
                    Catch
                        sb.Encoding.Quality = StreamQuality.Auto
                    End Try
                    Try
                        sb.Encoding.Bitrate = CType(ini_slingboxes.ReadInteger("Encoding", "Bitrate", CInt(StreamBitrate.Auto)), StreamBitrate)
                    Catch
                        sb.Encoding.Bitrate = StreamBitrate.Auto
                    End Try
                End If
            End If
            sb.Proxy.Enabled = False
            s2 = InStr(s, buf, "password=""")
            s2 = InStr(s2, buf, """") + 1
            e = InStr(s2, buf, """")
            If e > s2 Then
                sb.Password = Mid(buf, s2, e - s2)

            End If

            s2 = InStr(s, buf, "username=""")
            s2 = InStr(s2, buf, """") + 1
            e = InStr(s2, buf, """")
            If e > s2 Then
                Dim user As String = Mid(buf, s2, e - s2)
                If user = "admin" Then
                    sb.AccountIsAdmin = True

                End If
            End If

            s2 = InStr(s, buf, "port=""")
            s2 = InStr(s2, buf, """") + 1
            e = InStr(s2, buf, """")
            If e > s2 Then
                sb.Port = CInt(Mid(buf, s2, e - s2))
            End If

            s2 = InStr(s, buf, "address=""")
            s2 = InStr(s2, buf, """") + 1
            e = InStr(s2, buf, """")
            If e > s2 Then
                sb.IP = Mid(buf, s2, e - s2)
            End If

            s2 = InStr(s, buf, "name=""")
            s2 = InStr(s2, buf, """") + 1
            e = InStr(s2, buf, """")
            If e > s2 Then
                sb.Name = Mid(buf, s2, e - s2)
            End If

            Try
                MainFormRef.Player.CurrentBox.FinderID = sb.FinderID
                If sb.AccountIsAdmin Then
                    MainFormRef.Player.CurrentBox.Username = "admin"
                Else
                    MainFormRef.Player.CurrentBox.Username = "guest"

                End If

                If Len(sb.Password) > 15 Then
                    If Mid(sb.Password, 1, 3) = "E1:" Then

                    End If

                End If

                MainFormRef.Player.CurrentBox.Password = sb.Password

                SetValidSlingboxName(sb.Name)
                c += 1
                ReDim Preserve Slingboxes(c)
                Slingboxes(c) = sb
                Dim LastSlingBox As String = Reg.GetValueString(CRegistry.RootKey.HKEY_CURRENT_USER, "Software\SlingFront", "ResumeLastSlingBox", "")
                If LCase(Replace(LastSlingBox, "-", "")) = LCase(Replace(sb.FinderID, "-", "")) Then
                    Slingbox_Current = sb
                End If

            Catch ex As Exception

            End Try
        Loop

    End Sub
    Public Function LoadSlingbox(ByRef S As slingboxrelated.StructSlingboxInfo) As Boolean

        Dim FileName As String = GetSlingBoxFilename(S)
        If FileName = "" Then Return False

        Dim Path As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\SlingFront\SlingBoxes"
        ini_slingboxes = New IniReader(Path & "\" & FileName & ".ini")

        If Not ini_slingboxes.ReadInteger("Ident", "Slingbox", 0) = 1 Then Return False

        Try
            S.Aspect = CType(ini_slingboxes.ReadInteger("Player", "Aspect", CInt(slingboxrelated.Enum_Aspect.Aspect_169)), slingboxrelated.Enum_Aspect)
        Catch
            S.Aspect = Enum_Aspect.Aspect_169
        End Try

        S.Proxy.Enabled = ini_slingboxes.ReadBoolean("Proxy", "Enabled", False)
        S.Proxy.Address = ini_slingboxes.ReadString("Proxy", "Address", "")
        S.Proxy.Port = ini_slingboxes.ReadInteger("Proxy", "Port", 0)

        S.Proxy.User = ini_slingboxes.ReadString("Proxy", "User", "")
        If ini_slingboxes.ReadString("Proxy", "Password", "") = "" Then
            S.Proxy.Password = ""
        Else
            S.Proxy.Password = Crypt.DecryptCode2(ini_slingboxes.ReadString("Proxy", "Password", ""))
        End If

        S.Encoding.Manual = ini_slingboxes.ReadBoolean("Encoding", "Manual", False)
        S.Encoding.AudioBitRate = ini_slingboxes.ReadInteger("Encoding", "AudioBitRate", 0)

        S.Encoding.IFRame = ini_slingboxes.ReadInteger("Encoding", "IRFrame", 5)

        Try
            S.Encoding.Resolution = CType(ini_slingboxes.ReadInteger("Encoding", "Resolution", CInt(StreamVideoResolution.VideoResolutionAuto)), StreamVideoResolution)
        Catch
            S.Encoding.Resolution = StreamVideoResolution.VideoResolutionAuto
        End Try
        Try
            S.Encoding.Quality = CType(ini_slingboxes.ReadInteger("Encoding", "Quality", CInt(StreamQuality.Auto)), StreamQuality)
        Catch
            S.Encoding.Quality = StreamQuality.Auto
        End Try
        Try
            S.Encoding.Bitrate = CType(ini_slingboxes.ReadInteger("Encoding", "Bitrate", CInt(StreamBitrate.Auto)), StreamBitrate)
        Catch
            S.Encoding.Bitrate = StreamBitrate.Auto
        End Try

        S.Encoding.Smoothing = ini_slingboxes.ReadInteger("Encoding", "Smoothing", -1)

        S.Encoding.VideoBitRate = ini_slingboxes.ReadInteger("Encoding", "VideoBitRate", 1024)

        S.Encoding.VideoFPS = ini_slingboxes.ReadInteger("Encoding", "VideoFPS", -1)

        SetValidIFrame(S.Encoding.IFRame)
        SetValidAudioBitRate(S.Encoding.AudioBitRate)
        SetValidVideoSmoothing(S.Encoding.Smoothing)
        SetValidVideoBitRate(S.Encoding.VideoBitRate)
        SetValidSlingboxName(S.Name)

        S.ChannelDigits = ini_slingboxes.ReadInteger("IR", "ChannelDigits", 1)
        If S.ChannelDigits < 1 Or S.ChannelDigits > 3 Then
            S.ChannelDigits = 1
        End If

        S.LastConnected = DateTime.Parse(ini_slingboxes.ReadString("General", "LastConnected", "01/01/1900 00:00:00"))

        Return True

    End Function

    Sub SetValidVideoBitRate(ByRef i As Integer)
        If i < 1024 / 4 OrElse i > 10000 Then
            i = 1024

        End If

        If CInt(i / 4) <> i / 4 Then
            i = 1024
        End If
    End Sub

    Sub SetValidSlingboxName(ByRef s As String)

    End Sub
    Sub SetValidIFrame(ByRef i As Integer)
        If i < 1 OrElse i > 40 Then
            i = 5

        End If
    End Sub
    Sub SetValidVideoSmoothing(ByRef i As Integer)
        If i < 0 OrElse i > 100 Then
            i = 50

        End If
    End Sub
    Sub SetValidAudioBitRate(ByRef i As Integer)
        Select Case i
            Case Is = 16, 20, 32, 40, 48, 64, 96
                Return
        End Select
        i = 48
    End Sub
    Public Function SaveSlingbox() As Boolean
        Return SaveSlingbox(Slingbox_Current)
    End Function

    Public Function SaveSlingbox(ByVal S As slingboxrelated.StructSlingboxInfo) As Boolean
        Dim FileName As String = GetSlingBoxFilename(S)
        If FileName = "" Then Return False
        Dim Path As String = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) & "\SlingFront\SlingBoxes"
        ini_slingboxes = New IniReader(Path & "\" & FileName & ".ini")

        SetValidIFrame(S.Encoding.IFRame)
        SetValidAudioBitRate(S.Encoding.AudioBitRate)
        SetValidVideoSmoothing(S.Encoding.Smoothing)
        SetValidVideoBitRate(S.Encoding.VideoBitRate)

        SetValidSlingboxName(S.Name)

        ini_slingboxes.Write("Player", "UsingRemote", S.UsingRemote)
        ini_slingboxes.Write("Ident", "SlingBox", 1)

        ini_slingboxes.Write("General", "Name", S.Name)
        ini_slingboxes.Write("General", "FinderID", S.FinderID)

        ini_slingboxes.Write("General", "IP", S.IP)
        ini_slingboxes.Write("General", "Port", S.Port)
        ini_slingboxes.Write("Account", "IsAdmin", S.AccountIsAdmin)

        ini_slingboxes.Write("Account", "User", S.User)
        ini_slingboxes.Write("Account", "Password", Crypt.EncryptCode1(S.Password))

        ini_slingboxes.Write("Player", "Aspect", S.Aspect)
        ini_slingboxes.Write("Proxy", "Enabled", S.Proxy.Enabled)
        ini_slingboxes.Write("Proxy", "Address", S.Proxy.Address)
        ini_slingboxes.Write("Proxy", "Port", S.Proxy.Port)
        ini_slingboxes.Write("Proxy", "User", S.Proxy.User)

        If S.Proxy.Password <> "" Then
            ini_slingboxes.Write("Proxy", "Password", Crypt.EncryptCode2(S.Proxy.Password))
        End If

        ini_slingboxes.Write("Encoding", "Manual", S.Encoding.Manual)
        ini_slingboxes.Write("Encoding", "AudioBitRate", S.Encoding.AudioBitRate)
        ini_slingboxes.Write("Encoding", "IRFrame", S.Encoding.IFRame)
        ini_slingboxes.Write("Encoding", "Quality", S.Encoding.Quality)
        ini_slingboxes.Write("Encoding", "Resolution", S.Encoding.Resolution)
        ini_slingboxes.Write("Encoding", "Smoothing", S.Encoding.Smoothing)
        ini_slingboxes.Write("Encoding", "VideoBitRate", S.Encoding.VideoBitRate)
        ini_slingboxes.Write("Encoding", "VideoFPS", S.Encoding.VideoFPS)
        ini_slingboxes.Write("Encoding", "Bitrate", S.Encoding.Bitrate)

        ini_slingboxes.Write("IR", "Digits", S.IRDigits)
        ini_slingboxes.Write("IR", "Codes", S.IRCodes)

        ini_slingboxes.Write("IR", "ChannelDigits", S.ChannelDigits)

        ini_slingboxes.Write("General", "LastConnected", S.LastConnected.ToString())

        Return True
    End Function
    Function LoadAllSlingBoxes() As Boolean

    End Function
    Function InitBass(ByVal frm As Form) As Boolean
        If Bass_HasInit Then Return Bass_InitSuccess
        If Not IO.File.Exists(Application.StartupPath & "\bass.dll") Then
            Bass_HasInit = True
            Bass_InitSuccess = False
            Return False
        End If
        If Bass.BASS_Init(1, 44100, 0, frm.Handle.ToInt32, 0) = Bass.BassBool.BassFalse Then
            Bass_HasInit = True
            Bass_InitSuccess = False
            Return False

        End If
        Bass.BASS_SetConfig(Bass.BassConfigOptions.BASS_CONFIG_GVOL_STREAM, 40 * 100)
        Bass_HasInit = True
        Bass_InitSuccess = True
        Return True
    End Function

    Public Sub SaveSettings()
        ini_internal.Write("General", "CurrentSlingBox", GetSlingBoxFilename(Slingbox_Current))

        SaveSlingbox(Slingbox_Current)

    End Sub

    Public Sub CreateSlingBoxMenu()
        If Menu_Main IsNot Nothing Then
            Menu_Main.Dispose()
        End If
        LoadSlingBoxes2()
        frmmain.Refresh()
        Dim d As MenuItem.Struct_Menu_DisplayProperties
        d.BorderColor = Color.White
        d.BorderSize = 1
        d.FontColor = Color.White
        d.SelectedColor = Color.FromArgb(150, 0, 0, 255)
        d.UnSelectedColor = Color.FromArgb(150, 0, 0, 100)
        d.Size.Width = frmmain.ClientRectangle.Width - CInt((frmmain.ClientRectangle.Width / 6) * 2)
        d.Size.Height = CInt((frmmain.ClientRectangle.Height / 14) * 1)
        frmmain.Refresh()
        If Menu_Main Is Nothing Then
            Menu_Main = New Menu(New Rectangle(CInt(frmmain.ClientRectangle.Width / 7), CInt(frmmain.ClientRectangle.Height / 8), frmmain.ClientRectangle.Width - CInt((frmmain.ClientRectangle.Width / 7) * 2), CInt(frmmain.ClientRectangle.Height - ((frmmain.ClientRectangle.Height / 10) * 2))), frmmain, frmonscreen, Menu.Orientation.Horizontal, "Arial", d)
        End If

        Dim MI As SlingFront.MenuItem.Struct_MenuItem
        MI.Type = MenuItem.MenuType_Type.Button
        MI.ButtonType = MenuItem.MenuType_Button.Button_Slingbox
        Dim count As Integer = UBound(Slingboxes) + 1
        If count > 0 Then
            If count > 5 Then
                count = 5
            End If
            Dim done(count) As Boolean
            For i As Integer = 0 To count - 1
                Dim j As Integer = -1
                For k As Integer = 0 To count - 1
                    If done(k) = False Then
                        If j = -1 Then
                            j = k
                        ElseIf Slingboxes(k).LastConnected > Slingboxes(j).LastConnected Then
                            j = k
                        End If
                    End If
                Next
                If j > -1 Then
                    MI.Cmd.CMD_Integer = j
                    MI.Text = Slingboxes(j).Name
                    Menu_Main.AddMenu(MI)
                    done(j) = True
                End If
            Next
        End If

        MI.ButtonType = MenuItem.MenuType_Button.Button_MainMenu
        MI.AddSpace = True
        MI.Text = "Back"
        Menu_Main.AddMenu(MI)

        Menu_Main.DrawMenus(True, True, frmmain)
        frmmain.Refresh()

    End Sub

    Public Sub CreateEditSlingBoxMenu()
        If Menu_Main IsNot Nothing Then
            Menu_Main.Dispose()
        End If
        LoadSlingBoxes2()
        frmmain.Refresh()
        Dim d As MenuItem.Struct_Menu_DisplayProperties
        d.BorderColor = Color.White
        d.BorderSize = 1
        d.FontColor = Color.White
        d.SelectedColor = Color.FromArgb(150, 0, 0, 255)
        d.UnSelectedColor = Color.FromArgb(150, 0, 0, 100)
        d.Size.Width = frmmain.ClientRectangle.Width - CInt((frmmain.ClientRectangle.Width / 6) * 2)
        d.Size.Height = CInt((frmmain.ClientRectangle.Height / 14) * 1)
        frmmain.Refresh()
        If Menu_Main Is Nothing Then
            Menu_Main = New Menu(New Rectangle(CInt(frmmain.ClientRectangle.Width / 7), CInt(frmmain.ClientRectangle.Height / 8), frmmain.ClientRectangle.Width - CInt((frmmain.ClientRectangle.Width / 7) * 2), CInt(frmmain.ClientRectangle.Height - ((frmmain.ClientRectangle.Height / 10) * 2))), frmmain, frmonscreen, Menu.Orientation.Horizontal, "Arial", d)
        End If

        Dim MI As SlingFront.MenuItem.Struct_MenuItem
        MI.Type = MenuItem.MenuType_Type.Button
        MI.ButtonType = MenuItem.MenuType_Button.Button_Menu_EditSlingbox
        For i As Integer = 0 To UBound(Slingboxes)

            MI.Cmd.CMD_Integer = i
            MI.Cmd.CMD_Text = Slingboxes(i).FinderID
            MI.Text = Slingboxes(i).Name
            Menu_Main.AddMenu(MI)

            If i > 5 Then Exit For
        Next

        MI.ButtonType = MenuItem.MenuType_Button.Button_MainMenu
        MI.AddSpace = True
        MI.Text = "Back"
        Menu_Main.AddMenu(MI)
        Menu_Main.DrawMenus(True, True, frmmain)
        frmmain.Refresh()

    End Sub

    Public Sub CreateRemoteMenu()
        If Menu_Main IsNot Nothing Then
            Menu_Main.Dispose()
        End If
        LoadSlingBoxes2()
        frmmain.Refresh()
        Dim d As MenuItem.Struct_Menu_DisplayProperties
        d.BorderColor = Color.White
        d.BorderSize = 1
        d.FontColor = Color.White
        d.SelectedColor = Color.FromArgb(150, 0, 0, 255)
        d.UnSelectedColor = Color.FromArgb(150, 0, 0, 100)
        d.Size.Width = frmmain.ClientRectangle.Width - CInt((frmmain.ClientRectangle.Width / 6) * 2)
        d.Size.Height = CInt((frmmain.ClientRectangle.Height / 14) * 1)
        frmmain.Refresh()
        If Menu_Main Is Nothing Then
            Menu_Main = New Menu(New Rectangle(CInt(frmmain.ClientRectangle.Width / 7), CInt(frmmain.ClientRectangle.Height / 8), frmmain.ClientRectangle.Width - CInt((frmmain.ClientRectangle.Width / 7) * 2), CInt(frmmain.ClientRectangle.Height - ((frmmain.ClientRectangle.Height / 10) * 2))), frmmain, frmonscreen, Menu.Orientation.Horizontal, "Arial", d)
        End If

        Dim MI As SlingFront.MenuItem.Struct_MenuItem
        MI.Type = MenuItem.MenuType_Type.Button
        MI.ButtonType = MenuItem.MenuType_Button.Button_IRCode
        MainFormRef.Player.RemoteControl.Show = 1
        For i As Integer = 0 To UBound(Slingboxes)
            MI.Cmd.CMD_Integer = i
            MI.Text = Slingboxes(i).Name
            Menu_Main.AddMenu(MI)

        Next
        Menu_Main.DrawMenus(True, True, frmmain)
        frmmain.Refresh()

    End Sub

    Public Sub CreateSettingsMenu()
        If Menu_Main IsNot Nothing Then
            Menu_Main.Dispose()
        End If

        frmmain.Refresh()
        Dim d As MenuItem.Struct_Menu_DisplayProperties
        d.BorderColor = Color.White
        d.BorderSize = 1
        d.FontColor = Color.White
        d.SelectedColor = Color.FromArgb(150, 0, 0, 255)
        d.UnSelectedColor = Color.FromArgb(150, 0, 0, 100)
        d.Size.Width = frmmain.ClientRectangle.Width - CInt((frmmain.ClientRectangle.Width / 6) * 2)
        d.Size.Height = CInt((frmmain.ClientRectangle.Height / 14) * 1)
        frmmain.Refresh()
        If Menu_Main Is Nothing Then
            Menu_Main = New Menu(New Rectangle(CInt(frmmain.ClientRectangle.Width / 7), CInt(frmmain.ClientRectangle.Height / 8), frmmain.ClientRectangle.Width - CInt((frmmain.ClientRectangle.Width / 7) * 2), CInt(frmmain.ClientRectangle.Height - ((frmmain.ClientRectangle.Height / 10) * 2))), frmmain, frmonscreen, Menu.Orientation.Horizontal, "Arial", d)
        End If

        Dim MI As SlingFront.MenuItem.Struct_MenuItem

        MI.Text = "Edit Slingboxes"

        MI.ButtonType = MenuItem.MenuType_Button.Button_Menu_EditSlingboxes
        Menu_Main.AddMenu(MI)

        MI.Type = MenuItem.MenuType_Type.Button
        MI.ButtonType = MenuItem.MenuType_Button.Button_Menu_Keyboard_Controls

        MI.Text = "Keyboard Controls"
        Menu_Main.AddMenu(MI)

        MI.ButtonType = MenuItem.MenuType_Button.Button_Menu_Account

        MI.Text = "Change Account"
        Menu_Main.AddMenu(MI)
        MI.ButtonType = MenuItem.MenuType_Button.Button_Menu_ProxySettings

        MI.Text = "Proxy Server"
        Menu_Main.AddMenu(MI)

        MI.ButtonType = MenuItem.MenuType_Button.Button_Menu_GeneralSettings

        MI.Text = "General Settings"
        Menu_Main.AddMenu(MI)

        MI.ButtonType = MenuItem.MenuType_Button.Button_MainMenu
        MI.AddSpace = True
        MI.Text = "Back"
        Menu_Main.AddMenu(MI)
        Menu_Main.DrawMenus(True, True, frmmain)
        frmmain.Refresh()

    End Sub
    Public Sub CreateMainMenu()
        MainFormRef.TimerFadeOut.Enabled = False
        If Menu_Main IsNot Nothing Then
            Menu_Main.Dispose()
        End If
        frmmain.Update()

        Dim d As MenuItem.Struct_Menu_DisplayProperties
        d.BorderColor = Color.White
        d.BorderSize = 1
        d.FontColor = Color.White
        d.SelectedColor = Color.FromArgb(150, 0, 0, 255)
        d.UnSelectedColor = Color.FromArgb(150, 0, 0, 100)
        d.Size.Width = frmmain.ClientRectangle.Width - CInt((frmmain.ClientRectangle.Width / 6) * 2)
        d.Size.Height = CInt((frmmain.ClientRectangle.Height / 14) * 1)
        If Menu_Main Is Nothing Then
            Menu_Main = New Menu(New Rectangle(CInt(frmmain.ClientRectangle.Width / 7), CInt(frmmain.ClientRectangle.Height / 8), frmmain.ClientRectangle.Width - CInt((frmmain.ClientRectangle.Width / 7) * 2), CInt(frmmain.ClientRectangle.Height - ((frmmain.ClientRectangle.Height / 10) * 2))), frmmain, frmonscreen, Menu.Orientation.Horizontal, "Arial", d)
        End If

        Dim MI As SlingFront.MenuItem.Struct_MenuItem
        MI.Type = MenuItem.MenuType_Type.Button

        MI.Text = "Reconnect to " + Slingbox_Current.Name
        MI.ButtonType = MenuItem.MenuType_Button.Button_PlayPause
        If IsPlaying() Then

            MI.Text = "Return to TV"
        End If

        If Slingbox_Current.FinderID <> "" Then
            Menu_Main.AddMenu(MI)
        End If

        MI.Text = "View Slingboxes"
        MI.ButtonType = MenuItem.MenuType_Button.Button_Menu_Slingboxes
        Menu_Main.AddMenu(MI)

        MI.ButtonType = MenuItem.MenuType_Button.Button_Menu_Remote
        MI.Text = "Show/Hide Remote Control"
        If IsPlaying() Then
            Menu_Main.AddMenu(MI)
        End If
        MI.ButtonType = MenuItem.MenuType_Button.Button_Menu_Settings
        MI.Text = "Settings"

        Menu_Main.AddMenu(MI)

        MI.ButtonType = MenuItem.MenuType_Button.Button_Exit
        MI.AddSpace = True
        MI.Text = "Exit"
        Menu_Main.AddMenu(MI)
    End Sub
    Public Declare Sub mouse_event Lib "user32" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As Integer)

    Public Const MOUSEEVENTF_MOVE As Integer = &H1
    Public Const MOUSEEVENTF_LEFTDOWN As Integer = &H2
    Public Const MOUSEEVENTF_LEFTUP As Integer = &H4
    Public Const MOUSEEVENTF_RIGHTDOWN As Integer = &H8
    Public Const MOUSEEVENTF_RIGHTUP As Integer = &H10
    Public Const MOUSEEVENTF_MIDDLEDOWN As Integer = &H20
    Public Const MOUSEEVENTF_MIDDLEUP As Integer = &H40
    Public Const MOUSEEVENTF_WHEEL As Integer = &H800
    Public Const MOUSEEVENTF_ABSOLUTE As Integer = &H8000
    Function IsPlaying() As Boolean

        Try
            If MainFormRef.Player.StatusCode = 4 Or MainFormRef.Player.StatusCode = 5 Or LCase(MainFormRef.Player.status) = "no video signal" Then
                Return True
            Else

            End If
        Catch ex As Exception

        End Try

        Return False
    End Function

    Const ENUM_CURRENT_SETTINGS As Integer = -1
    Const CDS_UPDATEREGISTRY As Integer = &H1
    Const CDS_TEST As Long = &H2

    Const CCDEVICENAME As Integer = 32
    Const CCFORMNAME As Integer = 32

    Const DISP_CHANGE_SUCCESSFUL As Integer = 0
    Const DISP_CHANGE_RESTART As Integer = 1
    Const DISP_CHANGE_FAILED As Integer = -1

    Private Declare Function EnumDisplaySettings Lib "user32" Alias "EnumDisplaySettingsA" (ByVal lpszDeviceName As Integer, ByVal iModeNum As Integer, ByRef lpDevMode As DEVMODE) As Integer
    Private Declare Function ChangeDisplaySettings Lib "user32" Alias "ChangeDisplaySettingsA" (ByRef DEVMODE As DEVMODE, ByVal flags As Integer) As Integer

    <StructLayout(LayoutKind.Sequential)> Public Structure DEVMODE
        <MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst:=CCDEVICENAME)> Public dmDeviceName As String
        Public dmSpecVersion As Short
        Public dmDriverVersion As Short
        Public dmSize As Short
        Public dmDriverExtra As Short
        Public dmFields As Integer
        Public dmOrientation As Short
        Public dmPaperSize As Short
        Public dmPaperLength As Short
        Public dmPaperWidth As Short
        Public dmScale As Short
        Public dmCopies As Short
        Public dmDefaultSource As Short
        Public dmPrintQuality As Short
        Public dmColor As Short
        Public dmDuplex As Short
        Public dmYResolution As Short
        Public dmTTOption As Short
        Public dmCollate As Short
        <MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst:=CCFORMNAME)> Public dmFormName As String
        Public dmUnusedPadding As Short
        Public dmBitsPerPel As Short
        Public dmPelsWidth As Integer
        Public dmPelsHeight As Integer
        Public dmDisplayFlags As Integer
        Public dmDisplayFrequency As Integer
    End Structure
    Public Function SetRefreshRate(ByVal RR As Integer) As Boolean
        Dim DevM As DEVMODE
        '  Static OldRate As Integer
        DevM.dmDeviceName = New [String](New Char(32) {})
        DevM.dmFormName = New [String](New Char(32) {})
        DevM.dmSize = CShort(Marshal.SizeOf(GetType(DEVMODE)))
        Dim cnt As Integer = 0
        Dim BsTr As String = ""
        Dim curfreq As Integer = 60
        If 0 <> EnumDisplaySettings(Nothing, -1, DevM) Then

            If DevM.dmDisplayFrequency <> RR Then
                DevM.dmDisplayFrequency = RR

                Dim lret As Long = ChangeDisplaySettings(DevM, 0)
                If (DISP_CHANGE_SUCCESSFUL <> lret) Then
                    Return False

                Else
                    Return True
                End If
            Else
                Return True
            End If
        End If
    End Function
    Public Function SetResolution(ByVal Width As Integer, ByVal height As Integer) As Boolean
        Return SetResolution(Width, height, 0)
    End Function
    Public Function SetResolution(ByVal Width As Integer, ByVal height As Integer, ByVal RR As Integer) As Boolean
        Dim DevM As DEVMODE
        'Static OldRate As Integer
        DevM.dmDeviceName = New [String](New Char(32) {})
        DevM.dmFormName = New [String](New Char(32) {})
        DevM.dmSize = CShort(Marshal.SizeOf(GetType(DEVMODE)))
        Dim cnt As Integer = 0
        Dim BsTr As String = ""
        Dim curfreq As Integer = 60

        Do While 0 <> EnumDisplaySettings(Nothing, cnt, DevM)

            cnt += 1

            If DevM.dmPelsWidth = Width And DevM.dmPelsHeight = height And (DevM.dmDisplayFrequency = RR OrElse RR = 0) And DevM.dmBitsPerPel = 32 Then

                Dim lret As Long = ChangeDisplaySettings(DevM, 0)
                If (DISP_CHANGE_SUCCESSFUL <> lret) Then
                    Return False

                Else

                    Return True
                End If
            End If
        Loop
        Return False
    End Function
    Public Function GetDisplayDeviceMode() As DEVMODE
        Dim DevM As DEVMODE

        DevM.dmDeviceName = New [String](New Char(32) {})
        DevM.dmFormName = New [String](New Char(32) {})
        DevM.dmSize = CShort(Marshal.SizeOf(GetType(DEVMODE)))

        EnumDisplaySettings(Nothing, -1, DevM)
        Return DevM

    End Function
    Public Function SetDisplayDeviceMode(ByVal DevM As DEVMODE) As Boolean

        Dim lret As Long = ChangeDisplaySettings(DevM, 0)
        If (DISP_CHANGE_SUCCESSFUL <> lret) Then
            Return False

        Else
            Return True
        End If

    End Function
    Public Function GetRefreshRate() As Integer
        Dim DevM As DEVMODE

        DevM.dmDeviceName = New [String](New Char(32) {})
        DevM.dmFormName = New [String](New Char(32) {})
        DevM.dmSize = CShort(Marshal.SizeOf(GetType(DEVMODE)))
        Dim cnt As Integer = 0
        Dim BsTr As String = ""
        Dim curfreq As Integer = 60
        If 0 <> EnumDisplaySettings(Nothing, -1, DevM) Then

            Dim lret As Long = ChangeDisplaySettings(DevM, 0)
            If (DISP_CHANGE_SUCCESSFUL <> lret) Then
                Return 0

            Else
                Return DevM.dmDisplayFrequency
            End If
        End If

    End Function

    Public Function ConvertFrameRateToAvailableRefreshRate(ByVal fr As Integer) As Integer

        Dim RR As Integer = ConvertFrameRatetoRefreshRate(fr)
        Dim DevM As DEVMODE

        DevM.dmDeviceName = New [String](New Char(32) {})
        DevM.dmFormName = New [String](New Char(32) {})
        DevM.dmSize = CShort(Marshal.SizeOf(GetType(DEVMODE)))
        Dim cnt As Integer = 0
        Dim BsTr As String = ""
        Dim curfreq As Integer = 60
        If 0 <> EnumDisplaySettings(Nothing, -1, DevM) Then

            curfreq = DevM.dmDisplayFrequency
        Else

        End If
        If curfreq <= 0 Then Return -1

        If RR = curfreq Then Return -1

        Return -1
    End Function
    Public Function ConvertFrameRateToAvailableRefreshRate(ByVal w As Integer, ByVal h As Integer, ByVal fr As Integer) As Integer()

#If DebugOn Then
            Log("ConvertFrameRateToAvailableRefreshRate")
#End If
        Dim res(2) As Integer
        res(0) = 0
        res(1) = 0
        res(2) = 0

        Dim RR As Integer = ConvertFrameRatetoRefreshRate(fr)
        Dim DevM As DEVMODE
        Dim curDevM As DEVMODE

        DevM.dmDeviceName = New [String](New Char(32) {})
        DevM.dmFormName = New [String](New Char(32) {})
        DevM.dmSize = CShort(Marshal.SizeOf(GetType(DEVMODE)))

        curDevM.dmDeviceName = New [String](New Char(32) {})
        curDevM.dmFormName = New [String](New Char(32) {})
        curDevM.dmSize = CShort(Marshal.SizeOf(GetType(DEVMODE)))
        Dim cnt As Integer = 0
        Dim BsTr As String = ""
        Dim curfreq As Integer = 60
        If 0 <> EnumDisplaySettings(Nothing, -1, DevM) Then

            curDevM = DevM
        Else

        End If
        If curfreq <= 0 Then Return res

        Do While 0 <> EnumDisplaySettings(Nothing, cnt, DevM)

            cnt += 1
            If DevM.dmPelsWidth = w And (DevM.dmPelsHeight = h OrElse DevM.dmPelsHeight > h) And (DevM.dmDisplayFrequency = RR OrElse RR = 0) Then
                If DevM.dmPelsWidth <> curDevM.dmPelsWidth Or DevM.dmPelsHeight <> curDevM.dmPelsHeight Or DevM.dmDisplayFrequency <> curDevM.dmDisplayFrequency Then
                    res(0) = DevM.dmPelsWidth
                    res(1) = DevM.dmPelsHeight
                    If RR > 0 Then
                        res(2) = RR
                    End If

                End If

                Return res
            End If
        Loop
        cnt = 0
        Do While 0 <> EnumDisplaySettings(Nothing, cnt, DevM)

            cnt += 1
            If DevM.dmPelsWidth = w And (DevM.dmPelsHeight = h OrElse DevM.dmPelsHeight > h) And (DevM.dmDisplayFrequency = RR OrElse RR = 0) Then
                If DevM.dmPelsWidth <> curDevM.dmPelsWidth Or DevM.dmPelsHeight <> curDevM.dmPelsHeight Or DevM.dmDisplayFrequency <> curDevM.dmDisplayFrequency Then
                    res(0) = DevM.dmPelsWidth
                    res(1) = DevM.dmPelsHeight
                    If RR > 0 Then
                        res(2) = RR
                    End If

                End If

                Return res
            End If
        Loop
        cnt = 0
        If RR > 0 Then
            Do While 0 <> EnumDisplaySettings(Nothing, cnt, DevM)

                cnt += 1

                If DevM.dmPelsWidth = curDevM.dmPelsWidth And DevM.dmPelsHeight = curDevM.dmPelsHeight And DevM.dmDisplayFrequency = RR Then

                    res(2) = RR
                    Return res
                End If

            Loop

        End If
        Return res
    End Function
    Public Function ConvertFrameRatetoRefreshRate(ByVal fr As Integer) As Integer
        Select Case fr
            Case Is = 23, 24
                Return 24
            Case Is = 25, 50
                Return 50
            Case Is = 29, 30, 60
                Return 60
            Case Is = 70
                Return 70
            Case Is = 75
                Return 75
            Case Else
                Dim DevM As DEVMODE

                DevM.dmDeviceName = New [String](New Char(32) {})
                DevM.dmFormName = New [String](New Char(32) {})
                DevM.dmSize = CShort(Marshal.SizeOf(GetType(DEVMODE)))
                Dim cnt As Integer = 0
                Dim BsTr As String = ""
                Dim curfreq As Integer = 60
                If 0 <> EnumDisplaySettings(Nothing, -1, DevM) Then

                    curfreq = DevM.dmDisplayFrequency
                Else

                End If
                If curfreq <= 0 Then curfreq = 60

                Return curfreq

        End Select

    End Function

    Public Function GetAvailableResolutions() As String()
        Dim Resolutions(-1) As String
        Dim DevM As DEVMODE

        DevM.dmDeviceName = New [String](New Char(32) {})
        DevM.dmFormName = New [String](New Char(32) {})
        DevM.dmSize = CShort(Marshal.SizeOf(GetType(DEVMODE)))
        Dim cnt As Integer = 0
        Dim BsTr As String = ""
        Do While 0 <> EnumDisplaySettings(Nothing, cnt, DevM)
            ReDim Preserve Resolutions(cnt)
            Resolutions(cnt) = DevM.dmPelsWidth.ToString + "x" + DevM.dmPelsHeight.ToString + "x" + DevM.dmDisplayFrequency.ToString
            BsTr += Resolutions(cnt) + vbNewLine
            cnt += 1

        Loop

        MsgBox(BsTr)
        Return Resolutions

    End Function

    Public Function IsXBMCRunning() As Boolean
        For Each p As Process In Process.GetProcesses
            If LCase(p.ProcessName) = "xbmc.exe" OrElse LCase(p.ProcessName) = "xbmc" Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Declare Function SetForegroundWindow Lib "user32" Alias "SetForegroundWindow" (ByVal hwnd As IntPtr) As Long
End Module