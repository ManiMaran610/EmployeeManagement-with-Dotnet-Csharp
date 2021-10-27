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
           
            try
            {
                Console.WriteLine("\nTo Delete the Exisiting data ,Choose any one of the EmployeeId given below");

                updateEmployee.UsingEmployeeId(operation: "Delete");
            }
            catch (Exception Exception)
            {
                Console.WriteLine(Exception.Message);

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
        
            try
            {
                Console.WriteLine("\nTo Update the Exisiting data ,Choose any one of the EmployeeId given below");

                updateEmployee.UsingEmployeeId(operation: "Update");
            }catch (Exception Exception)
            {
                Console.WriteLine(Exception.Message);

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




        


