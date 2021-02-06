using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRental.Models
{
    public class CustomerWithMoviesSummary
    {
        public CustomerWithMoviesSummary(List<Customer> customers, List<Movies> movieRentals, List<CheckOut> checkOuts)
        {
            CustomerWithMovies = (from o in checkOuts
                                  join m in movieRentals on o.MovieId equals m.Id
                                  join c in customers on o.CustomerId equals c.Id
                                  select new CustomerWithMovie(c, m, o)).ToList();
        }
        public List<CustomerWithMovie> CustomerWithMovies { get; set; }
    }
}
