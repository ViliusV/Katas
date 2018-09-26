using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas.Tasks
{
	class DirReduction
	{
		


		public static string[] dirReduc(String[] arr)
		{
			if (arr == null || !arr.Any()) 
			{
				return arr;
			}


			var directions = new List<string>();
			for (int id = 0; id < arr.Count(); id++)
			{
				var direction = arr[id] != null ? arr[id].ToUpper() : null;
				var isUseful = direction != null
					&&  (id == arr.Count() - 1 
						|| direction == "NORTH" && arr[id + 1] != "SOUTH"
						|| direction == "SOUTH" && arr[id + 1] != "NORTH"
						|| direction == "WEST" && arr[id + 1] != "EAST"
						|| direction == "EAST" && arr[id + 1] != "WEST");

				if (isUseful) {
					directions.Add(arr[id]);
				} else {
					id ++;	//Skip non-useful direction
				}
			}

			if (arr.Count() == directions.Count()) {
				return directions.ToArray();	//If both collections are same size, it means that the navigations are minimized
			}

			return dirReduc(directions.ToArray());
		}
	}




	[TestFixture]
	public class DirReductionTests
	{

		[Test]
		public void Test1()
		{
			string[] a = new string[] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" };
			string[] b = new string[] { "WEST" };
			Assert.AreEqual(b, DirReduction.dirReduc(a));
		}
		[Test]
		public void Test2()
		{
			string[] a = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };
			string[] b = new string[] { "NORTH", "WEST", "SOUTH", "EAST" };
			Assert.AreEqual(b, DirReduction.dirReduc(a));
		}
	}
}
