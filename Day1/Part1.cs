using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day1
{
	class Part1
	{
		public static void Run()
		{
			var input = File.ReadAllLines("../../../Day1/Input.txt");

			var totalCalories = 0;
			var highestCalories = 0;

			foreach(var line in input)
			{
				if (line != "")
				{
					totalCalories += Int32.Parse(line);
				}
				else
				{
					if (totalCalories > highestCalories)
					{
						highestCalories = totalCalories;
					}
					totalCalories = 0;
				}
			}
			Console.WriteLine(highestCalories);
		}
	}
}
