using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ControladorPersonal
    {
        PersonalDAO personal;
        AdministradorSuperDao administrador;
        MonitorDAO monitorControl;

        public ControladorPersonal()
        {
            personal = new PersonalDAO();
            administrador = new AdministradorSuperDao();
            monitorControl = new MonitorDAO();
        }

        //Comprobar si un usuario que intenta logerase existe en la tabla personal
        public bool comprobarPersonal(string nif,string mail)
        {
            return personal.getPersonalLogin(nif, mail);
        }

        //obtemos el rol de un adminstrador pasandole como parametro el nif
        
        public int getRolAdministrador(string nif)
        {
            return personal.getRolAdministrador(nif);
        }
        //Obtiene el Rol del monitor pasandole como parametro el nif
        public int getRolMonitor(string nif)
        {
            return personal.getRolMonitor(nif);
        }

        //Añade un objeto personal a la tabla de personal
        //devuelve un 1 en caso de ser Ok , 0 en caso de error
        public int AddPersonal(Personal person)
        {
            return personal.AddPersonal(person);
        }

        //añade un administrador a la tabla administrador,se le pasa un objeto Administrador
        //devuelve un 1 en caso de ser Ok , 0 en caso de error
        public int addAdmin(Administrador admin)
        {
            return administrador.addAdmin(admin);
        }

        //Devuelve una lista completa de toda la tabla personal
        //return una lista de objetos personal,null en caso de error
        public List<Personal> getAllPersonal()
        {
            return personal.getAllPersonal();
        }

        //devuelve una lista de la tabla administrador
        //return una lista de objetos administrador,null en caso de error
        public List<Administrador> getAllAdministrador()
        {
            return administrador.getAllAdministrador();
        }

        //Busca un registro en la tabla personal,pasando como parametro el dni
        //deveulve un dataset,se debe tratar en el formulario,null si hay un error
        public DataSet getAllPersonalAdminByDni(string dni)
        {
            return personal.getAllPersonalAdminByDni(dni);
        }

        //Actualiza la tabla persona,se le pasa como parametro un objeto persona
        //devuelve 1 si la actualizacion es ok , 0 si es erronea
        public int updatePersona(Personal person)
        {
            return personal.updatePersona(person);
        }

        //Update la tabla administrador,se le pasa como parametro un objeto administrador
        //devuelve 1 si la actualizacion es ok , 0 si es erronea
        public int updateAdmin(Administrador admin)
        {
            return administrador.updateAdmin(admin);
        }
        //Añade un objeto monitor a la tabla monitor
        //devuelve 1 si la actualizacion es ok , 0 si es erronea
        public int addMonitor(Monitor monitor)
        {
            return monitorControl.addMonitor(monitor);
        }
        //Actualiza la un registro en la tabla monitor, se le pasa como parametro un objeto monitor
        //devuelve 1 si la actualizacion es ok , 0 si es erronea
        public int updateMonitor(Monitor monitor)
        {
            return monitorControl.updateMonitor(monitor);
        }

        //Funcion para devolver una mezcla de la tablas personal y administrador por DNI
        //devuelve un DataSet,que hay que tratar en en el formulario,en caso de error devuelve null
        public DataSet getAllPersonalMonitorByDni(string dni)
        {
            return personal.getAllPersonalMonitorByDni(dni);
        }

        //Funcion para devolver una mezcla de la tablas personal y administrador
        //devuelve un DataSet,que hay que tratar en en el formulario,en caso de error devuelve null
        public DataSet getAllPersonalMonitor()
        {
            return monitorControl.getAllPersonalMonitor();
        }

        //funcion para eliminar un registro de la tabla monitor por dni
        //devuelve 1 si la actualizacion es ok , 0 si es erronea
        public int borrarMonitor(string dni)
        {
            return monitorControl.borrarMonitor(dni);
        }
        //funcion para eliminar un registro de la tabla personal por dni
        //devuelve 1 si la actualizacion es ok , 0 si es erronea
        public int borrarPersonal(string dni)
        {
            return personal.borrarPersonal(dni);
        }
        //Funcion para devolver una combinacion de las tablas personal y administrador
        //Devuelve un dataset que hay que tratar en el formulario
        public DataSet getAllAdministradorFull()
        {
            return administrador.getAllAdministradorFull();
        }


    }
}
