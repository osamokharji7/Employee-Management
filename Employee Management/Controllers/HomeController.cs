using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Security.AccessControl;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Employee_Management.Models;
using System.Configuration;
using System.Collections;
using System.Web.Helpers;
using Microsoft.Ajax.Utilities;

namespace Employee_Management.Controllers
{
    public class HomeController : Controller
    {
        [System.Web.Mvc.HttpPost]
        public string EmployeeFunctions([FromBody] Employee post_data)
        {

            string first_name = post_data.first_name;
            string last_name = post_data.last_name;
            int designation = post_data.designation;
            string joining_date = post_data.joining_date;
            string choice = post_data.operation;
            int id = int.Parse(post_data.id);
            SqlConnection conn = new SqlConnection("data source =LAPTOP-SOPLE7JG\\SQLEXPRESS; database = master; integrated security = True");
            conn.Open();
            try
            {
                
                if (choice == "add")
                {
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = $"insert into employee values ('{last_name}', '{first_name}', {designation},'{joining_date}')";
                    comm.ExecuteScalar();
                }
                
                else if (choice == "update")
                {
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = $"update employee set FirstName = '{first_name}', LastName = '{last_name}', designation = {designation}, joining_date = '{joining_date}' where id = {id}";
                    comm.ExecuteScalar();
                }

                else if (choice == "delete")
                {
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = $"delete from employee where id = {id}";
                    comm.ExecuteScalar();
                }
                else
                {
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = $"delete from employee where id = {id}";
                    comm.ExecuteScalar();
                }
                return "done";
              
            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
        [System.Web.Mvc.HttpGet]
        public string GetEmployees ()
        {
            SqlConnection conn = new SqlConnection("data source =LAPTOP-SOPLE7JG\\SQLEXPRESS; database = master; integrated security = True");
            conn.Open();
            ArrayList emplist = new ArrayList();
            DataTable dt = new DataTable();
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = "select * from employee order by FirstName, LastName";
            SqlDataAdapter adap = new SqlDataAdapter(comm);
            adap.Fill(dt); 
            foreach (DataRow row in dt.Rows)
            {
                Employee emp = new Employee(row["id"].ToString(), (string)row["FirstName"], (string)row["LastName"], (int)row["designation"], DateTime.Parse(row["joining_date"].ToString()), "select");
                emplist.Add(emp);
            }
            return JsonConvert.SerializeObject(emplist);
        }

        [System.Web.Mvc.HttpPost]
        public string DesignationFunctions([FromBody] Designation post_data)
        {

            string name = post_data.name;
            string choice = post_data.operation;
            int id = int.Parse(post_data.id);
            SqlConnection conn = new SqlConnection("data source =LAPTOP-SOPLE7JG\\SQLEXPRESS; database = master; integrated security = True");
            conn.Open();
            try
            {

                if (choice == "add")
                {
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = $"insert into designation values ('{name}')";
                    comm.ExecuteScalar();
                }

                else if (choice == "update")
                {
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandType = CommandType.Text;
                    comm.CommandText = $"update designation set name = '{name}' where id = {id}";
                    comm.ExecuteScalar();
                }

                return "done";

            }
            catch (Exception e)
            {

                return e.Message;
            }
        }
        [System.Web.Mvc.HttpGet]
        public string GetDesignations()
        {
            SqlConnection conn = new SqlConnection("data source =LAPTOP-SOPLE7JG\\SQLEXPRESS; database = master; integrated security = True");
            conn.Open();
            ArrayList deslist = new ArrayList();
            DataTable dt = new DataTable();
            SqlCommand comm = new SqlCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "select * from designation order by id, name";
            SqlDataAdapter adap = new SqlDataAdapter(comm);
            adap.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                Designation des = new Designation(row["id"].ToString(), (string)row["name"], "select");
                deslist.Add(des);
            }
            return JsonConvert.SerializeObject(deslist);
        }
        public ActionResult Employee()
        {
            ViewBag.Message = "Here";
            return View();
        }
        public ActionResult Designation()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}