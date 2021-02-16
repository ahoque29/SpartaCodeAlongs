using System.Collections.Generic;
using System.Linq;
using NorthwindData;

namespace NorthwindBusiness
{
	public class CustomerManager
	{
		public Customer SelectedCustomer { get; set; }

		public void Create(string customerId, string contactName, string companyName, string city = null)
		{
			var newCust = new Customer() { CustomerId = customerId, ContactName = contactName, CompanyName = companyName };
			using (var db = new NorthwindContext())
			{
				db.Customers.Add(newCust);
				db.SaveChanges();
			}
		}

		public void Update(string customerId, string contactName, string city, string postcode, string country)
		{
			using (var db = new NorthwindContext())
			{
				SelectedCustomer = db.Customers.Where(c => c.CustomerId == customerId).FirstOrDefault();
				SelectedCustomer.ContactName = contactName;
				SelectedCustomer.City = city;
				SelectedCustomer.PostalCode = postcode;
				SelectedCustomer.Country = country;
				// write changes to database
				db.SaveChanges();
			}
		}

		public void Delete()
		{
		}

		public List<Customer> RetrieveAll()
		{
			using (var db = new NorthwindContext())
			{
				return db.Customers.ToList();
			}
		}

		public void SetSelectedCustomer(object selectedItem)
		{
			SelectedCustomer = (Customer)selectedItem;
		}
	}
}