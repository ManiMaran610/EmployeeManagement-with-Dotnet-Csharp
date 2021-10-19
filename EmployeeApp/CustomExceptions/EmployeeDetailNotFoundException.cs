using System;


namespace EmployeeManagement
{

    public class EmployeeDetailNotFoundException : Exception
    {
        private static string DefaultMsg = "Employee Detail not found ";
        
        public EmployeeDetailNotFoundException() : base(message: DefaultMsg)
        {
        }


        public EmployeeDetailNotFoundException(string message) : base(message)
        {
        }

        public EmployeeDetailNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
        


    }
}