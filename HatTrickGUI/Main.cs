using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HatTrickGUI
{
    public partial class Main : Form
    {
        HatTrickDataSet ds = new HatTrickDataSet();
        List<Tuple<string, DataTable>> tables = new List<Tuple<string, DataTable>>();
        List<Tuple<object, DataRow>> rows = new List<Tuple<object, DataRow>>();

        public Main()
        {
            InitializeComponent();
            part_type_combobox.SelectedIndexChanged += new System.EventHandler(PartTypeSelected);

            foreach ( DataTable table in ds.Tables )
            {
                tables.Add(Tuple.Create(table.TableName, table));
            }
            part_type_combobox.DataSource = tables;
            part_type_combobox.DisplayMember = "Item1";

        }

        public void PartTypeSelected( object sender_raw, System.EventArgs e)
        {
            if( tables[part_type_combobox.SelectedIndex].Item2.Rows == null)
            {
                MessageBox.Show("null!");
            }
            else
            {
                MessageBox.Show(ds.Microcontrollers.Rows.Count.ToString());
            }
            foreach (DataRow row in tables[part_type_combobox.SelectedIndex].Item2.Rows)
            {
                rows.Add(Tuple.Create(row["NXN"], row));
            }
            nxdn_combobox.DataSource = rows;
            //nxdn_combobox.DisplayMember = "Item1";
        }
    }
}
