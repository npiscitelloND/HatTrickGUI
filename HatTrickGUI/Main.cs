using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HatTrickGUI
{
    public partial class Main : Form
    {
        OleDbConnection conn = new OleDbConnection();
        DataTable tables = new DataTable();
        //List<Tuple<string, DataTable>> tables = new List<Tuple<string, DataTable>>();
        //List<Tuple<object, DataRow>> rows = new List<Tuple<object, DataRow>>();

        public Main()
        {
            InitializeComponent();
            part_type_combobox.SelectedIndexChanged += new System.EventHandler(PartTypeSelected);

            OleDbConnectionStringBuilder builder = new OleDbConnectionStringBuilder
            {
                { "Provider", "Microsoft.ACE.OLEDB.12.0" },
                { "Data Source", "C:\\Users\\piscitellon\\Documents\\VisualStudio_Work\\HatTrickGUI\\sample_data\\demo.accdb" }
            };
            conn.ConnectionString = builder.ConnectionString;
            conn.Open();

            string[] restrictions = new string[4];
            restrictions[3] = "Table";
            tables = conn.GetSchema("Tables", restrictions);

            part_type_combobox.DataSource = tables;
            part_type_combobox.DisplayMember = "TABLE_NAME";
        }

        public void PartTypeSelected( object sender_raw, System.EventArgs e)
        {
            string table_name = ((DataRowView)((ComboBox)sender_raw).SelectedItem)["TABLE_NAME"].ToString();

            // create an adapter for the selected table
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            // a table mapping names the DataTable
            adapter.TableMappings.Add("Table", table_name);

            // retreive data
            OleDbCommand command = new OleDbCommand("SELECT NXN FROM " + table_name, conn);

            // set the adapter's command
            adapter.SelectCommand = command;

            // Fill the DataSet
            DataSet dataset = new DataSet(table_name);
            adapter.Fill(dataset);
        }
    }
}
