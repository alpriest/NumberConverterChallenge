namespace NumberPuzzle.Strategies
{
	public class DescribingStrategyFactory
	{
		public static INamingStrategy GetDescribingStrategy(INumberDescriber numberDescriber, HundredGroup @group)
		{
			if (HasHundreds(@group) && HasTensOrDigit(@group))
				return new HundredsTensAndDigitDescribingStrategy(numberDescriber);
			else if (HasHundreds(group))
				return new HundredsDescribingStrategy(numberDescriber);
			else
				return new TensAndDigitDescribingStrategy(numberDescriber);
		}

		private static bool HasTensOrDigit(HundredGroup @group)
		{
			return @group.Tens + @group.Digit > 0;
		}

		private static bool HasHundreds(HundredGroup @group)
		{
			return @group.Hundreds > 0;
		}
	}
}