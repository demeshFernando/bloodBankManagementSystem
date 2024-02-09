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
    public partial class frm_newMessage : Form
    {
        public string[] message;
        public frm_newMessage(string[] message)
        {
            InitializeComponent();
            this.message = message;
        }
    }
}
