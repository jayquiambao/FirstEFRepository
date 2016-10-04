using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using ADO.NETLibrary.Entities;
using System.Configuration;
using System.Data;

namespace ADO.NETLibrary
{
    public class DataAccess
    {
        private SqlConnection connection;
        private string connectionString;

        private int result = 0;

        public DataAccess()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DbConnectionString"].ConnectionString;
        }

        public List<SalesReason> Read()
        {
            var listOfSalesReason = new List<SalesReason>();
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    SqlDataReader rdr = null;
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Sales.SalesReason", connection);

                    rdr = cmd.ExecuteReader();
                    if (rdr.HasRows)
                    {
                        while (rdr.Read())
                        {
                            listOfSalesReason.Add(new SalesReason()
                            {
                                SalesReasonID = Convert.ToInt32(rdr["SalesReasonID"].ToString()),
                                Name = rdr["Name"].ToString(),
                                ReasonType = rdr["ReasonType"].ToString(),
                                ModifiedDate = Convert.ToDateTime(rdr["ModifiedDate"].ToString())
                            });
                        }
                    }
                }
                return listOfSalesReason;
            }
            catch (Exception)
            {
                return listOfSalesReason;
            }
        }

        public int Insert(string name, string reason, string date)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Sales.SalesReason VALUES(@name,@reason,@date)", connection);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@reason", reason);
                    cmd.Parameters.AddWithValue("@date", date);
                    result = cmd.ExecuteNonQuery();
                    return result;
                }
            }
            catch (Exception)
            {
                return result;
            }
        }

        public int Update(int id, string name, string reason, string date)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Sales.SalesReason SET Name = @name, ReasonType = @reason, ModifiedDate = @date WHERE SalesReasonID = @id", connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@reason", reason);
                    cmd.Parameters.AddWithValue("@date", date);
                    result = cmd.ExecuteNonQuery();
                    return result;
                }
            }
            catch (Exception)
            {
                return result;
            }
        }

        public int Delete(int id)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Sales.SalesReason WHERE SalesReasonID = @id", connection);
                    cmd.Parameters.AddWithValue("@id", id);
                    result = cmd.ExecuteNonQuery();
                    return result;
                }
            }
            catch (Exception)
            {
                return result;
            }
        }

        public int ExecuteScalar()
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Sales.SalesReason", connection);
                    result = Convert.ToInt32(cmd.ExecuteScalar());
                    return result;
                }
            }
            catch (Exception)
            {
                return result;
            }
        }

        public List<EmployeeManager> StoredProcedure(int id)
        {
            var listOfEmployeeManager = new List<EmployeeManager>();
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    SqlDataReader rdr = null;
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("uspGetEmployeeManagers", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@BusinessEntityID", id));
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        listOfEmployeeManager.Add(new EmployeeManager()
                        {
                            FirstName = rdr["FirstName"].ToString(),
                            LastName = rdr["LastName"].ToString(),
                            ManagerFirstName = rdr["ManagerFirstName"].ToString(),
                            ManagerLastName = rdr["ManagerLastName"].ToString()
                        });
                    }
                }
                return listOfEmployeeManager;
            }
            catch (Exception)
            {
                return listOfEmployeeManager;
            }
        }

        public string GetTransactionResult(int result)
        {
            if(result==1)
            {
                return "Transaction Successful";
            }
            else
            {
                return "Transaction Failed";
            }
        }
    }
}
