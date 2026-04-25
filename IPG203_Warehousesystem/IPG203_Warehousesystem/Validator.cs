using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Warehousesystem
{
    public static class Validator
    {
        public static bool IsValidQuantity(int quantity)
        {
            return quantity > 0;
        }
    }
}
