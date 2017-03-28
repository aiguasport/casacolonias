using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class PersonalDAO
    {

        private static BDConect dataSource;

        public PersonalDAO()
        {
            dataSource = BDConect.getInstance();
        }
      //Function to search al personal,
      //return a DataSet,if is null return a null DataSet
        public List<Personal> getAllPersonal()
        {

            DataSet dataPersonal = new DataSet();
            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;
            String sql;
            List<Personal> listPersonal = new List<Personal>();
            sql = "SELECT * from personal;";
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
                    listPersonal.Add(new Personal(Convert.ToString(row["dni"]), Convert.ToString(row["nombre"]), Convert.ToString(row["apellidos"]), Convert.ToString(row["mail"])));
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
        //Seache in table personal one person with param nif and mail,
        //return a true if exist or false or not;
        public Boolean getPersonalLogin(string nif,string mail)
        {
            Boolean result = true;
            DataSet dataPersonal = new DataSet();
            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;
            String sql;
            sql = "SELECT count(dni) as result from personal where dni = '"+nif+"' and mail = '"+mail+"'";
            try
            {
                connection = dataSource.getConnection();
                connection.Open();
                mysqlCmd = new MySqlCommand(sql, connection);
                mysqlAdapter = new MySqlDataAdapter(mysqlCmd);
                mysqlAdapter.Fill(dataPersonal);
                int coun = int.Parse(dataPersonal.Tables[0].Rows[0][0].ToString());
                if (coun != 0)
                {
                    result = true;

                }
                else
                {
                    result = false;
                }

                }
            catch (Exception e)
            {
                Console.Write(e);
                result = false;
            }
            finally
            {
                if (mysqlCmd != null) mysqlCmd.Dispose();
                if (mysqlAdapter != null) mysqlAdapter.Dispose();
                if (connection != null) connection.Close();
            }
            return result;
        }
        //Search if person is in Administrador Table,return 1 if exist or 0 if not;
        public int getRolAdministrador(string nif)
        {
            int result = 0;
            DataSet dataPersonal = new DataSet();
            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;
            String sql;
            sql = "SELECT count(dni) as result from administrador where dni = '" + nif + "' and titulacion = 'super'";
            try
            {
                connection = dataSource.getConnection();
                connection.Open();
                mysqlCmd = new MySqlCommand(sql, connection);
                mysqlAdapter = new MySqlDataAdapter(mysqlCmd);
                mysqlAdapter.Fill(dataPersonal);
                result = int.Parse(dataPersonal.Tables[0].Rows[0][0].ToString());
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
        //Search if person is in Monitor Table,return 1 if exist or 0 if not;
        public int getRolMonitor(string nif)
        {
            int result = 0;
            DataSet dataPersonal = new DataSet();
            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;
            String sql;
            sql = "SELECT count(dni) as result from monitor where dni = '" + nif + "'";
            try
            {
                connection = dataSource.getConnection();
                connection.Open();
                mysqlCmd = new MySqlCommand(sql, connection);
                mysqlAdapter = new MySqlDataAdapter(mysqlCmd);
                mysqlAdapter.Fill(dataPersonal);
                result = int.Parse(dataPersonal.Tables[0].Rows[0][0].ToString());
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

        public int AddPersonal(Personal person)
        {
            int result = 0;

            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;

            String sql;
            sql = "INSERT INTO personal (dni, nombre, apellidos, mail) VALUES ('"+ person.MyNif.ToString() + "', '" + person.MyNombre.ToString() + "'"
                +", '" + person.MyApellidos.ToString() + "', '" + person.MyMail.ToString() + "')";
 
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

        public DataSet getAllPersonalAdminByDni(string dni)
        {
            DataSet dataPersonal = new DataSet();
            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;
            String sql;
            sql = "SELECT p.dni as dni,p.nombre as nombre,p.apellidos as apellidos,p.mail as mail,a.num_SS as ss,a.titulacion as titulo FROM personal as p,administrador as a WHERE p.dni = a.dni and p.dni ='"+dni+"'";
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

        public DataSet getAllPersonalMonitorByDni(string dni)
        {
            DataSet dataPersonal = new DataSet();
            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;
            String sql;
            sql = "SELECT p.dni as dni,p.nombre as nombre,p.apellidos as apellidos,p.mail as mail,a.fecha_nac as fecha FROM personal as p,monitor as a WHERE p.dni = a.dni and p.dni ='" + dni + "'";
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
        public int updatePersona(Personal person)
        {

            int result = 0;

            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;

            String sql;
            sql = "UPDATE personal SET dni='"+ person.MyNif.ToString() + "',nombre='"+ person.MyNombre.ToString() + "',apellidos='"+ person.MyApellidos.ToString()+"',"
                +"mail='"+ person.MyMail.ToString() + "' WHERE dni ='"+ person.MyNif.ToString() + "'";
            
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
