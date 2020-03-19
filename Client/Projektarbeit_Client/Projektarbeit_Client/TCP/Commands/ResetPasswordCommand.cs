using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Commands
{
    class ResetPasswordCommand
    {
        public ResetPasswordCommand()
        {
            Command = "<PAC>ResetPassword<PAC>";
        }
        public string Command { get; set; }
        public string EMail { get; set; }
        public string NewHash { get; set; }
        public int Code { get; set; }
    }
}
