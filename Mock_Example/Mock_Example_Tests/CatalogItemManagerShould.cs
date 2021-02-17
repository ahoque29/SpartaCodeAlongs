using NUnit.Framework;
using MoqExampleBackEnd;
using MoqExampleBackEnd.DbModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Mock_Example_Tests
{
    [TestFixture]
    public class CatalogItemManagerShould
    {
        private CatalogItemManager _sut;

        [OneTimeSetUp] 
        public void OneTimeSetUp()
        {
            var options = new DbContextOptionsBuilder<ExampleContext>()
                .UseInMemoryDatabase(databaseName: "Example_DB")
                .Options;
            var context = new ExampleContext(options);
            _sut = new CatalogItemManager(context);
            _sut.AddItems(new List<CatalogItem> {
                new CatalogItem() { CatalogItemId = 1, Brand = "Acme", Name = "Teaset", Price = 20.00m },
                new CatalogItem() { CatalogItemId = 2, Brand = "BigShot", Name = "Filofax", Price = 10.00m },
                new CatalogItem() { CatalogItemId = 3, Brand = "Fluffy Friends", Name = "Cuddly Toy", Price = 15.00m },
                new CatalogItem() { CatalogItemId = 4, Brand = "Dinarama", Name = "Record Player", Price = 60.00m }
            });
        }
        [Test]
        public void GivenAValidItemName_Return_ItsPrice()
        {
           Assert.That(_sut.GetPrice("Filofax"), Is.EqualTo(10.00m));
        }
		
		[Test]
        public void GivenANewItem_ItIsAddedToTheDatabase()
        {
            // Arrange
            var item = new CatalogItem() { Brand = "Ibex", Name = "Camera", Price = 124.99m };
            // make sure the item is not already in the database
            Assert.That(_sut.FindItem("Camera"), Is.Null);
            // Act
            _sut.AddItem(item);
            var insertedItem = _sut.FindItem("Camera");
            // Assert
            Assert.That(insertedItem.Name, Is.EqualTo("Camera"));
            Assert.That(insertedItem.Brand, Is.EqualTo("Ibex"));
            // clean up
            _sut.RemoveItem("Camera");
        }
    }
}