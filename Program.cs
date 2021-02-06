using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MovieRental
{
    class Program
    {
        private static IConfiguration _iconfiguration;
        static void Main(string[] args)
        {
            //  Console.WriteLine("Hello World!");
            GetAppSettingsFile();
            ShowSingleCustomer();
            // ShowAllCustomers();
        }
        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                 .AddEnvironmentVariables();
            _iconfiguration = builder.Build();
        }
        static void ShowAllCustomers()
        {
            var ShowAllCustomers = new Customer_Video_Connection(_iconfiguration);
            var Customers = ShowAllCustomers.GetListAllCustomers();
            //  var singleCustomer = ShowAllCustomers.GetCustomerTest(1);
            Console.WriteLine();
            Console.WriteLine("In this table we have the following Customers:");
            Customers.ForEach(item =>
            {
                Console.WriteLine(item.Name);
            });
            Console.WriteLine();
            Console.WriteLine("Press any key to stop.");
            Console.ReadKey();
        }
        static void ShowSingleCustomer()
        {
            var ShowSingleCustomer = new Customer_Video_Connection(_iconfiguration);
            Console.WriteLine();
            Console.Write("Type the id number of the person you wish to see: ");
            int userInput = Convert.ToInt32(Console.ReadLine());
            var singleCustomer = ShowSingleCustomer.GetSingleCustomer(userInput);
            if (userInput > 0)
            {
                Console.WriteLine($"You typed customerId: {singleCustomer.Id}, it belongs to: {singleCustomer.Name}");
            }
            else
            {
                Console.WriteLine("You wrote a negative number or 0");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to stop.");
            Console.ReadKey();
        }
    }
}
