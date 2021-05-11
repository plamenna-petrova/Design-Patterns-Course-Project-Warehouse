using Design_Patterns_Course_Project_Warehouse.Adapter;
using Design_Patterns_Course_Project_Warehouse.Command;
using Design_Patterns_Course_Project_Warehouse.Command.ConcreteCommands;
using Design_Patterns_Course_Project_Warehouse.Command.WarehouseRepository;
using Design_Patterns_Course_Project_Warehouse.Factory.Creators;
using Design_Patterns_Course_Project_Warehouse.Factory.Models;
using Design_Patterns_Course_Project_Warehouse.Helpers;
using Design_Patterns_Course_Project_Warehouse.Memento;
using System;
using System.Collections.Generic;

namespace Design_Patterns_Course_Project_Warehouse
{
    class Program
    { 
        public static void Main(string[] args)
        {
            // Factory
            IStoredProductCreator storedProductCreator = new GamingPeripheralsCreator();
            var logitechMouse = storedProductCreator.CreateStoredProduct();
            logitechMouse.Description = "A highly innovative mouse with 16 000 DPI";

            // Command
            var warehouse = new Warehouse();
            var warehouseInvoker = new WarehouseInvoker();
            CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(warehouse, WarehouseAction.Add, logitechMouse));
            CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(warehouse, WarehouseAction.Increase, logitechMouse, 10));
            CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(warehouse, WarehouseAction.Increase, logitechMouse, 5));
            CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(warehouse, WarehouseAction.Decrease, logitechMouse, 7));

            storedProductCreator = new ClothingMerchCreator();
            var borderlandsTShirt = storedProductCreator.CreateStoredProduct();
            borderlandsTShirt.Description = "A T-Shirt featuring the Claptrap robot";
            CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(warehouse, WarehouseAction.Add, borderlandsTShirt));

            storedProductCreator = new BoardGameCreator();
            var monopolyClassic = storedProductCreator.CreateStoredProduct();
            monopolyClassic.Description = "The Classic Monopoly game";
            CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(warehouse, WarehouseAction.Add, monopolyClassic));

            CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(warehouse, WarehouseAction.Print));

            storedProductCreator = new BoardGameCreator();
            var monopolyClassicAnniversaryEdition = storedProductCreator.CreateStoredProduct();
            monopolyClassicAnniversaryEdition.Description = "The Classic Monopoly with New Design for the Anniversary";
            CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(warehouse, WarehouseAction.Edit, monopolyClassic, monopolyClassicAnniversaryEdition));

            CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(warehouse, WarehouseAction.Print));

            storedProductCreator = new GamingPeripheralsCreator();
            var aulaKeyboard = storedProductCreator.CreateStoredProduct();
            aulaKeyboard.Description = "Aula Assault Keyboard";
            CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(warehouse, WarehouseAction.Add, aulaKeyboard));
            CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(warehouse, WarehouseAction.Print));
            CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(warehouse, WarehouseAction.Remove, aulaKeyboard));
            Console.WriteLine("Printing without the last removed object");
            CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(warehouse, WarehouseAction.Print));

            warehouseInvoker.UndoActions();
            CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(warehouse, WarehouseAction.Print));

            storedProductCreator = new ClothingMerchCreator();
            var dakineBackpack = storedProductCreator.CreateStoredProduct();
            dakineBackpack.Description = "Patterned Dakine Backpack";
            CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(warehouse, WarehouseAction.Add, dakineBackpack));

            storedProductCreator = new GamingPeripheralsCreator();
            var logitechHeadphones = storedProductCreator.CreateStoredProduct();
            logitechHeadphones.Description = "Logitech Headphones Newest Model, Blue, Fragile";
            CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(warehouse, WarehouseAction.Add, logitechHeadphones));

            storedProductCreator = new BoardGameCreator();
            var scrabble = storedProductCreator.CreateStoredProduct();
            scrabble.Description = "The Classic Game Scrabble";
            CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(warehouse, WarehouseAction.Add, scrabble));

            storedProductCreator = new GamingPeripheralsCreator();
            var steeringWheel = storedProductCreator.CreateStoredProduct();
            steeringWheel.Description = "Convenient Steering Wheel";
            CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(warehouse, WarehouseAction.Add, steeringWheel));

            // Adapter - Loading the truck for delivery
            IDelivery delivery = new Delivery();
            IWarehouse deliveryAdapter = new DeliveryAdapter(delivery);
            var warehouseInvokerForAdapter = new WarehouseInvoker();
            CommandHelper.ExecuteCommand(warehouseInvokerForAdapter, new WarehouseCommand(deliveryAdapter, WarehouseAction.Add, dakineBackpack));
            CommandHelper.ExecuteCommand(warehouseInvokerForAdapter, new WarehouseCommand(deliveryAdapter, WarehouseAction.Add, logitechHeadphones));
            CommandHelper.ExecuteCommand(warehouseInvokerForAdapter, new WarehouseCommand(deliveryAdapter, WarehouseAction.Add, scrabble));
            foreach (var warehouseItem in warehouse.GetStoredProducts())
            {
                if (deliveryAdapter.GetStoredProducts().Contains(warehouseItem))
                {
                    CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(warehouse, WarehouseAction.Remove, warehouseItem));
                }
            }
            Console.WriteLine("Printing warehouse products to test");
            CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(warehouse, WarehouseAction.Print));
            Console.WriteLine("Delivery information");
            CommandHelper.ExecuteCommand(warehouseInvokerForAdapter, new WarehouseCommand(deliveryAdapter, WarehouseAction.Print));

            // Memento
            Originator originator = new Originator();
            Console.WriteLine("Memento: ");
            Console.WriteLine("Printing initial state : ");
            originator.State = "Non-Fragile";
            Caretaker caretaker = new Caretaker();
            caretaker.WarehouseMemento = originator.CreateWarehouseMemento();
            string stateToFind = "fragile";
            List<StoredProduct> fragileProducts = new List<StoredProduct>();
            foreach (var deliveryItem in deliveryAdapter.GetStoredProducts())
            {
                if (deliveryItem.Description.ToLower().Contains(stateToFind)) {
                    originator.State = "Fragile";
                    Console.WriteLine("Increasing price for the delivery of a fragile product");
                    CommandHelper.ExecuteCommand(warehouseInvokerForAdapter, new WarehouseCommand(deliveryAdapter, WarehouseAction.Increase, deliveryItem, 10));
                    fragileProducts.Add(deliveryItem);
                } 
                else
                {
                    originator.SetWarehouseMemento(caretaker.WarehouseMemento);
                }
            }
            CommandHelper.ExecuteCommand(warehouseInvoker, new WarehouseCommand(deliveryAdapter, WarehouseAction.Print));
            Console.WriteLine("Printing fragile items");
            foreach (var fragileItem in fragileProducts)
            {
                Console.WriteLine(fragileItem.Name);
            }
        }     
    }
}
