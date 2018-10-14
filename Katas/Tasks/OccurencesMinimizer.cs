using NUnit.Framework;
using System.Collections.Generic;

namespace Katas.Tasks
{
	class OccurencesMinimizer
	{
		public static int[] DeleteNth(int[] arr, int x)
		{
			var repetitions = new Dictionary<int, int>();
			var newSequence = new List<int>();

			foreach (var motive in arr)
			{
				var currentRepetitions = 1;
				if (repetitions.ContainsKey(motive))
				{
					currentRepetitions = ++repetitions[motive];
				}
				else
				{
					repetitions[motive] = currentRepetitions;
				}

				if (currentRepetitions <= x)
				{
					newSequence.Add(motive);
				}
			}

			return newSequence.ToArray();
		}
	}


	[TestFixture]
	public class DeleteNthTests
	{
		[Test]
		public void TestSimple()
		{
			var expected = new int[] { 20, 37, 21 };

			var actual = OccurencesMinimizer.DeleteNth(new int[] { 20, 37, 20, 21 }, 1);

			CollectionAssert.AreEqual(expected, actual);
		}

		[Test]
		public void TestSimple2()
		{
			var expected = new int[] { 1, 1, 3, 3, 7, 2, 2, 2 };

			var actual = OccurencesMinimizer.DeleteNth(new int[] { 1, 1, 3, 3, 7, 2, 2, 2, 2 }, 3);

			CollectionAssert.AreEqual(expected, actual);
		}
	}
}
