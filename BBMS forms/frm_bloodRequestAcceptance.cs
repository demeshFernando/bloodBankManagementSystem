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
    public partial class frm_bloodRequestAcceptance : Form
    {
        DataTable tableValues = new DataTable();
        string entryID, messageBoxHeader = GlobalAcceass.companyName + " - Blood Request";
        public frm_bloodRequestAcceptance()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frm_bloodRequestAcceptance_Load(object sender, EventArgs e)
        {
            tableValues = new databases.BloodRequest().datagidviewItems();
            dataGridView1.DataSource = tableValues;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataView view = new DataView(tableValues);
            string generalSearchResult = textBox1.Text;
            string requestedBy = textBox2.Text;
            string requestDate = textBox3.Text;
            string wantedDate = textBox4.Text;
            string requestYear = "", requestMonth = "", requestDay = "", wantedYear = "", wantedMonth = "", wantedDay = "";

            if(textBox3.TextLength > 0)
            {
                int count = 0;
                while(requestDate[count].ToString() != "" && count < 4)
                {
                    requestYear += requestDate[count].ToString();
                    count++;
                }
            }
            if(textBox3.TextLength > 5)
            {
                int count = 5;
                while(requestDate[count].ToString() != "" && count < 7)
                {
                    requestMonth += requestDate[count].ToString();
                    count++;
                }
            }
            if(textBox3.TextLength > 8)
            {
                int count = 8;
                while(requestDate[count].ToString() != "" && count < 10)
                {
                    requestDay += requestDate[count].ToString();
                    count++;
                }
            }

            if(textBox4.TextLength > 0)
            {
                int count = 0;
                while(wantedDate[count].ToString() != "" && count < 4)
                {
                    wantedYear += wantedDate[count].ToString();
                    count++;
                }
            }
            if(textBox4.TextLength > 5)
            {
                int count = 5;
                while(wantedDate[count].ToString() != "" && count < 7)
                {
                    wantedMonth += wantedDate[count].ToString();
                    count++;
                }
            }
            if(textBox4.TextLength > 8)
            {
                int count = 8;
                while(wantedDate[count].ToString() != "" && count < 10)
                {
                    wantedDay += wantedDate[count].ToString();
                    count++;
                }
            }

            //the following code need to be added
            dataGridView1.DataSource = view;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_bloodRequest_acceptance_moreDetails moreDetails = new frm_bloodRequest_acceptance_moreDetails(this.entryID);
            moreDetails.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new databases.BloodRequest().acceptRequest(new databases.BloodRequest().getID(textBox1.Text), Properties.Settings.Default.userNIC);
            MessageBox.Show("Blood request accepted", messageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
            frm_bloodrequest_acceptance acceptance = new frm_bloodrequest_acceptance(entryID);
            acceptance.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string contity = new generalProcesses().formalizeNumbers(new databases.BloodGroups().getEntry(new databases.BloodRequest().getEntry(this.entryID, 0), 6));
            MessageBox.Show("Available blood quantity: " + contity + ".", messageBoxHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox6.Text == "")
            {
                DialogResult message = MessageBox.Show("Don't you want to add a reason for the decline?", messageBoxHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(message.ToString() == "Yes")
                {
                    new databases.BloodRequest().declineRequest(new databases.BloodRequest().getID(textBox1.Text), Properties.Settings.Default.userNIC, "");
                }
                else
                {
                    textBox6.Focus();
                }
            }
            else
            {
                new databases.BloodRequest().declineRequest(new databases.BloodRequest().getID(textBox1.Text), Properties.Settings.Default.userNIC, textBox6.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            generalProcesses processes = new generalProcesses();
            processes.getBackProcess(Properties.Settings.Default.lastLeave);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView view = new DataView(tableValues);
            //if checkbox is checked
            if (checkBox1.Checked == false)
            {
                view.RowFilter = string.Format("name LIKE '%{0}%'", textBox1.Text);
                entryID = new databases.BloodRequest().entryCount(name: textBox1.Text) > 1 ? "" : new databases.BloodRequest().getID(textBox1.Text);
            }

            //if checkbox is not checked
            else
            {
                view.RowFilter = string.Format("ID LIKE '%{0}%'", textBox1.Text);
                entryID = textBox1.Text;
            }
            dataGridView1.DataSource = view;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rows = dataGridView1.Rows[e.RowIndex];
                entryID = rows.Cells[0].Value.ToString();
                if (checkBox1.Checked == false)
                {
                    textBox1.Text = rows.Cells[1].Value.ToString();
                }
                else
                {
                    textBox1.Text = entryID;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataView view = new DataView(tableValues);
            view.RowFilter = String.Format("name LIKE '%{0}%'", textBox2.Text);
            dataGridView1.DataSource = view;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string requestedDate = textBox3.Text;
            string yearValue = "", monthValue = "", dayValue = "";

            if(textBox3.TextLength <= 4)
            {
                yearValue = textBox3.Text;
            }
            if (textBox3.TextLength == 4)
            {
                textBox3.Text += "/";
            }
            DataView yearView = new DataView(tableValues);
            yearView.RowFilter = string.Format("reqYear LIKE '%{0}%'", yearValue);
            dataGridView1.DataSource = yearView;

            if (textBox3.TextLength > 5 && textBox3.TextLength < 8)
            {
                monthValue += requestedDate[textBox3.TextLength - 1].ToString(); 
            }
            if(textBox3.TextLength == 5)
            {
                textBox3.Text += "/";
            }
            DataView monthView = new DataView(tableValues);
            monthView.RowFilter = string.Format("reqMonth LIKE '%{0}%'", monthValue);
            dataGridView1.DataSource = monthView;

            if (textBox3.TextLength > 8 && textBox3.TextLength < 11)
            {
                dayValue += requestedDate[textBox3.TextLength - 1].ToString();
            }
            DataView dayView = new DataView(tableValues);
            dayView.RowFilter = string.Format("reqDay LIKE '%{0}%'", dayValue);
            dataGridView1.DataSource = dayView;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string wantedDate = textBox4.Text;
            string yearValue = "", monthValue = "", dayValue = "";

            if (textBox4.TextLength <= 4)
            {
                yearValue = textBox3.Text;
            }
            if (textBox4.TextLength == 4)
            {
                textBox4.Text += "/";
            }
            DataView yearView = new DataView(tableValues);
            yearView.RowFilter = string.Format("reqYear LIKE '%{0}%'", yearValue);
            dataGridView1.DataSource = yearView;

            if (textBox4.TextLength > 5 && textBox4.TextLength < 8)
            {
                monthValue += wantedDate[textBox4.TextLength - 1].ToString();
            }
            if (textBox4.TextLength == 5)
            {
                textBox4.Text += "/";
            }
            DataView monthView = new DataView(tableValues);
            monthView.RowFilter = string.Format("reqMonth LIKE '%{0}%'", monthValue);
            dataGridView1.DataSource = monthView;

            if (textBox4.TextLength > 8 && textBox4.TextLength < 11)
            {
                dayValue += wantedDate[textBox4.TextLength - 1].ToString();
            }
            DataView dayView = new DataView(tableValues);
            dayView.RowFilter = string.Format("reqDay LIKE '%{0}%'", dayValue);
            dataGridView1.DataSource = dayView;
        }
    }
}
