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
        public int AddPersonal(Personal person)
        {
            return personal.AddPersonal(person);
        }
        public int addAdmin(Administrador admin)
        {
            return administrador.addAdmin(admin);
        }
        public List<Personal> getAllPersonal()
        {
            return personal.getAllPersonal();
        }

        public List<Administrador> getAllAdministrador()
        {
            return administrador.getAllAdministrador();
        }
        public DataSet getAllPersonalAdminByDni(string dni)
        {
            return personal.getAllPersonalAdminByDni(dni);
        }
        public int updatePersona(Personal person)
        {
            return personal.updatePersona(person);
        }
        public int updateAdmin(Administrador admin)
        {
            return administrador.updateAdmin(admin);
        }
        public int addMonitor(Monitor monitor)
        {
            return monitorControl.addMonitor(monitor);
        }

        public int updateMonitor(Monitor monitor)
        {
            return monitorControl.updateMonitor(monitor);
        }
        public DataSet getAllPersonalMonitorByDni(string dni)
        {
            return personal.getAllPersonalMonitorByDni(dni);
        }
        public DataSet getAllPersonalMonitor()
        {
            return monitorControl.getAllPersonalMonitor();
        }
        public int borrarMonitor(string dni)
        {
            return monitorControl.borrarMonitor(dni);
        }
        public int borrarPersonal(string dni)
        {
            return personal.borrarPersonal(dni);
        }


    }
}
