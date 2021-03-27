using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
	public abstract class SolverNxN : BaseGroupSolver
	{

		public SolverNxN()
		{

		}


		protected SolveResult SolveForMany(ISudokuSquare[] group, SolveResult result, List<int> indices, GroupKind groupKind)
		{
			List<List<int>> allNoteNumbers = new List<List<int>>();
			foreach (int index in indices)
			{
				ISudokuSquare square = group[index];
				List<int> squareNoteNumbers = GetNumbers(square.Notes);
				allNoteNumbers.Add(squareNoteNumbers);
				if (squareNoteNumbers.Count < 2 || squareNoteNumbers.Count > indices.Count)
					return SolveResult.None;
			}

			// We have N squares that all contain N notes or fewer!!!
			List<int> allNumbersFound = new List<int>();
			foreach (List<int> noteNumbers in allNoteNumbers)
				AddNumbersTo(allNumbersFound, noteNumbers);

			if (allNumbersFound.Count > indices.Count)
				return SolveResult.None;
			else
				for (int i = 0; i < group.Length; i++)
				{
					if (indices.Contains(i))
						continue;

					// We can actually remove!!!
					if (RemoveNotesFrom(group[i], string.Join(", ", allNumbersFound)) == SolveResult.SquaresSolved)
						result = SolveResult.SquaresSolved;
				}

			return result;
		}

		private static void AddNumbersTo(List<int> targetNumbers, List<int> sourceNumbers)
		{
			foreach (int number in sourceNumbers)
				if (!targetNumbers.Contains(number))
					targetNumbers.Add(number);
		}
	}
}
