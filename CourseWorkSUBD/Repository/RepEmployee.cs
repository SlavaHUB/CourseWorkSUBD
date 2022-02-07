using CourseWorkSUBD.Collections;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkSUBD.Repository
{
    class RepEmployee
    {
        static private MongoDB.Driver.IMongoDatabase database = MongoConnect.Connect.GetDatabase();
        public static List<Employee> SelectAll()
        {
            var collection = database.GetCollection<Employee>("Employee");
            var filter = new MongoDB.Bson.BsonDocument();
            var documents = collection.Find(filter).ToList();
            List<Employee> results = new List<Employee>();

            foreach (Employee doc in documents)
                results.Add(doc);

            return results;
        }
    }
}
