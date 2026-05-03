using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Warehousesystem
{

    // Represents a tablet-form medicine stored in the warehouse.
    // Inherits all stock management functionality from <see cref="Medicine"/>.
    public class Tablet : Medicine
    {

        // Initializes a new Tablet with the given details.
        // Passes all parameters up to the "Medicine" base constructor.

        // "code" Unique identifier code (e.g. "T001").
        // "name" Name of the tablet medicine (e.g. "Paracetamol").
        // "quantity" Initial stock quantity.
        // "price" Unit price per tablet pack.
        public Tablet(string code, string name, int quantity, double price)
            : base(code, name, quantity, price)
        {
        }


        // Returns a formatted string identifying this item as a Tablet,
        // along with its code, name, current stock, and price.
        public override string GetInfo()
        {
            return $"Tablet -> Code: {Code}, Name: {Name}, Qty: {Quantity}, Price: {Price}";
        }
    }
}
