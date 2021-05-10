using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Design_Patterns_Course_Project_Warehouse.Command
{
    // Invoker
    public class WarehouseInvoker
    {
        private readonly List<IWarehouseCommand> warehouseCommands;
        private IWarehouseCommand warehouseCommand;

        public WarehouseInvoker()
        {
            warehouseCommands = new List<IWarehouseCommand>();
        }

        public void SetCommand(IWarehouseCommand command)
        {
            warehouseCommand = command;
        }

        public void Invoke()
        {
            warehouseCommands.Add(warehouseCommand);
            warehouseCommand.ExecuteAction();
        }

        public void UndoActions()
        {
            foreach (var warehouseCommand in Enumerable.Reverse(warehouseCommands))
            {
                warehouseCommand.UndoAction();
            }
        }
    }
}
