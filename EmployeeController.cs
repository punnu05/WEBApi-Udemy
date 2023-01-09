using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {

        public HttpResponseMessage get()
        {
            DataTable dt = new DataTable();
            string query = @"select EmployeeId, EmployeeName ,Email,Department,convert(varchar(10),DOj,120) as DOJo from Employee  ";
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDbCS"].ConnectionString)) 
                using(var com =new SqlCommand(query,con))
                using( var da = new SqlDataAdapter(com))
            {
                com.CommandType = CommandType.Text;
                da.Fill(dt);
            }
        
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        public string post(Employee emp)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"insert into Employee values('"+ emp.EmployeeName+ @"',
                  '"+emp.Email+ @" ','"+emp.Department+@"','"+emp.DOJ+@"' 
       
                                                                           )";
                
                
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDbCS"].ConnectionString))
                using (var com = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(com))
                {
                    com.CommandType = CommandType.Text;
                    da.Fill(dt);
                }
                return "Added successFully";
            }
            catch (Exception e)
            {
                return "Failed to add";
            }
        }

        public string put(Employee emp)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"update Employee set EmployeeName='" + emp.EmployeeName + @"',Email = '" + emp.Email + @"',
                                       Department ='" + emp.Department + @"',DOJ = '" + emp.DOJ + @"'   where EmployeeId =" + emp.EmployeeId; 
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDbCS"].ConnectionString ) )
                    using(var com =new SqlCommand(query,con))
                    using(var da = new SqlDataAdapter(com))
                {
                    com.CommandType = CommandType.Text;
                    da.Fill(dt);
                }

                return "updated successfully";
            }catch
            {
                return "Failed to update";
            }

        }
        public string delete(long id)
        {
            try
            {
                if (id == 0)
                {
                    return "Unable to delete this id as no record found";
                }
                else
                {
                    DataTable dt = new DataTable();
                    string query = @"delete from Employee where EmployeeId=" + id;
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDbCS"].ConnectionString))
                    using (var com = new SqlCommand(query, con))
                    using (var da = new SqlDataAdapter(com))
                    {
                        com.CommandType = CommandType.Text;
                        da.Fill(dt);
                    }
                    return "successfully deleted";
                }
            }
            catch
            {
                return "Failed to delete";
            }
        }
    }
}
