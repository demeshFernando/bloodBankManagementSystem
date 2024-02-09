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
    public partial class frm_acessoryRegistration : Form
    {
        public frm_acessoryRegistration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textbox1 is id
            //textbox8 name
            //textbox9 country
            //textbox7, 4, 5 date
            //textbox6 seller id
            //textbox16 sellername
            //richtextbox1 description
            //textbox10, 3, 2 exp date

            if(textBox1.Text == "")
            {
                MessageBox.Show("Enter the ID of the product to be registered.", "BBMS - Acesory registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBox8.Text == "")
            {
                MessageBox.Show("Enter the name of the product.", "BBMS - Acesory registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBox9.Text == "")
            {
                MessageBox.Show("Contity required.", "BBMS - Acesory registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBox7.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Enter the registering date of the product.", "BBMS - Acesory registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBox6.Text == "")
            {
                MessageBox.Show("Seller ID required", "BBMS - Acesory registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBox16.Text == "")
            {
                MessageBox.Show("Seller name required", "BBMS - Acesory registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((textBox10.Text == "" || textBox3.Text == "" || textBox2.Text == "") && checkBox1.Checked == false)
            {
                MessageBox.Show("Enter the product expiry date.", "BBMS - Acesory registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                new databases.AcessoryDetails().registerNewAcessory(textBox8.Text, textBox9.Text, textBox6.Text, richTextBox1.Text, Properties.Settings.Default.userNIC, DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yyyy"), (checkBox1.Checked == true) ? ("00") : (textBox10.Text), (checkBox1.Checked == true) ? ("00") : (textBox3.Text), (checkBox1.Checked == true) ? ("0000") : (textBox2.Text));
                MessageBox.Show("Equpment Registration sucessfull.", "BBMS - Acessory Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox8.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_acessoryDetails details = new frm_acessoryDetails();
            BBMS_forms.Properties.Settings.Default.lastLeave = "frm_acessoryDetails";
            details.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            generalProcesses processes = new generalProcesses();
            processes.getBackProcess(Properties.Settings.Default.lastLeave);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox16.Text = new databases.AcessoryDetails().getAnEntry(textBox6.Text, 0);
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = new databases.AcessoryDetails().getID(textBox16.Text);
        }

        private void frm_acessoryRegistration_Load(object sender, EventArgs e)
        {
            textBox1.Text = (new databases.AcessoryDetails().countEntries() + 1).ToString();
        }
    }
}
