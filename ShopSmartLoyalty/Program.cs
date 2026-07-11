using ShopSmartLoyalty_;
using System;

class Program
{
    static void Main(string[] args)
    {
        ShopSmartManager manager = new ShopSmartManager();

        string response = "";

        Console.WriteLine("");
        Console.WriteLine("ShopSmart SmartRewards Management System;");
        Console.WriteLine("");
        Console.WriteLine("Choose from options 1-6");
        Console.WriteLine("");
        Console.WriteLine("1. Register customers");
        Console.WriteLine("2. Record purchases");
        Console.WriteLine("3. Update details");
        Console.WriteLine("4. Remove customers");
        Console.WriteLine("5. Display options");
        Console.WriteLine("6. Exit");
        Console.WriteLine("");

        response = Console.ReadLine();

        while (response != "6")
        {
            if (response == "1")
            {
                manager.registerCustomer();
            }
            else if (response == "2")
            {
                manager.addCustomerDetails();
            } 
            else if (response == "3")
            {
                manager.updateCustomer();
            } 
            else if (response == "4") 
            { 
                manager.removeCustomer();
            }
            else if (response == "5")
            {
                manager.displayOptions();
            }
            else if (response == "")
            {
                Console.WriteLine("Input cannot be blank");
            }
            else
            {
                Console.WriteLine("Please choose from 1-6! ");
            }

            Console.WriteLine("");
            Console.WriteLine("ShopSmart SmartRewards Management System;");
            Console.WriteLine("");
            Console.WriteLine("Choose from options 1-6");
            Console.WriteLine("");
            Console.WriteLine("1. Register customers");
            Console.WriteLine("2. Record purchases");
            Console.WriteLine("3. Update details");
            Console.WriteLine("4. Remove customers");
            Console.WriteLine("5. Display options");
            Console.WriteLine("6. Exit");
            Console.WriteLine("");
            response = Console.ReadLine();
        
        }
    }
}
