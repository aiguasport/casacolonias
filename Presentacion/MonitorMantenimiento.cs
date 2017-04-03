using Datos;
using Negocio;
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
        ControladorPersonal control = new ControladorPersonal();

        public MonitorMantenimiento()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult resultDialog = MessageBox.Show("Desea Borrar al Monitor?","Importante", MessageBoxButtons.YesNo);

            if (resultDialog == DialogResult.Yes)
            {
                String valor = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                int result = control.borrarMonitor(valor);
                result = control.borrarPersonal(valor);
                if (result == 1)
                {

                    dataGridView1.Rows.Clear();

                    DataSet listMonitor = new DataSet();
                    listMonitor = control.getAllPersonalMonitor();
                    DataTable dt = listMonitor.Tables[0];
                    foreach (DataRow row in dt.Rows)
                    {
                        dataGridView1.Rows.Add(Convert.ToString(row["dni"].ToString()), Convert.ToString(row["nombre"].ToString()), Convert.ToString(row["apellidos"].ToString()), Convert.ToString(row["mail"].ToString()), Convert.ToString(row["fecha"].ToString()));
                    }

                }
                else
                {
                    MessageBox.Show("Error al borrar");
                }
            }else
            {

            }
            //Por si hay que actualizar
            //AddMonitor newMDIChild = new AddMonitor();
            //// Set the Parent Form of the Child window.
            //newMDIChild.MdiParent = SuperAdmin.ActiveForm;
            //// Display the new form.
            //newMDIChild.update = valor;
            //newMDIChild.Show();
        }

        private void MonitorMantenimiento_Load(object sender, EventArgs e)
        {
            DataSet listMonitor = new DataSet();
            listMonitor = control.getAllPersonalMonitor();
            DataTable dt = listMonitor.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(Convert.ToString(row["dni"].ToString()), Convert.ToString(row["nombre"].ToString()), Convert.ToString(row["apellidos"].ToString()), Convert.ToString(row["mail"].ToString()), Convert.ToString(row["fecha"].ToString()));
            }
        }
    }
}
