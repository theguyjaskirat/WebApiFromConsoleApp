using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Text;
using System.Net.Http;
using System.Web.Script.Serialization;

namespace Console_WebAPI_HttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Start:
            Console.Write("Enter Employee Name to fetch details: ");
            string name = Console.ReadLine();
            string apiUrl = "http://localhost:26404/api/EmployeeAPI";
            var input = new
            {
                Name = name,
            };
            string inputJson = (new JavaScriptSerializer()).Serialize(input);

            HttpClient client = new HttpClient();
            HttpContent inputContent = new StringContent(inputJson, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(apiUrl + "/GetEmployees", inputContent).Result;
            if (response.IsSuccessStatusCode)
            {
                List<Emp> Empdata = (new JavaScriptSerializer()).Deserialize<List<Emp>>(response.Content.ReadAsStringAsync().Result);
                if (Empdata.Count > 0)
                {
                    foreach (Emp e in Empdata)
                    {
                        Console.WriteLine("Employee Name - " + e.EmpName + Environment.NewLine+"Phone - "+e.PhoneNo+ Environment.NewLine+"Salary - "+e.Salary);
                    }
                }
                else
                {
                    Console.WriteLine("No records found.");
                }
            }

            Console.WriteLine();
            goto Start;
        }
        public partial class Emp
        {
            public int Empid { get; set; }
            public string EmpName { get; set; }
            public Nullable<int> PhoneNo { get; set; }
            public Nullable<int> DeptID { get; set; }
            public Nullable<int> Salary { get; set; }
            public string status { get; set; }
        }
         
    }
}
