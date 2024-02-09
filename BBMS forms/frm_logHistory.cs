using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BBMS_forms.packages;

namespace BBMS_forms
{
    public partial class frm_logHistory : Form
    {
        public frm_logHistory()
        {
            InitializeComponent();
        }

        private void frm_logHistory_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource = localhost; username = root; password =; database = bbms_repository");
            MySqlCommand command3 = new MySqlCommand();
            command3.Connection = connection;
            command3.CommandText = "select * from logbook";
            connection.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command3;
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            generalProcesses processes = new generalProcesses();
            processes.getBackProcess(Properties.Settings.Default.lastLeave);
        }
    }
}
