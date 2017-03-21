using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class Personal
    {

        string nif;
        string nombre;
        string apellidos;
        string mail;

        public Personal()
        {

        }

        public Personal(string nif, string nombre, string apellidos, string mail)
        {
            this.nif = nif;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.mail = mail;
        }


        public string MyNif
        {
            get { return nif; }
            set { nif = value; }
        }
        public string MyNombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string MyApellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }
        public string MyMail
        {
            get { return mail; }
            set { mail = value; }
        }

        // override object.Equals

        public override bool Equals(object obj)

        {

            Personal personObj = obj as Personal;

            if (personObj == null)

                return false;

            else

                return nif.Equals(personObj.nif);

        }

        // override object.GetHashCode

        public override int GetHashCode()

        {

            return this.nif.GetHashCode();

        }
    }
}
