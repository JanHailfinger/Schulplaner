using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Commands
{
    class LeaveClassCommand
    {
        public LeaveClassCommand()
        {
            Command = "<PAC>LeaveClass<PAC>";
        }
        public string Command { get; }
        public string EMail { get; set; }
        public string Hash { get; set; }
    }
}
