using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Projektarbeit_TCP_Server
{
    public partial class DatabaseServerSettings : Form
    {
        public DatabaseServerSettings()
        {
            InitializeComponent();
            buildSaves();
        }

        private void btn_test_connection_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder con_string = new MySqlConnectionStringBuilder();
            con_string.Server = Tempsave.datenbank_server_adress;
            con_string.UserID = Tempsave.datenbank_login_username;
            con_string.Password = Tempsave.datenbank_login_password;
            con_string.Database = Tempsave.datenbank_datenbank;

            bool status = true;
            MySqlConnection con;

            try
            {
                 con = new MySqlConnection(con_string.ConnectionString);
                con.Open();
                con.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message);
                status = false;
            }

            if (status)
            {
                MessageBox.Show("Verbindung war möglich");
            }

        }

        private void txt_server_adress_Leave(object sender, EventArgs e)
        {
            Tempsave.datenbank_server_adress = txt_server_adress.Text;
            
        }

        private void txt_database_Leave(object sender, EventArgs e)
        {
            Tempsave.datenbank_datenbank = txt_database.Text;
        }

        private void txt_password_Leave(object sender, EventArgs e)
        {
            Tempsave.datenbank_login_password = txt_password.Text;
        }

        private void txt_username_Leave(object sender, EventArgs e)
        {
            Tempsave.datenbank_login_username = txt_username.Text;
        }

        private void buildSaves()
        {
            txt_database.Text = Tempsave.datenbank_datenbank;
            txt_server_adress.Text = Tempsave.datenbank_server_adress;
            txt_username.Text = Tempsave.datenbank_login_username;
            txt_password.Text = Tempsave.datenbank_login_password;
        }
    }
}
