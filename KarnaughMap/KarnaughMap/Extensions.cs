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
    }
}
