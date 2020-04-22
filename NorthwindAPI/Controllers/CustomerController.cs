using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NorthwindAPI.Models;
using Dapper;

namespace NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomerController : ControllerBase
    {
        private string connectionString;
        public CustomerController(IConfiguration config)
        {
            connectionString = config.GetConnectionString("default");
        }
        [HttpGet]
        public IEnumerable<Customer> GetAllCustomers()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "SELECT * FROM Customers ";

            return conn.Query<Customer>(command);
        }

        [HttpGet("{id}")]
        public Customer GetCustomer(string id)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            string command = "select * from customers where CustomerID = @id";
            return conn.QueryFirstOrDefault<Customer>(command, new { id = id });
        }

        [HttpPost]
        public Object Post(Customer c)
        {
            SqlConnection connection = null;
            string command = "INSERT INTO Customers (CustomerID, CompanyName)";
            command += " VALUES (@CustomerID, @CompanyName);";
            command += " SELECT SCOPE_IDENTITY();";

            int newId;
            connection = new SqlConnection(connectionString);

            newId = connection.ExecuteScalar<int>(command, c);

            if(newId < 0)
            {
                return new { newId = false };
            }
            return new { newId = true, id = newId };
        }


    }
    
}