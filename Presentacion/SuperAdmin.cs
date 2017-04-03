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
    public partial class SuperAdmin : Form
    {
        public SuperAdmin()
        {
            InitializeComponent();
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Compruebo si el formulario que lista los administradores esta abierto
            //en caso afirmativo lo cierro para evitar duplicados
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is AdminMantenimiento);
            if (frm != null)
            {
                frm.Close();
            }
            AddAdministrador newMDIChild = new AddAdministrador();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();

        
    }

        private void listarYModificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminMantenimiento newMDIChild = new AdminMantenimiento();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void altaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Compruebo si el formulario que lista los monitores esta abierto
            //en caso afirmativo lo cierro para evitar duplicados
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is MonitorMantenimiento);
            if (frm != null)
            {
                frm.Close();
            }

            AddMonitor newMDIChild = new AddMonitor();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void listarYBorrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonitorMantenimiento newMDIChild = new MonitorMantenimiento();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void altaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Compruebo si el formulario que lista las actividades esta abierto
            //en caso afirmativo lo cierro para evitar duplicados
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is ActividadesMantenimiento);
            if(frm != null)
            {
                frm.Close();
            }

            AddActividad newMDIChild = new AddActividad();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            ActividadesMantenimiento newMDIChild = new ActividadesMantenimiento();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = this;
            // Display the new form.
            newMDIChild.Show();
        }
        //Boton para salir de la APP
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
