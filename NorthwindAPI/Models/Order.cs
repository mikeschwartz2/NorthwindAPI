using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindAPI.Models
{
    public class Order
    {
        private int orderId;
        private string customerID;
        private DateTime orderDate;
        private DateTime requiredDate;
        private DateTime shippedDate;

        public int OrderId { get => orderId; set => orderId = value; }
        public string CustomerID { get => customerID; set => customerID = value; }
        public DateTime OrderDate { get => orderDate; set => orderDate = value; }
        public DateTime RequiredDate { get => requiredDate; set => requiredDate = value; }
        public DateTime ShippedDate { get => shippedDate; set => shippedDate = value; }
    }
}
