namespace BBMS_forms
{
    partial class Main_Nurse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Home = new System.Windows.Forms.ToolStripMenuItem();
            this.donorRegistrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donorDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Messages = new System.Windows.Forms.ToolStripMenuItem();
            this.newRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewRequests = new System.Windows.Forms.ToolStripMenuItem();
            this.bloodAvailabilityReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBloddRegistrationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newBloodRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.packetHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherEquipmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Staff = new System.Windows.Forms.ToolStripMenuItem();
            this.staffPresenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meetingArrangementsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.staffAllocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outSideConnectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Applications = new System.Windows.Forms.ToolStripMenuItem();
            this.tODOListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remindersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.leaveApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactRegistryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.markTheAttendanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Home,
            this.Messages,
            this.ViewRequests,
            this.Staff,
            this.Applications});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(15);
            this.menuStrip1.Size = new System.Drawing.Size(270, 692);
            this.menuStrip1.TabIndex = 30;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Home
            // 
            this.Home.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.donorRegistrationToolStripMenuItem,
            this.donorDetailsToolStripMenuItem});
            this.Home.Name = "Home";
            this.Home.Padding = new System.Windows.Forms.Padding(10);
            this.Home.Size = new System.Drawing.Size(209, 56);
            this.Home.Text = "Donors";
            // 
            // donorRegistrationToolStripMenuItem
            // 
            this.donorRegistrationToolStripMenuItem.Name = "donorRegistrationToolStripMenuItem";
            this.donorRegistrationToolStripMenuItem.Size = new System.Drawing.Size(302, 36);
            this.donorRegistrationToolStripMenuItem.Text = "Donor Registration";
            this.donorRegistrationToolStripMenuItem.Click += new System.EventHandler(this.donorRegistrationToolStripMenuItem_Click);
            // 
            // donorDetailsToolStripMenuItem
            // 
            this.donorDetailsToolStripMenuItem.Name = "donorDetailsToolStripMenuItem";
            this.donorDetailsToolStripMenuItem.Size = new System.Drawing.Size(302, 36);
            this.donorDetailsToolStripMenuItem.Text = "Donor Details";
            this.donorDetailsToolStripMenuItem.Click += new System.EventHandler(this.donorDetailsToolStripMenuItem_Click);
            // 
            // Messages
            // 
            this.Messages.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newRequestToolStripMenuItem,
            this.timeTableToolStripMenuItem});
            this.Messages.Name = "Messages";
            this.Messages.Padding = new System.Windows.Forms.Padding(10);
            this.Messages.Size = new System.Drawing.Size(209, 56);
            this.Messages.Text = "Camps";
            // 
            // newRequestToolStripMenuItem
            // 
            this.newRequestToolStripMenuItem.Name = "newRequestToolStripMenuItem";
            this.newRequestToolStripMenuItem.Size = new System.Drawing.Size(242, 36);
            this.newRequestToolStripMenuItem.Text = "New Request";
            this.newRequestToolStripMenuItem.Click += new System.EventHandler(this.newRequestToolStripMenuItem_Click);
            // 
            // timeTableToolStripMenuItem
            // 
            this.timeTableToolStripMenuItem.Name = "timeTableToolStripMenuItem";
            this.timeTableToolStripMenuItem.Size = new System.Drawing.Size(242, 36);
            this.timeTableToolStripMenuItem.Text = "Time Table";
            this.timeTableToolStripMenuItem.Click += new System.EventHandler(this.timeTableToolStripMenuItem_Click);
            // 
            // ViewRequests
            // 
            this.ViewRequests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bloodAvailabilityReportToolStripMenuItem,
            this.newBloddRegistrationToolStripMenuItem,
            this.newBloodRequestToolStripMenuItem,
            this.packetHistoryToolStripMenuItem,
            this.otherEquipmentsToolStripMenuItem});
            this.ViewRequests.Name = "ViewRequests";
            this.ViewRequests.Padding = new System.Windows.Forms.Padding(10);
            this.ViewRequests.Size = new System.Drawing.Size(209, 56);
            this.ViewRequests.Text = "Resouce Allocation";
            // 
            // bloodAvailabilityReportToolStripMenuItem
            // 
            this.bloodAvailabilityReportToolStripMenuItem.Name = "bloodAvailabilityReportToolStripMenuItem";
            this.bloodAvailabilityReportToolStripMenuItem.Size = new System.Drawing.Size(363, 36);
            this.bloodAvailabilityReportToolStripMenuItem.Text = "Blood Availability Report";
            this.bloodAvailabilityReportToolStripMenuItem.Click += new System.EventHandler(this.bloodAvailabilityReportToolStripMenuItem_Click);
            // 
            // newBloddRegistrationToolStripMenuItem
            // 
            this.newBloddRegistrationToolStripMenuItem.Name = "newBloddRegistrationToolStripMenuItem";
            this.newBloddRegistrationToolStripMenuItem.Size = new System.Drawing.Size(363, 36);
            this.newBloddRegistrationToolStripMenuItem.Text = "New Blood Registration";
            this.newBloddRegistrationToolStripMenuItem.Click += new System.EventHandler(this.newBloddRegistrationToolStripMenuItem_Click);
            // 
            // newBloodRequestToolStripMenuItem
            // 
            this.newBloodRequestToolStripMenuItem.Name = "newBloodRequestToolStripMenuItem";
            this.newBloodRequestToolStripMenuItem.Size = new System.Drawing.Size(363, 36);
            this.newBloodRequestToolStripMenuItem.Text = "New Blood Request";
            this.newBloodRequestToolStripMenuItem.Click += new System.EventHandler(this.newBloodRequestToolStripMenuItem_Click);
            // 
            // packetHistoryToolStripMenuItem
            // 
            this.packetHistoryToolStripMenuItem.Name = "packetHistoryToolStripMenuItem";
            this.packetHistoryToolStripMenuItem.Size = new System.Drawing.Size(363, 36);
            this.packetHistoryToolStripMenuItem.Text = "Packet History";
            this.packetHistoryToolStripMenuItem.Click += new System.EventHandler(this.packetHistoryToolStripMenuItem_Click);
            // 
            // otherEquipmentsToolStripMenuItem
            // 
            this.otherEquipmentsToolStripMenuItem.Name = "otherEquipmentsToolStripMenuItem";
            this.otherEquipmentsToolStripMenuItem.Size = new System.Drawing.Size(363, 36);
            this.otherEquipmentsToolStripMenuItem.Text = "Other Equipments";
            this.otherEquipmentsToolStripMenuItem.Click += new System.EventHandler(this.otherEquipmentsToolStripMenuItem_Click);
            // 
            // Staff
            // 
            this.Staff.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.staffPresenceToolStripMenuItem,
            this.meetingArrangementsToolStripMenuItem,
            this.staffAllocationToolStripMenuItem,
            this.outSideConnectionsToolStripMenuItem});
            this.Staff.Name = "Staff";
            this.Staff.Padding = new System.Windows.Forms.Padding(10);
            this.Staff.Size = new System.Drawing.Size(209, 56);
            this.Staff.Text = "Staff";
            // 
            // staffPresenceToolStripMenuItem
            // 
            this.staffPresenceToolStripMenuItem.Name = "staffPresenceToolStripMenuItem";
            this.staffPresenceToolStripMenuItem.Size = new System.Drawing.Size(349, 36);
            this.staffPresenceToolStripMenuItem.Text = "Staff presence";
            this.staffPresenceToolStripMenuItem.Click += new System.EventHandler(this.staffPresenceToolStripMenuItem_Click);
            // 
            // meetingArrangementsToolStripMenuItem
            // 
            this.meetingArrangementsToolStripMenuItem.Name = "meetingArrangementsToolStripMenuItem";
            this.meetingArrangementsToolStripMenuItem.Size = new System.Drawing.Size(349, 36);
            this.meetingArrangementsToolStripMenuItem.Text = "Meeting Arrangements";
            this.meetingArrangementsToolStripMenuItem.Click += new System.EventHandler(this.meetingArrangementsToolStripMenuItem_Click);
            // 
            // staffAllocationToolStripMenuItem
            // 
            this.staffAllocationToolStripMenuItem.Name = "staffAllocationToolStripMenuItem";
            this.staffAllocationToolStripMenuItem.Size = new System.Drawing.Size(349, 36);
            this.staffAllocationToolStripMenuItem.Text = "Staff Allocation";
            this.staffAllocationToolStripMenuItem.Click += new System.EventHandler(this.staffAllocationToolStripMenuItem_Click);
            // 
            // outSideConnectionsToolStripMenuItem
            // 
            this.outSideConnectionsToolStripMenuItem.Name = "outSideConnectionsToolStripMenuItem";
            this.outSideConnectionsToolStripMenuItem.Size = new System.Drawing.Size(349, 36);
            this.outSideConnectionsToolStripMenuItem.Text = "OutSide connections";
            this.outSideConnectionsToolStripMenuItem.Click += new System.EventHandler(this.outSideConnectionsToolStripMenuItem_Click);
            // 
            // Applications
            // 
            this.Applications.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tODOListToolStripMenuItem,
            this.remindersToolStripMenuItem,
            this.messagesToolStripMenuItem,
            this.leaveApplicationToolStripMenuItem,
            this.logDetailsToolStripMenuItem,
            this.contactRegistryToolStripMenuItem,
            this.markTheAttendanceToolStripMenuItem,
            this.moreToolStripMenuItem,
            this.logOutToolStripMenuItem});
            this.Applications.Name = "Applications";
            this.Applications.Size = new System.Drawing.Size(209, 36);
            this.Applications.Text = "General";
            // 
            // tODOListToolStripMenuItem
            // 
            this.tODOListToolStripMenuItem.Name = "tODOListToolStripMenuItem";
            this.tODOListToolStripMenuItem.Size = new System.Drawing.Size(329, 36);
            this.tODOListToolStripMenuItem.Text = "TODO List";
            this.tODOListToolStripMenuItem.Click += new System.EventHandler(this.tODOListToolStripMenuItem_Click);
            // 
            // remindersToolStripMenuItem
            // 
            this.remindersToolStripMenuItem.Name = "remindersToolStripMenuItem";
            this.remindersToolStripMenuItem.Size = new System.Drawing.Size(329, 36);
            this.remindersToolStripMenuItem.Text = "Reminders";
            this.remindersToolStripMenuItem.Click += new System.EventHandler(this.remindersToolStripMenuItem_Click);
            // 
            // messagesToolStripMenuItem
            // 
            this.messagesToolStripMenuItem.Name = "messagesToolStripMenuItem";
            this.messagesToolStripMenuItem.Size = new System.Drawing.Size(329, 36);
            this.messagesToolStripMenuItem.Text = "Messages";
            this.messagesToolStripMenuItem.Click += new System.EventHandler(this.messagesToolStripMenuItem_Click);
            // 
            // leaveApplicationToolStripMenuItem
            // 
            this.leaveApplicationToolStripMenuItem.Name = "leaveApplicationToolStripMenuItem";
            this.leaveApplicationToolStripMenuItem.Size = new System.Drawing.Size(329, 36);
            this.leaveApplicationToolStripMenuItem.Text = "Leave Application";
            this.leaveApplicationToolStripMenuItem.Click += new System.EventHandler(this.leaveApplicationToolStripMenuItem_Click);
            // 
            // logDetailsToolStripMenuItem
            // 
            this.logDetailsToolStripMenuItem.Name = "logDetailsToolStripMenuItem";
            this.logDetailsToolStripMenuItem.Size = new System.Drawing.Size(329, 36);
            this.logDetailsToolStripMenuItem.Text = "Log details";
            this.logDetailsToolStripMenuItem.Click += new System.EventHandler(this.logDetailsToolStripMenuItem_Click);
            // 
            // contactRegistryToolStripMenuItem
            // 
            this.contactRegistryToolStripMenuItem.Name = "contactRegistryToolStripMenuItem";
            this.contactRegistryToolStripMenuItem.Size = new System.Drawing.Size(329, 36);
            this.contactRegistryToolStripMenuItem.Text = "Contact Registry";
            this.contactRegistryToolStripMenuItem.Click += new System.EventHandler(this.contactRegistryToolStripMenuItem_Click);
            // 
            // moreToolStripMenuItem
            // 
            this.moreToolStripMenuItem.Name = "moreToolStripMenuItem";
            this.moreToolStripMenuItem.Size = new System.Drawing.Size(329, 36);
            this.moreToolStripMenuItem.Text = "More...";
            this.moreToolStripMenuItem.Click += new System.EventHandler(this.moreToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(329, 36);
            this.logOutToolStripMenuItem.Text = "Log Out";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(273, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 9F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(935, 59);
            this.tableLayoutPanel1.TabIndex = 32;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(929, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "Upcoming Activity";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(273, 65);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(935, 50);
            this.tableLayoutPanel2.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(929, 50);
            this.label2.TabIndex = 1;
            this.label2.Text = "Messages, Reminders, TODO Next Activity";
            // 
            // markTheAttendanceToolStripMenuItem
            // 
            this.markTheAttendanceToolStripMenuItem.Name = "markTheAttendanceToolStripMenuItem";
            this.markTheAttendanceToolStripMenuItem.Size = new System.Drawing.Size(329, 36);
            this.markTheAttendanceToolStripMenuItem.Text = "Mark The attendance";
            // 
            // Main_Nurse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main_Nurse";
            this.Text = "Main_Nurse";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Home;
        private System.Windows.Forms.ToolStripMenuItem Messages;
        private System.Windows.Forms.ToolStripMenuItem ViewRequests;
        private System.Windows.Forms.ToolStripMenuItem Staff;
        private System.Windows.Forms.ToolStripMenuItem Applications;
        private System.Windows.Forms.ToolStripMenuItem donorRegistrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donorDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newRequestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem timeTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bloodAvailabilityReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newBloddRegistrationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newBloodRequestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem packetHistoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherEquipmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffPresenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem meetingArrangementsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem staffAllocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem outSideConnectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tODOListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remindersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem leaveApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contactRegistryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem markTheAttendanceToolStripMenuItem;
    }
}