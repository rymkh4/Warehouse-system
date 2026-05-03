using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Warehousesystem
{

    // Represents a single line item within an "Order".
    // Links a specific "Medicine" to the quantity requested.
    public class OrderItem
    {
        private Medicine _medicine;
        private int _quantity;
        
        // Gets or sets the medicine being ordered.
        public Medicine Medicine
        {
            get { return _medicine; }
            set { _medicine = value; }
        }

        // Gets or sets the number of units requested for this medicine.
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        // Calculates the total price for this line item.
        // Computed as "Medicine.Price" multiplied by "Quantity"

        public double TotalPrice
        {
            get { return Medicine.Price * Quantity; }
        }


        // Initializes a new order item with the specified medicine and quantity.

        // "medicine" The medicine to include in the order
        // "quantity" is The number of units being ordered.
        public OrderItem(Medicine medicine, int quantity)
        {
            Medicine = medicine;
            Quantity = quantity;
        }
    }
}
