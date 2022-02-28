using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyAspNetCore.Models
{
    public static class CustomerContext
    {
        public static List<Customer> Customers = new()
        {
            new Customer { Id=1, FirstName = "Yavuz", LastName = "Kahraman", Age = 27 },
            new Customer { Id=2, FirstName = "Oğuz", LastName = "Kahraman", Age = 20 }
        };
    }
}
