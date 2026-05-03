using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Warehousesystem
{

    // Represents a purchase order placed by a pharmacy.
    // An order contains one or more "OrderItem" entries and belongs to a single "Pharmacy".

    public class Order
    {
        private Pharmacy _pharmacy;
        private List<OrderItem> _items;

        // Gets or sets the pharmacy that placed this order.
        public Pharmacy Pharmacy
        {
            get { return _pharmacy; }
            set { _pharmacy = value; }
        }

        // Gets or sets the list of items included in this order.
        public List<OrderItem> Items
        {
            get { return _items; }
            set { _items = value; }
        }


        // Calculates and returns the total monetary amount for this order
        // by summing the "OrderItem.TotalPrice" of all items.
        public double TotalAmount
        {
            get
            {
                double total = 0;
                foreach (OrderItem item in Items)
                {
                    total += item.TotalPrice; // Accumulate price for each line item
                }
                return total;
            }
        }


        // Initializes a new order for the specified pharmacy with an empty items list.
        // "pharmacy" is The pharmacy placing this order.
        public Order(Pharmacy pharmacy)
        {
            Pharmacy = pharmacy;
            Items = new List<OrderItem>(); // Start with no items; use AddItem to populate
        }


        // Adds an item (medicine + quantity) to this order.
        // "item" is The order item to add.
        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
    }
}
