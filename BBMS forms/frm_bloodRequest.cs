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
    public partial class frm_bloodRequest : Form
    {
        const string messageHeader = "BBMS - Blood Request";
        public frm_bloodRequest()
        {
            InitializeComponent();
        }

        protected string id;
        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "")
            {
                MessageBox.Show("The blood type need to be selected to prceed.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
            }
            else if(! new databases.BloodGroups().checkBloodGroup(comboBox1.Text))
            {
                DialogResult bloodGroupRegistration = MessageBox.Show("The blood Group you selected is not available in the current server. Would you like to register that new group? Otherwise, I'm sorry there is no way to register this blood request unless the blood is not available in the blood bank.", messageHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(bloodGroupRegistration.ToString() == "Yes")
                {
                    frm_newBloodGroupRegistration registration = new frm_newBloodGroupRegistration();
                    Properties.Settings.Default.lastLeave = "frm_newBloodGroupRegistration";
                    registration.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("The registration cannot be accepted", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(textBox8.Text == "")
            {
                MessageBox.Show("Fill the date the blood group needed.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox8.Focus();
            }
            else if(int.Parse(textBox8.Text) - int.Parse(DateTime.Now.ToString("yyyy")) > 10)
            {
                MessageBox.Show("The request should be below 10 years of time. Please change the year or else please register when the dates are arrived.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(textBox7.Text == "")
            {
                MessageBox.Show("The needed month required to continue.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox7.Focus();
            }
            else if(int.Parse(textBox7.Text) > 12 || int.Parse(textBox7.Text) < 1)
            {
                MessageBox.Show("Enter a month which is valid.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox7.Clear();
                textBox7.Focus();
            }
            else if(textBox6.Text == "")
            {
                MessageBox.Show("Enter the correct day to proceed.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox6.Focus();
            }
            else if(! new generalProcesses().checkDateWithMonth(textBox7.Text, textBox6.Text))
            {
                MessageBox.Show("The day you enter is not matching with the month.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //preparing the id
                string requestID = this.id + (new databases.BloodRequest().entryCount() + 1);
                textBox1.Text = requestID;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            generalProcesses processes = new generalProcesses();
            processes.getBackProcess(Properties.Settings.Default.lastLeave);
        }

        private void frm_bloodRequest_Load(object sender, EventArgs e)
        {
            //checking the id
            this.id = new databases.BloodRequest().checkID(Properties.Settings.Default.userNIC) ? Properties.Settings.Default.userNIC : "";

            if(this.id == "")
            {
                MessageBox.Show("Your id initializaiton failed to identify you. So please get sign in again.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Login login = new Login();
                login.Show();
                this.Hide();
            }

            textBox3.Text = DateTime.Now.ToString("yyyy");
            textBox4.Text = DateTime.Now.ToString("MM");
            textBox5.Text = DateTime.Now.ToString("dd");
            label4.Text = "Requested By: " + this.id;
            List<string> bloodGroups = new databases.BloodGroups().getBloodGroups();

            comboBox1.Items.Add("Select Group");
            comboBox1.Text = "Select Group";
            foreach(string bloodValue in bloodGroups)
            {
                comboBox1.Items.Add(bloodValue);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                //check the database
                if(new databases.BloodRequest().checkID(this.id))
                {
                    MessageBox.Show("The id is a properly registered as a staff inside the office.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The currently identified registration number is not in the staff registration list.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Login login = new Login();
                    login.Show();
                    this.Hide();
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && textBox3.TextLength < 5)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && textBox4.TextLength < 3)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && textBox5.TextLength < 3)
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && textBox8.TextLength < 5)
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && textBox7.TextLength < 3)
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && textBox6.TextLength < 3)
            {
                e.Handled = true;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if(textBox3.TextLength == 4)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if(textBox4.TextLength == 2)
            {
                textBox5.Focus();
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if(textBox8.TextLength == 4)
            {
                textBox7.Focus();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if(textBox7.TextLength == 2)
            {
                textBox6.Focus();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if(textBox6.TextLength == 2)
            {
                button1.Focus();
            }
        }
    }
}
