using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkSUBD.Collections
{
    public class Client
    {
        public ObjectId Id { get; set; }
        public string FIO { get; set; }
        public string UserLogin { get; set; }
        public string Phone { get; set; }
        public string Feedback { get; set; }
    }
}
