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

        public int addAdmin(Administrador admin)
        {
            int result = 0;

            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;

            String sql;
            sql = "INSERT INTO personal (dni, num_SS, titulacion) VALUES ('{0}', '{1}', '{2}')";
            admin.Mydni.ToString();
            admin.Mynum_SS.ToString();
            admin.Mytitulacion.ToString();

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
