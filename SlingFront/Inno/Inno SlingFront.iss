; Script generated by the Inno Setup Script Wizard.
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

[Setup]
; NOTE: The value of AppId uniquely identifies this application.
; Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{AABD511C-3B36-42CE-B208-49FC7E2BCE09}
AppName=SlingFront
AppVersion=1.6
;AppVerName=SingFront 1
AppPublisher=Spesoft
AppPublisherURL=http://www.spesoft.com/
AppSupportURL=http://www.spesoft.com/
AppUpdatesURL=http://www.spesoft.com/
DefaultDirName={pf}\SlingFront
DefaultGroupName=SlingFront
LicenseFile=gpl.txt
OutputDir=.\
OutputBaseFilename=SlingFrontSetup
Compression=lzma/ultra
SolidCompression=true
InternalCompressLevel=ultra
WizardImageFile=MicrosoftClassic15.bmp
MinVersion=0,6.0.6000
RestartIfNeededByRun=false
DisableDirPage=true
DisableProgramGroupPage=true

[Languages]
Name: english; MessagesFile: compiler:Default.isl

[Tasks]
Name: desktopicon; Description: {cm:CreateDesktopIcon}; GroupDescription: {cm:AdditionalIcons}; Flags: unchecked

[Files]
Source: ..\bin\Release\SlingFront.exe; DestDir: {app}; Flags: ignoreversion
Source: ..\bin\Release\bass.dll; DestDir: {app}; Flags: ignoreversion
Source: ..\bin\Release\AxInterop.SlingPlayerAXLib.dll; DestDir: {app}; Flags: ignoreversion
Source: ..\bin\Release\Interop.SlingPlayerAXLib.dll; DestDir: {app}; Flags: ignoreversion
Source: ..\bin\Release\Media\*; DestDir: {app}\Media; Flags: ignoreversion recursesubdirs createallsubdirs
Source: plugin.program.slingfront\*; DestDir: {userappdata}\XBMC\addons\plugin.program.slingfront; Flags: ignoreversion recursesubdirs createallsubdirs
Source: kodi.plugin.program.slingfront\*; DestDir: {userappdata}\Kodi\addons\plugin.program.slingfront; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files


[Icons]
Name: {group}\SlingFront; Filename: {app}\SlingFront.exe
Name: {group}\{cm:ProgramOnTheWeb,SlingFront}; Filename: http://www.spesoft.com/
Name: {group}\{cm:UninstallProgram,SlingFront}; Filename: {uninstallexe}
Name: {commondesktop}\SlingFront; Filename: {app}\SlingFront.exe; Tasks: desktopicon

[Run]
Filename: {app}\SlingFront.exe; Description: {cm:LaunchProgram,SlingFront}; Flags: nowait postinstall skipifsilent
[_ISToolPostCompile]
Name: G:\DropBox\-DATA-\- SVN PROJECTS -\SlingFront SourceForge\SlingFront\Inno\SignSetup.exe.bat; Parameters: 
