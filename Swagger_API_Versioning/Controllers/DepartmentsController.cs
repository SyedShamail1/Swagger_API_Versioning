using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swagger_API_Versioning.Interfaces;

namespace Swagger_API_Versioning.Controllers
{
    [Route("api")]
    
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentsService;
        public DepartmentsController(IDepartmentService departmentsService)
        {
            _departmentsService = departmentsService;
        }

        [HttpGet]
        [ApiVersion("2")]
        [ApiExplorerSettings(GroupName = "v2")]
        [Route("/v{version:apiVersion}/Get")]

        public IActionResult Get()
        {
            return Ok(_departmentsService.GetAll());
        }

        [HttpGet]
        [ApiVersion("1")]
        [ApiExplorerSettings(GroupName = "v1")]
        [Route("/v{version:apiVersion}/GetNew")]
        public IActionResult GetNew()
        {
            return Ok(_departmentsService.GetAll());
        }
    }
}
