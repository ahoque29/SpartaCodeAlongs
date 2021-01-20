using System;
using System.Text;

namespace ArraysAndStrings
{
	class Program
	{
		static void Main(string[] args)
		{
			//int[,] grid2 = { { 4, 7, 8, 9 }, { 6, 1, 7, 10 } };
			//var x = grid2[0, 0];
			//Console.WriteLine(x);

			//string[][] animalGrid = new string[2][];
			//animalGrid[0] = new string[4];
			//animalGrid[1] = new string[2];

			//string[][] animalGrid2 = new string[][]
			//	{
			//		new string[] {"llama", "puma", "horse", "kitten" },
			//		new string[] {"haddock", "tuna" },
			//	};

			//animalGrid2[0][2] = "puppy";
			//var myPet = animalGrid2[1][0];
			//Console.WriteLine(myPet);

			//animalGrid2[1][1] = "salmon";
			//Console.WriteLine(animalGrid2[1][1]);

			//string name = "Cathy";
			//var thirdLetter = name[2];
			//Console.WriteLine(thirdLetter);

			Console.WriteLine("How many apples? :");
			string input = Console.Read();
			//int numApples = Int32.Parse(input);
			bool success = Int32.TryParse(input, out int numApples);
			Console.WriteLine($"There are {numApples} apples");

			//// Create a StringBuilder that expects to hold 50 characters.
			//// Initialize the StringBuilder with "ABC".
			//StringBuilder sb = new StringBuilder("ABC", 50);
			//Console.WriteLine(sb);
			//// .Append to add an array of strings
			//sb.Append(new char[] { 'D', 'E', 'F' });
			//Console.WriteLine(sb);
			//sb.AppendFormat("GHI{0}{1}", 'J', 'k');
			//Console.WriteLine(sb);
		}
	}
}
