using Xunit;
using System.Text.Json;
using ProductService.Data;
using MongoDB.Bson;
using ProductService.Web.Controllers;
using Microsoft.AspNetCore.Mvc;


namespace ProductService.Test {

    public class ProductServiceCreateTest
    {

        CreateController controller;
        public ProductServiceCreateTest()
        {
            this.controller = new CreateController();
        }
        [Fact]    
        public void InsertProductStatusTest()
        {
            var result = controller.InsertOneProduct(JsonDocument.Parse("{\"product_name\" : \"Xunit-Create-Test\"}").RootElement);
            ProductDAO productDAO = new ProductDAO();
            var objectResult = result as OkObjectResult;
            string product_id = objectResult.Value.ToBsonDocument().GetValue("productId").ToString();
            productDAO.DeleteById(product_id);
            Assert.IsType<OkObjectResult>(result);
            
        }
        public void InsertProductStatusErrorStatus()
        {
            var result = controller.InsertOneProduct(new JsonElement());
            Assert.IsType<NotFoundObjectResult>(result);
            
        }
    }
}