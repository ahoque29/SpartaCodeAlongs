using System;

namespace SelectionLib
{
	public class Selection
	{
		public static string PassFail(int mark)
		{
			var grade = "Fail";
			if (mark >= 40)
			{
				grade = "Pass";
			}
			return grade;
		}

		public static string PassFailTernary(int mark)
		{
			return (mark >= 40) ? "Pass" : "Fail";
		}

		public static string GradeAchieved(int mark)
		{
			var grade = "";
			if (mark >= 40)
			{
				grade = "Pass";
				if (mark >= 75)
				{
					grade += " with Distinction";
				}
				else if (mark >= 60)
				{
					grade += " with Merit";
				}
			}
			else
			{
				grade += "Fail";
			}
			return grade;
		}

		public static string Priority(int level)
		{
			string priority = "Code ";
			switch (level)
			{
				case 3:
					priority += "Red";
					break;
				case 2:
				case 1:
					priority += "Amber";
					break;
				case 0:
					priority += "Green";
					break;
				default:
					priority = "Error";
					break;
			}
			return priority;
		}
		
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
	}
}
