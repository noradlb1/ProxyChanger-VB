Imports Microsoft.Win32
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms

Namespace ProxySwitcher
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			MinimumSize = Size
			Me.MaximumSize = MinimumSize
			EnableOkButtonOrDis()
			If CurrentProxyStatue() Then
			Load_proxy()
			End If

		End Sub
		Public Function TrimProxyString(ByVal defp As String) As String

			If defp.Chars(defp.Length - 1) = "/"c Then
				defp = defp.Substring(0, defp.Length - 1)
			End If
			 Dim passedfirstdot As Boolean = False
			Dim org_prox As String = ""
			For Each c As Char In defp
				If passedfirstdot AndAlso c <> "/"c Then
					org_prox &= c.ToString()
				ElseIf c = "/"c OrElse (c >= "0"c AndAlso c <= "9"c) Then
					passedfirstdot = True
				End If
			Next c
			If org_prox.Contains(":") = False Then
				Return defp
			End If
			Return org_prox
		End Function
		Private Sub Load_proxy()
			Try
				Dim prox_str As String = GetCurrentProxyString()
				Dim org_prox As String = TrimProxyString(prox_str)
				rb_Custom.Checked = True

			  Dim splidbycolon() As String = org_prox.Split(New Char() { ":"c })
				txbxIp.Text = splidbycolon(0)
				NmPort.Value = Decimal.Parse(splidbycolon(1))

			Catch
				MessageBox.Show("Could not load current proxy", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End Try
		End Sub

		Private Sub txbxIp_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txbxIp.TextChanged
			EnableOkButtonOrDis()
			lblChange.Text = "..."
		End Sub

		Private Sub EnableOkButtonOrDis()
			  btnOk.Enabled = If(RbNone.Checked, True, Regex.Match(txbxIp.Text, "\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}").Success)

		End Sub

		Private Sub rb_Custom_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles rb_Custom.CheckedChanged
			EnableOkButtonOrDis()
			NmPort.Enabled = rb_Custom.Checked
			txbxIp.Enabled = NmPort.Enabled
		End Sub

		Private Sub RbNone_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RbNone.CheckedChanged
			EnableOkButtonOrDis()

		End Sub

		Private Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
			Try
				If RbNone.Checked Then
					ProxyHandler.setProxy("", False)
				Else
					ProxyHandler.setProxy(txbxIp.Text & ":" & NmPort.Value.ToString(), True)
				End If
				lblChange.Text=("Changed")
			Catch ss As Exception
				MessageBox.Show(ss.Message, "Error")
				lblChange.Text = ("Error")
			End Try
			CurrentProxyStatue()


			'this.WindowState = FormWindowState.Minimized;
		End Sub


		 Public Sub Notify(ByVal tex As String, Optional ByVal title As String ="Mister Proxer", Optional ByVal v As Integer =500)
			notifyIcon1.BalloonTipTitle = title
			notifyIcon1.BalloonTipText = tex
			notifyIcon1.ShowBalloonTip(v)

		 End Sub

		Private Sub btnClose_Click(ByVal sender As Object, ByVal e As EventArgs)
			CurrentProxyStatue()
		End Sub

		Private Function CurrentProxyStatue() As Boolean
			   Dim myWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.microsoft.com"), HttpWebRequest)

			' Obtain the 'Proxy' of the  Default browser.  
			Dim proxy As IWebProxy = myWebRequest.Proxy
			' Print the Proxy Url to the console.
			If proxy IsNot Nothing Then
				Dim prx As String = TrimProxyString(proxy.GetProxy(myWebRequest.RequestUri).ToString())
				Dim res As String = String.Format("Proxy: {0}", prx)
				lblCPS.Text ="Current  " & res
				If res.Contains("micro") Then
					lblCPS.Text = "No proxy"
					Notify(lblCPS.Text)

					Return False
				End If
				Notify(lblCPS.Text)
				Return True

			Else
				lblCPS.Text="No proxy"
				Notify(lblCPS.Text)
				Return False
			End If
		End Function

		Private Function GetCurrentProxyString() As String
			Dim myWebRequest As HttpWebRequest = CType(WebRequest.Create("http://www.microsoft.com"), HttpWebRequest)

			' Obtain the 'Proxy' of the  Default browser.  
			Dim proxy As IWebProxy = myWebRequest.Proxy
			' Print the Proxy Url to the console.
			If proxy IsNot Nothing Then
				Dim res As String = proxy.GetProxy(myWebRequest.RequestUri).ToString() 'string.Format("Proxy: {0}", );
				If res.Contains("micro") Then
					Return "No proxy"
				Else
					Return res
				End If
			Else
				Return "No proxy"
			End If
		End Function

		Private Sub lblChange_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lblChange.TextChanged
			lblChange.ForeColor=If(lblChange.Text.Contains("changed")=False, Color.LimeGreen, Color.Red)
		End Sub

		Private Sub Form1_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Resize
			notifyIcon1.BalloonTipTitle = "Mister Proxer "
			notifyIcon1.BalloonTipText = "Im here " & Environment.UserName

			If FormWindowState.Minimized = Me.WindowState Then
				notifyIcon1.Visible = True
			   If checkBox_Silence.Checked=False Then
				   notifyIcon1.ShowBalloonTip(500)
			   End If
				Me.Hide()
			ElseIf FormWindowState.Normal = Me.WindowState Then
				notifyIcon1.Visible = False
			End If
		End Sub

		Private Sub notifyIcon1_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles notifyIcon1.MouseDoubleClick

			Me.Show()
			Me.WindowState = FormWindowState.Normal
		End Sub

		Private Sub linkLabelhint_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles linkLabelhint.LinkClicked
			MessageBox.Show("This option allows you to show or hide notification messages ","Hint",MessageBoxButtons.OK,MessageBoxIcon.Information)
		End Sub

		Private Sub linkLabel1_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles linkLabel1.LinkClicked
			System.Diagnostics.Process.Start("http://github.com/yassergersy")
		End Sub

		Private Sub SetAndMinimize(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			btnOk_Click(sender, e)
			Me.WindowState = FormWindowState.Minimized

		End Sub
	End Class
	Friend Class ProxyHandler
		<DllImport("wininet.dll")> _
		Public Shared Function InternetSetOption(ByVal hInternet As IntPtr, ByVal dwOption As Integer, ByVal lpBuffer As IntPtr, ByVal dwBufferLength As Integer) As Boolean
		End Function
		Public Const INTERNET_OPTION_SETTINGS_CHANGED As Integer = 39
		Public Const INTERNET_OPTION_REFRESH As Integer = 37


		Public Shared Sub setProxy(ByVal proxyhost As String, ByVal proxyEnabled As Boolean)
			Const userRoot As String = "HKEY_CURRENT_USER"
			Const subkey As String = "Software\Microsoft\Windows\CurrentVersion\Internet Settings"
			Const keyName As String = userRoot & "\" & subkey

			Registry.SetValue(keyName, "ProxyServer", proxyhost)
			Registry.SetValue(keyName, "ProxyEnable",If(proxyEnabled, "1", "0"))

			' These lines implement the Interface in the beginning of program 
			' They cause the OS to refresh the settings, causing IP to realy update
			InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0)
			InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0)
		End Sub

	End Class

End Namespace
