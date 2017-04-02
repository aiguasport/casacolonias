using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class AdministradorDAO
    {
        
        private static BDConect dataSource;

        public AdministradorDAO()
        {
            dataSource = BDConect.getInstance();
        }
        //comprobar si el niño existe
        public Boolean exist(int carnet)
        {
            Boolean result = true;
            DataSet dataNino = new DataSet();
            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;
            String sql;
            sql = "SELECT count(carnet) as result from nino where carnet = '" + carnet + "'";
            try
            {
                connection = dataSource.getConnection();
                connection.Open();
                mysqlCmd = new MySqlCommand(sql, connection);
                mysqlAdapter = new MySqlDataAdapter(mysqlCmd);
                mysqlAdapter.Fill(dataNino);
                int coun = int.Parse(dataNino.Tables[0].Rows[0][0].ToString());
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
        //devolver el código de la población
        public int poblacionCod(String poblacion)
        {
            int result = -1;
            DataSet dataNino = new DataSet();
            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;
            String sql;
            sql = "SELECT codigo FROM `poblacion` WHERE LOWER(nombre)=LOWER('" + poblacion + "')";
            try
            {
                connection = dataSource.getConnection();
                connection.Open();
                mysqlCmd = new MySqlCommand(sql, connection);
                mysqlAdapter = new MySqlDataAdapter(mysqlCmd);
                mysqlAdapter.Fill(dataNino);
                int poblcod = int.Parse(dataNino.Tables[0].Rows[0][0].ToString());
                if (poblcod != -1)
                {
                    result = poblcod;

                }
                else
                {
                    result = -1;
                }

            }
            catch (Exception e)
            {
                Console.Write(e);
                result = -1;
            }
            finally
            {
                if (mysqlCmd != null) mysqlCmd.Dispose();
                if (mysqlAdapter != null) mysqlAdapter.Dispose();
                if (connection != null) connection.Close();
            }
            return result;
        }
        //Añadir el niño
        public Boolean add(Childe childe)
        {
            Boolean result = true;
            DataSet dataNino = new DataSet();
            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;
            int codigop;
            codigop = this.poblacionCod(childe.Poblacion);

            String sql;
            sql = "INSERT INTO `nino`(`carnet`, `nombre`, `apellidos`, `direccion`, `sexo`, `anio_nac`, `codigo_poblacion`) VALUES (" + childe.Carnet + ", '" + childe.Name + "', '" + childe.Apellidos + "', '" + childe.Direccion + "', '" + childe.Sexo + "', '" + childe.Anionac + "', " + codigop + ")";
             try
            {
                connection = dataSource.getConnection();
                connection.Open();
                mysqlCmd = new MySqlCommand(sql, connection);
                mysqlAdapter = new MySqlDataAdapter(mysqlCmd);
                mysqlCmd.ExecuteNonQuery();
                result = true;
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
        public Boolean update(Childe childe)
        {

            Boolean result = false;

            MySqlConnection connection = null;
            MySqlCommand mysqlCmd = null;
            MySqlDataAdapter mysqlAdapter = null;
            int codigop;
            codigop = this.poblacionCod(childe.Poblacion);
            String sql;
            sql = "UPDATE administrador SET carnet='" + childe.Carnet + "',nombre='" + childe.Name + "',apellidos='" + childe.Apellidos + "', direccion='" + childe.Direccion + "', sexo='" + childe.Sexo + "', anio_nac='" + childe.Anionac + "', codigo_poblacion=" + codigop
                + " WHERE carnet =" + childe.Carnet;

            try
            {
                connection = dataSource.getConnection();
                connection.Open();
                mysqlCmd = new MySqlCommand(sql, connection);
                mysqlAdapter = new MySqlDataAdapter(mysqlCmd);
                mysqlCmd.ExecuteNonQuery();
                result = true;
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
    }
}
