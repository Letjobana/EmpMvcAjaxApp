using ECommerceApp.Repositories.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ECommerceApp.Controllers
{
    public class DesignationController : Controller
    {
        private readonly IDesignationRepository designationRepository;

        public DesignationController(IDesignationRepository designationRepository)
        {
            this.designationRepository = designationRepository;
        }
        [HttpGet]
        public IActionResult GetAllDesignation()
        {
            try
            {
                return Ok(designationRepository.GetDesignations().ToList());
            }
            catch (Exception ex)
            {
                var errorResult = new ObjectResult(new
                {
                    Message = "Error retrieving data from the database",
                    Status = "Error",
                    Exception = ex.Message
                });
                errorResult.StatusCode = StatusCodes.Status500InternalServerError;
                return errorResult;
            }
        }
    }
}
