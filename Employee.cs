using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Employee
    {
        public long EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Department { get; set; }
        public string Email { get; set; }
        public DateTime? DOJ { get; set; }
    }
}