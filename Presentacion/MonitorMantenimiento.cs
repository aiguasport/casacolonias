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
    public partial class MonitorMantenimiento : Form
    {
        public MonitorMantenimiento()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //TODO

            AddMonitor newMDIChild = new AddMonitor();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = SuperAdmin.ActiveForm;
            // Display the new form.
            newMDIChild.Show();
        }
    }
}
