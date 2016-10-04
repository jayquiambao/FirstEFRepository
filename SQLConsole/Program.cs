using System;
using BusinessLogicLibrary;

namespace SQLConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new CRUDManager();
            var inputOuput = new InputOutput();

            char choice;
            int id;
            string name;
            string reasonType;

            do
            {
                Console.Clear();
                inputOuput.DisplayMenu();
                choice = inputOuput.InputChoice();

                Console.WriteLine();
                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        inputOuput.DisplayListOfSalesReason(data.RetrieveUsingQuery());
                        inputOuput.DisplayListOfError(data.listOfException);
                        inputOuput.Continue();
                        break;
                    case '2':
                        id = inputOuput.InputID();
                        inputOuput.DisplaySelectedSalesReason(data.RetrieveUsingLambda(id));
                        inputOuput.DisplayListOfError(data.listOfException);
                        inputOuput.Continue();
                        break;
                    case '3':
                        name = inputOuput.InputName();
                        reasonType = inputOuput.InputReasonType();
                        inputOuput.DisplayTransactionResult(data.GetTransactionResult(data.AddSalesReason(name, reasonType)));
                        inputOuput.DisplayListOfError(data.listOfException);
                        inputOuput.Continue();
                        break;
                    case '4':
                        id = inputOuput.InputID();
                        name = inputOuput.InputName();
                        reasonType = inputOuput.InputReasonType();
                        inputOuput.DisplayTransactionResult(data.GetTransactionResult(data.UpdateSalesReason(id, name, reasonType)));
                        inputOuput.DisplayListOfError(data.listOfException);
                        inputOuput.Continue();
                        break;
                    case '5':
                        id = inputOuput.InputID();
                        inputOuput.DisplayTransactionResult(data.GetTransactionResult(data.DeleteSalesReason(id)));
                        inputOuput.DisplayListOfError(data.listOfException);
                        inputOuput.Continue();
                        break;
                    case '6':
                        inputOuput.DisplayScalarResult(data.ExecuteScalar());
                        inputOuput.DisplayListOfError(data.listOfException);
                        inputOuput.Continue();
                        break;
                    case '7':
                        id = inputOuput.InputID();
                        inputOuput.DisplayListOfEmployeeManager(data.ExecuteStoredProcedure(id));
                        inputOuput.DisplayListOfError(data.listOfException);
                        inputOuput.Continue();
                        break;
                    case '8':
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
            while (choice != '8');
        }
    }
}
