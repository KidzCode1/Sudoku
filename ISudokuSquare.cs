using System;
using System.Linq;

namespace Sudoku
{
	public interface ISudokuSquare
	{
		char Value { get; set; }
		string Notes { get; set; }
		bool IsEmpty { get; }

		int Row { get; set; }
		int Column { get; set; }
		int Block { get; set; }
		bool HasTestValue { get; set; }
		bool HasConflict { get; set; }
		bool Locked { get; set; }
		void SetNotes(string notes);

		void FillFromNotesIfPossible();

		// What? This method maybe shouldn't be here.
		void SetTextNoInternalEvents(string whatChanged);
		void Clear();
		void ClearNotes();

		// TODO: Remove GetText and SetText this and replace with Value (updating logic)
		string GetText();
		void SetText(string str);
	}
}
