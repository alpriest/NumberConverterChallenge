namespace NumberPuzzle
{
	public interface INumberDescriber
	{
		LookupResult LookupNumber(int number);
		LookupResult LookupWeightedName(int weight);
		string Conjunction { get; }
	}
}