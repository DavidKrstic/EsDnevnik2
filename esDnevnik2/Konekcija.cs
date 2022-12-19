using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace esDnevnik2
{
    internal class Konekcija
    {
        static public SqlConnection Connect()
        {
            string CS = ConfigurationManager.ConnectionStrings["home"].ConnectionString; 
            SqlConnection veza = new SqlConnection(CS);
            return veza;
        }
    }
}
