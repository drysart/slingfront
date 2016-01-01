









Option Strict On
Option Explicit On


Namespace My






    Partial Friend Class MyApplication

        <Global.System.Diagnostics.DebuggerStepThroughAttribute()> _
        Public Sub New()
            MyBase.New(Global.Microsoft.VisualBasic.ApplicationServices.AuthenticationMode.Windows)
            Me.IsSingleInstance = True
            Me.EnableVisualStyles = True
            Me.SaveMySettingsOnExit = False
            Me.ShutdownStyle = Global.Microsoft.VisualBasic.ApplicationServices.ShutdownMode.AfterMainFormCloses
        End Sub

        <Global.System.Diagnostics.DebuggerStepThroughAttribute()> _
        Protected Overrides Sub OnCreateMainForm()
            Me.MainForm = Global.SlingFront.frmmain
        End Sub
    End Class
End Namespace
