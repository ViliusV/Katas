using NUnit.Framework;
using static System.Console;
using System;

namespace Solution
{
	public class BinarySum
	{
		public static int Calculate(string num1, string num2)
		{
			var number1 = ConvertToDecimal(num1);
			var number2 = ConvertToDecimal(num2);

			return number1 + number2;
		}

		private static int ConvertToDecimal(string binaryNumber)
		{
			if (string.IsNullOrWhiteSpace(binaryNumber))
			{
				return 0;
			}

			var number = 0;
			for (var id = binaryNumber.Length - 1; id >= 0; id--)
			{
				var symbol = binaryNumber[id];
				if (symbol != '0' && symbol != '1')
				{
					return number;
				}

				if (symbol == '1')
				{
					var power = binaryNumber.Length - id - 1;
					var digit = (int)Math.Pow(2, power);
					number += digit;
				}
			}

			return number;
		}
	}

	[TestFixture]
	public class SolutionTest
	{
		[Test]
		public void BasicTests()
		{
			Assert.AreEqual(2, BinarySum.Calculate("1", "1"));
			Assert.AreEqual(4, BinarySum.Calculate("10", "10"));
			Assert.AreEqual(2, BinarySum.Calculate("10", "0"));
			Assert.AreEqual(3, BinarySum.Calculate("10", "1"));
		}
	}
}