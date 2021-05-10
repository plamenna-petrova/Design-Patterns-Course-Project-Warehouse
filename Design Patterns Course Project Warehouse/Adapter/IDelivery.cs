using Design_Patterns_Course_Project_Warehouse.Factory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns_Course_Project_Warehouse.Adapter
{
    public interface IDelivery
    {
        List<StoredProduct> CheckProductsBeforeLoading();
        void LoadTruck(StoredProduct productToDeliver);
        StoredProduct LocateProductToDeliver(string barcode);
        void ReplaceProductBeforeLoading(StoredProduct oldProductToDeliver, StoredProduct newProductToDeliver);
        void RemoveFromTruck(StoredProduct productToDeliver);
        void PrintLoadedProducts();
        void IncreaseDeliveryPrice(StoredProduct productToDeliver, int amount);
        bool DecreaseDeliveryPrice(StoredProduct productToDeliver, int amount);
    }
}
