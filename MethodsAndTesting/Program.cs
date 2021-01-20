using System;

namespace MethodsAndTesting
{
	public class Program
	{				
		// method declaration
		//public static (int xsquared, bool y_gt_10) DoThat(int x, string y)
		//{
		//	Console.WriteLine(y);
		//	var z = (x > 10);
		//	return (x * x, z);
		//}

		//public static int Add(int x, int y)
		//{
		//	return x + y;
		//}

		//public static int Add(int x, int y, int z)
		//{
		//	return Add(x, y) + z;
		//}

		public static int TripleCalc(int a, int b, int c, out int sum)
		{
			sum = a + b + c;
			return a * b * c;
		}

		public static (int sum, int product) TripleCalc(int a, int b, int c)
		{
			return (a + b + c, a * b * c);
		}


		static void Main(string[] args)
		{
			//// invoke (call) the DoThis() method
			//var result = DoThis(10, "Here's a string", out bool isLarge);
			//Console.WriteLine(isLarge);

			//var myTuple = ("Cathy", "French", 25);
			//Console.WriteLine(myTuple);
			//Console.WriteLine(myTuple.Item2);

			//var myNamedTuple = (fName: "John", lName: "Doe", age: 32);
			//Console.WriteLine(myNamedTuple);
			//Console.WriteLine(myNamedTuple.fName);

			//var title = "Gone with the wind";
			//int copies = 3;
			//var myThirdTuple = (title, copies);
			//Console.WriteLine(myThirdTuple);
			//Console.WriteLine(myThirdTuple.title);

			//var result = DoThat(10, "Here's a string");
			//Console.WriteLine(result);
			//Console.WriteLine(result.xsquared);
			//var (square, greaterThan10) = DoThat(5, "Hello");

			//Console.WriteLine(Add(2, 3));
			//Console.WriteLine(Add(4, 5, 6));

			var result1 = TripleCalc(2, 3, 4, out int result1Sum);
			Console.WriteLine(result1);
			Console.WriteLine(result1Sum);
			
			var result2 = TripleCalc(2, 3, 4);
			Console.WriteLine(result2);
		}
	}
}
