using System;

namespace EmployeeManagement
{
    public class Employee
    {
        private string _employeeId, _employeeName;
        private DateTime _dob;
        private long _mobileNo;
        private DateTime _doj;
        private string _email;


        public string EmployeeId                  //Encapsulations
        {
            get
            {
                return _employeeId;
            }
            set
            {
                _employeeId = value;
            }
        }


        public string EmployeeName
        {
            get
            {
                return _employeeName;
            }
            set
            {
                _employeeName = value;
            }
        }

        public DateTime EmployeeDob
        {
            get
            {
                return _dob;
            }
            set
            {
                _dob = value;
            }
        }
        public DateTime EmployeeDoj
        {
            get
            {
                return _doj;
            }
            set
            {
                _doj = value;
            }
        }
        public string EmployeeEmail
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public long EmployeeMobileNo
        {
            get
            {
                return _mobileNo;
            }
            set
            {
                _mobileNo = value;
            }
        }






    }
}