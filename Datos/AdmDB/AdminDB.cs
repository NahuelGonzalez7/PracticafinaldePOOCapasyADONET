using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Datos.AdmDB
{
    internal class AdminDB
    {
        internal static SqlConnection ConectarBase()
        {
            string consulta = Datos.Properties.Settings.Default.KeyDBClub;
            SqlConnection connection = new SqlConnection(consulta);
            connection.Open();

            return connection;
        }
    }
}
