using System;
using System.Threading;

namespace EmployeeManagement
{
    public abstract class EmployeeRecordSystem   //abstract class
    {
        public  abstract void HomePage();
    }





    class EmployeeRecords : EmployeeRecordSystem
    {
        public override void HomePage()
        {
            
            var employee = new EmployeeDetails();

            Console.WriteLine("\n..........EMPLOYEE MANAGEMENT SYSTEM........\n\n");

        InitialPhase:

            Console.WriteLine("\n\n 1.Add New Employee");
            Console.WriteLine(" 2.Update Existing Employee");
            Console.WriteLine(" 3.Delete Existing Employee");
            Console.WriteLine(" 4.Show Employee Records");
            Console.WriteLine(" 5.QUIT");

        InputOptions:
            Console.WriteLine("\n Choose any number from the above Options : ");
            bool isValidOption = int.TryParse(Console.ReadLine(), out int Count);


            if (!isValidOption)
            {
                Console.WriteLine($"Specify only the numeric values which ranges from 1 to 5.");
                goto InputOptions;
            }
            Thread DeleteEmployeeThread = new Thread(employee.DeleteEmployee);
           


            switch (Count)
            {
                case 1:
                    employee.AddNewEmployee();
                    Console.ReadKey();
                    goto InitialPhase;
                case 2:
                    employee.UpdateEmployee();
                    Console.ReadKey();
                    goto InitialPhase;
                case 3:
                    DeleteEmployeeThread.Start();
                    DeleteEmployeeThread.Join();
                    Console.ReadKey();
                    goto InitialPhase;
                case 4:
                    employee.ShowEmployee();
                    Console.ReadKey();
                    goto InitialPhase;
                case 5:
                    return;

                default:
                    Console.WriteLine("Specify the number from 1 to 5");
                    goto InitialPhase;

            }

        }
    }
}