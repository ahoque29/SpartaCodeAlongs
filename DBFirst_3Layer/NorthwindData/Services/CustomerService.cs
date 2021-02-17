using System.Collections.Generic;
using System.Linq;

namespace NorthwindData.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly NorthwindContext _context;

		public CustomerService()
		{
			_context = new NorthwindContext();
		}
		public void CreateCustomer(Customer customer)
		{
			_context.Customers.Add(customer);
		}

		public void DeleteCustomer(string customerId)
		{
			var del = GetCustomerById(customerId);
			_context.RemoveRange(del);
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
	}
}