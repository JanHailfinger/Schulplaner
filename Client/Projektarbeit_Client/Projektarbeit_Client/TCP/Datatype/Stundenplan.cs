using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Datatype
{
    class Stundenplan
    {
        public string[,] stunden { get; set; } = new string[5, 8];
    }
}
