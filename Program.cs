using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using ConsoleTables;
using System.Linq;

namespace MovieRental
{
    class Program
    {
        private static IConfiguration _iconfiguration;
        static void Main(string[] args)
        {
            //  Console.WriteLine("Hello World!");
            GetAppSettingsFile();
            //   ShowSingleCustomer();
            // ShowListOfAllCustomers();
            ShowAllActiveRentals();
        }
        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                                 .AddEnvironmentVariables();
            _iconfiguration = builder.Build();
        }
        static void ShowAllActiveRentals()
        {
            var ShowAllActiveRentals = new Customer_Video_Connection(_iconfiguration);
            //var table = new ConsoleTable("one", "two", "three", "four", "five");
            Console.WriteLine();
            Console.WriteLine("The active rentals are:");

            var ds = ShowAllActiveRentals.GeActiveRentals_ds();
            //    var ds = ShowAllActiveRentals.DataSet(new GetActiveRentals());
            foreach (DataRow dr in ds.Tables[0].Rows)
            //foreach (DataRow dr in ds.Rows)
            {
                //Console.WriteLine($"{dr[0]}, {dr[1]}, {dr[2]}, {dr[3]}, {dr[4]}");
                Console.WriteLine($"{dr[0]}, {dr[1]}, {dr[2]}, {dr[3]}, {dr[4]}");
            }
            Console.WriteLine("Press any key to stop.");
            Console.ReadKey();
        }
        static void ShowListOfAllCustomers()
        {
            var ShowAllCustomers = new Customer_Video_Connection(_iconfiguration);
            var Customers = ShowAllCustomers.GetListAllCustomers();
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
