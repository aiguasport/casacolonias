using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Actividad
    {
        int codigoActividad;
        String descripcion;
        int nivel;
        int codigoCasa;

        public Actividad()
        {

        }

        public Actividad(int codigoActividad,string descripcion,int nivel,int codigoCasa)
        {
            this.codigoActividad = codigoActividad;
            this.descripcion = descripcion;
            this.nivel = nivel;
            this.codigoCasa = codigoCasa;

        }

        public int MycodigoActividad
        {
            get { return codigoActividad; }
            set { codigoActividad = value; }
        }

        public string Mydescripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public int Mynivel
        {
            get { return nivel; }
            set { nivel = value; }
        }

        public int MycodigoCasa
        {
            get { return codigoCasa; }
            set { codigoCasa = value; }
        }

        // override object.Equals

        public override bool Equals(object obj)

        {

            Actividad personObj = obj as Actividad;

            if (personObj == null)

                return false;

            else

                return codigoActividad.Equals(personObj.codigoActividad);

        }

        // override object.GetHashCode

        public override int GetHashCode()

        {

            return this.codigoActividad.GetHashCode();

        }
    }
}
