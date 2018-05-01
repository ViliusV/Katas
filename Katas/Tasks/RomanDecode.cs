using System.Collections.Generic;
using System.Linq;

namespace Katas.Tasks
{
	public class RomanDecode
	{
		private static IDictionary<string, int> _numbers = new Dictionary<string, int>()
		{
			{ "I", 1 },
			{ "V", 5},
			{ "X", 10 },
			{ "L", 50 },
			{ "C", 100 },
			{ "D", 500 },
			{ "M", 1000 }
		};


		public static int Solution(string roman)
		{
			var digits = new List<int>();
			if (string.IsNullOrWhiteSpace(roman))
			{
				return 0;
			}

			foreach (var romanDigit in roman)
			{
				digits.Add(_numbers[romanDigit.ToString()]);
			}

			for (var id = 0; id < digits.Count; id++)
			{
				if (digits.Skip(id + 1).Any(d => d > digits[id]))
				{
					digits[id] *= -1;
				}
			}

			var number = digits.Sum();
			return number;
		}
	}
}
