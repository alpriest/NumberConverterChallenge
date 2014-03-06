using NUnit.Framework;
using NumberPuzzle;

namespace NumberPuzzleTests
{
	[TestFixture]
	public class HundredGroupFixture
	{
		[TestCase(1, 1, 0, 0)]
		[TestCase(11, 1, 1, 0)]
		[TestCase(111, 1, 1, 1)]
		public void CanConvertNumberBetween1And999ToHundredGroup(int inputNumber, int expectedDigit, int expectedTens, int expectedHundreds)
		{
			// Act
			var result = new HundredGroup(inputNumber);

			// Assert
			Assert.That(result.Digit, Is.EqualTo(expectedDigit));
			Assert.That(result.Tens, Is.EqualTo(expectedTens));
			Assert.That(result.Hundreds, Is.EqualTo(expectedHundreds));
		}
	}
}