using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Negocio;

namespace Presentacion
{
    public partial class ModifyChilde : Form
    {
        ControladorAdmin control = new ControladorAdmin();
        public ModifyChilde()
        {
            InitializeComponent();
        }

        private void modifyok_Click(object sender, EventArgs e)
        {
            int carnet = Int32.Parse(carnetm.Text);
            String nombre = nombrem.Text;
            String apellidos = apellidosm.Text;
            String direccion = direccionm.Text;
            String sexo = sexom.Text;
            String annionac = aninm.Text;
            String poblacion = poblacionm.Text;
            Childe childe = new Childe(carnet, nombre, apellidos, direccion, sexo, annionac, poblacion);
            if (control.exists(carnet))
            {
                if (control.update(childe))
                {
                    MessageBox.Show("Modificado");
                }
                else
                {
                    MessageBox.Show("Error de modificación");
                }

            }
            else
            {
                MessageBox.Show("No existe");
            }
        }
    }
}
