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

namespace BBMS_forms
{
    public partial class Doctor : Form
    {
        public Doctor()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            this.Text = "Welcome: " + Properties.Settings.Default.userName;
            label1.Text = "";
            label2.Text = "";

            //checking reminders from the database
            string reminderCount = new databases.Reminders().unseenReminders(Properties.Settings.Default.userNIC);
            if (reminderCount != "")
            {
                DialogResult result = MessageBox.Show("There are reminders to be checked. " + reminderCount + ". Would you like to check them?", "BBMS", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (result.ToString() == "Yes")
                {
                    Properties.Settings.Default.lastLeave = "frm_reminders";
                    frm_reminders reminders = new frm_reminders();
                    reminders.Show();
                    this.Hide();
                }
            }
            //showing the last reminder if there is one
            else if (new databases.Reminders().countUnseenReminders(Properties.Settings.Default.userNIC) == 1)
            {
                string[] reminder = new databases.Reminders().getLastUnseenReminder(Properties.Settings.Default.userNIC);
                MessageBox.Show(reminder[0] + "\n" + reminder[1], "BBMS - Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                label1.Text = "Reminder";
                label2.Text = reminder[1];
            }
            else if (new databases.Reminders().countUnseenReminders(Properties.Settings.Default.userNIC) > 1)
            {
                label1.Text = "Reminder(" + new databases.Reminders().countUnseenReminders(Properties.Settings.Default.userNIC) + ")";
                label2.Text = "";
            }

            //cheking messages from the database
            int count = new databases.Messages().unreadMessagesCount(Properties.Settings.Default.userNIC);

            //if the count == 0
            if(count == 0)
            {
                messagesToolStripMenuItem.Text = "Messages";
            }
            else if(count == 1)
            {
                string[] message = new databases.Messages().lastUnseenMessage(Properties.Settings.Default.userNIC);
                if(label1.Text == "" && label2.Text == "")
                {
                    label1.Text = "Message";
                    label2.Text = message[1] + "(" + message[0] + ")";
                }
                else if(label1.Text == "" && label2.Text != "")
                {
                    label1.Text = "Message";
                    label2.Text += ", " + message[1] + "(" + message[0] + ")";
                }
                else if(label1.Text != "" && label2.Text == "")
                {
                    label1.Text += ", Message";
                    label2.Text = message[1] + "(" + message[0] + ")";
                }
                else
                {
                    label1.Text += ", Message";
                    label2.Text += ", " + message[1] + "(" + message[0] + ")";
                }

                messagesToolStripMenuItem.Text = "Messages(1)";
            }
            else
            {
                messagesToolStripMenuItem.Text = "Messages(" + count + ")";
                DialogResult result = MessageBox.Show("You got " + count + " unread messages waiting to show. Whould you like them to see?", "BBMS - Messages", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if(result.ToString() == "Yes")
                {
                    frm_messages messages = new frm_messages();
                    Properties.Settings.Default.lastLeave = "frm_messages";
                    messages.Show();
                    this.Hide();
                }

                if(label1.Text == "")
                {
                    label1.Text = "Messages(" + count + ")";
                }
                else
                {
                    label1.Text += ", Messages(" + count + ")";
                }

                messagesToolStripMenuItem.Text = "Messages(" + count + ")";
            }


            //marking attendance
            //checking the marking of the reminder
            bool isAttended = new databases.AttendanceRegistry().checkAttendance(Properties.Settings.Default.userNIC);

            if (!isAttended)
            {
                new databases.AttendanceRegistry().markAttendance(Properties.Settings.Default.userNIC, DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("hh"), DateTime.Now.ToString("mm"), DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yyyy"));
            }

            timer1.Start();
            
        }

        private void donorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_donorList donors = new frm_donorList();
            donors.Show();
            this.Hide();
        }

        private void registerANewDornorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_newDonorRegistration registration = new frm_newDonorRegistration();
            registration.Show();
            this.Hide();
        }

        private void timetableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_timeTable timetable = new frm_timeTable();
            timetable.Show();
            this.Hide();
        }

        private void newCampRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_requestCamp request = new frm_requestCamp();
            request.Show();
            this.Show();
        }

        private void bloodAviilabilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_bloodStock stock = new frm_bloodStock();
            stock.Show();
            this.Hide();
        }

        private void newPacketRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_acessoryRegistration registration = new frm_acessoryRegistration();
            registration.Show();
            this.Hide();
        }

        private void newBloodReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_registerNewBloodReport report = new frm_registerNewBloodReport();
            report.Show();
            this.Hide();
        }

        private void bloodRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_bloodRequest request = new frm_bloodRequest();
            request.Show();
            this.Hide();
        }

        private void bloodHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_packetHistory history = new frm_packetHistory();
            history.Show();
            this.Hide();
        }

        private void remindersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_reminders reminder = new frm_reminders();
            reminder.Show();
            this.Hide();
        }

        private void messagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_messages messages = new frm_messages();
            messages.Show();
            this.Hide();
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_logHistory history = new frm_logHistory();
            history.Show();
            this.Hide();
        }

        private void phoneRegistryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_phoneRegistry registry = new frm_phoneRegistry();
            registry.Show();
            this.Hide();
        }

        private void tODOListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_todoList todo = new frm_todoList();
            todo.Show();
            this.Hide();
        }

        private void moreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_applyLeave leave = new frm_applyLeave();
            leave.Show();
            this.Hide();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_DoctorSettings settings = new frm_DoctorSettings();
            settings.Show();
            this.Hide();
        }

        private void signOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Login signOut = new Login();
            signOut.Show();
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
                        reminderAlert.Show();
                        label1.Text = "Reminder";
                        label2.Text = new databases.Reminders().getReminderusingID(Properties.Settings.Default.upcomingAlertID).GetValue(1).ToString();
                        isChecked = false;
                    }

                    // if the message is from todo list
                    else if (Properties.Settings.Default.alertReferringTable == "1")
                    {
                        frm_newTodoEvent eventAlert = new frm_newTodoEvent(new databases.Timetable().getEventUsingID(Properties.Settings.Default.upcomingAlertID));
                        eventAlert.Show();
                        label1.Text = "Event";
                        label2.Text = new databases.Timetable().getEventUsingID(Properties.Settings.Default.upcomingAlertID).GetValue(2).ToString();
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

                        //asigning the reminder to the labels
                        if (new databases.Reminders().countUnseenReminders(Properties.Settings.Default.userNIC) == 1)
                        {
                            if (label1.Text == "")
                            {
                                label1.Text = "Reminder";
                            }
                            else if (label1.Text != "")
                            {
                                label1.Text += ", Reminder";
                            }

                            label2.Text = new databases.Reminders().getLastUnseenReminder(Properties.Settings.Default.userNIC).GetValue(1).ToString();
                        }
                    }

                    //need to check the todo list

                    //if there are only one event to show
                    if (new databases.Timetable().unseenEventsCount(Properties.Settings.Default.userNIC) == 1)
                    {
                        frm_newTodoEvent eventAlert = new frm_newTodoEvent(new databases.Timetable().getLastUnseenEvent(Properties.Settings.Default.userNIC));
                        eventAlert.Show();

                        label1.Text = "TODO List";
                        label2.Text = new databases.Timetable().getLastUnseenEvent(Properties.Settings.Default.userNIC).GetValue(2).ToString();
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

                if (new databases.Messages().unreadMessagesCount(Properties.Settings.Default.userNIC) == 1)
                {
                    label1.Text = "Message";

                    label2.Text = new databases.Messages().lastUnseenMessage(Properties.Settings.Default.userNIC).GetValue(1).ToString();
                }

                messagesToolStripMenuItem.Text = "Messages(1)";
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
                messagesToolStripMenuItem.Text = "Messages(" + new databases.Messages().unreadMessagesCount(Properties.Settings.Default.userNIC) + ")";
            }
        }
    }
}
