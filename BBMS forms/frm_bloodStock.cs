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
    public partial class frm_bloodStock : Form
    {
        List<List<string>> bloodStreams = new List<List<string>>();
        List<List<string>> bloodLog = new List<List<string>>();
        string entryID = "";
        public frm_bloodStock()
        {
            InitializeComponent();
        }

        private void frm_bloodStock_Load(object sender, EventArgs e)
        {
            bloodStreams = new databases.BloodGroups().getValues();
            bloodLog = new databases.BloodLog().getItems(Id: true, name: true, bloodType: true, regDay: true, regMonth: true, regYear: true, regHour: true, regMinute: true, regBy: true, takenBy: true);

            DataTable bloodGroups = new DataTable();
            bloodGroups.Columns.Add("ID");
            bloodGroups.Columns.Add("Name");
            bloodGroups.Columns.Add("Reg Year");
            bloodGroups.Columns.Add("Quantity");

            for(int i = 0; i < bloodStreams.Count; i++)
            {
                List<string> tempList = bloodStreams[i];
                DataRow row = bloodGroups.NewRow();
                for(int j = 0; j < tempList.Count; j++)
                {
                    switch (j)
                    {
                        case 0:
                            row[j] = tempList[j];
                            break;

                        case 1:
                            row[j] = tempList[j];
                            break;

                        case 2:
                            row[j] = tempList[j] + "/" + tempList[j + 1] + "/" + tempList[j + 2];
                            break;

                        case 5:
                            row[j] = tempList[j];
                            break;

                        default:
                            continue;
                    }
                }
                bloodGroups.Rows.Add(row);
            }
            dataGridView1.DataSource = bloodGroups;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rows = dataGridView1.Rows[e.RowIndex];
                entryID = rows.Cells[0].Value.ToString();
                DataTable table = new DataTable();
                table.Columns.Add("ID");
                table.Columns.Add("Name");
                table.Columns.Add("Blood Type");
                table.Columns.Add("Registered Date");
                table.Columns.Add("Registratered By");
                table.Columns.Add("Taken By");

                for(int i = 0; i < bloodStreams.Count; i++)
                {
                    List<string> tempList = bloodStreams[i];

                    if(tempList[0] == entryID)
                    {
                        DataRow row = table.NewRow();
                        for (int j = 0; j < tempList.Count; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                    row[j] = tempList[j];
                                    break;

                                case 1:
                                    row[j] = tempList[j];
                                    break;

                                case 2:
                                    row[j] = tempList[j];
                                    break;

                                case 3:
                                    row[j] = tempList[j] + "/" + tempList[j + 1] + "/" + tempList[j + 2] + " (" + tempList[j + 3] + ":" + tempList[j + 4] + ")";
                                    break;

                                case 7:
                                    row[j] = tempList[j];
                                    break;

                                case 8:
                                    row[j] = tempList[j];
                                    break;

                                default:
                                    continue;
                            }
                        }
                        table.Rows.Add(row);
                    }
                }
                dataGridView2.DataSource = table;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bloodStreams = new databases.BloodGroups().getValues();
            bloodLog = new databases.BloodLog().getItems(Id: true, name: true, bloodType: true, regDay: true, regMonth: true, regYear: true, regHour: true, regMinute: true, regBy: true, takenBy: true);

            DataTable bloodGroups = new DataTable();
            bloodGroups.Columns.Add("ID");
            bloodGroups.Columns.Add("Name");
            bloodGroups.Columns.Add("Reg Year");
            bloodGroups.Columns.Add("Quantity");

            for (int i = 0; i < bloodStreams.Count; i++)
            {
                List<string> tempList = bloodStreams[i];
                DataRow row = bloodGroups.NewRow();
                for (int j = 0; j < tempList.Count; j++)
                {
                    switch (j)
                    {
                        case 0:
                            row[j] = tempList[j];
                            break;

                        case 1:
                            row[j] = tempList[j];
                            break;

                        case 2:
                            row[j] = tempList[j] + "/" + tempList[j + 1] + "/" + tempList[j + 2];
                            break;

                        case 5:
                            row[j] = tempList[j];
                            break;

                        default:
                            continue;
                    }
                }
                bloodGroups.Rows.Add(row);
            }
            dataGridView1.DataSource = bloodGroups;
            dataGridView2.DataSource = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new generalProcesses().getBackProcess(Properties.Settings.Default.lastLeave);
            this.Hide();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow rows = dataGridView1.Rows[e.RowIndex];
                frm_bloodStock_specifiedBloodStockDetails details = new frm_bloodStock_specifiedBloodStockDetails(rows.Cells[0].Value.ToString());
                details.Show();
            }
        }
    }
}
