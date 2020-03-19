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
    public partial class MailServerSettings : Form
    {
        public MailServerSettings()
        {
            InitializeComponent();
            buildCombobox();
            buildSaves();
            cb_htmldatei.SelectedIndexChanged += index_changed;
            txt_dateipfad.TextChanged += path_changed;
            switch (cb_htmldatei.SelectedItem)
            {
                case "Bestätigungscode":
                    txt_dateipfad.Text = Tempsave.email_path_activation_code;
                    break;
                case "Passwort Vergessen":
                    txt_dateipfad.Text = Tempsave.email_path_forgot_password;
                    break;
                case "Klasseneinladung":
                    txt_dateipfad.Text = Tempsave.email_path_class_invite;
                    break;
            }
        }

        private void path_changed(object sender, EventArgs e)
        {
            switch (cb_htmldatei.SelectedItem)
            {
                case "Bestätigungscode":
                    Tempsave.email_path_activation_code = txt_dateipfad.Text;
                    break;
                case "Passwort Vergessen":
                    Tempsave.email_path_forgot_password = txt_dateipfad.Text;
                    break;
                case "Klasseneinladung":
                    Tempsave.email_path_class_invite = txt_dateipfad.Text;
                    break;
            }
        }

        private void index_changed(object sender, EventArgs e)
        {
            switch (cb_htmldatei.SelectedItem)
            {
                case "Bestätigungscode":
                    txt_dateipfad.Text = Tempsave.email_path_activation_code;
                    break;
                case "Passwort Vergessen":
                    txt_dateipfad.Text = Tempsave.email_path_forgot_password;
                    break;
                case "Klasseneinladung":
                    txt_dateipfad.Text = Tempsave.email_path_class_invite;
                    break;
            }
        }

        private void btn_openfileDialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "HTML Datei(*.html)|*.html";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txt_dateipfad.Text = ofd.FileName;
            }
        }

        private void buildCombobox()
        {
            cb_htmldatei.Items.Add("Bestätigungscode");
            cb_htmldatei.Items.Add("Passwort Vergessen");
            cb_htmldatei.Items.Add("Klasseneinladung");
            cb_htmldatei.SelectedIndex = 0;
        }

        private void buildSaves()
        {
            txt_port.Text = Tempsave.email_server_port;
            txt_username.Text = Tempsave.email_login_username;
            txt_passwort.Text = Tempsave.email_login_password;
            txt_domain.Text = Tempsave.email_server_adress;
            txt_email.Text = Tempsave.email_mail;
        }

        private void txt_email_Leave(object sender, EventArgs e)
        {
            if (new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(txt_email.Text))
            {
                Tempsave.email_mail = txt_email.Text;
            }
            else
            {
                txt_email.Text = "";
                Tempsave.email_mail = txt_email.Text;
                MessageBox.Show("Das ist keine gültige E-Mail Adresse","Falsche eingabe");
            }
        }

        private void txt_domain_Leave(object sender, EventArgs e)
        {
            Tempsave.email_server_adress = txt_domain.Text;
        }

        private void txt_port_Leave(object sender, EventArgs e)
        {
            int port;
            if (int.TryParse(txt_port.Text,out port))
            {
                Tempsave.email_server_port = txt_port.Text;
            }
            else
            {
                txt_port.Text = "";
                Tempsave.email_server_port = txt_port.Text;
                MessageBox.Show("Das ist keine gültiger Port","Falsche Eingabe");
            }
        }

        private void txt_username_Leave(object sender, EventArgs e)
        {
            Tempsave.email_login_username = txt_username.Text;
        }

        private void txt_passwort_Leave(object sender, EventArgs e)
        {
            Tempsave.email_login_password = txt_passwort.Text;
        }

    }
}
