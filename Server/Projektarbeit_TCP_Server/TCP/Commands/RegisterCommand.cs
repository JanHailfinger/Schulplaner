using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Commands
{
    class RegisterCommand
    {
        public RegisterCommand()
        {
            Command = "<PAC>Register<PAC>";
        }
        public string Command { get;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string PasswordHash { get; set; }
        public string Gender { get; set; }
    }
}
