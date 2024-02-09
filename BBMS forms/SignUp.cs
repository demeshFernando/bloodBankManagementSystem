using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BBMS_forms.packages;

namespace BBMS_forms
{
    public partial class SignUp : Form
    {
        staffList manipulation = new staffList();
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        public SignUp()
        {
            InitializeComponent();
        }

        
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }


        private void button1_Click(object sender, EventArgs e)
        {

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

        string gender = "";
        private void button1_Click_1(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Fist name requried to move furthur.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else if (textBox8.Text == "")
            {
                MessageBox.Show("Last name requried to move furthur.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox8.Focus();
            }
            else if (textBox7.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox7.Text.Length < 4 || textBox4.Text.Length < 2 || textBox5.Text.Length < 2 || int.Parse(textBox7.Text) > int.Parse(DateTime.Now.ToString("yyyy")) || int.Parse(textBox4.Text) > int.Parse(DateTime.Now.ToString("MM")) || int.Parse(textBox5.Text) > int.Parse(DateTime.Now.ToString("dd")))
            {
                MessageBox.Show("Valid birthday parameter required.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false)
            {
                MessageBox.Show("Select the gender correctly to proceed", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox2.Text == "" || textBox10.Text == "" || textBox2.Text.Length > 3 || textBox10.Text.Length > 14)
            {
                MessageBox.Show("Check the phone number again seems like not in the correct way.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
            }
            else if (textBox11.Text == "")
            {
                MessageBox.Show("Enter the ID number correctly.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox11.Focus();
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Address line 01 is not filled properly.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
            }
            else if (textBox12.Text == "")
            {
                MessageBox.Show("Address line 02 is not filled properly.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox12.Focus();
            }
            else if (textBox13.Text == "")
            {
                MessageBox.Show("Address line 03 is not filled properly.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox13.Focus();
            }
            else if (textBox14.Text == "")
            {
                MessageBox.Show("City is not filled properly.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox14.Focus();
            }
            else if (textBox15.Text == "")
            {
                MessageBox.Show("Homeland is not filled properly.", "BBMS - Sign Up", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox15.Focus();
            }
            else
            {
                generalProcesses processes = new generalProcesses();
                try
                {
                    //saving files
                    manipulation.registerNewStaff(processes.Encrypt(textBox1.Text), processes.Encrypt(textBox8.Text), processes.Encrypt(textBox9.Text), processes.Encrypt(textBox3.Text), processes.Encrypt(textBox12.Text), processes.Encrypt(textBox13.Text), processes.Encrypt(textBox14.Text), processes.Encrypt(textBox15.Text), processes.Encrypt(gender));
                    Properties.Settings.Default.lastLeave = "SignUp";
                    frm_signUpLevel2 signup = new frm_signUpLevel2();
                    signup.Show();
                    this.Hide();
                }
                catch (Exception error)
                {
                    MessageBox.Show("There is an error" + error.Message, "BBMS - Error Handling", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && textBox5.Text.Length < 5)
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            
            frm_generalHomePage homePage = new frm_generalHomePage();
            homePage.Show();
            this.Hide();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                gender = "male";
            }
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                gender = "male";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                gender = "male";
            }
        }
    }
}
