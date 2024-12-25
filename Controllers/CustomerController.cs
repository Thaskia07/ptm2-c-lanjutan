using Microsoft.AspNetCore.Mvc;
using pertemuan_2.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace pertemuan_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerServices _customerServices;
        public CustomerController(CustomerServices services)
        {
            _customerServices = services;
        }


        // GET: api/<CustomerController>
        [HttpGet]


        public IActionResult Get()
        {
            var customerList = _customerServices.GetListCustomers();
            return Ok(customerList);

        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
