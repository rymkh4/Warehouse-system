using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Warehousesystem
{
    public class Injection : Medicine
    {
        // Initializes a new Injection with the given details.
        // Passes all parameters up to the Medicine base constructor.
        public Injection(string code, string name, int quantity, double price)
            : base(code, name, quantity, price)
        {
        }

        // Returns a formatted string identifying this item as an Injection,
        // along with its code, name, current stock, and price.
        public override string GetInfo()
        {
            return $"Injection -> Code: {Code}, Name: {Name}, Qty: {Quantity}, Price: {Price}";
        }
    }
}
