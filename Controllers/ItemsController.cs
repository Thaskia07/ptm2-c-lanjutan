using Microsoft.AspNetCore.Mvc;
using pertemuan_2.Models.DB;
using pertemuan_2.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860



namespace pertemuan_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ItemsServices _itemsServices;
        public ItemsController(ItemsServices services)
        {
            _itemsServices = services;
        }


        //// GET: api/<CustomerController>
        ///berdasarkan list
        [HttpGet]
        public IActionResult Get()
        {
            var itemsList = _itemsServices.GetListItems();
            return Ok(itemsList);

        }




        [HttpGet("{id}")]

        //berdasarkan id
        public IActionResult GetItems(int id)
        {
            var items = _itemsServices.GetItemsById(id);
            if (items == null)
            {
                return NotFound("items tidak ditemukan.");
            }
            return Ok(items);
        }





        [HttpPost]

        //menggunakan iactionresult karena lebih fleksibel karena ada return ok dan return badrequest
        public IActionResult Post(Items items)
        {
            var insertItems = _itemsServices.CreateItems(items);
            if (insertItems)
            {
                //return StatusCode(StatusCodes) untuk statuscode api
                return Ok("insert items succes");
            }
            return BadRequest("insert items failed");
        }


        // PUT api/<CustomerController>/5
        [HttpPut]
        public IActionResult Put(Items items)
        {
            try
            {

                var updateItems = _itemsServices.UpdateItems(items);
                if (updateItems)
                {
                    return Ok("update items succes!");
                }
                return BadRequest("update items failed");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
                throw;
            }
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteItems(int id)
        {
            try
            {
                var deleteItems = _itemsServices.DeleteItems(id);
                if (deleteItems)
                {
                    return Ok("delete items succes");
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
