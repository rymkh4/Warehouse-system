using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Warehousesystem
{
    // Defines the contract for any item that can be stored and managed in the warehouse.
    // All classes implementing this interface must support adding/removing stock
    // and providing a human-readable description of themselves.

    public interface IStorable
    {
        // Adds the specified number of units to the item's stock
        //  quantity is the Number of units to add. Must be greater than 0
        void AddStock(int quantity);

        // Removes the specified number of units from the item's stock
        // quantity is Number of units to remove. Must be greater than 0 and not exceed current stock
        void RemoveStock(int quantity);

        // Returns a formatted string with the item's details (type, code, name, quantity, price)
        string GetInfo();
    }
}
