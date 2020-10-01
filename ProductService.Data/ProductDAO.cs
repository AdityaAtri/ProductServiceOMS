using MongoDB.Driver;
using MongoDB.Bson;
using System.Linq;
using System.Collections.Generic;
using System;


namespace ProductService.Data
{
    public class ProductDAO
    {
        IMongoDatabase productsDB;
        IMongoCollection<BsonDocument> collection;
        public ProductDAO()
        {
            try
            {
                productsDB = MongoConnect.EstablishConnection();
                collection = productsDB.GetCollection<BsonDocument>("ProductDetails");
                System.Console.WriteLine("Collection opened");
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        public string InsertOneProduct(string sDoc)
        {
                string str = sDoc;
                BsonDocument doc = BsonDocument.Parse(str);
                string productId = Guid.NewGuid().ToString();
                doc.Add("product_id", productId);
                collection.InsertOne(doc);
                return productId;

        }
        public List<BsonDocument> GetAllProducts()
        {
            List<BsonDocument> documents = new List<BsonDocument>();
            documents = collection.Find(new BsonDocument()).Project(Builders<BsonDocument>.Projection.Include("product_id").Include("product_name").Include("brand").Include("price").Exclude("_id")).ToList();
            return documents;
        }
        public BsonDocument GetById(string id)
        {
            BsonDocument productDoc = null;
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("product_id", id);
                productDoc = collection.Find(filter).Project(Builders<BsonDocument>.Projection.Exclude("_id")).FirstOrDefault();
                if (productDoc==null)
                {
                    throw new Exception("Product Not found in . ID : " + id);
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }
            return productDoc;
        }

        // public BsonDocument GetByName(string name)
        // {
        //     BsonDocument productDoc = null;
        //     try
        //     {
        //         var filter = Builders<BsonDocument>.Filter.Regex("product_name", name);
        //         productDoc = collection.Find(filter).Project(Builders<BsonDocument>.Projection.Exclude("_id")).FirstOrDefault();
        //     }
        //     catch (System.Exception e)
        //     {

        //         throw e;
        //     }
        //     return productDoc;
        // }
        public bool UpdateById(string id, string sDoc)
        {
            try
            {
                BsonDocument doc = BsonDocument.Parse(sDoc);
                
                var filter = Builders<BsonDocument>.Filter.Eq("product_id", id);
                var productDoc = collection.Find(filter).FirstOrDefault();
                if (productDoc==null)
                {
                    throw new Exception("Product Not found in . ID : " + id);
                }
                if(doc.Contains("product_id"))
                    doc.Remove("product_id");
                doc.Add("product_id",id);
                collection.ReplaceOne(filter, doc);
                return true;
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public void DeleteById(string id)
        {
            try
            {
                var filter = Builders<BsonDocument>.Filter.Eq("product_id", id);
                var productDoc = collection.Find(filter).FirstOrDefault();
                if (productDoc==null)
                {
                    throw new Exception("Product Not found in . ID : " + id);
                }
                TakeBackup(filter);
                collection.DeleteOne(filter);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
        private void TakeBackup(FilterDefinition<BsonDocument> filter)
        {
            try
            {
                IMongoDatabase productsDBbak = MongoConnect.EstablishConnectionBackup();
                var collBak = productsDBbak.GetCollection<BsonDocument>("ProductDetails");
                BsonDocument doc = collection.Find(filter).FirstOrDefault();
                doc.Set("createdAt", DateTime.Now);
                collBak.InsertOne(doc);
                System.Console.WriteLine("Insert to Backup Success");
            }
            catch (System.Exception e)
            {
                throw e;
            }

        }
    }
}