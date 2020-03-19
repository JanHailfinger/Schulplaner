using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Commands
{
    class SendNewPasswordCodeCommand
    {
        public SendNewPasswordCodeCommand()
        {
            Command = "<PAC>SendNewPasswordCode<PAC>";
        }
        public string Command { get; set; }
        public string EMail { get; set; }
    }
}
