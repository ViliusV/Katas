using System;
using System.Threading.Tasks;

namespace ConsoleSandbox
{
	public class AsyncNumbers
	{
		public async static Task WriteNumbersAsync()
		{
			Console.WriteLine($"{nameof(WriteNumbersAsync)} start");
			for (var number = 1; number <= 5; number++)
			{
				await Task.Delay(1); //While waiting for Task.Delay to finish, the control returns to the caller of WriteNumbersAsync
				Console.WriteLine(number);
			}
			Console.WriteLine($"\n{nameof(WriteNumbersAsync)} end");
		}
	}
}
