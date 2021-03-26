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
			Collect2x2Notes(group, dictionary);
			return Solve2x2Notes(group, dictionary);
		}

		private SolveResult Solve2x2Notes(ISudokuSquare[] group, Dictionary<string, List<int>> dictionary)
		{
			SolveResult result = SolveResult.None;
			foreach (string key in dictionary.Keys)
			{
				List<int> list = dictionary[key];
				if (list.Count == 2)			// Are there exactly 2 occurrences of the 2-length note (e.g., "1, 2")?
				{
					for (int i = 0; i < group.Length; i++)
					{
						// The ints in the list are the indices of the sudoku squares having this note (key, which could be "1, 2", for example).
						if (list.Contains(i))  // This is one of the two sudoku squares that gave us this note.
							continue;
						if (RemoveNotesFrom(group[i], key) == SolveResult.SquaresSolved)
							result = SolveResult.SquaresSolved;
					}
				}
			}

			return result;
		}

		private static void Collect2x2Notes(ISudokuSquare[] group, Dictionary<string, List<int>> dictionary)
		{
			for (int i = 0; i < group.Length; i++)
			{
				string notes = group[i].Notes;
				if (NoteCount(notes) != 2)
					continue;

				if (!dictionary.ContainsKey(notes))
					dictionary.Add(notes, new List<int>());

				// Add this index (of the sudoku square) to the list, so we track the squares that have this note:
				dictionary[notes].Add(i);
			}
		}
	}
}
