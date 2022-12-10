using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Day7
{
	class Part1
	{
		public static void Run()
		{
			var input = File.ReadAllLines("../../../Day7/Input.txt");
			//var folders = new Dictionary<string, int>();
			var folders = new SortedDictionary<string, int>(new LengthComparer());
			Dictionary<string, List<string>> children = new();
			var path = "/";
			var pattern = @"^\d+";
			var smallFolders = 0;

			//Find all directories
			foreach (var line in input)
			{
				var commands = line.Split(" ");

				if (line.Contains("$ cd"))
				{
					if (!commands[2].Contains(".."))
					{
						if (commands[2] == "/")
						{
							path = "/";
						}
						else
						{
							if (path == "/")
							{
								path = "";
							}
							path += "/" + commands[2].Trim();
						}
						if (!folders.ContainsKey(path))
						{
							folders.Add(path, 0);
						}
					}
					else
					{
						var pathArray = path.Split("/");
						pathArray = pathArray.SkipLast(1).ToArray();
						path = String.Join("/", pathArray);
					}
				}
				else if (Regex.IsMatch(commands[0], pattern))
				{
					folders[path] += (Int32.Parse(commands[0]));
				}
			}

			var folderKeys = folders.Keys.ToList();

			foreach(var key in folderKeys)
			{
				var keys = key.Split("/");
				keys = keys.SkipLast(1).ToArray();
				var parentKey = String.Join("/", keys);
				if (keys.Length == 1)
				{
					parentKey = "/";
				}
				folders[parentKey] += folders[key];
			}

			foreach (var folder in folders)
			{
				if (folder.Value <= 100000)
				{
					smallFolders += folder.Value;
				}
			}

			Console.WriteLine(smallFolders);
		}
	}
}

