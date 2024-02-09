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
using System.Data;

namespace BBMS_forms
{   
    public partial class frm_camps : Form
    {
        DataTable table = new DataTable();
        public frm_camps()
        {
            InitializeComponent();
        }

        List<List<string>> tableItems = new List<List<string>>();
        private void frm_camps_Load(object sender, EventArgs e)
        {
            List<string> columnsValues = new List<string>();
            columnsValues.Add("ID");
            columnsValues.Add("Requester Name");
            columnsValues.Add("Registered Year");
            columnsValues.Add("Registered Month");
            table = new generalProcesses().ListToTable(new databases.BloodCamps().getRecords(id: true, reqName: true, regYear: true, regMonth: true), columnsValues);
            dataGridView1.DataSource = table;
            textBox4.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                string ID = row.Cells[0].Value.ToString();

                textBox1.Text = ID;
                textBox2.Text = new databases.BloodCamps().getAnEntry(ID, 1);
                textBox3.Text = new databases.BloodCamps().getAnEntry(ID, 13);
                richTextBox1.Text = new databases.BloodCamps().getAnEntry(ID, 2);
                richTextBox2.Text = new databases.Meetings().getAnEntry(ID, 15, true);
                label7.Text = "MD: " + new databases.Meetings().getAnEntry(ID, 2, true);
                label8.Text = "PHI: " + new databases.Meetings().getAnEntry(ID, 4, true);
                label9.Text = "Nurse: " + new databases.Meetings().getAnEntry(ID, 6, true);
                label10.Text = "Doctor: " + new databases.Meetings().getAnEntry(ID, 8, true);
                button1.Text = label7.Text == "MD: Accepted" ? "Reject" : "Accept";
                label12.Text = "MD: " + new databases.Meetings().getAnEntry(ID, 22, true);
                label13.Text = "PHI: " + new databases.Meetings().getAnEntry(ID, 18, true);
                label14.Text = "Nurse: " + new databases.Meetings().getAnEntry(ID, 16, true);
                label15.Text = "Doctor: " + new databases.Meetings().getAnEntry(ID, 20, true);
                button2.Text = label12.Text == "MD: Accepted" ? "Reject" : "Accept";
                linkLabel1.Text = new databases.BloodCamps().getAnEntry(ID, 6) + "/" + new databases.BloodCamps().getAnEntry(ID, 5) + "/" + new databases.BloodCamps().getAnEntry(ID, 4) + " (" + new databases.BloodCamps().getAnEntry(ID, 7) + " : " + new databases.BloodCamps().getAnEntry(ID, 8) + ")";
                linkLabel2.Text = new databases.BloodCamps().getAnEntry(ID, 11) + "/" + new databases.BloodCamps().getAnEntry(ID, 10) + "/" + new databases.BloodCamps().getAnEntry(ID, 9) + " (" + new databases.BloodCamps().getAnEntry(ID, 13) + ")";
                linkLabel3.Text = new databases.Meetings().getAnEntry(ID, 12, true) + "/" + new databases.Meetings().getAnEntry(ID, 11, true) + "/" + new databases.Meetings().getAnEntry(ID, 10, true) + " (" + new databases.Meetings().getAnEntry(ID, 13, true) + " : " + new databases.Meetings().getAnEntry(ID, 14, true) + ")";
                label19.Text = "Registered By: " + new databases.BloodCamps().getAnEntry(ID, 14);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataView view = new DataView(table);
            //if checkbox is checked
            if (radioButton1.Checked == true)
            {
                view.RowFilter = string.Format("ID LIKE '%{0}%'", textBox4.Text);
            }

            //if checkbox is not checked
            else if (radioButton2.Checked == true)
            {
                view.RowFilter = string.Format("reqName LIKE '%{0}%'", textBox4.Text);
            }
            else if (radioButton3.Checked == true)
            {
                view.RowFilter = string.Format("regYear LIKE '%{0}%'", textBox4.Text);
            }
            else
            {
                view.RowFilter = string.Format("ID LIKE '%{0}%'", textBox4.Text);
            }
            dataGridView1.DataSource = view;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //accepting the meeting helding
            if(button1.Text == "Accept")
            {
                new databases.Meetings().AcceptMeeting(textBox1.Text, 0, true);
            }
            else
            {
                new databases.Meetings().AcceptMeeting(textBox1.Text, 1, true);
                frm_camps_meetingRejectionOrApproval meetings = new frm_camps_meetingRejectionOrApproval(textBox1.Text, 0);
                meetings.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //accepting the meeting
            if(button2.Text == "Accept")
            {
                new databases.Meetings().acceptCamp(textBox1.Text, 0, true);
            }
            else
            {
                new databases.Meetings().acceptCamp(textBox1.Text, 1, true);
                frm_camps_meetingRejectionOrApproval meetings = new frm_camps_meetingRejectionOrApproval(textBox1.Text, 4);
                meetings.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_camps_newCampRegistration registration = new frm_camps_newCampRegistration();
            Properties.Settings.Default.lastLeave = "frm_camps_newCampRegistration";
            registration.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Clear();

            List<string> columnsValues = new List<string>();
            columnsValues.Add("ID");
            columnsValues.Add("Requester Name");
            columnsValues.Add("Registered Year");
            columnsValues.Add("Registered Month");
            table = new generalProcesses().ListToTable(new databases.BloodCamps().getRecords(id: true, reqName: true, regYear: true, regMonth: true), columnsValues);
            dataGridView1.DataSource = table;

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            richTextBox1.Clear();
            richTextBox2.Clear();
            label7.Text = "Manager Acceptance";
            label8.Text = "PHI Acceptance";
            label9.Text = "Nurse Accpetance";
            label10.Text = "Doctor Acceptance";
            button1.Text = "Accept";
            label12.Text = "Manager Approval";
            label13.Text = "PHI Approval";
            label14.Text = "Nurse Approval";
            label15.Text = "Doctor Approval";
            button2.Text = "Accept";
            linkLabel1.Text = "yyyy/MM/dd (hh:mm)";
            linkLabel2.Text = "yyyy/MM/dd (hh:mm)";
            linkLabel3.Text = "yyyy/MM/dd (hh:mm)";
            label19.Text = "Registered By";

        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm_camps_arrangedMeetings meetings = new frm_camps_arrangedMeetings(new databases.Meetings().getAnEntry(textBox1.Text, 1, true));
            Properties.Settings.Default.lastLeave = "frm_camps_arrangedMeetings";
            meetings.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new generalProcesses().getBackProcess(Properties.Settings.Default.lastLeave);
            this.Hide();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_camps_meetingDateTime dateTime = new frm_camps_meetingDateTime(textBox1.Text);
            dateTime.Show();
            this.Hide();
        }

        private void label7_MouseClick(object sender, MouseEventArgs e)
        {
            frm_camps_resonShowCase meetings = new frm_camps_resonShowCase(textBox1.Text, 0);
            meetings.Show();
        }

        private void label8_MouseClick(object sender, MouseEventArgs e)
        {
            frm_camps_resonShowCase meetings = new frm_camps_resonShowCase(textBox1.Text, 0);
            meetings.Show();
        }

        private void label9_MouseClick(object sender, MouseEventArgs e)
        {
            frm_camps_resonShowCase meetings = new frm_camps_resonShowCase(textBox1.Text, 0);
            meetings.Show();
        }

        private void label10_MouseClick(object sender, MouseEventArgs e)
        {
            frm_camps_resonShowCase meetings = new frm_camps_resonShowCase(textBox1.Text, 0);
            meetings.Show();
        }

        private void label12_MouseClick(object sender, MouseEventArgs e)
        {
            frm_camps_resonShowCase meetings = new frm_camps_resonShowCase(textBox1.Text, 0);
            meetings.Show();
        }

        private void label13_MouseClick(object sender, MouseEventArgs e)
        {
            frm_camps_resonShowCase meetings = new frm_camps_resonShowCase(textBox1.Text, 0);
            meetings.Show();
        }

        private void label14_MouseClick(object sender, MouseEventArgs e)
        {
            frm_camps_resonShowCase meetings = new frm_camps_resonShowCase(textBox1.Text, 0);
            meetings.Show();
        }

        private void label15_MouseClick(object sender, MouseEventArgs e)
        {
            frm_camps_resonShowCase meetings = new frm_camps_resonShowCase(textBox1.Text, 0);
            meetings.Show();
        }
    }
}
