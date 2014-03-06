using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberPuzzle.Strategies
{
	public abstract class BaseDescribingStrategy : INamingStrategy
	{
		private readonly INumberDescriber _numberDescriber;
		protected Func<HundredGroup, string>[] NumberParts;

		protected BaseDescribingStrategy(INumberDescriber numberDescriber)
		{
			_numberDescriber = numberDescriber;
		}

		public string Describe(HundredGroup @group)
		{
			return Concatenate(NumberParts.Select(x => x(@group)));
		}

		protected string Hundreds(HundredGroup @group)
		{
			return DescribeNumber(@group.Hundreds, 100);
		}

		protected string Digit(HundredGroup @group)
		{
			return DescribeNumber(@group.Digit);
		}

		protected string Teen(HundredGroup @group)
		{
			if (IsInTeenRange(@group))
			{
				return DescribeNumber((@group.Tens * 10) + @group.Digit);
			}
			else
			{
				return
					Concatenate(new Func<HundredGroup, string>[]
					            	{
					            		Tens,
					            		Digit
					            	}.Select(x => x(@group)));
			}
		}

		private bool IsInTeenRange(HundredGroup @group)
		{
			var sum = (@group.Tens*10) + @group.Digit;
			return sum > 10 && sum < 20;
		}

		protected string Tens(HundredGroup @group)
		{
			return DescribeNumber(@group.Tens * 10);
		}

		protected string Conjunction(HundredGroup ignored)
		{
			return _numberDescriber.Conjunction;
		}

		private string Concatenate(IEnumerable<string> values)
		{
			return string.Join(" ", values.Where(x => !string.IsNullOrEmpty(x)));
		}

		private string DescribeNumber(int number, int weight = 0)
		{
			var description = _numberDescriber.LookupNumber(number).Description;
			var weightingResult = _numberDescriber.LookupWeightedName(weight);

			if (HasWeighting(weightingResult))
			{
				description += " " + weightingResult.Description;
			}

			return description;
		}

		private bool HasWeighting(LookupResult weightingResult)
		{
			return weightingResult.Found;
		}
	}
}