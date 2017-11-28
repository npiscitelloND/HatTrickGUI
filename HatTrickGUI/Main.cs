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

            List<string> tables = new List<string>();
            foreach( DataTable table in ds.Tables )
            {
                tables.Add(table.ToString());
            }
            part_type_combobox.DataSource = tables;
        }
    }
}
