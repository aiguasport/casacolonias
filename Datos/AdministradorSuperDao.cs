using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class AdministradorSuperDao
    {


        private static BDConect dataSource;

        public AdministradorSuperDao()
        {
            dataSource = BDConect.getInstance();
        }

        public void AddAdmin(Personal person)
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

           
        }
       
    }
}
