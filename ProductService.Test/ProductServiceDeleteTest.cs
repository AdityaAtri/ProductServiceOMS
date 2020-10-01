
using Xunit;

using ProductService.Data;
using ProductService.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
namespace ProductService.Test {

    public class ProductServiceDeleteTest
    {
        DeleteController controller;
        public ProductServiceDeleteTest(){
            this.controller = new DeleteController();
        }

        [Fact]    
        public void DeleteProductOkStatus(){
            ProductDAO productDAO= new ProductDAO();
            string productId = productDAO.InsertOneProduct("{\"product_name\" : \"Xunit-Delete-Test\"}");
            var result = controller.DeleteProductOne(productId);
            Assert.IsType<OkObjectResult>(result);
        }
        public void DeleteProductErrorStatus()
        {
            var result = controller.DeleteProductOne("wrong-product-id");
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
