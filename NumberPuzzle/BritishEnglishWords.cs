using System.Collections.Generic;

namespace NumberPuzzle
{
	public class BritishEnglishWords : IWords
	{
		private readonly Dictionary<int, string> _numberLookupValues = new Dictionary<int, string>
		                                                               	{
		                                                               		{1, "one"},
		                                                               		{2, "two"},
		                                                               		{3, "three"},
		                                                               		{4, "four"},
		                                                               		{5, "five"},
		                                                               		{6, "six"},
		                                                               		{7, "seven"},
		                                                               		{8, "eight"},
		                                                               		{9, "nine"},
		                                                               		{10, "ten"},
		                                                               		{20, "twenty"},
		                                                               		{30, "thirty"},
		                                                               		{40, "forty"},
		                                                               		{50, "fifty"},
		                                                               		{60, "sixty"},
		                                                               		{70, "seventy"},
		                                                               		{80, "eighty"},
		                                                               		{90, "ninety"},
		                                                               	};

		private readonly Dictionary<int, string> _weightingLookupValues = new Dictionary<int, string>
		                                                                  	{
		                                                                  		{100, "hundred"},
		                                                                  		{1000, "thousand"},
		                                                                  		{1000000, "million"}
		                                                                  	};

		public string Conjunction
		{
			get { return "and"; }
		}

		public Dictionary<int, string> NumberLookupValues
		{
			get { return _numberLookupValues; }
		}

		public Dictionary<int, string> WeightingLookupValues
		{
			get { return _weightingLookupValues; }
		}
	}
}