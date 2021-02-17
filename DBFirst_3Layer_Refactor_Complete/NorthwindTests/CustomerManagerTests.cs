using NUnit.Framework;
using NorthwindBusiness;
using NorthwindData;
using NorthwindData.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NorthwindTests
{
    public class CustomerTests
    {
        CustomerManager _customerManager;
        [SetUp]
        public void Setup()
        {
           _customerManager = new CustomerManager();
            // remove test entry in DB if present
            using (var db = new NorthwindContext())
            {
                var selectedCustomers =
                from c in db.Customers
                where c.CustomerId == "MAND"
                select c;

                db.Customers.RemoveRange(selectedCustomers);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewCustomerIsAdded_TheNumberOfCustemersIncreasesBy1()
        {
            using (var db = new NorthwindContext())
            {
                var numberOfCustomersBefore = db.Customers.Count();
                _customerManager.Create("MAND", "Nish Mandal", "Sparta Global");
                var numberOfCustomersAfter = db.Customers.Count();

                Assert.AreEqual(numberOfCustomersBefore + 1, numberOfCustomersAfter);
            }
        }

        [Test]
        public void WhenANewCustomerIsCreated_TheCorrectStringIsReturned()
        {
            using (var db = new NorthwindContext())
            {
                var numberOfCustomersBefore = db.Customers.Count();
                var result = _customerManager.Create("MAND", "Nish Mandal", "Sparta Global");
                Assert.That(result, Does.Contain("MAND - Nish Mandal"));
            }
        }

        [Test]
        public void FindById_RetrievesTheCorrectCustomer()
        {
            using (var db = new NorthwindContext())
            {
                var numberOfCustomersBefore = db.Customers.Count();
                _customerManager.Create("MAND", "Nish Mandal", "Sparta Global");
                var numberOfCustomersAfter = db.Customers.Count();

                Assert.AreEqual(numberOfCustomersBefore + 1, numberOfCustomersAfter);
            }
        }

        [Test]
        public void WhenACustomersDetailsAreChanged_TheDatabaseIsUpdated()
        {
            using (var db = new NorthwindContext())
            {
                // arrange
                _customerManager.Create("MAND", "Nish Mandal", "Sparta Global", "Paris");
                // act
                _customerManager.Update("MAND", "Nish Mandal", "Birmingham", null, null);
                // assert
                var updatedCustomer = db.Customers.Find("MAND");
                Assert.AreEqual("Birmingham", updatedCustomer.City);
            }
        }

        [Test]
        public void WhenACustomerIsDeleted_TheCustomerIsNoLongerPresent()
        {
            using (var db = new NorthwindContext())
            {
                // arrange
                _customerManager.Create("MAND", "Nish Mandal", "Sparta Global", "Paris");
                var createdCustomer = db.Customers.Find("MAND");
                Assert.That(createdCustomer.ContactName, Is.EqualTo("Nish Mandal"));
                // act
                _customerManager.Delete("MAND");
                // assert
                var deletedCustomer = db.Customers.Find("MAND");
                Assert.That(deletedCustomer, Is.Null);
            }
        }

        [Test]
        public void WhenACustomerIsDeleted_TheCorrectStringIsReturned()
        {
            using (var db = new NorthwindContext())
            {
                // Arrange
                _customerManager.Create("MAND", "Nish Mandal", "Sparta Global", "Paris");
                // Act
                var result = _customerManager.Delete("MAND");
                // Assert
                Assert.That(result, Is.EqualTo("Customer MAND deleted"));

            }
        }

        [Test]
        public void WhenAnAttemptIsMadeToDeleteANonExistentCustomer_AnErrorMessageIsReturned()
        {
            using (var db = new NorthwindContext())
            {
                var result = _customerManager.Delete("MAND");
                var deletedCustomer = db.Customers.Find("MAND");
                Assert.That(result, Is.EqualTo("Customer MAND not found"));
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new NorthwindContext())
            {
                var selectedCustomers =
                from c in db.Customers
                where c.CustomerId == "MAND"
                select c;

                db.Customers.RemoveRange(selectedCustomers);
                db.SaveChanges();
            }
        }
    }
}