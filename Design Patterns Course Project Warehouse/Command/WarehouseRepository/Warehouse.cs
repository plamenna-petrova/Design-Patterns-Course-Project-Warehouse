using Design_Patterns_Course_Project_Warehouse.Command.WarehouseRepository;
using Design_Patterns_Course_Project_Warehouse.Factory.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Design_Patterns_Course_Project_Warehouse.Command
{
    // Receiver class
    public class Warehouse : IWarehouse
    {
        private List<StoredProduct> inventory;

        public Warehouse()
        {
            inventory = new List<StoredProduct>();
        }

        public void IncreasePrice(StoredProduct storedProduct, int amount)
        {
            if (storedProduct != null)
            {
                storedProduct.Price += amount;
                Console.WriteLine($"The price for the stored product {storedProduct.Name} has been increased by {amount}");
            }
        }

        public bool DecreasePrice(StoredProduct storedProduct, int amount)
        {
            if (amount < storedProduct.Price)
            {
                storedProduct.Price -= amount;
                Console.WriteLine($"The price for the stored product {storedProduct.Name} has been decreased by {amount}");
                return true;
            }
            return false;
        }

        public void AddStoredProduct(StoredProduct storedProduct)
        {
            if (storedProduct != null)
            {
                inventory.Add(storedProduct);
            }
        }

        public void RemoveStoredProduct(StoredProduct storedProduct)
        {
            if (storedProduct == FindStoredProduct(storedProduct.Barcode))
            {
                inventory.Remove(storedProduct);
            }
        }

        public StoredProduct FindStoredProduct(string barcode)
        {
            return inventory.Find(sp => sp.Barcode == barcode);
        }

        public void EditStoredProduct(StoredProduct oldStoredProduct, StoredProduct newStoredProduct)
        {
            oldStoredProduct = FindStoredProduct(oldStoredProduct.Barcode);
            if (oldStoredProduct != null && newStoredProduct != null)
            {
                inventory.Remove(oldStoredProduct);
                inventory.Add(newStoredProduct);
            }
        }

        public List<StoredProduct> GetStoredProducts()
        {
            return inventory.ToList();
        }

        public void PrintStoredProducts()
        {
            for (int i = 0; i < inventory.Count(); i++)
            {
                inventory[i].PrintStoredProductInfo();
            }
        }
    }
}
