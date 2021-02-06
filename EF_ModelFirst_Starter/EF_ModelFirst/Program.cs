using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EF_ModelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SouthwindContext())
            {
                // Create
                Console.WriteLine("Creating some customers");
                db.Add(new Customer() { CustomerId = "MART", City = "London", ContactName = "Martin", Country = "UK", PostalCode = "SE1" });
                db.Add(new Customer() { CustomerId = "CATH", City = "Birmingham", ContactName = "Cathy", Country = "UK", PostalCode = "AB1 4DD" });
            
                db.SaveChanges();
            }
        }
    }
}
