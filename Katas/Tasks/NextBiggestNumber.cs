using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Katas.Tasks
{
	partial class Kata
	{
		public static long NextBiggerNumber(long n)
		{
			if (n < 10)
			{
				return -1;
			}

			//ToDo: Heaps algorithm

			var digits = GetDigits(n);
			var multiplier = 1;
			var number = 0;
			for (var id = digits.Count - 1; id >= 0; id--)
			{
				number += digits[id] * multiplier;
				multiplier *= 10;
			}

			return number;
		}

		private static List<byte> GetDigits(long n)
		{
			var number = n;
			var digits = new List<byte>();
			while (number > 0)
			{
				digits.Add((byte)(number % 10));
				number = number / 10;
			}

			return digits;

		}
	}

	[TestFixture]
	public class NextBiggerNumberTests
	{
		[Test]
		public void Test1()
		{
			Console.WriteLine("****** Small Number");
			Assert.AreEqual(21, Kata.NextBiggerNumber(12));
			Assert.AreEqual(531, Kata.NextBiggerNumber(513));
			Assert.AreEqual(2071, Kata.NextBiggerNumber(2017));
			Assert.AreEqual(441, Kata.NextBiggerNumber(414));
			Assert.AreEqual(414, Kata.NextBiggerNumber(144));
		}
	}
}
