﻿using System.Collections.Generic;
using NorthwindData;
using NorthwindData.Services;

namespace NorthwindBusiness
{
	public class CustomerManager
	{
		private ICustomerService _service;

		public CustomerManager()
		{
			_service = new CustomerService();
		}

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
				SelectedCustomer = _service.GetCustomerById(customerId);
				SelectedCustomer.ContactName = contactName;
				SelectedCustomer.City = city;
				SelectedCustomer.PostalCode = postcode;
				SelectedCustomer.Country = country;
				// write changes to database
				_service.SaveCustomerChanges();
			}
		}

		public void Delete()
		{
		}

		public List<Customer> RetrieveAll()
		{
			return _service.GetCustomerList();
		}

		public void SetSelectedCustomer(object selectedItem)
		{
			SelectedCustomer = (Customer)selectedItem;
		}
	}
}