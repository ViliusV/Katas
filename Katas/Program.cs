using Katas.Tasks;

namespace Katas
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			for (var id = 1; id < 40; id++)
			{
				long result = PowerSumDig.PowerSumDigTerm(id);
				System.Console.WriteLine($"{id} {result}");
			}
		}
	}
}
