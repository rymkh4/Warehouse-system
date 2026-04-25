using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Warehousesystem
{
    public class Tablet : Medicine
    {
        public Tablet(string code, string name, int quantity, double price)
            : base(code, name, quantity, price)
        {
        }

        public override string GetInfo()
        {
            return $"Tablet -> Code: {Code}, Name: {Name}, Qty: {Quantity}, Price: {Price}";
        }
    }
}
