using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Commands
{
    class GetUserDataCommand
    {
        public GetUserDataCommand()
        {
            Command = "<PAC>GetUserData<PAC>";
        }
        public string Command { get; }
        public string EMail { get; set; }
        public string Hash { get; set; }
    }
}
