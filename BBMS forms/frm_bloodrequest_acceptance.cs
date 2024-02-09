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
    public partial class frm_bloodrequest_acceptance : Form
    {
        private string ID, messageHeader = GlobalAcceass.companyName + " - Blood Request";
        public frm_bloodrequest_acceptance(string ID)
        {
            this.ID = ID;
            InitializeComponent();
        }

        private void frm_bloodrequest_acceptance_Load(object sender, EventArgs e)
        {
            label1.Text = new databases.BloodRequest().getEntry(ID, 0);
            label2.Text = ID;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new databases.BloodRequest().updateTable(ID, 1, sendingYear: textBox1.Text, sendingMonth: textBox2.Text, sendingDay: textBox3.Text);
            MessageBox.Show("The sending date updated.", messageHeader, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
