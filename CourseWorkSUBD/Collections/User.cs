using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkSUBD.Collections
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string Rank { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }
    }
}
