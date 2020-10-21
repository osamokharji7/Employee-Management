using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_Management.Models
{
    public class Employee
    {
        public Employee()
        {

        }
        public Employee(string eid, string fn, string ln, int des, DateTime jd, string op)
        {
            id = eid;
            first_name = fn;
            last_name = ln;
            designation = des;
            joining_date = jd.ToString("yyyy-MM-dd");
            operation = op;
        }
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public int designation { get; set; }
        public string joining_date { get; set; }
        public string operation { get; set; }
    }
}