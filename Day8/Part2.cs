using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day8
{
	class Part2
	{
		public static List<List<int>> map = new();

		public static void Run()
		{
			var input = File.ReadAllLines("../../../Day8/Input.txt");
			var isVisible = 0;
			var bestScore = 0;

			foreach (var line in input)
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

						var score = allUp * allDown * allLeft * allRight;

						if (score > bestScore)
						{
							bestScore = score;
						}
					}
				}
			}

			Console.WriteLine(bestScore);

		}

		public static int CalculateUpList(int x, int y)
		{
			var allUp = 0;
			var currentTreeHeight = map[y][x];
			while (y > 0)
			{
				if (map[y-1][x] < currentTreeHeight)
				{
					allUp++;
					y--;
				}
				else if (map[y - 1][x] == currentTreeHeight)
				{
					allUp++;
					break;
				}
				else
				{
					allUp++;
					break;
				}
			}

			return allUp;
		}

		public static int CalculateDownList(int x, int y)
		{
			var allDown = 0;
			var currentTreeHeight = map[y][x];
			var rows = map.Count;
			while (y < (rows - 1))
			{
				if (map[y+1][x] < currentTreeHeight)
				{
					allDown++;
					y++;
				}
				else if (map[y + 1][x] == currentTreeHeight)
				{
					allDown++;
					break;
				}
				else
				{
					allDown++;
					break;
				}

			}

			return allDown;
		}

		public static int CalculateLeftList(int x, int y)
		{
			var allLeft = 0;
			var currentTreeHeight = map[y][x];

			while (x > 0)
			{
				if (map[y][x-1] < currentTreeHeight)
				{
					allLeft++;
					x--;
				}
				else if (map[y][x - 1] == currentTreeHeight)
				{
					allLeft++;
					break;
				}
				else
				{
					allLeft++;
					break;
				}
			}

			return allLeft;
		}

		public static int CalculateRightList(int x, int y)
		{
			var allRight = 0;
			var columns = map[y].Count;
			var currentTreeHeight = map[y][x];

			while (x < (columns - 1))
			{
				if (map[y][x+1] < currentTreeHeight)
				{
					allRight++;
					x++;
				}
				else if (map[y][x + 1] == currentTreeHeight)
				{
					allRight++;
					break;
				}
				else
				{
					allRight++;
					break;
				}

			}

			return allRight;
		}
	}
}
