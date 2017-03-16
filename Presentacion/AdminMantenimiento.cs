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
    public partial class AdminMantenimiento : Form
    {
        public AdminMantenimiento()
        {
            InitializeComponent();
        }

        private void AdminMantenimiento_Load(object sender, EventArgs e)
        {
            //Datos de prueba
            //List<String> datosPrueba = new List<string>();
            //datosPrueba.Add("Juanjo");
            //datosPrueba.Add("Valeria");
            //datosPrueba.Add("Montse");
            //datosPrueba.Add("Victor");

            string[] row0 = { "11/22/1968", "29", "Revolution 9",
            "Beatles", "The Beatles [White Album]" };
            string[] row1 = { "1960", "6", "Fools Rush In",
            "Frank Sinatra", "Nice 'N' Easy" };
            string[] row2 = { "11/11/1971", "1", "One of These Days",
            "Pink Floyd", "Meddle" };
            string[] row3 = { "1988", "7", "Where Is My Mind?",
            "Pixies", "Surfer Rosa" };
            string[] row4 = { "5/1981", "9", "Can't Find My Mind",
            "Cramps", "Psychedelic Jungle" };
            string[] row5 = { "6/10/2003", "13",
            "Scatterbrain. (As Dead As Leaves.)",
            "Radiohead", "Hail to the Thief" };
            string[] row6 = { "6/30/1992", "3", "Dress", "P J Harvey", "Dry" };

            dataGridView1.Rows.Add(row0);
            dataGridView1.Rows.Add(row1);
            dataGridView1.Rows.Add(row2);
            dataGridView1.Rows.Add(row3);
            dataGridView1.Rows.Add(row4);
            dataGridView1.Rows.Add(row5);
            dataGridView1.Rows.Add(row6);

            dataGridView1.Columns[0].DisplayIndex = 0;
            dataGridView1.Columns[1].DisplayIndex = 1;
            dataGridView1.Columns[2].DisplayIndex = 2;
            dataGridView1.Columns[3].DisplayIndex = 3;
            dataGridView1.Columns[4].DisplayIndex = 4;


        }

        //Boton para modificar un administrador
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //TODO
           
            AddAdministrador newMDIChild = new AddAdministrador();
            // Set the Parent Form of the Child window.
            newMDIChild.MdiParent =SuperAdmin.ActiveForm;
            // Display the new form.
            newMDIChild.Show();
        }
    }

}
