Namespace ProxyChanger
    Partial Class Form1
        ''' <summary>
        '''  Required designer variable.
        ''' </summary>
        Private components As ComponentModel.IContainer = Nothing

        ''' <summary>
        '''  Clean up any resources being used.
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
        '''  Required method for Designer support - do not modify
        '''  the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form1))
            pnlStatus = New Windows.Forms.Panel()
            lblProxyStatus = New Windows.Forms.Label()
            lblProxy = New Windows.Forms.Label()
            txtProxy = New Windows.Forms.TextBox()
            btnStop = New Windows.Forms.Button()
            btnStart = New Windows.Forms.Button()
            pnlStatus.SuspendLayout()
            SuspendLayout()
            ' 
            ' pnlStatus
            ' 
            pnlStatus.BackColor = Drawing.Color.Red
            pnlStatus.Controls.Add(lblProxyStatus)
            pnlStatus.Location = New Drawing.Point(0, 0)
            pnlStatus.Name = "pnlStatus"
            pnlStatus.Size = New Drawing.Size(340, 25)
            pnlStatus.TabIndex = 0
            ' 
            ' lblProxyStatus
            ' 
            lblProxyStatus.AutoSize = True
            lblProxyStatus.Font = New Drawing.Font("Verdana", 9F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
            lblProxyStatus.ForeColor = Drawing.Color.Black
            lblProxyStatus.Location = New Drawing.Point(155, 5)
            lblProxyStatus.Name = "lblProxyStatus"
            lblProxyStatus.Size = New Drawing.Size(62, 14)
            lblProxyStatus.TabIndex = 1
            lblProxyStatus.Text = "Proxy off"
            lblProxyStatus.TextAlign = Drawing.ContentAlignment.MiddleCenter
            ' 
            ' lblProxy
            ' 
            lblProxy.AutoSize = True
            lblProxy.Font = New Drawing.Font("Verdana", 9F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
            lblProxy.Location = New Drawing.Point(5, 35)
            lblProxy.Name = "lblProxy"
            lblProxy.Size = New Drawing.Size(42, 14)
            lblProxy.TabIndex = 2
            lblProxy.Text = "Proxy"
            ' 
            ' txtProxy
            ' 
            txtProxy.Font = New Drawing.Font("Verdana", 9F, Drawing.FontStyle.Regular, Drawing.GraphicsUnit.Point)
            txtProxy.Location = New Drawing.Point(55, 30)
            txtProxy.Name = "txtProxy"
            txtProxy.PlaceholderText = "Enter your proxy address"
            txtProxy.Size = New Drawing.Size(155, 22)
            txtProxy.TabIndex = 3
            ' 
            ' btnStop
            ' 
            btnStop.Location = New Drawing.Point(280, 30)
            btnStop.Name = "btnStop"
            btnStop.Size = New Drawing.Size(55, 23)
            btnStop.TabIndex = 4
            btnStop.Text = "Stop"
            btnStop.UseVisualStyleBackColor = True
            AddHandler btnStop.Click, New EventHandler(AddressOf btnStop_Click)
            ' 
            ' btnStart
            ' 
            btnStart.Location = New Drawing.Point(220, 30)
            btnStart.Name = "btnStart"
            btnStart.Size = New Drawing.Size(55, 23)
            btnStart.TabIndex = 5
            btnStart.Text = "Start"
            btnStart.UseVisualStyleBackColor = True
            AddHandler btnStart.Click, New EventHandler(AddressOf btnStart_Click)
            ' 
            ' Form1
            ' 
            AutoScaleDimensions = New Drawing.SizeF(7F, 15F)
            AutoScaleMode = Windows.Forms.AutoScaleMode.Font
            ClientSize = New Drawing.Size(340, 61)
            Controls.Add(btnStart)
            Controls.Add(btnStop)
            Controls.Add(txtProxy)
            Controls.Add(lblProxy)
            Controls.Add(pnlStatus)
            Icon = CType(resources.GetObject("$this.Icon"), Drawing.Icon)
            Name = "Form1"
            Text = "ProxyChanger"
            AddHandler Load, New EventHandler(AddressOf Form1_Load)
            pnlStatus.ResumeLayout(False)
            pnlStatus.PerformLayout()
            ResumeLayout(False)
            PerformLayout()

        End Sub

#End Region

        Private pnlStatus As Windows.Forms.Panel
        Private lblProxyStatus As Windows.Forms.Label
        Private lblProxy As Windows.Forms.Label
        Private txtProxy As Windows.Forms.TextBox
        Private btnStop As Windows.Forms.Button
        Private btnStart As Windows.Forms.Button
    End Class
End Namespace
