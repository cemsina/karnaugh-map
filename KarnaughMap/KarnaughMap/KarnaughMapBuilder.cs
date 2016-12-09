using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnaughMap
{
    public class KarnaughMapBuilder
    {
        public List<List<KarnaughVariable>> FixedStatement;
        public List<KarnaughVariable> VariableList;
        public KarnaughMapBuilder(string statement)
        {
            this.VariableList = new List<KarnaughVariable>();
            this.FixedStatement = new List<List<KarnaughVariable>>();
            SolveStatement(statement);
        }
        public void SolveStatement(string statement)
        {
            char[] charList = statement.ToCharArray();
            this.FixedStatement.Add(new List<KarnaughVariable>());
            foreach (char c in charList)
            {
                switch (c)
                {
                    case '+':
                        this.FixedStatement.Add(new List<KarnaughVariable>());
                        break;
                    case '\'':
                        this.FixedStatement[this.FixedStatement.Count() - 1][this.FixedStatement[this.FixedStatement.Count() - 1].Count() - 1].isNotReverse = false;
                        break;
                    case ' ':
                    case '.':
                    case '*':
                    case '-':
                    case ',':
                        continue;
                    default:
                        AddVariableToList(c);
                        this.FixedStatement[this.FixedStatement.Count() - 1].Add(new KarnaughVariable(c));
                        break;
                }
            }
        }
        public void AddVariableToList(char v)
        {
            foreach (KarnaughVariable k in this.VariableList)
            {
                if (k.Variable == v) return;
            }
            this.VariableList.Add(new KarnaughVariable(v));
        }
    }
}
