using ECommerceApp.Models;
using System.Collections.Generic;

namespace ECommerceApp.Repositories.Abstracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(int GetEmployeeById);
        Employee AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int employeeId);

        bool EmployeeExist(string email);


    }
}
