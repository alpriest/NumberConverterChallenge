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
		}

		private static void Usage()
		{
			Console.WriteLine("{0} <number>", Assembly.GetExecutingAssembly().GetName().Name);
		}
	}
}
