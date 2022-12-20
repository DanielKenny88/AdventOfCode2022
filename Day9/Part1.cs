using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day9
{
	class Part1
	{
		public static void Run()
		{
			var input = File.ReadAllLines("../../../Day9/Input.txt");
			var tailLocations = new List<string>();
			var a = 0;
			var b = 0;
			var x = 0;
			var y = 0;

			foreach (var line in input)
			{
				var direction = line.Split(" ")[0];
				var spaces = Int32.Parse(line.Split(" ")[1]);

				for (int i = 0; i < spaces; i++)
				{
					if (direction == "U")
					{
						b++;
						if (a == x && b > (y + 1))
						{
							y++;
						}
						else if ((a > x || a < x) && b > (y + 1))
						{
							x = a;
							y++;
						}
					}
					else if (direction == "D")
					{
						b--;
						if (a == x && b < (y - 1))
						{
							y--;
						}
						else if ((a > x || a < x) && b < (y - 1))
						{
							x = a;
							y--;
						}
					}
					else if (direction == "L")
					{
						a--;
						if (b == y && a < (x - 1))
						{
							x--;
						}
						else if ((b < y || b > y) && a < (x - 1))
						{
							y = b;
							x--;
						}
					}
					else if (direction == "R")
					{
						a++;
						if (b == y && a > (x + 1))
						{
							x++;
						}
						else if ((b < y || b > y) && a > (x + 1))
						{
							y = b;
							x++;
						}
					}
					tailLocations.Add($"{x},{y}");
				}
			}

			var unique = tailLocations.Distinct().ToList();
			Console.WriteLine(unique.Count());
		}
	}
}
