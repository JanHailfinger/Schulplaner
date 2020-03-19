using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Commands
{
    class NewTerminCommand
    {
        public NewTerminCommand()
        {
            Command = "<PAC>NewTermin<PAC>";
        }
        public string Command { get; }
        public string EMail { get; set; }
        public string Hash { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EndDate { get; set; }
    }
}
