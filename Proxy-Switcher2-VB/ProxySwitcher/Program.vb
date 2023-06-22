Imports Microsoft.Win32
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Namespace ProxySwitcher
	Friend NotInheritable Class Program

		Private Sub New()
		End Sub

'        
'        [DllImport("wininet.dll")]
'        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
'        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
'        public const int INTERNET_OPTION_REFRESH = 37;
'
'
'       public static void setProxy(string proxyhost, bool proxyEnabled)
'        {
'            const string userRoot = "HKEY_CURRENT_USER";
'            const string subkey = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
'            const string keyName = userRoot + "\\" + subkey;
'
'            Registry.SetValue(keyName, "ProxyServer", proxyhost);
'            Registry.SetValue(keyName, "ProxyEnable", proxyEnabled ? "1" : "0");
'
'            // These lines implement the Interface in the beginning of program 
'            // They cause the OS to refresh the settings, causing IP to realy update
'            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
'            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
'        }
'
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		<STAThread> _
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.SetCompatibleTextRenderingDefault(False)
			Application.Run(New Form1())
		End Sub
	End Class
End Namespace
