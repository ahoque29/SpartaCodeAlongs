using System;
using System.Collections.Generic;
using System.Linq;
using NorthwindData;
using NorthwindData.Services;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindTests
{
	class CustomerServiceTests
	{
		private NorthwindContext _db;
		CustomerService _customerService;

		[OneTimeSetUp]
		public void OneTimeSetup()
		{
			var options = new DbContextOptionsBuilder<NorthwindContext>()
				.UseInMemoryDatabase(databaseName: "Northwind_Fake")
				.Options;
			_db = new NorthwindContext(options);
			_customerService = new CustomerService(_db);
		}

		[SetUp]
		public void Setup()
		{
			// remove test entry in DB if present
			var selectedCustomers =
			from c in _db.Customers
			where c.CustomerId == "MAND"
			select c;

			_db.Customers.RemoveRange(selectedCustomers);
			_db.SaveChanges();
		}

		[Test]
		public void WhenACustomerIsSearchedFor_TheCorrectObjectIsReturned()
		{
			// Arrange
			_customerService.Add(new Customer() { CustomerId = "MAND", 
				ContactName = "Nish Mandal", 
				CompanyName = "Sparta Global", 
				City = "Paris" });
			// Act
			var result = _customerService.GetCustomerById("MAND");
			// Assert
			Assert.That(result.ContactName, Is.EqualTo("Nish Mandal"));

		}

		[TearDown]
		public void TearDown()
		{
			var selectedCustomers =
			from c in _db.Customers
			where c.CustomerId == "MAND"
			select c;

			_db.Customers.RemoveRange(selectedCustomers);
			_db.SaveChanges();
		}

	}
}
