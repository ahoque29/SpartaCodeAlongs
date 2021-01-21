using System;

namespace IterationApp
{
	class Program
	{
		static string DoThis(int x)
		{
			if (x < 10) return "Your number is Low";
			if (x < 20) return "Your nubmer is Medium";
			if (x < 30) return "Your number is Pretty High!";

			return "Off the charts!!!";
		}
		
		static void Main(string[] args)
		{
			//Console.WriteLine("For Loop");
			//for (int i = 0; i < 10; i++)
			//{
			//	Console.WriteLine(i);
			//}

			//int[] myArray = {10, 20, 30};
			//for (int i = 0; i < myArray.Length; i++)
			//{
			//	Console.WriteLine(myArray[i]);			
			//}

			//int[] myArray = { 10, 20, 30 };
			//foreach (var item in myArray)
			//{
			//	Console.WriteLine(item);
			//}

			//int counter = 0;
			//while (counter < 10)
			//{
			//	Console.WriteLine(counter * 10);
			//	counter++;
			//}

			//int counter = 0;
			//do
			//{
			//	Console.WriteLine(counter);
			//	counter++;
			//}
			//while (counter <= 10);

			//for (int i = 0; i < 10; i++)
			//{
			//	Console.WriteLine(i);
			//	// Break out of loop immediately
			//	if (i == 5)
			//	{
			//		break;
			//	}
			//}

			//int counter = 0;
			//while (counter < 10)
			//{
			//	counter++;
			//	Console.WriteLine(counter);

			//	if (counter < 4) continue;				
			//	Console.WriteLine(counter * 4);
			//}

			//	Console.WriteLine(DoThis(5));
			//	Console.WriteLine(DoThis(15));
			//	Console.WriteLine(DoThis(25));
			//	Console.WriteLine(DoThis(35));

			for (int i = 1; i <= 20; i++)
			{
				Console.WriteLine(i);
				if (i % 15 == 0)
				{
					break;
				}
			}
		}
	}
}
