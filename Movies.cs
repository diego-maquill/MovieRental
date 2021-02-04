using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MovieRental
{
    public class Movies
    {
        [Display(Name = "Movie Id")]
        public int Id { get; set; }

    }
}
