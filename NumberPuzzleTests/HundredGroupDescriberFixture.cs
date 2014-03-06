using NUnit.Framework;
using NumberPuzzle;

namespace NumberPuzzleTests
{
	[TestFixture]
	public class HundredGroupDescriberFixture
	{
		[TestCase(1, "one", Description = "Value has only units")]
		[TestCase(10, "ten", Description = "Value has only tens")]
		[TestCase(13, "thirteen", Description = "Value has special case of teen")]
		[TestCase(100, "one hundred", Description = "Value has only hundreds")]
		[TestCase(45, "forty five", Description = "Value has only tens and units")]
		[TestCase(450, "four hundred and fifty", Description = "Value has only hundreds and tens")]
		[TestCase(405, "four hundred and five", Description = "Value has only hundreds and units")]
		[TestCase(455, "four hundred and fifty five", Description = "Value has hundreds, tens and units")]
		public void CanDescribeHundredGroup(int number, string expected)
		{
			// Arrange
			var group = new HundredGroup(number);

			// Act
			var description = new HundredGroupDescriber(new NumberDescriber(new BritishEnglishWords())).Describe(group);

			// Assert
			Assert.That(description, Is.EqualTo(expected));
		}
	}
}