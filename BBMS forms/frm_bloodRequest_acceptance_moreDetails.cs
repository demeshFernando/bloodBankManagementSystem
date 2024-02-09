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
    public partial class frm_bloodRequest_acceptance_moreDetails : Form
    {
        private string ID, messageHeader = GlobalAcceass.companyName + " Blood Request";
        public frm_bloodRequest_acceptance_moreDetails(string ID)
        {
            this.ID = ID;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //getting the blood quantity
            int bloodQuantity = int.Parse(new databases.BloodGroups().getEntry(new databases.BloodGroups().getID(new databases.BloodRequest().getEntry(ID, 0)), 6));
            if(bloodQuantity > int.Parse(new databases.BloodRequest().getEntry(ID, 6)))
            {
                MessageBox.Show("There are total quantity of: " + bloodQuantity + ", As per the request the blood can be provided.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(bloodQuantity == int.Parse(new databases.BloodRequest().getEntry(ID, 6)))
            {
                MessageBox.Show("The available blood quantity is matching with the request. Still can be provided but other request in the same category cannot be considered. Please check them out as well.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("There are no enough blood availability in this category that matches with the request.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if the date is not provided matchingly
            if(textBox13.Text == "" || textBox14.Text == "" || textBox15.Text == "")
            {
                MessageBox.Show("Need to provide the correct date format to be proceed.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBox13.TextLength != 4 || textBox14.TextLength != 2 || textBox15.TextLength != 3)
            {
                MessageBox.Show("There are no matching dates provided or they are not valid with the formal accepted date.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //all are perfect
            else
            {
                new databases.BloodRequest().updateTable(ID, 1, sendingYear: textBox13.Text, sendingMonth: textBox14.Text, sendingDay: textBox15.Text);
                MessageBox.Show("The sending dates were updated sucessfully.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox18.Text == "")
            {
                DialogResult confirmation = MessageBox.Show("Are you sure to decline? there is no even a reason for the decline.", messageHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(confirmation.ToString() == "Yes")
                {
                    new databases.BloodRequest().updateTable(ID, 2, decReason: "declined");
                    MessageBox.Show("The request was declined.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                new databases.BloodRequest().updateTable(ID, 2, decReason: textBox18.Text);
                MessageBox.Show("The request was declined.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new databases.BloodRequest().updateTable(ID, 3, sendingYear: textBox13.Text, sendingMonth: textBox14.Text, sendingDay: textBox15.Text);
            MessageBox.Show("The blood request accepted.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new databases.BloodRequest().updateTable(ID, 0, textBox2.Text, textBox16.Text, textBox3.Text, textBox9.Text, textBox8.Text, textBox7.Text, textBox4.Text, textBox12.Text, textBox11.Text, textBox10.Text, textBox6.Text, textBox5.Text, textBox15.Text, textBox14.Text, textBox13.Text, textBox17.Text, textBox18.Text);
            MessageBox.Show("The Records updated succesfully.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show("Are you sure to delete the request?", messageHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(confirmation.ToString() == "Yes")
            {
                new databases.BloodRequest().updateTable(ID, 4);
                MessageBox.Show("The record deleted succesfully.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frm_bloodRequest_acceptance_moreDetails_Load(object sender, EventArgs e)
        {
            //if the id is empty
            if(ID == "")
            {
                MessageBox.Show("There is no valid ID to load details. use the ID field to load the details.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else if(!(new databases.BloodRequest().checkID(ID)))
            {
                MessageBox.Show("Enter a valid ID to proceed.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                textBox1.Text = ID;
                textBox2.Text = new databases.BloodRequest().getEntry(ID, 0);
                textBox3.Text = new databases.BloodRequest().getEntry(ID, 2);
                textBox4.Text = new databases.BloodRequest().getEntry(ID, 6);
                textBox5.Text = new databases.BloodRequest().getEntry(ID, 11);
                textBox6.Text = new databases.BloodRequest().getEntry(ID, 10);
                textBox7.Text = new databases.BloodRequest().getEntry(ID, 5);
                textBox8.Text = new databases.BloodRequest().getEntry(ID, 4);
                textBox9.Text = new databases.BloodRequest().getEntry(ID, 3);
                textBox10.Text = new databases.BloodRequest().getEntry(ID, 9);
                textBox11.Text = new databases.BloodRequest().getEntry(ID, 8);
                textBox12.Text = new databases.BloodRequest().getEntry(ID, 7);
                textBox13.Text = new databases.BloodRequest().getEntry(ID, 14);
                textBox14.Text = new databases.BloodRequest().getEntry(ID, 13);
                textBox15.Text = new databases.BloodRequest().getEntry(ID, 12);
                textBox16.Text = new databases.BloodRequest().getEntry(ID, 1);
                textBox17.Text = new databases.BloodRequest().getEntry(ID, 15);
                textBox18.Text = new databases.BloodRequest().getEntry(ID, 16);
            }
        }
    }
}
