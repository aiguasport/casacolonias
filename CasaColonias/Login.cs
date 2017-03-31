using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentacion;
using System.Windows.Forms;
using Negocio;

namespace CasaColonias
{
    public partial class Login : Form
    {
        ControladorPersonal control;
        public Login()
        {
            InitializeComponent();
            control = new ControladorPersonal();
        }

        //Login BUTTON
        private void btnLogin_Click(object sender, EventArgs e)
        {
            //Search person in Table personal,If exist in BD return true and the next search rol
           bool result = control.comprobarPersonal(txtDni.Text, txtMail.Text);
            if(result == true)
            {
                //if exist in Table person,search in table Adminstrador,if exit return 1 if not search 
                //in table monitor
                string rolAdmin = control.getRolAdministrador(txtDni.Text);

                if(rolAdmin == "super")
                {
                    SuperAdmin miForm = new SuperAdmin();
                    miForm.Show();
                    this.Hide();
                }else if (rolAdmin == "administrador")
                {
                    AdminForm adminform = new AdminForm();
                    adminform.Show();
                    this.Hide();

                }
                else
                {

                    int rolMonitor = control.getRolMonitor(txtDni.Text);

                    if(rolMonitor == 1)
                    {
                        MonitorMantenimiento miForm = new MonitorMantenimiento();
                        miForm.Show();
                        this.Hide();
                        MessageBox.Show("Eres Monitor");

                    }
                    else
                    {
                        MessageBox.Show("No tiene asignado un rol");
                    }
                }
                
            }
            else
            {
                MessageBox.Show("NIf o Mail incorrectos");
            }
           
        }
    }
}
