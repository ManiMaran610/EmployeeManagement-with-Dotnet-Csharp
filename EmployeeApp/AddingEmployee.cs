using System;
using System.Text.RegularExpressions;

namespace EmployeeManagement
{
    public class AddingEmployee
    {

        string _employeeId, _employeeName, _employeeEmail;
        DateTime _employeeDob;
        long _employeeMobileNo;
        DateTime _employeeDoj;




        public Employee AddEmployee(string id = null, string name = null)
        {

            bool IsValidMobNo = true;
            bool IsValidDob = true;
            bool IsValidDoj = true;
            bool IsValidEmail = true;


            if (id == null)
            {
                idBlock:
                try
                {

                    _employeeId = Validation.ValidateID();

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    goto idBlock;


                }
            }
            else
            {
                _employeeId = id;
            }


            if (name == null)
            {
                EmployeeName:
                try
                {
                    _employeeName = Validation.ValidateName();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    goto EmployeeName;
                }
            }
            else
            {
                _employeeName = name;
            }



            while (IsValidMobNo)
            {
                try
                {
                    _employeeMobileNo = Validation.ValidateMobileNo();
                    IsValidMobNo = false;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }


            }
            while (IsValidEmail)
            {
                try
                {
                    _employeeEmail = Validation.ValidateEmail();
                    IsValidEmail = false;

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }


            }
            while (IsValidDob)
            {

                try
                {
                    _employeeDob = Validation.ValidateDOB();
                    IsValidDob = false;


                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

            while (IsValidDoj)
            {
                try
                {
                    _employeeDoj = Validation.ValidateDOJ(dob: _employeeDob);
                    IsValidDoj = false;


                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }


            var employee = new Employee();
            employee.EmployeeId = _employeeId;
            employee.EmployeeName = _employeeName;
            employee.EmployeeDob = _employeeDob;
            employee.EmployeeMobileNo = _employeeMobileNo;
            employee.EmployeeDoj = _employeeDoj;
            employee.EmployeeEmail = _employeeEmail;
            return employee;
        }
    }
}