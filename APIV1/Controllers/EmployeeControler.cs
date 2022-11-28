using APIV1.Entities;
using APIV1.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIV1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly ICSVService _csvService;

        public EmployeeController(ICSVService csvService)
        {
            _csvService = csvService;
        }

         [HttpPost]
            public async Task<IActionResult> WriteEmployeeCSV([FromBody] List<Employee> employees)
            {
                _csvService.WriteCSV<Employee>(employees);

                return Ok();
            }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeCSV([FromForm] IFormFileCollection file)
            {
                var employees = _csvService.ReadCSV<Entities.Employee>(file[0].OpenReadStream());

                return Ok(employees);
            }
    }
}