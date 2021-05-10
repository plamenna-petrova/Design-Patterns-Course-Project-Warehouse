using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns_Course_Project_Warehouse.Factory.Models
{
    // Abstract Product
    public abstract class StoredProduct
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public abstract string Category { get; }
        public abstract string Description { get; set; }

        protected StoredProduct(string barcode, string name, double price)
        {
            Barcode = barcode;
            Name = name;
            Price = price;
        }

        public abstract void PrintStoredProductInfo();
    }
}
