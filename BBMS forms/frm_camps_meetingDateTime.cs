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
    public partial class frm_camps_meetingDateTime : Form
    {
        private string ID, messageHeader = GlobalAcceass.companyName + " - Meeting Date and Time";
        public frm_camps_meetingDateTime(string ID)
        {
            InitializeComponent();
            this.ID = ID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //checking if all the entries are followed correctly
            if(textBox1.TextLength < 5 && textBox2.TextLength < 3 && textBox3.TextLength < 3 && textBox4.TextLength < 3 && textBox5.TextLength < 3)
            {
                DialogResult confirmation = MessageBox.Show("Are you sure to change the time of the meeting?", messageHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if(confirmation.ToString() == "Yes")
                {
                    new databases.Meetings().updateField(ID, 0, heldingYear: textBox1.Text, heldingMonth: textBox2.Text, heldingDay: textBox3.Text, heldingHour: textBox4.Text, heldingMinute: textBox5.Text);

                    //informing the head doctor
                    List<string> doctorPostiionId = new databases.staffPosition().positionId("Head Doctor");

                    for(int i = 0; i < doctorPostiionId.Count; i++)
                    {
                        List<string> doctorId = new databases.StaffList().getStaffIDBasedOnPosition(doctorPostiionId[i]);
                        for(int j = 0; j < doctorId.Count; j++)
                        {
                            new databases.Messages().newMessage("Meeting date was chnged by the manager.  Meeting ID: " + textBox1.Text, doctorId[j], Properties.Settings.Default.userNIC, "0", DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("hh"), DateTime.Now.ToString("mm"), "00", "00", "0000", "00", "00", "");
                        }
                    }

                    //informing the Head PHI
                    List<string> phiPostiionId = new databases.staffPosition().positionId("Head PHI");

                    for(int i = 0; i < phiPostiionId.Count; i++)
                    {
                        List<string> phiId = new databases.StaffList().getStaffIDBasedOnPosition(phiPostiionId[i]);
                        for(int j = 0; j < phiId.Count; j++)
                        {
                            new databases.Messages().newMessage("Meetings date was changed by the manager. Meeting ID: " + textBox1.Text, phiId[j], Properties.Settings.Default.userNIC, "0", DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("hh"), DateTime.Now.ToString("mm"), "00", "00", "0000", "00", "00", "");
                        }
                    }

                    //informing to the head nurse
                    List<string> nursePositionId = new databases.staffPosition().positionId("Head Nurse");

                    for(int i = 0; i < nursePositionId.Count; i++)
                    {
                        List<string> nurseId = new databases.StaffList().getStaffIDBasedOnPosition(nursePositionId[i]);
                        for(int j = 0; j < nurseId.Count; j++)
                        {
                            new databases.Messages().newMessage("Meeting date was changed by the manger. Meeting ID: " + textBox1.Text, nurseId[j], Properties.Settings.Default.userNIC, "0", DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("hh"), DateTime.Now.ToString("mm"), "00", "00", "0000", "00", "00", "");
                        }
                    }

                    MessageBox.Show("Record updated sucessfully.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frm_camps_meetingDateTime_Load(object sender, EventArgs e)
        {
            //checking the ID
            if(new databases.Meetings().checkId(ID) == 1)
            {
                textBox1.Text = new databases.Meetings().getAnEntry(ID, 12);
                textBox2.Text = new databases.Meetings().getAnEntry(ID, 11);
                textBox3.Text = new databases.Meetings().getAnEntry(ID, 10);
                textBox4.Text = new databases.Meetings().getAnEntry(ID, 13);
                textBox5.Text = new databases.Meetings().getAnEntry(ID, 14);
            }
            else if(new databases.Meetings().checkId(ID) == -1)
            {
                MessageBox.Show("There is no verified ID related with the provided ID.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
            }
            //if there are many entries are followed
            else if(new databases.Meetings().checkId(ID) > 1)
            {
                MessageBox.Show("There are many entries followed by the provided ID. Please solve the case with the administration and try again.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
