using Katas.Tasks;
using System.Diagnostics;

namespace Katas
{
	internal class Program
	{


		public static void Main(string[] args)
		{
			long result = 0;
			var stopWatch = new Stopwatch();
			
			stopWatch.Start();
			result = PowerSumDig.PowerSumDigTerm(15);
			stopWatch.Stop();
			System.Console.WriteLine($"{result} {stopWatch.ElapsedMilliseconds}ms");
		}
	}
}
