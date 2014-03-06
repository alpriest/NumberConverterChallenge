using System;
using NUnit.Framework;
using NumberPuzzle;
using NumberPuzzle.Strategies;

namespace NumberPuzzleTests
{
	[TestFixture]
	public class DescribingStrategyFactoryFixture
	{
		[TestCase(100, typeof(HundredsDescribingStrategy))]
		[TestCase(56, typeof(TensAndDigitDescribingStrategy))]
		[TestCase(123, typeof(HundredsTensAndDigitDescribingStrategy))]
		public void ReturnsCorrectStrategy(int number, Type expected)
		{
			Assert.That(GetDescribingStrategy(number), Is.TypeOf(expected));
		}

		private static INamingStrategy GetDescribingStrategy(int number)
		{
			return DescribingStrategyFactory.GetDescribingStrategy(null, new HundredGroup(number));
		}
	}
}
