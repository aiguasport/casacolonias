using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Datos;
using Negocio;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class AddActividad : Form
    {
        ControladorActividades control;
        List<Casa> casa;
        public AddActividad()
        {
            InitializeComponent();
        }

        private void AddTareas_Load(object sender, EventArgs e)
        {
            control = new ControladorActividades();
            casa = new List<Casa>();

            casa = control.getAllCasas();

            foreach (var item in casa)
            {
                cmbCasas.Items.Add(item.MynombreCasa.ToString());
                
            }

        }

       

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            int codigoCasa = 0;
            foreach (var item in casa)
            {

                if (cmbCasas.Text.Equals(item.MynombreCasa))
                {
                    codigoCasa =int.Parse(item.MycodigoCasa.ToString());

                }



            }

                Actividad actividad = new Actividad(int.Parse(txtCodigo.Text),txtDescrip.Text,int.Parse(txtNivel.Text),codigoCasa);
                int result = control.addActividad(actividad);
                result = control.addActividadCasa(actividad);
                if(result == 1)
                {
                    MessageBox.Show("Actividad insertada");
                    Close();
                }
            


        }
    }
}
