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
    public partial class frm_camps_meetingRejectionOrApproval : Form
    {
        //editing event items, 
        //editing event, 0: manager rejection status, 1: PHI rejection status, 2: doctor rejection status, 3: nurse rejection Status, 4: manager camp rejection status , 5: doctor camp rejection status, 6: PHI camp rejection status, 7: nurse camp rejection status
        private string ID, messageHeader = GlobalAcceass.companyName + " - Meeting Rejection";
        private int editingEvent;
        public frm_camps_meetingRejectionOrApproval(string ID, int editingEvent)
        {
            InitializeComponent();
            this.ID = ID;
            this.editingEvent = editingEvent;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //checking whether there are any meeting id followed by this.
            if(new databases.Meetings().checkId(textBox1.Text) == 0)
            {
                //updating the entry
                new databases.Meetings().updateField(textBox1.Text, managerRejectionReason: richTextBox1.Text, updatingIndex: 1);
                MessageBox.Show("Record updated succesfully.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(new databases.Meetings().checkId(textBox1.Text) == -1)
            {
                MessageBox.Show("There is no valid meeting ID available to update. Please provide a valid ID", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("There are plentry of records available in the meeting ID that you are provided. Please contact your administrator immediately.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to accept the meeting happening?", messageHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //checking the ID is true
            if(new databases.Meetings().checkId(textBox1.Text) == 0)
            {
                if (result.ToString() == "Yes")
                {
                    //cancelling the rejection and accepting the meeting, 
                    new databases.Meetings().AcceptMeeting(textBox1.Text, 0);
                    new databases.Meetings().updateField(textBox1.Text, 1);
                }
            }
            else if(new databases.Meetings().checkId(textBox1.Text) == -1)
            {
                MessageBox.Show("The provided meeting ID is not available. Please provide a valid id.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("There are multiple entries present with your provided ID. Pelase contact the administrator immediately.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frm_camps_meetingRejectionOrApproval_Load(object sender, EventArgs e)
        {
            //checking whether the given campID is available or not, 
            //if the id is available
            textBox1.Text = this.ID;
            if (new databases.Meetings().checkId(this.ID) == 1)
            {
                //getting the values of the camp
                textBox2.Text = new databases.Meetings().getAnEntry(this.ID, 24);
                richTextBox1.Text = new databases.Meetings().getAnEntry(this.ID, 3);
            }
            //if there is no such kind of things
            else if (new databases.Meetings().checkId(this.ID) == -1)
            {
                MessageBox.Show("The entered ID was not in there. Please enter another ID and follow alogn.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("There are multiple entries followed up with the same meeting ID which seems to be not usual. So pelase contact the administrator and inform about this incident.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
