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
    public partial class frm_detailedAcessoryDetails_usageStatistics : Form
    {
        private string Id, messageHeader = GlobalAcceass.companyName + " - Usage Statistics";
        public frm_detailedAcessoryDetails_usageStatistics(string Id)
        {
            InitializeComponent();
            this.Id = Id;
        }
    }
}
