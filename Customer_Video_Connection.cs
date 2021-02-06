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
    public class Customer_Video_Connection
    {
        private string _connectionString;
        public Customer_Video_Connection(IConfiguration iconfiguration)
        {
            _connectionString = iconfiguration.GetConnectionString("DefaultConnection");
        }
        public DbSet<Customer> Customer { get; set; }

        public Customer GetSingleCustomerTest(int customerId)
        {
            var customer = new Customer();
            SqlConnection conn = new SqlConnection(_connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand("dbo.get_customer_by_id", conn);
                //SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@CustomerId", customerId));
                //cmd.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if ((bool)rdr["Found"] == true)
                    {
                        customer = new Customer(new Models.CustomerDTO
                        {
                            Id = Convert.ToInt32(rdr[1]),
                            FirstName = rdr[3].ToString(),
                            LastName = rdr[2].ToString()
                        });
                    }
                }
                conn.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            conn.Dispose();
            return customer;
        }
        public Customer GetSingleCustomer(int customerId)
        {
            var customer = new Customer();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("dbo.get_customer_by_id", conn);
                    //SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@CustomerId", customerId));
                    //cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        if ((bool)rdr["Found"] == true)
                        {
                            customer = new Customer(new Models.CustomerDTO
                            {
                                Id = Convert.ToInt32(rdr[1]),
                                FirstName = rdr[3].ToString(),
                                LastName = rdr[2].ToString()
                            });

                        }
                        else
                        {
                            Console.WriteLine("that id does not exist");
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return customer;
        }
        public List<Customer> GetListAllCustomers()
        {
            var List_Of_Customers = new List<Customer>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Select * from Customer", conn);
                    cmd.CommandType = CommandType.Text;
                    conn.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        List_Of_Customers.Add(new Customer
                        {
                            Id = Convert.ToInt32(rdr[0]),
                            FirstName = rdr[1].ToString(),
                            LastName = rdr[2].ToString()
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