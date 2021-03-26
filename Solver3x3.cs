using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
	public class Solver3x3: SolverNxN
	{
		
		public Solver3x3()
		{
			
		}

		public override SolveResult Solve(ISudokuSquare[] group)
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
								List<int> indices = new List<int>();
								indices.Add(first);
								indices.Add(second);
								indices.Add(third);
								result = SolveForMany(group, result, indices);
							}
			return result;
		}
	}
}
