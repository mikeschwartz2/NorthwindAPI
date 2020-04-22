using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NorthwindAPI.Models;
using Dapper;
using System.Data.SqlClient;

namespace NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private string connectionString;
        public EmployeeController(IConfiguration config)
        {
            connectionString = config.GetConnectionString("default");
        }

        [HttpGet]
        public IEnumerable<Employee> GetAllEmployees()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "SELECT LastName, FirstName, Title FROM Employees ";

            return conn.Query<Employee>(command);
        }

        [HttpGet("title")]
        public IEnumerable<Employee> GetAllTitles()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "SELECT DISTINCT Title FROM Employees ";

            return conn.Query<Employee>(command);
        }

        [HttpPost]
        public Object Post(Employee e)
        {
            SqlConnection connection = null;
            string command = "INSERT INTO Employee (LastName, FirstName, Title)";
            command += " VALUES (@LastName, @FirstName, @Title);";
            command += " SELECT SCOPE_IDENTITY();";

            int newId;
            connection = new SqlConnection(connectionString);

            newId = connection.ExecuteScalar<int>(command, e);

            if (newId < 0)
            {
                return new { newId = false };
            }
            return new { newId = true, id = newId };
        }

        [HttpDelete("{id}")]
        public Object Delete(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string deleteCommand = "DELETE FROM Employee WHERE ID = @id;";

            int result = connection.Execute(deleteCommand, new { id = id });

            if (result > 0)
            {
                return new { success = true };
            }
            else
            {
                return new { success = false };
            }
        }


    }
}