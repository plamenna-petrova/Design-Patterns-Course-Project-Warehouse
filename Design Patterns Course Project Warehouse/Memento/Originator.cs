using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns_Course_Project_Warehouse.Memento
{
    public class Originator
    {
        public string state;

        public string State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                Console.WriteLine("State = " + state);
            }
        }

        public WarehouseMemento CreateWarehouseMemento()
        {
            return (new WarehouseMemento(state));
        }

        public void SetWarehouseMemento(WarehouseMemento warehouseMemento)
        {
            Console.WriteLine("Restoring state");
            State = warehouseMemento.State;
        }
    }
}
