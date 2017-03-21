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

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           bool result = control.comprobarPersonal(txtDni.Text, txtMail.Text);
            if(result == true)
            {
                int rol = control.getRol(txtDni.Text);
                MessageBox.Show(rol.ToString());
            }
            else
            {
                MessageBox.Show("NIf o Mail incorrectos");
            }
          

            //SuperAdmin miForm = new SuperAdmin();
            //miForm.Show();
            //this.Hide();
        }
    }
}
