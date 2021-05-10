using Design_Patterns_Course_Project_Warehouse.Factory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Design_Patterns_Course_Project_Warehouse.Adapter
{
    // Adaptee class
    public class Delivery : IDelivery
    {
        private List<StoredProduct> productsToDeliver;

        public Delivery()
        {
            productsToDeliver = new List<StoredProduct>();
        }

        public void IncreaseDeliveryPrice(StoredProduct productToDeliver, int amount)
        {
            if (productToDeliver != null)
            {
                productToDeliver.Price += amount;
                Console.WriteLine($"The price for the product that will be delivered {productToDeliver.Name} has been increased by {amount}");
            }
        }

        public bool DecreaseDeliveryPrice(StoredProduct productToDeliver, int amount)
        {
            if (amount < productToDeliver.Price)
            {
                productToDeliver.Price -= amount;
                Console.WriteLine($"The price for the stored product {productToDeliver.Name} has been decreased by {amount}");
            }
            return false;
        }

        public void LoadTruck(StoredProduct productToDeliver)
        {
            if (productsToDeliver != null)
            {
                productsToDeliver.Add(productToDeliver);
            }
        }

        public StoredProduct LocateProductToDeliver(string barcode)
        {
            return productsToDeliver.Find(ptd => ptd.Barcode == barcode);
        }

        public void ReplaceProductBeforeLoading(StoredProduct oldProductToDeliver, StoredProduct newProductToDeliver)
        {
            oldProductToDeliver = LocateProductToDeliver(oldProductToDeliver.Barcode);
            if (oldProductToDeliver != null && newProductToDeliver != null)
            {
                productsToDeliver.Remove(oldProductToDeliver);
                productsToDeliver.Add(newProductToDeliver);
            }
        }

        public List<StoredProduct> CheckProductsBeforeLoading()
        {
            return productsToDeliver.ToList();
        }

        public void RemoveFromTruck(StoredProduct productToDeliver)
        {
            if (productToDeliver == LocateProductToDeliver(productToDeliver.Barcode))
            {
                productsToDeliver.Remove(productToDeliver);
            }
        }

        public void PrintLoadedProducts()
        {
            for (int i = 0; i < productsToDeliver.Count(); i++)
            {
                productsToDeliver[i].PrintStoredProductInfo();
            }
        }
    }
}
