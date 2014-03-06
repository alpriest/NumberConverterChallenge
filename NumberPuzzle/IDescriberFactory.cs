namespace NumberPuzzle
{
	public interface IDescriberFactory
	{
		IHundredGroupDescriber CreateHundredGroupDescriber(INumberDescriber numberDescriber);
	}
}