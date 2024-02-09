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
    public partial class frm_newTodoEvent : Form
    {
        public string[] eventDetails;
        public frm_newTodoEvent(string[] eventDetails)
        {
            InitializeComponent();
            this.eventDetails = eventDetails;
        }
    }
}
