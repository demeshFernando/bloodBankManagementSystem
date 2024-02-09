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
    public partial class Main_Nurse : Form
    {
        public Main_Nurse()
        {
            InitializeComponent();
        }

        private void newBloddRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_newBloodGroupRegistration register = new frm_newBloodGroupRegistration();
            register.Show();
            this.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void donorRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_newDonorRegistration registration = new frm_newDonorRegistration();
            registration.Show();
            this.Hide();
        }

        private void donorDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_donorList list = new frm_donorList();
            list.Show();
            this.Hide();
        }

        private void newRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_requestCamp request = new frm_requestCamp();
            request.Show();
            this.Hide();
        }

        private void timeTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_timeTable timetable = new frm_timeTable();
            timetable.Show();
            this.Hide();
        }

        private void bloodAvailabilityReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_bloodStock stock = new frm_bloodStock();
            stock.Show();
            this.Hide();
        }

        private void newBloodRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_bloodRequest request = new frm_bloodRequest();
            request.Show();
            this.Hide();
        }

        private void packetHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_packetHistory history = new frm_packetHistory();
            history.Show();
            this.Hide();
        }

        private void otherEquipmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void tODOListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_todoList list = new frm_todoList();
            list.Show();
            this.Hide();
        }

        private void remindersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_reminders reminders = new frm_reminders();
            reminders.Show();
            this.Hide();
        }

        private void messagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_messages messages = new frm_messages();
            messages.Show();
            this.Hide();
        }

        private void leaveApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_applyLeave leave = new frm_applyLeave();
            leave.Show();
            this.Hide();
        }

        private void logDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_logHistory history = new frm_logHistory();
            history.Show();
            this.Hide();
        }

        private void contactRegistryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_phoneRegistry registry = new frm_phoneRegistry();
            registry.Show();
            this.Hide();
        }

        private void moreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_mainNurseSettings settings = new frm_mainNurseSettings();
            settings.Show();
            this.Hide();
        }

        private void staffPresenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_attendanceRegistry registry = new frm_attendanceRegistry();
            registry.Show();
            this.Hide();
        }

        private void meetingArrangementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_meetingArrangements arrangements = new frm_meetingArrangements();
            arrangements.Show();
            this.Hide();
        }

        private void staffAllocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_staffAllocation allocation = new frm_staffAllocation();
            allocation.Show();
            this.Hide();
        }

        private void outSideConnectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_outsideContancts contacts = new frm_outsideContancts();
            contacts.Show();
            this.Hide();
        }
    }
}
