using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Katas.Tasks
{
	class HumanReadableTime
	{
		public static string GetReadableTime(int seconds)
		{
			var hours = seconds / 3600;
			var remainingSeconds = seconds % 3600;

			var minutes = remainingSeconds / 60;
			remainingSeconds = remainingSeconds % 60;

			var time = $"{hours:D2}:{minutes:D2}:{remainingSeconds:D2}";
			return time;
		}
	}
}
