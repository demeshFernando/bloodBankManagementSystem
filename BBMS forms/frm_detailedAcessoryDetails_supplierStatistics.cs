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
    public partial class frm_detailedAcessoryDetails_supplierStatistics : Form
    {
        private string acessoryId, messageHeader = GlobalAcceass.companyName + " - Supplier Statistics";

        private void tableLayoutPanel24_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void tableLayoutPanel13_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void frm_detailedAcessoryDetails_supplierStatistics_Load(object sender, EventArgs e)
        {
            //checking the database for the id
            if(new databases.AcessoryDetails().checkId(acessoryId) == 0)
            {
                //getting supplier statistics of the current year
                label1.Text = "Supplier Supply Statistics (" + DateTime.Now.ToString("yyyy") + ")";
                this.Text = "Getting the user statistics over the year...";
                List<List<string>> annualSupplierStatistics = new databases.AcessoryReservation().getItemsByAcessoryId(acessoryId: this.acessoryId, isreservedDay: true, isreservedMonth: true, isreservedYear: true, isreservedHour: true, isreservedMinute: true, iswantDay: true, iswantMonth: true, iswantYear: true, iswantHour: true, iswantMinute: true, isquantity: true);
                List<string> calculatableYears = new List<string>();
                //adding all the statistics month wise
                int januaryCount = 0, februaryCount = 0, marchCount = 0, aprilCount = 0, mayCount = 0, juneCount = 0, julyCount = 0, augustCount = 0, septemberCount = 0, octomberCount = 0, novemberCount = 0, decemberCount = 0;
                for(int i = 0; i < annualSupplierStatistics.Count; i++)
                {
                    this.Text = "Processing Supplier Statistics...(" + new generalProcesses().getPercentage(i + 1, annualSupplierStatistics.Count) + "%)";
                    List<string> tempList = annualSupplierStatistics[i];
                    if(tempList[7] == DateTime.Now.ToString("yyyy"))
                    {
                        switch (tempList[6])
                        {
                            case "01":
                                januaryCount += int.Parse(tempList[10]);
                                break;

                            case "02":
                                februaryCount += int.Parse(tempList[10]);
                                break;

                            case "03":
                                marchCount += int.Parse(tempList[10]);
                                break;

                            case "04":
                                aprilCount += int.Parse(tempList[10]);
                                break;

                            case "05":
                                mayCount += int.Parse(tempList[10]);
                                break;

                            case "06":
                                juneCount += int.Parse(tempList[10]);
                                break;

                            case "07":
                                julyCount += int.Parse(tempList[10]);
                                break;

                            case "08":
                                augustCount += int.Parse(tempList[10]);
                                break;

                            case "09":
                                septemberCount += int.Parse(tempList[10]);
                                break;

                            case "10":
                                octomberCount += int.Parse(tempList[10]);
                                break;

                            case "11":
                                novemberCount += int.Parse(tempList[10]);
                                break;

                            case "12":
                                decemberCount += int.Parse(tempList[10]);
                                break;
                        }
                    }

                    if(calculatableYears == null)
                    {
                        calculatableYears.Add(tempList[7]);
                    }
                    else
                    {
                        bool isAvailable = false;
                        //checking whether the years are added to the list
                        for(int j = 0; j < calculatableYears.Count; j++)
                        {
                            if(tempList[7] == calculatableYears[j])
                            {
                                isAvailable = true;
                            }
                        }
                        if (!isAvailable)
                        {
                            calculatableYears.Add(tempList[7]);
                        }
                    }
                }
                this.Text = "Loading required libraries";
                //sorting out the elements in the calculatable years list
                for(int i = 0; i < calculatableYears.Count - 1; i++)
                {
                    int minIndex = i;
                    for(int j = i + 1; j < calculatableYears.Count; j++)
                    {
                        if(int.Parse(calculatableYears[minIndex]) > int.Parse(calculatableYears[j]))
                        {
                            minIndex = j;
                        }
                    }
                    if(minIndex != i)
                    {
                        //swapping the elements
                        string temp = calculatableYears[minIndex];
                        calculatableYears[minIndex] = calculatableYears[i];
                        calculatableYears[i] = temp;
                    }
                    comboBox1.Items.Add(calculatableYears[i]);
                }
                comboBox1.Text = DateTime.Now.ToString("yyyy");
                for(int i = 1; i <= int.Parse(DateTime.Now.ToString("MM")); i++)
                {
                    switch (i)
                    {
                        case 1:
                            comboBox2.Items.Add("January");
                            break;

                        case 2:
                            comboBox2.Items.Add("February");
                            break;

                        case 3:
                            comboBox2.Items.Add("March");
                            break;

                        case 4:
                            comboBox2.Items.Add("April");
                            break;

                        case 5:
                            comboBox2.Items.Add("May");
                            break;

                        case 6:
                            comboBox2.Items.Add("June");
                            break;

                        case 7:
                            comboBox2.Items.Add("July");
                            break;

                        case 8:
                            comboBox2.Items.Add("August");
                            break;

                        case 9:
                            comboBox2.Items.Add("September");
                            break;

                        case 10:
                            comboBox2.Items.Add("Octomber");
                            break;

                        case 11:
                            comboBox2.Items.Add("November");
                            break;

                        case 12:
                            comboBox2.Items.Add("December");
                            break;
                    }
                }

                //statistical view of the suppliers good buying in the current month
                List<List<string>> sellerDetails = new databases.AcessorySellersDetails().getSellerIdWithPrice(this.acessoryId);
                label8.Text = "Total purchase of the product in " + DateTime.Now.ToString("MM");
                label10.Text = DateTime.Now.ToString("MM") == "01" ? januaryCount.ToString() : (DateTime.Now.ToString("MM") == "02" ? februaryCount.ToString() : (DateTime.Now.ToString("MM") == "03" ? marchCount.ToString() : (DateTime.Now.ToString("MM") == "04" ? aprilCount.ToString() : (DateTime.Now.ToString("MM") == "05" ? mayCount.ToString() : (DateTime.Now.ToString("MM") == "06" ? juneCount.ToString() : (DateTime.Now.ToString("MM") == "07" ? julyCount.ToString() : (DateTime.Now.ToString("MM") == "08" ? augustCount.ToString() : (DateTime.Now.ToString("MM") == "09" ? septemberCount.ToString() : (DateTime.Now.ToString("MM") == "10" ? octomberCount.ToString() : (DateTime.Now.ToString("MM") == "11" ? novemberCount.ToString() : decemberCount.ToString()))))))))));
                for(int i = 0; i < sellerDetails.Count; i++)
                {
                    List<string> tempList = sellerDetails[i];
                    comboBox10.Items.Add(new databases.OutsideContacts().getEntry(tempList[0], 2));
                }
            }
            else if(new databases.AcessoryDetails().checkId(acessoryId) == -1)
            {
                //informing to the user
                MessageBox.Show("Usage statistics cannot be shows because the chosen id was not a valid one.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
                label45.Text = acessoryId;
            }
            else
            {
                MessageBox.Show("There are duplicated entries found with the same ID. Please contact the administrator.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public frm_detailedAcessoryDetails_supplierStatistics(string acessoryId)
        {
            InitializeComponent();
            this.acessoryId = acessoryId;
        }
    }
}
