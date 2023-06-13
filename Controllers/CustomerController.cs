using Microsoft.AspNetCore.Mvc;
using Projects.Data.Services;
using Projects.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Projects.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            _service = service;
        }
        // GET: api/Customerss
        
        [HttpGet("GetAll")]      
        public  IEnumerable<Customer> GetAll()
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

        // POST api/Customer/Create
        [HttpPost("Create")]
        public async Task<ActionResult> Create(Customer customer)
        {
            if (!ModelState.IsValid)
                return NotFound(customer);


            await _service.Create(customer);
            return Ok(nameof(Index));
        }

        // PUT api/Customer/5
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> Update(Guid id,Customer customer)
        {          
                var customerDetails = await _service.GetById(id);

            if (customerDetails == null)
                return NotFound("Not Found");


            await _service.Update(id, customer);

            return Ok();
        }

        // DELETE api/Customer/5
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
