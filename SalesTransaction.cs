using System;

namespace helloworld
{
    public struct SalesTransaction
    {
        public int RowId {get; set;}
        public string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string ShipMode { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Segment { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Statey { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }
        public string ProductId { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string ProductName { get; set; }
        public string Sales { get; set; }
        public string Quantity { get; set; }
        public double Discount { get; set; }
        public double Profit { get; set; }
    }
}