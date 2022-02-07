using CourseWorkSUBD.Collections;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization;

namespace CourseWorkSUBD.Repository
{
    class RepOrder
    {
        static private MongoDB.Driver.IMongoDatabase database = MongoConnect.Connect.GetDatabase();
        public static List<Order> SelectAll()
        {
            var collection = database.GetCollection<Order>("Orders");
            var filter = new MongoDB.Bson.BsonDocument();
            var documents = collection.Find(filter).ToList();
            List<Order> results = new List<Order>();

            foreach (Order doc in documents)
                results.Add(doc);

            return results;
        }

        public static void UpdatePayment(string id)
        {
            var collection = database.GetCollection<Order>("Orders");
            var filter = new BsonDocument("_id", new ObjectId(id));
            var newDoc = new BsonDocument { { "$set", new BsonDocument("Payment", 1) } };
            collection.UpdateOne(filter, newDoc);
        }

        public static void UpdateStatusAndMaster(Order order)
        {
            var collection = database.GetCollection<Order>("Orders");
            var filter = new BsonDocument("_id", order.Id);
          
            var newDoc = new BsonDocument { { "$set", new BsonDocument("Master.FIO", order.Master.FIO) } };
            collection.UpdateOne(filter, newDoc);
            newDoc = new BsonDocument { { "$set", new BsonDocument("Master.UserLogin", order.Master.UserLogin) } };
            collection.UpdateOne(filter, newDoc);
            newDoc = new BsonDocument { { "$set", new BsonDocument("Master.FIO", order.Master.FIO) } };
            collection.UpdateOne(filter, newDoc);
            newDoc = new BsonDocument { { "$set", new BsonDocument("Checker.UserLogin", order.Checker.UserLogin) } };
            collection.UpdateOne(filter, newDoc);
            newDoc = new BsonDocument { { "$set", new BsonDocument("Checker.FIO", order.Checker.FIO) } };
            collection.UpdateOne(filter, newDoc);
            newDoc = new BsonDocument { { "$set", new BsonDocument("Status", order.Status) } };
            collection.UpdateOne(filter, newDoc);
        }

        public static void UpdateOnlyStatus(string id, string status)
        {
            var collection = database.GetCollection<Order>("Orders");
            var filter = new BsonDocument("_id", new ObjectId(id));
            var newDoc = new BsonDocument { { "$set", new BsonDocument("Status", status) } };
            collection.UpdateOne(filter, newDoc);
        }

        public static void Insert(Order order)
        {
            var collection = database.GetCollection<Order>("Orders");
            collection.InsertOne(order);
        }
    }
}
