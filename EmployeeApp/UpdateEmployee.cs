using System;
using System.Data;

namespace EmployeeManagement
{
    public class UpdateEmployee
    {

        public void UsingEmployeeId(string operation)
        {
            DataTable table = Database.ViewRecordsFromDB();
            if (table.Rows.Count > 0)
            {
                Console.WriteLine($"\nExisting EmployeeId from the database are as follows\n ");
                foreach (DataRow dataRow in table.Rows)
                {
                    Console.WriteLine(dataRow[0]);
                }

                string Input = Validation.ValidateID();
                foreach (DataRow dataRow in table.Rows)
                {
                    bool IsMatch = dataRow[0].ToString() == Input;
                    if (IsMatch && operation == "Update")
                    {
                        UpdateIndividualRecords(dataRow[0].ToString(), Convert.ToDateTime(dataRow[3]));
                    }
                    else if (IsMatch && operation == "Delete")
                    {
                        int RowsAffected = Database.SqlOperation($"DELETE FROM EMPLOYEES WHERE EMPLOYEEID = '{dataRow[0]}'");
                        Console.WriteLine($"\n\t{RowsAffected} Rows Affected");
                        if (RowsAffected >= 1)
                        {
                            Console.WriteLine("\n........Successfully deleted the record ");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{Input} does not match with the existing EmployeeId.");
                    }
                }
            }
            else
            {
                Console.WriteLine("\n..............There are no records in the database ..............");
            }

        }

        private void UpdateIndividualRecords(string EmployeeId, DateTime ExistingDob)
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
                            string InputID = Validation.ValidateID();
                            SqlUpdateRecord("EMPLOYEEID", InputID, EmployeeId);
                            break;
                        case 2:
                            string InputName = Validation.ValidateName();
                            SqlUpdateRecord("NAME", InputName, EmployeeId);
                            break;
                        case 3:
                            long InputMobileNo = Validation.ValidateMobileNo();
                            SqlUpdateRecord("MOBILENO", InputMobileNo, EmployeeId);
                            break;
                        case 4:
                            string InputEmail = Validation.ValidateEmail();
                            SqlUpdateRecord("EMAIL", InputEmail, EmployeeId);
                            break;
                        case 5:
                            DateTime InputDOB = Validation.ValidateDOB();
                            SqlUpdateRecord("DATEOFBIRTH", InputDOB.ToString("MM/dd/yyyy"), EmployeeId);
                            break;
                        case 6:
                            DateTime InputDOJ = Validation.ValidateDOJ(ExistingDob);
                            SqlUpdateRecord("DATEOFJOINING", InputDOJ.ToString("MM/dd/yyyy"), EmployeeId);
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
            if (RowsAffected >= 1)
            {
                Console.WriteLine("\n.......Succesfully Updated the record ");
            }
        }
    }



}

