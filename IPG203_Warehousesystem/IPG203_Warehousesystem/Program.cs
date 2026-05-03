using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Warehousesystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new warehouse instance to manage medicines and orders
            Warehouse warehouse = new Warehouse();

            // Subscribe to the low stock event so we get notified when stock falls below threshold
            warehouse.LowStockWarning += ShowWarning;

            // Subscribe to the out-of-stock event so we get notified when a medicine runs out
            warehouse.OutOfStockWarning += ShowOutOfStock;

            // Create sample medicines: one Tablet, one Syrup, and one Injection
            Medicine med1 = new Tablet("T001", "Paracetamol", 50, 2.5);
            Medicine med2 = new Syrup("S001", "Cough Syrup", 20, 5);
            Medicine med3 = new Injection("I001", "Vitamin B12", 10, 8);

            // Register all medicines in the warehouse inventory
            warehouse.AddMedicine(med1);
            warehouse.AddMedicine(med2);
            warehouse.AddMedicine(med3);

            Console.WriteLine("============================");
            Console.WriteLine("\nCurrent Medicines:");
            warehouse.ShowAllMedicines();

            // --- Order 1: AlShifa Pharmacy orders Paracetamol and Cough Syrup ---
            Pharmacy pharmacy = new Pharmacy("AlShifa Pharmacy", "+963 999 555 222");
            Order order = new Order(pharmacy);
            order.AddItem(new OrderItem(med1, 5));  // 5 units of Paracetamol
            order.AddItem(new OrderItem(med2, 2));  // 2 units of Cough Syrup

            Console.WriteLine("============================");
            Console.WriteLine("\nCurrent Orders After Order1:");
            warehouse.AddOrder(order);
            warehouse.ShowOrders();

            // --- Order 2: Health Pharmacy orders a large quantity; may trigger low/out-of-stock warnings ---
            Pharmacy pharmacy2 = new Pharmacy("Health Pharmacy", "+963 666 552 914");
            Order order2 = new Order(pharmacy2);
            order2.AddItem(new OrderItem(med1, 35)); // 35 units of Paracetamol
            order2.AddItem(new OrderItem(med3, 10)); // 10 units of Vitamin B12 (exactly all remaining stock)

            Console.WriteLine("============================");
            Console.WriteLine("\nCurrent Orders After Order2:");
            warehouse.AddOrder(order2);
            warehouse.ShowOrders();
            Console.WriteLine("============================");

            // --- Order 3: Mousqe Pharmacy places a small order ---
            Pharmacy pharmacy3 = new Pharmacy("Mousqe Pharmacy", "+963 888 777 333");
            Order order3 = new Order(pharmacy3);
            order3.AddItem(new OrderItem(med1, 2)); // 2 units of Paracetamol
            order3.AddItem(new OrderItem(med2, 1)); // 1 unit of Cough Syrup

            Console.WriteLine("\nCurrent Orders After Order3:");
            warehouse.AddOrder(order3);
            warehouse.ShowOrders();
            Console.WriteLine("============================");

            // --- Final warehouse status report ---
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Warehouse Status: ");
            Console.WriteLine("============================");
            Console.WriteLine("\nCurrent Orders:");
            warehouse.ShowOrders();
            Console.WriteLine("============================");
            Console.WriteLine("\nCurrent Medicines:");
            warehouse.ShowAllMedicines();

            // Wait for user input before closing the console window
            Console.ReadLine();
        }


        // Event handler called when a medicine's stock drops below the low-stock threshold (less than 10 units).
        // Prints a red warning message to the console.
        static void ShowWarning(string pharmacyName, string medicineName, int quantity)
        {
            Console.ForegroundColor = ConsoleColor.Red; // Highlight warning in red for visibility
            Console.WriteLine(
                $"Warning: After order from {pharmacyName}, stock of {medicineName} became low ({quantity})"
            );
            Console.ResetColor(); // Restore default console color
        }


        /// Event handler called when a medicine is out of stock or the requested quantity
        /// exceeds available stock.
        /// Prints a red error message to the console.
        static void ShowOutOfStock(string medicineName, string pharmacyName)
        {
            Console.ForegroundColor = ConsoleColor.Red; // Highlight error in red for visibility
            Console.WriteLine($"Sorry: The {medicineName} is out of stock - Requested by {pharmacyName}");
            Console.ResetColor(); // Restore default console color
        }
    }
}
