using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Warehousesystem
{
    // Delegate for the low stock warning event.
    // Triggered when a medicine's remaining quantity falls below the low-stock threshold.

    // "pharmacyName" The pharmacy whose order caused the stock to drop.
    // "medicineName" The medicine that is running low.
    // "quantity" The remaining quantity after the order
    public delegate void LowStockHandler(string pharmacyName, string medicineName, int quantity);


    // Delegate for the out-of-stock warning event.
    // Triggered when a medicine has zero stock or a requested quantity exceeds what is available.

    // "medicineName" The medicine that is out of stock.
    // "pharmacyName" The pharmacy that requested the medicine. 
    public delegate void OutOfStockHandler(string medicineName, string pharmacyName);

    // Represents the central warehouse that stores medicines and processes pharmacy orders.
    // Raises events when stock levels become critically low or reach zero.
    public class Warehouse
    {
        // Event fired when a medicine's quantity drops below 10 (but is still above 0)
        public event LowStockHandler LowStockWarning;

        // Event fired when a medicine is completely out of stock or cannot fulfill the requested quantity
        public event OutOfStockHandler OutOfStockWarning;

        // Internal list of all medicines stored in the warehouse
        private List<Medicine> medicines = new List<Medicine>();

        // Internal list of all successfully processed orders
        private List<Order> orders = new List<Order>();

        // Adds a medicine to the warehouse inventory.
        // "med" is The medicine object to add.
        public void AddMedicine(Medicine med)
        {
            medicines.Add(med);
        }

        //AddOrder
        // Processes a pharmacy order by deducting stock for each ordered item.
        // If any item is out of stock or the requested quantity exceeds available stock,
        // the entire order is rejected and an out-of-stock event is raised.
        // After deducting stock, raises a low-stock event if quantity drops below 10,
        // or an out-of-stock event if it reaches exactly 0.
        // "order" is The order to process, containing pharmacy info and ordered items.
        public void AddOrder(Order order)
        {
            foreach (OrderItem item in order.Items)
            {
                // Reject the order if the medicine is already out of stock
                // or if the requested quantity is more than what is available
                if (item.Medicine.Quantity == 0 || item.Quantity > item.Medicine.Quantity)
                {
                    OutOfStockWarning?.Invoke(
                        item.Medicine.Name,
                        order.Pharmacy.PharmacyName
                    );
                    return; // Stop processing this order entirely
                }

                // Deduct the ordered quantity from the medicine's stock
                item.Medicine.RemoveStock(item.Quantity);

                // Raise a low-stock warning if remaining quantity is between 1 and 9 (inclusive)
                if (item.Medicine.Quantity < 10 && item.Medicine.Quantity > 0)
                {
                    LowStockWarning?.Invoke(
                        order.Pharmacy.PharmacyName,
                        item.Medicine.Name,
                        item.Medicine.Quantity
                    );
                }

                // Raise an out-of-stock warning if the medicine is now completely depleted
                if (item.Medicine.Quantity == 0)
                {
                    OutOfStockWarning?.Invoke(
                        item.Medicine.Name,
                        order.Pharmacy.PharmacyName
                    );
                }
            }

            // All items were fulfilled successfully; save the order
            orders.Add(order);
            Console.WriteLine($"Order of Pharmacy ({order.Pharmacy.PharmacyName}) saved successfully.");
        }

        // Show Orders()
        // Displays all processed orders in the console, showing the pharmacy name,
        // each ordered item with its quantity and line total, and the order's grand total.
        public void ShowOrders()
        {
            foreach (Order order in orders)
            {
                Console.WriteLine($"\nPharmacy: {order.Pharmacy.PharmacyName}");
                foreach (OrderItem item in order.Items)
                {
                    // Display: medicine name x quantity = total price for that line
                    Console.WriteLine($"{item.Medicine.Name} x {item.Quantity} = {item.TotalPrice}");
                }
                // Display the grand total for the order
                Console.WriteLine($"Total = {order.TotalAmount}");
            }
        }

        //ShowAllMedicines()
        // Displays all medicines currently in the warehouse inventory,
        // including their type, code, name, quantity, and price.
        public void ShowAllMedicines()
        {
            foreach (Medicine med in medicines)
            {
                Console.WriteLine(med.GetInfo());
            }
        }
    }
}
