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
    public class NorthwindController : ControllerBase
    {
        private string connectionString;

        public NorthwindController(IConfiguration config)
        {
            connectionString = config.GetConnectionString("default");
        }

        [HttpGet]
        public IEnumerable<CustomerSummary> Get()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "EXEC CustomerSummary";

            IEnumerable<CustomerSummary> result = conn.Query<CustomerSummary>(command);
            return result;
        }

        [HttpGet("ByCountry/{id}")]
        public IEnumerable<CustomerSummary> GetByCountry(string id = null)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "EXEC CustSummaryByCountry @Country";
            IEnumerable<CustomerSummary> result = conn.Query<CustomerSummary>(command, new { Country = id });
            return result;
        }

        [HttpGet("ProductDetail/{id}")]
        public IEnumerable<ProductDetail> GetProductDetails(int id)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            SqlConnection conn = new SqlConnection(connectionString);
            string command = "EXEC ProductDetail2 @OrderId";
            var result = conn.Query<ProductDetail>(command, new { OrderId = id });
            //example of simple error handling
            //if (result == null)
            //{
            //    return new List<ProductDetail>();
            //}
            return result;
        }

        //[HttpGet]
        //public string[] TestGet()
        //{
        //    string[] words = { "hello", "world", "beautiful", "morning" };

        //    return words;
        //}

        //[HttpGet("Client")]
        //public Object TestGetClients()
        //{
        //    return new
        //    {
        //        ClientName = "Guenther Software",
        //        CustomerName = "Peter Guenther",
        //        LastYearsSales = 41000000
        //    };
        //}
    }
}