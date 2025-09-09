namespace EmployeeManagement.Application.Exceptions
{
    public class EmployeeDontExistsException : Exception
    {
        public EmployeeDontExistsException(Guid id) : base($"El empleado con la id {id} ya existe") { }
    }
}