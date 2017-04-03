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
    public partial class AddMonitor : Form
    {
        public string update = "";
        ControladorPersonal control = new ControladorPersonal();

        public AddMonitor()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (update == "")
            {

                //Recorremos todos los TextBox para comprobar que ninguno esta vacio.
                int contarTxt = 0;
                foreach (Control _textbox in this.Controls)
                {
                    if (_textbox is TextBox && _textbox.Text == string.Empty)
                    {
                        contarTxt = contarTxt + 1;
                    }
                }
                //Cargamos el personal y miramos si este dni existe
                List<Personal> listPersonal = new List<Personal>();
                int exist = 0;
                listPersonal = control.getAllPersonal();
                foreach (var item in listPersonal)
                {
                    if (item.MyNif.Equals(txtDni.Text))
                    {
                        exist = 1;
                    }
                }

                if (exist != 1)
                {
                    //comprobamos si habia alguno vacio
                    if (contarTxt > 0)
                    {
                        MessageBox.Show("Campos Vacios");


                    }
                    else
                    {
                        Personal personal = new Personal();
                        personal = new Personal(txtDni.Text, txtName.Text, txtApellidos.Text, txtMail.Text);
                        int result = control.AddPersonal(personal);
                        if (result == 1)
                        {
                            Monitor monitor = new Monitor(txtDni.Text, txFecha.Value);
                            int result2 = control.addMonitor(monitor);
                            if (result2 == 1)
                            {
                                MessageBox.Show("Añadido");
                                MonitorMantenimiento newMDIChild = new MonitorMantenimiento();
                                // Set the Parent Form of the Child window.
                                newMDIChild.MdiParent = SuperAdmin.ActiveForm;
                                // Display the new form.
                                newMDIChild.Show();

                                Close();
                            }
                        }

                    }
                }
                else
                {
                    MessageBox.Show("este DNI O NIF ya existe");
                }
            }
            else
            {

                Personal personal = new Personal(txtDni.Text, txtName.Text, txtApellidos.Text, txtMail.Text);
                Monitor moni = new Monitor(txtDni.Text, txFecha.Value);
                int result = control.updatePersona(personal);
                result = control.updateMonitor(moni);
                if (result == 1)
                {
                    MessageBox.Show("Actualizado");
                    Close();
                }

            }
        }

        private void AddMonitor_Load(object sender, EventArgs e)
        {
            //si el obtenemos un dni de la tabla padre consideramos que vamos a actuallizar un registro
            //lo buscamos en la base de datos y llenamos los campos con el
            if (update != "")
            {
                DataSet ds = new DataSet();
                ds = control.getAllPersonalMonitorByDni(update);
                DataTable dt = ds.Tables[0];
                //p.dni as dni,p.nombre as nombre,p.apellidos as apellidos,p.mail as mail,a.num_SS as ss,a.titulacion as titulo
                foreach (DataRow row in dt.Rows)
                {
                    txtDni.Text = Convert.ToString(row[0]);
                    txtName.Text = Convert.ToString(row[1]);
                    txtApellidos.Text = Convert.ToString(row[2]);
                    txtMail.Text = Convert.ToString(row[3]);
                    txFecha.Text = Convert.ToString(row[4]);

                }
            }
        }
    }
}
