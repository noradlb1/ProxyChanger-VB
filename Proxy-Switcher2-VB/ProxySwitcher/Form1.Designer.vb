Namespace ProxySwitcher
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
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
			Me.components = New System.ComponentModel.Container()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
			Me.notifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
			Me.panelcontainer = New System.Windows.Forms.Panel()
			Me.linkLabel1 = New System.Windows.Forms.LinkLabel()
			Me.linkLabelhint = New System.Windows.Forms.LinkLabel()
			Me.checkBox_Silence = New System.Windows.Forms.CheckBox()
			Me.lblChange = New System.Windows.Forms.Label()
			Me.lblCPS = New System.Windows.Forms.Label()
			Me.NmPort = New System.Windows.Forms.NumericUpDown()
			Me.label2 = New System.Windows.Forms.Label()
			Me.label1 = New System.Windows.Forms.Label()
			Me.txbxIp = New System.Windows.Forms.TextBox()
			Me.button1 = New System.Windows.Forms.Button()
			Me.btnOk = New System.Windows.Forms.Button()
			Me.rb_Custom = New System.Windows.Forms.RadioButton()
			Me.RbNone = New System.Windows.Forms.RadioButton()
			Me.panelcontainer.SuspendLayout()
			DirectCast(Me.NmPort, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' notifyIcon1
			' 
			Me.notifyIcon1.Icon = (DirectCast(resources.GetObject("notifyIcon1.Icon"), System.Drawing.Icon))
			Me.notifyIcon1.Text = "Im here"
			Me.notifyIcon1.Visible = True
'			Me.notifyIcon1.MouseDoubleClick += New System.Windows.Forms.MouseEventHandler(Me.notifyIcon1_MouseDoubleClick)
			' 
			' panelcontainer
			' 
			Me.panelcontainer.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.panelcontainer.BackColor = System.Drawing.Color.Black
			Me.panelcontainer.Controls.Add(Me.linkLabel1)
			Me.panelcontainer.Controls.Add(Me.linkLabelhint)
			Me.panelcontainer.Controls.Add(Me.checkBox_Silence)
			Me.panelcontainer.Controls.Add(Me.lblChange)
			Me.panelcontainer.Controls.Add(Me.lblCPS)
			Me.panelcontainer.Controls.Add(Me.NmPort)
			Me.panelcontainer.Controls.Add(Me.label2)
			Me.panelcontainer.Controls.Add(Me.label1)
			Me.panelcontainer.Controls.Add(Me.txbxIp)
			Me.panelcontainer.Controls.Add(Me.button1)
			Me.panelcontainer.Controls.Add(Me.btnOk)
			Me.panelcontainer.Controls.Add(Me.rb_Custom)
			Me.panelcontainer.Controls.Add(Me.RbNone)
			Me.panelcontainer.Location = New System.Drawing.Point(12, 12)
			Me.panelcontainer.Name = "panelcontainer"
			Me.panelcontainer.Size = New System.Drawing.Size(354, 215)
			Me.panelcontainer.TabIndex = 0
			' 
			' linkLabel1
			' 
			Me.linkLabel1.AutoSize = True
			Me.linkLabel1.LinkColor = System.Drawing.Color.Lime
			Me.linkLabel1.Location = New System.Drawing.Point(285, 187)
			Me.linkLabel1.Name = "linkLabel1"
			Me.linkLabel1.Size = New System.Drawing.Size(35, 13)
			Me.linkLabel1.TabIndex = 10
			Me.linkLabel1.TabStop = True
			Me.linkLabel1.Text = "Coder"
'			Me.linkLabel1.LinkClicked += New System.Windows.Forms.LinkLabelLinkClickedEventHandler(Me.linkLabel1_LinkClicked)
			' 
			' linkLabelhint
			' 
			Me.linkLabelhint.AutoSize = True
			Me.linkLabelhint.LinkColor = System.Drawing.Color.Yellow
			Me.linkLabelhint.Location = New System.Drawing.Point(327, 3)
			Me.linkLabelhint.Name = "linkLabelhint"
			Me.linkLabelhint.Size = New System.Drawing.Size(13, 13)
			Me.linkLabelhint.TabIndex = 9
			Me.linkLabelhint.TabStop = True
			Me.linkLabelhint.Text = "?"
'			Me.linkLabelhint.LinkClicked += New System.Windows.Forms.LinkLabelLinkClickedEventHandler(Me.linkLabelhint_LinkClicked)
			' 
			' checkBox_Silence
			' 
			Me.checkBox_Silence.AutoSize = True
			Me.checkBox_Silence.ForeColor = System.Drawing.Color.White
			Me.checkBox_Silence.Location = New System.Drawing.Point(268, 3)
			Me.checkBox_Silence.Name = "checkBox_Silence"
			Me.checkBox_Silence.Size = New System.Drawing.Size(52, 17)
			Me.checkBox_Silence.TabIndex = 8
			Me.checkBox_Silence.Text = "Silent"
			Me.checkBox_Silence.UseVisualStyleBackColor = True
			' 
			' lblChange
			' 
			Me.lblChange.AutoSize = True
			Me.lblChange.Location = New System.Drawing.Point(135, 130)
			Me.lblChange.Name = "lblChange"
			Me.lblChange.Size = New System.Drawing.Size(13, 13)
			Me.lblChange.TabIndex = 7
			Me.lblChange.Text = ".."
'			Me.lblChange.TextChanged += New System.EventHandler(Me.lblChange_TextChanged)
			' 
			' lblCPS
			' 
			Me.lblCPS.AutoSize = True
			Me.lblCPS.ForeColor = System.Drawing.Color.White
			Me.lblCPS.Location = New System.Drawing.Point(3, 187)
			Me.lblCPS.Name = "lblCPS"
			Me.lblCPS.Size = New System.Drawing.Size(16, 13)
			Me.lblCPS.TabIndex = 6
			Me.lblCPS.Text = "..."
			' 
			' NmPort
			' 
			Me.NmPort.Enabled = False
			Me.NmPort.Location = New System.Drawing.Point(135, 79)
			Me.NmPort.Maximum = New Decimal(New Integer() { 65535, 0, 0, 0})
			Me.NmPort.Minimum = New Decimal(New Integer() { 1, 0, 0, 0})
			Me.NmPort.Name = "NmPort"
			Me.NmPort.Size = New System.Drawing.Size(100, 20)
			Me.NmPort.TabIndex = 5
			Me.NmPort.Value = New Decimal(New Integer() { 8080, 0, 0, 0})
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.ForeColor = System.Drawing.Color.White
			Me.label2.Location = New System.Drawing.Point(78, 81)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(26, 13)
			Me.label2.TabIndex = 4
			Me.label2.Text = "Port"
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.ForeColor = System.Drawing.Color.White
			Me.label1.Location = New System.Drawing.Point(78, 43)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(33, 13)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Proxy"
			' 
			' txbxIp
			' 
			Me.txbxIp.Enabled = False
			Me.txbxIp.Location = New System.Drawing.Point(135, 43)
			Me.txbxIp.Name = "txbxIp"
			Me.txbxIp.Size = New System.Drawing.Size(100, 20)
			Me.txbxIp.TabIndex = 3
			Me.txbxIp.Text = "127.0.0.1"
'			Me.txbxIp.TextChanged += New System.EventHandler(Me.txbxIp_TextChanged)
			' 
			' button1
			' 
			Me.button1.BackColor = System.Drawing.Color.Gray
			Me.button1.Location = New System.Drawing.Point(154, 149)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(126, 23)
			Me.button1.TabIndex = 2
			Me.button1.Text = "Set and minimize"
			Me.button1.UseVisualStyleBackColor = False
'			Me.button1.Click += New System.EventHandler(Me.SetAndMinimize)
			' 
			' btnOk
			' 
			Me.btnOk.BackColor = System.Drawing.Color.Gray
			Me.btnOk.Enabled = False
			Me.btnOk.Location = New System.Drawing.Point(22, 149)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New System.Drawing.Size(126, 23)
			Me.btnOk.TabIndex = 2
			Me.btnOk.Text = "Set"
			Me.btnOk.UseVisualStyleBackColor = False
'			Me.btnOk.Click += New System.EventHandler(Me.btnOk_Click)
			' 
			' rb_Custom
			' 
			Me.rb_Custom.AutoSize = True
			Me.rb_Custom.ForeColor = System.Drawing.Color.White
			Me.rb_Custom.Location = New System.Drawing.Point(22, 14)
			Me.rb_Custom.Name = "rb_Custom"
			Me.rb_Custom.Size = New System.Drawing.Size(89, 17)
			Me.rb_Custom.TabIndex = 1
			Me.rb_Custom.Text = "Manual Proxy"
			Me.rb_Custom.UseVisualStyleBackColor = True
'			Me.rb_Custom.CheckedChanged += New System.EventHandler(Me.rb_Custom_CheckedChanged)
			' 
			' RbNone
			' 
			Me.RbNone.AutoSize = True
			Me.RbNone.Checked = True
			Me.RbNone.ForeColor = System.Drawing.Color.White
			Me.RbNone.Location = New System.Drawing.Point(22, 126)
			Me.RbNone.Name = "RbNone"
			Me.RbNone.Size = New System.Drawing.Size(68, 17)
			Me.RbNone.TabIndex = 0
			Me.RbNone.TabStop = True
			Me.RbNone.Text = "No Proxy"
			Me.RbNone.UseVisualStyleBackColor = True
'			Me.RbNone.CheckedChanged += New System.EventHandler(Me.RbNone_CheckedChanged)
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = System.Drawing.SystemColors.ActiveCaption
			Me.ClientSize = New System.Drawing.Size(378, 239)
			Me.Controls.Add(Me.panelcontainer)
			Me.Icon = (DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.MinimizeBox = False
			Me.Name = "Form1"
			Me.Opacity = 0.96R
			Me.Text = "System Proxy Switcher"
'			Me.Load += New System.EventHandler(Me.Form1_Load)
'			Me.Resize += New System.EventHandler(Me.Form1_Resize)
			Me.panelcontainer.ResumeLayout(False)
			Me.panelcontainer.PerformLayout()
			DirectCast(Me.NmPort, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private panelcontainer As System.Windows.Forms.Panel
		Private WithEvents RbNone As System.Windows.Forms.RadioButton
		Private WithEvents txbxIp As System.Windows.Forms.TextBox
		Private WithEvents btnOk As System.Windows.Forms.Button
		Private WithEvents rb_Custom As System.Windows.Forms.RadioButton
		Private NmPort As System.Windows.Forms.NumericUpDown
		Private label2 As System.Windows.Forms.Label
		Private label1 As System.Windows.Forms.Label
		Private lblCPS As System.Windows.Forms.Label
		Private WithEvents lblChange As System.Windows.Forms.Label
		Private WithEvents notifyIcon1 As System.Windows.Forms.NotifyIcon
		Private checkBox_Silence As System.Windows.Forms.CheckBox
		Private WithEvents linkLabelhint As System.Windows.Forms.LinkLabel
		Private WithEvents linkLabel1 As System.Windows.Forms.LinkLabel
		Private WithEvents button1 As System.Windows.Forms.Button
	End Class
End Namespace

