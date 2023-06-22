Imports System
Imports System.Windows.Forms

Namespace ProxySwitcher
    Public Partial Class AddProxy
        Inherits Form
        ''' <summary>
        ''' If this value is not empty then parent should get the proxy 
        ''' </summary>
        Public Proxy As String = ""
        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub addButton_Click(ByVal sender As Object, ByVal e As EventArgs)
            Submit()
        End Sub
        Private Sub AddProxy_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
            If e.KeyCode = Keys.Enter Then Submit()
        End Sub
        Private Sub Submit()
            Dim __ As UShort = Nothing

            If Not UShort.TryParse(proxyPort.Text, __) Then
                MessageBox.Show("Cannot parse port number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Proxy = proxyHost.Text & ":" & proxyPort.Text
            Close()
        End Sub

    End Class
End Namespace
