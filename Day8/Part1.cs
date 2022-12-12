using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day8
{
	class Part1
	{
		public static List<List<int>> map = new();

		public static void Run()
		{
			var input = File.ReadAllLines("../../../Day8/Input.txt");
			var isVisible = 0;

			foreach(var line in input)
			{
				var row = new List<int>();

				foreach (var tree in line)
				{
					row.Add(Int32.Parse(tree.ToString()));
				}

				map.Add(row);
			}

			for (int i = 0; i < map.Count; i++)
			{
				for (int j = 0; j < map[i].Count; j++)
				{
					if (i == 0 || j == 0)
					{
						isVisible++;
					}
					else if (i == (map.Count - 1) || j == (map[i].Count - 1))
					{
						isVisible++;
					}
					else
					{
						var currentTree = map[i][j];

						var allUp = CalculateUpList(j, i);
						var allDown = CalculateDownList(j, i);
						var allLeft = CalculateLeftList(j, i);
						var allRight = CalculateRightList(j, i);

						if (allUp.All(x => x < currentTree) ||
							allDown.All(x => x < currentTree) ||
							allLeft.All(x => x < currentTree) ||
							allRight.All(x => x < currentTree))
						{
							isVisible++;
						}
					}
				}
			}

			Console.WriteLine(isVisible);

		}

		public static List<int> CalculateUpList(int x, int y)
		{
			var allUp = new List<int>();
			while (y > 0)
			{
				allUp.Add(map[y - 1][x]);
				y--;
			}

			return allUp;
		}

		public static List<int> CalculateDownList(int x, int y)
		{
			var allDown = new List<int>();
			var rows = map.Count;
			while (y < (rows - 1))
			{
				allDown.Add(map[y + 1][x]);
				y++;
			}

			return allDown;
		}

		public static List<int> CalculateLeftList(int x, int y)
		{
			var allLeft = new List<int>();

			while (x > 0)
			{
				allLeft.Add(map[y][x - 1]);
				x--;
			}

			return allLeft;
		}

		public static List<int> CalculateRightList(int x, int y)
		{
			var allRight = new List<int>();
			var columns = map[y].Count;

			while (x < (columns - 1))
			{
				allRight.Add(map[y][x + 1]);
				x++;
			}

			return allRight;
		}
	}
}
