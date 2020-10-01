using System;
using Xunit;
using ProductService.Data;

namespace ProductService.Test{
    public class DAOExceptionTest{


        [Fact]
        public void GetByIdException(){
            ProductDAO productDAO = new ProductDAO();
            Assert.Throws<System.Exception>(() => productDAO.GetById("wrongId"));
        }

        [Fact]
        public void UpdateByWrongIdException(){
            ProductDAO productDAO = new ProductDAO();
            Assert.Throws<System.FormatException>(() => productDAO.UpdateById("wrongId",""));
        }

        [Fact]
        public void DeleteByIdException(){
            ProductDAO productDAO = new ProductDAO();
            Assert.Throws<System.Exception>(() => productDAO.DeleteById("wrongId"));
        }
    }
}