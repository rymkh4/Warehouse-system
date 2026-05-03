using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Warehousesystem
{
    // Represents a syrup-form medicine stored in the warehouse.
    // Inherits all stock management functionality from "Medicine"

    public class Syrup : Medicine
    {
        // Initializes a new Syrup with the given details.
        // Passes all parameters up to the "Medicine" base constructor.
        // "code" Unique identifier code (e.g. "S001") 
        // name" Name of the syrup medicine (e.g. "Cough Syrup") 
        // "quantity" Initial stock quantity (number of bottles) 
        // "price" Unit price per bottle
        public Syrup(string code, string name, int quantity, double price)
            : base(code, name, quantity, price)
        {
        }


        // Returns a formatted string identifying this item as a Syrup,
        // along with its code, name, current stock, and price.
        public override string GetInfo()
        {
            return $"Syrup -> Code: {Code}, Name: {Name}, Qty: {Quantity}, Price: {Price}";
        }
    }
}
