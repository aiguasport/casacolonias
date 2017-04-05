using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void añadirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddChilde addchilde = new AddChilde();
            addchilde.MdiParent = this;
            addchilde.Show();
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifyChilde modchilde = new ModifyChilde();
            modchilde.MdiParent = this;
            modchilde.Show();
        }
    }
}
