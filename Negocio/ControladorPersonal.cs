using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ControladorPersonal
    {
        PersonalDAO personal;

        public ControladorPersonal()
        {
            personal = new PersonalDAO();
        }

        public bool comprobarPersonal(string nif,string mail)
        {
            return personal.getPersonalLogin(nif, mail);
        }
        public int getRolAdministrador(string nif)
        {
            return personal.getRolAdministrador(nif);
        }

        public int getRolMonitor(string nif)
        {
            return personal.getRolMonitor(nif);
        }


    }
}
