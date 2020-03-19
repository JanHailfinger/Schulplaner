using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Commands
{
    class SetStundenplanCommand
    {
        public SetStundenplanCommand()
        {
            Command = "<PAC>SetStundenplan<PAC>";
        }
        public string Command { get; set; }
        public string EMail { get; set; }
        public string Hash { get; set; }
        public string Stundenplan { get; set; }
    }
}
