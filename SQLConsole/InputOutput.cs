using System;
using System.Collections.Generic;
using EntityLibrary;
using EntityLibrary.CustomEntity;

namespace SQLConsole
{
    public class InputOutput
    {
        public void DisplayMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("[1] Retrieve using query");
            Console.WriteLine("[2] Retrieve using lambda");
            Console.WriteLine("[3] Create");
            Console.WriteLine("[4] Update");
            Console.WriteLine("[5] Delete");
            Console.WriteLine("[6] Execute Scalar");
            Console.WriteLine("[7] Stored Procedure");
            Console.WriteLine("[8] Exit");
        }

        public char InputChoice()
        {
            Console.Write("Input Choice: ");
            return Console.ReadKey().KeyChar;
        }

        public void DisplayListOfSalesReason(List<SalesReason> listOfSalesReason)
        {
            Console.WriteLine("{0,3} {1,27} {2,15}", "ID", "Name", "ReasonType");
            foreach (var item in listOfSalesReason)
            {
                Console.WriteLine("{0,3} {1,27} {2,15}", item.SalesReasonID, item.Name, item.ReasonType);
            }
        }

        public void DisplaySelectedSalesReason(SalesReason objSalesReason)
        {
            Console.WriteLine("{0,3} {1,27} {2,15}", "ID", "Name", "ReasonType");
            Console.WriteLine("{0,3} {1,27} {2,15}", objSalesReason.SalesReasonID, objSalesReason.Name, objSalesReason.ReasonType);
        }

        public int InputID()
        {
            int id = 0;
            Console.Write("Input ID: ");
            int.TryParse(Console.ReadLine(), out id);
            return id;
        }

        public string InputName()
        {
            Console.Write("Input Name: ");
            return Console.ReadLine();
        }

        public string InputReasonType()
        {
            Console.Write("Input Reason Type: ");
            return Console.ReadLine();
        }

        public void DisplayTransactionResult(string result)
        {
            Console.WriteLine(result);
        }

        public void DisplayScalarResult(int result)
        {
            Console.WriteLine("Number of Count in Sales.SalesReason Table: " + result);
        }

        public void DisplayListOfEmployeeManager(List<CustomEmployeeManager> listOfEmployeeManager)
        {
            Console.WriteLine("{0,20} {1,20}", "Employee Name", "Manager Name");
            foreach (var item in listOfEmployeeManager)
            {
                Console.WriteLine("{0,20} {1,20}", item.FirstName + " " + item.LastName, item.ManagerFirstName + " " + item.ManagerLastName);
            }
        }

        public void DisplayListOfError(List<Exception> listOfException)
        {
            foreach (var item in listOfException)
            {
                Console.WriteLine("Error: " + item.Message);
            }
        }

        public void Continue()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue");
            Console.ReadKey();
        }
    }
}
