using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BBMS_forms.packages;

namespace BBMS_forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            staffCredentials creadentials = new staffCredentials();

            try
            {
                if(creadentials.credentialMatching(textBox1.Text, textBox2.Text) != "no" && creadentials.credentialMatching(textBox1.Text, textBox2.Text) != "duplicates")
                {
                    string NIC = creadentials.credentialMatching(textBox1.Text, textBox2.Text);
                    Properties.Settings.Default.userNIC = NIC;

                    if(new staffList().getActivationDetails(NIC) == "activated")
                    {
                        //moving to the desired form
                        Properties.Settings.Default.lastLeave = "Login";
                        new generalProcesses().signInMove(new staffList().getPosition(NIC));
                        this.Hide();
                    }
                    else if (new staffList().getActivationDetails(NIC) == "not_found")
                    {
                        MessageBox.Show("The account is not found. Please retry.", "BBMS - Sign In", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (new staffList().getActivationDetails(NIC) == "many_found")
                    {
                        MessageBox.Show("There are several duplicate values found in the system. Please contact the IT departement", "BBMS - Sign In", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("an unknows error occured", "BBMS - Sign In", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if(creadentials.credentialMatching(textBox1.Text, textBox2.Text) == "no")
                {
                    MessageBox.Show("There is no username and password matched with the endtered credentials.", "BBMS - Sign In", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(creadentials.credentialMatching(textBox1.Text, textBox2.Text) == "duplicates")
                {
                    MessageBox.Show("There are several duplicate values found in the system. Please contact the IT departement", "BBMS - Sign In", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("an unknows error occured", "BBMS - Sign In", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception error)
            {
                MessageBox.Show("There is an error in connecting with the server. Error text: " + error.Message, "BBMS - Error Handler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
            if(Properties.Settings.Default.usernameRemembering == true)
            {
                textBox1.Text = Properties.Settings.Default.userName;
            }


            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp secondForm = new SignUp();
            secondForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.UseSystemPasswordChar == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SignUp secondForm = new SignUp();
            secondForm.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                Properties.Settings.Default.usernameRemembering = true;
            }
            else
            {
                Properties.Settings.Default.usernameRemembering = false;
            }
        }
    }

}
