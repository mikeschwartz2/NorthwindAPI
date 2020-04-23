using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindAPI.Models
{
    public class OrderDetails
    {
        private int orderId;
        private int productID;
        private double unitPrice;
        private int quantity;
        private double discount;

        public int OrderId { get => orderId; set => orderId = value; }
        public int ProductID { get => productID; set => productID = value; }
        public double UnitPrice { get => unitPrice; set => unitPrice = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Discount { get => discount; set => discount = value; }
    }
}
