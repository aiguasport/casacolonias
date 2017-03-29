using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
   public class ActividadDao
    {
        private static BDConect dataSource;

        public ActividadDao()
        {
            dataSource = BDConect.getInstance();
        }

        public int addActividad(Actividad actividad)
        {
  
            int result = 0;

            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;

            String sql;
        
            sql = "INSERT INTO actividad (codigo, description) VALUES ('" + actividad.MycodigoActividad.ToString() + "', '" + actividad.Mydescripcion.ToString() + "')";

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

        public int addActividadCasa(Actividad actividad)
        {

            int result = 0;

            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;

            String sql;
           
            sql = "INSERT INTO actividad_casa (codigo_actividad, nivel_calidad,codigo_casa) VALUES ('" + actividad.MycodigoActividad.ToString() + "', '" + actividad.Mynivel.ToString() + "', '" + actividad.MycodigoCasa.ToString() + "')";

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

        public DataSet getAllActividadYCasa()
        {
            DataSet dataActividad = new DataSet();
            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;
            String sql;
            sql = "SELECT ac.codigo_actividad as codigo,a.description as descrip,ac.nivel_calidad as nivel"
                +", c.nombre as nombre FROM actividad as a,casa as c, actividad_casa as ac WHERE a.codigo = ac.codigo_actividad and c.codigo = ac.codigo_casa ";
            try
            {
                connection = dataSource.getConnection();
                connection.Open();
                mysqlCmd = new MySqlCommand(sql, connection);
                mysqlAdapter = new MySqlDataAdapter(mysqlCmd);
                mysqlAdapter.Fill(dataActividad);


            }
            catch (Exception e)
            {
                Console.Write(e);
                dataActividad = new DataSet();
            }
            finally
            {
                if (mysqlCmd != null) mysqlCmd.Dispose();
                if (mysqlAdapter != null) mysqlAdapter.Dispose();
                if (connection != null) connection.Close();
            }

            return dataActividad;


        }



    }
}
