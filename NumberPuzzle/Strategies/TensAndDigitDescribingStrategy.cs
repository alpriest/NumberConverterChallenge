using System;

namespace NumberPuzzle.Strategies
{
	public class TensAndDigitDescribingStrategy : BaseDescribingStrategy
	{
		public TensAndDigitDescribingStrategy(INumberDescriber numberDescriber) : base(numberDescriber)
		{
			base.NumberParts = new Func<HundredGroup, string>[]
			                   	{
			                   		Teen
			                   	};
		}
	}
}