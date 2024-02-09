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
    public partial class frm_bloodCategorizationReport : Form
    {
        public frm_bloodCategorizationReport()
        {
            InitializeComponent();
        }

        private void frm_bloodCategorizationReport_Load(object sender, EventArgs e)
        {
            label3.Text = "";
            //loading available blood groups
            List<string> availableBloodGroups = new databases.BloodGroups().getBloodGroups();

            for(int i = 0; i < availableBloodGroups.Count; i++)
            {
                comboBox1.Items.Add(availableBloodGroups[i]);
            }
            comboBox1.Text = availableBloodGroups[0];

            label2.Text = "Avilable Contity: " + new databases.BloodGroups().getEntry(new databases.BloodGroups().getID(availableBloodGroups[0]), 6) + "ml";

            label4.Text = "Last Recent Request: " + new databases.BloodRequest().lastRecentRequest(availableBloodGroups[0]).GetValue(1).ToString() + "/" + new databases.BloodRequest().lastRecentRequest(availableBloodGroups[0]).GetValue(2).ToString() + "/" + new databases.BloodRequest().lastRecentRequest(availableBloodGroups[0]).GetValue(3).ToString() + ", Contity: " + new databases.BloodRequest().lastRecentRequest(availableBloodGroups[0]).GetValue(4).ToString();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure to proceed? because this may take a while or too long depend on the data that the database has.", "BBMS - Blood Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result.ToString() == "Yes")
            {
                label3.Text = "Analyzing...";
                string contity = new databases.BloodGroups().getEntry(new databases.BloodGroups().getID(comboBox1.Text), 6);
                int availableContity = new databases.BloodLog().bloodContityAnalyzer(new databases.BloodGroups().getID(comboBox1.Text));
                if(int.Parse(contity) != availableContity)
                {
                    DialogResult result2 = MessageBox.Show("The current database contitiy: " + contity + "\nActually avilable contity: " + availableContity + "\nThe is a inequality in this parameters. Whould you like to change it?", "BBMS - Blood categorization", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    linkLabel3.Text = availableContity.ToString() + ", " + contity;

                    if(result2.ToString() == "Yes")
                    {
                        new databases.BloodGroups().updateEntry(new databases.BloodGroups().getID(comboBox1.Text), 6, contity = availableContity.ToString());
                        MessageBox.Show("New Contity is updated succesfully.", "BBMS - Blood Categorization", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        linkLabel3.Text = availableContity.ToString();
                    }
                }
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frm_bloodLog log = new frm_bloodLog();
            Properties.Settings.Default.lastLeave = "frm_bloodLog";
            log.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_camps bloodCamps = new frm_camps();
            Properties.Settings.Default.lastLeave = "frm_camps";
            bloodCamps.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new generalProcesses().getBackProcess(Properties.Settings.Default.lastLeave);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_bloodRequest request = new frm_bloodRequest();
            Properties.Settings.Default.lastLeave = "frm_bloodRequest";
            request.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = "Avilable Contity: " + new databases.BloodGroups().getEntry(new databases.BloodGroups().getID(comboBox1.Text), 6) + "ml";

            label4.Text = "Last Recent Request: " + new databases.BloodRequest().lastRecentRequest(comboBox1.Text).GetValue(1).ToString() + "/" + new databases.BloodRequest().lastRecentRequest(comboBox1.Text).GetValue(2).ToString() + "/" + new databases.BloodRequest().lastRecentRequest(comboBox1.Text).GetValue(3).ToString() + ", Contity: " + new databases.BloodRequest().lastRecentRequest(comboBox1.Text).GetValue(4).ToString();
        }
    }
}
