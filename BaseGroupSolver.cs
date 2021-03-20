﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Sudoku
{
	public abstract class BaseGroupSolver
	{
		public abstract SolveResult Solve(ISudokuSquare[] group);   // I'm not going to implement it here.

		public List<int> GetNumbers(string notes)
		{
			List<int> result = new List<int>();
			string[] splitStr = notes.Split(',');
			foreach (string item in splitStr)
				if (int.TryParse(item.Trim(), out int parsedNumber))
					result.Add(parsedNumber);

			return result;
		}

		public static int NoteCount(string notes)
		{
			if (notes == null)
				return 0;
			return notes.Count(x => x == ',') + 1;
		}

		public SolveResult RemoveNotesFrom(ISudokuSquare sudokuSquare, string notes)
		{
			if (string.IsNullOrEmpty(sudokuSquare.Notes))
				return SolveResult.None;
			else
			{
				List<int> toRemoveList = GetNumbers(notes);
				List<int> squareNotes = GetNumbers(sudokuSquare.Notes);
				foreach (int numberToRemove in toRemoveList)
					squareNotes.Remove(numberToRemove);

				string newNotes = string.Join(", ", squareNotes);
				if (newNotes != sudokuSquare.Notes)
				{
					sudokuSquare.Notes = newNotes;
					return SolveResult.SquaresSolved;
				}
			}
			return SolveResult.None;
		}
	}
}
