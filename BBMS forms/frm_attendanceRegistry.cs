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
    public partial class frm_attendanceRegistry : Form
    {
        public frm_attendanceRegistry()
        {
            InitializeComponent();
        }

        private DataTable table = new DataTable();
        private string id = "";

        private void frm_attendanceRegistry_Load(object sender, EventArgs e)
        {
            table = new databases.AttendanceRegistry().loadAttendanceRegistry(Properties.Settings.Default.userNIC, 0);
            dataGridView1.DataSource = table;

            textBox1.Clear();
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            checkBox1.Checked = false;
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataView view = new DataView(table);
            //if checkbox is checked
            if (checkBox1.Checked == false)
            {
                view.RowFilter = string.Format("ID LIKE '%{0}%'", textBox1.Text);
                this.id = textBox1.Text;
            }

            //if checkbox is not checked
            else
            {
                view.RowFilter = string.Format("year LIKE '%{0}%'", textBox1.Text);
            }
            dataGridView1.DataSource = view;
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if the id has a proper id
            if(new databases.AttendanceRegistry().checkID(this.id))
            {
                string name = new databases.StaffList().getStaffEntry(this.id).GetValue(1).ToString() + " " + new databases.StaffList().getStaffEntry(this.id).GetValue(2).ToString();
                List<string> contactNumbers = new databases.StaffContactDetails().getContact(this.id);
                if(int.Parse(contactNumbers[0]) == 1)
                {
                    MessageBox.Show(name + ": " + contactNumbers[1], "BBMS - Attendance Registry", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if(int.Parse(contactNumbers[0]) > 1)
                {
                    string numbers = "";
                    for(int i = 1; i < contactNumbers.Count; i++)
                    {
                        numbers += contactNumbers[i];
                    }
                    DialogResult result = MessageBox.Show(name + "\nContact Number: " + numbers + "\nWould you see the details list of that contact?", "BBMS - Attendance Registry", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if(result.ToString() == "Yes")
                    {
                        frm_staffListView listview = new frm_staffListView();
                        Properties.Settings.Default.lastLeave = "frm_staffListView";
                        listview.Show();
                        this.Hide();
                    }
                }
            }

            //if the id has not proper id
            else
            {
                MessageBox.Show("The ID was not properly selected. Please select it correctly.", "BBMS - Attendance Registry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (new databases.AttendanceRegistry().checkID(this.id))
            {
                string name = new databases.StaffList().getStaffEntry(this.id).GetValue(1).ToString() + " " + new databases.StaffList().getStaffEntry(this.id).GetValue(2).ToString();
                List<string> contactNumbers = new databases.StaffContactDetails().getContact(Properties.Settings.Default.userNIC);
                if (new databases.AttendanceRegistry().checkID(this.id))
                {
                    string[] message = { this.id, "" };
                    frm_newMessage messageForm = new frm_newMessage(message);
                    messageForm.Show();
                }
                else
                {
                    MessageBox.Show("The ID was not properly selected. Please select it correctly.", "BBMS - Attendance Registry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                }
            }

            //if the id has not proper id
            else
            {
                MessageBox.Show("The ID was not properly selected. Please select it correctly.", "BBMS - Attendance Registry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //getting attendance count in attendance registry
            int attendanceCount = new databases.AttendanceRegistry().attendanceCount(this.id, DateTime.Now.ToString("MM"));

            //getting leave applications in leave applications which are approved.
            int leaveApplicationCount = new databases.LeaveApplication().leaveApplicationCount(this.id, DateTime.Now.ToString("MM"));

            //if the count is ok
            if(attendanceCount + leaveApplicationCount == new generalProcesses().endDayOfMonth())
            {
                MessageBox.Show("There is no mismatching date found. Which means Every leave was applied formally.", "BBMS - Attendance Registry", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //if there is a mismatching
            else
            {
                //if the count is low
                if(attendanceCount + leaveApplicationCount < new generalProcesses().endDayOfMonth())
                {
                    //getting approvedLeave months
                    List<string> approvedLeaveMonths = new databases.LeaveApplication().getApprovedLeaveDates(this.id, DateTime.Now.ToString("MM"));
                    //getting the attendant dates
                    List<string> attendedDates = new databases.AttendanceRegistry().getAttendanceDates(this.id, DateTime.Now.ToString("MM"));
                    List<int> mismatchingIndexes = new List<int>();

                    int count = 1;
                    while(count <= new generalProcesses().endDayOfMonth())
                    {
                        bool isFound = false;
                        //if the entry is not available
                        if(int.Parse(attendedDates[count - 1][0].ToString() + attendedDates[count - 1][1].ToString()) != count)
                        {
                            //checking whether is it available in the leave application
                            for(int i = 0; i < approvedLeaveMonths.Count; i++)
                            {
                                if (int.Parse(approvedLeaveMonths[i][0].ToString() + approvedLeaveMonths[i][1].ToString()) == count)
                                {
                                    isFound = true;
                                    break;
                                }
                            }

                            if(!isFound){
                                mismatchingIndexes.Add(count);
                            }
                        }

                        count++;
                    }

                    string mismatchingDates = "";
                    for(int i = 0; i < mismatchingIndexes.Count; i++)
                    {
                        mismatchingDates += " " + mismatchingIndexes[i] + "/" + DateTime.Now.ToString("MM") + "/" + DateTime.Now.ToString("yyyy");
                    }
                    DialogResult result = MessageBox.Show("The mismatching dates are found in the selected ID: " + this.id + "\nMismathing Dates are:" + mismatchingDates + ".\nWould you like to see detailed view", "BBMS - Attendance Registry", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if(result.ToString() == "Yes")
                    {
                        frm_ListmismatchingAttendance attendance = new frm_ListmismatchingAttendance();
                        attendance.Show();
                    }
                }

                //if the count exceed the month limits.
                else if(attendanceCount + leaveApplicationCount > new generalProcesses().endDayOfMonth())
                {
                    MessageBox.Show("There is a mistake happned. there are multiple copies or corrupted data fields found in the system.", "BBMS - Attendance Registry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm_staffListView listview = new frm_staffListView();
            Properties.Settings.Default.lastLeave = "frm_staffListView";
            listview.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //if the id is selected properly
            if(new databases.StaffList().checkID(this.id) == 1)
            {
                frm_specificStaffAttendanceDetails attendance = new frm_specificStaffAttendanceDetails(this.id);
                attendance.Show();
            }

            //if the id is not selected properly
            else if(new databases.StaffList().checkID(this.id) == 0)
            {
                MessageBox.Show("Select The ID properly to move furthur.", "BBMS - Attendance Registry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }

            else if(new databases.StaffList().checkID(this.id) == 2)
            {
                MessageBox.Show("There are multiple entries found in the system. Please confirm your higher authority to clean the mess.", "BBMS - Higher Authority", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            generalProcesses processes = new generalProcesses();
            processes.getBackProcess(Properties.Settings.Default.lastLeave);
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView view = new DataView(table);
            //if checkbox is checked
            if (checkBox1.Checked == false)
            {
                view.RowFilter = string.Format("ID LIKE '%{0}%'", textBox1.Text);
                this.id = textBox1.Text;
            }

            //if checkbox is not checked
            else
            {
                view.RowFilter = string.Format("year LIKE '%{0}%'", textBox1.Text);
            }
            dataGridView1.DataSource = view;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rows = dataGridView1.Rows[e.RowIndex];
                this.id = rows.Cells[0].Value.ToString();
                if (checkBox1.Checked == false)
                {
                    textBox1.Text = rows.Cells[1].Value.ToString();
                }
                else
                {
                    textBox1.Text = this.id;
                }
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            table = new databases.AttendanceRegistry().loadAttendanceRegistry(Properties.Settings.Default.userNIC, 2);
            dataGridView1.DataSource = table;

            textBox1.Clear();
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            checkBox1.Checked = false;
            textBox1.Focus();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                table = new databases.AttendanceRegistry().loadAttendanceRegistry(Properties.Settings.Default.userNIC, 0);
                dataGridView1.DataSource = table;

                textBox1.Clear();
                radioButton1.Checked = true;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                checkBox1.Checked = false;
                textBox1.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.Focus();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            table = new databases.AttendanceRegistry().loadAttendanceRegistry(Properties.Settings.Default.userNIC, 1);
            dataGridView1.DataSource = table;

            textBox1.Clear();
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            checkBox1.Checked = false;
            textBox1.Focus();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            table = new databases.AttendanceRegistry().loadAttendanceRegistry(Properties.Settings.Default.userNIC, 3);
            dataGridView1.DataSource = table;

            textBox1.Clear();
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            checkBox1.Checked = false;
            textBox1.Focus();
        }
    }
}
