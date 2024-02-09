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
    public partial class frm_acessoryEqupmentAllocation_allocationList : Form
    {
        string messageHeader = GlobalAcceass.companyName + " - Equipment Allocation";
        List<List<string>> mainHeadings = new List<List<string>>();
        List<List<string>> subHeadings = new List<List<string>>();
        string Id = "";
        public frm_acessoryEqupmentAllocation_allocationList()
        {
            InitializeComponent();
        }

        public void majorLoad()
        {
            subHeadings = new databases.AcessoryReservation().getItems();

            //loading the datagridviews
            for (int i = 0; i < subHeadings.Count; i++)
            {
                List<string> consideringIndex = subHeadings[i];
                string consideringId = consideringIndex[1];
                bool isIdAvailable = false;

                //checking whether the got id is already considered or not
                //if i != 0
                if (i != 0)
                {
                    for (int j = 0; j < mainHeadings.Count; j++)
                    {
                        List<string> tempMainEntry = mainHeadings[j];
                        if (tempMainEntry[0] == consideringId)
                        {
                            isIdAvailable = true;
                            break;
                        }
                    }
                }

                //if the considering id is not available.
                if (isIdAvailable)
                {
                    continue;
                }
                else
                {
                    List<string> tempList = new List<string>();
                    int totalQuantity = 0;
                    string itemName = new databases.AcessoryDetails().getAnEntry(consideringId, 0);
                    for (int j = 0; j < subHeadings.Count; j++)
                    {
                        List<string> subList = subHeadings[j];
                        if (consideringId == subList[1])
                        {
                            totalQuantity += int.Parse(subList[15]);
                        }
                    }
                    tempList.Add(consideringId);
                    tempList.Add(itemName);
                    tempList.Add(totalQuantity.ToString());
                    mainHeadings.Add(tempList);
                }
            }

            dataGridView1.DataSource = createMainHeadings();
        }

        public DataTable createMainHeadings()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Acessory ID");
            table.Columns.Add("Item Name");
            table.Columns.Add("Quantity");

            //creating rows
            for (int i = 0; i < mainHeadings.Count; i++)
            {
                DataRow row = table.NewRow();
                List<string> tempList = mainHeadings[i];
                for (int j = 0; j < 3; j++)
                {
                    row[j] = tempList[j];
                }
                table.Rows.Add(row);
            }
            return table;
        }

        public DataTable createSubHeadings()
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID");
            table.Columns.Add("Acessory ID");
            table.Columns.Add("Description");
            table.Columns.Add("Reserved Date");
            table.Columns.Add("Requested Date");
            table.Columns.Add("Resrved By");
            table.Columns.Add("Reason");
            table.Columns.Add("Quantity");

            for (int i = 0; i < subHeadings.Count; i++)
            {
                List<string> tempList = subHeadings[i];
                DataRow row = table.NewRow();
                for (int j = 0; j < 8; j++)
                {
                    switch (j)
                    {
                        case 0:
                            row[0] = tempList[0];
                            break;
                        case 1:
                            row[1] = tempList[1];
                            break;
                        case 2:
                            row[2] = tempList[2];
                            break;
                        case 3:
                            row[3] = tempList[3] + "/" + tempList[4] + "/" + tempList[5] + "(" + tempList[7] + ":" + tempList[6] + ")";
                            break;
                        case 4:
                            row[4] = tempList[8] + "/" + tempList[9] + "/" + tempList[10] + "(" + tempList[12] + ":" + tempList[11] + ")";
                            break;
                        case 5:
                            row[5] = tempList[13];
                            break;
                        case 6:
                            row[6] = tempList[14];
                            break;
                        case 7:
                            row[7] = tempList[15];
                            break;
                        default:
                            continue;
                    }
                }
                table.Rows.Add(row);
            }
            return table;
        }

        private void frm_acessoryEqupmentAllocation_allocationList_Load(object sender, EventArgs e)
        {
            majorLoad();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rows = dataGridView1.Rows[e.RowIndex];
                Id = rows.Cells[0].Value.ToString();
                textBox1.Text = checkBox1.Checked ? Id : rows.Cells[1].Value.ToString();
                
                dataGridView2.DataSource = createSubHeadings();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rows = dataGridView1.Rows[e.RowIndex];
                Id = rows.Cells[0].Value.ToString();
                textBox1.Text = checkBox1.Checked ? Id : rows.Cells[1].Value.ToString();
                List<string> searchingList = new List<string>();

                for(int i = 0; i < subHeadings.Count; i++)
                {
                    List<string> tempList = subHeadings[i];
                    if(tempList[0] == Id)
                    {
                        searchingList = tempList;
                        break;
                    }
                }

                richTextBox1.Text = searchingList[14];
                richTextBox2.Text = searchingList[2];
                textBox2.Text = searchingList[15];
                textBox5.Text = searchingList[8];
                textBox6.Text = searchingList[9];
                textBox7.Text = searchingList[10];
                textBox3.Text = searchingList[12];
                textBox4.Text = searchingList[11];
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView view = new DataView(createMainHeadings());
            //if checkbox is checked
            if (checkBox1.Checked == false)
            {
                view.RowFilter = string.Format("name LIKE '%{0}%'", textBox1.Text);
            }

            //if checkbox is not checked
            else
            {
                view.RowFilter = string.Format("acessoryId LIKE '%{0}%'", textBox1.Text);
            }
            dataGridView1.DataSource = view;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataView view = new DataView(createMainHeadings());
            //if checkbox is checked
            if (checkBox1.Checked == false)
            {
                view.RowFilter = string.Format("name LIKE '%{0}%'", textBox1.Text);
            }

            //if checkbox is not checked
            else
            {
                view.RowFilter = string.Format("acessoryId LIKE '%{0}%'", textBox1.Text);
            }
            dataGridView1.DataSource = view;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show("Are you sure to Change the updated values?", messageHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(confirmation.ToString() == "Yes")
            {
                new databases.AcessoryReservation().updateTable(Id, 0, description: richTextBox2.Text, wantYear: textBox5.Text, wantMonth: textBox6.Text, wantDay: textBox7.Text, wantHour: textBox3.Text, wantMinute: textBox4.Text, quantity: textBox2.Text);
                MessageBox.Show("Record udpated sucessfully.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);

                //creating the state

                //updating the subheadings
                int pastQuantity = 0;
                string acessoryId = "";
                for(int i = 0; i < subHeadings.Count; i++)
                {
                    List<string> consideringItem = subHeadings[i];
                    if(consideringItem[0] == Id)
                    {
                        pastQuantity = int.Parse(consideringItem[15]);
                        acessoryId = consideringItem[1];
                        consideringItem[15] = textBox2.Text;
                        subHeadings[i] = consideringItem;
                    }
                }
                //updating the mainheadings
                for(int i = 0; i < mainHeadings.Count; i++)
                {
                    List<string> consideringIndex = mainHeadings[i];
                    if(consideringIndex[0] == acessoryId)
                    {
                        int newQuantity = pastQuantity - int.Parse(textBox2.Text);
                        consideringIndex[2] = (int.Parse(consideringIndex[2]) + newQuantity).ToString();
                        mainHeadings[i] = consideringIndex;
                    }
                }
                dataGridView1.DataSource = createMainHeadings();
                DataView view = new DataView(createMainHeadings());
                //if checkbox is checked
                if (checkBox1.Checked == false)
                {
                    view.RowFilter = string.Format("name LIKE '%{0}%'", textBox1.Text);
                }

                //if checkbox is not checked
                else
                {
                    view.RowFilter = string.Format("acessoryId LIKE '%{0}%'", textBox1.Text);
                }
                dataGridView1.DataSource = view;
                dataGridView2.DataSource = createSubHeadings();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            majorLoad();
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult confirmation = MessageBox.Show("Are you sure to proceed?", messageHeader, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(confirmation.ToString() == "Yes")
            {
                new databases.AcessoryReservation().deleteItem(Id);
                MessageBox.Show("The entry was deleted sucessfully. Item Id: " + Id, messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);

                //getting rid of that id from the array
                int oldQuantity = 0;
                string acessoryId = "";
                for(int i = 0; i < subHeadings.Count; i++)
                {
                    List<string> tempList = subHeadings[i];
                    if(tempList[0] == Id)
                    {
                        oldQuantity = int.Parse(tempList[15]);
                        acessoryId = tempList[1];
                        subHeadings.Remove(tempList);
                    }
                }

                //getting rid of the main headings
                for(int i = 0; i < mainHeadings.Count; i++)
                {
                    List<string> tempList = mainHeadings[i];
                    if(tempList[0] == acessoryId)
                    {
                        tempList[2] = (int.Parse(tempList[2]) - oldQuantity).ToString();
                        if(tempList[2] == "0")
                        {
                            mainHeadings.Remove(tempList);
                        }
                    }
                }
                majorLoad();
                textBox1.Clear();
                textBox2.Clear();
                richTextBox1.Clear();
                richTextBox2.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
