using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day5
{
	class Part1
	{
		public static void Run()
		{
			var input = File.ReadAllText("../../../Day5/Input.txt").Split("\r\n\r\n");
			var piles = input[0].Split("\r\n");
			var instructions = input[1].Split("\r\n");
			var stacks = new Dictionary<int, List<string>>();

			//Create Stacks
			foreach (var line in piles)
			{
				if (!line.Contains("1"))
				{
					var pileNumber = 1;
					for (int i = 0; i < line.Length; i += 4)
					{
						var crate = line.Substring(i, 3);
						var content = crate[1].ToString().Trim();

						if (!stacks.ContainsKey(pileNumber))
						{
							stacks[pileNumber] = new List<string>();
						}
						if (content != "")
						{
							var stack = stacks[pileNumber];
							stack.Add(content);
							stacks[pileNumber] = stack;
						}

						pileNumber++;
					}
				}
			}

			//Run instructions
			foreach (var instruction in instructions)
			{
				var pattern = @"\d+";
				var moves = new List<int>();
				foreach (Match match in Regex.Matches(instruction, pattern))
				{
					var number = Int32.Parse(match.Value);
					moves.Add(number);
				}
				var quantity = moves[0];
				var fromPile = moves[1];
				var toPile = moves[2];

				for (int i = 0; i < quantity; i++)
				{
					stacks[toPile].Insert(0, stacks[fromPile].First());
					stacks[fromPile].RemoveAt(0);
				}
			}

			for (int i = 1; i < stacks.Count + 1; i++)
			{
				var pile = stacks[i];
				Console.Write(pile[0]);
			}

		}
	}
}
