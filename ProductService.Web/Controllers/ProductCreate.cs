
using Microsoft.AspNetCore.Mvc;
using ProductService.Data;
using System.Text.Json;
namespace ProductService.Web.Controllers

{
    // [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("OMS/product/[controller]")]
    public class CreateController : ControllerBase
    {

        [HttpPost("")]
        public IActionResult InsertOneProduct([FromBody] JsonElement jsonProduct)
        {
            try
            {

                string jsonString = JsonSerializer.Serialize(jsonProduct);
                ProductDAO product = new ProductDAO();
                string productId = product.InsertOneProduct(jsonString);
                System.Console.WriteLine("Product created");
                return Ok(new { message = "Product Inserted", productId = productId });
            }
            catch (System.Exception e)
            {
                return NotFound(new { message = e.Message }); ;
            }
        }


    }
}
