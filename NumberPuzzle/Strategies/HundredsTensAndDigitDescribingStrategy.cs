using System;

namespace NumberPuzzle.Strategies
{
	public class HundredsTensAndDigitDescribingStrategy : BaseDescribingStrategy
	{
		public HundredsTensAndDigitDescribingStrategy(INumberDescriber numberDescriber) : base(numberDescriber)
		{
			base.NumberParts = new Func<HundredGroup, string>[]
			                                     	{
														Hundreds,
			                                     		Conjunction,
			                                     		Teen
			                                     	};
		}
	}
}