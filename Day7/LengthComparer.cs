using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day7
{
	class LengthComparer : IComparer<String>
	{
		public int Compare(string x, string y)
		{
			var lengthComparison = y.Length.CompareTo(x.Length);
			if (lengthComparison == 0)
			{
				return y.CompareTo(x);
			}
			return lengthComparison;
		}
	}
}
