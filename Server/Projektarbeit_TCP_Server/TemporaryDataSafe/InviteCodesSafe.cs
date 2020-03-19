using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektarbeit_TCP_Server.TemporaryDataSafe
{
    class InviteCodesSafe
    {
        public static List<CodeEMailCIDSafe> safe = new List<CodeEMailCIDSafe>();
        public static CodeEMailCIDSafe getData(string EMail)
        {
            return SearchData(EMail);
        }

        public static void addData(string EMail, int Code, int CID)
        {

            safe.Remove(SearchData(EMail));

            CodeEMailCIDSafe tmpdata = new CodeEMailCIDSafe();
            tmpdata.EMail = EMail;
            tmpdata.Code = Code;
            tmpdata.CID = CID;
            safe.Add(tmpdata);
        }

        public static void RemoveData(string EMail)
        {
            safe.Remove(SearchData(EMail));
        }

        private static CodeEMailCIDSafe SearchData(string EMail)
        {
            return safe.Find(x => x.EMail.Contains(EMail));
        }
    }
}
