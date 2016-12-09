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
            string variablesColName = "";
            for (int i = 1;i< builder.VariableList.Count();i++) variablesColName += builder.VariableList[i].Variable.ToString();
            variablesColName += " / " + builder.VariableList[0];
            MainTable.Columns["variables"].HeaderText = variablesColName;
            MainTable.Rows.Clear();
            List<KarnaughVariable> rowVars = new List<KarnaughVariable>();
            for (int i = 1; i < builder.VariableList.Count(); i++) rowVars.Add(builder.VariableList[i]);
            List<string> rowBits = grouping.SortBitsByOneBitDifference(grouping.CreateBitmap(rowVars));
            foreach (string bit in rowBits)
            {
                MainTable.Rows.Add(bit, map.BitMap["0" + bit], map.BitMap["1" + bit]);
            }
        }

    }
}
