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


		protected SolveResult SolveForMany(ISudokuSquare[] group, SolveResult result, List<int> indicesToCheck, GroupKind groupKind)
		{
			if (!NoteCountsAreSufficient(group, indicesToCheck, out List<List<int>> allNoteNumbers))
				return SolveResult.None;

			// We have N squares that all contain N notes or fewer (in indicesToCheck)!!!
			return SolveForManyWithIndicesToCheck(group, ref result, indicesToCheck, groupKind, allNoteNumbers);
		}

		bool NoteCountsAreSufficient(ISudokuSquare[] group, List<int> indicesToCheck, out List<List<int>> allNoteNumbers)
		{
			allNoteNumbers = new List<List<int>>();
			foreach (int index in indicesToCheck)
			{
				ISudokuSquare square = group[index];
				List<int> squareNoteNumbers = GetNumbers(square.Notes);
				allNoteNumbers.Add(squareNoteNumbers);
				if (squareNoteNumbers.Count < 2 || squareNoteNumbers.Count > indicesToCheck.Count)
					return false;
			}
			return true;
		}

		private SolveResult SolveForManyWithIndicesToCheck(ISudokuSquare[] group, ref SolveResult result, List<int> indicesToCheck, GroupKind groupKind, List<List<int>> allNoteNumbers)
		{
			// We want to add the new logic!
			if (groupKind == GroupKind.Column || groupKind == GroupKind.Row)
			{
				// TODO: Group by block

				Dictionary<int, List<int>> blockMap = new Dictionary<int, List<int>>();

				foreach (int index in indicesToCheck)
				{
					int key = group[index].Block;
					if (!blockMap.ContainsKey(key))
						blockMap.Add(key, new List<int>());

					List<int> allBlockNotes = blockMap[key];
					List<int> notes = GetNumbers(group[index].Notes);
					foreach (int note in notes)
						if (allBlockNotes.IndexOf(note) < 0)
							allBlockNotes.Add(note);
				}

				if (blockMap.Count > 1)
				{
					foreach (int key in blockMap.Keys)
					{
						List<int> targetBlock = blockMap[key];
						List<int> resultsForThisSubtraction = new List<int>();
						resultsForThisSubtraction = targetBlock.ToList();
						foreach (int sourceKey in blockMap.Keys)
						{
							List<int> sourceBlock = blockMap[sourceKey];
							if (targetBlock == sourceBlock)
								continue;

							// We need to subtract!!
							foreach (int note in sourceBlock)
							{
								if (resultsForThisSubtraction.IndexOf(note) >= 0)
									resultsForThisSubtraction.Remove(note);
							}
						}

						// Subtraction for this block is done!

						if (resultsForThisSubtraction.Count > 0)
						{
							// Magic!!! We can remove these from other squares in the targetBlock!
							ISudokuSquare[] blocks = SudokuBoard.GetBlock(key);

							// We need to make sure that any blocks we examine are not among those already in group[indicesToCheck]
						}
					}
				}

				//foreach (List<int> noteNumbers in allNoteNumbers)
				//{

				//}

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

			if (allNumbersFound.Count > indicesToCheck.Count)
				return SolveResult.None;
			else
				for (int i = 0; i < group.Length; i++)
				{
					if (indicesToCheck.Contains(i))
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
