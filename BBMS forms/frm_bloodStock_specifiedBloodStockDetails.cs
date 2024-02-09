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
    public partial class frm_bloodStock_specifiedBloodStockDetails : Form
    {
        string logId, messageHeader = GlobalAcceass.companyName + " - Blood Stock";
        public frm_bloodStock_specifiedBloodStockDetails(string logId)
        {
            InitializeComponent();
            this.logId = logId;
        }

        private void frm_bloodStock_specifiedBloodStockDetails_Load(object sender, EventArgs e)
        {
            label1.Text += ": " + logId;
            //getting the details
            label2.Text += ": " + new databases.BloodLog().getAnEntry(logId, 0);
            label3.Text += ": " + new databases.BloodLog().getAnEntry(logId, 1);
            label4.Text += ": " + new databases.BloodLog().getAnEntry(logId, 8);
            label5.Text += ": " + new databases.BloodLog().getAnEntry(logId, 14);
            label6.Text += ": " + new databases.BloodLog().getAnEntry(logId, 4) + "/" + new databases.BloodLog().getAnEntry(logId, 3) + "/" + new databases.BloodLog().getAnEntry(logId, 2) + " (" + new databases.BloodLog().getAnEntry(logId, 5) + ":" + new databases.BloodLog().getAnEntry(logId, 6) + ")";
            label7.Text += ": " + new databases.BloodLog().getAnEntry(logId, 11) + "/" + new databases.BloodLog().getAnEntry(logId, 10) + "/ " + new databases.BloodLog().getAnEntry(logId, 9) + " (" + new databases.BloodLog().getAnEntry(logId, 12) + ":" + new databases.BloodLog().getAnEntry(logId, 13) + ")";
            textBox1.Text = new databases.BloodLog().getAnEntry(logId, 21);
            textBox2.Text = new databases.BloodLog().getAnEntry(logId, 20);
            textBox3.Text = new databases.BloodLog().getAnEntry(logId, 19);
            label9.Text += ": " + new databases.BloodLog().getAnEntry(logId, 17);
            label10.Text += ": " + new databases.BloodLog().getAnEntry(logId, 18);
            label11.Text += ": " + new databases.BloodLog().getAnEntry(logId, 15);
            label12.Text += ": " + new databases.BloodLog().getAnEntry(logId, 16);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new databases.BloodLog().updateTable(logId, 1, resYear: textBox1.Text, resMonth: textBox2.Text, resDay: textBox3.Text);
            MessageBox.Show("Record item outsourced to the due date.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
