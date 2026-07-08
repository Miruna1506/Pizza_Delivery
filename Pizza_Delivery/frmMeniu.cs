using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pizza_Delivery
{
    public partial class frmMeniu : Form
    {
        public frmMeniu()
        {
            InitializeComponent();
        }

        private void btnComenzi_Click(object sender, EventArgs e)
        {
            frmComenzi form = new frmComenzi();
            form.ShowDialog();
        }

        private void btnPizza_Click(object sender, EventArgs e)
        {
            frmPizza form = new frmPizza();
            form.ShowDialog();
        }
    }
}
