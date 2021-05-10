using Design_Patterns_Course_Project_Warehouse.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Patterns_Course_Project_Warehouse.Helpers
{
    public class CommandHelper
    {
        public static void ExecuteCommand(WarehouseInvoker warehouseInvoker, IWarehouseCommand warehouseCommand)
        {
            warehouseInvoker.SetCommand(warehouseCommand);
            warehouseInvoker.Invoke();
        }
    }
}
