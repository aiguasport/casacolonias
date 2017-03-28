using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using Datos;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class AddAdministrador : Form
    {

        PersonalDAO personalDao = new PersonalDAO();

           
        public AddAdministrador()
        {
            InitializeComponent();
        }

        private void AddAdministrador_Load(object sender, EventArgs e)
        {

        }

        private void btnADD_Click(object sender, EventArgs e)
        {
            Personal personal = new Personal();
            personal = new Personal(txtDni.Text, txtName.Text, txtApellidos.Text, txtMail.Text);
            int result = personalDao.AddPersonal(personal);
        }
    }
}
