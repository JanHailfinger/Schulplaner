using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Commands
{
    class SetClassDataCommand
    {
        public SetClassDataCommand()
        {
            Command = "<PAC>SetClassData<PAC>";
        }
        public string Command { get; set; }
        public string EMail { get; set; }
        public string Hash { get; set; }
        public string ClassName { get; set; }
        public string Description { get; set; }
        public string School { get; set; }
    }
}
