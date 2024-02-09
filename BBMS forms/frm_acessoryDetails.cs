using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using BBMS_forms.packages;
using System.Data;

namespace BBMS_forms
{
    public partial class frm_acessoryDetails : Form
    {
        public frm_acessoryDetails()
        {
            InitializeComponent();
        }

        private string idOfSelectedDatagridviewEntry = "";
        DataTable table = new DataTable();
        private void frm_acessoryDetails_Load(object sender, EventArgs e)
        {
            table = new databases.AcessoryDetails().datagidviewItems(Properties.Settings.Default.userNIC, 0);
            dataGridView1.DataSource = table;
            radioButton1.Checked = true;
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if the check box is checked
            if(idOfSelectedDatagridviewEntry != "")
            {
                int entryCount = new databases.AcessoryDetails().checkAvailableEntries(idOfSelectedDatagridviewEntry);

                if(entryCount == 1)
                {
                    frm_detailedAcessoryDetails acessoryDetails = new frm_detailedAcessoryDetails(idOfSelectedDatagridviewEntry);
                    acessoryDetails.Show();
                }
                else if(entryCount > 1)
                {
                    MessageBox.Show("There are many entries found with the same id you have entered. Please contact the admin to check the error.", "BBMS - Acessory details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("The string you are entered is not matched with the database entries. Please check the string you entered is correct or not.", "BBMS - Acessory Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //if the checkbox is not checked
            else
            {
                MessageBox.Show("Select an entry or enter the correct ID number or the name of the acessory to view the detailed description of details.", "BBMS - Acessory Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //checking whether there is an id selected
            if(idOfSelectedDatagridviewEntry != "")
            {
                int entryCount = new databases.AcessoryDetails().checkAvailableEntries(idOfSelectedDatagridviewEntry);
                if(entryCount == 1)
                {
                    frm_acessoryEquipmentAllocation equipmentAllocation = new frm_acessoryEquipmentAllocation(idOfSelectedDatagridviewEntry);
                    equipmentAllocation.Show();
                }
                else if(entryCount == 0)
                {
                    MessageBox.Show("There is no entry related with the selected entry. Please chose an entry which matches with the entry.", "BBMS - acessory details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("There is no entries in here. Please select an entry to move.", "BBMS - Acessory details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //checking whether there is no id
            else
            {
                MessageBox.Show("There is no entries in here. Please select an entry to move.", "BBMS - Acessory details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Something occured during the process", "BBMS", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //getting the equipment ID
            if(idOfSelectedDatagridviewEntry != "")
            {
                //checking whether tehre is any equpment related to the got id
                int entryCount = new databases.AcessoryDetails().checkAvailableEntries(idOfSelectedDatagridviewEntry);
                if(entryCount == 1)
                {
                    //getting the supplier id and other contact details and displaying them
                    MessageBox.Show("Supplier Name: " + new databases.OutsideContacts().getEntry(new databases.AcessoryDetails().getAnEntry(idOfSelectedDatagridviewEntry, 2), 2) + "\nRegistered Date: " + new databases.OutsideContacts().getEntry(new databases.AcessoryDetails().getAnEntry(idOfSelectedDatagridviewEntry, 2), 5) + "/" + new databases.OutsideContacts().getEntry(new databases.AcessoryDetails().getAnEntry(idOfSelectedDatagridviewEntry, 2), 6) + "/" + new databases.OutsideContacts().getEntry(new databases.AcessoryDetails().getAnEntry(idOfSelectedDatagridviewEntry, 2), 7) + "\nContact Number: " + new databases.OutsideNumbers().getEntry(new databases.AcessoryDetails().getAnEntry(idOfSelectedDatagridviewEntry, 2), 0), "BBMS - Contact Numbers", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if(entryCount == 0)
                {
                    MessageBox.Show("There is no equipment related to the ID you are chosen.", "BBMS - Acessory details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("There is an error occured in the system. Please try again with the right ID or name.", "BBMS - acessory details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(idOfSelectedDatagridviewEntry == "")
            {
                MessageBox.Show("There is an error occured in the system. Please try again with the right ID or name.", "BBMS - acessory details", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm_acessoryRegistration registration = new frm_acessoryRegistration();
            BBMS_forms.Properties.Settings.Default.lastLeave = "frm_acessoryRegistration";
            registration.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            generalProcesses processes = new generalProcesses();
            processes.getBackProcess(BBMS_forms.Properties.Settings.Default.lastLeave);
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bool isChecked = false;

            if (isChecked)
            {
                if ((Properties.Settings.Default.upcomingAlertYear == DateTime.Now.ToString("yyyy")) && (Properties.Settings.Default.upcomingAlertMonth == DateTime.Now.ToString("MM")) && (Properties.Settings.Default.upcomingAlertDay == DateTime.Now.ToString("dd")) && (Properties.Settings.Default.upcomingAlertHour == ((DateTime.Now.ToString("tt").ToLower() == "am") ? (DateTime.Now.ToString("hh")) : ((int.Parse(DateTime.Now.ToString("hh")) + 12).ToString()))) && (Properties.Settings.Default.upcomingAlertMinute == "mm"))
                {
                    //if the message is from the reminder
                    if (Properties.Settings.Default.alertReferringTable == "0")
                    {
                        frm_newReminder reminderAlert = new frm_newReminder(new databases.Reminders().getReminderusingID(Properties.Settings.Default.upcomingAlertID));
                        isChecked = false;
                    }

                    // if the message is from todo list
                    else if (Properties.Settings.Default.alertReferringTable == "1")
                    {
                        frm_newTodoEvent eventAlert = new frm_newTodoEvent(new databases.Timetable().getEventUsingID(Properties.Settings.Default.upcomingAlertID));
                        eventAlert.Show();
                        isChecked = false;
                    }
                }
                else if ((int.Parse(Properties.Settings.Default.upcomingAlertYear) < int.Parse(DateTime.Now.ToString("yyyy"))) || ((int.Parse(Properties.Settings.Default.upcomingAlertYear) < int.Parse(DateTime.Now.ToString("yyyy")))) && ((int.Parse(Properties.Settings.Default.upcomingAlertMonth) < int.Parse(DateTime.Now.ToString("MM")))) || ((int.Parse(Properties.Settings.Default.upcomingAlertYear) < int.Parse(DateTime.Now.ToString("yyyy")))) && ((int.Parse(Properties.Settings.Default.upcomingAlertMonth) < int.Parse(DateTime.Now.ToString("MM")))) && ((int.Parse(Properties.Settings.Default.upcomingAlertDay) < int.Parse(DateTime.Now.ToString("dd")))) || (((int.Parse(Properties.Settings.Default.upcomingAlertYear) < int.Parse(DateTime.Now.ToString("yyyy")))) && ((int.Parse(Properties.Settings.Default.upcomingAlertMonth) < int.Parse(DateTime.Now.ToString("MM")))) && ((int.Parse(Properties.Settings.Default.upcomingAlertDay) < int.Parse(DateTime.Now.ToString("dd")))) && (int.Parse(Properties.Settings.Default.upcomingAlertHour) < ((DateTime.Now.ToString("tt").ToLower() == "am") ? (int.Parse(DateTime.Now.ToString("hh"))) : (int.Parse(DateTime.Now.ToString("hh")) + 12)))) || ((int.Parse(Properties.Settings.Default.upcomingAlertYear) < int.Parse(DateTime.Now.ToString("yyyy"))) && (int.Parse(Properties.Settings.Default.upcomingAlertMonth) < int.Parse(DateTime.Now.ToString("MM"))) && (int.Parse(Properties.Settings.Default.upcomingAlertDay) < int.Parse(DateTime.Now.ToString("dd"))) && (int.Parse(Properties.Settings.Default.upcomingAlertHour) < ((DateTime.Now.ToString("tt").ToLower() == "am") ? (int.Parse(DateTime.Now.ToString("hh"))) : (int.Parse(DateTime.Now.ToString("hh")) + 12))) && ((int.Parse(Properties.Settings.Default.upcomingAlertMinute) < int.Parse(DateTime.Now.ToString("mm"))))))
                {
                    //need to check about the reminder 
                    //checking whether there are any reminders to set today.
                    string[] reminders = new databases.Reminders().unseenRemindersList(Properties.Settings.Default.userNIC);

                    if (reminders[0] != "")
                    {
                        frm_newReminder reminderAlert = new frm_newReminder(reminders);
                        reminderAlert.Show();
                    }

                    //need to check the todo list

                    //if there are only one event to show
                    if (new databases.Timetable().unseenEventsCount(Properties.Settings.Default.userNIC) == 1)
                    {
                        frm_newTodoEvent eventAlert = new frm_newTodoEvent(new databases.Timetable().getLastUnseenEvent(Properties.Settings.Default.userNIC));
                        eventAlert.Show();
                    }

                    //if there are many events to be seen
                    else if (new databases.Timetable().unseenEventsCount(Properties.Settings.Default.userNIC) > 1)
                    {
                        DialogResult result = MessageBox.Show("There are many event to shown here. Would you like to see them?", "BBMS - Event Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                        if (result.ToString() == "Yes")
                        {
                            frm_todoList list = new frm_todoList();
                            Properties.Settings.Default.lastLeave = "frm_todoList";
                            list.Show();
                            this.Hide();
                        }
                    }
                    isChecked = false;
                }
            }

            else
            {
                //getting upcoming events
                //getting the reminder details
                string[] reminder = new databases.Reminders().getReminderusingID(new databases.Reminders().upcomingReminder(Properties.Settings.Default.userNIC));

                //getting todo list
                string[] todoEvent = new databases.Timetable().getEventUsingID(new databases.Timetable().upcomingEvent(Properties.Settings.Default.userNIC));

                //if the there is reminder to check and no events
                if (reminder != null && todoEvent == null)
                {
                    Properties.Settings.Default.upcomingAlertYear = reminder[3];
                    Properties.Settings.Default.upcomingAlertMonth = reminder[4];
                    Properties.Settings.Default.upcomingAlertDay = reminder[5];
                    Properties.Settings.Default.upcomingAlertHour = reminder[6];
                    Properties.Settings.Default.upcomingAlertMinute = reminder[7];
                    Properties.Settings.Default.upcomingAlertID = reminder[2];
                    Properties.Settings.Default.alertReferringTable = "0";
                }

                //if there is no reminders and has an event
                else if (reminder == null && todoEvent != null)
                {
                    Properties.Settings.Default.upcomingAlertYear = todoEvent[10];
                    Properties.Settings.Default.upcomingAlertMonth = todoEvent[9];
                    Properties.Settings.Default.upcomingAlertDay = todoEvent[8];
                    Properties.Settings.Default.upcomingAlertHour = todoEvent[11];
                    Properties.Settings.Default.upcomingAlertMinute = todoEvent[12];
                    Properties.Settings.Default.upcomingAlertID = todoEvent[0];
                    Properties.Settings.Default.alertReferringTable = "1";
                }

                //if there is a reminder and an event
                else if (reminder != null && todoEvent != null)
                {
                    //if the reminder has the first priority in years
                    if (int.Parse(reminder[3]) < int.Parse(todoEvent[10]))
                    {
                        Properties.Settings.Default.upcomingAlertYear = reminder[3];
                        Properties.Settings.Default.upcomingAlertMonth = reminder[4];
                        Properties.Settings.Default.upcomingAlertDay = reminder[5];
                        Properties.Settings.Default.upcomingAlertHour = reminder[6];
                        Properties.Settings.Default.upcomingAlertMinute = reminder[7];
                        Properties.Settings.Default.upcomingAlertID = reminder[2];
                        Properties.Settings.Default.alertReferringTable = "0";
                    }

                    //if the reminder has the first priority in months
                    else if ((reminder[3] == todoEvent[10]) && ((int.Parse(reminder[4])) < (int.Parse(todoEvent[9]))))
                    {
                        Properties.Settings.Default.upcomingAlertYear = reminder[3];
                        Properties.Settings.Default.upcomingAlertMonth = reminder[4];
                        Properties.Settings.Default.upcomingAlertDay = reminder[5];
                        Properties.Settings.Default.upcomingAlertHour = reminder[6];
                        Properties.Settings.Default.upcomingAlertMinute = reminder[7];
                        Properties.Settings.Default.upcomingAlertID = reminder[2];
                        Properties.Settings.Default.alertReferringTable = "0";
                    }

                    //if the reminder has the first priority in day
                    else if ((reminder[3] == todoEvent[10]) && (reminder[9] == todoEvent[4]) && (int.Parse(reminder[5]) < int.Parse(todoEvent[8])))
                    {
                        Properties.Settings.Default.upcomingAlertYear = reminder[3];
                        Properties.Settings.Default.upcomingAlertMonth = reminder[4];
                        Properties.Settings.Default.upcomingAlertDay = reminder[5];
                        Properties.Settings.Default.upcomingAlertHour = reminder[6];
                        Properties.Settings.Default.upcomingAlertMinute = reminder[7];
                        Properties.Settings.Default.upcomingAlertID = reminder[2];
                        Properties.Settings.Default.alertReferringTable = "0";
                    }

                    //if the reminder has the first priority in hour
                    else if ((reminder[3] == todoEvent[10]) && (reminder[9] == todoEvent[4]) && (reminder[5] == todoEvent[8]) && (int.Parse(reminder[6]) < int.Parse(todoEvent[11])))
                    {
                        Properties.Settings.Default.upcomingAlertYear = reminder[3];
                        Properties.Settings.Default.upcomingAlertMonth = reminder[4];
                        Properties.Settings.Default.upcomingAlertDay = reminder[5];
                        Properties.Settings.Default.upcomingAlertHour = reminder[6];
                        Properties.Settings.Default.upcomingAlertMinute = reminder[7];
                        Properties.Settings.Default.upcomingAlertID = reminder[2];
                        Properties.Settings.Default.alertReferringTable = "0";
                    }

                    //if the reminder has the first priority in minute 
                    else if ((reminder[3] == todoEvent[10]) && (reminder[9] == todoEvent[4]) && (reminder[5] == todoEvent[8]) && (reminder[6] == todoEvent[11]) && (int.Parse(reminder[7]) < int.Parse(todoEvent[12])))
                    {
                        Properties.Settings.Default.upcomingAlertYear = reminder[3];
                        Properties.Settings.Default.upcomingAlertMonth = reminder[4];
                        Properties.Settings.Default.upcomingAlertDay = reminder[5];
                        Properties.Settings.Default.upcomingAlertHour = reminder[6];
                        Properties.Settings.Default.upcomingAlertMinute = reminder[7];
                        Properties.Settings.Default.upcomingAlertID = reminder[2];
                        Properties.Settings.Default.alertReferringTable = "0";
                    }

                    //todo has the first priority
                    else
                    {
                        Properties.Settings.Default.upcomingAlertYear = todoEvent[10];
                        Properties.Settings.Default.upcomingAlertMonth = todoEvent[9];
                        Properties.Settings.Default.upcomingAlertDay = todoEvent[8];
                        Properties.Settings.Default.upcomingAlertHour = todoEvent[11];
                        Properties.Settings.Default.upcomingAlertMinute = todoEvent[12];
                        Properties.Settings.Default.upcomingAlertID = todoEvent[0];
                        Properties.Settings.Default.alertReferringTable = "1";
                    }
                }
                isChecked = true;
            }

            //need to check messages
            if (new databases.Messages().unreadMessagesCount(Properties.Settings.Default.userNIC) == 1)
            {
                string[] messages = new databases.Messages().lastUnseenMessage(Properties.Settings.Default.userNIC);
                frm_newMessage messageAlert = new frm_newMessage(messages);
                messageAlert.Show();
            }
            else if (new databases.Messages().unreadMessagesCount(Properties.Settings.Default.userNIC) > 1)
            {
                DialogResult result = MessageBox.Show("There are " + new databases.Messages().unreadMessagesCount(Properties.Settings.Default.userNIC) + " unread messages to be read. Would You like to look at them?", "BBMS - Messages", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result.ToString() == "Yes")
                {
                    frm_messages messages = new frm_messages();
                    Properties.Settings.Default.lastLeave = "frm_messages";
                    messages.Show();
                    this.Hide();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView view = new DataView(table);
            //if checkbox is checked
            if(checkBox1.Checked == false)
            {
                view.RowFilter = string.Format("name LIKE '%{0}%'", textBox1.Text);
            }

            //if checkbox is not checked
            else
            {
                view.RowFilter = string.Format("ID LIKE '%{0}%'", textBox1.Text);
            }
            dataGridView1.DataSource = view;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Focus();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            table = new databases.AcessoryDetails().datagidviewItems(Properties.Settings.Default.userNIC, 0);
            dataGridView1.DataSource = table;
            radioButton1.Checked = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                table = new databases.AcessoryDetails().datagidviewItems(Properties.Settings.Default.userNIC, 0);
                dataGridView1.DataSource = table;
            }
        }

        private void tableLayoutPanel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                table = new databases.AcessoryDetails().datagidviewItems(Properties.Settings.Default.userNIC, 1);
                dataGridView1.DataSource = table;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                table = new databases.AcessoryDetails().datagidviewItems(Properties.Settings.Default.userNIC, 2);
                dataGridView1.DataSource = table;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                table = new databases.AcessoryDetails().datagidviewItems(Properties.Settings.Default.userNIC, 3);
                dataGridView1.DataSource = table;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow rows = dataGridView1.Rows[e.RowIndex];
                idOfSelectedDatagridviewEntry = rows.Cells[0].Value.ToString();
                if(checkBox1.Checked == false)
                {
                    textBox1.Text = rows.Cells[1].Value.ToString();
                }
                else
                {
                    textBox1.Text = idOfSelectedDatagridviewEntry;
                }
            }
        }
    }
}
