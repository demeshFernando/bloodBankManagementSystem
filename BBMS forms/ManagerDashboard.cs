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
    public partial class ManagerDashboard : Form
    {
        public ManagerDashboard()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
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
            frm_newDonorRegistration registration = new frm_newDonorRegistration();
            registration.Show();
            this.Hide();
        }

        private void newCampOrganizationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_requestCamp request = new frm_requestCamp();
            request.Show();
            this.Hide();
        }

        private void timetableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_timeTable timetable = new frm_timeTable();
            timetable.Show();
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
            frm_packetProcessing process = new frm_packetProcessing();
            process.Show();
            this.Hide();
        }

        private void bloodDeliverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_bloodRequestAcceptance acceptance = new frm_bloodRequestAcceptance();
            acceptance.Show();
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
            frm_acessoryDetails acessories = new frm_acessoryDetails();
            acessories.Show();
            this.Hide();
        }

        private void staffPresenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_attendanceRegistry registry = new frm_attendanceRegistry();
            registry.Show();
            this.Hide();
        }

        private void meetingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_managerMeetings meetings = new frm_managerMeetings();
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
            frm_outsideContancts contancts = new frm_outsideContancts();
            contancts.Show();
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
            frm_managerSettings settings = new frm_managerSettings();
            settings.Show();
            this.Hide();
        }
    }
}
