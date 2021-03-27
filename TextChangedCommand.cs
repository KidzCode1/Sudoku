namespace Sudoku
{
	public class TextChangedCommand: Command
	{
		public TextChangedCommand()
		{
		}

		public string WhatChanged { get; }
		public int Row { get; }
		public int Column { get; }
		public string PreviousValue { get; set; }

		public TextChangedCommand(string previousValue, string whatChanged, int row, int column)
		{
			PreviousValue = previousValue;
			WhatChanged = whatChanged;
			Row = row;
			Column = column;
		}

		public override void Execute()
		{
			SudokuBoard.ChangeText(Row, Column, WhatChanged);
		}

		public override void Undo()
		{
			SudokuBoard.ChangeText(Row, Column, PreviousValue);
		}
	}
}
