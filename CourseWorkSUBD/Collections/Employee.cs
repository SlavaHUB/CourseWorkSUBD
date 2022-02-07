using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseWorkSUBD.Collections
{
    class Employee
    {
        public ObjectId Id { get; set; }
        public string FIO { get; set; }
        public string PrivateData { get; set; }
        public double Salary { get; set; }
        public string UserLogin { get; set; }
        public string Position { get; set; }
    }
}
