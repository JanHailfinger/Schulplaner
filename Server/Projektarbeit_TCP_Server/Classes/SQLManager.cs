using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace Projektarbeit_TCP_Server
{
    class SQLManager
    {
        static private MySqlConnection connection;

        public static MySqlConnection Connection { get => connection; set => connection = value; }

        public static void init()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            MySqlConnectionStringBuilder con_string = new MySqlConnectionStringBuilder();
            con_string.Server = config.AppSettings.Settings["datenbank_server_adress"].Value;
            con_string.UserID = config.AppSettings.Settings["datenbank_login_username"].Value;
            con_string.Password = config.AppSettings.Settings["datenbank_login_password"].Value;
            con_string.Database = config.AppSettings.Settings["datenbank_datenbank"].Value;

            try
            {
                Connection = new MySqlConnection(con_string.ConnectionString);
                Connection.Open();
                Connection.Close();
            }
            catch (Exception ex)
            {
                Control_Icon.showMessage(20000, "MYSQL Status", ex.Message, ToolTipIcon.Error);
            }

        }
    }
}
