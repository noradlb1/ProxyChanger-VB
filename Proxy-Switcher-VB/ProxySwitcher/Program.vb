Imports System
Imports System.Windows.Forms

Namespace ProxySwitcher
    Friend Module Program
        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Private Sub Main(ByVal args As String())
            Call Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Dim lMain = New Main()
            If args.Length > 0 AndAlso Equals(args(0), "--taskbar") Then lMain.NoGuiStart = True
            Application.Run(lMain)
        End Sub
    End Module
End Namespace
