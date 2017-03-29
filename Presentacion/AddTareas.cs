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
    public partial class AddTareas : Form
    {
        ControladorActividades control;
        public AddTareas()
        {
            InitializeComponent();
        }

        private void AddTareas_Load(object sender, EventArgs e)
        {
            control = new ControladorActividades();
            List<Casa> casa = new List<Casa>();

            casa = control.getAllCasas();

            foreach (var item in casa)
            {
                cmbCasas.Items.Add(item.MynombreCasa.ToString());
                
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int result = 0;
            for (int i = 0; i < listCasas.Items.Count; i++)
            {
                if (listCasas.Items[i].SubItems[0].Text == cmbCasas.Text)
                {
                    result = 1;
                }
                    
            }

            if (result == 0)
            {
                listCasas.Items.Add(cmbCasas.Text);
            }else
            {
                MessageBox.Show("Casa ya añadida");
            }
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listCasas.Items.Count; i++)
            {
                Actividad actividad = new Actividad(int.Parse(txtCodigo.Text),txtDescrip.Text,int.Parse(txtNivel.Text),1);
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
}
