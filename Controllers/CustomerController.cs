using Microsoft.AspNetCore.Mvc;
using pertemuan_2.Models;
using pertemuan_2.Models.DB;
using pertemuan_2.Models.DTO;
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
        [HttpGet ("GetListCustomer")]
        public IActionResult Get()
        {
            try
            {
                var customerList = _customerServices.GetListCustomers();
                var response = new GeneralResponse
                {
                    StatusCode = "01",
                    StatusDesc = " sukses",
                    Data = customerList

                };
                return Ok(response);

            }
            catch (Exception ex)
            {
                var response = new GeneralResponse
                {
                    StatusCode = "99",
                    StatusDesc = " Failed | " + ex.Message.ToString(),
                    Data = null
                };
                return BadRequest(response);
            }
        }





        [HttpGet]
        [Route("GetCustomerById/{id}")]

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





        [HttpPost ("InsertDataCustomer")]

        //menggunakan iactionresult karena lebih fleksibel karena ada return ok dan return badrequest
        public IActionResult Post(CustomerRequestDTO customer)
        {
            try
            {
                var insertCustomer = _customerServices.CreateCustomer(customer);
                if (insertCustomer)
                {
                    var responsiSuccess = new GeneralResponse
                    {
                        StatusCode = "01",
                        StatusDesc = "Insert Customer Success",
                        Data = null
                    };
                    //return StatusCode(StatusCodes) untuk statuscode api
                    return Ok(responsiSuccess);
                }
                var responsiFailed = new GeneralResponse
                {
                    StatusCode = "02",
                    StatusDesc = " Insert Customer Failed",
                    Data = null
                };
                return BadRequest(responsiFailed);
            }
            catch (Exception ex)
            {
                var responseFailed = new GeneralResponse
                {
                    StatusCode = "99",
                    StatusDesc = "Failed |" + ex.Message.ToString(),
                    Data = null
                };
                return BadRequest(responseFailed);
            }
        }


        // PUT api/<CustomerController>/5
        [HttpPut("UpdateCustomer")]
        public IActionResult Put(int id,CustomerRequestDTO customer)
        {
            try
            {

                var updateCustomer = _customerServices.UpdateCustomer(id,customer);
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

        [HttpDelete("DeleteCustomer")] 
        //[Route("DeleteCustomerById/{id}")]


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
