using System;
using Moq;
using MoqExampleBackEnd;
using NUnit.Framework;

namespace Mock_Example_Tests
{
	[TestFixture]
	public class SaleCreatorTests
	{
		private SaleCreator _sut;

		[Test]
		[Ignore("Fails because the first parameter is null")]
		public void BeAbleToBeConstructed()
		{
			// Arrange and Act
			_sut = new SaleCreator(null, null);
			// Assert
			Assert.That(_sut, Is.InstanceOf<SaleCreator>());
		}

		[Test]
		public void BeAbleToBeConstructedUsingMoq()
		{
			// Arrange
			var mockCatalogItemManager = new Mock<ICatalogItemManager>();
			var mockExchangeRateService = new Mock<IExchangeRateService>();
			// Act
			_sut = new SaleCreator(mockCatalogItemManager.Object, mockExchangeRateService.Object);
			// Assert
			Assert.That(_sut, Is.InstanceOf<SaleCreator>());
		}

		[Test]
		public void CalculateTotal_ReturnsTheCorrectTotalString()
		{
			// Arrange
			var mockCatalogItemManager = new Mock<ICatalogItemManager>();
			mockCatalogItemManager.Setup(x => x.GetPrice("Filofax")).Returns(10.00m);

			var mockExchangeRateService = new Mock<IExchangeRateService>();
			mockExchangeRateService.Setup(x => x.GetRateFor("GBP", "CDN")).Returns(1.50m);

			_sut = new SaleCreator(mockCatalogItemManager.Object, mockExchangeRateService.Object);
			// Act
			var result = _sut.CalculateTotal("Filofax", "CDN", 2);
			// Assert
			Assert.That(result, Is.EqualTo("Total price: 30.00 CDN at 1.50 per GBP"));
		}

		[Test]
		public void CalculateTotal_CallsIExchangeRateService_GetRateFor_WithCorrectParameters()
		{
			// Arrange
			var mockCatalogItemManager = new Mock<ICatalogItemManager>();
			var mockExchangeRateService = new Mock<IExchangeRateService>();
			_sut = new SaleCreator(mockCatalogItemManager.Object, mockExchangeRateService.Object);
			// Act
			_sut.CalculateTotal("Filofax", "CDN", 2);
			// Assert
			mockExchangeRateService.Verify(x => x.GetRateFor("GBP", "CDN"));
		}

		[Test]
		public void CalculateTotal_DoesNotCallIExchangeRateService_GetRateFor_WhenDesiredCurrencyIsGBP()
		{
			// Arrange
			var mockCatalogItemManager = new Mock<ICatalogItemManager>();
			var mockExchangeRateService = new Mock<IExchangeRateService>();
			_sut = new SaleCreator(mockCatalogItemManager.Object, mockExchangeRateService.Object);
			// Act
			_sut.CalculateTotal("Filofax", "GBP", 2);
			// Assert
			mockExchangeRateService.Verify(x => x.GetRateFor(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
		}

		[Test]
		public void CalculateTotal_ReturnsAnErrorString_WhenIExchangeRateService_GetRateFor_ThrowsAnException()
		{
			// Arrange
			var mockCatalogItemManager = new Mock<ICatalogItemManager>();
			var mockExchangeRateService = new Mock<IExchangeRateService>();

			mockExchangeRateService.Setup(x => x.GetRateFor(It.IsAny<string>(), It.IsAny<string>())).Throws<TimeoutException>();

			_sut = new SaleCreator(mockCatalogItemManager.Object, mockExchangeRateService.Object);
			// Act
			var result = _sut.CalculateTotal("Filofax", "CDN", 2);
			// Assert
			Assert.That(result, Is.EqualTo("Sorry there was a problem obtaining an exchange rate"));
		}

		[Test]
		public void CalculateTotal_CallsTheCorrectMethodWithCorrectParameters_OfICatalogItemManager()
		{
			var mockCatalogItemManager = new Mock<ICatalogItemManager>(MockBehavior.Strict);
			mockCatalogItemManager.Setup(x => x.GetPrice("Filofax")).Returns(It.IsAny<decimal>);
			var mockExchangeRateService = new Mock<IExchangeRateService>();
			_sut = new SaleCreator(mockCatalogItemManager.Object, mockExchangeRateService.Object);
			_sut.CalculateTotal("Filofax", "CDN", 2);
		}

		[Test]
		[Ignore("Fails because CalculateTotal arguments do not match")]
		// for demonstration purposes, this test should fail
		public void CalculateTotalTest_FailsInStrictModeIfArgumentsDontMatchSetup()
		{
			var mockCatalogItemManager = new Mock<ICatalogItemManager>(MockBehavior.Strict);
			mockCatalogItemManager.Setup(x => x.GetPrice("Filofax")).Returns(It.IsAny<decimal>);
			var mockExchangeRateService = new Mock<IExchangeRateService>();
			_sut = new SaleCreator(mockCatalogItemManager.Object, mockExchangeRateService.Object);
			_sut.CalculateTotal("Handbag", "CDN", 2);
		}

		[Test]
		public void CalculateTotalTest_PassesInLooseModeIfArgumentsDontMatchSetup()
		{
			var mockCatalogItemManager = new Mock<ICatalogItemManager>(MockBehavior.Loose);
			mockCatalogItemManager.Setup(x => x.GetPrice("Filofax")).Returns(It.IsAny<decimal>);
			var mockExchangeRateService = new Mock<IExchangeRateService>();
			_sut = new SaleCreator(mockCatalogItemManager.Object, mockExchangeRateService.Object);
			_sut.CalculateTotal("Handbag", "CDN", 2);
		}
	}
}