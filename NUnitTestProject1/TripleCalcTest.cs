using NUnit.Framework;

using MethodsAndTesting;

namespace NUnitTestProject1
{
	public class TripleCalcTest
	{
		private int _result;
		private int _sum;
		
		[SetUp]
		public void Setup()
		{
			_result = Program.TripleCalc(10, 2, 4, out int sum);
			_sum = sum;
		}

		[Test]
		public void ProductIsCorrect()
		{
			// assert
			Assert.AreEqual(80, _result);
		}

		[Test]
		public void SumIsCorrect()
		{
			Assert.AreEqual(16, _sum);
		}

		[TestCase(10, 2, 4, 80)]
		[TestCase(0, -3, 7, 0)]
		public void ProductIsCorrect2(int a, int b, int c, int expectedResult)
		{
			var result = Program.TripleCalc(a, b, c, out int sum);
			Assert.AreEqual(expectedResult, result);
		}

		[TestCase(10, 2, 4, 16)]
		[TestCase(0, -3, 7, 4)]
		public void SumIsCorrect2(int a, int b, int c, int expectedResult)
		{
			var result = Program.TripleCalc(a, b, c, out int sum);
			Assert.AreEqual(expectedResult, sum);
		}
	}
}