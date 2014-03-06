using System;
using System.Reflection;

namespace NumberPuzzle
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var argsParser = new ArgumentsParser(args);
			if (!argsParser.IsValid)
			{
				Usage();
				return;
			}

			Console.WriteLine(new NumberToWordConverter().Convert(argsParser.NumericValue()));
			Console.ReadLine();
		}

		private static void Usage()
		{
			Console.WriteLine("Please specify a number on the command line.\r\n\r\nUsage: {0} <number>", Assembly.GetExecutingAssembly().GetName().Name);
			Console.ReadLine();
		}
	}
}
