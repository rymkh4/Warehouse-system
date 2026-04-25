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
            Warehouse warehouse = new Warehouse();
            warehouse.LowStockWarning += ShowWarning; // subscribe in event low stock
            warehouse.OutOfStockWarning += ShowOutOfStock; // // subscribe in event out of stock

            Medicine med1 = new Tablet("T001", "Paracetamol", 50, 2.5);
            Medicine med2 = new Syrup("S001", "Cough Syrup", 20, 5);
            Medicine med3 = new Injection("I001", "Vitamin B12", 10, 8);

            warehouse.AddMedicine(med1);
            warehouse.AddMedicine(med2);
            warehouse.AddMedicine(med3);

            Console.WriteLine("============================");
            Console.WriteLine("\nCurrent Medicines:");
            warehouse.ShowAllMedicines();

            Pharmacy pharmacy = new Pharmacy("AlShifa Pharmacy");

            Order order = new Order(pharmacy);
            order.AddItem(new OrderItem(med1, 5));
            order.AddItem(new OrderItem(med2, 2));

            Console.WriteLine("============================");
            Console.WriteLine("\nCurrent Orders After Order1:");
            warehouse.AddOrder(order);
            warehouse.ShowOrders();

            // 
            Pharmacy pharmacy2 = new Pharmacy("Health Pharmacy");

            Order order2 = new Order(pharmacy2);
            order2.AddItem(new OrderItem(med1, 35));
            order2.AddItem(new OrderItem(med3, 10));

            Console.WriteLine("============================");
            Console.WriteLine("\nCurrent Orders After Order2:");
            warehouse.AddOrder(order2);
            warehouse.ShowOrders();
            Console.WriteLine("============================");
            // 
            Pharmacy pharmacy3 = new Pharmacy("Mousqe Pharmacy");

            Order order3 = new Order(pharmacy3);
            order3.AddItem(new OrderItem(med1, 2));
            order3.AddItem(new OrderItem(med2, 1));

            Console.WriteLine("\nCurrent Orders After Order3:");
            warehouse.AddOrder(order3);
            warehouse.ShowOrders();
            Console.WriteLine("============================");
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("Warehouse Status: ");
            Console.WriteLine("============================");
            Console.WriteLine("\nCurrent Orders:");
            warehouse.ShowOrders();
            Console.WriteLine("============================");
            Console.WriteLine("\nCurrent Medicines:");
            warehouse.ShowAllMedicines();

            Console.ReadLine();
        }
        static void ShowWarning(string pharmacyName, string medicineName, int quantity)
        {
            Console.ForegroundColor = ConsoleColor.Red; // print warning in red
            Console.WriteLine(
                $"Warning: After order from {pharmacyName}, stock of {medicineName} became low ({quantity})"
            );
            Console.ResetColor();
        }
        static void ShowOutOfStock(string medicineName, string pharmacyName)
        {
            Console.ForegroundColor = ConsoleColor.Red; // print warning in red
            Console.WriteLine($"Sorry: The {medicineName} is out of stock - Requested by {pharmacyName}");
                        Console.ResetColor();
        }
    }
}
