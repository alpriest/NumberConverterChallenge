using System;
using NumberPuzzle.Strategies;

namespace NumberPuzzle
{
	public class TensAndDigitDescribingStrategy : BaseDescribingStrategy
	{
		public TensAndDigitDescribingStrategy(INumberDescriber numberDescriber) : base(numberDescriber)
		{
			base.NumberParts = new Func<HundredGroup, string>[]
			                   	{
			                   		Tens,
			                   		Digit
			                   	};
		}
	}
}