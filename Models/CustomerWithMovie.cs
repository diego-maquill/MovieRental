using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.Models
{

    public class CustomerWithMovie
    {
        public CustomerWithMovie(Customer customer, Movies movieRental, CheckOut checkOut)
        {
            Id = customer.Id;
            Name = customer.Name;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Movie_Name { get; set; }
        public string Code { get; set; }
        public string Date_Out { get; set; }
        public string Date_Returned { get; set; }
        public string Type { get; set; }
    }
}
