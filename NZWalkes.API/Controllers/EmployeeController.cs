using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalkes.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        [HttpGet]
        public IActionResult getemployee()
        {
            var employees = new List<string> { "ahmed", "Mohamed", "Khaled", "Saad" };

            return Ok(employees);

        }


    }
}
