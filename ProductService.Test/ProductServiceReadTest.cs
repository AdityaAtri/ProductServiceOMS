
using Xunit;

using ProductService.Data;

using ProductService.Web.Controllers;
using Microsoft.AspNetCore.Mvc;


namespace ProductService.Test
{
    public class ProductServiceReadTest 
    {
        ReadController controller;
        public ProductServiceReadTest()
        {
            this.controller = new ReadController();
        }
        

        [Fact]
        public void GetAllProductsReturnOk()
        {

            
            IActionResult result = controller.Get();
            Assert.IsType<JsonResult>(result);
        }
        [Fact]
        public void GetProductByIdReturnOk()
        {
            ProductDAO productDAO= new ProductDAO();
            string product_id = productDAO.InsertOneProduct("{'product_name' : 'Xunit-GetById-Test'}");   
            System.Console.WriteLine(product_id);
            IActionResult result = controller.Get(product_id);
            productDAO.DeleteById(product_id);
            Assert.IsType<JsonResult>(result);
            
        }

        [Fact]
        public void GetProductByIdReturnNotFound()
        {

            var product_id = "Wrong-product_id";
            IActionResult result = controller.Get(product_id);
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}