using System;
using System.Linq;

namespace Sudoku
{
	public enum SolveResult
	{
		None,
		SquaresSolved
	}
	public interface ISudokuSquare
	{
		char Value { get; }
		string Notes { get; set; }
	}
}
