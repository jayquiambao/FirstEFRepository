using System;
using System.Collections.Generic;
using System.Linq;
using EntityLibrary;
using EntityLibrary.CustomEntity;
using System.Data.SqlClient;
using System.Data.Entity;

namespace BusinessLogicLibrary
{
    public class CRUDManager
    {
        //For GitHub
        public List<Exception> listOfException = new List<Exception>();

        public List<SalesReason> RetrieveUsingQuery()
        {
            var results = new List<SalesReason>();

            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    results = (from sr in context.SalesReasons
                                   orderby sr.Name
                                   select sr).ToList();

                    if (results != null)
                    {
                        return results;
                    }
                }
            }
            catch (Exception e)
            {
                listOfException.Add(e);
            }
            return results = null;
        }

        public SalesReason RetrieveUsingLambda(int? id)
        {
            var result = new SalesReason();

            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    result = context.SalesReasons.Where(sr => sr.SalesReasonID == id).FirstOrDefault();

                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            catch (Exception e)
            {
                listOfException.Add(e);
            }
            return result = null;
        }

        public int AddSalesReason(SalesReason salesReason)
        {
            int returnValue = 0;

            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    salesReason.ModifiedDate = DateTime.Now;

                    context.SalesReasons.Add(salesReason);

                    returnValue = context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                listOfException.Add(e);
            }
            return returnValue;
        }

        public int UpdateSalesReason(SalesReason salesReason)
        {
            int returnValue = 0;

            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    salesReason.ModifiedDate = DateTime.Now;
                    //var result = context.SalesReasons.Where(sr => sr.SalesReasonID == salesReason.SalesReasonID).FirstOrDefault();
                    context.Entry(salesReason).State = EntityState.Modified;
                    returnValue = context.SaveChanges();
                    //context.Entry(result).State = System.Data.Entity.EntityState.Modified;
                }
            }
            catch (Exception e)
            {
                listOfException.Add(e);
            }
            return returnValue;
        }

        public int DeleteSalesReason(int id)
        {
            int returnValue = 0;

            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    returnValue = context.Database.ExecuteSqlCommand("DELETE FROM Sales.SalesReason WHERE SalesReasonID = @id", new SqlParameter("@id", id));
                }
            }
            catch (Exception e)
            {
                listOfException.Add(e);
            }
            return returnValue;
        }

        public int ExecuteScalar()
        {
            int result = 0;
            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    result = context.Database.SqlQuery<int>("SELECT COUNT(*) FROM Sales.SalesReason").SingleOrDefault();
                }
            }
            catch (Exception e)
            {
                listOfException.Add(e);
            }
            return result;
        }

        public List<CustomEmployeeManager> ExecuteStoredProcedure(int id)
        {
            var listOfEmployeeManager = new List<CustomEmployeeManager>();

            try
            {
                using (var context = new AdventureWorks2008Entities())
                {
                    var results = context.Database.SqlQuery<uspGetEmployeeManagers_Result>("uspGetEmployeeManagers @id", new SqlParameter("@id", id));

                    if (results != null)
                    {
                        foreach (var item in results)
                        {
                            listOfEmployeeManager.Add(new CustomEmployeeManager()
                            {
                                FirstName = item.FirstName,
                                LastName = item.LastName,
                                ManagerFirstName = item.ManagerFirstName,
                                ManagerLastName = item.ManagerLastName
                            });
                        }
                    }
                }
            }
            catch (Exception e)
            {
                listOfException.Add(e);
            }
            return listOfEmployeeManager;
        }

        public string GetTransactionResult(int result)
        {
            if (result == 1)
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
