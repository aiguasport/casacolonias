using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class AdministradorSuperDao
    {


        private static BDConect dataSource;

        public AdministradorSuperDao()
        {
            dataSource = BDConect.getInstance();
        }
        //Añade una actividad a la tabla administrador
        //Parametro = objeto Administrador
        //return 1 si la insercion es correcta o 0 si es error
        public int addAdmin(Administrador admin)
        {
            int result = 0;

            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;

            String sql;
            sql = "INSERT INTO administrador (dni, num_SS , titulacion) VALUES ('" + admin.Mydni.ToString() + "', '"+ admin.Mynum_SS.ToString() + "', '"+ admin.Mytitulacion.ToString() + "')";

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

        //Function to list all administradors
        //return a list of adminstradors
        public List<Administrador> getAllAdministrador()
        {

            DataSet dataPersonal = new DataSet();
            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;
            String sql;
            List<Administrador> listPersonal = new List<Administrador>();
            sql = "SELECT * from administrador";
            try
            {
                connection = dataSource.getConnection();
                connection.Open();
                mysqlCmd = new MySqlCommand(sql, connection);
                mysqlAdapter = new MySqlDataAdapter(mysqlCmd);
                mysqlAdapter.Fill(dataPersonal);

                DataTable dt = dataPersonal.Tables[0];

                foreach (DataRow row in dt.Rows)
                {
                    listPersonal.Add(new Administrador(Convert.ToString(row["dni"]), Convert.ToString(row["num_SS"]), Convert.ToString(row["titulacion"])));
                }
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
            return listPersonal;
        }

        //Actualiza un registro de la tabla administrador
        //Parametro = objeto Administrador
        //Devuelve 1 en caso de insercion correcta o 0 en caso de error
        public int updateAdmin(Administrador admin)
        {

            int result = 0;

            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;

            String sql;
            sql = "UPDATE administrador SET dni='" + admin.Mydni.ToString() + "',num_SS='" + admin.Mynum_SS.ToString() + "',titulacion='" + admin.Mytitulacion.ToString() + "'"
                + " WHERE dni ='" + admin.Mydni.ToString() + "'";

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

        //Funcion para devolver una combinacion de las tablas Personal y Administrador
        //Devuelve un DataSet o un null en caso de error
        public DataSet getAllAdministradorFull()
        {

            DataSet dataPersonal = new DataSet();
            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;
            String sql;
            sql = "SELECT p.dni as dni, p.nombre as nombre, p.apellidos as apellidos, p.mail as mail,a.num_SS as num_SS,a.titulacion as titulacion FROM personal as p, administrador as a  WHERE p.dni = a.dni";
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


    }
}
