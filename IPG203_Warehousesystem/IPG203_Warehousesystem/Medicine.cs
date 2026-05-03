using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Warehousesystem
{

    // Abstract base class representing a medicine stored in the warehouse.
    // Implements "IStorable" to enforce stock management operations.
    // Concrete subclasses (Tablet, Syrup, Injection) must implement "GetInfo()".
    public abstract class Medicine : IStorable
    {
        // Backing fields for medicine properties
        private string code;
        private string name;
        private int quantity;
        private double price;

        // Gets the unique code identifying this medicine (e.g. "T001")
        public string Code
        {
            get { return code; }
        }

        // Gets the display name of the medicine (e.g. "Paracetamol")
        public string Name
        {
            get { return name; }
        }

        // Gets or sets the current stock quantity.
        // The setter is protected so only this class and its subclasses can modify quantity directly.
        // External callers must go through "AddStock" or "RemoveStock"

        public int Quantity
        {
            get { return quantity; }
            protected set { quantity = value; }
        }

        // Gets the unit price of this medicine
        public double Price
        {
            get { return price; }
        }
        // Initializes a new medicine with the given details.
        // Also increments the global "InventoryCounter.TotalMedicines" counter.
        // 
        // "code" is Unique identifier code for the medicine.
        // "name" is Human-readable name of the medicine.
        // "quantity" is Initial stock quantity.
        // is Unit price of the medicine.
        public Medicine(string code, string name, int quantity, double price)
        {
            this.code = code;
            this.name = name;
            this.quantity = quantity;
            this.price = price;

            // Increment the global medicine counter every time a new medicine is created
            InventoryCounter.TotalMedicines++;
        }

        // Increases the stock quantity by the given amount.
        // The quantity is only added if it passes the "Validator.IsValidQuantity" check (must be > 0).
        // 
        // quantity" is The number of units to add to stock.
        public void AddStock(int quantity)
        {
            if (Validator.IsValidQuantity(quantity))
                Quantity += quantity;
        }


        // Decreases the stock quantity by the given amount.
        // The quantity is only removed if it is valid (> 0) and does not exceed the current stock.
        // "quantity" The number of units to remove from stock.
        public void RemoveStock(int quantity)
        {
            if (Validator.IsValidQuantity(quantity) && quantity <= Quantity)
                Quantity -= quantity;
        }


        // Returns a formatted string describing this medicine (type, code, name, quantity, price).
        // Must be implemented by each concrete subclass.

        public abstract string GetInfo();
    }
}
