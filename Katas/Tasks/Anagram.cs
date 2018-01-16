using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Katas.Tasks
{
	//https://www.codewars.com/kata/where-my-anagrams-at/csharp
	public class Anagarm
	{

		public static class Kata
		{
			public static List<string> Anagrams(string word, List<string> words)
			{
				var anagrams = new List<string>();
				if (string.IsNullOrWhiteSpace(word) || words == null || !words.Any())
				{
					return anagrams;
				}

				var orderedOriginalWord = string.Concat(word.OrderBy(c => c));
				foreach (var item in words)
				{
					var orderedWord = string.Concat(item.OrderBy(c => c));
					if (orderedWord.Equals(orderedOriginalWord, StringComparison.InvariantCultureIgnoreCase))
					{
						anagrams.Add(item);
					}
				}

				return anagrams;
			}
		}

		[TestFixture]
		public class SolutionTest
		{
			[Test]
			public void SampleTest()
			{
				Assert.AreEqual(new List<string> { "a" }, Kata.Anagrams("a", new List<string> { "a", "b", "c", "d" }));
				Assert.AreEqual(new List<string> { "carer", "arcre", "carre" },
					Kata.Anagrams("racer",
						new List<string> { "carer", "arcre", "carre", "racrs", "racers", "arceer", "raccer", "carrer", "cerarr" }));
			}
		}
	}
}
