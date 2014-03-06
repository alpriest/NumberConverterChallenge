using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using NumberPuzzle;

namespace NumberPuzzleTests
{
	[TestFixture]
	public class NumberDescriberFixture
	{
		[TestCase(1, "one")]
		[TestCase(2, "two")]
		[TestCase(3, "three")]
		[TestCase(4, "four")]
		[TestCase(5, "five")]
		[TestCase(6, "six")]
		[TestCase(7, "seven")]
		[TestCase(8, "eight")]
		[TestCase(9, "nine")]
		[TestCase(10, "ten")]
		[TestCase(11, "eleven")]
		[TestCase(12, "twelve")]
		[TestCase(13, "thirteen")]
		[TestCase(14, "fourteen")]
		[TestCase(15, "fifteen")]
		[TestCase(16, "sixteen")]
		[TestCase(17, "seventeen")]
		[TestCase(18, "eighteen")]
		[TestCase(19, "nineteen")]
		[TestCase(20, "twenty")]
		[TestCase(30, "thirty")]
		[TestCase(40, "forty")]
		[TestCase(50, "fifty")]
		[TestCase(60, "sixty")]
		[TestCase(70, "seventy")]
		[TestCase(80, "eighty")]
		[TestCase(90, "ninety")]
		public void CanDescribeAllUniqueNumbersFromOneToNinety(int number, string expected)
		{
			// Arrange
			var converter = new NumberDescriber(new BritishEnglishWords());

			// Act
			var result = converter.LookupNumber(number);

			// Assert
			Assert.That(result.Description, Is.EqualTo(expected));
		}

		[TestCase(100, "hundred")]
		[TestCase(1000, "thousand")]
		[TestCase(1000000, "million")]
		public void CanDescribeWeightings(int number, string expected)
		{
			// Arrange
			var converter = new NumberDescriber(new BritishEnglishWords());

			// Act
			var result = converter.LookupWeightedName(number);

			// Assert
			Assert.That(result.Description, Is.EqualTo(expected));
		}

		[Test]
		public void ReturnsFalseWhenValueNotFound()
		{
			// Arrange
			var words = new Mock<IWords>();
			words.Setup(x => x.NumberLookupValues).Returns(new Dictionary<int, string>());

			// Act
			var result = new NumberDescriber(new BritishEnglishWords()).LookupNumber(-1);

			// Assert
			Assert.That(result.Found, Is.False);
		}
		
		[Test]
		public void DoesNotFindMultipleWordResults()
		{
			Assert.That(new NumberDescriber(new BritishEnglishWords()).LookupNumber(21).Found, Is.False);
		}
	}
}
