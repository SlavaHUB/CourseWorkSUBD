using CourseWorkSUBD.Collections;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkSUBD.Repository
{
    class RepMarks
    {
        static private MongoDB.Driver.IMongoDatabase database = MongoConnect.Connect.GetDatabase();
        public static List<Marka> SelectAll()
        {
            var collection = database.GetCollection<Marka>("Marks");
            var filter = new MongoDB.Bson.BsonDocument();
            var documents = collection.Find(filter).ToList();
            List<Marka> results = new List<Marka>();

            foreach (Marka doc in documents)
                results.Add(doc);

            return results;
        }
    }
}
