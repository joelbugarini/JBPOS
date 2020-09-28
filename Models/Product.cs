using System;
using System.Collections.Generic;
using System.Text;

namespace JBPOS.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int StockNumber { get; set; }
        public string Description { get; set; }
        public float RegularPrice { get; set; }
        public float SalePrice { get; set; }
        public double NoSold { get; set; }
        public float ValueSold { get; set; }
        public double Inventory { get; set; }
        public float Cost { get; set; }
        public int Model { get; set; }
        public int Pack { get; set; }
        public string VendorStockNumber { get; set; }
    }
}
