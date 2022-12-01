using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day1
{
	class Part2
	{
		public static void Run()
		{
			var input = File.ReadAllLines("../../../Day1/Input.txt");

			var totalCalories = 0;
			var highestThree = 0;
			List<int> totals = new List<int>();

			foreach (var line in input)
			{
				if (line != "")
				{
					totalCalories += Int32.Parse(line);
				}
				else
				{
					totals.Add(totalCalories);
					totalCalories = 0;
				}
			}

			totals.Sort();
			totals.Reverse();

			highestThree += totals[0];
			highestThree += totals[1];
			highestThree += totals[2];

			Console.WriteLine(highestThree);
		}
	}
}
