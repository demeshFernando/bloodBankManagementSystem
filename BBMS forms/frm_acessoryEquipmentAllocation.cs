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
    public partial class frm_acessoryEquipmentAllocation : Form
    {
        private string selectedEntryID, messageHeader = GlobalAcceass.companyName + " - Acessory Reservation";
        public frm_acessoryEquipmentAllocation(string selectedEntryID)
        {
            InitializeComponent();
            this.selectedEntryID = selectedEntryID;
        }

        private void frm_acessoryEquipmentAllocation_Load(object sender, EventArgs e)
        {
            DataTable names = new databases.AcessoryDetails().datagidviewItems(Properties.Settings.Default.userNIC, 4);
            for(int i = 0; i < names.Rows.Count; i++)
            {
                for(int j = 0; j < names.Columns.Count; j++)
                {
                    comboBox1.Items.Add(names.Rows[j]);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if there is no id selected
            if(textBox1.Text == "")
            {
                MessageBox.Show("There is no id selected. Or the selected ID is not matching.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                DataTable newItemList = new DataTable();
                for(int i = 0; i < globalStorage.acessoryReservation.Count; i++)
                {
                    for(int j = 0; j < 1; j++)
                    {
                        List<string> row = globalStorage.acessoryReservation[i];
                        if(textBox1.Text == row[j])
                        {
                            globalStorage.acessoryReservation.Remove(row);
                        }
                    }
                }

                //loading the datagrid view
                newItemList.Columns.Add("Id");
                newItemList.Columns.Add("Item Name");
                newItemList.Columns.Add("Quantity");

                for(int i = 0; i < globalStorage.acessoryReservation.Count; i++)
                {
                    DataRow row = newItemList.NewRow();
                    for(int j = 0; j < 3; j++)
                    {
                        List<string> item = globalStorage.acessoryReservation[i];
                        row[j] = item[j];
                    }
                    newItemList.Rows.Add(row);
                }
                dataGridView1.DataSource = newItemList;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if there is not items selected
            if(globalStorage.acessoryReservation.Count == 0)
            {
                MessageBox.Show("There are no items selected from the system to perform any acessory reservation.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //if there is no proper date fixed
            else if(textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Proper wanted date need to be fixed.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //if there is no reason fixed
            else if(textBox5.Text == "")
            {
                MessageBox.Show("Please fix a reason why are you reserving those equipments.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //if all are ok
            else
            {
                for(int i = 0; i < globalStorage.acessoryReservation.Count; i++)
                {
                    List<string> item = globalStorage.acessoryReservation[i];

                    //checking whether the looking quantity is available or not
                    if(int.Parse(new databases.AcessoryDetails().getAnEntry(item[0], 1)) >= int.Parse(textBox6.Text))
                    {
                        //reserving the entry
                        new databases.AcessoryReservation().newAcessoryReservation(item[0], DateTime.Now.ToString("dd"), DateTime.Now.ToString("MM"), DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("mm"), DateTime.Now.ToString("hh"), textBox4.Text, textBox3.Text, textBox2.Text, "", "", Properties.Settings.Default.userNIC, textBox5.Text, item[2]);

                        //udpating the inventory
                        int newQuantity = int.Parse(new databases.AcessoryDetails().getAnEntry(item[0], 1)) - int.Parse(item[2]);
                        new databases.AcessoryDetails().updateAnEntry(item[0], 1, quantity: newQuantity.ToString());
                    }
                    else
                    {
                        MessageBox.Show("There is not enough items in " + item[1] + " Please update the inventory or reduce the requesting quantity and reserve the item.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //clearance of globalstorage
                globalStorage.acessoryReservation.RemoveRange(0, globalStorage.acessoryReservation.Count - 1);

                MessageBox.Show("Acessory reservation sucessfully completed for available items.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new generalProcesses().getBackProcess(Properties.Settings.Default.lastLeave);
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_acessoryEqupmentAllocation_allocationList allocationList = new frm_acessoryEqupmentAllocation_allocationList();
            allocationList.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if the item is selected
            //checkign whether the item is available or not
            if(comboBox1.Text == "")
            {
                MessageBox.Show("Please select an item to proceed", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }

            //if the item is not selected
            else if(new databases.AcessoryDetails().checkId(textBox1.Text) == 1)
            {
                DataTable reserveditems = new DataTable();
                List<string> item = new List<string>();
                item.Add(textBox1.Text);
                item.Add(comboBox1.Text);
                item.Add(textBox6.Text);
                globalStorage.acessoryReservation.Add(item);

                //loading the datagrid view
                reserveditems.Columns.Add("Id");
                reserveditems.Columns.Add("Item Name");
                reserveditems.Columns.Add("Quantity");

                for (int i = 0; i < globalStorage.acessoryReservation.Count; i++)
                {
                    DataRow row = reserveditems.NewRow();
                    for (int j = 0; j < 3; j++)
                    {
                        List<string> newItems = globalStorage.acessoryReservation[i];
                        row[j] = newItems[j];
                    }
                    reserveditems.Rows.Add(row);
                }
                dataGridView1.DataSource = reserveditems;
            }

            //if any other error occured
            else
            {
               MessageBox.Show("There is an unknow error occured in the system. Please try again", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
