using System;
using System.Linq;

namespace Sudoku
{
	public interface ISudokuSquare
	{
		char Value { get; set; }
		string Notes { get; set; }
	}
}
