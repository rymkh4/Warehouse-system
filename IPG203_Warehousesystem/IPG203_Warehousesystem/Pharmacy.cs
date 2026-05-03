using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPG203_Warehousesystem
{
    // Represents a pharmacy that places orders at the warehouse.
    // Used to identify who submitted an order and to include the pharmacy's name in event messages.

    public class Pharmacy
    {
        private string _pharmacyName;
        private string _phoneNumber;
        // Gets or sets the display name of this pharmacy.
        public string PharmacyName
        {
            get { return _pharmacyName; }
            set { _pharmacyName = value; }
        }

        // Gets or sets the display phone number of this pharmacy.
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }
        // Initializes a new Pharmacy with the given name and given number.
        // "name" is The name of the pharmacy (e.g. "AlShifa Pharmacy").
        public Pharmacy(string name, string phone)
        {
            PharmacyName = name;
            PhoneNumber = phone;
        }
    }
}
