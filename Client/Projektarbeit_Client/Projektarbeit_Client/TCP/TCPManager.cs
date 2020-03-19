using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Security.Cryptography;

namespace Projektarbeit_Client.TCP
{
    class TCPManager
    {
        private static string adresse = //IPAddress; // Hier Adresse des Servers beim Testen PC im Netzwerk
        private static int port_ = 7252;
        private static TcpClient client;
        public static string SendRequest(string Command)
        {
            ASCIIEncoding asen = new ASCIIEncoding();
            try
            {
                client = new TcpClient(adresse, port_);
                Schreiben(Command, client);
                return Lesen(client);
            }
            catch (Exception e)
            {
                return "ERROR";
            }
        }
        private static void Schreiben(string text, TcpClient client)
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

        private static string Lesen(TcpClient client)
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
        public static string Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
