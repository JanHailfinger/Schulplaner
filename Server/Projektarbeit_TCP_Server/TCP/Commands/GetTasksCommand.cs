using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Commands
{
    class GetTasksCommand
    {
        public GetTasksCommand()
        {
            Command = "<PAC>GetTasks<PAC>";
        }
        public string Command { get; set; }
        public string EMail { get; set; }
        public string Hash { get; set; }
    }
}
