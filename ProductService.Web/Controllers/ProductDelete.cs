using Microsoft.AspNetCore.Mvc;
using ProductService.Data;

namespace ProductService.Web.Controllers
{
    // [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("OMS/product/[controller]")]
    public class DeleteController : ControllerBase
    {
        [HttpDelete("{ProductId}")]
        public IActionResult DeleteProductOne(string ProductId)
        {
            try
            {
                ProductDAO product = new ProductDAO();
                product.DeleteById(ProductId);

                System.Console.WriteLine("Product Deleted : " + ProductId);
                return Ok(new { message = "Product Deleted" });
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                return NotFound(new { message = e.Message }); ;
            }
        }
    }
}