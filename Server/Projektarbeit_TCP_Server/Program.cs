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
using System.Configuration;

namespace Projektarbeit_TCP_Server
{
    static class Program
    {
        public static SQLManager sql;

        [STAThread]
        static void Main()
        {

            //bekommen
            Control_Icon.init();

            SQLManager.init();

            TCP_Server.start();

            Mail_Server.init();

            Tempsave.init();

           

            Application.Run();

            
        }

        public static void exit()
        {
            Application.Exit();
        }


    }
}
