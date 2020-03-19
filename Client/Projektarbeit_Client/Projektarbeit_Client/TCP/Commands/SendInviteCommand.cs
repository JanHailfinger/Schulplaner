using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Commands
{
    class SendInviteCommand
    {
        public SendInviteCommand()
        {
            Command = "<PAC>SendInvite<PAC>";
        }
        public string Command { get; set; }
        public string EMail { get; set; }
        public string Hash { get; set; }
        public string EMail_Target { get; set; }
    }
}
