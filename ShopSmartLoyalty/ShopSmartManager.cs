using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Linq;

namespace ShopSmartLoyalty_
{
    public class ShopSmartManager
    {
        public List<Purchase> purchaseHistory = new List<Purchase>();
        Dictionary<string, Customer> customers = new Dictionary<string, Customer>();

        public void registerCustomer()
        {
            Console.WriteLine("");
            Customer customer = new Customer();

            Console.WriteLine("Enter Customer ID: ");
            customer.customerID = Console.ReadLine();

            if (customers.ContainsKey(customer.customerID))
            {
                Console.WriteLine("Customer ID already exists.");
                
            } 
            else if (customer.customerID == "")
            {
                Console.WriteLine("Input cannot be blank! ");
                Console.WriteLine("");
            } 
            else
            {
                
                Console.WriteLine("Enter Customer Name: ");
                customer.name = Console.ReadLine();

                if (customer.name == "")
                {
                    Console.WriteLine("Input cannot be blank! ");
                    Console.WriteLine("");
                }

                else
                {
                    Console.WriteLine("Enter Province: ");
                    customer.province = Console.ReadLine();

                    if (customer.province == "")
                    {
                        Console.WriteLine("Input cannot be blank! ");
                        Console.WriteLine("");
                    } 
                    else
                    {
                        Console.WriteLine("Enter Branch Code: ");
                        customer.branchCode = Console.ReadLine();

                        if (customer.branchCode == "")
                        {
                            Console.WriteLine("Input cannot be blank! ");
                            Console.WriteLine("");
                        } 
                        else
                        {
                            customer.RegistrationDate = DateTime.Now;

                            Console.WriteLine("Registration Date: " + customer.RegistrationDate);

                            customers.Add(customer.customerID, customer);
                            Console.WriteLine("");
                            Console.WriteLine("Customer registered successfully");
                        }

                    }

                    
                }

            }
        }

        public void removeCustomer()
        {
            Console.WriteLine("");
            Console.WriteLine("Enter Customer ID:");
            string id = Console.ReadLine();

            if (customers.ContainsKey(id))
            {
                Customer customer = customers[id];
                customers.Remove(customer.customerID, out customer);
                Console.WriteLine("");
                Console.WriteLine("Customer Removed successfully");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Customer does not exist");
            }
        }

        public void addCustomerDetails()
        {
            Console.WriteLine("");
            Console.WriteLine("Enter Customer ID:");
            string id = Console.ReadLine();

            if (customers.ContainsKey(id))
            {
                Customer customer = customers[id];

                Purchase purchase = new Purchase();

                Console.WriteLine("Enter Purchase ID:");
                purchase.purchaseID = Console.ReadLine();

                if (purchase.purchaseID == "")
                {
                    Console.WriteLine("Input cannot be blank! ");
                    Console.WriteLine("");
                    return;
                }
                else { 

                foreach (Purchase p in customer.purchaseHistory)
                {
                    if (p.purchaseID == purchase.purchaseID)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Purchase ID already exists.");
                        return;
                    }

                }

                try
                {
                    Console.WriteLine("Enter Amount:");
                    purchase.amount = double.Parse(Console.ReadLine());

                }
                catch
                {
                    Console.WriteLine("");
                    Console.WriteLine("Please enter a valid amount. (numeric)");
                    return;
                }

                Console.WriteLine("What was this amount for? e.g Groceries");
                purchase.description = Console.ReadLine();

                if (purchase.description == "")
                {
                    Console.WriteLine("Input cannot be blank! ");
                    Console.WriteLine("");
                    return;
                }

                customer.totalSpend = customer.totalSpend + purchase.amount;

                customer.points = purchase.amount * 0.10;

                customer.totalPoints = customer.totalPoints + customer.points;

                customer.purchaseHistory.Add(purchase);
                Console.WriteLine("");
                Console.WriteLine("Purchase added successfully");
            }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Customer does not exist");
            }
        }

        public void updateCustomer()
        {
            Console.WriteLine("");
            Console.WriteLine("Enter Customer ID:");
            string id = Console.ReadLine();

            if (customers.ContainsKey(id))
            {
                Customer customer = customers[id];

                Console.WriteLine("Update Menu");
                Console.WriteLine("1. Update Name");
                Console.WriteLine("2. Update Province");
                Console.WriteLine("3. Update Branch Code");
                Console.WriteLine("4. Back");

                string choice = Console.ReadLine();

                while (choice != "4")
                {
                    if (choice == "1")
                    {
                        Console.WriteLine("Enter New Customer Name: ");
                        customer.name = Console.ReadLine();

                        while (customer.name == "")
                        {
                            Console.WriteLine("Input cannot be blank!");

                            Console.WriteLine("Enter New Customer Name: ");
                            customer.name = Console.ReadLine();
                        }
                        
                    }
                    else if (choice == "2")
                    {
                        Console.WriteLine("Enter New Province: ");
                        customer.province = Console.ReadLine();

                        while (customer.province == "")
                        {
                            Console.WriteLine("Input cannot be blank!");
                            Console.WriteLine("Enter New Province: ");
                            customer.province = Console.ReadLine();
                        }
                        
                    }
                    else if (choice == "3")
                    {
                        Console.WriteLine("Enter New Branch Code: ");
                        customer.branchCode = Console.ReadLine();

                        while (customer.branchCode == "")
                        {
                            Console.WriteLine("Input cannot be blank!");
                            Console.WriteLine("Enter New Branch Code: ");
                            customer.branchCode = Console.ReadLine();
                        }
                        
                    }
                    else if (choice == "")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Input Cannot be blank");

                    } 
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Invalid input! Choose from provided options");
                    }

                    Console.WriteLine("Update Menu");
                    Console.WriteLine("1. Update Name");
                    Console.WriteLine("2. Update Province");
                    Console.WriteLine("3. Update Branch Code");
                    Console.WriteLine("4. Back");

                    choice = Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Customer does not exist");
            }
        }
        public void searchAndDisplay()
        {
            Console.WriteLine("");
            Console.WriteLine("Enter Customer ID:");
            string id = Console.ReadLine();

            if (customers.ContainsKey(id))
            {
                Console.WriteLine("");
                Customer customer = customers[id];
                Console.WriteLine("Customer Details");
                Console.WriteLine("ID: " + customer.customerID);
                Console.WriteLine("Name: " + customer.name);
                Console.WriteLine("Province: " + customer.province);
                Console.WriteLine("Branch Code: " + customer.branchCode);
                Console.WriteLine("Registration Date: " + customer.RegistrationDate);
                Console.WriteLine("Total Spent: " + customer.totalSpend);
                Console.WriteLine("Reward Points: " + customer.totalPoints);

                if (customer.totalSpend >= 5000)
                {
                    customer.membership = "Gold";
                }
                else if (customer.totalSpend >= 1000)
                {
                    customer.membership = "Silver";
                }
                else if (customer.totalSpend >= 1)
                {
                    customer.membership = "Bronze";
                }
                
                Console.WriteLine("Membership Tier: " + customer.membership);

                Console.WriteLine("Purchase History:");
                foreach (var p in customer.purchaseHistory)
                {
                    Console.WriteLine(p.purchaseID + " | " + customer.RegistrationDate + "| " +customer.branchCode+ "| " +p.description+ "| R" +p.amount);
                }

            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine("Customer does not exist");
            }
        }

        public void displayAll()
        {
            Console.WriteLine("");
            foreach (var item in customers)
            {
                Customer customer = item.Value;
                Console.WriteLine("");
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Customer ID: " + customer.customerID);
                Console.WriteLine("Name: " + customer.name);
                Console.WriteLine("Province: " + customer.province);
                Console.WriteLine("Branch Code: " + customer.branchCode);
                Console.WriteLine("Registration Date: " + customer.RegistrationDate);
                Console.WriteLine("Total Spent: " + customer.totalSpend);
                Console.WriteLine("Reward Points: " + customer.totalPoints);
               

                if (customer.totalSpend >= 5000)
                {
                    customer.membership = "Gold";
                }
                else if (customer.totalSpend >= 1000)
                {
                    customer.membership = "Silver";
                }
                else
                {
                    customer.membership = "Bronze";
                }
                Console.WriteLine("Membership Tier: " + customer.membership);
                Console.WriteLine("");




                Console.WriteLine("Purchases:");

                foreach (var p in customer.purchaseHistory)
                {
                    Console.WriteLine("");
                    Console.WriteLine(p.purchaseID + " | " + customer.RegistrationDate + "| " + customer.branchCode + "| " + p.description + "| R" + p.amount);
                }
            }

        }

        public void topCustomers()
        {
            var top = customers.Values.OrderByDescending(c => c.totalSpend);
            Console.WriteLine("");
            Console.WriteLine("Top Customers");
            Console.WriteLine("");

            foreach (Customer customer in top)
            {
                Console.WriteLine("Customer ID: " + customer.customerID);
                Console.WriteLine("Name: " + customer.name);
                Console.WriteLine("Total Spend: R" + customer.totalSpend);
                Console.WriteLine("Total Points: " + customer.totalPoints);
                Console.WriteLine("Membership: " + customer.membership);
                Console.WriteLine("");
            }
        }

        public void membershipSpending()
        {
            var groups = customers.Values.GroupBy(c => c.membership);
            Console.WriteLine("");
            Console.WriteLine("Customers by Membership");
            Console.WriteLine("");

            foreach (var group in groups)
            {
                Console.WriteLine(group.Key);
                Console.WriteLine("----------------");

                foreach (Customer customer in group)
                {
                    Console.WriteLine("");
                    Console.WriteLine(customer.customerID + " - " + customer.name);
                }

                Console.WriteLine("");
            }
        }

        public void provinceSpending()
        {
            var provinces = customers.Values
                .GroupBy(c => c.province)
                .Select(g => new
                {
                    Province = g.Key,
                    TotalSpend = g.Sum(c => c.totalSpend)
                });
            Console.WriteLine("");
            Console.WriteLine("Spending by Province");
            Console.WriteLine("");

            foreach (var province in provinces)
            {
                Console.WriteLine(province.Province + " - R" + province.TotalSpend);
            }
        }

        public void branchSpending()
        {
            var branches = customers.Values
                .GroupBy(c => c.branchCode)
                .Select(g => new
                {
                    Branch = g.Key,
                    TotalSpend = g.Sum(c => c.totalSpend)
                });
            Console.WriteLine("");
            Console.WriteLine("Spending by Branch");
            Console.WriteLine("");

            foreach (var branch in branches)
            {
                Console.WriteLine(branch.Branch + " - R" + branch.TotalSpend);
            }
        }

        public void unusualPurchases()
        {
            Console.WriteLine("");
            Console.WriteLine("Unusual Purchases");
            Console.WriteLine("");

            foreach (Customer customer in customers.Values)
            {
                var purchases = customer.purchaseHistory
                    .Where(p => p.amount > 3000);

                foreach (Purchase purchase in purchases)
                {
                    Console.WriteLine(customer.name);
                    Console.WriteLine("Purchase ID: " + purchase.purchaseID);
                    Console.WriteLine("Amount: R" + purchase.amount);
                    Console.WriteLine("");
                }
            }
        }

        

        public void displayOptions()
        {
            Console.WriteLine("");
            Console.WriteLine("Display Menu");
            Console.WriteLine("");
            Console.WriteLine("1. Search & Display customer");
            Console.WriteLine("2. Display top customers");
            Console.WriteLine("3. Display Province Spending");
            Console.WriteLine("4. Display Branch Spending");
            Console.WriteLine("5. Display Customers by membership");
            Console.WriteLine("6. Display Unusual Transactions");
            Console.WriteLine("7. Display all customers");
            Console.WriteLine("8. Back");
            Console.WriteLine("");

            string choice = Console.ReadLine();

            while (choice != "8")
            {
                if (choice == "1")
                {
                    searchAndDisplay();
                }
                else if (choice == "2")
                {
                    topCustomers();
                }
                else if (choice == "3")
                {
                    provinceSpending();
                }
                else if (choice == "4")
                {
                    branchSpending();
                }
                else if (choice == "5")
                {
                    membershipSpending();
                }
                else if (choice == "6")
                {
                    unusualPurchases();
                }
                else if (choice == "7")
                {
                    displayAll();
                }
                else if (choice == "")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Input cannot be blank");
                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Incorrect input! Please choose from options provided. ");
                }

                Console.WriteLine("");
                Console.WriteLine("Display Menu");
                Console.WriteLine("");
                Console.WriteLine("1. Search & Display customer");
                Console.WriteLine("2. Display top customers");
                Console.WriteLine("3. Display Province Spending");
                Console.WriteLine("4. Display Branch Spending");
                Console.WriteLine("5. Display Customers by membership");
                Console.WriteLine("6. Display Unusual Transactions");
                Console.WriteLine("7. Display all customers");
                Console.WriteLine("8. Back");
                Console.WriteLine("");

                choice = Console.ReadLine();
            }
        }


    }
}

