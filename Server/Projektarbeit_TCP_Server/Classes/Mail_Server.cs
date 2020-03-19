using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using System.IO;

namespace Projektarbeit_TCP_Server
{
    class Mail_Server
    {
        private static MailMessage mail;
        private static SmtpClient client;
        private static string text;
        private static string path;

        public static void init()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string smtp_host = config.AppSettings.Settings["email_server_adress"].Value;
            int smtp_port = 0;
            if (config.AppSettings.Settings["email_server_port"].Value != "")
            {
                smtp_port = int.Parse(config.AppSettings.Settings["email_server_port"].Value);
            }
            
            client = new SmtpClient(smtp_host, smtp_port);
            string smtp_username = config.AppSettings.Settings["email_login_username"].Value;
            string smtp_password = config.AppSettings.Settings["email_login_password"].Value;
            client.Credentials = new NetworkCredential(smtp_username, smtp_password);
            client.EnableSsl = true;

            mail = new MailMessage();

            string email = "Max.Mustermann@outlook.de";

            if (new System.ComponentModel.DataAnnotations.EmailAddressAttribute().IsValid(config.AppSettings.Settings["email_email"].Value))
            {
                email = config.AppSettings.Settings["email_email"].Value;
            }
            
            mail.From = new MailAddress(email);
            mail.IsBodyHtml = true;
        }
        public static void sendPasswordCode(int pin, string email)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            path = config.AppSettings.Settings["email_path_forgot_password"].Value;
            if (File.Exists(path))
            {
                text = File.ReadAllText(path);
                var zeilen = File.ReadLines(path);
                mail.Subject = zeilen.First();
                mail.To.Add(email);
                text = text.Replace("%code%",pin.ToString());
                text = text.Replace(zeilen.First()," " );
                mail.Body = text;
                try
                {
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    Control_Icon.showMessage(500, "Projektarbeit TCP Server", ex.Message, ToolTipIcon.Error);
                }
            }
            else
            {
                Control_Icon.showMessage(500, "Projektarbeit TCP Server", "Die HTML Datei der Passwort EMail wurde nicht gefunden", ToolTipIcon.Error);
                return;
            }
        }
        public static void sendActivationCode(int pin, string email)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            path = config.AppSettings.Settings["email_path_activation_code"].Value;
            if (File.Exists(path))
            {
                text = File.ReadAllText(path);
                var zeilen = File.ReadLines(path);
                mail.Subject = zeilen.First();
                mail.To.Add(email);
                text = text.Replace("%code%", pin.ToString());
                text = text.Replace(zeilen.First(), " ");
                mail.Body = text;
                try
                {
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    Control_Icon.showMessage(500, "Projektarbeit TCP Server", ex.Message, ToolTipIcon.Error);
                }
            }
            else
            {
                Control_Icon.showMessage(500, "Projektarbeit TCP Server", "Die HTML Datei der Registration EMail wurde nicht gefunden", ToolTipIcon.Error);
                return;
            }
        }
        public static void sendClassInviteCode(int pin, string email)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            path = config.AppSettings.Settings["email_path_class_invite"].Value;
            if (File.Exists(path))
            {
                text = File.ReadAllText(path);
                var zeilen = File.ReadLines(path);
                mail.Subject = zeilen.First();
                mail.To.Add(email);
                text = text.Replace("%code%", pin.ToString());
                text = text.Replace(zeilen.First(), " ");
                mail.Body = text;
                try
                {
                    client.Send(mail);
                }
                catch (Exception ex)
                {
                    Control_Icon.showMessage(500, "Projektarbeit TCP Server", ex.Message, ToolTipIcon.Error);
                }
            }
            else
            {
                Control_Icon.showMessage(500, "Projektarbeit TCP Server", "Die HTML Datei der Einladungs EMail wurde nicht gefunden", ToolTipIcon.Error);
                return;
            }
        }
    }
}