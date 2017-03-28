﻿using Datos;
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
    }
}
