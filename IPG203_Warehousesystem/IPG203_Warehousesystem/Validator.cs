using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Warehousesystem
{

    // A static utility class providing input validation methods used throughout the system.
    // Centralizing validation here ensures consistent rules are applied wherever stock quantities are checked.
    public static class Validator
    {

        // Validates that a stock quantity is acceptable for use in add or remove operations.
        // A quantity is considered valid if it is strictly greater than zero.
        // "quantity" The quantity value to validate. 
        // returns true if the quantity is positive; false if it is zero or negative. 
        public static bool IsValidQuantity(int quantity)
        {
            return quantity > 0;
        }
    }
}
