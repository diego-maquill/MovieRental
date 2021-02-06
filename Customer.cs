using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using MovieRental.Models;

namespace MovieRental
{
    public class Customer : CustomerDTO
    {

        public Customer(CustomerDTO customerDTO)
        {
            Id = customerDTO.Id;
            FirstName = customerDTO.FirstName;
            LastName = customerDTO.LastName;
            PhoneNumber = customerDTO.PhoneNumber;
        }
        public Customer() { }

        [Display(Name = "Customer Name")]
        //public virtual ICollection<Customer> Customer { get; set; }
        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [JsonIgnore]
        public List<Movies> Movies { get; set; }

        public List<CheckOut> CheckOut { get; set; }
    }
}
