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
        public string update = "";
        ControladorPersonal control = new ControladorPersonal();

           
        public AddAdministrador()
        {
            InitializeComponent();
        }

        private void AddAdministrador_Load(object sender, EventArgs e)
        {
            //si el obtenemos un dni de la tabla padre consideramos que vamos a actuallizar un registro
            //lo buscamos en la base de datos y llenamos los campos con el
            if(update != ""){
                DataSet ds = new DataSet();
                ds = control.getAllPersonalAdminByDni(update);
                DataTable dt = ds.Tables[0];
                //p.dni as dni,p.nombre as nombre,p.apellidos as apellidos,p.mail as mail,a.num_SS as ss,a.titulacion as titulo
                foreach (DataRow row in dt.Rows)
                {
                    txtDni.Text = Convert.ToString(row[0]);
                    txtName.Text = Convert.ToString(row[1]);
                    txtSS.Text = Convert.ToString(row[4]);
                    txtApellidos.Text = Convert.ToString(row[2]);
                    txtMail.Text = Convert.ToString(row[3]);
                    comboBox1.Text = Convert.ToString(row[5]);
                   
                }
            }
        }
        //ADD A NEW PERSONAL
        //IF THE ADD IS CORRECT INSERT THIS PERSON IN ADMIN TABLE
        private void btnADD_Click(object sender, EventArgs e)
        {
            //comprobamos si vamos ha actualizar o a insertar un nuevo administrador
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
                            Administrador admin = new Administrador(txtDni.Text, txtSS.Text, comboBox1.Text);
                            int result2 = control.addAdmin(admin);
                            if (result2 == 1)
                            {
                                MessageBox.Show("Añadido");
                                Close();
                            }
                        }

                    }
                }
                else
                {
                    MessageBox.Show("este DNI O NIF ya existe");
                }
            }else
            {

                Personal personal = new Personal(txtDni.Text, txtName.Text, txtApellidos.Text, txtMail.Text);
                Administrador admin = new Administrador(txtDni.Text, txtSS.Text, comboBox1.Text);
                int result = control.updatePersona(personal);
                result = control.updateAdmin(admin);
                if(result == 1)
                {
                    MessageBox.Show("Actualizado");
                    Close();
                }

            }

        }
    }
}
