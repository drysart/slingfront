<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmonscreen
    Inherits System.Windows.Forms.Form


    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    Private components As System.ComponentModel.IContainer




    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmonscreen))
        Me.Logo = New System.Windows.Forms.PictureBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.Vol = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdLoginBack = New System.Windows.Forms.Button()
        Me.lblletter = New System.Windows.Forms.Label()
        Me.cmdConnect = New System.Windows.Forms.Button()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblpassword = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.lblemail = New System.Windows.Forms.Label()
        Me.lbllogin = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdKeyboardBack = New System.Windows.Forms.Button()
        Me.ComboControl = New System.Windows.Forms.ComboBox()
        Me.cmdEditKey = New System.Windows.Forms.Button()
        Me.txtKey = New System.Windows.Forms.TextBox()
        Me.lblKey = New System.Windows.Forms.Label()
        Me.lblControl = New System.Windows.Forms.Label()
        Me.lblKeyBoardControls = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ProxytxtPassword = New System.Windows.Forms.TextBox()
        Me.ProxyLblPassword = New System.Windows.Forms.Label()
        Me.ProxytxtUserName = New System.Windows.Forms.TextBox()
        Me.ProxyLblUser = New System.Windows.Forms.Label()
        Me.ProxyTxtPort = New System.Windows.Forms.TextBox()
        Me.ProxyLblPort = New System.Windows.Forms.Label()
        Me.ProxycmdBack = New System.Windows.Forms.Button()
        Me.ProxyComboType = New System.Windows.Forms.ComboBox()
        Me.ProxyTxtAddress = New System.Windows.Forms.TextBox()
        Me.ProxyLabelAddress = New System.Windows.Forms.Label()
        Me.ProxyLabelType = New System.Windows.Forms.Label()
        Me.lblProxySettings = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ComboStartup = New System.Windows.Forms.ComboBox()
        Me.lblStartup = New System.Windows.Forms.Label()
        Me.cmdGeneralSettingsBack = New System.Windows.Forms.Button()
        Me.ComboMusic = New System.Windows.Forms.ComboBox()
        Me.lblMusic = New System.Windows.Forms.Label()
        Me.lblGeneralSettings = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.ComboRefreshRate = New System.Windows.Forms.ComboBox()
        Me.lblRefreshRate = New System.Windows.Forms.Label()
        Me.ComboChannelDigits = New System.Windows.Forms.ComboBox()
        Me.lblChannelDigits = New System.Windows.Forms.Label()
        Me.cmdEditSlingBoxBack = New System.Windows.Forms.Button()
        Me.ComboQuality = New System.Windows.Forms.ComboBox()
        Me.lblQuality = New System.Windows.Forms.Label()
        Me.ComboBitrate = New System.Windows.Forms.ComboBox()
        Me.lblBitrate = New System.Windows.Forms.Label()
        Me.lblSlingBoxSettings = New System.Windows.Forms.Label()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Vol, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Logo
        '
        Me.Logo.BackColor = System.Drawing.Color.Transparent
        Me.Logo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Logo.Image = CType(resources.GetObject("Logo.Image"), System.Drawing.Image)
        Me.Logo.Location = New System.Drawing.Point(0, 551)
        Me.Logo.Name = "Logo"
        Me.Logo.Size = New System.Drawing.Size(875, 144)
        Me.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Logo.TabIndex = 1
        Me.Logo.TabStop = False
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(0, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Padding = New System.Windows.Forms.Padding(20, 20, 0, 0)
        Me.lblStatus.Size = New System.Drawing.Size(116, 52)
        Me.lblStatus.TabIndex = 2
        Me.lblStatus.Text = "Label1"
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblStatus.Visible = False
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.BackColor = System.Drawing.Color.Transparent
        Me.lblDate.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.ForeColor = System.Drawing.Color.White
        Me.lblDate.Location = New System.Drawing.Point(361, 0)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Padding = New System.Windows.Forms.Padding(20, 20, 0, 0)
        Me.lblDate.Size = New System.Drawing.Size(116, 52)
        Me.lblDate.TabIndex = 3
        Me.lblDate.Text = "Label1"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblDate.Visible = False
        '
        'Vol
        '
        Me.Vol.BackColor = System.Drawing.Color.Transparent
        Me.Vol.Location = New System.Drawing.Point(237, 88)
        Me.Vol.Name = "Vol"
        Me.Vol.Size = New System.Drawing.Size(150, 50)
        Me.Vol.TabIndex = 4
        Me.Vol.TabStop = False
        Me.Vol.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.cmdLoginBack)
        Me.Panel1.Controls.Add(Me.lblletter)
        Me.Panel1.Controls.Add(Me.cmdConnect)
        Me.Panel1.Controls.Add(Me.txtPassword)
        Me.Panel1.Controls.Add(Me.lblpassword)
        Me.Panel1.Controls.Add(Me.txtEmail)
        Me.Panel1.Controls.Add(Me.lblemail)
        Me.Panel1.Controls.Add(Me.lbllogin)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 464)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(875, 87)
        Me.Panel1.TabIndex = 5
        Me.Panel1.Visible = False
        '
        'cmdLoginBack
        '
        Me.cmdLoginBack.AutoSize = True
        Me.cmdLoginBack.FlatAppearance.BorderColor = System.Drawing.Color.Gold
        Me.cmdLoginBack.FlatAppearance.BorderSize = 3
        Me.cmdLoginBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdLoginBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdLoginBack.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLoginBack.ForeColor = System.Drawing.Color.White
        Me.cmdLoginBack.Location = New System.Drawing.Point(381, 109)
        Me.cmdLoginBack.Name = "cmdLoginBack"
        Me.cmdLoginBack.Size = New System.Drawing.Size(112, 47)
        Me.cmdLoginBack.TabIndex = 3
        Me.cmdLoginBack.Text = "Back"
        Me.cmdLoginBack.UseVisualStyleBackColor = True
        '
        'lblletter
        '
        Me.lblletter.AutoSize = True
        Me.lblletter.BackColor = System.Drawing.Color.Transparent
        Me.lblletter.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblletter.ForeColor = System.Drawing.Color.White
        Me.lblletter.Location = New System.Drawing.Point(284, 72)
        Me.lblletter.Name = "lblletter"
        Me.lblletter.Padding = New System.Windows.Forms.Padding(0, 20, 20, 20)
        Me.lblletter.Size = New System.Drawing.Size(517, 72)
        Me.lblletter.TabIndex = 7
        Me.lblletter.Text = "Press Channel Up/Down to select letter."
        Me.lblletter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdConnect
        '
        Me.cmdConnect.AutoSize = True
        Me.cmdConnect.FlatAppearance.BorderColor = System.Drawing.Color.Gold
        Me.cmdConnect.FlatAppearance.BorderSize = 3
        Me.cmdConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdConnect.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdConnect.ForeColor = System.Drawing.Color.White
        Me.cmdConnect.Location = New System.Drawing.Point(184, 198)
        Me.cmdConnect.Name = "cmdConnect"
        Me.cmdConnect.Size = New System.Drawing.Size(111, 47)
        Me.cmdConnect.TabIndex = 2
        Me.cmdConnect.Text = "Connect"
        Me.cmdConnect.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(184, 142)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(0)
        Me.txtPassword.MaxLength = 70
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(405, 38)
        Me.txtPassword.TabIndex = 1
        '
        'lblpassword
        '
        Me.lblpassword.AutoSize = True
        Me.lblpassword.BackColor = System.Drawing.Color.Transparent
        Me.lblpassword.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpassword.ForeColor = System.Drawing.Color.White
        Me.lblpassword.Location = New System.Drawing.Point(0, 142)
        Me.lblpassword.Name = "lblpassword"
        Me.lblpassword.Padding = New System.Windows.Forms.Padding(40, 0, 20, 20)
        Me.lblpassword.Size = New System.Drawing.Size(201, 52)
        Me.lblpassword.TabIndex = 6
        Me.lblpassword.Text = "Password:"
        Me.lblpassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(184, 90)
        Me.txtEmail.Margin = New System.Windows.Forms.Padding(0)
        Me.txtEmail.MaxLength = 70
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(405, 38)
        Me.txtEmail.TabIndex = 0
        '
        'lblemail
        '
        Me.lblemail.AutoSize = True
        Me.lblemail.BackColor = System.Drawing.Color.Transparent
        Me.lblemail.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblemail.ForeColor = System.Drawing.Color.White
        Me.lblemail.Location = New System.Drawing.Point(0, 90)
        Me.lblemail.Name = "lblemail"
        Me.lblemail.Padding = New System.Windows.Forms.Padding(40, 0, 20, 20)
        Me.lblemail.Size = New System.Drawing.Size(150, 52)
        Me.lblemail.TabIndex = 5
        Me.lblemail.Text = "Email:"
        Me.lblemail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbllogin
        '
        Me.lbllogin.AutoSize = True
        Me.lbllogin.BackColor = System.Drawing.Color.Transparent
        Me.lbllogin.Dock = System.Windows.Forms.DockStyle.Top
        Me.lbllogin.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllogin.ForeColor = System.Drawing.Color.Gold
        Me.lbllogin.Location = New System.Drawing.Point(0, 0)
        Me.lbllogin.Name = "lbllogin"
        Me.lbllogin.Padding = New System.Windows.Forms.Padding(20, 20, 0, 20)
        Me.lbllogin.Size = New System.Drawing.Size(278, 72)
        Me.lbllogin.TabIndex = 4
        Me.lbllogin.Text = "Slingbox.com Login:"
        Me.lbllogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.cmdKeyboardBack)
        Me.Panel2.Controls.Add(Me.ComboControl)
        Me.Panel2.Controls.Add(Me.cmdEditKey)
        Me.Panel2.Controls.Add(Me.txtKey)
        Me.Panel2.Controls.Add(Me.lblKey)
        Me.Panel2.Controls.Add(Me.lblControl)
        Me.Panel2.Controls.Add(Me.lblKeyBoardControls)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 407)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(875, 57)
        Me.Panel2.TabIndex = 6
        Me.Panel2.Visible = False
        '
        'cmdKeyboardBack
        '
        Me.cmdKeyboardBack.AutoSize = True
        Me.cmdKeyboardBack.FlatAppearance.BorderColor = System.Drawing.Color.Gold
        Me.cmdKeyboardBack.FlatAppearance.BorderSize = 3
        Me.cmdKeyboardBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdKeyboardBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdKeyboardBack.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdKeyboardBack.ForeColor = System.Drawing.Color.White
        Me.cmdKeyboardBack.Location = New System.Drawing.Point(381, 109)
        Me.cmdKeyboardBack.Name = "cmdKeyboardBack"
        Me.cmdKeyboardBack.Size = New System.Drawing.Size(112, 47)
        Me.cmdKeyboardBack.TabIndex = 3
        Me.cmdKeyboardBack.Text = "Back"
        Me.cmdKeyboardBack.UseVisualStyleBackColor = True
        '
        'ComboControl
        '
        Me.ComboControl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboControl.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboControl.FormattingEnabled = True
        Me.ComboControl.Location = New System.Drawing.Point(184, 96)
        Me.ComboControl.Name = "ComboControl"
        Me.ComboControl.Size = New System.Drawing.Size(121, 39)
        Me.ComboControl.TabIndex = 0
        '
        'cmdEditKey
        '
        Me.cmdEditKey.AutoSize = True
        Me.cmdEditKey.FlatAppearance.BorderColor = System.Drawing.Color.Gold
        Me.cmdEditKey.FlatAppearance.BorderSize = 3
        Me.cmdEditKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdEditKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdEditKey.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEditKey.ForeColor = System.Drawing.Color.White
        Me.cmdEditKey.Location = New System.Drawing.Point(184, 198)
        Me.cmdEditKey.Name = "cmdEditKey"
        Me.cmdEditKey.Size = New System.Drawing.Size(112, 47)
        Me.cmdEditKey.TabIndex = 2
        Me.cmdEditKey.Text = "Edit Key"
        Me.cmdEditKey.UseVisualStyleBackColor = True
        '
        'txtKey
        '
        Me.txtKey.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKey.Location = New System.Drawing.Point(184, 142)
        Me.txtKey.Margin = New System.Windows.Forms.Padding(0)
        Me.txtKey.MaxLength = 70
        Me.txtKey.Name = "txtKey"
        Me.txtKey.ReadOnly = True
        Me.txtKey.Size = New System.Drawing.Size(405, 38)
        Me.txtKey.TabIndex = 1
        '
        'lblKey
        '
        Me.lblKey.AutoSize = True
        Me.lblKey.BackColor = System.Drawing.Color.Transparent
        Me.lblKey.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKey.ForeColor = System.Drawing.Color.White
        Me.lblKey.Location = New System.Drawing.Point(0, 142)
        Me.lblKey.Name = "lblKey"
        Me.lblKey.Padding = New System.Windows.Forms.Padding(40, 0, 20, 20)
        Me.lblKey.Size = New System.Drawing.Size(130, 52)
        Me.lblKey.TabIndex = 6
        Me.lblKey.Text = "Key:"
        Me.lblKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblControl
        '
        Me.lblControl.AutoSize = True
        Me.lblControl.BackColor = System.Drawing.Color.Transparent
        Me.lblControl.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblControl.ForeColor = System.Drawing.Color.White
        Me.lblControl.Location = New System.Drawing.Point(0, 90)
        Me.lblControl.Name = "lblControl"
        Me.lblControl.Padding = New System.Windows.Forms.Padding(40, 0, 20, 20)
        Me.lblControl.Size = New System.Drawing.Size(170, 52)
        Me.lblControl.TabIndex = 5
        Me.lblControl.Text = "Control:"
        Me.lblControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblKeyBoardControls
        '
        Me.lblKeyBoardControls.AutoSize = True
        Me.lblKeyBoardControls.BackColor = System.Drawing.Color.Transparent
        Me.lblKeyBoardControls.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblKeyBoardControls.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKeyBoardControls.ForeColor = System.Drawing.Color.Gold
        Me.lblKeyBoardControls.Location = New System.Drawing.Point(0, 0)
        Me.lblKeyBoardControls.Name = "lblKeyBoardControls"
        Me.lblKeyBoardControls.Padding = New System.Windows.Forms.Padding(20, 20, 0, 20)
        Me.lblKeyBoardControls.Size = New System.Drawing.Size(268, 72)
        Me.lblKeyBoardControls.TabIndex = 4
        Me.lblKeyBoardControls.Text = "Keyboard Controls:"
        Me.lblKeyBoardControls.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.ProxytxtPassword)
        Me.Panel3.Controls.Add(Me.ProxyLblPassword)
        Me.Panel3.Controls.Add(Me.ProxytxtUserName)
        Me.Panel3.Controls.Add(Me.ProxyLblUser)
        Me.Panel3.Controls.Add(Me.ProxyTxtPort)
        Me.Panel3.Controls.Add(Me.ProxyLblPort)
        Me.Panel3.Controls.Add(Me.ProxycmdBack)
        Me.Panel3.Controls.Add(Me.ProxyComboType)
        Me.Panel3.Controls.Add(Me.ProxyTxtAddress)
        Me.Panel3.Controls.Add(Me.ProxyLabelAddress)
        Me.Panel3.Controls.Add(Me.ProxyLabelType)
        Me.Panel3.Controls.Add(Me.lblProxySettings)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 349)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(875, 58)
        Me.Panel3.TabIndex = 7
        Me.Panel3.Visible = False
        '
        'ProxytxtPassword
        '
        Me.ProxytxtPassword.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProxytxtPassword.Location = New System.Drawing.Point(548, 104)
        Me.ProxytxtPassword.Margin = New System.Windows.Forms.Padding(0)
        Me.ProxytxtPassword.MaxLength = 70
        Me.ProxytxtPassword.Name = "ProxytxtPassword"
        Me.ProxytxtPassword.Size = New System.Drawing.Size(405, 38)
        Me.ProxytxtPassword.TabIndex = 4
        '
        'ProxyLblPassword
        '
        Me.ProxyLblPassword.AutoSize = True
        Me.ProxyLblPassword.BackColor = System.Drawing.Color.Transparent
        Me.ProxyLblPassword.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProxyLblPassword.ForeColor = System.Drawing.Color.White
        Me.ProxyLblPassword.Location = New System.Drawing.Point(169, 127)
        Me.ProxyLblPassword.Name = "ProxyLblPassword"
        Me.ProxyLblPassword.Padding = New System.Windows.Forms.Padding(40, 0, 20, 20)
        Me.ProxyLblPassword.Size = New System.Drawing.Size(201, 52)
        Me.ProxyLblPassword.TabIndex = 11
        Me.ProxyLblPassword.Text = "Password:"
        Me.ProxyLblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProxytxtUserName
        '
        Me.ProxytxtUserName.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProxytxtUserName.Location = New System.Drawing.Point(486, 40)
        Me.ProxytxtUserName.Margin = New System.Windows.Forms.Padding(0)
        Me.ProxytxtUserName.MaxLength = 70
        Me.ProxytxtUserName.Name = "ProxytxtUserName"
        Me.ProxytxtUserName.Size = New System.Drawing.Size(405, 38)
        Me.ProxytxtUserName.TabIndex = 3
        '
        'ProxyLblUser
        '
        Me.ProxyLblUser.AutoSize = True
        Me.ProxyLblUser.BackColor = System.Drawing.Color.Transparent
        Me.ProxyLblUser.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProxyLblUser.ForeColor = System.Drawing.Color.White
        Me.ProxyLblUser.Location = New System.Drawing.Point(310, 18)
        Me.ProxyLblUser.Name = "ProxyLblUser"
        Me.ProxyLblUser.Padding = New System.Windows.Forms.Padding(40, 0, 20, 20)
        Me.ProxyLblUser.Size = New System.Drawing.Size(207, 52)
        Me.ProxyLblUser.TabIndex = 10
        Me.ProxyLblUser.Text = "Username:"
        Me.ProxyLblUser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProxyTxtPort
        '
        Me.ProxyTxtPort.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProxyTxtPort.Location = New System.Drawing.Point(337, 179)
        Me.ProxyTxtPort.Margin = New System.Windows.Forms.Padding(0)
        Me.ProxyTxtPort.MaxLength = 70
        Me.ProxyTxtPort.Name = "ProxyTxtPort"
        Me.ProxyTxtPort.Size = New System.Drawing.Size(405, 38)
        Me.ProxyTxtPort.TabIndex = 2
        '
        'ProxyLblPort
        '
        Me.ProxyLblPort.AutoSize = True
        Me.ProxyLblPort.BackColor = System.Drawing.Color.Transparent
        Me.ProxyLblPort.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProxyLblPort.ForeColor = System.Drawing.Color.White
        Me.ProxyLblPort.Location = New System.Drawing.Point(153, 179)
        Me.ProxyLblPort.Name = "ProxyLblPort"
        Me.ProxyLblPort.Padding = New System.Windows.Forms.Padding(40, 0, 20, 20)
        Me.ProxyLblPort.Size = New System.Drawing.Size(132, 52)
        Me.ProxyLblPort.TabIndex = 9
        Me.ProxyLblPort.Text = "Port:"
        Me.ProxyLblPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProxycmdBack
        '
        Me.ProxycmdBack.AutoSize = True
        Me.ProxycmdBack.FlatAppearance.BorderColor = System.Drawing.Color.Gold
        Me.ProxycmdBack.FlatAppearance.BorderSize = 3
        Me.ProxycmdBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ProxycmdBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ProxycmdBack.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProxycmdBack.ForeColor = System.Drawing.Color.White
        Me.ProxycmdBack.Location = New System.Drawing.Point(381, 109)
        Me.ProxycmdBack.Name = "ProxycmdBack"
        Me.ProxycmdBack.Size = New System.Drawing.Size(112, 47)
        Me.ProxycmdBack.TabIndex = 5
        Me.ProxycmdBack.Text = "Back"
        Me.ProxycmdBack.UseVisualStyleBackColor = True
        '
        'ProxyComboType
        '
        Me.ProxyComboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ProxyComboType.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProxyComboType.FormattingEnabled = True
        Me.ProxyComboType.Items.AddRange(New Object() {"Disabled", "Same as Web Browser", "Specified here"})
        Me.ProxyComboType.Location = New System.Drawing.Point(193, 84)
        Me.ProxyComboType.Name = "ProxyComboType"
        Me.ProxyComboType.Size = New System.Drawing.Size(121, 39)
        Me.ProxyComboType.TabIndex = 0
        '
        'ProxyTxtAddress
        '
        Me.ProxyTxtAddress.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProxyTxtAddress.Location = New System.Drawing.Point(408, 114)
        Me.ProxyTxtAddress.Margin = New System.Windows.Forms.Padding(0)
        Me.ProxyTxtAddress.MaxLength = 70
        Me.ProxyTxtAddress.Name = "ProxyTxtAddress"
        Me.ProxyTxtAddress.Size = New System.Drawing.Size(405, 38)
        Me.ProxyTxtAddress.TabIndex = 1
        '
        'ProxyLabelAddress
        '
        Me.ProxyLabelAddress.AutoSize = True
        Me.ProxyLabelAddress.BackColor = System.Drawing.Color.Transparent
        Me.ProxyLabelAddress.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProxyLabelAddress.ForeColor = System.Drawing.Color.White
        Me.ProxyLabelAddress.Location = New System.Drawing.Point(0, 142)
        Me.ProxyLabelAddress.Name = "ProxyLabelAddress"
        Me.ProxyLabelAddress.Padding = New System.Windows.Forms.Padding(40, 0, 20, 20)
        Me.ProxyLabelAddress.Size = New System.Drawing.Size(183, 52)
        Me.ProxyLabelAddress.TabIndex = 8
        Me.ProxyLabelAddress.Text = "Address:"
        Me.ProxyLabelAddress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProxyLabelType
        '
        Me.ProxyLabelType.AutoSize = True
        Me.ProxyLabelType.BackColor = System.Drawing.Color.Transparent
        Me.ProxyLabelType.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProxyLabelType.ForeColor = System.Drawing.Color.White
        Me.ProxyLabelType.Location = New System.Drawing.Point(0, 90)
        Me.ProxyLabelType.Name = "ProxyLabelType"
        Me.ProxyLabelType.Padding = New System.Windows.Forms.Padding(40, 0, 20, 20)
        Me.ProxyLabelType.Size = New System.Drawing.Size(142, 52)
        Me.ProxyLabelType.TabIndex = 7
        Me.ProxyLabelType.Text = "Type:"
        Me.ProxyLabelType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblProxySettings
        '
        Me.lblProxySettings.AutoSize = True
        Me.lblProxySettings.BackColor = System.Drawing.Color.Transparent
        Me.lblProxySettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblProxySettings.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProxySettings.ForeColor = System.Drawing.Color.Gold
        Me.lblProxySettings.Location = New System.Drawing.Point(0, 0)
        Me.lblProxySettings.Name = "lblProxySettings"
        Me.lblProxySettings.Padding = New System.Windows.Forms.Padding(20, 20, 0, 20)
        Me.lblProxySettings.Size = New System.Drawing.Size(304, 72)
        Me.lblProxySettings.TabIndex = 6
        Me.lblProxySettings.Text = "Proxy Server Settings:"
        Me.lblProxySettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.ComboStartup)
        Me.Panel4.Controls.Add(Me.lblStartup)
        Me.Panel4.Controls.Add(Me.ComboRefreshRate)
        Me.Panel4.Controls.Add(Me.lblRefreshRate)
        Me.Panel4.Controls.Add(Me.cmdGeneralSettingsBack)
        Me.Panel4.Controls.Add(Me.ComboMusic)
        Me.Panel4.Controls.Add(Me.lblMusic)
        Me.Panel4.Controls.Add(Me.lblGeneralSettings)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New System.Drawing.Point(0, 282)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(875, 67)
        Me.Panel4.TabIndex = 8
        Me.Panel4.Visible = False
        '
        'ComboStartup
        '
        Me.ComboStartup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboStartup.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboStartup.FormattingEnabled = True
        Me.ComboStartup.Items.AddRange(New Object() {"Resume Last SlingBox", "Nothing"})
        Me.ComboStartup.Location = New System.Drawing.Point(371, 189)
        Me.ComboStartup.Name = "ComboStartup"
        Me.ComboStartup.Size = New System.Drawing.Size(121, 39)
        Me.ComboStartup.TabIndex = 1
        '
        'lblStartup
        '
        Me.lblStartup.AutoSize = True
        Me.lblStartup.BackColor = System.Drawing.Color.Transparent
        Me.lblStartup.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStartup.ForeColor = System.Drawing.Color.White
        Me.lblStartup.Location = New System.Drawing.Point(187, 183)
        Me.lblStartup.Name = "lblStartup"
        Me.lblStartup.Padding = New System.Windows.Forms.Padding(40, 0, 20, 20)
        Me.lblStartup.Size = New System.Drawing.Size(215, 52)
        Me.lblStartup.TabIndex = 6
        Me.lblStartup.Text = "On Startup:"
        Me.lblStartup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboRefreshRate
        '
        Me.ComboRefreshRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboRefreshRate.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboRefreshRate.FormattingEnabled = True
        Me.ComboRefreshRate.Items.AddRange(New Object() {"Don't Change", "Match To Video"})
        Me.ComboRefreshRate.Location = New System.Drawing.Point(371, 189)
        Me.ComboRefreshRate.Name = "ComboRefreshRate"
        Me.ComboRefreshRate.Size = New System.Drawing.Size(121, 39)
        Me.ComboRefreshRate.TabIndex = 2
        '
        'lblRefreshRate
        '
        Me.lblRefreshRate.AutoSize = True
        Me.lblRefreshRate.BackColor = System.Drawing.Color.Transparent
        Me.lblRefreshRate.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRefreshRate.ForeColor = System.Drawing.Color.White
        Me.lblRefreshRate.Location = New System.Drawing.Point(187, 183)
        Me.lblRefreshRate.Name = "lblRefreshRate"
        Me.lblRefreshRate.Padding = New System.Windows.Forms.Padding(40, 0, 20, 20)
        Me.lblRefreshRate.Size = New System.Drawing.Size(215, 52)
        Me.lblRefreshRate.TabIndex = 7
        Me.lblRefreshRate.Text = "Refresh Rate:"
        Me.lblRefreshRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdGeneralSettingsBack
        '
        Me.cmdGeneralSettingsBack.AutoSize = True
        Me.cmdGeneralSettingsBack.FlatAppearance.BorderColor = System.Drawing.Color.Gold
        Me.cmdGeneralSettingsBack.FlatAppearance.BorderSize = 3
        Me.cmdGeneralSettingsBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdGeneralSettingsBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdGeneralSettingsBack.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGeneralSettingsBack.ForeColor = System.Drawing.Color.White
        Me.cmdGeneralSettingsBack.Location = New System.Drawing.Point(381, 109)
        Me.cmdGeneralSettingsBack.Name = "cmdGeneralSettingsBack"
        Me.cmdGeneralSettingsBack.Size = New System.Drawing.Size(112, 47)
        Me.cmdGeneralSettingsBack.TabIndex = 3
        Me.cmdGeneralSettingsBack.Text = "Back"
        Me.cmdGeneralSettingsBack.UseVisualStyleBackColor = True
        '
        'ComboMusic
        '
        Me.ComboMusic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboMusic.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboMusic.FormattingEnabled = True
        Me.ComboMusic.Items.AddRange(New Object() {"Enabled", "Disabled"})
        Me.ComboMusic.Location = New System.Drawing.Point(184, 96)
        Me.ComboMusic.Name = "ComboMusic"
        Me.ComboMusic.Size = New System.Drawing.Size(121, 39)
        Me.ComboMusic.TabIndex = 0
        '
        'lblMusic
        '
        Me.lblMusic.AutoSize = True
        Me.lblMusic.BackColor = System.Drawing.Color.Transparent
        Me.lblMusic.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMusic.ForeColor = System.Drawing.Color.White
        Me.lblMusic.Location = New System.Drawing.Point(0, 90)
        Me.lblMusic.Name = "lblMusic"
        Me.lblMusic.Padding = New System.Windows.Forms.Padding(40, 0, 20, 20)
        Me.lblMusic.Size = New System.Drawing.Size(231, 52)
        Me.lblMusic.TabIndex = 5
        Me.lblMusic.Text = "Menu Music:"
        Me.lblMusic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblGeneralSettings
        '
        Me.lblGeneralSettings.AutoSize = True
        Me.lblGeneralSettings.BackColor = System.Drawing.Color.Transparent
        Me.lblGeneralSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblGeneralSettings.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGeneralSettings.ForeColor = System.Drawing.Color.Gold
        Me.lblGeneralSettings.Location = New System.Drawing.Point(0, 0)
        Me.lblGeneralSettings.Name = "lblGeneralSettings"
        Me.lblGeneralSettings.Padding = New System.Windows.Forms.Padding(20, 20, 0, 20)
        Me.lblGeneralSettings.Size = New System.Drawing.Size(246, 72)
        Me.lblGeneralSettings.TabIndex = 4
        Me.lblGeneralSettings.Text = "General Settings:"
        Me.lblGeneralSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.ComboChannelDigits)
        Me.Panel5.Controls.Add(Me.lblChannelDigits)
        Me.Panel5.Controls.Add(Me.cmdEditSlingBoxBack)
        Me.Panel5.Controls.Add(Me.ComboQuality)
        Me.Panel5.Controls.Add(Me.lblQuality)
        Me.Panel5.Controls.Add(Me.ComboBitrate)
        Me.Panel5.Controls.Add(Me.lblBitrate)
        Me.Panel5.Controls.Add(Me.lblSlingBoxSettings)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(0, 69)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(875, 213)
        Me.Panel5.TabIndex = 9
        Me.Panel5.Visible = False
        '
        'ComboChannelDigits
        '
        Me.ComboChannelDigits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboChannelDigits.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboChannelDigits.FormattingEnabled = True
        Me.ComboChannelDigits.Location = New System.Drawing.Point(371, 189)
        Me.ComboChannelDigits.Name = "ComboChannelDigits"
        Me.ComboChannelDigits.Size = New System.Drawing.Size(121, 39)
        Me.ComboChannelDigits.TabIndex = 2
        '
        'lblChannelDigits
        '
        Me.lblChannelDigits.AutoSize = True
        Me.lblChannelDigits.BackColor = System.Drawing.Color.Transparent
        Me.lblChannelDigits.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblChannelDigits.ForeColor = System.Drawing.Color.White
        Me.lblChannelDigits.Location = New System.Drawing.Point(187, 183)
        Me.lblChannelDigits.Name = "lblChannelDigits"
        Me.lblChannelDigits.Padding = New System.Windows.Forms.Padding(40, 0, 20, 20)
        Me.lblChannelDigits.Size = New System.Drawing.Size(134, 52)
        Me.lblChannelDigits.TabIndex = 7
        Me.lblChannelDigits.Text = "Channel Digits:"
        Me.lblChannelDigits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdEditSlingBoxBack
        '
        Me.cmdEditSlingBoxBack.AutoSize = True
        Me.cmdEditSlingBoxBack.FlatAppearance.BorderColor = System.Drawing.Color.Gold
        Me.cmdEditSlingBoxBack.FlatAppearance.BorderSize = 3
        Me.cmdEditSlingBoxBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.cmdEditSlingBoxBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdEditSlingBoxBack.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEditSlingBoxBack.ForeColor = System.Drawing.Color.White
        Me.cmdEditSlingBoxBack.Location = New System.Drawing.Point(381, 109)
        Me.cmdEditSlingBoxBack.Name = "cmdEditSlingBoxBack"
        Me.cmdEditSlingBoxBack.Size = New System.Drawing.Size(112, 47)
        Me.cmdEditSlingBoxBack.TabIndex = 3
        Me.cmdEditSlingBoxBack.Text = "Back"
        Me.cmdEditSlingBoxBack.UseVisualStyleBackColor = True
        '
        'ComboQuality
        '
        Me.ComboQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboQuality.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboQuality.FormattingEnabled = True
        Me.ComboQuality.Location = New System.Drawing.Point(184, 96)
        Me.ComboQuality.Name = "ComboQuality"
        Me.ComboQuality.Size = New System.Drawing.Size(252, 39)
        Me.ComboQuality.TabIndex = 0
        '
        'lblQuality
        '
        Me.lblQuality.AutoSize = True
        Me.lblQuality.BackColor = System.Drawing.Color.Transparent
        Me.lblQuality.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuality.ForeColor = System.Drawing.Color.White
        Me.lblQuality.Location = New System.Drawing.Point(0, 90)
        Me.lblQuality.Name = "lblQuality"
        Me.lblQuality.Padding = New System.Windows.Forms.Padding(40, 0, 20, 20)
        Me.lblQuality.Size = New System.Drawing.Size(211, 52)
        Me.lblQuality.TabIndex = 5
        Me.lblQuality.Text = "Quality:"
        Me.lblQuality.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboBitrate
        '
        Me.ComboBitrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBitrate.Font = New System.Drawing.Font("Arial Narrow", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBitrate.FormattingEnabled = True
        Me.ComboBitrate.Location = New System.Drawing.Point(184, 96)
        Me.ComboBitrate.Name = "ComboBitrate"
        Me.ComboBitrate.Size = New System.Drawing.Size(252, 39)
        Me.ComboBitrate.TabIndex = 1
        '
        'lblBitrate
        '
        Me.lblBitrate.AutoSize = True
        Me.lblBitrate.BackColor = System.Drawing.Color.Transparent
        Me.lblBitrate.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBitrate.ForeColor = System.Drawing.Color.White
        Me.lblBitrate.Location = New System.Drawing.Point(0, 90)
        Me.lblBitrate.Name = "lblBitrate"
        Me.lblBitrate.Padding = New System.Windows.Forms.Padding(40, 0, 20, 20)
        Me.lblBitrate.Size = New System.Drawing.Size(211, 52)
        Me.lblBitrate.TabIndex = 6
        Me.lblBitrate.Text = "Bitrate:"
        Me.lblBitrate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSlingBoxSettings
        '
        Me.lblSlingBoxSettings.AutoSize = True
        Me.lblSlingBoxSettings.BackColor = System.Drawing.Color.Transparent
        Me.lblSlingBoxSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblSlingBoxSettings.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSlingBoxSettings.ForeColor = System.Drawing.Color.Gold
        Me.lblSlingBoxSettings.Location = New System.Drawing.Point(0, 0)
        Me.lblSlingBoxSettings.Name = "lblSlingBoxSettings"
        Me.lblSlingBoxSettings.Padding = New System.Windows.Forms.Padding(20, 20, 0, 20)
        Me.lblSlingBoxSettings.Size = New System.Drawing.Size(255, 72)
        Me.lblSlingBoxSettings.TabIndex = 4
        Me.lblSlingBoxSettings.Text = "SlingBox Settings:"
        Me.lblSlingBoxSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmonscreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(875, 695)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Vol)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.Logo)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmonscreen"
        Me.Opacity = 0.01R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmonscreen"
        Me.TopMost = True
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Vol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Logo As System.Windows.Forms.PictureBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents Vol As System.Windows.Forms.PictureBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdConnect As System.Windows.Forms.Button
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblpassword As System.Windows.Forms.Label
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents lblemail As System.Windows.Forms.Label
    Friend WithEvents lbllogin As System.Windows.Forms.Label
    Friend WithEvents lblletter As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ComboControl As System.Windows.Forms.ComboBox
    Friend WithEvents cmdEditKey As System.Windows.Forms.Button
    Friend WithEvents txtKey As System.Windows.Forms.TextBox
    Friend WithEvents lblKey As System.Windows.Forms.Label
    Friend WithEvents lblControl As System.Windows.Forms.Label
    Friend WithEvents lblKeyBoardControls As System.Windows.Forms.Label
    Friend WithEvents cmdLoginBack As System.Windows.Forms.Button
    Friend WithEvents cmdKeyboardBack As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ProxytxtPassword As System.Windows.Forms.TextBox
    Friend WithEvents ProxyLblPassword As System.Windows.Forms.Label
    Friend WithEvents ProxytxtUserName As System.Windows.Forms.TextBox
    Friend WithEvents ProxyLblUser As System.Windows.Forms.Label
    Friend WithEvents ProxyTxtPort As System.Windows.Forms.TextBox
    Friend WithEvents ProxyLblPort As System.Windows.Forms.Label
    Friend WithEvents ProxycmdBack As System.Windows.Forms.Button
    Friend WithEvents ProxyComboType As System.Windows.Forms.ComboBox
    Friend WithEvents ProxyTxtAddress As System.Windows.Forms.TextBox
    Friend WithEvents ProxyLabelAddress As System.Windows.Forms.Label
    Friend WithEvents ProxyLabelType As System.Windows.Forms.Label
    Friend WithEvents lblProxySettings As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents cmdGeneralSettingsBack As System.Windows.Forms.Button
    Friend WithEvents ComboMusic As System.Windows.Forms.ComboBox
    Friend WithEvents lblMusic As System.Windows.Forms.Label
    Friend WithEvents lblGeneralSettings As System.Windows.Forms.Label
    Friend WithEvents ComboStartup As System.Windows.Forms.ComboBox
    Friend WithEvents lblStartup As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents ComboRefreshRate As System.Windows.Forms.ComboBox
    Friend WithEvents lblRefreshRate As System.Windows.Forms.Label
    Friend WithEvents ComboChannelDigits As System.Windows.Forms.ComboBox
    Friend WithEvents lblChannelDigits As System.Windows.Forms.Label
    Friend WithEvents cmdEditSlingBoxBack As System.Windows.Forms.Button
    Friend WithEvents ComboQuality As System.Windows.Forms.ComboBox
    Friend WithEvents lblQuality As System.Windows.Forms.Label
    Friend WithEvents ComboBitrate As System.Windows.Forms.ComboBox
    Friend WithEvents lblBitrate As System.Windows.Forms.Label
    Friend WithEvents lblSlingBoxSettings As System.Windows.Forms.Label
End Class
