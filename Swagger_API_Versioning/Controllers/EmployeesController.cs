using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swagger_API_Versioning.Interfaces;

namespace Swagger_API_Versioning.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeesService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeesService = employeeService;
        }

        [HttpGet]
        //[Route("")]
        public IActionResult Get()
        {
            return Ok(_employeesService.GetAll());
        }
    }
}
