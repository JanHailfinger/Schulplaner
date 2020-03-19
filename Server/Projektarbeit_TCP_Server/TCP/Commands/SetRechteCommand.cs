using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Commands
{
    class SetRechteCommand
    {
        public SetRechteCommand()
        {
            Command = "<PAC>SetRechte<PAC>";
        }
        public string Command { get; set; }
        public string EMail { get; set; }
        public string Hash { get; set; }
        public bool changeStundenplan { get; set; }
        public bool createAufgabe { get; set; }
        public bool changeAufgabe { get; set; }
        public bool deleteAufgabe { get; set; }
        public bool createTermin { get; set; }
        public bool changeTermin { get; set; }
        public bool deleteTermin { get; set; }
    }
}
