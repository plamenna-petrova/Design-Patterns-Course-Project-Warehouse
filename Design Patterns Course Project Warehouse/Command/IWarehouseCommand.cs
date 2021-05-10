using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns_Course_Project_Warehouse.Command
{
    public interface IWarehouseCommand
    {
        void ExecuteAction();
        void UndoAction();
    }
}
