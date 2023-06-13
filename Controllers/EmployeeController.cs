using Microsoft.AspNetCore.Mvc;
using Projects.Data.Services;
using Projects.Models;

namespace Projects.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        // GET: api/Customerss

        [HttpGet("GetAll")]
        public IEnumerable<Employee> GetAll()
        {
            return _service.GetAll();


        }

        // GET api/Employee/5
        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult> GetBy(Guid id)
        {
            var employeeDetails = await _service.GetById(id);

            if (employeeDetails == null)
                return NotFound("Not Found");

            return Ok(employeeDetails);
        }

        // POST api/Employee/Create
        [HttpPost("Create")]
        public async Task<ActionResult> Create(Employee employee)
        {
            if (!ModelState.IsValid)
                return NotFound(employee);


            await _service.Create(employee);
            return Ok(nameof(Index));
        }

        // PUT api/Employee/5
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(Guid id, Employee employee)
        {
            var employeeDetails = await _service.GetById(id);

            if (employeeDetails == null)
                return NotFound("Not Found");


            await _service.Update(id, employee);

            return Ok();
        }

        // DELETE api/Employee/5
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var employeeDetails = await _service.GetById(id);

            if (employeeDetails == null)
                return NotFound("Not Found");


            await _service.Delete(id);
            return Ok();
        }
    }
}
