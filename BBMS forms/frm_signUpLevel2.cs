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
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using BBMS_forms.packages;

namespace BBMS_forms
{
    public partial class frm_signUpLevel2 : Form
    {
        public frm_signUpLevel2()
        {
            InitializeComponent();
        }

        generalProcesses processes = new generalProcesses();
        private void frm_signUpLevel2_Load(object sender, EventArgs e)
        {
            string[] availblePositions = processes.availablePositions();
            foreach(string position in availblePositions)
            {
                comboBox1.Items.Add(position);
            }
            
        }

        bool drag = false;
        Point startPoint = new Point(0, 0);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && textBox5.Text.Length < 5)
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && textBox5.Text.Length < 5)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && textBox5.Text.Length < 3)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        generalProcesses process = new generalProcesses();
        private void button2_Click(object sender, EventArgs e)
        {
            process.getBackProcess(Properties.Settings.Default.lastLeave);
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to move away. Because you are in the middle of somewhere", "BBMS - Sign Up", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result.ToString() == "Yes")
            {
                frm_generalHomePage homePage = new frm_generalHomePage();
                homePage.Show();
                this.Hide();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked == true)
            {
                textBox1.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                comboBox2.Enabled = false;
                button1.Focus();
            }
            else
            {
                textBox1.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                comboBox2.Enabled = true;
                textBox1.Focus();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                textBox1.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                comboBox2.Enabled = true;
                textBox1.Focus();
            }
            else
            {
                textBox1.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                comboBox2.Enabled = false;
                button1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if(comboBox1.Text == "")
            {
                MessageBox.Show("Select your Applying position to continue", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBox1.Focus();
            }
            else if (textBox2.Text == "" || textBox10.Text == "")
            {
                MessageBox.Show("Phone number is not positioned correctly.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
            }
            else if (textBox11.Text == "")
            {
                MessageBox.Show("Enter the email to proceed", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox11.Focus();
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Enter Your last educational qualification correctly.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Focus();
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Enter Your last educated institute correctly.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox6.Focus();
            }
            else if (textBox7.Text == "" || textBox7.Text.Length > 5 || int.Parse(textBox7.Text) > int.Parse(DateTime.Now.ToString("yyyy")))
            {
                MessageBox.Show("Enter when you begin to study. The year is enough.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox7.Focus();
            }
            else if (textBox8.Text == "" || textBox8.Text.Length > 5)
            {
                MessageBox.Show("Enter when you end your studies. The year is enough.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox8.Focus();
            }
            else if (radioButton1.Checked == true && textBox1.Text == "")
            {
                MessageBox.Show("Enter your position completed last.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox8.Focus();
            }
            else if (radioButton1.Checked == true && textBox4.Text == "")
            {
                MessageBox.Show("Enter Your experiance level.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
            }
            else if (radioButton1.Checked == true && textBox3.Text == "")
            {
                MessageBox.Show("Enter where you work last.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
            }
            else
            {
                if(Regex.IsMatch(textBox11.Text, pattern))
                {
                    generalProcesses processes = new generalProcesses();
                    try
                    {
                        new staffList().updateStaffListforProfessionalDetails(processes.Encrypt(Properties.Settings.Default.userNIC), processes.Encrypt(comboBox1.Text), processes.Encrypt(textBox11.Text));

                        new staffEducationalQualification().newStaffEducationalQualification(processes.Encrypt(Properties.Settings.Default.userNIC), processes.Encrypt(textBox5.Text), processes.Encrypt(textBox6.Text), processes.Encrypt(textBox7.Text), processes.Encrypt(textBox8.Text),processes.Encrypt(textBox1.Text), processes.Encrypt(textBox3.Text), processes.Encrypt(textBox4.Text), processes.Encrypt(comboBox2.Text));

                        string phoneNumber = textBox2.Text + textBox10.Text;
                        new staffContactDetails().newStaffContact(processes.Encrypt(phoneNumber), processes.Encrypt(Properties.Settings.Default.userNIC));

                        Properties.Settings.Default.lastLeave = "frm_signUpLevel2";
                        frm_signLevel3 signUp = new frm_signLevel3();
                        signUp.Show();
                        this.Hide();
                    }
                    catch(Exception error)
                    {
                        MessageBox.Show("There is an error detected. Error Details: " + error.Message, "BBMS - Error Handler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Email pattern is not matching.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox11.Focus();
                }
            }
        }
    }
}
