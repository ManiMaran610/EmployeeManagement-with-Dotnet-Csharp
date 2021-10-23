using System;
using System.Collections.Generic;
using System.Data;


namespace EmployeeManagement
{
    public class EmployeeDetails
    {
        public static List<Employee> employees = new List<Employee>();
        AddingEmployee addingEmployee = new AddingEmployee();
        UpdateEmployee updateEmployee = new UpdateEmployee();


        public void AddNewEmployee()

        {
            try
            {
                var newEmployee = addingEmployee.AddEmployee();
                if (employees.Exists(item => item.EmployeeId == newEmployee.EmployeeId) || employees.Exists(item => item.EmployeeName == newEmployee.EmployeeName))
                {
                    throw new EmployeeNameAlreadyExistsException();          // Custom Exception
                }
                else
                {
                    employees.Add(newEmployee);
                    String SqlAddEmployee = ("INSERT INTO EMPLOYEES VALUES(" +
                        $"'{newEmployee.EmployeeId}'," +
                        $"'{newEmployee.EmployeeName}'," +
                        $"{newEmployee.EmployeeMobileNo}," +
                        $"'{newEmployee.EmployeeDob.ToShortDateString()}'," +
                        $"'{newEmployee.EmployeeDoj.ToShortDateString()}'," +
                        $"'{newEmployee.EmployeeEmail}')");
                    Console.WriteLine(SqlAddEmployee);
                    int RowsAffected = Database.SqlOperation(SqlAddEmployee);
                    Console.WriteLine("\n\t{0} Rows Affected", RowsAffected);
                    Console.WriteLine("\n..........Succesfully added the new Employee in the records.......");
                }
            }
            catch (EmployeeNameAlreadyExistsException EmployeeNameAlreadyExistsException)
            {
                Console.WriteLine(EmployeeNameAlreadyExistsException.Message);
            }

        }




        public void DeleteEmployee()
        {
            deleteblock:
            Console.WriteLine("\nTo delete the record ,Choose any of the options given below");
            Console.WriteLine("\n   1.Delete Employee with EmployeeID\n   2.Delete Employee with Employee Name");
            bool isValidOption = int.TryParse(Console.ReadLine(), out int deleteOption);
            if (isValidOption)
            {
                if (deleteOption == 1)
                {
                    updateEmployee.UsingEmployeeId(operation: "Delete");

                }
                else if (deleteOption == 2)
                {
                    updateEmployee.UsingEmployeeName(operation: "Delete");
                }
                else
                {
                    Console.WriteLine("Specify only the numeric digits 1 or 2");
                    goto deleteblock;
                }
            }
            else
            {
                Console.WriteLine("Specify only the numeric digits ");
                goto deleteblock;
            }

        }

        public void ShowEmployeeFromDB()
        {
            DataTable table = Database.ViewRecordsFromDB();
            Console.WriteLine("------Employee Records from the DataBase------");
            foreach(DataRow dataRow in table.Rows)
            {
                Console.WriteLine("-----------------------------------------------------------------------------");
                Console.WriteLine($"EmployeeID :{dataRow[0]}\nNAME :{dataRow[1]}\n" +
                    $"MobileNo :{dataRow[2]}\nDOB :{dataRow[3]}\nDOJ :{dataRow[4]}\nEmail :{dataRow[5]}");
            }

           
            
        }
        public void UpdateEmployee()
        {
            updateblock:
            Console.WriteLine("\nTo Update the Exisiting data ,Select any of the Options given below");
            Console.WriteLine("\n   1.Update Employee with EmployeeID\n   2.Update Employee with Employee Name");
            bool isValidUpdateOption = int.TryParse(Console.ReadLine(), out int updateOption);
            if (isValidUpdateOption)
            {
                if (updateOption == 1)
                {
                    updateEmployee.UsingEmployeeId(operation: "Update");

                }
                else if (updateOption == 2)
                {
                    updateEmployee.UsingEmployeeName(operation: "Update");
                }
                else
                {
                    Console.WriteLine("Specify only the numeric digits 1 or 2");
                    goto updateblock;
                }
            }
            else
            {
                Console.WriteLine("Specify only the numeric digits ");
                goto updateblock;
            }
        }


        public void ShowEmployee()
        {

            if (employees.Count != 0)
            {
                for (int i = 0; i < employees.Count; i++)
                {

                    Console.WriteLine($"EmployeeID : {employees[i].EmployeeId.ToUpper()}");
                    Console.WriteLine($"Employee Name : {employees[i].EmployeeName.ToUpper()}");
                    Console.WriteLine($"Employee mobile number: {employees[i].EmployeeMobileNo}");
                    Console.WriteLine($"Employee Email: {employees[i].EmployeeEmail}");
                    Console.WriteLine($"Employee DOB : {employees[i].EmployeeDob.ToShortDateString()}");
                    Console.WriteLine($"Employee DOJ : {employees[i].EmployeeDoj.ToShortDateString()}");
                }
            }
            else
            {
                Console.WriteLine(" There are no records stored in the Employee Management Systems");
            }

        }
    }
}




        


