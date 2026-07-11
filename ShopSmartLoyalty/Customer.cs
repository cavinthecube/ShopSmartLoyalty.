using System;
using System.Collections.Generic;
using System.Text;

namespace ShopSmartLoyalty_
{
    public class Customer
    {
        public List<Purchase> purchaseHistory = new List<Purchase>();

        public string customerID { get; set; }
        public string name { get; set; }
        public string province { get; set; }
        public string branchCode { get; set; }
        public double points { get; set; }
        public double totalSpend { get; set; }
        public double totalPoints { get; set; }
        public string membership { get; set; }
        public DateTime RegistrationDate { get; set; }


    }
}
