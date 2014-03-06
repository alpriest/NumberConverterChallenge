namespace NumberPuzzle
{
	public class HundredGroup
	{
		public int Number { get; private set; }
		public int Digit { get; set; }
		public int Tens { get; set; }
		public int Hundreds { get; set; }

		public HundredGroup(int number)
		{
			var paddedNumber = number.ToString("000");
			Number = number;
			Digit = NumberAtPosition(paddedNumber, 2);
			Tens = NumberAtPosition(paddedNumber, 1);
			Hundreds = NumberAtPosition(paddedNumber, 0);
		}

		private static int NumberAtPosition(string paddedNumber, int position)
		{
			return int.Parse(paddedNumber.Substring(position, 1));
		}
	}
}