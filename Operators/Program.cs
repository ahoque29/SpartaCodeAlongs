using System;

namespace Operators
{
	class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello World!");

			//int x = -5;
			//int y = +x;
			//Console.WriteLine(y);

			//var average = (2 + 5 + 4 + 8) / 4.0;
			//Console.WriteLine(average);

			//int total = 26;
			//Console.WriteLine("26 days is " + 26 / 7 + " weeks and " + 26 % 7 + " days");

			int a = 5, b = 3, c = 4;
			c += +a++ + ++b;
			Console.WriteLine(c);
		}
	}
}
