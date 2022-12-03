using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day3
{
	class Part1
	{
		public static void Run()
		{
			var input = File.ReadAllLines("../../../Day3/Input.txt");

			List<string> commonItems = new();
			var possibleItems = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
			var totalScore = 0;

			//Make list of all common items in backpacks
			foreach (var backpack in input)
			{
				var bagContents = backpack.Length;
				var compartment1 = backpack.Substring(0, bagContents / 2);
				var compartment2 = backpack.Substring(bagContents / 2, bagContents /2);

				foreach(var item in compartment1)
				{
					if (compartment2.Contains(item))
					{
						commonItems.Add(item.ToString());
						Console.WriteLine("Common Item: " + item);
						break;
					}
				}
			}

			//Calculate common items numerical value
			foreach (var possibility in possibleItems)
			{
				if (commonItems.Contains(possibility.ToString()))
				{
					var filtered = commonItems.FindAll(i => i.Contains(possibility));
					var numberOfOccurrences = filtered.Count;
					totalScore += numberOfOccurrences * (possibleItems.IndexOf(possibility) + 1);
				}
			}

			Console.WriteLine("total is: " + totalScore);
		}
	}
}
