using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Warehousesystem
{
    public delegate void LowStockHandler(string pharmacyName, string medicineName, int quantity);
    public delegate void OutOfStockHandler(string medicineName, string pharmacyName);

    public class Warehouse
    {
        public event LowStockHandler LowStockWarning;
        public event OutOfStockHandler OutOfStockWarning;

        private List<Medicine> medicines = new List<Medicine>();
        private List<Order> orders = new List<Order>();

        public void AddMedicine(Medicine med)
        {
            medicines.Add(med);
        }

        public void AddOrder(Order order)
        {
            foreach (OrderItem item in order.Items)
            {
                if (item.Medicine.Quantity == 0 || item.Quantity > item.Medicine.Quantity)
                {
                    OutOfStockWarning?.Invoke(
                        item.Medicine.Name,
                        order.Pharmacy.PharmacyName
                    );
                    return;
                }

                item.Medicine.RemoveStock(item.Quantity);

                if (item.Medicine.Quantity < 10 && item.Medicine.Quantity > 0)
                {
                    LowStockWarning?.Invoke(
                        order.Pharmacy.PharmacyName,
                        item.Medicine.Name,
                        item.Medicine.Quantity
                    );
                }

                if (item.Medicine.Quantity == 0)
                {
                    OutOfStockWarning?.Invoke(
                        item.Medicine.Name,
                        order.Pharmacy.PharmacyName
                    );
                }
            }

            orders.Add(order);
            Console.WriteLine($"Order of Pharmacy ({order.Pharmacy.PharmacyName}) saved successfully.");
        }

        public void ShowOrders()
        {
            foreach (Order order in orders)
            {
                Console.WriteLine($"\nPharmacy: {order.Pharmacy.PharmacyName}");
                foreach (OrderItem item in order.Items)
                {
                    Console.WriteLine($"{item.Medicine.Name} x {item.Quantity} = {item.TotalPrice}");
                }
                Console.WriteLine($"Total = {order.TotalAmount}");
            }
        }

        public void ShowAllMedicines()
        {
            foreach (Medicine med in medicines)
            {
                Console.WriteLine(med.GetInfo());
            }
        }
    }
}
