using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
	public class Solver3x3 : SolverNxN
	{

		public Solver3x3()
		{

		}

		public override SolveResult Solve(ISudokuSquare[] group, GroupKind groupKind)
		{
			SolveResult result = SolveResult.None;

			for (int first = 0; first < group.Length; first++)
				for (int second = 0; second < group.Length; second++)
					if (second == first)
						continue;
					else
						for (int third = 0; third < group.Length; third++)
							if (third == first || third == second)
								continue;
							else
							{
								List<int> indicesToCheck = new List<int>();
								indicesToCheck.Add(first);
								indicesToCheck.Add(second);
								indicesToCheck.Add(third);
								result = SolveForMany(group, result, indicesToCheck, groupKind);
							}
			return result;
		}
	}
}
