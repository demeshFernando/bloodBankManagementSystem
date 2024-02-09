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
    public partial class frm_camps_resonShowCase : Form
    {
        //0: manager meeting acceptance
        //1: manager meeting rejection
        //2: doctor meeting acceptance
        //3: doctor meeting rejection
        //4: nurse meeting acceptance
        //5: nurse meeting rejection
        //6: PHI meeting acceptance
        //7: PHI meeting rejection
        //8: manager camp acceptance
        //9: manager camp rejection 
        //10: doctor camp acceptance
        //11: doctor camp rejection
        //12: nurse camp acceptance
        //13: nurse camp rejection
        //14: phi camp acceptance
        //15: phi camp rejection
        string ID, messageHeader = GlobalAcceass.companyName + " - Camp Approval";
        int eventStatus;
        public frm_camps_resonShowCase(string ID, int eventStatus)
        {
            InitializeComponent();
            this.ID = ID;
            this.eventStatus = eventStatus;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //checking whether the needed fillds are empty or not, 
            if(textBox1.Text == "")
            {
                MessageBox.Show("Proper meeting ID required to accept the meeting.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else if(textBox3.Text == "")
            {
                MessageBox.Show("provide a valid status to proceed.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //checking the provdided ID
                if(new databases.Meetings().checkId(textBox1.Text) == 0)
                {
                    new databases.Meetings().updateField(textBox1.Text, personIdentifier: 0, updatingIndex: 3, managerApproval: "8", managerCampRejectionReason: richTextBox1.Text);
                    MessageBox.Show("The record updated successfully.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //if the provided id is not availabe\
                else if(new databases.Meetings().checkId(textBox1.Text) == -1)
                {
                    MessageBox.Show("The provided ID is not available in the system. Please try to provide a valid meeting ID.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);)
                }
                else
                {
                    MessageBox.Show("There are duplicated entries found in the system with the same ID. Please contanct the administrator to solve this issue.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frm_camps_resonShowCase_Load(object sender, EventArgs e)
        {
            //verifying the ID
            if(new databases.Meetings().checkId(this.ID) == 0)
            {
                textBox1.Text = this.ID;
                textBox2.Text = new databases.Meetings().getAnEntry(this.ID, 24);
            }
            else if(new databases.Meetings().checkId(this.ID) == -1)
            {
                MessageBox.Show("There is no valid meeting id provided. Pelase provide a valid meeting ID.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("There are many duplicated values found with the same ID. Contact your administrator to solve this issue.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
