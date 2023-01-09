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
    public class DepartmentController : ApiController
    {
      
        public HttpResponseMessage Get()
        {
            DataTable table = new DataTable();
            string query = @"select depatmentid ,departmentname from Department";
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDbCS"].ConnectionString);
            using (con) 
            using (var com = new SqlCommand(query, con)) 
            using (var da = new SqlDataAdapter(com))
            {
                com.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
      
        public string Post(Department dep)
        {
            try
            {
                DataTable dt = new DataTable();
                string query = @"insert into Department values('" + dep.DepartmentName + @"' )  
                        " ;
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDbCS"].ConnectionString)) 
                    using(var com =new SqlCommand(query,con))
                    using(var da =new SqlDataAdapter(com))
                {
                    com.CommandType = CommandType.Text;
                    da.Fill(dt);
                }
               
                    return "Added SuccessFully";
            }
            catch(Exception e)
            {
                return e.ToString();
            }
        }
        public string put(Department dep)
        {
            try
            {
                if (dep.DepartmentId == 0 || dep.DepartmentId==null)
                {
                    return "There is no record to update";
                }
                else
                {
                    DataTable dt = new DataTable();
                    string qry = @"update department set DepartmentName ='" + dep.DepartmentName + @"' where DepatmentId= " + dep.DepartmentId;
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDbCS"].ConnectionString))
                    using (var com = new SqlCommand(qry, con))
                    using (var da = new SqlDataAdapter(com))
                    {
                        com.CommandType = CommandType.Text;
                        da.Fill(dt);
                    }
                    return "Updated succesfully";
                }
                
            }
            catch
            {
                return "failed to Update";
            }
        }
        public string delete(long id)
        {
            try
            {
                if(id==0 || id == null)
                {
                    return "No Record Found";
                }
                else
                {
                    DataTable dt = new DataTable();
                    string qry = @"delete from department where DepatmentId = " + id;
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDbCS"].ConnectionString))
                    using (var com = new SqlCommand(qry, con))
                    using (var da = new SqlDataAdapter(com))
                    {
                        com.CommandType = CommandType.Text;
                        da.Fill(dt);
                    }
                
                }
                return "Deleted!!";
            }
            catch
            {
                return "Failed to delete";
            }
        }
    }
}
