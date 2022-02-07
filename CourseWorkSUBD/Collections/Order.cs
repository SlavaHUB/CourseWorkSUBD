using CourseWorkSUBD.DocumentInto;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkSUBD.Collections
{
    class Order
    {
        public ObjectId Id { get; set; }
        [BsonIgnoreIfNull]
        public Checker Checker { get; set; }
        [BsonIgnoreIfNull]
        public Master Master { get; set; }
        public string DateRegistr { get; set; }
        public int Payment { get; set; }
        public string Status { get; set; }
        public ClientInto Client { get; set; }
        public Auto Auto { get; set; }
        public List<WorkInto> Works { get; set; }
    }
}
