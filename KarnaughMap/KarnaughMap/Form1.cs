using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarnaughMap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KarnaughMapBuilder builder = new KarnaughMapBuilder(textBox1.Text);
            if(builder.VariableList.Count() < 2)
            {
                MessageBox.Show("The variables can be at least 2"); return;
            }
            KarnaughMap map = new KarnaughMap(builder);
           
            KarnaughMapGrouping grouping = new KarnaughMapGrouping(map);
            int columnVarCount = map.Builder.VariableList.Count()/2;
            int rowVarCount = map.Builder.VariableList.Count() - columnVarCount;
            List<KarnaughVariable> columnVars = new List<KarnaughVariable>();
            List<KarnaughVariable> rowVars = new List<KarnaughVariable>();
            for (int i = 0; i < columnVarCount; i++) columnVars.Add(map.Builder.VariableList[i]);
            for (int i = columnVarCount; i < map.Builder.VariableList.Count(); i++) rowVars.Add(map.Builder.VariableList[i]);
            MainTable.Columns.Clear();
            MainTable.Rows.Clear();
            MainTable.Columns.Add("mid", rowVars.ToStringVar() + "/" + columnVars.ToStringVar());
            List<string> columnBits = grouping.SortBitsByOneBitDifference(grouping.CreateBitmap(columnVars));
            List<string> rowBits = grouping.SortBitsByOneBitDifference(grouping.CreateBitmap(rowVars));
            foreach (string c in columnBits) MainTable.Columns.Add(c, c);
            foreach (string bit in rowBits)
            {
                int rowid = MainTable.Rows.Add();
                DataGridViewRow newrow = MainTable.Rows[rowid];
                newrow.Cells["mid"].Value = bit;
                foreach (string c in columnBits)
                {
                    newrow.Cells[c].Value = (map.BitMap[c + bit]) ? "1" : "0";
                }
            }


            List<string> listboxBits = grouping.SortBitsByOneBitDifference(grouping.CreateBitmap(builder.VariableList));
            listBox1.Items.Add(builder.VariableList.ToStringVar());
            foreach(string bit in listboxBits)
            {
                string s = (map.BitMap[bit] == true) ? "1" : "0";
                listBox1.Items.Add(bit + " = " + s);
            }
        }
        
    }
}
