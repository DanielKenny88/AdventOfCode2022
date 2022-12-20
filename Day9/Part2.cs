using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day9
{
	class Part2
	{

		public static void Run()
		{
			var input = File.ReadAllLines("../../../Day9/Input.txt");
			var tailLocations = new List<string>();
			tailLocations.Add("0,0");
			var allLocations = new List<string>();
			for (int i = 0; i < 10; i++)
			{
				allLocations.Add("0,0");
			}
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
					for (var j=0; j < allLocations.Count() - 1; j++)
					{
						a = Int32.Parse(allLocations[j].Split(",")[0]);
						b = Int32.Parse(allLocations[j].Split(",")[1]);
						x = Int32.Parse(allLocations[j + 1].Split(",")[0]);
						y = Int32.Parse(allLocations[j + 1].Split(",")[1]);
						var newHeadLocation = "";
						var newTailLocation = "";

						if (direction == "U")
						{
							if (j == 0)
							{
								b++;
							}

							var spacesAway = Math.Abs(a - x) + Math.Abs(b - y);
							if (a == x && b > (y + 1))
							{
								y++;
							}
							else if (spacesAway >= 3)
							{
								if (a > x)
								{
									x++;
								}
								else if (a < x)
								{
									x--;
								}
								if (b > y)
								{
									y++;
								}
								else if (b < y)
								{
									y--;
								}
							}
							else if (b == y && a > (x + 1))
							{
								x++;
							}
							else if (b == y && a < (x - 1))
							{
								x--;
							}
							else
							{
								newHeadLocation = $"{a},{b}";
								newTailLocation = $"{x},{y}";
								allLocations[j] = newHeadLocation;
								allLocations[j + 1] = newTailLocation;
								break;
							}
						}
						else if (direction == "D")
						{
							if (j == 0)
							{
								b--;
							}
							var spacesAway = Math.Abs(a - x) + Math.Abs(b - y);
							if (a == x && b < (y - 1))
							{
								y--;
							}
							else if (spacesAway >= 3)
							{
								if (a > x)
								{
									x++;
								}
								else if (a < x)
								{
									x--;
								}
								if (b > y)
								{
									y++;
								}
								else if (b < y)
								{
									y--;
								}
							}
							else if (b == y && a > (x + 1))
							{
								x++;
							}
							else if (b == y && a < (x - 1))
							{
								x--;
							}
							else
							{
								newHeadLocation = $"{a},{b}";
								newTailLocation = $"{x},{y}";
								allLocations[j] = newHeadLocation;
								allLocations[j + 1] = newTailLocation;
								break;
							}
						}
						else if (direction == "L")
						{
							if (j == 0)
							{
								a--;
							}
							var spacesAway = Math.Abs(a - x) + Math.Abs(b - y);
							if (b == y && a < (x - 1))
							{
								x--;
							}
							else if (spacesAway >= 3)
							{
								if (b > y)
								{
									y++;
								}
								else if (b < y)
								{
									y--;
								}
								if (a > x)
								{
									x++;
								}
								else if (a < x)
								{
									x--;
								}
							}
							else if (a == x && b > (y + 1))
							{
								y++;
							}
							else if (a == x && b < (y - 1))
							{
								y--;
							}
							else
							{
								newHeadLocation = $"{a},{b}";
								newTailLocation = $"{x},{y}";
								allLocations[j] = newHeadLocation;
								allLocations[j + 1] = newTailLocation;
								break;
							}
						}
						else if (direction == "R")
						{
							if (j == 0)
							{
								a++;
							}
							var spacesAway = Math.Abs(a - x) + Math.Abs(b - y);
							if (b == y && a > (x + 1))
							{
								x++;
							}
							else if (spacesAway >= 3)
							{
								if (b > y)
								{
									y++;
								}
								else if (b < y)
								{
									y--;
								}
								if (a > x)
								{
									x++;
								}
								else if (a < x)
								{
									x--;
								}
							}
							else if (a == x && b > (y + 1))
							{
								y++;
							}
							else if (a == x && b < (y - 1))
							{
								y--;
							}
							else
							{
								newHeadLocation = $"{a},{b}";
								newTailLocation = $"{x},{y}";
								allLocations[j] = newHeadLocation;
								allLocations[j + 1] = newTailLocation;
								break;
							}
						}

						newHeadLocation = $"{a},{b}";
						newTailLocation = $"{x},{y}";
						allLocations[j] = newHeadLocation;
						allLocations[j + 1] = newTailLocation;

						if (j == allLocations.Count - 1)
						{
							tailLocations.Add($"{x},{y}");
						}
					}
					tailLocations.Add(allLocations[9]);
				}

			}
			var unique = tailLocations.Distinct().ToList();
			Console.WriteLine(unique.Count());
		}
	}
}
