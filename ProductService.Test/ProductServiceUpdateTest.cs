
using Xunit;

using System.Text.Json;

using ProductService.Data;

using ProductService.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Test
{

    public class ProductServiceUpdateTest
    {
        UpdateController controller;
        public ProductServiceUpdateTest()
        {
            controller = new UpdateController();
        }

        [Fact]
        public void UpdateProductByIdOkSatus()
        {
            ProductDAO productDAO= new ProductDAO();
            string productId = productDAO.InsertOneProduct("{'product_name' : 'Xunit-Update-Test'}");
            var result = controller.UpdateItem(productId,JsonDocument.Parse("{\"product_name\" : \"Xunit-Update-Test-Succcess\"}").RootElement);
            productDAO.DeleteById(productId);
            Assert.IsType<OkObjectResult>(result);
            
        }
        
        [Fact]
        public void UpdateProductByIdErrorStatus()
        {
            var result = controller.UpdateItem("Wrong-product-id",JsonDocument.Parse("{\"product_name\" : \"Xunit-Update-Test-Succcess\"}").RootElement);
            Assert.IsType<NotFoundObjectResult>(result);
        }
       
    }
}
