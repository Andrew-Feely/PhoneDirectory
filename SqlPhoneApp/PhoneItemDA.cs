using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlPhoneApp
{
    public class PhoneItemDA
    {
        public static List<DirectoryItem> GetAll()
        {
            List<DirectoryItem> allItems = new List<DirectoryItem>();

            // get a connection
            SqlConnection conn = PhoneItemDB.GetConnection();
            // get sqlStatement
            string selectStatement = "Select * from PhoneTable";
            // get sqlCommand
            SqlCommand selectCommand = new SqlCommand(selectStatement, conn);

            try
            {
                // open the connection;
                conn.Open();

                // execute the command
                SqlDataReader reader = selectCommand.ExecuteReader();

                while (reader.Read())
                {
                    DirectoryItem d = new DirectoryItem();

                    d.Id = Convert.ToInt16(reader["Id"]);
                    d.FirstName = reader["FirstName"].ToString();
                    d.LastName = reader["Lastname"].ToString();
                    d.PhoneNumber = reader["PhoneNumber"].ToString();
                    d.Dept = reader["Dept"].ToString();
                    d.Active = Convert.ToBoolean(reader["Active"]);

                    allItems.Add(d);

                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return allItems;
        }

        internal static void Delete(DirectoryItem directoryItem)
        {
            SqlConnection conn = PhoneItemDB.GetConnection();

            string deleteStatement = "Delete from PhoneTable Where Id = @id";

            SqlCommand deleteCommand = new SqlCommand(deleteStatement, conn);

            deleteCommand.Parameters.AddWithValue("@id", directoryItem.Id);

            try
            {
                conn.Open();

                deleteCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        internal static void Edit(DirectoryItem selectedItem)
        {
            // get a connection
            SqlConnection conn = PhoneItemDB.GetConnection();

            string updateStatement = "Update PhoneTable set FirstName = @fname, LastName = @lname, PhoneNumber = @phone, Dept = @dept, Active = @active where Id = @id";

            SqlCommand updateCommand = new SqlCommand(updateStatement, conn);

            updateCommand.Parameters.AddWithValue("@fname", selectedItem.FirstName);
            updateCommand.Parameters.AddWithValue("@lname", selectedItem.LastName);
            updateCommand.Parameters.AddWithValue("@phone", selectedItem.PhoneNumber);
            updateCommand.Parameters.AddWithValue("@dept", selectedItem.Dept);
            updateCommand.Parameters.AddWithValue("@active", selectedItem.Active);
            updateCommand.Parameters.AddWithValue("@id", selectedItem.Id);

            try
            {
                conn.Open();

                updateCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        internal static void Add(DirectoryItem directoryItem)
        {
            // get a connection
            SqlConnection conn = PhoneItemDB.GetConnection();
            // get sqlStatement
            string insertStatement = "Insert PhoneTable (FirstName, LastName, PhoneNumber, Dept, Active) values (@fname, @lname, @phone, @dept, @active)";

            // get sqlCommand
            SqlCommand insertCommand = new SqlCommand(insertStatement, conn);
            // insert the perameters

            insertCommand.Parameters.AddWithValue("@fname", directoryItem.FirstName);
            insertCommand.Parameters.AddWithValue("@lname", directoryItem.LastName);
            insertCommand.Parameters.AddWithValue("@phone", directoryItem.PhoneNumber);
            insertCommand.Parameters.AddWithValue("@dept", directoryItem.Dept);
            insertCommand.Parameters.AddWithValue("@active", directoryItem.Active);

            try
            {
                conn.Open();

                insertCommand.ExecuteNonQuery(); // after this statement It has a Id

                // fix the Id propblem
                string selectStatement = "Select IDENT_CURRENT ('PhoneTable') from PhoneTable";
                SqlCommand selectCommand = new SqlCommand(selectStatement, conn);
                int theId = Convert.ToInt16(selectCommand.ExecuteScalar());

                directoryItem.Id = theId;
            }

            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

    }
}
