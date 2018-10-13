using NUnit.Framework;

namespace Katas.Tasks
{
	//Euler 119# problem
	public class PowerSumDig
	{
		public static long PowerSumDigTerm(int n)
		{
			var matchesCount = 0;
			for (long number = 81; number < long.MaxValue; number += 1)
			{
				if (IsNumberProductOfItsDigitsSum(number) && ++matchesCount == n)
				{
					return number;
				}
			}

			return 0;
		}

		public static int CalculateDigitsSum(long number)
		{
			var sum = 0;
			var x = number;

			while (x > 0)
			{
				sum += (int)x % 10;
				x = x / 10;
			}

			return sum;
		}

		public static bool IsNumberProductOfItsDigitsSum(long number)
		{
			if (number < 0)
			{
				return false;
			}

			if (number == 0 || number == 1)
			{
				return true;
			}

			var digitsSum = CalculateDigitsSum(number);
			if (digitsSum == 1)
			{
				return false;
			}

			long product = digitsSum;
			do
			{
				var previousProduct = product;
				product *= digitsSum;
				if (product / digitsSum != previousProduct)
				{
					return false; //Overflow has happened
				}

			}
			while (product < number);

			return product == number;
		}
	}

	[TestFixture]
	public static class PowerSumDigTests
	{
		[Test]
		public static void PowerSumDigTerm_Test()
		{
			Assert.AreEqual(PowerSumDig.PowerSumDigTerm(1), 81);
			Assert.AreEqual(PowerSumDig.PowerSumDigTerm(2), 512);
			Assert.AreEqual(PowerSumDig.PowerSumDigTerm(3), 2401);
			Assert.AreEqual(PowerSumDig.PowerSumDigTerm(4), 4913);
			//Assert.AreEqual(PowerSumDig.PowerSumDigTerm(20), 4913);
		}

		[Test]
		public static void CalculateDigitsSum_Test()
		{
			Assert.AreEqual(PowerSumDig.CalculateDigitsSum(0), 0);
			Assert.AreEqual(PowerSumDig.CalculateDigitsSum(1), 1);
			Assert.AreEqual(PowerSumDig.CalculateDigitsSum(10), 1);
			Assert.AreEqual(PowerSumDig.CalculateDigitsSum(100), 1);
			Assert.AreEqual(PowerSumDig.CalculateDigitsSum(237), 12);
			Assert.AreEqual(PowerSumDig.CalculateDigitsSum(456712), 25);
		}

		[Test]
		public static void IsNumberProductOfItsDigitsSum_Test()
		{
			Assert.AreEqual(PowerSumDig.IsNumberProductOfItsDigitsSum(0), true);
			Assert.AreEqual(PowerSumDig.IsNumberProductOfItsDigitsSum(1), true);
			Assert.AreEqual(PowerSumDig.IsNumberProductOfItsDigitsSum(2), false);
			Assert.AreEqual(PowerSumDig.IsNumberProductOfItsDigitsSum(12), false);
			Assert.AreEqual(PowerSumDig.IsNumberProductOfItsDigitsSum(81), true);
			Assert.AreEqual(PowerSumDig.IsNumberProductOfItsDigitsSum(100), false);
			Assert.AreEqual(PowerSumDig.IsNumberProductOfItsDigitsSum(512), true);
			Assert.AreEqual(PowerSumDig.IsNumberProductOfItsDigitsSum(513), false);
		}
	}
}
