using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
	public class Solver5x5 : SolverNxN
	{

		public Solver5x5()
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
								for (int fourth = 0; fourth < group.Length; fourth++)
									if (fourth == first || fourth == second || fourth == third)
										continue;
									else
										for (int fifth = 0; fifth < group.Length; fifth++)
											if (fifth == first || fifth == second || fifth == third || fifth == fourth)
												continue;
											else
											{
												List<int> indices = new List<int>();
												indices.Add(first);
												indices.Add(second);
												indices.Add(third);
												indices.Add(fourth);
												indices.Add(fifth);
												result = SolveForMany(group, result, indices);
											}
			return result;
		}
	}
}
