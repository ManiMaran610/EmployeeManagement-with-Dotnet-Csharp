using System;
using System.Collections.Generic;


namespace EmployeeManagement
{
    public class EmployeeDetails
    {
        List<Employee> employees = new List<Employee>();
        AddingEmployee addingEmployee = new AddingEmployee();


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
                    UsingEmployeeId(operation: "Delete");

                }
                else if (deleteOption == 2)
                {
                    UsingEmployeeName(operation: "Delete");
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
                    UsingEmployeeId(operation: "Update");

                }
                else if (updateOption == 2)
                {
                    UsingEmployeeName(operation: "Update");
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




        private void UsingEmployeeId(string operation)
        {
            Console.WriteLine($"Existing EmployeeId are as follows ");

            for (int index = 0; index < employees.Count; index++)
            {
                Console.WriteLine(employees[index].EmployeeId.ToUpper());
            }
            Console.WriteLine($"\nEnter the  EmployeeId which you want to {operation} ");
            var input = Console.ReadLine().ToUpper();

            int IndexId = employees.FindIndex(item => item.EmployeeId.ToUpper() == input);
            if (IndexId >= 0)
            {
                if (operation == "Update")
                {
                    UpdateIndividualRecords(IndexId);
                    Console.WriteLine("\n........Successfully Updated the record");
                }
                else if (operation == "Delete")
                {
                    employees.RemoveAt(IndexId);
                    Console.WriteLine("\n........Successfully deleted the record for the EmployeeID");

                }
            }
            else
            {
                Console.WriteLine($"{input} doest not exists in the Employee records ");
            }
        }



        private void UsingEmployeeName(string operation)
        {
            Console.WriteLine($"Existing Employee Names are as follows ");
            for (int index = 0; index < employees.Count; index++)
            {
                Console.WriteLine($" {employees[index].EmployeeName.ToUpper()}");
            }
            Console.WriteLine($"\n  Enter  any existing Employee Name  which you want to {operation} ");
            var input = Console.ReadLine().ToUpper();
            int IndexOfName = employees.FindIndex(item => item.EmployeeName.ToUpper() == input);
            if (IndexOfName >= 0)
            {
                if (operation == "Update")
                {
                    UpdateIndividualRecords(IndexOfName);
                    Console.WriteLine("\n.......Succesfully Updated the record ");
                }
                else if (operation == "Delete")
                {
                    employees.RemoveAt(IndexOfName);
                    Console.WriteLine("\n........Successfully deleted the record ");
                }
            }
            else
            {
                Console.WriteLine($"{input} doest not exists in the Employee records ");
            }
        }

        private void UpdateIndividualRecords(int index)
        {
            options:
            Console.WriteLine("\n choose the number for the options given below : \n");
            Console.WriteLine("1.ID\n2.Name\n3.MobileNumber\n4.Email\n5.Date of Birth\n6.Date of Joining");
            bool isValid = int.TryParse(Console.ReadLine(), out int option);
            if (isValid)
            {
                try
                {
                    switch (option)
                    {
                        case 1:
                            employees[index].EmployeeId = Validation.ValidateID();
                            break;
                        case 2:
                            employees[index].EmployeeName = Validation.ValidateName();
                            break;
                        case 3:
                            employees[index].EmployeeMobileNo = Validation.ValidateMobileNo();
                            break;
                        case 4:
                            employees[index].EmployeeEmail = Validation.ValidateEmail();
                            break;
                        case 5:
                            employees[index].EmployeeDob = Validation.ValidateDOB();
                            break;
                        case 6:
                            employees[index].EmployeeDoj = Validation.ValidateDOJ(employees[index].EmployeeDoj);
                            break;
                        default:
                            Console.WriteLine("The Valid Option number is from 1 to 6 ");
                            goto options;

                    }
                }catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    goto options;
                }
            }
            else
            {
                Console.WriteLine("Special characters and Alphabetics are not allowed.");
                goto options;
            }
        }
    }



}
    

