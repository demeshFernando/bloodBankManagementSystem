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
    public partial class frm_donorList : Form
    {
        public frm_donorList()
        {
            InitializeComponent();
        }

        private void frm_donorList_Load(object sender, EventArgs e)
        {
            //load database values 
            //load system suggestions 
            this.Text = "Donors";
            checkBox1.Checked = false;
            //activate reminder list
            //acticvate messages list
            //activate todo reminders

            MySqlConnection connection = new MySqlConnection("datasource = localhost; username = root; password =; database = bbms_repository");
            MySqlCommand command3 = new MySqlCommand();
            command3.Connection = connection;
            command3.CommandText = "select * from acessoryDetails";
            connection.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = command3;
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            connection.Close();

            MySqlConnection connection2 = new MySqlConnection("datasource = localhost; username = root; password =; database = bbms_repository");
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection2;
            command.CommandText = "select * from acessoryDetails";
            connection.Open();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            adapter1.SelectCommand = command;
            DataTable table2 = new DataTable();
            adapter1.Fill(table2);
            dataGridView2.DataSource = table2;
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Error Occured", "BBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Error Occured", "BBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Error Occured", "BBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Error Occured", "BBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Error Occured", "BBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Error Occured", "BBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            generalProcesses processes = new generalProcesses();
            processes.getBackProcess(Properties.Settings.Default.lastLeave);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Error Occured", "BBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
