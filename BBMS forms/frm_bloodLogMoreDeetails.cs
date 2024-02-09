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
    public partial class frm_bloodLogMoreDeetails : Form
    {
        private string id;
        public frm_bloodLogMoreDeetails(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void frm_bloodLogMoreDeetails_Load(object sender, EventArgs e)
        {
            //checking whether the id is correct or not
            if(new databases.BloodLog().checkID(id))
            {
                textBox1.Text = id;
                textBox4.Text = new databases.BloodLog().getAnEntry(id, 0);
                textBox3.Text = new databases.BloodLog().getAnEntry(id, 1);
                textBox2.Text = new databases.Donors().checkName(new databases.BloodLog().getAnEntry(id, 8)) ? (new databases.BloodLog().getAnEntry(id, 8) + "(" + new databases.Donors().getID(new databases.BloodLog().getAnEntry(id, 8)) + ")") : new databases.BloodLog().getAnEntry(id, 8);
                textBox5.Text = new databases.BloodLog().getAnEntry(id, 14) + " ml";
                textBox6.Text = new databases.BloodLog().getAnEntry(id, 15);
                textBox7.Text = (new databases.StaffList().checkID(new databases.BloodLog().getAnEntry(id, 16)) == 1) ? ((new databases.StaffList().getStaffEntry(new databases.BloodLog().getAnEntry(id, 16)).GetValue(1).ToString()) + "(" + new databases.BloodLog().getAnEntry(id, 16) + ")") : new databases.BloodLog().getAnEntry(id, 16);
                textBox10.Text = new databases.BloodLog().getAnEntry(id, 17);
                textBox9.Text = new databases.BloodLog().getAnEntry(id, 18);
                textBox8.Text = (new databases.StaffList().checkID(new databases.BloodLog().getAnEntry(id, 7)) == 1) ? ((new databases.StaffList().getStaffEntry(new databases.BloodLog().getAnEntry(id, 16)).GetValue(1).ToString()) + "(" + new databases.BloodLog().getAnEntry(id, 7) + ")") : new databases.BloodLog().getAnEntry(id, 7);

                textBox12.Text = new databases.BloodLog().getAnEntry(id, 11);
                textBox11.Text = new databases.BloodLog().getAnEntry(id, 10);
                textBox13.Text = new databases.BloodLog().getAnEntry(id, 9);
                textBox15.Text = new databases.BloodLog().getAnEntry(id, 13);
                textBox14.Text = new databases.BloodLog().getAnEntry(id, 12);
                
                textBox16.Text = new databases.BloodLog().getAnEntry(id, 21);
                textBox17.Text = new databases.BloodLog().getAnEntry(id, 20);
                textBox18.Text = new databases.BloodLog().getAnEntry(id, 19);
                label14.Text = (textBox16.Text == "" || textBox16.Text == "0000") ? "False" : "True";

                textBox21.Text = new databases.BloodLog().getAnEntry(id, 4);
                textBox19.Text = new databases.BloodLog().getAnEntry(id, 3);
                textBox23.Text = new databases.BloodLog().getAnEntry(id, 2);
                textBox22.Text = new databases.BloodLog().getAnEntry(id, 5);
                textBox20.Text = new databases.BloodLog().getAnEntry(id, 6);
            }
            else
            {
                MessageBox.Show("There is an error occured during the getting the entry details of the blood log.", "BBMS-Blood Log", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(new databases.BloodLog().checkID(textBox1.Text))
            {
                DialogResult result = MessageBox.Show("Are you sure to proceed with this update. this update cannot be chnage again. so be resposible", "BBMS - Record update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result.ToString() == "Yes")
                {
                    button1.Text = "Checking...";
                    button1.Enabled = false;

                    //checking the name field
                    if(new databases.BloodLog().getAnEntry(this.id, 0) != textBox4.Text)
                    {
                        DialogResult nameChanging = MessageBox.Show("Are you sure to move the name of the current blood type from: " + new databases.BloodLog().getAnEntry(this.id, 0) + " to : " + textBox4.Text + "?", "BBMS - Blood Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(nameChanging.ToString() == "Yes")
                        {
                            new databases.BloodLog().updateEntries(this.id, 1, name: textBox4.Text);
                            button1.Text = "Updated name";
                        }
                    }

                    //checking the blood type
                    if(new databases.BloodLog().getAnEntry(this.id, 1) != textBox3.Text)
                    {
                        DialogResult bloodTypeChanging = MessageBox.Show("Are you sure to change the blood type? from: " + new databases.BloodLog().getAnEntry(this.id, 1) + " to: " + textBox3.Text, "BBMS - Blood Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if(bloodTypeChanging.ToString() == "Yes")
                        {
                            new databases.BloodLog().updateEntries(this.id, 2, bloodType: textBox3.Text);
                            button1.Text = "Updated blood Type";
                        }
                    }

                    //checking the regby details
                    if (new databases.BloodLog().getAnEntry(this.id, 7) != textBox8.Text)
                    {
                        MessageBox.Show("Changing the registered person is not allowed because the system itself register that entry. We will keep it that to maintain the transperancy of this sensitive process.", "BBMS - Blood Log", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox8.Text = new databases.BloodLog().getAnEntry(this.id, 7);
                    }

                    //checking the packet owner
                    if (new databases.BloodLog().getAnEntry(this.id, 8) != textBox2.Text)
                    {
                        DialogResult packetOwner = MessageBox.Show("Are you sure to change the Packet owner be sure of this because this may cause even a death of the patient? from: " + new databases.BloodLog().getAnEntry(this.id, 8) + " to: " + textBox2.Text, "BBMS - Blood Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (packetOwner.ToString() == "Yes")
                        {
                            //checking the id
                            if(new databases.Donors().checkID(textBox2.Text))
                            {
                                new databases.BloodLog().updateEntries(this.id, 9, packetOwner: new databases.Donors().getID(textBox2.Text));
                            }
                            else
                            {
                                new databases.BloodLog().updateEntries(this.id, 9, packetOwner: textBox2.Text);
                            }
                            button1.Text = "Updated Packet Owner";
                        }
                    }

                    //checking the contity field
                    if (new databases.BloodLog().getAnEntry(this.id, 14) != textBox5.Text)
                    {
                        DialogResult contity = MessageBox.Show("Are you sure to change the Contity of the registered blood packet? from: " + new databases.BloodLog().getAnEntry(this.id, 14) + " to: " + textBox5.Text, "BBMS - Blood Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (contity.ToString() == "Yes")
                        {
                            new databases.BloodLog().updateEntries(this.id, 15, contity: textBox5.Text);
                            button1.Text = "Updated Contity";
                        }
                    }

                    //checking the campID field
                    if (new databases.BloodLog().getAnEntry(this.id, 15) != textBox6.Text)
                    {
                        DialogResult campID = MessageBox.Show("Are you sure to change the Camp ID? from: " + new databases.BloodLog().getAnEntry(this.id, 15) + " to: " + textBox6.Text, "BBMS - Blood Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (campID.ToString() == "Yes")
                        {
                            new databases.BloodLog().updateEntries(this.id, 16, campID: textBox6.Text);
                            button1.Text = "Updated Camp ID";
                        }
                    }

                    //checking the taken by field
                    if (new databases.BloodLog().getAnEntry(this.id, 7) != textBox7.Text)
                    {
                        DialogResult takeyBy = MessageBox.Show("Are you sure to change the person who takes the blood type field? from: " + new databases.BloodLog().getAnEntry(this.id, 7) + " to: " + textBox7.Text, "BBMS - Blood Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (takeyBy.ToString() == "Yes")
                        {
                            new databases.BloodLog().updateEntries(this.id, 17, takenBy: textBox7.Text);
                            button1.Text = "Updated Taken ID";
                        }
                    }

                    //checking the packetID field
                    if (new databases.BloodLog().getAnEntry(this.id, 17) != textBox10.Text)
                    {
                        DialogResult packetID = MessageBox.Show("Are you sure to change the Packet ID? from: " + new databases.BloodLog().getAnEntry(this.id, 17) + " to: " + textBox10.Text, "BBMS - Blood Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (packetID.ToString() == "Yes")
                        {
                            new databases.BloodLog().updateEntries(this.id, 18, packetID: textBox10.Text);
                            button1.Text = "Updated Packet ID";
                        }
                    }

                    //checking the city field
                    if (new databases.BloodLog().getAnEntry(this.id, 18) != textBox9.Text)
                    {
                        DialogResult city = MessageBox.Show("Are you sure to change the City where the blood camp held? from: " + new databases.BloodLog().getAnEntry(this.id, 18) + " to: " + textBox9.Text, "BBMS - Blood Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (city.ToString() == "Yes")
                        {
                            new databases.BloodLog().updateEntries(this.id, 19, city: textBox9.Text);
                            button1.Text = "Updated Packet ID";
                        }
                    }

                    //checking the regday, regmonth, regyear, reghour, regminute
                    if ((new databases.BloodLog().getAnEntry(this.id, 2) != textBox21.Text) || (new databases.BloodLog().getAnEntry(this.id, 3) != textBox19.Text) || (new databases.BloodLog().getAnEntry(this.id, 4) != textBox23.Text) || (new databases.BloodLog().getAnEntry(this.id, 5) != textBox22.Text) || (new databases.BloodLog().getAnEntry(this.id, 6) != textBox20.Text))
                    {
                        MessageBox.Show("Changing the registration date is not allowed because the system itself register that entry. We will keep it that to maintain the transperancy of this sensitive process.", "BBMS - Blood Log", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox21.Text = new databases.BloodLog().getAnEntry(this.id, 2);
                        textBox19.Text = new databases.BloodLog().getAnEntry(this.id, 3);
                        textBox23.Text = new databases.BloodLog().getAnEntry(this.id, 4);
                        textBox22.Text = new databases.BloodLog().getAnEntry(this.id, 5);
                        textBox20.Text = new databases.BloodLog().getAnEntry(this.id, 6);
                    }

                    //checking the donday, donMonth, donYear, donhour, donminute
                    if ((new databases.BloodLog().getAnEntry(this.id, 9) != textBox12.Text) || (new databases.BloodLog().getAnEntry(this.id, 10) != textBox11.Text) || (new databases.BloodLog().getAnEntry(this.id, 11) != textBox13.Text) || (new databases.BloodLog().getAnEntry(this.id, 12) != textBox15.Text) || (new databases.BloodLog().getAnEntry(this.id, 13) != textBox14.Text))
                    {
                        DialogResult city = MessageBox.Show("Are you sure to change Donation date related details from the repository? from: " + new databases.BloodLog().getAnEntry(this.id, 9) + "/" + new databases.BloodLog().getAnEntry(this.id, 10) + "/" + new databases.BloodLog().getAnEntry(this.id, 11) + " (" + new databases.BloodLog().getAnEntry(this.id, 12) + ":" + new databases.BloodLog().getAnEntry(this.id, 13) + ") to: " + textBox12.Text + "/" + textBox11.Text + "/" + textBox13.Text + " (" + textBox15.Text + ":" + textBox14.Text + ")", "BBMS - Blood Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (city.ToString() == "Yes")
                        {
                            new databases.BloodLog().updateEntries(this.id, 10, donDay: textBox12.Text);
                            new databases.BloodLog().updateEntries(this.id, 11, donMonth: textBox11.Text);
                            new databases.BloodLog().updateEntries(this.id, 12, donYear: textBox13.Text);
                            new databases.BloodLog().updateEntries(this.id, 13, donHour: textBox15.Text);
                            new databases.BloodLog().updateEntries(this.id, 14, donMinute: textBox14.Text);
                            button1.Text = "Updated Donation dates";
                        }
                    }

                    //checking resday, resmonth, resyear
                    if ((new databases.BloodLog().getAnEntry(this.id, 19) != textBox16.Text) || (new databases.BloodLog().getAnEntry(this.id, 20) != textBox17.Text) || (new databases.BloodLog().getAnEntry(this.id, 21) != textBox18.Text))
                    {
                        DialogResult city = MessageBox.Show("Are you sure to change the Reservation date of this blood group? from: " + new databases.BloodLog().getAnEntry(this.id, 19) + "/" + new databases.BloodLog().getAnEntry(this.id, 20) + "/" + new databases.BloodLog().getAnEntry(this.id, 21) + " to: " + textBox16.Text + "/" + textBox17.Text + "/" + textBox18.Text, "BBMS - Blood Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (city.ToString() == "Yes")
                        {
                            new databases.BloodLog().updateEntries(this.id, 20, resDay: textBox16.Text);
                            new databases.BloodLog().updateEntries(this.id, 21, resMonth: textBox17.Text);
                            new databases.BloodLog().updateEntries(this.id, 22, resYear: textBox18.Text);
                            button1.Text = "Updated Reservation date";
                        }
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            textBox9.Text = "Individual";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //checking whether the blood is already reserved
            bool isReserved = false;

            //if the blood is reserved
            if(new databases.BloodLog().getAnEntry(this.id, 20) != "00")
            {
                DialogResult reRegistrationConfirmation = MessageBox.Show("This category is already registered. Whould you like to update the entries?", "BBMS - Blood Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(reRegistrationConfirmation.ToString() == "Yes")
                {
                    isReserved = false;
                }
                else
                {
                    isReserved = true;
                    textBox16.Text = new databases.BloodLog().getAnEntry(this.id, 19);
                    textBox17.Text = new databases.BloodLog().getAnEntry(this.id, 20);
                    textBox18.Text = new databases.BloodLog().getAnEntry(this.id, 21);
                }
            }

            //if the blood is not reserved
            if (!isReserved)
            {
                if (textBox16.Text == "" || int.Parse(textBox16.Text) == 0)
                {
                    DialogResult faultReserveDateConfirmation = MessageBox.Show("Are you sure to register these dates because this is not a value that can be accepted?", "BBMS - Blood Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (faultReserveDateConfirmation.ToString() == "Yes")
                    {
                        new databases.BloodLog().updateEntries(this.id, 20, resDay: textBox16.Text);
                        new databases.BloodLog().updateEntries(this.id, 21, resMonth: textBox17.Text);
                        new databases.BloodLog().updateEntries(this.id, 22, resYear: textBox18.Text);
                    }
                }
                else
                {
                    new databases.BloodLog().updateEntries(this.id, 20, resDay: textBox16.Text);
                    new databases.BloodLog().updateEntries(this.id, 21, resMonth: textBox17.Text);
                    new databases.BloodLog().updateEntries(this.id, 22, resYear: textBox18.Text);
                }
                label14.Text = "True";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_registerNewBloodReport newBloodGroup = new frm_registerNewBloodReport();
            newBloodGroup.Show();
            Properties.Settings.Default.lastLeave = "frm_registerNewBloodReport";
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //getting the owner details and checking in the database
            if(new databases.Donors().checkName(textBox2.Text) || new databases.Donors().checkID(textBox2.Text))
            {
                string fullName = "";
                if(new databases.Donors().checkName(textBox2.Text))
                {
                    fullName = new databases.Donors().getEntry(new databases.Donors().getID(textBox2.Text), 0) + " " + new databases.Donors().getEntry(new databases.Donors().getID(textBox2.Text), 1);
                }
                else
                {
                    fullName = new databases.Donors().getEntry(textBox2.Text, 0) + " " + new databases.Donors().getEntry(textBox2.Text, 1);
                }

                DialogResult packetOwnerDetails = MessageBox.Show("Donor full Name: " + fullName + "\nAccording to the database donor is registered as a regular blood donor. Whould you like to see more details?", "BBMS - Blood Log", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if(packetOwnerDetails.ToString() == "Yes")
                {
                    frm_donorList list = new frm_donorList();
                    list.Show();
                }
            }
            else if(!(new databases.Donors().checkName(textBox2.Text)))
            {
                DialogResult ownerNameMissing = MessageBox.Show("The entered entry not available as a name or as an ID in the database. That because may be because there are several donors in the database with the same name. try checking manually by visiting to the database. Would you like to visit there?", "BBMS - Blood log", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(ownerNameMissing.ToString() == "Yes")
                {
                    frm_donorList list = new frm_donorList();
                    Properties.Settings.Default.lastLeave = "frm_donorList";
                    list.Show();
                    this.Hide();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(new databases.BloodGroups().getID(textBox3.Text) != "")
            {
                string availableContity = new databases.BloodGroups().getEntry(new databases.BloodGroups().getID(textBox3.Text), 6);
                if(availableContity == "0")
                {
                    MessageBox.Show("There are no contity available in the blood bank with this name.", "BBMS - BLood Log", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("There are available contitiy at: " + availableContity + " in millileters.", "BBMS - blood log", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("There are no Blood id related with the blood name you are entered.", "BBMS - Blood Log", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult removingRegistration = MessageBox.Show("Are you sure to undo the registration form the server. because this action cannot redo again?", "BBMS - Blood Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(removingRegistration.ToString() == "Yes")
            {
                new databases.BloodLog().deleteRecord(this.id);
                MessageBox.Show("The record is deleted.", "BBMS - Blood Log", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frm_bloodLog bloodLog = new frm_bloodLog();
                bloodLog.Show();
                this.Hide();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new generalProcesses().getBackProcess(Properties.Settings.Default.lastLeave);
            this.Hide();
        }
    }
}
