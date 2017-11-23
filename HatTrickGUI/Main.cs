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

        private System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection();

        public Main()
        {
            InitializeComponent();
            conn.ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0; Data source= C:\Users\piscitellon\Documents\VisualStudio_Work\HatTrickGUI\sample_data\demo.accdb";
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to connect to data source");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
