using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
   public class Casa
    {
        int codigoCasa;
        String nombreCasa;
        int codigo_comarca;
        int litoral;

        public Casa()
        {

        }

        public Casa(int codigoCasa,string nombreCasa,int codigo_comarca,int litoral)
        {
            this.codigoCasa = codigoCasa;
            this.nombreCasa = nombreCasa;
            this.codigo_comarca = codigo_comarca;
            this.litoral = litoral;
        }


        public int MycodigoCasa
        {
            get { return codigoCasa; }
            set { codigoCasa = value; }
        }
        public string MynombreCasa
        {
            get { return nombreCasa; }
            set { nombreCasa = value; }
        }

        public int Mycodigo_comarca
        {
            get { return codigo_comarca; }
            set { codigo_comarca = value; }
        }

        public int Mylitoral
        {
            get { return litoral; }
            set { litoral = value; }
        }

        // override object.Equals

        public override bool Equals(object obj)

        {

            Casa personObj = obj as Casa;

            if (personObj == null)

                return false;

            else

                return codigoCasa.Equals(personObj.codigoCasa);

        }

        // override object.GetHashCode

        public override int GetHashCode()

        {

            return this.codigoCasa.GetHashCode();

        }


    }
}
