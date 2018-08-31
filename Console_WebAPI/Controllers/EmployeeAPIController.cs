using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Console_WebAPI.Models;

namespace Console_WebAPI.Controllers
{
    public class EmployeeAPIController : ApiController
    {

        [Route("api/EmployeeAPI/GetEmployees")]
        [HttpPost]
        public List<Emp> GetEmployees(EmployeeModel emp)
        {
            EmpEntities entities = new EmpEntities();
            return (from c in entities.Emps.Take(10)
                    where c.EmpName.StartsWith(emp.Name) || string.IsNullOrEmpty(emp.Name)
                    select c).ToList();
        }
        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        

        
    }
}