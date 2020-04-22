using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindAPI.Models
{
    public class ProductDetail
    {
        public int OrderID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public Decimal CurrentPrice { get; set; }
        public Decimal PriceAtOrder { get; set; }
        public double Discount { get; set; }
    }
}
