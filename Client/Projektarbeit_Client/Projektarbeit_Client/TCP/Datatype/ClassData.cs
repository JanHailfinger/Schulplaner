using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client.TCP.Datatype
{
    class ClassData
    {
        public string ClassName { get; set; }
        public string Description { get; set; }
        public string School { get; set; }
        public string Creator { get; set; }
        public bool changeStundenplan { get; set; }
        public bool createAufgabe { get; set; }
        public bool deleteAufgabe { get; set; }
        public bool createTermin { get; set; }
        public bool deleteTermin { get; set; }
        public int statusCode { get; set; }

        public string Stundenplan { get; set; }
        public string Aufgabe { get; set; }
        public string Termin { get; set; }


    }
}
/*

    "stunden":{
        {
            "",
            "",
            "",
        },
        {
            
        }
    },

*/