namespace EmployeeManagement.Application.Exceptions
{
    public class EmailAlreadyExistsException : Exception
    {
        public EmailAlreadyExistsException(string email) : base($"El email: {email} ya esta registrado") { }
    }
}