using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Negocio;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class TareasMantenimiento : Form
    {
        ControladorActividades control = new ControladorActividades();   
        public TareasMantenimiento()
        {
            InitializeComponent();
        }

        private void TareasMantenimiento_Load(object sender, EventArgs e)
        {
            DataSet listactividad = new DataSet();
            listactividad = control.getAllActividadYCasa();
            DataTable dt = listactividad.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(Convert.ToString(row["codigo"].ToString()), Convert.ToString(row["descrip"].ToString()), Convert.ToString(row["nivel"].ToString()), Convert.ToString(row["nombre"].ToString()));
            }

            
        }
    }
}
