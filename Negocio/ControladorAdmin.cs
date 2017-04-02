using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
   public class ControladorAdmin
    {
        AdministradorDAO admindao;
        public ControladorAdmin()
        {
            this.admindao = new AdministradorDAO();
        }
       //Comprobar si el niño existe
        public Boolean exists(int carnet)
        {
            return admindao.exist(carnet);
        }
       //Añadir niño
        public Boolean add(Childe childe)
        {
            return admindao.add(childe);
        }
       //Modificar niño
        public Boolean update(Childe childe)
        {
            return admindao.update(childe);
        }
    }
}
