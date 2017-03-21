using MySql.Data.MySqlClient;
using System;


namespace Datos
{
    public class BDConect
    {

        private static readonly String HOST = "localhost";
        private static readonly String BD = "casa_colonias";
        private static readonly String USER = "alumne";
        private static readonly String PASSWORD = "alumne";
        private static MySqlConnection sqlCon;
        private static BDConect instance = null;

        protected BDConect()
        {

        }

        public static BDConect getInstance()
        {
            if (instance == null)
            {
                instance = new BDConect();
            }
            return instance;
        }

        public MySqlConnection getConnection()
        {
                
                sqlCon = new MySqlConnection("Server=" + HOST + ";Database=" + BD + ";Uid=" + USER + ";Pwd=" + PASSWORD + ";");
            
            return sqlCon;
        }
    }
}

