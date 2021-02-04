using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Security.Claims;
//using ConsoleApp.Model;  
using Microsoft.Extensions.Configuration;
//using Microsoft.EntityFrameworkCore.Proxies;

namespace MovieRental
{
    // this manages the connection to the database
    public class Customer_Video
    {
        private string _connectionString;
        public Customer_Video(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("Default");
        }
        public DbSet<Customer> Customer { get; set; }

        /*     public Customer_Video(DbContextOptions<Customer_Video> options) : base(options)
            {
            } */
        public List<Customer> GetList()
        {
            var List_Of_Customers = new List<Customer>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    //SqlCommand cmd = new SqlCommand("list_of_Customers", conn);
                    SqlCommand cmd = new SqlCommand();
                    // cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        List_Of_Customers.Add(new Customer
                        {
                            Id = Convert.ToInt32(rdr[0]),
                            FirstName = rdr[1].ToString(),
                            LastName = rdr[1].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return List_Of_Customers;
        }
    }
}