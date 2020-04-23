using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private string connectionString;
        public OrderDetailController(IConfiguration config)
        {
            connectionString = config.GetConnectionString("default");
        }

        [HttpDelete("{id}")]
        public Object Delete(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string deleteCommand = "DELETE FROM [Order Detail] WHERE OrderId = @id;";

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