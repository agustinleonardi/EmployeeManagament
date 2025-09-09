namespace EmployeeManagement.Application.DTOs.Input
{
    public record CreateEmployeeDTO(string FirstName, string LastName, string Email, DateTime DateOfBirth);
}