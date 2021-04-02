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

			// We want to add the new logic!
			if (groupKind == GroupKind.Column || groupKind == GroupKind.Row)
			{
				// TODO: Group by block

				foreach (List<int> noteNumbers in allNoteNumbers)
				{
					
				}

				// TODO: Do we have more than one block?
				// Yes? It's magic!!!
				// TODO: Set Subtraction (e.g., b1 - b2) - b1 is the first block we subtract from
				// TODO: Set Subtraction the other (b2 - b1) - so b2 is the first block we subtract from
				// TODO: Anything left over???
				// Yes? Then we can remove those leftover numbers from **all the other squares** in the first block we subtracted from.
				// LaterCommands.Add(new RemoveCommand(b2, "1, 3"));
			}

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
