using System;
using System.Text.RegularExpressions;

namespace EmployeeManagement
{
    public class Validation
    {
        public Validation()
        {
        }

        public static string ValidateID()

        {
            IdBlock:
            Console.WriteLine("Enter your EmployeeId For Example (\"ACE1234\")  ");
            string InputId = Console.ReadLine();
            if (Regex.IsMatch(InputId, "[ace|ACE]{3}[0-9]{4}$") && (InputId.Contains("ace") || InputId.Contains("ACE")))
            {
                return InputId;
            }
            else
            {
               Console.WriteLine("Enter the Employee Id which starts with ace or ACE followed by 4 digit number ");
                goto IdBlock;
            }
        }


        public static string ValidateName()
        {
            EmployeeName:
            Console.WriteLine("Enter the Employee name");
            string Name = Console.ReadLine();
            if (Regex.IsMatch(Name, "^[a-zA-Z\\s]*$") && Name.Length >= 4)
            {
                return Name;
            }
            else
            {
                Console.WriteLine("Name should be declared only in Alphabetics");
                goto EmployeeName;
            }
        }


        public static long ValidateMobileNo()
        {
            Console.WriteLine("Enter the Employee Mobile number");
            string mobileNo = Console.ReadLine();
            var isValid = Regex.IsMatch(mobileNo, "[6-9][0-9]{9}");

            if (isValid && mobileNo.Length == 10)
            {
                return Convert.ToInt64(mobileNo);
            }
            else
            {
                throw new FormatException("You should specify ten numeric digits which starts with 6 to 9 followed by 9 digit mobile number");
            }
        }

        public static string ValidateEmail()
        {
            Console.WriteLine("Enter the Employee Email");
            string InputEmail = Console.ReadLine();
            var isValid = Regex.IsMatch(InputEmail, @"[0-9a-zA-Z]@[a-zA-Z]+(.[a-zA-Z]{2,}[a-zA-Z]*){0,}$");
            if (isValid)
            {
                return InputEmail;
            }
            else
            {
                throw new FormatException("Email should contain @ followed by domain Name in Alphabetics");
            }
        }

        public static DateTime ValidateDOB()
        {
            Console.WriteLine("Enter your Date of Birth in YYYY-MM-DD or DD-MM-YYYY");
            DateTime Dob = Convert.ToDateTime(Console.ReadLine());
            if (DateTime.UtcNow.Year - Dob.Year > 18 && DateTime.UtcNow.Year - Dob.Year < 60)
            {
               return Dob;
            }
            else
            {
                throw new FormatException("You should specify the date where your age in between 18 and 60 ");
            }
        }

        public static DateTime ValidateDOJ(DateTime dob)
        {
            Console.WriteLine("Enter Your Date of joining in YYYY-MM-DD or DD-MM-YYYY");
            DateTime Doj = Convert.ToDateTime(Console.ReadLine());
            var DiffDate = (Doj.Year - dob.Year);
            if (DiffDate > 18 && DiffDate < 60 && Doj.Date <= DateTime.UtcNow.Date)
            {
                return Doj;
            }
            else
            {
                throw new FormatException("Joining Date should not be future date  ");
            }


        }
    }}