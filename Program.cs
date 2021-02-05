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
            ShowCustomerTable();
        }
        static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                                 .SetBasePath(Directory.GetCurrentDirectory())
                                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _iconfiguration = builder.Build();
        }
        static void ShowCustomerTable()
        {
            var getDbTable = new Customer_Video_Connection(_iconfiguration);
            var Customers = getDbTable.GetList();
            Customers.ForEach(item =>
            {
                Console.WriteLine(item.Name);
            });
            Console.WriteLine("Press any key to stop.");
            Console.ReadKey();
        }
    }
}
