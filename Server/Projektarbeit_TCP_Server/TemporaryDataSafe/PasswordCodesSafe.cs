using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbeit_TCP_Server.TemporaryDataSafe
{
    class PasswordCodesSafe
    {
        public static List<CodeEmailSafe> safe = new List<CodeEmailSafe>();
        public static CodeEmailSafe getData(string EMail)
        {
            return SearchData(EMail);
        }

        public static void addData(string EMail, int Code)
        {

            safe.Remove(SearchData(EMail));

            CodeEmailSafe tmpdata = new CodeEmailSafe();
            tmpdata.EMail = EMail;
            tmpdata.Code = Code;
            safe.Add(tmpdata);
        }

        public static void RemoveData(string EMail)
        {
            safe.Remove(SearchData(EMail));
        }

        private static CodeEmailSafe SearchData(string EMail)
        {

            return safe.Find(x => x.EMail.Contains(EMail));

        }
    }
}
