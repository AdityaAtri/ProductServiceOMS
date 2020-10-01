using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;
namespace ProductService.Data
{
    [ExcludeFromCodeCoverage]
    public static class MongoConnect
    {
        
        public static IMongoDatabase EstablishConnection()
        {
            IMongoDatabase productsDB;
            try
            {
                MongoClient mongoClient = new MongoClient("mongodb://localhost:27017");
                productsDB = mongoClient.GetDatabase("ProductsDB");
                System.Console.WriteLine("Connection Established");
            }
            catch (System.Exception e)
            {
                throw e;
            }
            return productsDB;
        }
        
        public static IMongoDatabase EstablishConnectionBackup()
        {
            IMongoDatabase productsDBbak;
            try
            {
                MongoClient mongoClient = new MongoClient("mongodb://localhost:27017");
                productsDBbak = mongoClient.GetDatabase("ProductsDBbak");
                System.Console.WriteLine("Connection Established for backup");
            }
            catch (System.Exception e)
            {
                throw e;
            }
            return productsDBbak;
        }
    }
}
