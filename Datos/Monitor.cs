using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Monitor
    {
        string dni;
        DateTime fechaNaci;

        public Monitor()
        {

        }

        public Monitor(string dni,DateTime fechaNaci)
        {
            this.dni = dni;
            this.fechaNaci = fechaNaci;

        }


        public string Mydni
        {
            get { return dni; }
            set { dni = value; }
        }

        public DateTime MyfechaNaci
        {
            get { return fechaNaci; }
            set { fechaNaci = value; }
        }

        // override object.Equals

        public override bool Equals(object obj)

        {

            Monitor personObj = obj as Monitor;

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
