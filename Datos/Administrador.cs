using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class Administrador
    {
        string dni;
        string num_SS;
        string titulacion;

        public Administrador()
        {

        }
        public Administrador(string dni, string num_SS, string titulacion)
        {
            this.dni = dni;
            this.num_SS = num_SS;
            this.titulacion = titulacion;
        }


        public string Mydni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string Mynum_SS
        {
            get { return num_SS; }
            set { num_SS = value; }
        }

        public string Mytitulacion
        {
            get { return titulacion; }
            set { titulacion = value; }
        }

        // override object.Equals

        public override bool Equals(object obj)

        {

            Administrador personObj = obj as Administrador;

            if (personObj == null)

                return false;

            else

                return dni.Equals(personObj.dni);

        }

        // override object.GetHashCode

        public override int GetHashCode()

        {

            return this.dni.GetHashCode();

        }


    }
}
