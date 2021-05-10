using Design_Patterns_Course_Project_Warehouse.Command.WarehouseRepository;
using Design_Patterns_Course_Project_Warehouse.Factory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns_Course_Project_Warehouse.Command.ConcreteCommands
{
    public class WarehouseCommand : IWarehouseCommand
    {
        private readonly IWarehouse warehouse;
        private readonly WarehouseAction warehouseAction;
        private readonly StoredProduct storedProduct;
        private readonly StoredProduct oldStoredProduct;
        private readonly StoredProduct newStoredProduct;
        private readonly int amount;

        public bool IsCommandExecuted { get; private set; }

        // Constructor overloading

        // For Print command
        public WarehouseCommand(IWarehouse warehouse, WarehouseAction warehouseAction)
        {
            this.warehouse = warehouse;
            this.warehouseAction = warehouseAction;
        }

        // For Add and Remove commands
        public WarehouseCommand(IWarehouse warehouse, WarehouseAction warehouseAction, StoredProduct storedProduct)
            : this(warehouse, warehouseAction)
        {
            this.storedProduct = storedProduct;
        }

        // For Edit Command
        public WarehouseCommand(IWarehouse warehouse, WarehouseAction warehouseAction, StoredProduct oldStoredProduct, StoredProduct newStoredProduct)
            : this (warehouse, warehouseAction)
        {
            this.oldStoredProduct = oldStoredProduct;
            this.newStoredProduct = newStoredProduct;
        }

        // For Increase and Decrease Commands
        public WarehouseCommand(IWarehouse warehouse, WarehouseAction warehouseAction, StoredProduct storedProduct, int amount)
            : this (warehouse, warehouseAction)
        {
            this.storedProduct = storedProduct;
            this.amount = amount;
        }
        
        public void ExecuteAction()
        {
            switch (warehouseAction)
            {
                case WarehouseAction.Add:
                    warehouse.AddStoredProduct(storedProduct);
                    IsCommandExecuted = true;
                    break;
                case WarehouseAction.Remove:
                    warehouse.RemoveStoredProduct(storedProduct);
                    IsCommandExecuted = true;
                    break;
                case WarehouseAction.Edit:
                    warehouse.EditStoredProduct(oldStoredProduct, newStoredProduct);
                    IsCommandExecuted = true;
                    break;
                case WarehouseAction.Print:
                    warehouse.PrintStoredProducts();
                    IsCommandExecuted = true;
                    break;
                case WarehouseAction.Increase:
                    warehouse.IncreasePrice(storedProduct, amount);
                    IsCommandExecuted = true;
                    break;
                case WarehouseAction.Decrease:
                    IsCommandExecuted = warehouse.DecreasePrice(storedProduct, amount);
                    break;
            }
        }

        public void UndoAction()
        {
            if (!IsCommandExecuted)
                return;

            if (warehouseAction == WarehouseAction.Add)
            {
                Console.WriteLine($"Removing {storedProduct.Name}");
                warehouse.RemoveStoredProduct(storedProduct);
            }
            else if (warehouseAction == WarehouseAction.Remove)
            {
                Console.WriteLine($"Adding {storedProduct.Name}");
                warehouse.AddStoredProduct(storedProduct);
            }
            else if (warehouseAction == WarehouseAction.Edit)
            {
                Console.WriteLine("Undo edit");
                Console.WriteLine($"Removing {newStoredProduct.Name}");
                warehouse.RemoveStoredProduct(newStoredProduct);
                Console.WriteLine($"Adding {oldStoredProduct.Name}");
                warehouse.AddStoredProduct(oldStoredProduct);
            }
            else if (warehouseAction == WarehouseAction.Increase)
            {
                warehouse.DecreasePrice(storedProduct, amount);
            }
            else
            {
                warehouse.IncreasePrice(storedProduct, amount);
            }
        }
    }
}
