namespace NumberPuzzle
{
	public class WeightedHundredGroupDescriber : IGroupDescriber
	{
		private readonly INumberDescriber _numberDescriber;
		private readonly IHundredGroupDescriber _groupDescriber;

		public WeightedHundredGroupDescriber(INumberDescriber numberDescriber, IDescriberFactory describerFactory)
		{
			_numberDescriber = numberDescriber;
			_groupDescriber = describerFactory.CreateHundredGroupDescriber(numberDescriber);
		}

		public string Describe(WeightedHundredGroup @group)
		{
			var description = _groupDescriber.Describe(@group.HundredGroup);

			if (GroupHasDescription(description) && HasWeighting(@group.Weighting))
			{
				var weightedResult = _numberDescriber.LookupWeightedName(@group.Weighting);
				description += " " + weightedResult.Description;
			}

			return description;
		}

		private bool HasWeighting(int weighting)
		{
			return _numberDescriber.LookupWeightedName(weighting).Found;
		}

		private static bool GroupHasDescription(string description)
		{
			return !string.IsNullOrWhiteSpace(description);
		}
	}
}