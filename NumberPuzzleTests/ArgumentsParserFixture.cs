using NUnit.Framework;
using NumberPuzzle;

namespace NumberPuzzleTests
{
	[TestFixture]
	public class ArgumentsParserFixture
	{
		[Test]
		public void IsValidWithSingleNumericArgument()
		{
			Assert.That(new ArgumentsParser(new[] { "52" }).IsValid, Is.True);
		}

		[Test]
		public void IsInvalidWithSingleNonNumericArgument()
		{
			Assert.That(new ArgumentsParser(new[] { "abc" }).IsValid, Is.False);
		}

		[Test]
		public void ParsesSingleNumericArgument()
		{
			Assert.That(new ArgumentsParser(new[] { "52" }).NumericValue(), Is.EqualTo(52));
		}
	}
}
