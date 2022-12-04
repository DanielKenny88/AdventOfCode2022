using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day4
{
	class Part1
	{
		public static void Run()
		{
			var input = File.ReadAllLines("../../../Day4/Input.txt");
			var counter = 0;

			foreach (var team in input)
			{
				var elf1Task = team.Split(",")[0];
				var elf2Task = team.Split(",")[1];

				var elf1Start = Int32.Parse(elf1Task.Split("-")[0]);
				var elf1End = Int32.Parse(elf1Task.Split("-")[1]);

				var elf2Start = Int32.Parse(elf2Task.Split("-")[0]);
				var elf2End = Int32.Parse(elf2Task.Split("-")[1]);

				if (elf2Start >= elf1Start && elf2End <= elf1End)
				{
					counter++;
				}
				else if (elf1Start >= elf2Start && elf1End <= elf2End)
				{
					counter++;
				}
			}

			Console.WriteLine(counter);
		}
	}
}
