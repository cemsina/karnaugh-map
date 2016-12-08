using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnaughMap
{
    public class KarnaughVariable
    {
        public bool isNotReverse;
        public char Variable;
        public KarnaughVariable(char x,bool isnotreverse = true)
        {
            this.Variable = x;
            this.isNotReverse = isnotreverse;
        }
        
        public override bool Equals(object obj)
        {
            KarnaughVariable o = obj as KarnaughVariable;
            return (o.Variable == this.Variable && o.isNotReverse == this.isNotReverse) ? true : false;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            return (this.isNotReverse == false) ? this.Variable.ToString() + "'" : this.Variable.ToString() + "";
        }
    }
}