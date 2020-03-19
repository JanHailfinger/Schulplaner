using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Datatype
{
    class UserData
    {
        public bool HasSelected { get; set; }
        public bool HasActivated { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Gender { get; set; }
        public int UID { get; set; }
        public int statusCode { get; set; }


    }
}
