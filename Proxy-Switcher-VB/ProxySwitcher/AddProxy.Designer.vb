Imports System

Namespace ProxySwitcher
    Partial Class AddProxy
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <paramname="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            addButton = New Windows.Forms.Button()
            label1 = New Windows.Forms.Label()
            proxyHost = New Windows.Forms.TextBox()
            label2 = New Windows.Forms.Label()
            proxyPort = New Windows.Forms.TextBox()
            SuspendLayout()
            ' 
            ' addButton
            ' 
            addButton.Location = New Drawing.Point(85, 102)
            addButton.Name = "addButton"
            addButton.Size = New Drawing.Size(75, 23)
            addButton.TabIndex = 0
            addButton.Text = "Add"
            addButton.UseVisualStyleBackColor = True
            AddHandler addButton.Click, New EventHandler(AddressOf addButton_Click)
            ' 
            ' label1
            ' 
            label1.AutoSize = True
            label1.Location = New Drawing.Point(13, 13)
            label1.Name = "label1"
            label1.Size = New Drawing.Size(61, 13)
            label1.TabIndex = 1
            label1.Text = "Proxy Host:"
            ' 
            ' proxyHost
            ' 
            proxyHost.Location = New Drawing.Point(16, 30)
            proxyHost.Name = "proxyHost"
            proxyHost.Size = New Drawing.Size(216, 20)
            proxyHost.TabIndex = 2
            ' 
            ' label2
            ' 
            label2.AutoSize = True
            label2.Location = New Drawing.Point(16, 57)
            label2.Name = "label2"
            label2.Size = New Drawing.Size(58, 13)
            label2.TabIndex = 3
            label2.Text = "Proxy Port:"
            ' 
            ' proxyPort
            ' 
            proxyPort.Location = New Drawing.Point(16, 74)
            proxyPort.Name = "proxyPort"
            proxyPort.Size = New Drawing.Size(216, 20)
            proxyPort.TabIndex = 4
            ' 
            ' AddProxy
            ' 
            AutoScaleDimensions = New Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = Windows.Forms.AutoScaleMode.Font
            ClientSize = New Drawing.Size(244, 134)
            Controls.Add(proxyPort)
            Controls.Add(label2)
            Controls.Add(proxyHost)
            Controls.Add(label1)
            Controls.Add(addButton)
            FormBorderStyle = Windows.Forms.FormBorderStyle.FixedToolWindow
            KeyPreview = True
            Name = "AddProxy"
            StartPosition = Windows.Forms.FormStartPosition.CenterParent
            Text = "Add Proxy"
            AddHandler KeyDown, New Windows.Forms.KeyEventHandler(AddressOf AddProxy_KeyDown)
            ResumeLayout(False)
            PerformLayout()

        End Sub

#End Region

        Private addButton As Windows.Forms.Button
        Private label1 As Windows.Forms.Label
        Private proxyHost As Windows.Forms.TextBox
        Private label2 As Windows.Forms.Label
        Private proxyPort As Windows.Forms.TextBox
    End Class
End Namespace
