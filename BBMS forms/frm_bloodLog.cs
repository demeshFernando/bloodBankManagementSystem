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
    public partial class frm_bloodLog : Form
    {
        public frm_bloodLog()
        {
            InitializeComponent();
        }

        DataTable table = new DataTable();
        private string entryID = "";
        private void frm_bloodLog_Load(object sender, EventArgs e)
        {
            //load the data gridview
            table = new databases.BloodLog().loadData();
            dataGridView1.DataSource = table;

            //load filter pallette details
            textBox1.Text = "0000";
            textBox2.Text = "00";
            textBox3.Text = "00";
            textBox4.Text = "0000";
            textBox5.Text = "00";
            textBox6.Text = "00";
            textBox7.Text = "0000";
            textBox8.Text = "00";
            textBox9.Text = "00";

            //load search pallette
            comboBox1.Text = "All";
            comboBox1.Items.Add("All");

            List<string> bloodGroups = new databases.BloodGroups().getBloodGroups();
            for(int i = 0; i < bloodGroups.Count; i++)
            {
                comboBox1.Items.Add(bloodGroups[i]);
            }
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

            //radio button selection
            //button disabling


            //focus the textbox
            textBox10.Clear();
            textBox10.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            DataView view = new DataView(table);
            view.RowFilter = string.Format("resYear LIKE '%{0}%'", textBox7.Text);
            dataGridView1.DataSource = view;

            if (textBox7.TextLength >= 4)
            {
                textBox8.Focus();
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView view = new DataView(table);
            view.RowFilter = string.Format("regYear LIKE '%{0}%'", textBox1.Text);
            dataGridView1.DataSource = view;

            if (textBox1.TextLength >= 4)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataView view = new DataView(table);
            view.RowFilter = string.Format("regMonth LIKE '%{0}%'", textBox2.Text);
            dataGridView1.DataSource = view;

            if (textBox2.TextLength >= 2)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataView view = new DataView(table);
            view.RowFilter = string.Format("regDay LIKE '%{0}%'", textBox3.Text);
            dataGridView1.DataSource = view;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataView view = new DataView(table);
            view.RowFilter = string.Format("donYear LIKE '%{0}%'", textBox4.Text);
            dataGridView1.DataSource = view;

            if (textBox4.TextLength >= 4)
            {
                textBox5.Focus();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataView view = new DataView(table);
            view.RowFilter = string.Format("donMonth LIKE '%{0}%'", textBox5.Text);
            dataGridView1.DataSource = view;

            if (textBox5.TextLength >= 2)
            {
                textBox6.Focus();
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            DataView view = new DataView(table);
            view.RowFilter = string.Format("resMonth LIKE '%{0}%'", textBox8.Text);
            dataGridView1.DataSource = view;

            if (textBox8.TextLength >= 2)
            {
                textBox9.Focus();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rows = dataGridView1.Rows[e.RowIndex];
                this.entryID = rows.Cells[0].Value.ToString();
                if (radioButton1.Checked == true)
                {
                    textBox10.Text = rows.Cells[1].Value.ToString();
                }
                else if(radioButton2.Checked == true)
                {
                    textBox10.Text = this.entryID;
                }
                else if (radioButton3.Checked == true)
                {
                    textBox10.Text = rows.Cells[9].Value.ToString();
                }
                else if (radioButton4.Checked == true)
                {
                    textBox10.Text = rows.Cells[17].Value.ToString();
                }
                else if (radioButton5.Checked == true)
                {
                    textBox10.Text = rows.Cells[18].Value.ToString();
                }
                else if (radioButton6.Checked == true)
                {
                    textBox10.Text = rows.Cells[19].Value.ToString();
                }
                else
                {
                    textBox10.Text = rows.Cells[1].Value.ToString();
                }

                textBox1.Text = rows.Cells[5].Value.ToString();
                textBox2.Text = rows.Cells[4].Value.ToString();
                textBox3.Text = rows.Cells[3].Value.ToString();

                textBox4.Text = rows.Cells[12].Value.ToString();
                textBox5.Text = rows.Cells[11].Value.ToString();
                textBox6.Text = rows.Cells[10].Value.ToString();

                textBox7.Text = rows.Cells[22].Value.ToString();
                textBox8.Text = rows.Cells[21].Value.ToString();
                textBox9.Text = rows.Cells[20].Value.ToString();
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            DataView view = new DataView(table);
            //if checkbox is checked
            if (radioButton1.Checked == true)
            {
                view.RowFilter = string.Format("name LIKE '%{0}%'", textBox10.Text);
                this.entryID = textBox1.Text;
            }

            //if checkbox is not checked
            else if (radioButton2.Checked == true)
            {
                view.RowFilter = string.Format("ID LIKE '%{0}%'", textBox10.Text);
            }
            else if (radioButton3.Checked == true)
            {
                view.RowFilter = string.Format("packetOwner LIKE '%{0}%'", textBox10.Text);
            }
            else if (radioButton4.Checked == true)
            {
                view.RowFilter = string.Format("takenBy LIKE '%{0}%'", textBox10.Text);
            }
            else if (radioButton5.Checked == true)
            {
                view.RowFilter = string.Format("packetID LIKE '%{0}%'", textBox10.Text);
            }
            else if (radioButton6.Checked == true)
            {
                view.RowFilter = string.Format("city LIKE '%{0}%'", textBox10.Text);
            }
            else
            {
                view.RowFilter = string.Format("ID LIKE '%{0}%'", textBox10.Text);
            }
            dataGridView1.DataSource = view;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            DataView view = new DataView(table);
            view.RowFilter = string.Format("donDay LIKE '%{0}%'", textBox6.Text);
            dataGridView1.DataSource = view;
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            DataView view = new DataView(table);
            view.RowFilter = string.Format("resDay LIKE '%{0}%'", textBox9.Text);
            dataGridView1.DataSource = view;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataView view = new DataView(table);
            view.RowFilter = string.Format("bloodType LIKE '%{0}%'", comboBox1.Text);
            dataGridView1.DataSource = view;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataView view = new DataView(table);
            //if checkbox is checked
            if (radioButton1.Checked == true)
            {
                view.RowFilter = string.Format("name LIKE '%{0}%'", textBox10.Text);
                this.entryID = textBox1.Text;
            }

            //if checkbox is not checked
            else if (radioButton2.Checked == true)
            {
                view.RowFilter = string.Format("ID LIKE '%{0}%'", textBox10.Text);
            }
            else if (radioButton3.Checked == true)
            {
                view.RowFilter = string.Format("packetOwner LIKE '%{0}%'", textBox10.Text);
            }
            else if (radioButton4.Checked == true)
            {
                view.RowFilter = string.Format("takenBy LIKE '%{0}%'", textBox10.Text);
            }
            else if (radioButton5.Checked == true)
            {
                view.RowFilter = string.Format("packetID LIKE '%{0}%'", textBox10.Text);
            }
            else if (radioButton6.Checked == true)
            {
                view.RowFilter = string.Format("city LIKE '%{0}%'", textBox10.Text);
            }
            else
            {
                view.RowFilter = string.Format("ID LIKE '%{0}%'", textBox10.Text);
            }
            dataGridView1.DataSource = view;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(new databases.BloodLog().checkID(entryID))
            {
                frm_bloodLogMoreDeetails details = new frm_bloodLogMoreDeetails(this.entryID);
                details.Show();
            }
            else
            {
                MessageBox.Show("Select a proper id to get more details.", "BBMS - Blood log", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_bloodRequestAcceptance acceptance = new frm_bloodRequestAcceptance();
            Properties.Settings.Default.lastLeave = "frm_bloodRequestAcceptance";
            acceptance.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = "Analyzing";
            if (new databases.BloodLog().checkID(entryID))
            {
                //getting the contity
                button4.Text = "Contity: " + new databases.BloodLog().getAnEntry(entryID, 14);
            }
            else
            {
                MessageBox.Show("Select a correct entry to show the contity available.", "BBMS - Blood Log", MessageBoxButtons.OK, MessageBoxIcon.Error);
                button4.Text = "Contity";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //load the data gridview
            table = new databases.BloodLog().loadData();
            dataGridView1.DataSource = table;

            //load filter pallette details
            textBox1.Text = "0000";
            textBox2.Text = "00";
            textBox3.Text = "00";
            textBox4.Text = "0000";
            textBox5.Text = "00";
            textBox6.Text = "00";
            textBox7.Text = "0000";
            textBox8.Text = "00";
            textBox9.Text = "00";

            //load search pallette
            comboBox1.Text = "All";
            comboBox1.Items.Add("All");

            List<string> bloodGroups = new databases.BloodGroups().getBloodGroups();
            for (int i = 0; i < bloodGroups.Count; i++)
            {
                comboBox1.Items.Add(bloodGroups[i]);
            }
            radioButton1.Checked = true;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

            //radio button selection
            //button disabling


            //focus the textbox
            textBox10.Clear();
            textBox10.Focus();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //getting the phone number
            List<string> phoneNumber = new databases.DonorPhoneNumbers().getPhoneNumber(this.entryID);

            //checking whether there is any usable phone numbers
            if (phoneNumber.Count > 0)
            {
                string phoneNumbers = "";
                for (int i = 0; i < phoneNumber.Count; i++)
                {
                    if (phoneNumbers == "")
                    {
                        phoneNumbers = phoneNumber[i];
                    }
                    else
                    {
                        phoneNumbers += ", " + phoneNumber[i];
                    }
                }
                MessageBox.Show("Available Phone Numbers:\n" + phoneNumbers, "BBMS - Blood Log", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult result = MessageBox.Show("There is no valid contact numbers for this person. Whould you like to add one?", "BBMS - Blood Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result.ToString() == "Yes")
                {
                    if(new databases.Donors().checkID(new databases.BloodLog().getAnEntry(this.entryID, 8)))
                    {
                        frm_bloodLogContactNumberRegistration registration = new frm_bloodLogContactNumberRegistration(this.entryID);
                        registration.Show();
                    }
                    else
                    {
                        MessageBox.Show("The selected ID does not have a proper card. Which means he/she is not a registered donor.", "BBMS - Blood Log", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new generalProcesses().getBackProcess(Properties.Settings.Default.lastLeave);
            this.Hide();
        }
    }
}
