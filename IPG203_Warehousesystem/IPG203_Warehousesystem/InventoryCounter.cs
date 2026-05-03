using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Warehousesystem
{

    // A static utility class that tracks the total number of medicine types
    // that have been created across the entire application.
    // TotalMedicines is incremented by the Medicine base constructor
    // each time a new medicine instance (Tablet, Syrup, or Injection) is created.

    public static class InventoryCounter
    {

        // Gets or sets the running total of medicine instances created since the application started.
        // Initialized to 0 and incremented by the Medicine constructor.
        private static int _totalMedicines = 0;

        // Property
        public static int TotalMedicines
        {
            get { return _totalMedicines; }
            set { _totalMedicines = value; }
        }
    }
}
