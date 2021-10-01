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
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Andrew Feely\OneDrive\Documents\CIT\Summer 2021\INFO 1434\Projects\SqlPhoneApp\SqlPhoneApp\PhoneDatabase.mdf;Integrated Security=True";
            // HomeConnection   Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=N:\1434\Summer21\SqlPhoneApp\SqlPhoneApp\PhoneDatabase.mdf;Integrated Security=True
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\1434\Summer21\WindowsFormsApp1\WindowsFormsApp1\PhoneDatabase.mdf;Integrated Security=True";

            SqlConnection connection = new SqlConnection(connectionString);

            return connection;
        }
    }
}
