<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MenuItem
    Inherits System.Windows.Forms.UserControl


    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try


        If Not Me.Image_Selected Is Nothing Then
            Image_Selected.Dispose()
            Image_Selected = Nothing
        End If

        If Not Me.Image_Unselected Is Nothing Then
            Image_Unselected.Dispose()
            Image_Unselected = Nothing
        End If
    End Sub


    Private components As System.ComponentModel.IContainer




    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SuspendLayout()



        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Name = "MenuItem"
        Me.Size = New System.Drawing.Size(342, 48)
        Me.ResumeLayout(False)

    End Sub

End Class
