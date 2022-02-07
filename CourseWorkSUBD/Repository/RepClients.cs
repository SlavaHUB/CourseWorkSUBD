using CourseWorkSUBD.Collections;
using CourseWorkSUBD.MongoConnect;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseWorkSUBD.Repository
{
    class RepClients
    {
        static private IMongoDatabase database = Connect.GetDatabase();
        public static List<Client> SelectAll()
        {
            var collection = database.GetCollection<Client>("Clients");
            var filter = new BsonDocument();
            var documents = collection.Find(filter).ToList();
            if (documents == null)
                return null;

            List<Client> clients = new List<Client>();

            foreach (Client doc in documents)
                clients.Add(doc);

            return clients;
        }

        public static Client SelectByLogin(string login)
        {
            var collection = database.GetCollection<Client>("Clients");
            var filter = new BsonDocument("UserLogin", login);
            var documents = collection.Find(filter).ToList();
            Client client;

            if (documents.Count() == 0)
                return null;
            else
                client = documents.First();

            return client;
        }

        public static void Update(string login, string feedback)
        {
            var collection = database.GetCollection<Client>("Clients");
            var filter = new BsonDocument("UserLogin", login);
            var newDoc = new BsonDocument { { "$set", new BsonDocument("Feedback", feedback) } };
            collection.UpdateOne(filter, newDoc);
        }

        public static void Insert(Client client)
        {
            var collection = database.GetCollection<Client>("Clients");
            collection.InsertOne(client);
        }

        public static void UpdatePrivateData(Client client)
        {
            var collection = database.GetCollection<Client>("Clients");
            var filter = new BsonDocument("UserLogin", client.UserLogin);
            var newDoc = new BsonDocument { { "$set", new BsonDocument("FIO", client.FIO) } };
            collection.UpdateOne(filter, newDoc);
            newDoc = new BsonDocument { { "$set", new BsonDocument("Phone", client.Phone) } };
            collection.UpdateOne(filter, newDoc);
        }
    }
}
