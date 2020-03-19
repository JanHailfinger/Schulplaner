using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Commands
{
    class GetClassDataCommand
    {
        public GetClassDataCommand()
        {
            Command = "<PAC>GetClassData<PAC>";
        }
        public string Command { get; set; }
        public string EMail { get; set; }
        public string Hash { get; set; }
    }
}

