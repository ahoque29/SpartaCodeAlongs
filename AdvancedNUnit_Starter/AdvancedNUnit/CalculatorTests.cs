using System.Collections.Generic;
using NUnit.Framework;

namespace AdvancedNUnit
{
	[TestFixture]
	public class CalculatorTests
	{
		[OneTimeSetUp]
		public void OneSetup()
		{
			// runs onnce before running the test methods
		}

		[SetUp]
		public void Setup()
		{
			// runs before each test method
		}

		[Test]
		public void Add_Always_ReturnsExpectedResult()
		{
			// Arrange
			var subject = new Calculator();
			// Act
			var result = subject.Add(2, 4);
			// Assert
			Assert.AreEqual(6, result, "Add method does not work");
		}

		[Test]
		public void Add_Always_ReturnsExpectedResult_Contraint()
		{
			// Arrange
			var subject = new Calculator();
			// Act
			var result = subject.Add(2, 4);
			// Assert
			Assert.That(result, Is.EqualTo(6), "Add method does not work");
		}

		[Test]
		public void AddDoesNotThrowExceptions()
		{
			var subject = new Calculator();
			Assert.That(() => subject.Add(2, 4), Throws.Nothing);
		}

		[TestCase(4, 2, 2)]
		[TestCase(2, 4, -2)]
		public void Subtract_Always_ReturnsExpectedResult_Contraint(int a, int b, int expectedResult)
		{
			var subject = new Calculator();
			Assert.That(subject.Subtract(a, b), Is.EqualTo(expectedResult), "Subtract method does not work");
		}

		[Test]
		public void SubtractDoesNotThrowExceptions()
		{
			var subject = new Calculator();
			Assert.That(() => subject.Subtract(2, 4), Throws.Nothing);
		}

		[Test]
		public void DivideByZero_ThrowsArgumentException()
		{
			var subject = new Calculator();
			Assert.That(() => subject.Divide(5, 0), Throws.ArgumentException.With.Message.EqualTo("Can't divide by 0"));
		}

		[Test]
		public void String_Tests()
		{
			var subject = new Calculator();
			var strResult = subject.ToString();
			Assert.That(strResult, Does.Contain("Calculator"));
			Assert.That(strResult, Does.Not.Contain("Potato"));
			Assert.That(strResult, Is.EqualTo("AdvancedNUnit.Calculator"));
			Assert.That(strResult, Is.EqualTo("advancedNUnit.Calculator").IgnoreCase);
			Assert.That(strResult, Is.Not.Empty);
		}

		[Test]
		public void Collection_Tests()
		{
			var fruit = new List<string> { "apple", "pear", "banana", "peach" };
			Assert.That(fruit, Does.Contain("pear"));
			Assert.That(fruit, Has.Count.EqualTo(4));
			Assert.That(fruit, Has.Exactly(2).StartsWith("pea"));
		}

		[Test]
		public void RangeContraints_Test()
		{
			Assert.That(8, Is.InRange(1, 10));
			List<int> nums = new List<int> { 4, 2, 7, 5, 9 };
			Assert.That(nums, Is.All.InRange(1, 10));
			Assert.That(nums, Has.Exactly(3).InRange(1, 5));
		}

		[TestCaseSource("AddCases")]
		public void Add_AlwaysReturnsExpectedResult_WithDataProvided(int x, int y, int expectedResult)
		{
			var subject = new Calculator();
			Assert.That(subject.Add(x, y), Is.EqualTo(expectedResult));
		}

		public static object[] AddCases =
		{
			new int[] { 2, 4, 6 },
			new int [] { -2, 3, 1 }
		};

		[TearDown]
		public void TearDown()
		{
			// runs after each tests
		}

		[OneTimeTearDown]
		public void OneTimeTearDown()
		{
			// runs after all test methods run
		}
	}
}