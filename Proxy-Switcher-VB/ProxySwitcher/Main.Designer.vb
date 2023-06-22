Imports System

Namespace ProxySwitcher
    Partial Class Main
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
            components = New ComponentModel.Container()
            Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Main))
            notifyIcon = New Windows.Forms.NotifyIcon(components)
            notifyIconContextMenu = New Windows.Forms.ContextMenuStrip(components)
            exitToolStripMenuItem = New Windows.Forms.ToolStripMenuItem()
            proxyList = New Windows.Forms.ListBox()
            addButton = New Windows.Forms.Button()
            deleteButton = New Windows.Forms.Button()
            DisableProxyAtStartupCheckbox = New Windows.Forms.CheckBox()
            notifyIconContextMenu.SuspendLayout()
            SuspendLayout()
            ' 
            ' notifyIcon
            ' 
            notifyIcon.ContextMenuStrip = notifyIconContextMenu
            notifyIcon.Icon = CType(resources.GetObject("notifyIcon.Icon"), Drawing.Icon)
            notifyIcon.Text = "Proxy Switcher (Default)"
            notifyIcon.Visible = True
            AddHandler notifyIcon.DoubleClick, New EventHandler(AddressOf notifyIcon_DoubleClick)
            ' 
            ' notifyIconContextMenu
            ' 
            notifyIconContextMenu.Items.AddRange(New Windows.Forms.ToolStripItem() {exitToolStripMenuItem})
            notifyIconContextMenu.Name = "notifyIconContextMenu"
            notifyIconContextMenu.Size = New Drawing.Size(181, 48)
            ' 
            ' exitToolStripMenuItem
            ' 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem"
            exitToolStripMenuItem.Size = New Drawing.Size(180, 22)
            exitToolStripMenuItem.Text = "Exit"
            AddHandler exitToolStripMenuItem.Click, New EventHandler(AddressOf exitToolStripMenuItem_Click)
            ' 
            ' proxyList
            ' 
            proxyList.FormattingEnabled = True
            proxyList.Location = New Drawing.Point(12, 12)
            proxyList.Name = "proxyList"
            proxyList.Size = New Drawing.Size(247, 264)
            proxyList.TabIndex = 1
            ' 
            ' addButton
            ' 
            addButton.Location = New Drawing.Point(13, 282)
            addButton.Name = "addButton"
            addButton.Size = New Drawing.Size(120, 23)
            addButton.TabIndex = 2
            addButton.Text = "Add"
            addButton.UseVisualStyleBackColor = True
            AddHandler addButton.Click, New EventHandler(AddressOf addButton_Click)
            ' 
            ' deleteButton
            ' 
            deleteButton.Location = New Drawing.Point(139, 282)
            deleteButton.Name = "deleteButton"
            deleteButton.Size = New Drawing.Size(120, 23)
            deleteButton.TabIndex = 2
            deleteButton.Text = "Delete"
            deleteButton.UseVisualStyleBackColor = True
            AddHandler deleteButton.Click, New EventHandler(AddressOf deleteButton_Click)
            ' 
            ' DisableProxyAtStartupCheckbox
            ' 
            DisableProxyAtStartupCheckbox.AutoSize = True
            DisableProxyAtStartupCheckbox.Location = New Drawing.Point(13, 315)
            DisableProxyAtStartupCheckbox.Name = "DisableProxyAtStartupCheckbox"
            DisableProxyAtStartupCheckbox.Size = New Drawing.Size(171, 17)
            DisableProxyAtStartupCheckbox.TabIndex = 3
            DisableProxyAtStartupCheckbox.Text = "Disable system proxy at startup"
            DisableProxyAtStartupCheckbox.UseVisualStyleBackColor = True
            AddHandler DisableProxyAtStartupCheckbox.CheckedChanged, New EventHandler(AddressOf DisableProxyAtStartupCheckbox_CheckedChanged)
            ' 
            ' Main
            ' 
            AutoScaleDimensions = New Drawing.SizeF(6.0F, 13.0F)
            AutoScaleMode = Windows.Forms.AutoScaleMode.Font
            ClientSize = New Drawing.Size(271, 349)
            Controls.Add(DisableProxyAtStartupCheckbox)
            Controls.Add(deleteButton)
            Controls.Add(addButton)
            Controls.Add(proxyList)
            FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
            MaximizeBox = False
            Name = "Main"
            StartPosition = Windows.Forms.FormStartPosition.CenterScreen
            Text = "Proxy Switcher"
            AddHandler FormClosed, New Windows.Forms.FormClosedEventHandler(AddressOf Main_FormClosed)
            AddHandler Resize, New EventHandler(AddressOf Main_Resize)
            notifyIconContextMenu.ResumeLayout(False)
            ResumeLayout(False)
            PerformLayout()

        End Sub

#End Region

        Private notifyIcon As Windows.Forms.NotifyIcon
        Private notifyIconContextMenu As Windows.Forms.ContextMenuStrip
        Private exitToolStripMenuItem As Windows.Forms.ToolStripMenuItem
        Private proxyList As Windows.Forms.ListBox
        Private addButton As Windows.Forms.Button
        Private deleteButton As Windows.Forms.Button
        Private DisableProxyAtStartupCheckbox As Windows.Forms.CheckBox
    End Class
End Namespace
