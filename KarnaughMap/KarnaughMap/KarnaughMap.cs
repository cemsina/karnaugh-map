using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnaughMap
{
    public class KarnaughMap
    {
        public Dictionary<string,bool> BitMap;
        public KarnaughMapBuilder Builder;
        public KarnaughMap(KarnaughMapBuilder builder)
        {
            this.Builder = builder;
            CreateBitMap();
            FillBitMap();
        }
        public void CreateBitMap()
        {
            this.BitMap = new Dictionary<string, bool>();
            int BitCount = (int) Math.Pow(2, this.Builder.VariableList.Count());
            for (int i = 0; i < BitCount; i++)
            {
                string binary = Convert.ToString(i, 2);
                int diff = this.Builder.VariableList.Count() - binary.ToCharArray().Count();
                for (int j = 0; j < diff; j++) binary = "0" + binary;
                this.BitMap.Add(binary, false);
            }
        }
        public void FillBitMap()
        {
            foreach(List<KarnaughVariable> stList in this.Builder.FixedStatement)
            {
                foreach(string bit in this.BitMap.Keys.ToList())
                {
                    char[] bitArr = bit.ToCharArray();
                    int matches = 0;
                    for(int i = 0; i < this.Builder.VariableList.Count(); i++)
                    {
                        KarnaughVariable stListVar = stList.GetVariableByName(this.Builder.VariableList[i].Variable);
                        if (stListVar == null) continue;
                        if (bitArr[i] == '0' && this.Builder.VariableList[i].Variable == stListVar.Variable && stListVar.isNotReverse == false) matches++;
                        else if(bitArr[i] == '1' && this.Builder.VariableList[i].Variable == stListVar.Variable && stListVar.isNotReverse == true) matches++;
                    }
                    this.BitMap[bit] = (matches == stList.Count()) ? true : this.BitMap[bit];
                }
            }
        }
    }
}
