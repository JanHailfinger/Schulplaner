using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Projektarbeit_TCP_Server
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            box_database.Visible = false;
            box_mailserver.Visible = false;
            box_tcpserver.Visible = true;

            panel.Controls.Clear();
            TcpServerSettings tcpsettings = new TcpServerSettings();
            tcpsettings.TopLevel = false;

            panel.Controls.Add(tcpsettings);
            tcpsettings.Show();
        }

        private void btn_tcpserversettings_Click(object sender, EventArgs e)
        {

            box_database.Visible = false;
            box_mailserver.Visible = false;
            box_tcpserver.Visible = true;

            panel.Controls.Clear();
            TcpServerSettings tcpsettings = new TcpServerSettings();
            tcpsettings.TopLevel = false;

            panel.Controls.Add(tcpsettings);
            tcpsettings.Show();
        }

        private void btn_mailserversettings_Click(object sender, EventArgs e)
        {
            box_database.Visible = false;
            box_mailserver.Visible = true;
            box_tcpserver.Visible = false;

            panel.Controls.Clear();
            MailServerSettings mailsettings = new MailServerSettings();
            mailsettings.TopLevel = false;

            panel.Controls.Add(mailsettings);
            mailsettings.Show();
        }

        private void btn_databasesettings_Click(object sender, EventArgs e)
        {
            box_database.Visible = true;
            box_mailserver.Visible = false;
            box_tcpserver.Visible = false;

            panel.Controls.Clear();
            DatabaseServerSettings databasesettings = new DatabaseServerSettings();
            databasesettings.TopLevel = false;

            panel.Controls.Add(databasesettings);
            databasesettings.Show();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Tempsave.save();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void copyright_Click(object sender, EventArgs e)
        {

        }
    }
}
