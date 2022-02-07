using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkSUBD.Collections
{
    class Work
    {
        public ObjectId Id { get; set; }
        public double Cost { get; set; }
        public string Description { get; set; }
    }
}
