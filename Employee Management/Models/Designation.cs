using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_Management.Models
{
    public class Designation
    {
        public Designation()
        {

        }
        public Designation(string did, string thisname, string op)
        {
            id = did;
            name = thisname;
            operation = op;
        }
        public string id { get; set; }
        public string name { get; set; }
        public string operation { get; set; }
    }
}