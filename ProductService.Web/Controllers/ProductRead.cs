using Microsoft.AspNetCore.Mvc;
using ProductService.Data;
using MongoDB.Bson;

namespace ProductService.Web.Controllers
{
    // [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("OMS/product/[controller]")]
    public class ReadController : ControllerBase
    {
        [HttpGet, Route("")]
        public IActionResult Get()
        {
                ProductDAO prodDAO = new ProductDAO();
                System.Console.WriteLine("Get all products");
                return (new JsonResult(prodDAO.GetAllProducts().ConvertAll(BsonTypeMapper.MapToDotNetValue)));   
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                System.Console.WriteLine("Product deltails for Product id : " + id);
                ProductDAO prodDAO = new ProductDAO();
                BsonDocument doc = prodDAO.GetById(id);
                return (new JsonResult(BsonTypeMapper.MapToDotNetValue(doc)));
            }
            catch (System.Exception e)
            {
                System.Console.WriteLine(e.Message);
                return NotFound(new { message = "Not Found" });

            }

        }



    }
}