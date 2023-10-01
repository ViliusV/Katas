using Katas.Tasks;
using System;

namespace Katas
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			var numbers = new int[] { 19, 5, 42, 2, 77 };
			var result = SumOfTwoSmallestNumbers.sumTwoSmallestNumbers(numbers);
			Console.WriteLine(result);
		}
	}
}
