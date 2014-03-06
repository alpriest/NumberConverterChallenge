namespace NumberPuzzle
{
	public class ArgumentsParser
	{
		private readonly string[] _args;

		public ArgumentsParser(string[] args)
		{
			_args = args;
		}

		public int NumericValue()
		{
			return int.Parse(_args[0]);
		}

		public bool IsValid
		{
			get { return _args.Length == 1 && IsNumeric(_args[0]); }
		}

		private bool IsNumeric(string value)
		{
			int result;
			return int.TryParse(value, out result);
		}
	}
}