using System;
using Microsoft.AspNetCore.Mvc;
using ProductService.Data;
using System.Text.Json;

namespace ProductService.Web.Controllers
{
    // [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("OMS/product/[controller]")]
    public class UpdateController : ControllerBase
    {
        [HttpPut, Route("{id}")]
        public IActionResult UpdateItem(string id, [FromBody] JsonElement updatedJson)
        {
            try
            {

                string updateJsonString = JsonSerializer.Serialize(updatedJson);
                ProductDAO prodDAO = new ProductDAO();
                prodDAO.UpdateById(id, updateJsonString);
                System.Console.WriteLine("Product updated : " + id);
                return Ok(new { message = "Product Updated" });
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
                return NotFound(new { message = e.Message });
            }
        }
    }

}