using System;

namespace ExceptionApp
{
	class Program
	{
		private static string[] _diningTable = { "Amy", "Bob", "Cath", "Dan" };

		public static void SeatDiner(int pos, string name)
		{
			//try
			//{
			//	_diningTable[pos] = name;

			//}
			//catch (IndexOutOfRangeException e)
			//{
			//	Console.WriteLine("1. Sorry something went wrong");
			//	Console.WriteLine($"2. {e.ToString()}");
			//	Console.WriteLine($"3. {e.Data}");
			//	Console.WriteLine($"4. {e.Message}");
			//}
			//catch (Exception f)
			//{
			//	Console.WriteLine("Sorry no room");
			//}

			if (pos < 0 || pos >= _diningTable.Length)
			{
				throw new ArgumentException($"The dining table does not have a position {pos}");
			}
			_diningTable[pos] = name;
		}

		static void Main(string[] args)
		{
			//SeatDiner(4, "george");

			//int x = 10;
			//int y = 0;
			//try
			//{
			//	int output = x / y;
			//}
			//catch (Exception e)
			//{
			//	Console.WriteLine("an exception has occured");
			//}
			//finally 
			//{
			//	Console.WriteLine("but life goes on...");
			//}

			//try
			//{
			//	SeatDiner(5, "George");
			//}
			//catch (ArgumentException e)
			//{
			//	Console.WriteLine("Exception Thrown: " + e.Message);
			//}

			checked
			{
				int three = 3;
				int sum = int.MaxValue + three;
				Console.WriteLine(sum);
			}
		}
	}
}
