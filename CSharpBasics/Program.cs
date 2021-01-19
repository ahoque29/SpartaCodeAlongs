using System;

namespace CSharpBasics
{
	class Program
	{
		static void Main(string[] args)
		{
			double sum = 0;
			for (int i = 0; i < 1000; i++)
			{
				sum += 1 / 3.0;
			}
			Console.WriteLine("1/3 is: " + 1 / 3.0);
			Console.WriteLine("1/3 added 1000 times: " + sum);
			Console.WriteLine("1/3 multiplied by 1000: " + 1 / 3.0 * 1000);

			float pi = 3.14f;
			double dPi = pi;
			Console.WriteLine(pi);
			Console.WriteLine(dPi);
		}
	}
}
