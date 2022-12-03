using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day3
{
	class Part2
	{
		public static void Run()
		{
			var input = File.ReadAllLines("../../../Day3/Input.txt").ToList();

			var commonItems = new List<string>();
			var possibleItems = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
			var totalScore = 0;

			//Find all the badges
			while (input.Count > 0)
			{
				var elf1 = input[0];
				var elf2 = input[1];
				var elf3 = input[2];

				foreach (var item in elf1)
				{
					if (elf2.Contains(item) && elf3.Contains(item))
					{
						commonItems.Add(item.ToString());
						break;
					}
				}

				input.Remove(elf1);
				input.Remove(elf2);
				input.Remove(elf3);
			}

			//Calculate badge values
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
