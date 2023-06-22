Imports System
Imports System.Collections
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Microsoft.Win32

Namespace ProxySwitcher
    Public Partial Class Main
        Inherits Form
        <DllImport("wininet.dll")>
        Public Shared Function InternetSetOption(ByVal hInternet As IntPtr, ByVal dwOption As Integer, ByVal lpBuffer As IntPtr, ByVal dwBufferLength As Integer) As Boolean
        End Function
        Public Const INTERNET_OPTION_SETTINGS_CHANGED As Integer = 39
        Public Const INTERNET_OPTION_REFRESH As Integer = 37
        ''' <summary>
        ''' Some local addresses must not be passed through proxy.
        ''' List from shadowsocks
        ''' </summary>
        Public Const BypassRules As String = "localhost;127.*;10.*;172.16.*;172.17.*;172.18.*;172.19.*;172.20.*;172.21.*;172.22.*;172.23.*;172.24.*;172.25.*;172.26.*;172.27.*;172.28.*;172.29.*;172.30.*;172.31.*;192.168.*;<local>"

        Private Const KeyName As String = "HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings"
        ''' <summary>
        ''' Sets the global proxy for the computer
        ''' </summary>
        ''' <remarks>
        ''' https://stackoverflow.com/a/26273084/4213397
        ''' </remarks>
        ''' <paramname="proxyHost">The proxy host and port</param>
        ''' <paramname="proxyEnabled">Enable the proxy?</param>
        ''' <paramname="overrideSettings"></param>
        Private Shared Sub SetProxy(ByVal proxyHost As String, ByVal proxyEnabled As Boolean, ByVal overrideSettings As String)
            Registry.SetValue(KeyName, "ProxyServer", proxyHost)
            Registry.SetValue(KeyName, "ProxyEnable", If(proxyEnabled, 1, 0))
            Registry.SetValue(KeyName, "ProxyOverride", overrideSettings)

            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0)
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0)
        End Sub
        ''' <summary>
        ''' True when the gui must not be shown when starting the app
        ''' </summary>
        Public NoGuiStart As Boolean
        ''' <summary>
        ''' The proxy of system when the application has started
        ''' </summary>
        Private ReadOnly _defaultProxyHost As String
        ''' <summary>
        ''' The bypass rules when the application has started
        ''' </summary>
        Private ReadOnly _defaultProxyOverride As String
        ''' <summary>
        ''' Is the proxy on when the application has started?
        ''' </summary>
        Private ReadOnly _defaultProxyIsOn As Boolean
        Public Sub New()
            InitializeComponent()
            ' Get default proxy settings
            _defaultProxyHost = CStr(Registry.GetValue(KeyName, "ProxyServer", ""))
            _defaultProxyOverride = CStr(Registry.GetValue(KeyName, "ProxyOverride", ""))
            _defaultProxyIsOn = CInt(Registry.GetValue(KeyName, "ProxyEnable", 0)) = 1
            ' Add default buttons
            notifyIconContextMenu.Items.Insert(0, New ToolStripMenuItem("Default Off", Nothing, Sub(sender, args) SetProxyEvent(CType(sender, ToolStripMenuItem), _defaultProxyHost, False, _defaultProxyOverride)))
            notifyIconContextMenu.Items.Insert(1, New ToolStripMenuItem("Default On", Nothing, Sub(sender, args) SetProxyEvent(CType(sender, ToolStripMenuItem), _defaultProxyHost, True, _defaultProxyOverride)))
            ' Disable proxy on startup
            If Properties.Settings.Default.DisableProxyOnStartup Then
                SetProxy(_defaultProxyHost, False, _defaultProxyOverride)
                DisableProxyAtStartupCheckbox.Checked = True
            End If
            ' Check the first or second button
            CType(notifyIconContextMenu.Items(If(Not _defaultProxyIsOn OrElse Properties.Settings.Default.DisableProxyOnStartup, 0, 1)), ToolStripMenuItem).Checked = True
            notifyIcon.Text = $"Proxy Switcher ({If(Not _defaultProxyIsOn OrElse Properties.Settings.Default.DisableProxyOnStartup, "Off", "Default")})"
            notifyIconContextMenu.Items.Insert(2, New ToolStripSeparator())
            ' Load settings
            Dim list = Properties.Settings.Default.ProxyList
            If list IsNot Nothing Then
                For Each proxy As String In list
                    proxyList.Items.Add(proxy)
                    notifyIconContextMenu.Items.Insert(notifyIconContextMenu.Items.Count - 1, New ToolStripMenuItem(proxy, Nothing, Sub(sender, args) SetProxyEvent(CType(sender, ToolStripMenuItem), proxy, True, BypassRules)))
                Next
            Else
                Properties.Settings.Default.ProxyList = New Specialized.StringCollection()
                Properties.Settings.Default.Save()
            End If
        End Sub
        ' https://stackoverflow.com/a/4210040/4213397
        Protected Overrides Sub SetVisibleCore(ByVal value As Boolean)
            MyBase.SetVisibleCore(If(Not NoGuiStart, value, Not NoGuiStart))
        End Sub
        Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
            Application.Exit()
        End Sub

        Private Sub addButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim dialog = New AddProxy()
            dialog.ShowDialog(Me)
            If Not Equals(dialog.Proxy, "") Then
                proxyList.Items.Add(dialog.Proxy)
                notifyIconContextMenu.Items.Insert(notifyIconContextMenu.Items.Count - 1, New ToolStripMenuItem(dialog.Proxy, Nothing, Sub(s, args) SetProxyEvent(CType(s, ToolStripMenuItem), dialog.Proxy, True, BypassRules)))
                Properties.Settings.Default.ProxyList.Add(dialog.Proxy)
                Properties.Settings.Default.Save()
            End If
        End Sub

        Private Sub deleteButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            If proxyList.SelectedItem IsNot Nothing Then
                Dim res = MessageBox.Show($"Are you sure you want to delete {proxyList.SelectedItem}?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If res = DialogResult.Yes Then
                    Dim index = proxyList.SelectedIndex
                    proxyList.Items.RemoveAt(index)
                    notifyIconContextMenu.Items.RemoveAt(index + 3) ' +3 is because of default values at top
                    Properties.Settings.Default.ProxyList.RemoveAt(index)
                    Properties.Settings.Default.Save()
                End If
            End If
        End Sub

        Private Sub Main_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs)
            SetProxy(_defaultProxyHost, _defaultProxyIsOn, _defaultProxyOverride)
        End Sub

        Private Sub notifyIcon_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
            NoGuiStart = False
            Show()
            WindowState = FormWindowState.Normal
        End Sub

        Private Sub Main_Resize(ByVal sender As Object, ByVal e As EventArgs)
            If WindowState = FormWindowState.Minimized Then
                If Properties.Settings.Default.FirstMinimize Then
                    notifyIcon.BalloonTipTitle = "Proxy Switcher is in taskbar!"
                    notifyIcon.BalloonTipText = "Double click on icon to open the form again."
                    notifyIcon.BalloonTipIcon = ToolTipIcon.Info
                    notifyIcon.ShowBalloonTip(500)
                    Properties.Settings.Default.FirstMinimize = False
                    Properties.Settings.Default.Save()
                End If
                Hide()
            End If
        End Sub

        ''' <summary>
        ''' An event to handle the menu clicks and set the proxy and checkbox
        ''' </summary>
        ''' <paramname="sender">The toolbar item</param>
        ''' <paramname="host">Proxy host and port</param>
        ''' <paramname="enabled">Should the proxy be enabled?</param>
        ''' <paramname="rules">Bypass rules</param>
        Private Sub SetProxyEvent(ByVal sender As ToolStripMenuItem, ByVal host As String, ByVal enabled As Boolean, ByVal rules As String)
            Dim menuItem As ToolStripMenuItem = Nothing
            For Each item In notifyIconContextMenu.Items
                If CSharpImpl.__Assign(menuItem, TryCast(item, ToolStripMenuItem)) IsNot Nothing Then menuItem.Checked = False
            Next
            sender.Checked = True
            notifyIcon.Text = $"Proxy Switcher ({If(enabled, host, "Off")})"
            SetProxy(host, enabled, rules)
        End Sub

        Private Sub DisableProxyAtStartupCheckbox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
            Properties.Settings.Default.DisableProxyOnStartup = DisableProxyAtStartupCheckbox.Checked
            Properties.Settings.Default.Save()
        End Sub

        Private Class CSharpImpl
            <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
            Shared Function __Assign(Of T)(ByRef target As T, value As T) As T
                target = value
                Return value
            End Function
        End Class
    End Class
End Namespace
