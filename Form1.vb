Imports Microsoft.Win32

Namespace ProxyChanger
    Public Partial Class Form1
        Inherits Windows.Forms.Form
        Private reg As RegistryKey
        Public Shared path As String = "Software\Microsoft\Windows\CurrentVersion\Internet Settings"
        Public Shared x As Integer
        Public Shared y As Integer

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub btnStart_Click(ByVal sender As Object, ByVal e As EventArgs)
            btnStart.Enabled = False
            btnStop.Enabled = True
            txtProxy.Enabled = False
            reg = Registry.CurrentUser.OpenSubKey(path, True)
            Dim proxy = txtProxy.Text
            reg.SetValue("ProxyEnable", 1)
            reg.SetValue("ProxyServer", proxy)
            pnlStatus.BackColor = Drawing.Color.Green
            lblProxyStatus.Text = proxy
            lblProxyStatus.ForeColor = Drawing.Color.White
            x = (pnlStatus.Size.Width - lblProxyStatus.Size.Width) / 2
            y = (pnlStatus.Size.Height - lblProxyStatus.Size.Height) / 2
            lblProxyStatus.Location = New Drawing.Point(x, y)
        End Sub

        Private Sub btnStop_Click(ByVal sender As Object, ByVal e As EventArgs)
            btnStart.Enabled = True
            btnStop.Enabled = False
            txtProxy.Enabled = True
            reg.SetValue("ProxyEnable", 0)
            pnlStatus.BackColor = Drawing.Color.Red
            lblProxyStatus.ForeColor = Drawing.Color.White
            lblProxyStatus.Text = "No proxy"
            x = (pnlStatus.Size.Width - lblProxyStatus.Size.Width) / 2
            y = (pnlStatus.Size.Height - lblProxyStatus.Size.Height) / 2
            lblProxyStatus.Location = New Drawing.Point(x, y)
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            x = (pnlStatus.Size.Width - lblProxyStatus.Size.Width) / 2
            y = (pnlStatus.Size.Height - lblProxyStatus.Size.Height) / 2
            lblProxyStatus.Location = New Drawing.Point(x, y)

        End Sub
    End Class
End Namespace
