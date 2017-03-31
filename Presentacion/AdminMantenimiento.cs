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
    public partial class AdminMantenimiento : Form
    {
        ControladorPersonal control = new ControladorPersonal();
        public AdminMantenimiento()
        {
            InitializeComponent();
        }

        private void AdminMantenimiento_Load(object sender, EventArgs e)
        {
            DataSet listAdmin = new DataSet();
            listAdmin = control.getAllAdministradorFull();
            DataTable dt = listAdmin.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                dataGridView1.Rows.Add(Convert.ToString(row["dni"].ToString()), Convert.ToString(row["nombre"].ToString()), Convert.ToString(row["apellidos"].ToString()), Convert.ToString(row["mail"].ToString()), Convert.ToString(row["num_SS"].ToString()), Convert.ToString(row["titulacion"].ToString()));
            }

        }

        //Boton para modificar un administrador
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



            String valor = dataGridView1.CurrentRow.Cells[0].Value.ToString();


            AddAdministrador newMDIChild = new AddAdministrador();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent = SuperAdmin.ActiveForm;
            // Display the new form.
            newMDIChild.update = valor;
            newMDIChild.Show();
           
        }
    }

}
