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
        public DataSet getAllPersonal()
        {
            DataSet dataPersonal = new DataSet();
            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;
            String sql;
            sql = "SELECT * from personal;";
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
            sql = "SELECT count(dni) as result from administrador where dni = '" + nif + "' and titulación = 'super'";
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

            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;

            String sql;
            sql = "INSERT INTO personal (dni, nombre, apellidos, mail) VALUES ('{0}', '{1}', '{2}', '{3}')";
            person.MyNif.ToString();
            person.MyNombre.ToString();
            person.MyApellidos.ToString();
            person.MyMail.ToString();
            try
            {
                connection = dataSource.getConnection();
                connection.Open();
                mysqlCmd = new MySqlCommand(sql, connection);
                mysqlAdapter = new MySqlDataAdapter(mysqlCmd);
                mysqlCmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.Write(e);

            }
            finally
            {
                if (mysqlCmd != null) mysqlCmd.Dispose();
                if (mysqlAdapter != null) mysqlAdapter.Dispose();
                if (connection != null) connection.Close();
            }

            return 0;
        }

    }
}
