using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlPhoneApp
{
    public class PhoneItemDB
    {

        public static SqlConnection GetConnection()
        {

            // need a connectionString

            // School Connection
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=*here*PhoneDatabase.mdf;Integrated Security=True"; //Todo: insert path to local database at specified location

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}
