using Microsoft.AspNetCore.Mvc;
using pertemuan_2.Models.DB;
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


        //// GET: api/<CustomerController>`aaaaaaaaaaax
        ///berdasarkan list
        [HttpGet]
        public IActionResult Get()
        {
            var customerList = _customerServices.GetListCustomers();
            return Ok(customerList);

        }




        [HttpGet("{id}")]

        //berdasarkan id
        public IActionResult GetCustomer(int id)
        {
            var customer = _customerServices.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound("Customer tidak ditemukan.");
            }
            return Ok(customer);
        }





        [HttpPost]

        //menggunakan iactionresult karena lebih fleksibel karena ada return ok dan return badrequest
        public IActionResult Post(Customer customer)
        {
            var insertCustomer = _customerServices.CreateCustomer(customer);
            if(insertCustomer)
            {
                //return StatusCode(StatusCodes) untuk statuscode api
                return Ok("insert customer succes");
            }
            return BadRequest("insert customer failed");
        }


        // PUT api/<CustomerController>/5
        [HttpPut]
        public IActionResult Put(Customer customer)
        {
            try
            {

                var updateCustomer = _customerServices.UpdateCustomer(customer);
                if (updateCustomer)
                {
                    return Ok("update customert succes!");
                }
                return BadRequest("update customer failed");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
                throw;
            }
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteCustomer(int id)
        {
            try
            {
                var deleteCustomer = _customerServices.DeleteCustomer(id);
                if(deleteCustomer)
                {
                    return Ok("delete customer succes");
                }
                return BadRequest("delete failede");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());

                throw;
            }
        }


    }
}
