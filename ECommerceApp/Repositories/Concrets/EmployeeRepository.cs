using ECommerceApp.Models;
using ECommerceApp.Persistance;
using ECommerceApp.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerceApp.Repositories.Concrets
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Employee AddEmployee(Employee employee)
        {
            try
            {

                var newEmployee = context.Employees.Add(employee);
                context.SaveChanges();
                return newEmployee.Entity;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteEmployee(int employeeId)
        {
            try
            {
                var deleteEmployee = context.Employees.Where(x => x.Id == employeeId).FirstOrDefault();
                if (deleteEmployee != null)
                {
                    context.Employees.Remove(deleteEmployee);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Employee GetEmployeeById(int GetEmployeeById)
        {
            try
            {
                return context.Employees.Where(x => x.Id == GetEmployeeById).FirstOrDefault();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EmployeeExist(string email)
        {
            try
            {
                return context.Employees.Any(x => x.Email.Equals(email));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                return context.Employees.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                var updateEmployee = context.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();
                if (updateEmployee != null)
                {
                    updateEmployee.Name = employee.Name;
                    updateEmployee.Email = employee.Email;
                    updateEmployee.Phone = employee.Phone;
                    updateEmployee.DesignationId = employee.DesignationId;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }     

    }
}
