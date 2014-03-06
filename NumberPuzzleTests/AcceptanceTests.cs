using System;
using System.IO;
using NUnit.Framework;
using NumberPuzzle;

namespace NumberPuzzleTests
{
	[TestFixture]
	public class AcceptanceTests
	{
		[TestCase(1, "one")]
		[TestCase(21, "twenty one")]
		[TestCase(105, "one hundred and five")]
		[TestCase(56945781, "fifty six million nine hundred and forty five thousand seven hundred and eighty one")]
		[TestCase(113, "one hundred and thirteen")]
		public void CanConvertExamples(int number, string expected)
		{
			Assert.That(ExecuteProgram(number), Is.EqualTo(expected));
		}

		private static string ExecuteProgram(int input)
		{
			var buffer = new StringWriter();
			Console.SetOut(buffer);
			Program.Main(new[] { input.ToString() });
			return buffer.GetStringBuilder().ToString().Trim();
		}
	}
}
