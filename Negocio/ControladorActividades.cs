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

        //Funcion para devolver una lista de todas las casas
        //Devuelve una lista con objetos casa,null en caso de error
        public List<Casa> getAllCasas()
        {
            return casaDao.getAllCasas();
        }
        //Añade una actividad a la tabla actividad
        //Se le pasa como parametro un objeto actividad
        //devuelve 1 si el añadir es ok o 0 en caso de error
        public int addActividad(Actividad actividad)
        {
            return actividadCasa.addActividad(actividad);

        }
        //Añade una actividad a la tabla actividad_casa
        //Se le pasa como parametro un objeto actividad_casa
        //devuelve 1 si el añadir es ok o 0 en caso de error
        public int addActividadCasa(Actividad actividad)
        {
            return actividadCasa.addActividadCasa(actividad);
        }

        //Funcion para devolver una combinacion de las tablas actividad y actividad_casa
        //Devuelve un DataSet o un null en caso de error
        public DataSet getAllActividadYCasa()
        {
            return actividadCasa.getAllActividadYCasa();
        }
    }
}
