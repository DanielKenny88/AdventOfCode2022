using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day6
{
	class Part1
	{
		public static void Run()
		{
			var input = File.ReadAllLines("../../../Day6/Input.txt");

			foreach(var line in input)
			{
				for (int i = 0; i < line.Length; i++)
				{
					var markerTrial = line.Substring(i, 4);
					var groups = markerTrial.GroupBy(c => c).Where(g => g.Count() > 1);
					if (groups.Count() == 0)
					{
						Console.WriteLine(markerTrial);
						Console.WriteLine(i + 4);
						break;
					}
				}
			}
		}
	}
}
