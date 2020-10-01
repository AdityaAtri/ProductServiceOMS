using System;
using Xunit;
using ProductService.Data;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ProductService.Test
{
    public class DAOFunctionTest
    {
        [Fact]
        public void InsertOneProductTestReturnProductIdTrue()
        {

            ProductDAO productDAO = new ProductDAO();
            var jsonData = new BsonDocument();
            jsonData.Add("product_name", "Cup");
            jsonData.Add("brand", "Red Hat");
            jsonData.Add("price", "54");
            jsonData.Add("product_category", "Cloth");
            jsonData.Add("product_colour", "White");
            jsonData.Add("product_description", "A good bulb");
            jsonData.Add("product_dimensions", "3 * 4 * 5");
            jsonData.Add("product_main_image", "http://find-image");
            var productId = productDAO.InsertOneProduct(jsonData.ToString());
            BsonDocument document = productDAO.GetById(productId);
            Assert.Equal(productId, document["product_id"]);
            productDAO.DeleteById(productId);
        }

        [Fact]
        public void GetByProductIdTestTrue()
        {

            ProductDAO productDAO = new ProductDAO();
            var jsonData = new BsonDocument();
            jsonData.Add("product_name", "Cup");
            jsonData.Add("brand", "Red Hat");
            jsonData.Add("price", "54");
            jsonData.Add("product_category", "Cloth");
            jsonData.Add("product_colour", "White");
            jsonData.Add("product_description", "A good bulb");
            jsonData.Add("product_dimensions", "3 * 4 * 5");
            jsonData.Add("product_main_image", "http://find-image");
            var productId = productDAO.InsertOneProduct(jsonData.ToString());
            BsonDocument document = productDAO.GetById(productId);
            Assert.Equal(productId, document["product_id"]);
            productDAO.DeleteById(productId);
        }

        [Fact]
        public void UpdateByIdReturnProductIdTrue()
        {

            ProductDAO productDAO = new ProductDAO();
            var jsonData = new BsonDocument();
            jsonData.Add("product_name", "Cup");
            jsonData.Add("brand", "Red Hat");
            jsonData.Add("price", "54");
            jsonData.Add("product_category", "Cloth");
            jsonData.Add("product_colour", "White");
            jsonData.Add("product_description", "A good bulb");
            jsonData.Add("product_dimensions", "3 * 4 * 5");
            jsonData.Add("product_main_image", "http://find-image");
            var productId = productDAO.InsertOneProduct(jsonData.ToString());

            var jsonDataUpdated = new BsonDocument();
            jsonDataUpdated.Add("product_name", "UpdatedsfgfgCup");
            jsonDataUpdated.Add("brand", "Red Hat");
            jsonDataUpdated.Add("price", "54");
            jsonDataUpdated.Add("product_category", "Cloth");
            jsonDataUpdated.Add("product_colour", "White");
            jsonDataUpdated.Add("product_description", "A good bulb");
            jsonDataUpdated.Add("product_dimensions", "3 * 4 * 5");
            jsonDataUpdated.Add("product_main_image", "http://find-image");
            bool result = productDAO.UpdateById(productId, jsonDataUpdated.ToString());
            Assert.Equal(true, result);
            productDAO.DeleteById(productId);
        }

        [Fact]
        public void DeleteByProductIdTestTrue()
        {

            ProductDAO productDAO = new ProductDAO();
            var jsonData = new BsonDocument();
            jsonData.Add("product_name", "Cup");
            jsonData.Add("brand", "Red Hat");
            jsonData.Add("price", "54");
            jsonData.Add("product_category", "Cloth");
            jsonData.Add("product_colour", "White");
            jsonData.Add("product_description", "A good bulb");
            jsonData.Add("product_dimensions", "3 * 4 * 5");
            jsonData.Add("product_main_image", "http://find-image");
            var productId = productDAO.InsertOneProduct(jsonData.ToString());
            productDAO.DeleteById(productId);
            Assert.Throws<System.Exception>(() => productDAO.GetById(productId));
        }

    }
}