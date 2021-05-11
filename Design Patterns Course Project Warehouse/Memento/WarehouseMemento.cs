using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns_Course_Project_Warehouse.Memento
{
    public class WarehouseMemento
    {
        public string state;

        public WarehouseMemento(string state)
        {
            this.state = state;
        }

        public string State
        {
            get
            {
                return state;
            }
        }
    }
}
