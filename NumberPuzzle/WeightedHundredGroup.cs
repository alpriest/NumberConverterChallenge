namespace NumberPuzzle
{
	public class WeightedHundredGroup
	{
		public HundredGroup HundredGroup { get; private set; }

		public int Weighting { get; private set; }

		public WeightedHundredGroup(int number, int weighting)
		{
			HundredGroup = new HundredGroup(number);
			Weighting = weighting;
		}
	}
}