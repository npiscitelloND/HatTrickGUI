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
        public Main()
        {
            InitializeComponent();

            Dictionary<string, DataTable> tables = new Dictionary<string, DataTable>();
            foreach( DataTable table in ds.Tables )
            {
                tables.Add(table.ToString(), table);
            }
            part_type_combobox.DataSource = tables.Keys.ToArray();

            Dictionary<string, DataRow> rows = new Dictionary<string, DataRow>();
            if (tables.ContainsKey(part_type_combobox.SelectedText))
            {
                foreach (DataRow row in tables[part_type_combobox.SelectedText].Rows)
                {
                    rows.Add(row.ToString(), row);
                }
            }
            nxdn_combobox.DataSource = rows.Keys.ToArray();
        }

    }
}
