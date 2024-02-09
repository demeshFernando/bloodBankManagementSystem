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
    public partial class frm_messages : Form
    {
        public frm_messages()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frm_messages_Load(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource = localhost; username = root; password =; database = bbms_repository");
            MySqlCommand command3 = new MySqlCommand();
            command3.Connection = connection;
            command3.CommandText = "select * from meetings";
            connection.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command3;
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Error Occured", "BBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource = localhost; username = root; password =; database = bbms_repository");
            MySqlCommand command3 = new MySqlCommand();
            command3.Connection = connection;
            command3.CommandText = "select * from meetings";
            connection.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command3;
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Error Occured", "BBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            generalProcesses processes = new generalProcesses();
            processes.getBackProcess(Properties.Settings.Default.lastLeave);
        }
    }
}
