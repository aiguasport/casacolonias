﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class MonitorDAO
    {

        private static BDConect dataSource;

        public MonitorDAO()
        {
            dataSource = BDConect.getInstance();
        }

        //Añade una monitor a la tabla Monitor
        //Parametro = objeto Monitor
        //return 1 si la insercion es correcta o 0 si es error
        public int addMonitor(Monitor monitor)
        {
            int result = 0;

            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;

            String sql;
            String fechaConver = monitor.MyfechaNaci.ToString("yyyy/MM/dd");
            sql = "INSERT INTO monitor (dni, fecha_nac) VALUES ('" + monitor.Mydni.ToString() + "', '" + fechaConver + "')";

            try
            {
                connection = dataSource.getConnection();
                connection.Open();
                mysqlCmd = new MySqlCommand(sql, connection);
                mysqlAdapter = new MySqlDataAdapter(mysqlCmd);
                mysqlCmd.ExecuteNonQuery();
                result = 1;
            }
            catch (Exception e)
            {
                Console.Write(e);
                result = 0;
            }
            finally
            {
                if (mysqlCmd != null) mysqlCmd.Dispose();
                if (mysqlAdapter != null) mysqlAdapter.Dispose();
                if (connection != null) connection.Close();
            }

            return result;
        }

        //Actualizar un registro de la tabla monitor
        //Parametro = objeto monitor
        //return 1 si la insercion es correcta o 0 si es error
        public int updateMonitor(Monitor monitor)
        {
            int result = 0;

            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;
            String fechaConver = monitor.MyfechaNaci.ToString("yyyy/MM/dd");
            String sql;
            sql = "UPDATE monitor SET dni='" + monitor.Mydni.ToString() + "',fecha_nac='" + fechaConver + "'"
                + " WHERE dni ='" + monitor.Mydni.ToString() + "'";

            try
            {
                connection = dataSource.getConnection();
                connection.Open();
                mysqlCmd = new MySqlCommand(sql, connection);
                mysqlAdapter = new MySqlDataAdapter(mysqlCmd);
                mysqlCmd.ExecuteNonQuery();
                result = 1;
            }
            catch (Exception e)
            {
                Console.Write(e);
                result = 0;
            }
            finally
            {
                if (mysqlCmd != null) mysqlCmd.Dispose();
                if (mysqlAdapter != null) mysqlAdapter.Dispose();
                if (connection != null) connection.Close();
            }

            return result;
        }
        //Funcion para devolver una combinacion de las tablas Personal y monitor
        //Devuelve un DataSet o un null en caso de error
        public DataSet getAllPersonalMonitor()
        {
            DataSet dataPersonal = new DataSet();
            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;
            String sql;
            sql = "SELECT p.dni as dni,p.nombre as nombre,p.apellidos as apellidos,p.mail as mail,a.fecha_nac as fecha FROM personal as p,monitor as a where p.dni = a.dni";
            try
            {
                connection = dataSource.getConnection();
                connection.Open();
                mysqlCmd = new MySqlCommand(sql, connection);
                mysqlAdapter = new MySqlDataAdapter(mysqlCmd);
                mysqlAdapter.Fill(dataPersonal);


            }
            catch (Exception e)
            {
                Console.Write(e);
                dataPersonal = new DataSet();
            }
            finally
            {
                if (mysqlCmd != null) mysqlCmd.Dispose();
                if (mysqlAdapter != null) mysqlAdapter.Dispose();
                if (connection != null) connection.Close();
            }

            return dataPersonal;


        }

        //Borrar un registro de la tabla monitor
        //Parametro = dni del monitor
        //return 1 si la insercion es correcta o 0 si es error
        public int borrarMonitor(string dni)
        {

            int result = 0;

            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;
           
            String sql;
            sql = "DELETE FROM monitor WHERE dni='"+dni+"'";

            try
            {
                connection = dataSource.getConnection();
                connection.Open();
                mysqlCmd = new MySqlCommand(sql, connection);
                mysqlAdapter = new MySqlDataAdapter(mysqlCmd);
                mysqlCmd.ExecuteNonQuery();
                result = 1;
            }
            catch (Exception e)
            {
                Console.Write(e);
                result = 0;
            }
            finally
            {
                if (mysqlCmd != null) mysqlCmd.Dispose();
                if (mysqlAdapter != null) mysqlAdapter.Dispose();
                if (connection != null) connection.Close();
            }

            return result;
        }
    }
}
