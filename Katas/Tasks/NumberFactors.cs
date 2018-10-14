using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Katas.Tasks
{
	class NumberFactors
	{
		public static int[] Factors(int num)
		{
			if (num < 1)
			{
				return new int[0];
			}
			else if (num == 1)
			{
				return new int[] { 1 };
			}

			var factors = new List<int>() { 1, num };
			var maxPossibleFactor = num >> 1;

			for (var factor = 2; factor <= maxPossibleFactor; factor++)
			{
				if (num % factor == 0)
				{
					factors.Add(factor);
				}
			}

			return factors.OrderByDescending(x => x).ToArray();
		}
	}

	[TestFixture]
	public class Tests
	{
		[Test]
		[TestCase(54, ExpectedResult = new int[] { 54, 27, 18, 9, 6, 3, 2, 1 })]
		[TestCase(9, ExpectedResult = new int[] { 9, 3, 1 })]
		public static int[] FixedTest(int num)
		{
			return NumberFactors.Factors(num);
		}
	}
}
