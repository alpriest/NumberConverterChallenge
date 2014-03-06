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

			var result = new List<string>();
			for (var i = 0; i < numberGroups.Count(); i++)
			{
				result.Add(groupDescriber.Describe(numberGroups[i]));
			}

			if (ShouldInsertConjunctionBeforeFinalGroup(numberGroups))
			{
				result.Insert(result.Count - 1, numberDescriber.Conjunction);
			}

			return string.Join(" ", result.Where(x => !string.IsNullOrEmpty(x)));
		}

		private bool ShouldInsertConjunctionBeforeFinalGroup(IList<WeightedHundredGroup> numberGroups)
		{
			var firstGroups = numberGroups.Take(numberGroups.Count - 1);
			var finalGroup = numberGroups.Skip(numberGroups.Count - 1).First();

			if (GroupHasHundredsValue(finalGroup))
				return false;

			return AnyGroupHasAValue(firstGroups) && GroupHasAValue(finalGroup);
		}

		private static bool GroupHasAValue(WeightedHundredGroup finalGroup)
		{
			return finalGroup.HundredGroup.Number > 0;
		}

		private static bool AnyGroupHasAValue(IEnumerable<WeightedHundredGroup> firstGroups)
		{
			return firstGroups.Any(x => x.HundredGroup.Number > 0);
		}

		private static bool GroupHasHundredsValue(WeightedHundredGroup finalGroup)
		{
			return finalGroup.HundredGroup.Hundreds > 0;
		}

		private IList<WeightedHundredGroup> SplitNumberIntoWeightedHundredGroups(int number)
		{
			const string format = "000,000,000";

			return number
				.ToString(format)
				.Split(',')
				.Select((n, i) => new WeightedHundredGroup(int.Parse(n), _groupWeightings[i]))
				.ToList();
		}
	}
}