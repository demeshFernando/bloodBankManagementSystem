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
    public partial class PHI : Form
    {
        public PHI()
        {
            InitializeComponent();
        }

        private void PHI_Load(object sender, EventArgs e)
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

        private void newCampOrganizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_newCampOrganization organization = new frm_newCampOrganization();
            organization.Show();
            this.Hide();
        }

        private void timetableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_timeTable table = new frm_timeTable();
            table.Show();
            this.Hide();
        }

        private void registeredPacketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_acessoryDetails details = new frm_acessoryDetails();
            details.Show();
            this.Hide();
        }

        private void bloodCategorizationReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_bloodCategorizationReport report = new frm_bloodCategorizationReport();
            report.Show();
            this.Hide();
        }

        private void processingPacketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_packetProcessing processing = new frm_packetProcessing();
            processing.Show();
            this.Hide();
        }

        private void bloodDeliverToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void otherEqupmentAvailabilityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_acessoryDetails details = new frm_acessoryDetails();
            details.Show();
            this.Hide();
        }

        private void staffPresenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_attendanceRegistry attendance = new frm_attendanceRegistry();
            attendance.Show();
            this.Hide();
        }

        private void meetingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_meetingArrangements meetings = new frm_meetingArrangements();
            meetings.Show();
            this.Hide();
        }

        private void staffAllocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_staffAllocation allocation = new frm_staffAllocation();
            allocation.Show();
            this.Hide();
        }

        private void outsideContactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_outsideContancts contacts = new frm_outsideContancts();
            contacts.Show();
            this.Hide();
        }

        private void tODOListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_todoList todo = new frm_todoList();
            todo.Show();
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

        private void logsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_logHistory history = new frm_logHistory();
            history.Show();
            this.Hide();
        }

        private void stayOutDaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_applyLeave leave = new frm_applyLeave();
            leave.Show();
            this.Hide();
        }

        private void moreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_phiSettings settings = new frm_phiSettings();
            settings.Show();
            this.Hide();
        }
    }
}
