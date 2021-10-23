using System;
namespace EmployeeManagement
{
    public class UpdateEmployee
    {

        public void UsingEmployeeId(string operation)
        {
            Console.WriteLine($"Existing EmployeeId are as follows ");

            for (int Index = 0; Index < EmployeeDetails.employees.Count; Index++)
            {
                Console.WriteLine(EmployeeDetails.employees[Index].EmployeeId.ToUpper());
            }
            Console.WriteLine($"\nEnter the  EmployeeId which you want to {operation} ");
            var input = Console.ReadLine().ToUpper();

            int IndexId = EmployeeDetails.employees.FindIndex(item => item.EmployeeId.ToUpper() == input);
            if (IndexId >= 0)
            {
                if (operation == "Update")
                {
                    UpdateIndividualRecords(IndexId);
                   
                }
                else if (operation == "Delete")
                {
                    int RowsAffected = Database.SqlOperation($"DELETE FROM EMPLOYEES WHERE EMPLOYEEID = '{EmployeeDetails.employees[IndexId].EmployeeId}'");
                    Console.WriteLine($"\n\t{RowsAffected} Rows Affected");
                    if (RowsAffected >= 1)
                    {
                        EmployeeDetails.employees.RemoveAt(IndexId);
                        Console.WriteLine("\n........Successfully deleted the record ");
                    }

                }
            }
            else
            {
                Console.WriteLine($"{input} doest not exists in the Employee records ");
            }
        }



        public void UsingEmployeeName(string operation)
        {
            Console.WriteLine($"Existing Employee Names are as follows ");
            for (int index = 0; index < EmployeeDetails.employees.Count; index++)
            {
                Console.WriteLine($" {EmployeeDetails.employees[index].EmployeeName.ToUpper()}");
            }
            Console.WriteLine($"\n  Enter  any existing Employee Name  which you want to {operation} ");
            var input = Console.ReadLine().ToUpper();
            int IndexOfName = EmployeeDetails.employees.FindIndex(item => item.EmployeeName.ToUpper() == input);
            if (IndexOfName >= 0)
            {
                if (operation == "Update")
                {
                    UpdateIndividualRecords(IndexOfName);
                  
                }
                else if (operation == "Delete")
                {
                    int RowsAffected = Database.SqlOperation($"DELETE FROM EMPLOYEES WHERE NAME = '{EmployeeDetails.employees[IndexOfName].EmployeeName}'");
                    Console.WriteLine($"\n\t{RowsAffected} Rows Affected");
                    if (RowsAffected >= 1)
                    {
                        EmployeeDetails.employees.RemoveAt(IndexOfName);
                        Console.WriteLine("\n........Successfully deleted the record ");
                    }
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
            Employee existingEmployee =EmployeeDetails.employees[index];
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
                            string InputID = Validation.ValidateID();
                            SqlUpdateRecord("EMPLOYEEID", InputID, existingEmployee.EmployeeId);
                            existingEmployee.EmployeeId = InputID;
                            break;
                        case 2:
                            string InputName = Validation.ValidateName();
                            SqlUpdateRecord("NAME", InputName, existingEmployee.EmployeeId);
                            existingEmployee.EmployeeName = InputName;
                            break;
                        case 3:
                            long InputMobileNo = Validation.ValidateMobileNo();
                            SqlUpdateRecord("MOBILENO", InputMobileNo, existingEmployee.EmployeeId);
                            existingEmployee.EmployeeMobileNo = InputMobileNo;
                            break;

                        case 4:
                            string InputEmail = Validation.ValidateEmail();
                            SqlUpdateRecord("EMAIL", InputEmail, existingEmployee.EmployeeId);
                            existingEmployee.EmployeeEmail = InputEmail;
                            break;
                        case 5:
                            DateTime InputDOB = Validation.ValidateDOB();
                            SqlUpdateRecord("DATEOFBIRTH", InputDOB.ToShortDateString(), existingEmployee.EmployeeId);
                            existingEmployee.EmployeeDob = InputDOB;
                            break;
                        case 6:
                            DateTime InputDOJ = Validation.ValidateDOJ(existingEmployee.EmployeeDoj);
                            SqlUpdateRecord("DATEOFJOINING", InputDOJ.ToShortDateString(),existingEmployee.EmployeeId);
                            existingEmployee.EmployeeDoj = InputDOJ;
                         
                            break;
                        default:
                            Console.WriteLine("The Valid Option number is from 1 to 6 ");
                            goto options;

                    }
                }
                catch (Exception exception)
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
        private void SqlUpdateRecord(string ColumnName, Object Value, string EmployeeId)
        {
            int RowsAffected = Database.SqlOperation($"UPDATE EMPLOYEES SET {ColumnName} = '{Value}' WHERE EMPLOYEEID ='{EmployeeId}'");
            Console.WriteLine($"\n\t{RowsAffected} Rows Affected");
            if(RowsAffected >= 1)
            {
                Console.WriteLine("\n.......Succesfully Updated the record ");
            }
        }
    }



}

