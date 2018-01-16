using NUnit.Framework;

namespace Katas.Tasks
{
	class AddingBigNumbers
	{
		public class Kata
		{
			public static string Add(string a, string b)
			{
				var sum = string.Empty;
				var inMemory = 0;
				while (a.Length > 0 || b.Length > 0)
				{
					var result = TakeLastDigit(ref a) + TakeLastDigit(ref b) + inMemory;
					inMemory = result / 10;
					result = result % 10;

					sum = result + sum;
				}

				if (inMemory > 0)
				{
					sum = inMemory + sum;
				}

				return sum;
			}
			private static int TakeLastDigit(ref string value)
			{
				if (string.IsNullOrEmpty(value))
				{
					return 0;
				}
				var digit = value[value.Length - 1] - 48;
				value = value.Remove(value.Length - 1);

				return digit;
			}
		}


		[TestFixture]
		public class SolutionTest
		{
			[Test]
			public void MyTest()
			{
				Assert.AreEqual("300", Kata.Add("100", "200"));
				Assert.AreEqual("15", Kata.Add("8", "7"));
				Assert.AreEqual("416621935682", Kata.Add("461556731", "416160378951"));
			}
		}
	}
}
