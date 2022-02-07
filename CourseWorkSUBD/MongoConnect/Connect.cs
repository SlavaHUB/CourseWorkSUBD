using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseWorkSUBD.MongoConnect
{
    public class Connect
    {
        public static IMongoDatabase GetDatabase()
        {
            try
            {
                string connectionString = "mongodb://localhost";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("STO_Mongodb");
                return database;
            }
            catch(Exception mes) 
            { 
                MessageBox.Show("Error: " + mes);
                return null;
            }
        }
    }
}
