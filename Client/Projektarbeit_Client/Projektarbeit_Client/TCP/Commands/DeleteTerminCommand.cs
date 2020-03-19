using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Commands
{
    class DeleteTerminCommand
    {
        public DeleteTerminCommand()
        {
            Command = "<PAC>DeleteTermin<PAC>";
        }
        public string Command { get; }
        public string EMail { get; set; }
        public string Hash { get; set; }
        public int ID { get; set; }
    }
}
