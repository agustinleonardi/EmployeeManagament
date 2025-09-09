namespace EmployeeManagement.API.DTOs.Input
{
    public record CreateEmployeeRequest(string FirstName, string LastName, string Email, DateTime DateOfBirth);
}