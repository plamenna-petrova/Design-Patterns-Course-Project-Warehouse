using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns_Course_Project_Warehouse.Factory.Models
{
    // Concrete Product
    public class BoardGame : StoredProduct
    {
        public string description;

        public BoardGame(string barcode, string name, double price)
            : base(barcode, name, price)
        {

        }

        public override string Category => GetType().Name;

        public override string Description { get => description; set => description = value; }

        public override void PrintStoredProductInfo()
        {
            Console.WriteLine($"Printing the most important information about the product...");
            Console.WriteLine($"Barcode: {Barcode}, Name: {Name}, Price: {Price}, Category: {Category}");
        }
    }
}
