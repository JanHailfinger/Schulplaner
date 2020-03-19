using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projektarbeit_TCP_Server
{
    public partial class TcpServerSettings : Form
    {
        public TcpServerSettings()
        {
            InitializeComponent();
            txt_Port.Text = Tempsave.tcpserver_port;
        }

        private void txt_Port_Leave(object sender, EventArgs e)
        {
            int port;
            if (int.TryParse(txt_Port.Text, out port))
            {
                Tempsave.tcpserver_port = txt_Port.Text;
            }
            else
            {
                txt_Port.Text = "";
                Tempsave.tcpserver_port = txt_Port.Text;
                MessageBox.Show("Das ist keine gültiger Port", "Falsche Eingabe");
            }
        }
    }
}
