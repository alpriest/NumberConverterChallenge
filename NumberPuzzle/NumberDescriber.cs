using System.Collections.Generic;

namespace NumberPuzzle
{
	public class NumberDescriber : INumberDescriber
	{
		private readonly IWords _words;

		public NumberDescriber(IWords words)
		{
			_words = words;
		}

		public LookupResult LookupNumber(int number)
		{
			return Lookup(number, _words.NumberLookupValues);
		}

		public LookupResult LookupWeightedName(int weight)
		{
			return Lookup(weight, _words.WeightingLookupValues);
		}

		public string Conjunction
		{
			get { return _words.Conjunction; }
		}

		private static LookupResult Lookup(int weight, Dictionary<int, string> dictionary)
		{
			var found = dictionary.ContainsKey(weight);

			return new LookupResult
			       	{
			       		Found = found,
			       		Description = found ? dictionary[weight] : string.Empty
			       	};
		}
	}
}