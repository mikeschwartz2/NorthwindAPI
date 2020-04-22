using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NorthwindAPI.Models;

namespace NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private string connectionString;
        public OrderController(IConfiguration config)
        {
            connectionString = config.GetConnectionString("default");
        }
  
        [HttpGet]
        public IEnumerable<Order> GetAllOrders()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "SELECT * FROM Orders";

            return conn.Query<Order>(command);
        }

        [HttpGet("{id}")]
        public Order GetOrderByCustomerId(string id)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            string command = "select * from orders where CustomerID = @id";
            return conn.QueryFirstOrDefault<Order>(command, new { id = id });
        }

    }

}