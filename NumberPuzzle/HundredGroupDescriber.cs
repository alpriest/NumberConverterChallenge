using NumberPuzzle.Strategies;

namespace NumberPuzzle
{
	public class HundredGroupDescriber : IHundredGroupDescriber
	{
		private readonly INumberDescriber _numberDescriber;

		public HundredGroupDescriber(INumberDescriber numberDescriber)
		{
			_numberDescriber = numberDescriber;
		}

		public string Describe(HundredGroup group)
		{
			var strategy = DescribingStrategyFactory.GetDescribingStrategy(_numberDescriber, group);
			return strategy.Describe(group);
		}
	}
}