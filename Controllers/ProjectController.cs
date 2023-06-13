using Microsoft.AspNetCore.Mvc;
using Projects.Data.Services;
using Projects.Models;

namespace Projects.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _service;

        public ProjectController(IProjectService service)
        {
            _service = service;
        }
        // GET: api/Project

        [HttpGet("GetAll")]
        public IEnumerable<Project> GetAll()
        {
            return _service.GetAll();


        }

        // GET api/Customer/5
        [HttpGet("GetBy/{id}")]
        public async Task<ActionResult> GetBy(Guid id)
        {
            var customerDetails = await _service.GetById(id);

            if (customerDetails == null)
                return NotFound("Not Found");

            return Ok(customerDetails);
        }

        // POST api/Project/Create
        [HttpPost("Create")]
        public async Task<ActionResult> Create(Project project)
        {
            if (!ModelState.IsValid)
                return NotFound(project);


            await _service.Create(project);
            return Ok(nameof(Index));
        }

        // PUT api/Customer/5
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(Guid id, Project project)
        {
            var projectDetails = await _service.GetById(id);

            if (projectDetails == null)
                return NotFound("Not Found");


            await _service.Update(id, project);

            return Ok();
        }

        // DELETE api/Project/5
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var customerDetails = await _service.GetById(id);

            if (customerDetails == null)
                return NotFound("Not Found");


            await _service.Delete(id);
            return Ok();
        }
    }
}
