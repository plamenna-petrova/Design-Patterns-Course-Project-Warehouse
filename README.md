# Design Patterns Course Project Warehouse
Warehouse Console App, featuring the three gof design patterns types - creational, structural and behavioral 

## Idea and implementation

The project simulates a warehouse, where new products can be added, edited and removed from. Moreover, the price of every single item can be increased or decreased, when necessary.
Thanks to the implementation of the Factory design pattern new Stored Product objects can be created. The products are arranged into categories, representing the Concrete Product classes and
inheriting an abstract Product class. There are also separate Concrete Creators, implementing the Creator interface and returning new objects from the Concrete Product types. The role of the 
Command Receiver is assigned to the IWarehouse interface for the demonstration of dependency injection later on. This interface declares not only CRUD operations methods for the list of products in
the warehouse, but also such, influencing the Price, printing the most important information for each product on the console or simply to listing all products, stored in the warehouse.
The Command interface ICommand defines two methods for future invocation - one for executing a single IWarehouse method by switching an enum action and other for hard-deleting all products
in the warehouse list, undoing the commands in reverse order. Next, the third embedded pattern - Adapter is used to differentiate between the warehouse inventory as a whole and those products
which need to be delivered and thus have to be removed from the collection. The Target is the IWarehouse interface, the IDelivery makes for the Adaptee. The latter includes methods sharing
the same feautures and functionality as the IWarehouse methods, which in turn, implemented in the Adapter class, contain the execution of the Adaptee methods in their body with the passing of IWarehouse methods parameters
as arguments to the Adaptee methods. Last but not least, the Memento pattern plays the role of setting a non-fragile or fragile state of the products. The decision, which state to be allocated, is made
by searching the substring "fragile" in the products descriptions. Then, each fragile product has it's price increased by 10. 

## How to configure the project

All you need is a recent version of Visual Studio up and running and the matching .NET and C# components installed.

## The project

The Warehouse console app is developed in the Visual Studio 2019 IDE and is written in C#. 

## Project Structure by Patterns

The project is divided into folders that point a concrete design pattern. In the default Program class the application is demonstated by mixing up the four pattern so that the simulation
of the warehouse would function properly.

## Adapter
  - Delivery - class that implements the Adaptee interface
  - DeliveryAdapter - the Adapter class
  - IDelivery - the Adaptee interface
  - IWarehouse - the Target interface
  - Program - the Client class
## Command
  - IWarehouse - the Receiver interface
  - Warehouse - class that implements the Receiver interface
  - IWarehouseCommand - the Command interface
  - WarehouseCommand - the ConcreteCommand class
  - WarehouseAction - enum helper
  - WarehouseInvoker - the Invoker class
  - Program - the Client class
## Factory
 - Product - the StoredProduct abstract class
 - ConcreteProduct classes that inherit the Product class
   - BoardGame
   - ClothingMerch
   - GamingPeripherals
- Creator - IStoredProductCreator interface
- ConcreteCreator classes that implement the Creator interface
  - BoardGameCreator
  - ClothingMerchCreator
  - GamingPeripheralsCreator
## Memento
 - Memento - WarehouseMemento
 - Originator - class with the same name
 - Caretaker - class with the same name
## Documentation

The documentation file is named "1909011132 Шаблони за софтуерен дизайн документация"
