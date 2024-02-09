using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBMS_forms
{
    public partial class Nurse : Form
    {
        public Nurse()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frm_newDonorRegistration registration = new frm_newDonorRegistration();
            registration.Show();
            this.Hide();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frm_donorList details = new frm_donorList();
            details.Show();
            this.Hide();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frm_requestCamp request = new frm_requestCamp();
            request.Show();
            this.Hide();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            frm_timeTable table = new frm_timeTable();
            table.Show();
            this.Hide();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            frm_acessoryRegistration registration = new frm_acessoryRegistration();
            registration.Show();
            this.Hide();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            frm_packetProcessing processing = new frm_packetProcessing();
            processing.Show();
            this.Hide();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            frm_bloodRequest request = new frm_bloodRequest();
            request.Show();
            this.Hide();
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            frm_packetHistory history = new frm_packetHistory();
            history.Show();
            this.Hide();
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e)
        {
            frm_todoList todo = new frm_todoList();
            todo.Show();
            this.Hide();
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e)
        {
            frm_reminders reminders = new frm_reminders();
            reminders.Show();
            this.Hide();
        }

        private void toolStripMenuItem19_Click(object sender, EventArgs e)
        {
            frm_messages messages = new frm_messages();
            messages.Show();
            this.Hide();
        }

        private void toolStripMenuItem20_Click(object sender, EventArgs e)
        {
            frm_logHistory history = new frm_logHistory();
            history.Show();
            this.Hide();
        }

        private void toolStripMenuItem21_Click(object sender, EventArgs e)
        {
            frm_applyLeave leave = new frm_applyLeave();
            leave.Show();
            this.Hide();
        }

        private void toolStripMenuItem22_Click(object sender, EventArgs e)
        {
            frm_nurseSettings settings = new frm_nurseSettings();
            settings.Show();
            this.Hide();
        }
    }
}
