using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Datos;
using System.Threading.Tasks;
using System.Data;

namespace Negocio
{
    public class ControladorActividades
    {
        CasaDao casaDao = new CasaDao();
        ActividadDao actividadCasa = new ActividadDao();

        public ControladorActividades()
        {
            casaDao = new CasaDao();
            actividadCasa = new ActividadDao();
        }

        public List<Casa> getAllCasas()
        {
            return casaDao.getAllCasas();
        }
        public int addActividad(Actividad actividad)
        {
            return actividadCasa.addActividad(actividad);

        }
        public int addActividadCasa(Actividad actividad)
        {
            return actividadCasa.addActividadCasa(actividad);
        }

        public DataSet getAllActividadYCasa()
        {
            return actividadCasa.getAllActividadYCasa();
        }
    }
}
