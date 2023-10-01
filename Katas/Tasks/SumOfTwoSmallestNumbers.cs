using System.Linq;

namespace Katas.Tasks
{
	public class SumOfTwoSmallestNumbers
	{
		public static int sumTwoSmallestNumbers(int[] numbers)
		{
			var orderedNumbers = numbers.OrderBy(x => x).ToArray();
			var sum = orderedNumbers[0] + orderedNumbers[1];
			return sum;
		}
	}
}
