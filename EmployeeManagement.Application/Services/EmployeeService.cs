using System.Reflection.Metadata;
using EmployeeManagement.Application.DTOs.Input;
using EmployeeManagement.Application.Exceptions;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces;


namespace EmployeeManagement.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(Guid id)
        {
            var existingEmployee = await _employeeRepository.GetByIdAsync(id);
            if (existingEmployee == null) throw new EmployeeDontExistsException(id);
            return existingEmployee;
        }

        public async Task<Guid> AddEmployeeAsync(CreateEmployeeDTO dto)
        {
            var existingEmployee = await _employeeRepository.GetByEmailAsync(dto.Email);
            if (existingEmployee != null) throw new EmailAlreadyExistsException(dto.Email);
            var newEmployee = new Employee(dto.FirstName, dto.LastName, dto.Email, dto.DateOfBirth);
            await _employeeRepository.AddAsync(newEmployee);
            return newEmployee.Id;
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            await _employeeRepository.UpdateAsync(employee);
        }

        public async Task DeleteEmployeeAsync(Guid id)
        {
            await _employeeRepository.DeleteAsync(id);
        }


    }
}
