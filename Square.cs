using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace Sudoku
{
	public class Square
	{
		public SudokuSquare TextBox { get; set; }
		public string Notes { get; set; }
		public bool Locked { get; set; }

		public Square(SudokuSquare textBox)
		{
			TextBox = textBox;
		}

		public Square()
		{

		}

		internal void ShowSelection()
		{
			TextBox.Background = new SolidColorBrush(Color.FromRgb(255, 244, 176));
			TextBox.Focus();
		}

		public void HideSelection()
		{
			TextBox.Background = null;
		}
	}
}
