using NUnit.Framework;

namespace Katas.Tasks
{
	//https://www.codewars.com/kata/517abf86da9663f1d2000003/train/csharp
	public class CamelCase
	{

		public class Kata
		{
			public static string ToCamelCase(string str)
			{
				var text = string.Empty;
				var isNextUppercase = false;
				foreach (var letter in str)
				{
					if (letter == '_' || letter == '-')
					{
						isNextUppercase = true;
					}
					else
					{
						if (isNextUppercase)
						{
							text += !char.IsUpper(letter) ? char.ToUpper(letter) : letter;
							isNextUppercase = false;
						}
						else
						{
							text += letter;
						}
					}
				}
				return text;
			}
		}

		[TestFixture]
		public class KataTest
		{
			[Test]
			public void KataTests()
			{
				Assert.AreEqual("theStealthWarrior", Kata.ToCamelCase("the_stealth_warrior"), "Kata.ToCamelCase('the_stealth_warrior') did not return correct value");
				Assert.AreEqual("TheStealthWarrior", Kata.ToCamelCase("The-Stealth-Warrior"), "Kata.ToCamelCase('The-Stealth-Warrior') did not return correct value");
			}
		}
	}
}
