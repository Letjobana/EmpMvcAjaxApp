using ECommerceApp.Models;
using ECommerceApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ECommerceApp.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetEmployees()
        {
            try
            {
                return Ok(employeeRepository.GetAllEmployees().ToList());
            }
            catch (Exception ex)
            {
                var errorObjectResult = new ObjectResult(new
                {
                    Message = "Error retrieving data from the database",
                    Status = "Error",
                    Exception = ex.Message

                });
                errorObjectResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorObjectResult;
            }
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            try
            {
                if (employeeRepository.EmployeeExist(employee.Email))
                {
                    var errorResult = new ObjectResult(new
                    {
                        Message = "The employee already exist",
                        Status = "Error"
                    });
                    errorResult.StatusCode = StatusCodes.Status500InternalServerError;
                    return errorResult;
                }
                else
                    return Ok(employeeRepository.AddEmployee(employee));

            }
            catch (Exception ex)
            {
                var errorResult = new ObjectResult(new
                {
                    Message = "An error occured while adding data to the database,Please try again",
                    Status = "Error",
                    Exception = ex.Message
                });
                errorResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorResult;

            }
        }
        public IActionResult UpdateEmployee(Employee employee)
        {
            try
            {
                employeeRepository.UpdateEmployee(employee);
                return Ok(new
                {
                    Message = "Successfully Updated",
                    Status = "Sucess"
                });
            }
            catch (Exception ex)
            {
                var errorResult = new ObjectResult(new
                {
                    Message = "An error occured while trying to update the employee",
                    Status = "Error",
                    Exception = ex.Message
                });
                errorResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorResult;
            }
        }
        [HttpDelete]
        public IActionResult DeleteEmployee(int Id)
        {
            try
            {
                employeeRepository.DeleteEmployee(Id);
                return Ok(new
                {
                    Message = "Deleted Succesfully",
                    Status = "Success"
                });
            }
            catch (Exception ex)
            {
                var errorResult = new ObjectResult(new
                {
                    Message = "An error occured while trying to delete the employee",
                    Status = "Error",
                    Exception = ex.Message
                });
                errorResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorResult;
            }
        }
        [HttpGet]
        public IActionResult GetEmployeeById(int empId)
        {
            try
            {
                return Ok(employeeRepository.GetEmployeeById(empId));

            }
            catch (Exception ex)
            {
                var errorResult = new ObjectResult(new
                {
                    Message = "An error occured while trying to getting the employee from the database",
                    Status = "Error",
                    Exception = ex.Message
                });
                errorResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorResult;

            }
        }

    }
}
