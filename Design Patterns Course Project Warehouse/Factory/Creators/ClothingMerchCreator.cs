using Design_Patterns_Course_Project_Warehouse.Factory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns_Course_Project_Warehouse.Factory.Creators
{
    // Concrete Creator
    public class ClothingMerchCreator : IStoredProductCreator
    {
        public StoredProduct CreateStoredProduct()
        {
            Console.WriteLine("Enter new product info -----------");
            Console.Write("Enter stored product barcode : ");
            string barcode = Console.ReadLine();
            Console.Write("Enter stored product name : ");
            string name = Console.ReadLine();
            Console.Write("Enter stored product price : ");
            double price = double.Parse(Console.ReadLine());
            Console.WriteLine("---------------------------------");
            return new ClothingMerch(barcode, name, price);
        }
    }
}
