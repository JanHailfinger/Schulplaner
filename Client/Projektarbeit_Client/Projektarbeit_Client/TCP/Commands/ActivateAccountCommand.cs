using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Commands
{
    class ActivateAccountCommand
    {
        public ActivateAccountCommand()
        {
            Command = "<PAC>ActivateAccount<PAC>";
        }
        public string Command { get; }
        public string EMail { get; set; }
        public string Hash { get; set; }
        public int Code { get; set; }
    }
}
