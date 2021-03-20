using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
	public class Solver2x2 : BaseGroupSolver
	{

		public Solver2x2()
		{

		}

		public override SolveResult Solve(ISudokuSquare[] group)
		{
			Dictionary<string, List<int>> dictionary = new Dictionary<string, List<int>>();
			for (int i = 0; i < group.Length; i++)
			{
				string notes = group[i].Notes;
				if (NoteCount(notes) != 2)
					continue;

				if (!dictionary.ContainsKey(notes))
					dictionary.Add(notes, new List<int>());

				dictionary[notes].Add(i);
			}

			SolveResult result = SolveResult.None;
			
			foreach (string key in dictionary.Keys)
			{
				List<int> list = dictionary[key];
				if (list.Count == 2)
				{
					for (int i = 0; i < group.Length; i++)
					{
						if (list.Contains(i))
							continue;
						if (RemoveNotesFrom(group[i], key) == SolveResult.SquaresSolved)
							result = SolveResult.SquaresSolved;
					}
				}
			}
			return result;
		}
	}
}
