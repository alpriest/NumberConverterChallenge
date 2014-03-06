namespace NumberPuzzle
{
	public class DescriberFactory : IDescriberFactory
	{
		public IHundredGroupDescriber CreateHundredGroupDescriber(INumberDescriber numberDescriber)
		{
			return new HundredGroupDescriber(numberDescriber);
		}
	}
}