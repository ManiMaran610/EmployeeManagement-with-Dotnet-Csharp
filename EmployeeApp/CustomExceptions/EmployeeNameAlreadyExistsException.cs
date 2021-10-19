using System;


namespace EmployeeManagement
{
   
    public class EmployeeNameAlreadyExistsException : Exception
    {
        public string EmployeeName { get; }
        public EmployeeNameAlreadyExistsException():base("Employee Name already exist.")
        {
        }

        public EmployeeNameAlreadyExistsException(string message) : base(message: message)
        {
        }

        public EmployeeNameAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
        {
        }
        public EmployeeNameAlreadyExistsException(string message,string name) : base(message)
        {
            EmployeeName = name;
        }

        public override string Message
        {
            get
            {
                string message = base.Message;
                if(EmployeeName != null)
                {
                    return message +Environment.NewLine + $"{EmployeeName} is already exists in our record ";
                }else
                {
                    return message;
                }
            }
        }

    }
}