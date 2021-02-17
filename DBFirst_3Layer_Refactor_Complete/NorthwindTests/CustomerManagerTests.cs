using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using NorthwindBusiness;
using NorthwindData;
using NorthwindData.Services;
using NUnit.Framework;

namespace NorthwindTests
{
	public class CustomerTests
	{
		private CustomerManager _customerManager;
		private NorthwindContext _db;

		//[OneTimeSetUp]
		//public void OneTimeSetup()
		//{
		//	var options = new DbContextOptionsBuilder<NorthwindContext>()
		//		.UseInMemoryDatabase(databaseName: "Northwind_Fake")
		//		.Options;
		//	_db = new NorthwindContext(options);
		//	_customerManager = new CustomerManager(new CustomerService(_db));
		//}

		//[SetUp]
		//public void Setup()
		//{
		//	// remove test entry in DB if present
		//	var selectedCustomers =
		//	from c in _db.Customers
		//	where c.CustomerId == "MAND"
		//	select c;

		//	_db.Customers.RemoveRange(selectedCustomers);
		//	_db.SaveChanges();
		//}

		//[Test]
		//public void WhenANewCustomerIsAdded_TheNumberOfCustemersIncreasesBy1()
		//{
		//	var numberOfCustomersBefore = _db.Customers.Count();
		//	_customerManager.Create("MAND", "Nish Mandal", "Sparta Global");
		//	var numberOfCustomersAfter = _db.Customers.Count();

		//	Assert.AreEqual(numberOfCustomersBefore + 1, numberOfCustomersAfter);
		//}


		//[Test]
		//public void FindById_RetrievesTheCorrectCustomer()
		//{
		//	var numberOfCustomersBefore = _db.Customers.Count();
		//	_customerManager.Create("MAND", "Nish Mandal", "Sparta Global");
		//	var numberOfCustomersAfter = _db.Customers.Count();

		//	Assert.AreEqual(numberOfCustomersBefore + 1, numberOfCustomersAfter);
		//}

		//[Test]
		//public void WhenACustomersDetailsAreChanged_TheDatabaseIsUpdated()
		//{
		//	// arrange
		//	_customerManager.Create("MAND", "Nish Mandal", "Sparta Global", "Paris");
		//	// act
		//	_customerManager.Update("MAND", "Nish Mandal", "Birmingham", null, null);
		//	// assert
		//	var updatedCustomer = _db.Customers.Find("MAND");
		//	Assert.AreEqual("Birmingham", updatedCustomer.City);
		//}




		//[Test]
		//public void WhenACustomerIsDeleted_TheCustomerIsNoLongerPresent()
		//{
		//	// arrange
		//	_customerManager.Create("MAND", "Nish Mandal", "Sparta Global", "Paris");
		//	var createdCustomer = _db.Customers.Find("MAND");
		//	Assert.That(createdCustomer.ContactName, Is.EqualTo("Nish Mandal"));
		//	// act
		//	_customerManager.Delete("MAND");
		//	// assert
		//	var deletedCustomer = _db.Customers.Find("MAND");
		//	Assert.That(deletedCustomer, Is.Null);
		//}

		[Test]
		public void WhenANewCustomerIsCreated_TheCorrectStringIsReturned()
		{
			var mockCustomerService = new Mock<ICustomerService>();
			var customerManager = new CustomerManager(mockCustomerService.Object);
			var result = customerManager.Create("MAND", "Nish Mandal", "Sparta Global");
			Assert.That(result, Does.Contain("MAND - Nish Mandal"));
		}

		[Test]
		public void WhenACustomerIsDeleted_TheCorrectStringIsReturned()
		{
			var mockCustomerService = new Mock<ICustomerService>();
			var customerManager = new CustomerManager(mockCustomerService.Object);
			customerManager.Create("MAND", "Nish Mandal", "Sparta Global");
			var result = customerManager.Delete("MAND");
			Assert.That(result, Is.EqualTo("Customer MAND deleted"));
		}

		[Test]
		public void WhenAnAttemptIsMadeToDeleteANonExistentCustomer_AnErrorMessageIsReturned()
		{
			var mockCustomerService = new Mock<ICustomerService>();
			mockCustomerService.Setup(x => x.Delete(It.IsAny<string>())).Throws<ArgumentNullException>();
			var customerManager = new CustomerManager(mockCustomerService.Object);
			var result = customerManager.Delete("MAND");
			Assert.That(result, Is.EqualTo("Customer MAND not found"));
		}

		//[TearDown]
		//public void TearDown()
		//{
		//	var selectedCustomers =
		//	from c in _db.Customers
		//	where c.CustomerId == "MAND"
		//	select c;

		//	_db.Customers.RemoveRange(selectedCustomers);
		//	_db.SaveChanges();
		//}
	}
}