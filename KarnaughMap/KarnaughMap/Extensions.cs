using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnaughMap
{
    public static class Extensions
    {
        public static KarnaughVariable GetVariableByName(this List<KarnaughVariable> list,char variable)
        {
            foreach (KarnaughVariable k in list) if (k.Variable == variable) return k;
            return null;
        }
        public static string ToTruthTableBits(this List<KarnaughVariable> list, List<KarnaughVariable> variableQueue)
        {
            if (list.Count() != variableQueue.Count()) return null;
            string rtrn = "";
            foreach(KarnaughVariable v in variableQueue)
            {
                KarnaughVariable l = list.GetVariableByName(v.Variable);
                rtrn += (l.isNotReverse == true) ? "1" : "0";
            }
            return rtrn;
        }
        public static string ToStringVar(this List<KarnaughVariable> list)
        {
            string rtrn = "";
            foreach (KarnaughVariable k in list) rtrn += k.ToString();
            return rtrn;
        }
    }
}
