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
    public partial class frm_signUpLevel5 : Form
    {
        public frm_signUpLevel5()
        {
            InitializeComponent();
        }

        bool drag = false;
        Point startPoint = new Point(0, 0);
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

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

        private void button6_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && textBox2.Text == textBox3.Text)
            {
                generalProcesses processes = new generalProcesses();
                try
                {
                    bool status = new staffCredentials().newCredential(processes.Encrypt(textBox1.Text), processes.Encrypt(textBox2.Text), processes.Encrypt(Properties.Settings.Default.userNIC));
                    Properties.Settings.Default.lastLeave = "frm_signUpLevel5";

                    if (status)
                    {
                        Login login = new Login();
                        login.Show();
                        this.Hide();

                        MessageBox.Show("The account creation process succeeded. PHI needs to activate your username to continue work", "BBMS - Sign In", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("The username is already in use. Please try another one.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    
                }
                catch (Exception error)
                {
                    MessageBox.Show("An error occured while running the system. Error Message: " + error.Message, "BBMS - Error Handler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Username and the password cannot be acceptable", "BBMS - sign up", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            generalProcesses process = new generalProcesses();
            process.getBackProcess(Properties.Settings.Default.lastLeave);
        }
    }
}
