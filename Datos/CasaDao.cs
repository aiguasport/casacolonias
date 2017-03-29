using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CasaDao
    {

        private static BDConect dataSource;

        public CasaDao()
        {
            dataSource = BDConect.getInstance();
        }

        public List<Casa> getAllCasas()
        {
            List<Casa> casa = new List<Casa>();

            DataSet dataPersonal = new DataSet();
            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;
            String sql;
            sql = "SELECT * from casa";
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
                    casa.Add(new Casa(Convert.ToInt16(row["codigo"]), Convert.ToString(row["nombre"]), Convert.ToInt16(row["codigo_comarca"]), Convert.ToInt16(row["litoral"])));
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

            return casa;

        }

       
        
        }
    }
