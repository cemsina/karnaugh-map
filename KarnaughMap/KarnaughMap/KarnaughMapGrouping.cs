using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarnaughMap
{
    public class KarnaughMapGrouping
    {
        public KarnaughMap Map;
        
        public KarnaughMapGrouping(KarnaughMap map)
        {
            this.Map = map;
        }
        public List<string> CreateBitmap(List<KarnaughVariable> variables)
        {
            int BitCount = (int)Math.Pow(2, variables.Count());
            List<string> bitmapList = new List<string>();
            for (int i = 0; i < BitCount; i++)
            {
                string binary = Convert.ToString(i, 2);
                int diff = variables.Count() - binary.ToCharArray().Count();
                for (int j = 0; j < diff; j++) binary = "0" + binary;
                bitmapList.Add(binary);
            }
            return bitmapList;
        }
        public int CheckDifference(string bit1, string bit2)
        {
            char[] bit1Arr = bit1.ToCharArray();
            char[] bit2Arr = bit2.ToCharArray();
            int diff = 0;
            for (int i = 0; i < bit1Arr.Count(); i++) if (bit1Arr[i] != bit2Arr[i]) diff++;
            return diff;
        }
        public List<string> SortBitsByOneBitDifference(List<string> bitmap)
        {
            List<string> sortedBitMap = new List<string>();
            sortedBitMap.Add(bitmap[0]);
            bitmap.RemoveAt(0);
            while(bitmap.Count() > 0)
            {
                foreach(string bit in bitmap)
                {
                    if(CheckDifference(sortedBitMap[sortedBitMap.Count()-1],bit) == 1)
                    {
                        bitmap.Remove(bit);
                        sortedBitMap.Add(bit);
                        break;
                    }
                }
            }
            return sortedBitMap;
        }

    }
}
