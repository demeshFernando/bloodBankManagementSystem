using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BBMS_forms.packages;

namespace BBMS_forms
{
    public partial class frm_camps_newCampRegistration : Form
    {
        private string messageHeader = GlobalAcceass.companyName + " - Camp Registration";
        public frm_camps_newCampRegistration()
        {
            InitializeComponent();
        }

        private void frm_camps_newCampRegistration_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //checking any entries are not empty
            if (textBox1.Text == "")
            {
                //informing to the user
                MessageBox.Show("Please enter a valid and unique camp id to proceed.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Please provide a heading to the organizing camp.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Provide a requester name to proceed.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
            }
            else if (richTextBox1.Text == "")
            {
                MessageBox.Show("Provide a camp descrption. So that others can clerly undestand about the reason of the camp.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTextBox1.Focus();
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Head count required for the statistical view.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Camp helding year is not provided correctly.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Focus();
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Camp helding Month is not provided correctly.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox6.Focus();
            }
            else if (textBox7.Text == "")
            {
                MessageBox.Show("Camp helding day is not mentioned.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox7.Focus();
            }
            else if (textBox8.Text == "")
            {
                MessageBox.Show("Provide the correct time of the camp helding.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox8.Focus();
            }
            else if(textBox9.Text == "")
            {
                MessageBox.Show("Provide the camp helding minute to precise the details and improve the reliability.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox9.Focus();
            }
            else
            {
                //verifying the camp ID
                if(new databases.BloodCamps().checkId(textBox1.Text) == 0)
                {
                    //informing the user
                    MessageBox.Show("The entered ID was already used. So used a unique one.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }
                else if(new databases.BloodCamps().checkId(textBox1.Text) == -1)
                {
                    //creating the camp
                    new databases.BloodCamps().newBloodCamp(textBox2.Text, textBox3.Text, richTextBox1.Text, textBox4.Text, DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("hh"), DateTime.Now.ToString("mm"), textBox7.Text, textBox6.Text, textBox5.Text, textBox8.Text, textBox9.Text);

                    //informing the usr
                    MessageBox.Show("Meeting registration succesful.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frm_camps_newCampRegistration_meetingArrangingStep meetings = new frm_camps_newCampRegistration_meetingArrangingStep(textBox1.Text);
                    Properties.Settings.Default.lastLeave = "frm_camps_newCampRegistration_meetingArrangingStep";
                    meetings.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("There are multiple entries found in the system. Pelase conaact the administrator.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new generalProcesses().getBackProcess(Properties.Settings.Default.lastLeave);
            this.Hide();
        }
    }
}
