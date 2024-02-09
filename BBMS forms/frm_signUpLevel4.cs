using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BBMS_forms.packages;
using MySql.Data.MySqlClient;

namespace BBMS_forms
{
    public partial class frm_signUpLevel4 : Form
    {
        public frm_signUpLevel4()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = Path.GetFullPath(openFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show("select a file to review.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = Path.GetFullPath(openFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show("select a file to review.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = Path.GetFullPath(openFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show("select a file to review.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox4.Text = Path.GetFullPath(openFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show("select a file to review.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Focus();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            generalProcesses process = new generalProcesses();
            process.getBackProcess(Properties.Settings.Default.lastLeave);
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            generalProcesses processes = new generalProcesses();
            bool isdegreeSelected = false, isBirthCertificate = false, isNICFront = false, isNICBack = false;
            if(textBox1.Text == "")
            {
                MessageBox.Show("Choose a file for the degree program to complete the registration.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else if(textBox1.Text != "")
            {
                processes.pastingFiles("D:/Demesh/NSBM/Year 02/Year 02 Semester 02/Business Proceess and ERP/2. Take Home Group Assignment/samples/BP-ERPnew/BBMS forms/BBMS forms/collections/Staff_Proofs", textBox1.Text);
                isdegreeSelected = true;
            }

            if(textBox2.Text == "")
            {
                MessageBox.Show("Choose a file for the birth certificate to complete the registration.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
            }
            else if (textBox2.Text != "")
            {
                processes.pastingFiles("D:/Demesh/NSBM/Year 02/Year 02 Semester 02/Business Proceess and ERP/2. Take Home Group Assignment/samples/BP-ERPnew/BBMS forms/BBMS forms/collections/Staff_Proofs", textBox2.Text);
                isBirthCertificate = true;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("Choose a file for the NIC front to complete the registration.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
            }
            else if (textBox3.Text != "")
            {
                processes.pastingFiles("D:/Demesh/NSBM/Year 02/Year 02 Semester 02/Business Proceess and ERP/2. Take Home Group Assignment/samples/BP-ERPnew/BBMS forms/BBMS forms/collections/Staff_Proofs", textBox3.Text);
                isNICFront = true;
            }

            if (textBox4.Text == "")
            {
                MessageBox.Show("Choose a file for the NIC back to complete the registration.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
            }
            else if (textBox4.Text != "")
            {
                processes.pastingFiles("D:/Demesh/NSBM/Year 02/Year 02 Semester 02/Business Proceess and ERP/2. Take Home Group Assignment/samples/BP-ERPnew/BBMS forms/BBMS forms/collections/Staff_Proofs", textBox4.Text);
                isNICBack = true;
            }

            if (isBirthCertificate == true && isdegreeSelected == true && isNICFront == true && isNICBack == true)
            {
                generalProcesses process = new generalProcesses();
                try
                {
                    new staffEducationalQualification().newStaffEducationalQualification(process.Encrypt(Properties.Settings.Default.userNIC), process.Encrypt(textBox1.Text), process.Encrypt(textBox2.Text), process.Encrypt(textBox3.Text), process.Encrypt(textBox4.Text));
                    Properties.Settings.Default.lastLeave = "frm_signUpLevel4";
                    frm_signUpLevel5 credentials = new frm_signUpLevel5();
                    credentials.Show();
                    this.Hide();
                }
                catch(Exception error)
                {
                    MessageBox.Show("An error occured while trying to contact to server. Error: " + error.Message, "BBMS - Error Handler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("There are some kind of error shows please refill the file paths correctly", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_signUpLevel4_Load(object sender, EventArgs e)
        {

        }
    }
}
