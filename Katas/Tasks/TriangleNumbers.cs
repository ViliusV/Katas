using NUnit.Framework;

namespace Katas.Tasks
{
	class TriangleNumbers
	{
		public static bool isTriangleNumber(long number)
		{
			var sum = 0;
			for (var addend = 0; addend <= number && sum < number; addend++)
			{
				sum += addend;
				if (sum == number)
				{
					return true;
				}
			}

			return false;
		}
	}

	[TestFixture]
	public class TriangleNumbersTests
	{

		[Test]
		public void Test1()
		{
			Assert.AreEqual(true, TriangleNumbers.isTriangleNumber(125250));
		}
		[Test]
		public void Test2()
		{
			Assert.AreEqual(true, TriangleNumbers.isTriangleNumber(3126250));
		}
	}
}
