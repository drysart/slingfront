Public Class frmonscreen

    Private Sub TimerFadeIn_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub frmonscreen_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub frmonscreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmonscreen_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        For Each ctl As Control In Me.Controls
            If InStr(LCase(ctl.GetType.ToString), "panel") > 0 Then
                For Each ctl2 As Control In ctl.Controls
                    Dim t As String = LCase(ctl2.GetType.ToString)
                    If InStr(t, "combo") > 0 OrElse InStr(t, "text") > 0 OrElse InStr(t, "label") > 0 OrElse InStr(t, "button") > 0 Then
                        Try
                            ctl2.Font.Dispose()
                            ctl2.Font = New Font(New FontFamily("Arial"), CSng(Me.ClientRectangle.Width / 42), FontStyle.Regular, GraphicsUnit.Pixel)
                        Catch ex As Exception

                        End Try

                    End If
                Next
            Else
                Dim t As String = LCase(ctl.GetType.ToString)
                If InStr(t, "combo") > 0 OrElse InStr(t, "text") > 0 OrElse InStr(t, "label") > 0 OrElse InStr(t, "button") > 0 Then
                    Try
                        ctl.Font.Dispose()
                        ctl.Font = New Font(New FontFamily("Arial"), CSng(Me.ClientRectangle.Width / 42), FontStyle.Regular, GraphicsUnit.Pixel)
                    Catch ex As Exception

                    End Try

                End If
            End If

        Next

        Panel1.Height = CInt(Me.Height / 1.5)
        Panel2.Height = CInt(Me.Height / 1.5)
        Panel3.Height = CInt(Me.Height / 1.5)
        Panel4.Height = CInt(Me.Height / 1.5)
        Panel5.Height = CInt(Me.Height / 1.5)

        Me.lblGeneralSettings.Left = 0
        Me.lblMusic.Left = 0
        Me.lblStartup.Left = 0
        Me.lblRefreshRate.Left = 0
        Me.ComboMusic.Left = Me.lblRefreshRate.Left + Me.lblRefreshRate.Width
        Me.ComboStartup.Left = Me.lblRefreshRate.Left + Me.lblRefreshRate.Width
        Me.ComboRefreshRate.Left = Me.lblRefreshRate.Left + Me.lblRefreshRate.Width
        Me.lblMusic.Top = Me.lblGeneralSettings.Top + Me.lblGeneralSettings.Height

        Me.ComboMusic.Top = Me.lblMusic.Top
        Me.ComboMusic.Width = CInt(Me.Width / 2.5)
        Me.ComboStartup.Width = CInt(Me.Width / 2.5)
        Me.ComboRefreshRate.Width = CInt(Me.Width / 2.5)

        Me.lblStartup.Top = Me.ComboMusic.Top + ComboMusic.Height + 20
        Me.ComboStartup.Top = Me.ComboMusic.Top + ComboMusic.Height + 20
        Me.lblRefreshRate.Top = Me.ComboStartup.Top + ComboStartup.Height + 20
        Me.ComboRefreshRate.Top = Me.ComboStartup.Top + ComboStartup.Height + 20

        Me.cmdGeneralSettingsBack.Left = Me.ComboMusic.Left
        Me.cmdGeneralSettingsBack.Top = Me.ComboRefreshRate.Top + Me.ComboRefreshRate.Height + 20
        Me.lblControl.Left = 0
        Me.lblKey.Left = 0
        Me.lblControl.Top = Me.lblKeyBoardControls.Top + Me.lblKeyBoardControls.Height + 20
        Me.lblKey.Top = Me.lblControl.Top + ComboControl.Height
        Me.txtKey.Top = lblKey.Top
        Me.txtKey.Left = Me.lblControl.Left + Me.lblControl.Width
        Me.ComboControl.Left = Me.txtKey.Left
        Me.ComboControl.Width = CInt(Me.Width / 3)
        Me.txtKey.Width = CInt(Me.Width / 3)
        Me.cmdEditKey.Top = Me.txtKey.Top
        Me.cmdEditKey.Left = Me.txtKey.Left + Me.txtKey.Width + 20
        Me.cmdKeyboardBack.Top = Me.lblKey.Top + Me.lblKey.Height
        Me.cmdKeyboardBack.Left = Me.txtKey.Left

        Me.lblSlingBoxSettings.Left = 0
        Me.lblSlingBoxSettings.Top = 0

        Me.lblQuality.Left = 0
        Me.lblQuality.Top = Me.lblSlingBoxSettings.Top + Me.lblSlingBoxSettings.Height
        Me.ComboQuality.Top = Me.lblQuality.Top
        Me.ComboQuality.Width = CInt(Me.Width / 2.5)
        Me.ComboQuality.Left = Me.lblQuality.Left + Me.lblChannelDigits.Width

        Me.lblBitrate.Left = 0
        Me.lblBitrate.Top = Me.ComboQuality.Top + Me.ComboQuality.Height + 20
        Me.ComboBitrate.Left = Me.ComboQuality.Left
        Me.ComboBitrate.Top = Me.lblBitrate.Top
        Me.ComboBitrate.Width = CInt(Me.Width / 2.5)

        Me.lblChannelDigits.Left = 0
        Me.lblChannelDigits.Top = Me.ComboBitrate.Top + Me.ComboBitrate.Height + 20
        Me.ComboChannelDigits.Left = Me.ComboBitrate.Left
        Me.ComboChannelDigits.Top = Me.lblChannelDigits.Top
        Me.ComboChannelDigits.Width = CInt(Me.Width / 2.5)

        Me.cmdEditSlingBoxBack.Left = Me.ComboChannelDigits.Left
        Me.cmdEditSlingBoxBack.Top = Me.ComboChannelDigits.Top + Me.ComboChannelDigits.Height + 20

        Me.txtPassword.Width = CInt(Me.ClientRectangle.Width / 2)
        Me.txtEmail.Width = CInt(Me.ClientRectangle.Width / 2)
        Me.lblemail.Left = 0
        Me.lblpassword.Left = 0
        Me.lblemail.Top = Me.lbllogin.Top + Me.lbllogin.Height
        Me.lblpassword.Top = Me.lblemail.Top + Me.lblemail.Height
        Me.txtEmail.Left = Me.lblpassword.Left + Me.lblpassword.Width
        Me.txtEmail.Top = Me.lblemail.Top
        Me.txtPassword.Left = Me.lblpassword.Left + Me.lblpassword.Width
        Me.txtPassword.Top = Me.lblpassword.Top
        Me.cmdConnect.Left = Me.txtPassword.Left
        Me.cmdConnect.Top = Me.lblpassword.Top + Me.lblpassword.Height
        Me.lblletter.Left = cmdConnect.Left
        Me.lblletter.Top = cmdConnect.Top + cmdConnect.Height + 20
        Me.cmdLoginBack.Top = Me.cmdConnect.Top
        Me.cmdLoginBack.Left = Me.cmdConnect.Left + Me.cmdConnect.Width + 20
        ProxyLabelAddress.Left = 0
        ProxyLabelType.Left = 0
        ProxyLblPassword.Left = 0
        ProxyLblPort.Left = 0
        ProxyLblUser.Left = 0

        ProxyTxtAddress.Left = ProxyLblUser.Left + ProxyLblUser.Width
        ProxytxtPassword.Left = ProxyTxtAddress.Left
        ProxyTxtAddress.Left = ProxyTxtAddress.Left
        ProxyTxtPort.Left = ProxyTxtAddress.Left
        ProxytxtUserName.Left = ProxyTxtAddress.Left
        ProxycmdBack.Left = ProxyTxtAddress.Left
        ProxyComboType.Left = ProxyTxtAddress.Left

        ProxyLabelType.Top = lblProxySettings.Top + lblProxySettings.Height
        ProxyComboType.Top = ProxyLabelType.Top

        ProxyLabelAddress.Top = ProxyComboType.Top + ProxyComboType.Height + 20
        ProxyTxtAddress.Top = ProxyLabelAddress.Top

        ProxyLblPort.Top = ProxyLabelAddress.Top + ProxyLabelAddress.Height
        ProxyTxtPort.Top = ProxyLblPort.Top

        ProxyLblUser.Top = ProxyLblPort.Top + ProxyLblPort.Height
        ProxytxtUserName.Top = ProxyLblUser.Top

        ProxyLblPassword.Top = ProxyLblUser.Top + ProxyLblUser.Height
        ProxytxtPassword.Top = ProxyLblPassword.Top
        ProxycmdBack.Top = ProxyLblPassword.Top + ProxyLblPassword.Height

        ProxyComboType.Width = CInt(Me.ClientRectangle.Width / 2)
        ProxyTxtAddress.Width = CInt(Me.ClientRectangle.Width / 2)
        ProxytxtPassword.Width = CInt(Me.ClientRectangle.Width / 2)
        ProxyTxtPort.Width = CInt(Me.ClientRectangle.Width / 3)
        ProxytxtUserName.Width = CInt(Me.ClientRectangle.Width / 2)

        Try
            Logo.Height = CInt(Me.ClientRectangle.Height / 9)
            Vol.Width = CInt(Me.ClientRectangle.Width / 5)
            Vol.Left = Me.ClientRectangle.Width - Vol.Width - CInt((Me.ClientRectangle.Height / 9) / 4)
            Vol.Height = CInt((Me.ClientRectangle.Height / 9) / 2)
            Vol.Top = CInt((Me.ClientRectangle.Height - CInt(Me.ClientRectangle.Height / 9)) + ((Me.ClientRectangle.Height / 9) / 4))
        Catch
        End Try

    End Sub

    Function r(ByVal S As String, ByVal n As Integer) As String
        Return Microsoft.VisualBasic.Right(S, n)
    End Function

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Logo.Click

    End Sub

    Public Sub New()

        InitializeComponent()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub cmdConnect_Click(sender As Object, e As EventArgs) Handles cmdConnect.Click
        ini_config.Write("Login", "Email", Crypt.EncryptCode4(txtEmail.Text))
        If txtPassword.Text = "" Then
            ini_config.Write("Login", "Password", txtPassword.Text)
        Else
            ini_config.Write("Login", "Password", Crypt.EncryptCode3(txtPassword.Text))
        End If

        lblStatus.Text = "Attempting Login"
        Application.DoEvents()
        LoadSlingBoxes2(True)
        If Not LoggedIn Then
            lblStatus.Text = "Login Failed"
        Else
            Panel1.Visible = False
            lblStatus.Text = "Login Success"
            Application.DoEvents()
            MainFormRef.StartMainMenu()
            Menu_Main.DrawMenus(True, True, MainFormRef)

        End If
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub ComboControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboControl.SelectedIndexChanged
        Dim Ini_Keys As New IniReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\SlingFront\Keyboard_Mappings_v2.ini")
        Me.txtKey.Text = Ini_Keys.ReadKeyCode("Key_Codes", Me.ComboControl.Items(Me.ComboControl.SelectedIndex).ToString, Keys.None).ToString
        Me.txtKey.SelectionStart = 0
        Me.txtKey.SelectionLength = 0

    End Sub

    Private Sub cmdEditKey_Click(sender As Object, e As EventArgs) Handles cmdEditKey.Click
        Me.txtKey.Text = "Press Key Now"
        Me.txtKey.SelectionStart = 0
        Me.txtKey.SelectionLength = 0
        Dim Ini_Keys As New IniReader(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\SlingFront\Keyboard_Mappings_v2.ini")
        Me.ComboControl.Enabled = False
        Me.cmdEditKey.Enabled = False
        MainFormRef.Timer20ml.Enabled = False
        Me.cmdKeyboardBack.Enabled = False
        Do While 1 = 1
            For i As Integer = 1 To 255
                If GetAsyncKeyState(i) = -32767 Then
                    For k As Integer = 1 To Me.ComboControl.Items.Count()
                        If Ini_Keys.ReadKeyCode("Key_Codes", Me.ComboControl.Items(k - 1).ToString, Keys.None) = CType(i, Keys) Then
                            Ini_Keys.Write("Key_Codes", Me.ComboControl.Items(k - 1).ToString, Keys.None)
                        End If
                    Next
                    Ini_Keys.Write("Key_Codes", Me.ComboControl.Items(Me.ComboControl.SelectedIndex).ToString, i)
                    Me.txtKey.Text = Ini_Keys.ReadKeyCode("Key_Codes", Me.ComboControl.Items(Me.ComboControl.SelectedIndex).ToString, Keys.None).ToString
                    Me.txtKey.SelectionStart = 0
                    Me.txtKey.SelectionLength = 0
                    Keyboard.SetDefaultKeys()
                    Me.ComboControl.Enabled = True
                    Me.cmdEditKey.Enabled = True
                    MainFormRef.Timer20ml.Enabled = True
                    Me.cmdKeyboardBack.Enabled = True
                    Return
                End If
                Application.DoEvents()
            Next
        Loop
    End Sub

    Private Sub cmdKeyboardBack_Click(sender As Object, e As EventArgs) Handles cmdKeyboardBack.Click
        Panel2.Visible = False
        MainFormRef.StartMainMenu()
    End Sub

    Private Sub cmdLoginBack_Click(sender As Object, e As EventArgs) Handles cmdLoginBack.Click
        Panel1.Visible = False
        MainFormRef.StartMainMenu()
    End Sub
    Public Sub SavePRoxySettings()
        ini_config.Write("Proxy", "Type", ProxyComboType.SelectedIndex)
        ini_config.Write("Proxy", "Address", ProxyTxtAddress.Text)
        ini_config.Write("Proxy", "Password", Crypt.EncryptCode2(ProxytxtPassword.Text))
        ini_config.Write("Proxy", "User", Crypt.EncryptCode2(ProxytxtUserName.Text))
        ini_config.Write("Proxy", "Port", ProxyTxtPort.Text)

    End Sub
    Private Sub ProxyComboType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ProxyComboType.SelectedIndexChanged

    End Sub

    Private Sub ComboControl_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboControl.KeyDown
        If ComboControl.Focused And Not ComboControl.DroppedDown Then
            If e.KeyCode = Keys.Enter Then
                ComboControl.DroppedDown = True
                e.Handled = True
            ElseIf e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ProxyComboType_KeyDown(sender As Object, e As KeyEventArgs) Handles ProxyComboType.KeyDown
        If ProxyComboType.Focused And Not ProxyComboType.DroppedDown Then
            If e.KeyCode = Keys.Enter Then
                ProxyComboType.DroppedDown = True
                e.Handled = True
            ElseIf e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ComboStartup_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboStartup.KeyDown
        If ComboStartup.Focused And Not ComboStartup.DroppedDown Then
            If e.KeyCode = Keys.Enter Then
                ComboStartup.DroppedDown = True
                e.Handled = True
            ElseIf e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ComboMusic_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboMusic.KeyDown
        If ComboMusic.Focused And Not ComboMusic.DroppedDown Then
            If e.KeyCode = Keys.Enter Then
                ComboMusic.DroppedDown = True
                e.Handled = True
            ElseIf e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ComboRefreshRate_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboRefreshRate.KeyDown
        If ComboRefreshRate.Focused And Not ComboRefreshRate.DroppedDown Then
            If e.KeyCode = Keys.Enter Then
                ComboRefreshRate.DroppedDown = True
                e.Handled = True
            ElseIf e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ComboChannelDigits_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboChannelDigits.KeyDown
        If ComboChannelDigits.Focused And Not ComboChannelDigits.DroppedDown Then
            If e.KeyCode = Keys.Enter Then
                ComboChannelDigits.DroppedDown = True
                e.Handled = True
            ElseIf e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ComboQuality_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboQuality.KeyDown
        If ComboQuality.Focused And Not ComboQuality.DroppedDown Then
            If e.KeyCode = Keys.Enter Then
                ComboQuality.DroppedDown = True
                e.Handled = True
            ElseIf e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ComboBitrate_KeyDown(sender As Object, e As KeyEventArgs) Handles ComboBitrate.KeyDown
        If ComboBitrate.Focused And Not ComboBitrate.DroppedDown Then
            If e.KeyCode = Keys.Enter Then
                ComboBitrate.DroppedDown = True
                e.Handled = True
            ElseIf e.KeyCode = Keys.Up Or e.KeyCode = Keys.Down Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub ProxytxtUserName_TextChanged(sender As Object, e As EventArgs) Handles ProxytxtUserName.TextChanged

    End Sub

    Private Sub ProxytxtPassword_TextChanged(sender As Object, e As EventArgs) Handles ProxytxtPassword.TextChanged

    End Sub

    Private Sub ProxyTxtAddress_TextChanged(sender As Object, e As EventArgs) Handles ProxyTxtAddress.TextChanged

    End Sub

    Private Sub ProxyTxtPort_TextChanged(sender As Object, e As EventArgs) Handles ProxyTxtPort.TextChanged
        If ProxyTxtPort.Text = "" Then Return
        Dim BStr As String
        Dim sel As Integer = ProxyTxtPort.SelectionStart
        For i As Integer = 1 To Len(ProxyTxtPort.Text)
            If Mid(ProxyTxtPort.Text, i, 1) <> "" Then
                Try
                    Dim int As Integer = CInt(Mid(ProxyTxtPort.Text, i, 1))
                    BStr += int.ToString
                Catch ex As Exception

                End Try
            End If

        Next

        If BStr <> ProxyTxtPort.Text Then
            ProxyTxtPort.Text = BStr
            ProxyTxtPort.SelectionStart = sel - 1
        End If
    End Sub

    Private Sub ProxycmdBack_Click(sender As Object, e As EventArgs) Handles ProxycmdBack.Click
        SavePRoxySettings()
        Panel3.Visible = False
        MainFormRef.StartMainMenu()
    End Sub

    Private Sub ProxyTxtPort_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ProxyTxtPort.Validating

    End Sub

    Private Sub cmdGeneralSettingsBack_Click(sender As Object, e As EventArgs) Handles cmdGeneralSettingsBack.Click
        Panel4.Visible = False
        MainFormRef.StartMainMenu()
    End Sub

    Private Sub ComboMusic_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboMusic.SelectedIndexChanged
        If Me.Opacity > 0.3 Then
            ini_config.Write("General_Settings", "MenuMusic", ComboMusic.SelectedIndex)
            If ComboMusic.SelectedIndex = 0 Then

                MainFormRef.StartMusic()
            Else
                MainFormRef.StopMusic(False)
            End If

        End If

    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub ComboStartup_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboStartup.SelectedIndexChanged
        If Me.Opacity > 0.3 Then
            ini_config.Write("General_Settings", "OnStartup", ComboStartup.SelectedIndex)
        End If

    End Sub

    Private Sub ComboRefreshRate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboRefreshRate.SelectedIndexChanged
        If Me.Opacity > 0.3 Then
            ini_config.Write("General_Settings", "RefreshRate", ComboRefreshRate.SelectedIndex)
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles cmdEditSlingBoxBack.Click
        Panel5.Visible = False
        MainFormRef.StartMainMenu()
    End Sub

    Private Sub ComboChannelDigits_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboChannelDigits.SelectedIndexChanged
        If Me.Opacity > 0.3 Then
            Slingbox_Edit.ChannelDigits = ComboChannelDigits.SelectedIndex + 1
            For i As Integer = 0 To UBound(Slingboxes)
                If Slingboxes(i).FinderID = Slingbox_Edit.FinderID Then
                    Slingboxes(i) = Slingbox_Edit
                End If
            Next
            If Slingbox_Edit.FinderID = Slingbox_Current.FinderID Then
                If Slingbox_Current.HasConnected Then Slingbox_Edit.HasConnected = True
                Slingbox_Current = Slingbox_Edit
            End If
            SaveSlingbox(Slingbox_Edit)
        End If
    End Sub

    Private Sub ComboQuality_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboQuality.SelectedIndexChanged
        If Me.Opacity > 0.3 Then
            Slingbox_Edit.Encoding.Quality = CType(ComboQuality.SelectedIndex, StreamQuality)
            For i As Integer = 0 To UBound(Slingboxes)
                If Slingboxes(i).FinderID = Slingbox_Edit.FinderID Then
                    Slingboxes(i) = Slingbox_Edit
                End If
            Next
            If Slingbox_Edit.FinderID = Slingbox_Current.FinderID Then
                If Slingbox_Current.HasConnected Then Slingbox_Edit.HasConnected = True
                Slingbox_Current = Slingbox_Edit
            End If
            SaveSlingbox(Slingbox_Edit)
        End If
    End Sub

    Private Sub ComboBitrate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBitrate.SelectedIndexChanged
        If Me.Opacity > 0.3 Then
            Slingbox_Edit.Encoding.Bitrate = CType(ComboBitrate.SelectedIndex, StreamBitrate)
            For i As Integer = 0 To UBound(Slingboxes)
                If Slingboxes(i).FinderID = Slingbox_Edit.FinderID Then
                    Slingboxes(i) = Slingbox_Edit
                End If
            Next
            If Slingbox_Edit.FinderID = Slingbox_Current.FinderID Then
                If Slingbox_Current.HasConnected Then Slingbox_Edit.HasConnected = True
                Slingbox_Current = Slingbox_Edit
            End If
            SaveSlingbox(Slingbox_Edit)
        End If
    End Sub
End Class
