using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
	public class Solver3x3 : BaseGroupSolver
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
					{
						for (int third = 0; third < group.Length; third++)
							if (third == first || third == second)
								continue;
							else
							{
								// Magic! I've got three squares!
								ISudokuSquare firstSquare = group[first];
								List<int> firstNoteNumbers = GetNumbers(firstSquare.Notes);
								if (firstNoteNumbers.Count < 2 || firstNoteNumbers.Count > 3)
									continue;

								ISudokuSquare secondSquare = group[second];
								List<int> secondNoteNumbers = GetNumbers(secondSquare.Notes);
								if (secondNoteNumbers.Count < 2 || secondNoteNumbers.Count > 3)
									continue;

								ISudokuSquare thirdSquare = group[third];
								List<int> thirdNoteNumbers = GetNumbers(thirdSquare.Notes);
								if (thirdNoteNumbers.Count < 2 || thirdNoteNumbers.Count > 3)
									continue;

								// Super magic!!!
								// We have three squares that all contain 2 or 3 notes!!!
								List<int> allNumbersFound = new List<int>();
								AddNumbersTo(allNumbersFound, firstNoteNumbers);
								AddNumbersTo(allNumbersFound, secondNoteNumbers);
								AddNumbersTo(allNumbersFound, thirdNoteNumbers);
								if (allNumbersFound.Count > 3)
									continue;
								else
								{
									for (int i = 0; i < group.Length; i++)
									{
										if (i == first || i == second || i == third)
											continue;
										// Now we can actually remove!!!
										if (RemoveNotesFrom(group[i], string.Join(", ", allNumbersFound)) == SolveResult.SquaresSolved)
											result = SolveResult.SquaresSolved;
									}
								}
							}
					}
			return result;
		}

		private static void AddNumbersTo(List<int> allNumbersFound, List<int> firstNoteNumbers)
		{
			foreach (int number in firstNoteNumbers)
				if (!allNumbersFound.Contains(number))
					allNumbersFound.Add(number);
		}
	}
}
