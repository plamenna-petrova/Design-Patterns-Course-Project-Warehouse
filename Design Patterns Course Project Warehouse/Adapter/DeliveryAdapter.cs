using Design_Patterns_Course_Project_Warehouse.Command.WarehouseRepository;
using Design_Patterns_Course_Project_Warehouse.Factory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns_Course_Project_Warehouse.Adapter
{
    public class DeliveryAdapter : IWarehouse
    {
        private IDelivery delivery;

        public DeliveryAdapter(IDelivery delivery)
        {
            this.delivery = delivery;
        }

        public void IncreasePrice(StoredProduct productToDeliver, int amount)
        {
            delivery.IncreaseDeliveryPrice(productToDeliver, amount);
        }

        public bool DecreasePrice(StoredProduct productToDeliver, int amount)
        {
            return delivery.DecreaseDeliveryPrice(productToDeliver, amount);
        }

        public void AddStoredProduct(StoredProduct productToDeliver)
        {
            delivery.LoadTruck(productToDeliver);
        }

        public StoredProduct FindStoredProduct(string barcode)
        {
            return delivery.LocateProductToDeliver(barcode);
        }

        public void EditStoredProduct(StoredProduct oldProductToDeliver, StoredProduct newProductToDeliver)
        {
            delivery.ReplaceProductBeforeLoading(oldProductToDeliver, newProductToDeliver);
        }

        public List<StoredProduct> GetStoredProducts()
        {
            return delivery.CheckProductsBeforeLoading();
        }

        public void RemoveStoredProduct(StoredProduct productToDeliver)
        {
            delivery.RemoveFromTruck(productToDeliver);
        }

        public void PrintStoredProducts()
        {
            delivery.PrintLoadedProducts();
        }
    }
}
