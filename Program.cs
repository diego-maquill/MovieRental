using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;
using ConsoleTables;
using System.Linq;
using System.Text;

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
            Console.WriteLine();
            Console.WriteLine("The active rentals are:");
            Console.WriteLine();
            DataSet ds = ShowAllActiveRentals.GeActiveRentals_ds();
            //    var ds = ShowAllActiveRentals.DataSet(new GetActiveRentals());
            /*        
                   string currentLine = "";
                   var nameLengths = new int[ds.Tables[0].Columns.Count];
                   var i = 0;
                   foreach (var col in ds.Tables[0].Columns)
                   {
                       var colName = col.ToString();
                       nameLengths[i] = colName.Length;
                       currentLine += " " + colName;
                       i++;
                   }
                   Console.WriteLine(currentLine);
        */
            // var dataLength = new int[ds.Tables[0].Columns.Count];
            int nCols = ds.Tables[0].Columns.Count;
            var dataWidths = ds.Tables[0].Columns.Cast<DataColumn>().Select(x => x.ColumnName.Length).ToList();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                for (int i = 0; i < nCols; i++)
                {
                    dataWidths[i] = Math.Max(dataWidths[i], row.ItemArray[i].ToString().Length);
                }
            }

            var colFormats = dataWidths.Select(x => $"{{0,{-x}}}").ToList();

            var sb = new StringBuilder();

            sb.AppendLine(string.Join(" ", ds.Tables[0].Columns.Cast<DataColumn>().Select((x, i) => string.Format(colFormats[i], x.ColumnName))));

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                sb.AppendLine(string.Join(" ", row.ItemArray.Select((x, i) => string.Format(colFormats[i], x))));
            }

            Console.WriteLine(sb.ToString());

            /* 
                        foreach (DataRow row in ds.Tables[0].Rows)
                        //foreach (DataRow row in ds.Rows)
                        {
                            //Console.WriteLine($"{row[0]}, {row[1]}, {row[2]}, {row[3]}, {row[4]}");
                            currentLine = "";
                            i = 0;
                            foreach (var item in row.ItemArray)
                            {
                                var field = item.ToString();
                                //      dataLength[i] = field.Length;
                                //currentLine += " " + field.PadRight(nameLengths[i], ' ');
                                currentLine += " " + field.PadRight(nameLengths[i], ' ');
                                i++;
                            }
                            Console.WriteLine(currentLine);
                        }
                         */
            Console.WriteLine();
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
