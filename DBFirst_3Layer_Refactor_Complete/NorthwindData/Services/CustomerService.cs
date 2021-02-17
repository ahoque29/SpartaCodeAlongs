using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindData.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly NorthwindContext _context;

        public CustomerService(NorthwindContext context)
        {
            _context = context;
        }
        public CustomerService()
        {
            _context = new NorthwindContext();
        }

        public void Add(Customer c)
        {
            _context.Add(c);
            _context.SaveChanges();
        }
        public Customer GetCustomerById(string customerId)
        {
                return _context.Customers.Where(c => c.CustomerId == customerId).FirstOrDefault();
        }

        public List<Customer> GetCustomerList()
        {
               return _context.Customers.ToList();
        }

        public void SaveCustomerChanges()
        {
              _context.SaveChanges();
        }

        public void Delete(string customerId)
        {
            var customer = GetCustomerById(customerId);
            _context.Customers.Remove(customer);
            _context.SaveChanges();
        }
    }
}
