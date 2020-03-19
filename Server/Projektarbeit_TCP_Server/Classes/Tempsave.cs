using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Projektarbeit_TCP_Server
{
    class Tempsave
    {
        // E-Mail Bereich

        public static string email_mail;
        public static string email_server_adress;
        public static string email_server_port;
        public static string email_login_username;
        public static string email_login_password;
        public static string email_path_activation_code;
        public static string email_path_forgot_password;
        public static string email_path_class_invite;
        public static string datenbank_server_adress;
        public static string datenbank_datenbank;
        public static string datenbank_login_username;
        public static string datenbank_login_password;
        public static string tcpserver_port;
        public static void init()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            email_mail = config.AppSettings.Settings["email_email"].Value;
            email_server_adress = config.AppSettings.Settings["email_server_adress"].Value;
            email_server_port = config.AppSettings.Settings["email_server_port"].Value;
            email_login_username = config.AppSettings.Settings["email_login_username"].Value;
            email_login_password = config.AppSettings.Settings["email_login_password"].Value;
            email_path_activation_code = config.AppSettings.Settings["email_path_activation_code"].Value;
            email_path_forgot_password = config.AppSettings.Settings["email_path_forgot_password"].Value;
            email_path_class_invite = config.AppSettings.Settings["email_path_class_invite"].Value;

            datenbank_server_adress = config.AppSettings.Settings["datenbank_server_adress"].Value;
            datenbank_datenbank = config.AppSettings.Settings["datenbank_datenbank"].Value;
            datenbank_login_username = config.AppSettings.Settings["datenbank_login_username"].Value;
            datenbank_login_password = config.AppSettings.Settings["datenbank_login_password"].Value;

            tcpserver_port = config.AppSettings.Settings["tcpserver_port"].Value;
        }
        public static void save()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            config.AppSettings.Settings["email_email"].Value = email_mail;
            config.AppSettings.Settings["email_server_adress"].Value = email_server_adress;
            config.AppSettings.Settings["email_server_port"].Value = email_server_port;
            config.AppSettings.Settings["email_login_username"].Value = email_login_username;
            config.AppSettings.Settings["email_login_password"].Value = email_login_password;
            config.AppSettings.Settings["email_path_activation_code"].Value = email_path_activation_code;
            config.AppSettings.Settings["email_path_forgot_password"].Value = email_path_forgot_password;
            config.AppSettings.Settings["email_path_class_invite"].Value = email_path_class_invite;

            config.AppSettings.Settings["datenbank_server_adress"].Value = datenbank_server_adress;
            config.AppSettings.Settings["datenbank_datenbank"].Value = datenbank_datenbank;
            config.AppSettings.Settings["datenbank_login_username"].Value = datenbank_login_username;
            config.AppSettings.Settings["datenbank_login_password"].Value = datenbank_login_password;

            config.AppSettings.Settings["tcpserver_port"].Value = tcpserver_port;

            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
