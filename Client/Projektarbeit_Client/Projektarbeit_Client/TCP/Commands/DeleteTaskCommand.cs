using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Commands
{
    class DeleteTaskCommand
    {
        public DeleteTaskCommand()
        {
            Command = "<PAC>DeleteTask<PAC>";
        }
        public string Command { get; }
        public string EMail { get; set; }
        public string Hash { get; set; }
        public int ID { get; set; }
    }
}
