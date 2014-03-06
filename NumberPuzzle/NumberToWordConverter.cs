using System.Collections.Generic;
using System.Linq;

namespace NumberPuzzle
{
	public class NumberToWordConverter
	{
		private readonly int[] _groupWeightings = new[] {1000000, 1000, 1};
		private INumberDescriber numberDescriber;
		private IGroupDescriber groupDescriber;

		public NumberToWordConverter() : this(new BritishEnglishWords())
		{
		}

		public NumberToWordConverter(IWords words)
		{
			numberDescriber = new NumberDescriber(words);
			groupDescriber = new WeightedHundredGroupDescriber(numberDescriber, new DescriberFactory());
		}

		public string Convert(int number)
		{
			var numberGroups = SplitNumberIntoWeightedHundredGroups(number);

			return numberGroups
				.Aggregate(string.Empty, (s, @group) => s + groupDescriber.Describe(@group) + " ")
				.Trim();
		}

		private IEnumerable<WeightedHundredGroup> SplitNumberIntoWeightedHundredGroups(int number)
		{
			const string format = "000,000,000";

			return number
				.ToString(format)
				.Split(',')
				.Select((n, i) => new WeightedHundredGroup(int.Parse(n), _groupWeightings[i]));
		}
	}
}