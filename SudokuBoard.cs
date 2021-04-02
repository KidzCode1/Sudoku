
using System;
using System.Linq;

namespace Sudoku
{
	public static class SudokuBoard
	{
		public static SudokuSquare[,] squares = new SudokuSquare[9, 9];
		static SudokuSquare selectedSquare;

		public static SudokuSquare SelectedSquare
		{
			get => SudokuBoard.selectedSquare;
			set
			{
				if (selectedSquare == value)
					return;

				SudokuSquare oldSelectedSquare = selectedSquare;
				if (oldSelectedSquare != null)
					oldSelectedSquare.HideSelection();

				selectedSquare = value;
				selectedSquare.ShowSelection();
			}
		}

		public static void SelectFirstSquare()
		{
			SelectedSquare = squares[0, 0];
		}

		public static void AddSquare(int row, int column, SudokuSquare sudokuSquare)
		{
			squares[row, column] = sudokuSquare;
		}

		public static void ChangeText(int row, int column, string whatChanged)
		{
			squares[row, column].SetTextNoInternalEvents(whatChanged);
		}
	}
}
