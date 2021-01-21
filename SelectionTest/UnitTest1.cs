using NUnit.Framework;
using SelectionLib;

namespace SelectionTest
{
	public class Tests
	{
		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void GivenAMarkGreaterThan40_PassIsReturned()
		{
			var result = Selection.PassFail(75);
			Assert.AreEqual("Pass", result);
		}

		[Test]
		public void GivenAMarkLessThan40_FailIsReturned()
		{
			var result = Selection.PassFail(39);
			Assert.AreEqual("Fail", result);
		}

		[Test]
		public void GivenAMarkOf40_PassIsReturned()
		{
			var result = Selection.PassFail(40);
			Assert.AreEqual("Pass", result);
		}

		[TestCase(100)]
		[TestCase(75)]
		public void Mark75AndOver_PassesWithDistinction(int mark)
		{
			var result = Selection.GradeAchieved(mark);
			Assert.AreEqual("Pass with Distinction", result);
		}

		[TestCase(74)]
		[TestCase(60)]
		public void MarkBetween60And74_PassesWithMerit(int mark)
		{
			var result = Selection.GradeAchieved(mark);
			Assert.AreEqual("Pass with Merit", result);
		}

		[TestCase(59)]
		[TestCase(40)]
		public void MarkBetween40And59_Passes(int mark)
		{
			var result = Selection.GradeAchieved(mark);
			Assert.AreEqual("Pass", result);
		}

		[TestCase(39)]
		[TestCase(0)]
		public void MarkBetween0And39_Fails(int mark)
		{
			var result = Selection.GradeAchieved(mark);
			Assert.AreEqual("Fail", result);
		}

		[TestCase(3, "Code Red")]
		[TestCase(2, "Code Amber")]
		[TestCase(1, "Code Amber")]
		[TestCase(0, "Code Green")]
		public void PriorityIsCorrect(int level, string expectedPriority)
		{
			var result = Selection.Priority(level);
			Assert.AreEqual(expectedPriority, result);
		}

		[Test]
		public void TernaryGivenAMarkGreaterThan40_PassIsReturned()
		{
			var result = Selection.PassFailTernary(75);
			Assert.AreEqual("Pass", result);
		}

		[Test]
		public void TernaryGivenAMarkLessThan40_FailIsReturned()
		{
			var result = Selection.PassFailTernary(39);
			Assert.AreEqual("Fail", result);
		}

		[Test]
		public void TernaryGivenAMarkOf40_PassIsReturned()
		{
			var result = Selection.PassFailTernary(40);
			Assert.AreEqual("Pass", result);
		}
	}
}