using NUnit.Framework;
using System.Collections.Generic;

namespace Katas.Tasks
{
	//Euler 119# problem https://projecteuler.net/problem=119
	public class PowerSumDig
	{
		public static long PowerSumDigTerm(int n)
		{
			const int maxDigitsSum = 170; //That's the biggest possible sum of digits of a C# long-type number (8,999,999,999,999,999,999)	
			var foundNumbers = new List<long>();

			for (var digitsSum = 2; digitsSum <= maxDigitsSum; digitsSum++)
			{
				long product = digitsSum;
				do
				{
					long previousProduct = product;
					product *= digitsSum;
					if (product / digitsSum != previousProduct)
					{
						break;  //Overflow has happened
					}

					if (!foundNumbers.Contains(product) && CalculateDigitsSum(product) == digitsSum)
					{
						foundNumbers.Add(product);
					}

				}
				while (product < long.MaxValue);
			}
			foundNumbers.Sort(); //Numbers are added randomly, so it's necessary to sort them

			if (n <= foundNumbers.Count)
			{
				return foundNumbers[n - 1];
			}
			else
			{
				return 0;
			}
		}

		public static int CalculateDigitsSum(long number)
		{
			var sum = 0;
			var x = number;

			while (x > 0)
			{
				sum += (int)(x % 10);
				x = x / 10;
			}

			return sum;
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
	}
}
