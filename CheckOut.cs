using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MovieRental
{
    public class CheckOut
    {
        //
        [Display(Name = "Movie Name")]
        public string Movie_Name { get; set; }

        [Display(Name = "Date Out")]
        [DisplayFormat(DataFormatString = "{0:C2}")]

        public DateTime Date_Out { get; set; }
        //
        [Display(Name = "Date Return")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public DateTime Date_Return { get; set; }
    }
}
