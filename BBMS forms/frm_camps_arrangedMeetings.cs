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
    public partial class frm_camps_arrangedMeetings : Form
    {
        private string ID, messageHeader = GlobalAcceass.companyName + " - Meeting Arrangements";
        public frm_camps_arrangedMeetings(string ID)
        {
            InitializeComponent();
            this.ID = ID;
        }

        private void label10_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to chage the status of the meeting?", messageHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result.ToString() == "Yes"){
                new databases.Meetings().AcceptMeeting(ID, 1);
            }
        }

        private void label18_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to change the meeting status?", messageHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result.ToString() == "Yes")
            {
                new databases.Meetings().acceptCamp(ID, 1);
            }
        }

        private void frm_camps_arrangedMeetings_Load(object sender, EventArgs e)
        {
            //checking whether the ID is a valid meeting id
            if(ID == new databases.Meetings().checkId(ID).ToString())
            {
                //loading deatils to the field provided
                textBox1.Text = ID;
                textBox2.Text = new databases.Meetings().getAnEntry(ID, 24);
                textBox3.Text = new databases.Meetings().getAnEntry(ID, 15);
                textBox4.Text = new databases.Meetings().getAnEntry(ID, 27);
                textBox5.Text = new databases.Meetings().getAnEntry(ID, 26);
                textBox6.Text = new databases.Meetings().getAnEntry(ID, 25);
                textBox7.Text = new databases.Meetings().getAnEntry(ID, 28);
                textBox8.Text = new databases.Meetings().getAnEntry(ID, 29);
                textBox9.Text = new databases.Meetings().getAnEntry(ID, 12);
                textBox10.Text = new databases.Meetings().getAnEntry(ID, 11);
                textBox11.Text = new databases.Meetings().getAnEntry(ID, 10);
                textBox12.Text = new databases.Meetings().getAnEntry(ID, 13);
                textBox13.Text = new databases.Meetings().getAnEntry(ID, 14);
                label10.Text = new databases.Meetings().getAnEntry(ID, 2);
                label11.Text = new databases.Meetings().getAnEntry(ID, 8);
                label12.Text = new databases.Meetings().getAnEntry(ID, 4);
                label13.Text = new databases.Meetings().getAnEntry(ID, 6);
                richTextBox1.Text = new databases.Meetings().getAnEntry(ID, 3);
                richTextBox2.Text = new databases.Meetings().getAnEntry(ID, 9);
                richTextBox3.Text = new databases.Meetings().getAnEntry(ID, 5);
                richTextBox4.Text = new databases.Meetings().getAnEntry(ID, 7);
                label18.Text = new databases.Meetings().getAnEntry(ID, 22);
                label19.Text = new databases.Meetings().getAnEntry(ID, 20);
                label20.Text = new databases.Meetings().getAnEntry(ID, 18);
                label21.Text = new databases.Meetings().getAnEntry(ID, 16);
                richTextBox5.Text = new databases.Meetings().getAnEntry(ID, 23);
                richTextBox6.Text = new databases.Meetings().getAnEntry(ID, 21);
                richTextBox7.Text = new databases.Meetings().getAnEntry(ID, 19);
                richTextBox8.Text = new databases.Meetings().getAnEntry(ID, 17);
                label22.Text = "Registered By: " + new databases.Meetings().getAnEntry(ID, 1);
            }
            //if the meeting id is not valid
            else if(new databases.Meetings().checkId(ID) == -1)
            {
                MessageBox.Show("There is no proper id verification please retry again.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
            }
            //if there are multiple ID with the same ID
            else if(new databases.Meetings().checkId(ID) > 1)
            {
                MessageBox.Show("There are multiple meetings registered with the same ID. Inform the administrator about this.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
            }
        }
    }
}
