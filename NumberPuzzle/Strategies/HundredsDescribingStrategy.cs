using System;

namespace NumberPuzzle.Strategies
{
	public class HundredsDescribingStrategy : BaseDescribingStrategy
	{
		public HundredsDescribingStrategy(INumberDescriber numberDescriber) : base(numberDescriber)
		{
			base.NumberParts = new Func<HundredGroup, string>[]
			                                     	{
														Hundreds,
			                                     	};
		}
	}
}