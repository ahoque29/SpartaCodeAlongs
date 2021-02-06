//#define TEST

using System;
using System.IO;
using System.Diagnostics;

namespace File_Handling
{
	class Program
	{
		static void Main(string[] args)
		{
			//string text = "Hello out there";
			//File.WriteAllText("Hello.txt", text);
			//string readText = File.ReadAllText("Hello.txt");
			//Console.WriteLine(readText);

			Console.WriteLine($"This is being logged at time {DateTime.Now}");
			TextWriterTraceListener twtl = new
				TextWriterTraceListener(File.Create("TraceOutput.txt"));
			Trace.Listeners.Add(twtl);
			for (int i = 0; i < 3; i++)
			{
				Console.WriteLine(i);
				Debug.WriteLine($"Debug - the value of i is {i}");
				Trace.WriteLine($"Trace - the value of i is {i}");
				Debug.WriteLine(i == 2, $"\nReached maximum value of i: {i} at {DateTime.Now}");
				Trace.Assert(i > 0, "i is not greater than zero: {i}");
			}
			Trace.Flush();

			//			Console.WriteLine("Starting app");
			//#if DEBUG
			//			Console.WriteLine("This is debug code");
			//#endif
			//#if TEST
			//			Console.WriteLine("This is a test");
			//#endif
			//			Console.WriteLine("Finishing app");
		}
	}
}
