using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkSUBD.DocumentInto
{
    class Checker
    {
        [BsonRepresentation(BsonType.String)]
        public string FIO { get; set; }
        [BsonRepresentation(BsonType.String)]
        public string UserLogin { get; set; }
    }
}
