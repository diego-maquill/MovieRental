﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MovieRental
{
    public class Customer
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        //
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }
        //
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Phone]
        [Display(Name = "Phone number")]
        public string Phone { get; set; }
        [NotMapped]

        [Display(Name = "Customer Name")]
        //public virtual ICollection<Customer> Customer { get; set; }
        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        [NotMapped]
        [JsonIgnore]
        public List<Movies> Movies { get; set; }
        [NotMapped]
        public List<CheckOut> CheckOut { get; set; }
    }
}
