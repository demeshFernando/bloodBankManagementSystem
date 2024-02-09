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
    public partial class frm_camps_newCampRegistration_meetingArrangingStep : Form
    {
        private string Id, messageHeader = GlobalAcceass.companyName + " - Meeting Arrangement";

        private void frm_camps_newCampRegistration_meetingArrangingStep_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.lastLeave = "frm_camps_newCampRegistration_meetingArrangingStep";
            textBox2.Text = this.Id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //checking all the entries are provided
            if(textBox1.Text == "")
            {
                MessageBox.Show("You need to add a unique meeting id to proceed.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else if(textBox2.Text == "")
            {
                MessageBox.Show("Please provide a valid camp ID to indicate which camp this meeting belongs to.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Focus();
            }
            else if(textBox3.Text == "")
            {
                MessageBox.Show("Provide a valid reason for this meeting.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
            }
            else if(textBox5.Text == "")
            {
                MessageBox.Show("Meeting helding year is imortant.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.Focus();
            }
            else if(textBox6.Text == "")
            {
                MessageBox.Show("You need to add the meeting helding month correctly.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox6.Focus();
            }
            else if(textBox7.Text == "")
            {
                MessageBox.Show("You need to add the meeting helding day correctly.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox7.Focus();
            }
            else if(textBox8.Text == "")
            {
                MessageBox.Show("You need to add the meeting helding hour correctly in this field.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox8.Focus();
            }
            else if(textBox9.Text == "")
            {
                MessageBox.Show("You need to add the meeting helding minute correctly.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox9.Focus();
            }
            else
            {
                //verifying the provided id is unique
                if(new databases.Meetings().checkId(textBox1.Text) == -1)
                {
                    //checkign whether the provided camp id is already in the database
                    if(new databases.BloodCamps().checkId(textBox2.Text) == 0)
                    {
                        //updating the field
                        new databases.Meetings().arrangeNewMeeting(Properties.Settings.Default.userNIC, textBox4.Text == "" ? "-1" : (textBox4.Text == "Accept" ? "0" : "1"), heldingYear: textBox5.Text, heldingMonth: textBox6.Text, heldingDay: textBox7.Text, heldingHour: textBox8.Text, heldingMinute: textBox9.Text, campID: textBox2.Text, reason: textBox3.Text, createdYear: DateTime.Now.ToString("yyyy"), createdMonth: DateTime.Now.ToString("MM"), createdDay: DateTime.Now.ToString("dd"), createdHour: DateTime.Now.ToString("hh"), createdminute: DateTime.Now.ToString("mm"));
                        //informingt to the user
                        MessageBox.Show("Meeting sceduled succesfully.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    //if the provided campid is not matching
                    else if(new databases.BloodCamps().checkId(textBox2.Text) == -1)
                    {
                        MessageBox.Show("There is no blood camp with this ID registered. First of all register the blood camp and then sceduled the meeting.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox2.Focus();
                    }
                    //if the provided campid has many duplicates
                    else
                    {
                        MessageBox.Show("We are sorry! we cannot register a new blood camp meeting because there are many IDs available with the same camp ID. Please inform this issue with the administrator and solve this. then try again.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //if there is a meeting id already registered
                else if(new databases.Meetings().checkId(textBox1.Text) == 0)
                {
                    MessageBox.Show("There is a meeting id already exist with this id. please provde another one.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //if there are multiple entries with the same id
                else
                {
                    MessageBox.Show("There are multiple records wit the same ID. Please solve that issue and come back again to register the meeting.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //re confirming whethert he user wants to delete the registered blood camp again.
            DialogResult result = MessageBox.Show("Are you sure to delete all the records with this meeing ID?", messageHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if the user wants to delete it all
            if(result.ToString() == "Yes")
            {
                //checkign the camp id
                //if the camp id is available
                if(new databases.BloodCamps().checkId(textBox2.Text) == 0)
                {
                    //deleting the record
                    new databases.BloodCamps().deleteRecords(textBox2.Text, 0);

                    //checking whether the meeting alrady registered.
                    //if the meeting is in there
                    if(new databases.Meetings().checkId(textBox1.Text) == 0)
                    {
                        new databases.Meetings().deleteRecords(textBox2.Text, 0);
                        MessageBox.Show("Camp and meeting scheduling canceled.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        textBox6.Clear();
                        textBox5.Clear();
                        textBox7.Clear();
                        textBox8.Clear();
                        textBox9.Clear();
                        textBox1.Focus();
                    }

                    //if the meeting is not in there
                    else if(new databases.Meetings().checkId(textBox1.Text) == -1)
                    {
                        MessageBox.Show("Camp scheduling was deleted.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //if there are multiple records with the same id
                    else
                    {
                        MessageBox.Show("Camp scheduling was deleted.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if(new databases.BloodCamps().checkId(textBox2.Text) == -1)
                {
                    MessageBox.Show("There are no camps available with this id. please solve this issue with the administrator and try to delete.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("There are many camps available with this id. please solve this issue with the administrator and try to delete.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new generalProcesses().getBackProcess(Properties.Settings.Default.lastLeave);
        }

        public frm_camps_newCampRegistration_meetingArrangingStep(string ID)
        {
            InitializeComponent();
            this.Id = ID;
        }
    }
}
