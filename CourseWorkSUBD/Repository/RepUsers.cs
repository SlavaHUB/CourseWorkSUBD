using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CourseWorkSUBD.Collections;
using CourseWorkSUBD.MongoConnect;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CourseWorkSUBD.Repository
{
    public class RepUsers
    {
        static private IMongoDatabase database = Connect.GetDatabase();
        public static List<User> SelectAll()
        {
            var collection = database.GetCollection<User>("Users");
            var filter = new BsonDocument();
            var people = collection.Find(filter).ToList();
            List<User> users = new List<User>();

            foreach (User doc in people)
                users.Add(doc);

            return users;
        }

        public static void Insert(User user)
        {
            var collection = database.GetCollection<User>("Users");
            collection.InsertOne(user);
        }

        public static User SelectByLogin(string login)
        {
            var collection = database.GetCollection<User>("Users");
            var filter = new BsonDocument(new BsonDocument("UserLogin", login));
            var documents = collection.Find(filter).ToList();
            User user;
            if (documents.Count() == 0)
                return null;
            else
                user = documents.First();

            return user;
        }

        public static User SelectByLogPass(string login, string pass)
        {
            var collection = database.GetCollection<User>("Users");
            var filter = new BsonDocument("$and", new BsonArray
            {
                new BsonDocument("UserLogin", login),
                new BsonDocument("UserPassword", pass)
            });
            var documents = collection.Find(filter).ToList();
            User user;

            if (documents.Count() == 0)
                return null;
            else
                user = documents.First();

            return user;
        }
    }
}