
using System;
using System.Linq;

namespace Sudoku
{
	public static class SudokuBoard
	{
		public static ISudokuSquare[,] squares = new XamlSudokuSquare[9, 9];
		static ISudokuSquare selectedSquare;

		public static void Initialize()
		{
			for (int row = 0; row < 9; row++)
				for (int column = 0; column < 9; column++)
				{
					squares[row, column].Row = row;
					squares[row, column].Column = column;
					int rowOffset;
					if (row < 3)  // blocks 1, 2, or 3
						rowOffset = 0;
					else if (row < 6)
						rowOffset = 3;
					else
						rowOffset = 6;

					if (column < 3)
						squares[row, column].Block = rowOffset + 1;
					else if (column < 6)
						squares[row, column].Block = rowOffset + 2;
					else
						squares[row, column].Block = rowOffset + 3;
				}
		}

		public static XamlSudokuSquare SelectedSquare
		{
			get => SudokuBoard.selectedSquare as XamlSudokuSquare;
			set
			{
				if (selectedSquare == value)
					return;

				ISudokuSquare oldSelectedSquare = selectedSquare;
				if (oldSelectedSquare is XamlSudokuSquare oldSquare)
					oldSquare.HideSelection();

				selectedSquare = value;
				if (selectedSquare is XamlSudokuSquare sudokuSquare)
					sudokuSquare.ShowSelection();
			}
		}

		static void SelectSquare(ISudokuSquare sudokuSquare)
		{
			SelectedSquare = sudokuSquare as XamlSudokuSquare;
		}

		public static void SelectSquare(int row, int column)
		{
			if (column >= 9)
				column -= 9;

			if (column < 0)
				column += 9;

			if (row >= 9)
				row -= 9;

			if (row < 0)
				row += 9;

			SelectSquare(squares[row, column]);
		}

		public static void SelectFirstSquare()
		{
			SelectSquare(squares[0, 0]);
		}

		public static void AddSquare(int row, int column, XamlSudokuSquare sudokuSquare)
		{
			squares[row, column] = sudokuSquare;
		}

		public static void ChangeText(int row, int column, string whatChanged)
		{
			squares[row, column].SetTextNoInternalEvents(whatChanged);
		}
	}
}
