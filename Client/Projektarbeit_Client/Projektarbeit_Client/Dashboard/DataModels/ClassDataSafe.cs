using System;
using System.Collections.Generic;
using System.Text;

namespace Projektarbeit_Client
{
    class ClassDataSafe
    {
        public static string ClassName { get; set; }
        public static string Description { get; set; }
        public static string School { get; set; }
        public static string Creator { get; set; }
        public static bool changeStundenplan { get; set; }
        public static bool createAufgabe { get; set; }
        public static bool deleteAufgabe { get; set; }
        public static bool createTermin { get; set; }
        public static bool deleteTermin { get; set; }
        public static int statusCode { get; set; }

        public static string Stundenplan { get; set; }
        public static string Aufgabe { get; set; }
        public static string Termin { get; set; }
    }
}
