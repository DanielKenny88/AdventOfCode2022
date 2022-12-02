using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day2
{
	class Part1
	{
		public static void Run()
		{
			var input = File.ReadAllLines("../../../Day2/Input.txt");

			var rockPlayers = input.Where(g => g.Contains("A")).ToArray();
			var paperPlayers = input.Where(g => g.Contains("B")).ToArray();
			var scissorsPlayer = input.Where(g => g.Contains("C")).ToArray();

			var rockScore = CalculateScoreAgainstRockOpponent(rockPlayers);
			var paperScore = CalculateScoreAgainstPaperOpponent(paperPlayers);
			var scissorsScore = CalculateScoreAgainstScissorsOpponent(scissorsPlayer);

			Console.WriteLine(rockScore + paperScore + scissorsScore);
		}

		public static int CalculateScoreAgainstRockOpponent(string[] opponents)
		{
			var totalScore = 0;

			var wins = opponents.Where(r => r.Contains("Y")).ToArray().Length;
			var draws = opponents.Where(r => r.Contains("X")).ToArray().Length;
			var losses = opponents.Where(r => r.Contains("Z")).ToArray().Length;

			totalScore += wins * 8;
			totalScore += draws * 4;
			totalScore += losses * 3;

			return totalScore;
		}

		public static int CalculateScoreAgainstPaperOpponent(string[] opponents)
		{
			var totalScore = 0;

			var wins = opponents.Where(p => p.Contains("Z")).ToArray().Length;
			var draws = opponents.Where(p => p.Contains("Y")).ToArray().Length;
			var losses = opponents.Where(p => p.Contains("X")).ToArray().Length;

			totalScore += wins * 9;
			totalScore += draws * 5;
			totalScore += losses * 1;

			return totalScore;
		}

		public static int CalculateScoreAgainstScissorsOpponent(string[] opponents)
		{
			var totalScore = 0;

			var wins = opponents.Where(s => s.Contains("X")).ToArray().Length;
			var draws = opponents.Where(s => s.Contains("Z")).ToArray().Length;
			var losses = opponents.Where(s => s.Contains("Y")).ToArray().Length;

			totalScore += wins * 7;
			totalScore += draws * 6;
			totalScore += losses * 2;

			return totalScore;
		}
	}
}
