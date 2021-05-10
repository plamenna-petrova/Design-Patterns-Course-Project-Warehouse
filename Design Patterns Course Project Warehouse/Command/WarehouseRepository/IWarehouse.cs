using Design_Patterns_Course_Project_Warehouse.Factory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns_Course_Project_Warehouse.Command.WarehouseRepository
{
    public interface IWarehouse
    {
        List<StoredProduct> GetStoredProducts();
        void AddStoredProduct(StoredProduct storedProduct);
        StoredProduct FindStoredProduct(string barcode);
        void EditStoredProduct(StoredProduct oldStoredProduct, StoredProduct newStoredProduct);
        void RemoveStoredProduct(StoredProduct storedProduct);
        void PrintStoredProducts();
        void IncreasePrice(StoredProduct storedProduct, int amount);
        bool DecreasePrice(StoredProduct storedProduct, int amount);
    }
}
