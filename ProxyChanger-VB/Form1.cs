using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace ProxyChanger
{
    public partial class Form1 : Form
    {       
        RegistryKey reg;
        public static string path = @"Software\Microsoft\Windows\CurrentVersion\Internet Settings";
        public static int x;
        public static int y;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            txtProxy.Enabled = false;
            reg = Registry.CurrentUser.OpenSubKey(path, true);
            string proxy = txtProxy.Text;
            reg.SetValue("ProxyEnable", 1);
            reg.SetValue("ProxyServer", proxy);
            pnlStatus.BackColor = Color.Green;
            lblProxyStatus.Text = proxy;
            lblProxyStatus.ForeColor = Color.White;
            x = (pnlStatus.Size.Width - lblProxyStatus.Size.Width) / 2;
            y = (pnlStatus.Size.Height - lblProxyStatus.Size.Height) / 2;
            lblProxyStatus.Location = new Point(x, y);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            txtProxy.Enabled = true;
            reg.SetValue("ProxyEnable", 0);           
            pnlStatus.BackColor = Color.Red;
            lblProxyStatus.ForeColor = Color.White;
            lblProxyStatus.Text = "No proxy";
            x = (pnlStatus.Size.Width - lblProxyStatus.Size.Width) / 2;
            y = (pnlStatus.Size.Height - lblProxyStatus.Size.Height) / 2;
            lblProxyStatus.Location = new Point(x, y);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            x = (pnlStatus.Size.Width - lblProxyStatus.Size.Width) / 2;
            y = (pnlStatus.Size.Height - lblProxyStatus.Size.Height) / 2;
            lblProxyStatus.Location = new Point(x, y);
            
        }
    }
}