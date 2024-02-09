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
    public partial class frm_detailedAcessoryDetails : Form
    {
        private string id, messageHeader = GlobalAcceass.companyName + " - Acessory Details";
        List<List<string>> acessoryDetails = new List<List<string>>();
        public frm_detailedAcessoryDetails(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //checking acessory ID
            if (new databases.AcessoryDetails().checkId(id) == 0)
            {
                //loading acessory details
                textBox1.Text = id;
                textBox2.Text = new databases.AcessoryDetails().getAnEntry(id, 0);
                textBox3.Text = new databases.AcessoryDetails().getAnEntry(id, 1);
                textBox4.Text = new databases.AcessoryDetails().getAnEntry(id, 2);
                richTextBox1.Text = new databases.AcessoryDetails().getAnEntry(id, 3);
                textBox5.Text = new databases.AcessoryDetails().getAnEntry(id, 7);
                textBox6.Text = new databases.AcessoryDetails().getAnEntry(id, 6);
                textBox7.Text = new databases.AcessoryDetails().getAnEntry(id, 5);
                textBox10.Text = new databases.AcessoryDetails().getAnEntry(id, 10);
                textBox11.Text = new databases.AcessoryDetails().getAnEntry(id, 9);
                textBox12.Text = new databases.AcessoryDetails().getAnEntry(id, 8);
                textBox13.Text = new databases.AcessoryDetails().getAnEntry(id, 4);

                //loading datagridview
                List<string> columnItems = ["reason", "Reserved By", "Reserved Date", "Want Date", "Description"];
                List<List<string>> tempItems = new databases.AcessoryReservation().getItemsByAcessoryId(this.id, isreason: true, isreservedDay: true, isreservedMonth: true, isreservedYear: true, isreservedHour: true, isreservedMinute: true, iswantYear: true, iswantMonth: true, iswantDay: true, iswantHour: true, iswantMinute: true, isreservedBy: true, isdescription: true);
                List<List<string>> tempItems2 = new List<List<string>>();

                for (int i = 0; i < tempItems.Count; i++)
                {
                    List<string> tempIndexValue = tempItems[i];
                    List<string> tempIndexValue2 = new List<string>();
                    for (int j = 0; j < tempIndexValue.Count; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                tempIndexValue2.Add(tempIndexValue[j]);
                                break;

                            case 1:
                                tempIndexValue2.Add(tempIndexValue[j]);
                                break;

                            case 2:
                                tempIndexValue2.Add(tempIndexValue[j] + "/" + tempIndexValue[j + 1] + "/" + tempIndexValue[j + 2] + " (" + tempIndexValue[j + 3] + ":" + tempIndexValue[j + 4] + ")");
                                break;

                            case 7:
                                tempIndexValue2.Add(tempIndexValue[j] + "/" + tempIndexValue[j = 1] + "/" + tempIndexValue[j + 2] + " (" + tempIndexValue[j + 3] + ":" + tempIndexValue[j + 4] + ")");
                                break;

                            case 12:
                                tempIndexValue2.Add(tempIndexValue[j]);
                                break;

                            default:
                                continue;

                        }
                    }
                    tempItems2.Add(tempIndexValue2);
                }

                dataGridView1.DataSource = new generalProcesses().ListToTable(tempItems2, columnItems);
            }
            else if (new databases.AcessoryDetails().checkId(id) == -1)
            {
                MessageBox.Show("There are no valid ID provided.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("There are many records available with the provided ID. Please contact the administrator regarding this issue.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frm_detailedAcessoryDetails_usageStatistics usage = new frm_detailedAcessoryDetails_usageStatistics(this.id);
            Properties.Settings.Default.lastLeave = "frm_detailedAcessoryDetails";
            usage.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_equipmentRegistration registration = new frm_equipmentRegistration();
            registration.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frm_detailedAcessoryDetails_supplierStatistics supplierDetails = new frm_detailedAcessoryDetails_supplierStatistics(this.id);
            Properties.Settings.Default.lastLeave = "frm_detailedAcessoryDetails";
            supplierDetails.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frm_comparisons compare = new frm_comparisons();
            Properties.Settings.Default.lastLeave = "";
            compare.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frm_detailedAcessoryDetails_Load(object sender, EventArgs e)
        {
            //checking acessory ID
            if(new databases.AcessoryDetails().checkId(id) == 0)
            {
                //loading acessory details
                textBox1.Text = id;
                textBox2.Text = new databases.AcessoryDetails().getAnEntry(id, 0);
                textBox3.Text = new databases.AcessoryDetails().getAnEntry(id, 1);
                textBox4.Text = new databases.AcessoryDetails().getAnEntry(id, 2);
                richTextBox1.Text = new databases.AcessoryDetails().getAnEntry(id, 3);
                textBox5.Text = new databases.AcessoryDetails().getAnEntry(id, 7);
                textBox6.Text = new databases.AcessoryDetails().getAnEntry(id, 6);
                textBox7.Text = new databases.AcessoryDetails().getAnEntry(id, 5);
                textBox10.Text = new databases.AcessoryDetails().getAnEntry(id, 10);
                textBox11.Text = new databases.AcessoryDetails().getAnEntry(id, 9);
                textBox12.Text = new databases.AcessoryDetails().getAnEntry(id, 8);
                textBox13.Text = new databases.AcessoryDetails().getAnEntry(id, 4);

                //loading datagridview
                List<string> columnItems = ["reason", "Reserved By", "Reserved Date", "Want Date", "Description"];
                List<List<string>> tempItems = new databases.AcessoryReservation().getItemsByAcessoryId(this.id, isreason: true, isreservedDay: true, isreservedMonth: true, isreservedYear: true, isreservedHour: true, isreservedMinute: true, iswantYear: true, iswantMonth: true, iswantDay: true, iswantHour: true, iswantMinute: true, isreservedBy: true, isdescription: true);
                List<List<string>> tempItems2 = new List<List<string>>();

                for(int i = 0; i < tempItems.Count; i++)
                {
                    List<string> tempIndexValue = tempItems[i];
                    List<string> tempIndexValue2 = new List<string>();
                    for(int j = 0; j < tempIndexValue.Count; j++)
                    {
                        switch (j)
                        {
                            case 0:
                                tempIndexValue2.Add(tempIndexValue[j]);
                                break;

                            case 1:
                                tempIndexValue2.Add(tempIndexValue[j]);
                                break;

                            case 2:
                                tempIndexValue2.Add(tempIndexValue[j] + "/" + tempIndexValue[j + 1] + "/" + tempIndexValue[j + 2] + " (" + tempIndexValue[j + 3] + ":" + tempIndexValue[j + 4] + ")");
                                break;

                            case 7:
                                tempIndexValue2.Add(tempIndexValue[j] + "/" + tempIndexValue[j = 1] + "/" + tempIndexValue[j + 2] + " (" + tempIndexValue[j + 3] + ":" + tempIndexValue[j + 4] + ")");
                                break;

                            case 12:
                                tempIndexValue2.Add(tempIndexValue[j]);
                                break;

                            default:
                                continue;

                        }
                    }
                    tempItems2.Add(tempIndexValue2);
                }

                dataGridView1.DataSource = new generalProcesses().ListToTable(tempItems2, columnItems);
            }
            else if(new databases.AcessoryDetails().checkId(id) == -1)
            {
                MessageBox.Show("There are no valid ID provided.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("There are many records available with the provided ID. Please contact the administrator regarding this issue.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
