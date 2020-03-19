using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Commands
{
    class SendNewActivationCodeCommand
    {
        public SendNewActivationCodeCommand()
        {
            Command = "<PAC>SendNewActivationCode<PAC>";
        }
        public string Command { get; set; }
        public string EMail { get; set; }
        public string Hash { get; set; }
    }
}
