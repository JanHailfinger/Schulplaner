using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Commands
{
    class NewTaskCommand
    {
        public NewTaskCommand()
        {
            Command = "<PAC>NewTask<PAC>";
        }
        public string Command { get; }
        public string EMail { get; set; }
        public string Hash { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string EndDate { get; set; }
        public string CreateDate { get; set; }
    }
}
