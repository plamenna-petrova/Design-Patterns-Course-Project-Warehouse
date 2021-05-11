using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns_Course_Project_Warehouse.Memento
{
    public class Caretaker
    {
        public WarehouseMemento warehouseMemento;

        public WarehouseMemento WarehouseMemento
        {
            get
            {
                return warehouseMemento;
            }
            set
            {
                warehouseMemento = value;
            }
        }
    }
}
