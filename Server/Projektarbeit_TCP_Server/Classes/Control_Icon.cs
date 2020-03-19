using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Resources;

namespace Projektarbeit_TCP_Server
{
    class Control_Icon
    {
        
        private static NotifyIcon notifyIcon;
        private static ContextMenu menus = new ContextMenu();
        private static MenuItem item1 = new MenuItem();
        private static MenuItem item3 = new MenuItem();
        private static MenuItem txt_name = new MenuItem();



        public static void init() {

            item1.Text = "Einstellungen";
            item1.Click += new System.EventHandler(item1_Click);

            item3.Text = "Beenden";
            item3.Click += new System.EventHandler(item3_Click);

            txt_name.Text = "Projektarbeit - TCP Server";
            txt_name.Enabled = false;

            menus.MenuItems.Add(txt_name);
            menus.MenuItems.Add("-");
            menus.MenuItems.Add(item1);
            menus.MenuItems.Add("-");
            menus.MenuItems.Add(item3);

            notifyIcon = new NotifyIcon { Icon = Properties.Resources.icon, Visible = true, Text = "Projektarbeit TCP - SQL Manager", ContextMenu = menus };
           
        }

        private static void item2_Click(object sender, EventArgs e)
        {        }

        private static void item1_Click(object Sender, EventArgs e)
        {
            Settings einstellungen = new Settings();

            Form currentForm = Application.OpenForms["Settings"];

            if (currentForm == null)
            {
                einstellungen.Show();
            }
            else
            {
                notifyIcon.ShowBalloonTip(10000, "Service Einstellungen", "Die Einstellungsseite ist schon Offen", ToolTipIcon.Error);
            }
        }
        private static void item3_Click(object Sender, EventArgs e)
        {

            Environment.Exit(0);

        }

        public static void showMessage(int ms,string title,string message,ToolTipIcon icon)
        {
            notifyIcon.ShowBalloonTip(ms, title, message, icon);
        }

    }
}
