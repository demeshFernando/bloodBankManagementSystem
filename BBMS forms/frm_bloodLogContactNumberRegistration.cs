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
    public partial class frm_bloodLogContactNumberRegistration : Form
    {
        private string nic;
        public frm_bloodLogContactNumberRegistration(string nic)
        {
            InitializeComponent();
            this.nic = nic;
        }

        private void frm_bloodLogContactNumberRegistration_Load(object sender, EventArgs e)
        {
            if(new databases.Donors().checkID(this.nic))
            {
                string firstName = new databases.Donors().getEntry(this.nic, 0), lastName = new databases.Donors().getEntry(this.nic, 1), otherNames = new databases.Donors().getEntry(this.nic, 2);
                string fullName = (firstName != "" && lastName != "" && otherNames != "") ? (firstName + " " + lastName + "(" + otherNames + ")") : ((firstName == "" && lastName != "" && otherNames != "") ? (lastName + "(" + otherNames + ")") : ((firstName != "" && lastName == "" && otherNames != "") ? (firstName + "(" + otherNames + ")") : ((firstName == "" && lastName == "" && otherNames != "") ? (otherNames) : ((firstName != "" && lastName != "" && otherNames == "") ? (firstName + " " + lastName) : ((firstName != "" && lastName == "" && otherNames == "") ? (firstName) : ((firstName == "" && lastName != "" && otherNames == "") ? (lastName) : ("")))))));
                label1.Text = "Name: " + fullName;
                label2.Text = "ID: " + this.nic;

                textBox1.Clear();
                textBox2.Clear();

                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("Invalid ID found.", "BBMS - Contact Number Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.TextLength >= 3)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.TextLength >= 7)
            {
                button1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.TextLength + textBox2.TextLength == 10)
            {
                if (!new databases.DonorPhoneNumbers().entryCheckout(this.nic, textBox1.Text + textBox2.Text))
                {
                    new databases.DonorPhoneNumbers().donorPhoneNumber(textBox1.Text + textBox2.Text, this.nic);
                    textBox2.Clear();
                    textBox1.Clear();
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show("The entered number is already registered with the same ID number.", "BBMS - Blood Log - Number Registration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_bloodLog bloodlog = new frm_bloodLog();
            bloodlog.Show();
            this.Hide();
        }
    }
}
