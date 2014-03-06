using System.Collections.Generic;

namespace NumberPuzzle
{
	public interface IWords
	{
		string Conjunction { get; }
		Dictionary<int, string> NumberLookupValues { get; }
		Dictionary<int, string> WeightingLookupValues { get; }
	}
}