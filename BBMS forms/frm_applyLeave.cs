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
    public partial class frm_applyLeave : Form
    {
        public frm_applyLeave()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = new MySqlConnection("datasource = localhost; username = root; password =; database = bbms_repository");
            MySqlCommand command = new MySqlCommand();
            command.Connection = connection;
            command.CommandText = "insert into leaveapplication values ('" + textBox1.Text + "', '" + comboBox1.Text + "', '" + richTextBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + comboBox2.Text + "')";
            connection.Open();
            MySqlDataReader reader = command.ExecuteReader();
            connection.Close();
            MessageBox.Show("Succesfully registered", "BBMS", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //opening the form
            frm_acessoryDetails details = new frm_acessoryDetails();
            Properties.Settings.Default.lastLeave = "frm_acessoryRegistration";
            details.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_logHistory history = new frm_logHistory();
            Properties.Settings.Default.lastLeave = "frm_acessoryRegistration";
            history.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            generalProcesses processes = new generalProcesses();
            processes.getBackProcess(Properties.Settings.Default.lastLeave);
            this.Hide();
        }

        private void frm_applyLeave_Load(object sender, EventArgs e)
        {
            textBox1.Text = (new databases.LeaveApplication().countEntries() + 1).ToString();
            label13.Text = new databases.StaffList().getStaffEntry(Properties.Settings.Default.userNIC).GetValue(16).ToString() + " total aplicable leaves " + ((new databases.LeaveApplication().approvedLeaves(Properties.Settings.Default.userNIC) > 0) ? (" " + new databases.LeaveApplication().approvedLeaves(Properties.Settings.Default.userNIC) + " are already applied.") : ("."));
        }
    }
}
