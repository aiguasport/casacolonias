using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;
using Datos;
namespace Presentacion
{
    public partial class AddChilde : Form
    {
        ControladorAdmin control = new ControladorAdmin();
        public AddChilde()
        {
            InitializeComponent();
        }

        private void Carnet_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void addchibtn_Click(object sender, EventArgs e)
        {
            int carnet = Int32.Parse(carnettb.Text);
            String nombre = nombretb.Text;
            String apellidos = apellidostb.Text;
            String direccion = direcciontb.Text;
            String sexo = sexotb.Text;
            String annionac = anionactb.Text;
            String poblacion = poblaciontb.Text;
            Childe childe = new Childe(carnet, nombre, apellidos, direccion, sexo, annionac, poblacion);
            if (!control.exists(carnet))
            {
                if (control.add(childe))
                {
                    MessageBox.Show("Añadido");
                }
                else
                {
                    MessageBox.Show("Error de inserción");
                }
                
            }
            else
            {
                MessageBox.Show("ya existe");
            }
        }
    }
}
