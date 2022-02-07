using CourseWorkSUBD.Collections;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkSUBD.Repository
{
    class RepWorks
    {
        static private MongoDB.Driver.IMongoDatabase database = MongoConnect.Connect.GetDatabase();
        public static List<Work> SelectAll()
        {
            var collection = database.GetCollection<Work>("Works");
            var filter = new MongoDB.Bson.BsonDocument();
            var documents = collection.Find(filter).ToList();
            List<Work> results = new List<Work>();

            foreach (Work doc in documents)
                results.Add(doc);

            return results;
        }

        public static void Delete(string id)
        {
            var collection = database.GetCollection<Work>("Works");
            var filter = new MongoDB.Bson.BsonDocument("_id", new ObjectId(id));
            var a = collection.DeleteOne(filter);
        }

        public static void Update(Work work)
        {
            var collection = database.GetCollection<Work>("Works");
            var filter = new BsonDocument("_id", work.Id);
            var newDoc = new BsonDocument { { "$set", new BsonDocument("Description", work.Description) } };
            collection.UpdateOne(filter, newDoc);
            newDoc = new BsonDocument { { "$set", new BsonDocument("Cost", work.Cost) } };
            collection.UpdateOne(filter, newDoc);
        }

        public static void Insert(Work work)
        {
            var collection = database.GetCollection<Work>("Works");
            collection.InsertOne(work);
        }
    }
}
