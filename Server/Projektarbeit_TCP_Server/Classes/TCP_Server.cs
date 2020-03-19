using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Net.Security;
using System.Configuration;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

using Projektarbeit_TCP_Server.TCP;

namespace Projektarbeit_TCP_Server
{
    class TCP_Server
    {

        //private static byte[] pfxData = File.ReadAllBytes("certificate.pfx");
        //private static X509Certificate2 serverCertificate = new X509Certificate2(pfxData, "linsen07", X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.Exportable);

        public static TcpListener tcpListener;

        private static Thread tcpserverthread;

        private static void tcpServerRun()
        {

            tcpListener.Start();

            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                Thread tcpHandlerThread = new Thread(new ParameterizedThreadStart(tcpHandler));
                tcpHandlerThread.Start(client);
            }
        }

        private static void tcpHandler(object client)
        {
            TcpClient mclient = (TcpClient)client;
            try
            {
                // sslStream.AuthenticateAsServer(serverCertificate, false,SslProtocols.Tls, true);

                string messageData = lesen(mclient);

                string returntext = CommandProzessor.ProzessCommand(messageData);

                schreiben(returntext, mclient);

            }
            catch (Exception e)
            {
                MessageBox.Show("Exception: " + e.Message);
                mclient.Close();
                return;
            }
            finally
            {
                mclient.Close();
            }
        }

        public static void start()
        {
            int port;
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (config.AppSettings.Settings["tcpserver_port"].Value != "")
            {
                port = int.Parse(config.AppSettings.Settings["tcpserver_port"].Value);
            }
            else
            {
                port = 9999;
            }


            tcpListener = new TcpListener(IPAddress.Any, port);

            tcpserverthread = new Thread(new ThreadStart(tcpServerRun));

            tcpserverthread.Start();
        }

        private static string lesen(TcpClient client)
        {

            byte[] buffer = new byte[2048];
            StringBuilder messageData = new StringBuilder();
            int bytes = -1;
            do
            {

                bytes = client.GetStream().Read(buffer, 0, buffer.Length);

                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(buffer, 0, bytes)];
                decoder.GetChars(buffer, 0, bytes, chars, 0);
                messageData.Append(chars);

                if (messageData.ToString().IndexOf("<EOF>") != -1)
                {

                    break;
                }

            } while (bytes != 0);

            return messageData.ToString().Replace("<EOF>", "");



        }

        private static void schreiben(string text, TcpClient client)
        {
            text = text + "<EOF>";
            char[] tmpC = text.ToCharArray();
            byte[] tmpB = new byte[tmpC.Length];
            int i = 0;
            foreach (char c in tmpC)
            {
                tmpB[i] = (byte)c;
                i++;
            }
            client.GetStream().Write(tmpB, 0, tmpB.Length);
        }

    }
}
