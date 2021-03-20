using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sudoku
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		SudokuSquare[,] squares = new SudokuSquare[9, 9];
		SudokuSquare selectedSquare;
		public static string availableChars;
		public SudokuSquare SelectedSquare
		{
			get => selectedSquare;
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
		public MainWindow()
		{
			InitializeComponent();
			squares[0, 0] = tbx0_0;
			squares[0, 1] = tbx0_1;
			squares[0, 2] = tbx0_2;
			squares[0, 3] = tbx0_3;
			squares[0, 4] = tbx0_4;
			squares[0, 5] = tbx0_5;
			squares[0, 6] = tbx0_6;
			squares[0, 7] = tbx0_7;
			squares[0, 8] = tbx0_8;

			squares[1, 0] = tbx1_0;
			squares[1, 1] = tbx1_1;
			squares[1, 2] = tbx1_2;
			squares[1, 3] = tbx1_3;
			squares[1, 4] = tbx1_4;
			squares[1, 5] = tbx1_5;
			squares[1, 6] = tbx1_6;
			squares[1, 7] = tbx1_7;
			squares[1, 8] = tbx1_8;

			squares[2, 0] = tbx2_0;
			squares[2, 1] = tbx2_1;
			squares[2, 2] = tbx2_2;
			squares[2, 3] = tbx2_3;
			squares[2, 4] = tbx2_4;
			squares[2, 5] = tbx2_5;
			squares[2, 6] = tbx2_6;
			squares[2, 7] = tbx2_7;
			squares[2, 8] = tbx2_8;
			squares[3, 0] = tbx3_0;
			squares[3, 1] = tbx3_1;
			squares[3, 2] = tbx3_2;
			squares[3, 3] = tbx3_3;
			squares[3, 4] = tbx3_4;
			squares[3, 5] = tbx3_5;
			squares[3, 6] = tbx3_6;
			squares[3, 7] = tbx3_7;
			squares[3, 8] = tbx3_8;
			squares[4, 0] = tbx4_0;
			squares[4, 1] = tbx4_1;
			squares[4, 2] = tbx4_2;
			squares[4, 3] = tbx4_3;
			squares[4, 4] = tbx4_4;
			squares[4, 5] = tbx4_5;
			squares[4, 6] = tbx4_6;
			squares[4, 7] = tbx4_7;
			squares[4, 8] = tbx4_8;
			squares[5, 0] = tbx5_0;
			squares[5, 1] = tbx5_1;
			squares[5, 2] = tbx5_2;
			squares[5, 3] = tbx5_3;
			squares[5, 4] = tbx5_4;
			squares[5, 5] = tbx5_5;
			squares[5, 6] = tbx5_6;
			squares[5, 7] = tbx5_7;
			squares[5, 8] = tbx5_8;
			squares[6, 0] = tbx6_0;
			squares[6, 1] = tbx6_1;
			squares[6, 2] = tbx6_2;
			squares[6, 3] = tbx6_3;
			squares[6, 4] = tbx6_4;
			squares[6, 5] = tbx6_5;
			squares[6, 6] = tbx6_6;
			squares[6, 7] = tbx6_7;
			squares[6, 8] = tbx6_8;
			squares[7, 0] = tbx7_0;
			squares[7, 1] = tbx7_1;
			squares[7, 2] = tbx7_2;
			squares[7, 3] = tbx7_3;
			squares[7, 4] = tbx7_4;
			squares[7, 5] = tbx7_5;
			squares[7, 6] = tbx7_6;
			squares[7, 7] = tbx7_7;
			squares[7, 8] = tbx7_8;
			squares[8, 0] = tbx8_0;
			squares[8, 1] = tbx8_1;
			squares[8, 2] = tbx8_2;
			squares[8, 3] = tbx8_3;
			squares[8, 4] = tbx8_4;
			squares[8, 5] = tbx8_5;
			squares[8, 6] = tbx8_6;
			squares[8, 7] = tbx8_7;
			squares[8, 8] = tbx8_8;

			HookEvents();

			SelectedSquare = squares[0, 0];
		}

		private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Right)
			{
				GetSquarePosition(SelectedSquare, out int row, out int column);
				SelectSquare(row, column + 1);
			}

			if (e.Key == Key.Left)
			{
				GetSquarePosition(SelectedSquare, out int row, out int column);
				SelectSquare(row, column - 1);
			}

			if (e.Key == Key.Down)
			{
				GetSquarePosition(SelectedSquare, out int row, out int column);
				SelectSquare(row + 1, column);
			}

			if (e.Key == Key.Up)
			{
				GetSquarePosition(SelectedSquare, out int row, out int column);
				SelectSquare(row - 1, column);
			}
		}

		void SelectSquare(int row, int column)
		{
			if (column >= 9)
				column -= 9;

			if (column < 0)
				column += 9;

			if (row >= 9)
				row -= 9;

			if (row < 0)
				row += 9;

			SelectedSquare = squares[row, column];
		}

		void GetSquarePosition(SudokuSquare square, out int row, out int column)
		{
			for (int c = 0; c < 9; c++)
				for (int r = 0; r < 9; r++)
					if (squares[r, c] == square)
					{
						row = r;
						column = c;
						return;
					}
			row = -1;
			column = -1;
		}

		void SetAvailableCharacters()
		{
			availableChars = tbxAvailableCharacter.Text.Trim();
			if (availableChars.Length != 9)
				Background = new SolidColorBrush(Colors.Red);
			else
				Background = new SolidColorBrush(Colors.White);
		}

		private void tbxAvailableCharacter_TextChanged(object sender, TextChangedEventArgs e)
		{
			SetAvailableCharacters();
		}


		// ![](39E2DF101A5C3558D58B7B46582D30B6.png;;;0.01546,0.01546)
		string easyGame = @"53  7
6  195
 98    6
8   6   3
4  8 3  1
7   2   6
 6    28 
   419  5
    8  79
";

		string hardGame = @"6     53
     27
5 7 96 18
  6  1 8
 98
    2
      9
   2   43
31   9 62";
		string mediumGame = @"         
     3 85
  1 2    
   5 7   
  4   1  
 9       
5      73
  2 1    
    4   9";

		void ClearGame()
		{
			ClearAllConflicts();

			for (int c = 0; c < 9; c++)
				for (int r = 0; r < 9; r++)
					squares[r, c].Clear();
		}

		void AddValuesForLine(int row, string line)
		{
			for (int column = 0; column < line.Length; column++)
			{
				char chr = line[column];
				if (chr != ' ')
				{
					squares[row, column].SetText(chr.ToString());
					squares[row, column].Locked = true;
				}
			}
		}
		bool loadingGame;
		void LoadGame(string gameStr)
		{
			loadingGame = true;
			try
			{
				ClearGame();
				string[] lines = gameStr.Split('\n');
				int row = 0;
				foreach (string line in lines)
				{
					AddValuesForLine(row, line.TrimEnd());
					row++;
				}
			}
			finally
			{
				loadingGame = false;
			}
		}

		private void btnTest_Click(object sender, RoutedEventArgs e)
		{
			if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
				if (Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
					LoadGame(mediumGame);
				else
					LoadGame(hardGame);
			else
				LoadGame(easyGame);
		}

		SudokuSquare[] GetColumn(int column)
		{
			SudokuSquare[] result = new SudokuSquare[9];
			for (int row = 0; row < 9; row++)
				result[row] = squares[row, column];

			return result;
		}

		SudokuSquare[] GetRow(int row)
		{
			SudokuSquare[] result = new SudokuSquare[9];
			for (int column = 0; column < 9; column++)
				result[column] = squares[row, column];

			return result;
		}

		SudokuSquare[] GetBlock(int row, int column)
		{
			int topRow = 3 * (int)Math.Floor((double)row / 3);
			int leftColumn = 3 * (int)Math.Floor((double)column / 3);
			SudokuSquare[] result = new SudokuSquare[9];
			int index = 0;
			for (int r = topRow; r < topRow + 3; r++)
				for (int c = leftColumn; c < leftColumn + 3; c++)
				{
					result[index] = squares[r, c];
					index++;
				}

			return result;
		}

		void RemoveCharactersFromGroup(List<char> availableChars, SudokuSquare[] group)
		{
			for (int i = 0; i < 9; i++)
			{
				char thisChar = group[i].Char;
				if (availableChars.Contains(thisChar))
					availableChars.Remove(thisChar);
			}
		}

		private void btnFill_Click(object sender, RoutedEventArgs e)
		{
			FillFromAllNotes();
		}

		private void FillFromAllNotes()
		{
			for (int c = 0; c < 9; c++)
				for (int r = 0; r < 9; r++)
					squares[r, c].FillFromNotesIfPossible();
		}

		private void ShowNotesForSquare(SudokuSquare square)
		{
			if (square.GetText().Trim().Length > 0)
				return;

			GetSquarePosition(square, out int r, out int c);
			SudokuSquare[] column = GetColumn(c);
			SudokuSquare[] row = GetRow(r);
			SudokuSquare[] block = GetBlock(r, c);

			List<char> availableChars = new List<char>();
			foreach (char item in tbxAvailableCharacter.Text)
				availableChars.Add(item);

			RemoveCharactersFromGroup(availableChars, row);
			RemoveCharactersFromGroup(availableChars, column);
			RemoveCharactersFromGroup(availableChars, block);

			square.SetNotes(string.Join(", ", availableChars));
		}

		private void btnSolve_Click(object sender, RoutedEventArgs e)
		{
			FillFromAllNotes();
			RefreshAllNotes();
		}

		private void RefreshAllNotes()
		{
			for (int c = 0; c < 9; c++)
				for (int r = 0; r < 9; r++)
					ShowNotesForSquare(squares[r, c]);
		}

		private void btnClearNotes_Click(object sender, RoutedEventArgs e)
		{
			for (int c = 0; c < 9; c++)
				for (int r = 0; r < 9; r++)
					squares[r, c].ClearNotes();
		}

		private void btnConflictToggle_Click(object sender, RoutedEventArgs e)
		{
			SelectedSquare.HasConflict = !SelectedSquare.HasConflict;
		}

		void HookEvents()
		{
			for (int row = 0; row < 9; row++)
				for (int column = 0; column < 9; column++)
					squares[row, column].ValueChanged += SudokuSquare_ValueChanged;

		}

		void ShowConflicts()
		{
			ClearAllConflicts();

			for (int r = 0; r < 9; r++)
				for (int c = 0; c < 9; c++)
				{
					SudokuSquare thisSquare = squares[r, c];
					string text = thisSquare.GetText();
					if (string.IsNullOrWhiteSpace(text))
						continue;

					SudokuSquare[] column = GetColumn(c);
					SudokuSquare[] row = GetRow(r);
					SudokuSquare[] block = GetBlock(r, c);
					for (int rowIndex = 0; rowIndex < 9; rowIndex++)
						if (rowIndex != r && column[rowIndex].GetText() == text)
						{
							thisSquare.HasConflict = true;
							column[rowIndex].HasConflict = true;
						}

					for (int colIndex = 0; colIndex < 9; colIndex++)
						if (colIndex != c && row[colIndex].GetText() == text)
						{
							thisSquare.HasConflict = true;
							row[colIndex].HasConflict = true;
						}

					for (int squareIndex = 0; squareIndex < 9; squareIndex++)
					{
						GetSquarePosition(block[squareIndex], out int blockRow, out int blockColumn);
						if (blockRow == r && blockColumn == c)
							continue;

						if (block[squareIndex].GetText() == text)
						{
							thisSquare.HasConflict = true;
							block[squareIndex].HasConflict = true;
						}
					}
				}
		}

		private void ClearAllConflicts()
		{
			for (int r = 0; r < 9; r++)
				for (int c = 0; c < 9; c++)
					squares[r, c].HasConflict = false;
		}

		private void SudokuSquare_ValueChanged(object sender, EventArgs e)
		{
			if (loadingGame)
			{
				return;
			}
			else
			{
				ShowConflicts();
			}
		}

		//private void Button1_Click(object sender, RoutedEventArgs e)
		//{
		//	if (SelectedSquare != null)
		//		SelectedSquare.Locked = !SelectedSquare.Locked;
		//}
	}
}
