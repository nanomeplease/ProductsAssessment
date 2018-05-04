namespace ProductsAssessment.Models
{
    using System;

    public class ProductsPO
    {
        public string ProductName { get; set; }
        public string ProductQuanity { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 UnitsInStock { get; set; }
        public Int16 UnitsOnOrder { get; set; }
    }
}