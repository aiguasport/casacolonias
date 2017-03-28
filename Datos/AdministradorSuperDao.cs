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

        
       
    }
}
