using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Commands
{
    class JoinClassCommand
    {
        public JoinClassCommand()
        {
            Command = "<PAC>JoinClass<PAC>";
        }
        public string Command { get; set; }
        public string EMail { get; set; }
        public string Hash { get; set; }
        public int Code { get; set; }
    }
}
