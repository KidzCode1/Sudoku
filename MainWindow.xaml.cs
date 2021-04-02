using System;
using System.Numerics;
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
		bool alwaysEnableSolveButtons = true;
		List<BaseGroupSolver> solvers = new List<BaseGroupSolver>();
		public static string availableChars;
		
		public MainWindow()
		{
			InitializeComponent();
			InitializeSquares();
			InitializeSolvers();
			HookEvents();

			SudokuBoard.SelectFirstSquare();
		}

		private void InitializeSquares()
		{
			SudokuBoard.AddSquare(0, 0, tbx0_0);
			SudokuBoard.AddSquare(0, 1, tbx0_1);
			SudokuBoard.AddSquare(0, 2, tbx0_2);
			SudokuBoard.AddSquare(0, 3, tbx0_3);
			SudokuBoard.AddSquare(0, 4, tbx0_4);
			SudokuBoard.AddSquare(0, 5, tbx0_5);
			SudokuBoard.AddSquare(0, 6, tbx0_6);
			SudokuBoard.AddSquare(0, 7, tbx0_7);
			SudokuBoard.AddSquare(0, 8, tbx0_8);
			SudokuBoard.AddSquare(1, 0, tbx1_0);
			SudokuBoard.AddSquare(1, 1, tbx1_1);
			SudokuBoard.AddSquare(1, 2, tbx1_2);
			SudokuBoard.AddSquare(1, 3, tbx1_3);
			SudokuBoard.AddSquare(1, 4, tbx1_4);
			SudokuBoard.AddSquare(1, 5, tbx1_5);
			SudokuBoard.AddSquare(1, 6, tbx1_6);
			SudokuBoard.AddSquare(1, 7, tbx1_7);
			SudokuBoard.AddSquare(1, 8, tbx1_8);
			SudokuBoard.AddSquare(2, 0, tbx2_0);
			SudokuBoard.AddSquare(2, 1, tbx2_1);
			SudokuBoard.AddSquare(2, 2, tbx2_2);
			SudokuBoard.AddSquare(2, 3, tbx2_3);
			SudokuBoard.AddSquare(2, 4, tbx2_4);
			SudokuBoard.AddSquare(2, 5, tbx2_5);
			SudokuBoard.AddSquare(2, 6, tbx2_6);
			SudokuBoard.AddSquare(2, 7, tbx2_7);
			SudokuBoard.AddSquare(2, 8, tbx2_8);
			SudokuBoard.AddSquare(3, 0, tbx3_0);
			SudokuBoard.AddSquare(3, 1, tbx3_1);
			SudokuBoard.AddSquare(3, 2, tbx3_2);
			SudokuBoard.AddSquare(3, 3, tbx3_3);
			SudokuBoard.AddSquare(3, 4, tbx3_4);
			SudokuBoard.AddSquare(3, 5, tbx3_5);
			SudokuBoard.AddSquare(3, 6, tbx3_6);
			SudokuBoard.AddSquare(3, 7, tbx3_7);
			SudokuBoard.AddSquare(3, 8, tbx3_8);
			SudokuBoard.AddSquare(4, 0, tbx4_0);
			SudokuBoard.AddSquare(4, 1, tbx4_1);
			SudokuBoard.AddSquare(4, 2, tbx4_2);
			SudokuBoard.AddSquare(4, 3, tbx4_3);
			SudokuBoard.AddSquare(4, 4, tbx4_4);
			SudokuBoard.AddSquare(4, 5, tbx4_5);
			SudokuBoard.AddSquare(4, 6, tbx4_6);
			SudokuBoard.AddSquare(4, 7, tbx4_7);
			SudokuBoard.AddSquare(4, 8, tbx4_8);
			SudokuBoard.AddSquare(5, 0, tbx5_0);
			SudokuBoard.AddSquare(5, 1, tbx5_1);
			SudokuBoard.AddSquare(5, 2, tbx5_2);
			SudokuBoard.AddSquare(5, 3, tbx5_3);
			SudokuBoard.AddSquare(5, 4, tbx5_4);
			SudokuBoard.AddSquare(5, 5, tbx5_5);
			SudokuBoard.AddSquare(5, 6, tbx5_6);
			SudokuBoard.AddSquare(5, 7, tbx5_7);
			SudokuBoard.AddSquare(5, 8, tbx5_8);
			SudokuBoard.AddSquare(6, 0, tbx6_0);
			SudokuBoard.AddSquare(6, 1, tbx6_1);
			SudokuBoard.AddSquare(6, 2, tbx6_2);
			SudokuBoard.AddSquare(6, 3, tbx6_3);
			SudokuBoard.AddSquare(6, 4, tbx6_4);
			SudokuBoard.AddSquare(6, 5, tbx6_5);
			SudokuBoard.AddSquare(6, 6, tbx6_6);
			SudokuBoard.AddSquare(6, 7, tbx6_7);
			SudokuBoard.AddSquare(6, 8, tbx6_8);
			SudokuBoard.AddSquare(7, 0, tbx7_0);
			SudokuBoard.AddSquare(7, 1, tbx7_1);
			SudokuBoard.AddSquare(7, 2, tbx7_2);
			SudokuBoard.AddSquare(7, 3, tbx7_3);
			SudokuBoard.AddSquare(7, 4, tbx7_4);
			SudokuBoard.AddSquare(7, 5, tbx7_5);
			SudokuBoard.AddSquare(7, 6, tbx7_6);
			SudokuBoard.AddSquare(7, 7, tbx7_7);
			SudokuBoard.AddSquare(7, 8, tbx7_8);
			SudokuBoard.AddSquare(8, 0, tbx8_0);
			SudokuBoard.AddSquare(8, 1, tbx8_1);
			SudokuBoard.AddSquare(8, 2, tbx8_2);
			SudokuBoard.AddSquare(8, 3, tbx8_3);
			SudokuBoard.AddSquare(8, 4, tbx8_4);
			SudokuBoard.AddSquare(8, 5, tbx8_5);
			SudokuBoard.AddSquare(8, 6, tbx8_6);
			SudokuBoard.AddSquare(8, 7, tbx8_7);
			SudokuBoard.AddSquare(8, 8, tbx8_8);
		}

		private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Right)
			{
				GetSquarePosition(SudokuBoard.SelectedSquare, out int row, out int column);
				SelectSquare(row, column + 1);
			}

			if (e.Key == Key.Left)
			{
				GetSquarePosition(SudokuBoard.SelectedSquare, out int row, out int column);
				SelectSquare(row, column - 1);
			}

			if (e.Key == Key.Down)
			{
				GetSquarePosition(SudokuBoard.SelectedSquare, out int row, out int column);
				SelectSquare(row + 1, column);
			}

			if (e.Key == Key.Up)
			{
				GetSquarePosition(SudokuBoard.SelectedSquare, out int row, out int column);
				SelectSquare(row - 1, column);
			}

			if (e.Key == Key.Z && Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
			{
				CommandInvoker.Undo();
				e.Handled = true;
			}

			bool ctrlShiftZPressed = e.Key == Key.Z && Keyboard.Modifiers.HasFlag(ModifierKeys.Control) && Keyboard.Modifiers.HasFlag(ModifierKeys.Shift);
			bool ctrlYPressed = e.Key == Key.Y && Keyboard.Modifiers.HasFlag(ModifierKeys.Control);
			
			if (ctrlShiftZPressed || ctrlYPressed)
			{
				CommandInvoker.Redo();
				e.Handled = true;
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

			SudokuBoard.SelectedSquare = SudokuBoard.squares[row, column];
		}

		void GetSquarePosition(SudokuSquare square, out int row, out int column)
		{
			for (int c = 0; c < 9; c++)
				for (int r = 0; r < 9; r++)
					if (SudokuBoard.squares[r, c] == square)
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

		// ![](6692E3EA32E9E486DC7E3F6F19C0028D.png;;9,93,564,651;0.01728,0.01728)
		string expertGame = @" 4 8    6
  1  6  3
  63 98
25 6 3

 87    4
    9 7
     4 1
     2  5";

		void ClearGame()
		{
			for (int c = 0; c < 9; c++)
				for (int r = 0; r < 9; r++)
					SudokuBoard.squares[r, c].Clear();
		}

		void LoadValuesForLine(int row, string line)
		{
			for (int column = 0; column < line.Length; column++)
			{
				char chr = line[column];
				if (chr != ' ')
				{
					SudokuBoard.squares[row, column].SetText(chr.ToString());
					SudokuBoard.squares[row, column].Locked = true;
				}
			}
		}
		bool loadingGame;
		void LoadGame(string gameStr, string message)
		{
			Title = message;
			loadingGame = true;
			SudokuSquare.Updating = true;
			btnBruteForce.IsEnabled = false;
			btnHint.IsEnabled = false;
			try
			{
				ClearGame();
				string[] lines = gameStr.Split('\n');
				int row = 0;
				foreach (string line in lines)
				{
					LoadValuesForLine(row, line.TrimEnd());
					row++;
				}
			}
			finally
			{
				SudokuSquare.Updating = false;
				loadingGame = false;
			}
		}

		private void btnTest_Click(object sender, RoutedEventArgs e)
		{
			if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
				if (Keyboard.Modifiers.HasFlag(ModifierKeys.Shift))
					if (Keyboard.Modifiers.HasFlag(ModifierKeys.Alt))
						LoadGame(expertGame, "Expert Game Loaded");
					else
						LoadGame(hardGame, "Hard Game Loaded");
				else
					LoadGame(mediumGame, "Medium Game Loaded");
			else
				LoadGame(easyGame, "Easy Game Loaded");
		}

		SudokuSquare[] GetColumn(int column)
		{
			SudokuSquare[] result = new SudokuSquare[9];
			for (int row = 0; row < 9; row++)
				result[row] = SudokuBoard.squares[row, column];

			return result;
		}

		SudokuSquare[] GetRow(int row)
		{
			SudokuSquare[] result = new SudokuSquare[9];
			for (int column = 0; column < 9; column++)
				result[column] = SudokuBoard.squares[row, column];

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
					result[index] = SudokuBoard.squares[r, c];
					index++;
				}

			return result;
		}

		void RemoveCharactersFromGroup(List<char> availableChars, SudokuSquare[] group)
		{
			for (int i = 0; i < 9; i++)
			{
				char thisChar = group[i].Value;
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
					SudokuBoard.squares[r, c].FillFromNotesIfPossible();
		}

		private void ShowNotesForSquare(SudokuSquare square)
		{
			if (square.GetText().Trim().Length > 0)
				return;

			GetSquarePosition(square, out int r, out int c);
			ShowNotesForSquareAt(square, r, c);
		}

		private void ShowNotesForSquareAt(SudokuSquare square, int r, int c)
		{
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
			ApplySolvers();
			UpdateCombinationsRemaining();
		}

		private bool ApplySolvers()
		{
			bool squaresSolved = false;
			foreach (BaseGroupSolver sudokuSolver in solvers)
			{
				// Calling solve 27 times for all the rows, columns, and blocks.
				for (int c = 0; c < 9; c++)
					if (sudokuSolver.Solve(GetColumn(c), GroupKind.Column) == SolveResult.SquaresSolved)
						squaresSolved = true;
				for (int r = 0; r < 9; r++)
					if (sudokuSolver.Solve(GetRow(r), GroupKind.Row) == SolveResult.SquaresSolved)
						squaresSolved = true;
				for (int r = 0; r < 3; r++)
					for (int c = 0; c < 3; c++)
						if (sudokuSolver.Solve(GetBlock(r * 3, c * 3), GroupKind.Block) == SolveResult.SquaresSolved)
							squaresSolved = true;
			}

			return squaresSolved;
		}

		private void RefreshAllNotes()
		{
			for (int c = 0; c < 9; c++)
				for (int r = 0; r < 9; r++)
					ShowNotesForSquare(SudokuBoard.squares[r, c]);
		}

		private void btnClearNotes_Click(object sender, RoutedEventArgs e)
		{
			for (int c = 0; c < 9; c++)
				for (int r = 0; r < 9; r++)
					SudokuBoard.squares[r, c].ClearNotes();
		}

		private void btnConflictToggle_Click(object sender, RoutedEventArgs e)
		{
			SudokuBoard.SelectedSquare.ToggleConflicts();
		}

		void HookEvents()
		{
			for (int row = 0; row < 9; row++)
				for (int column = 0; column < 9; column++)
					SudokuBoard.squares[row, column].ValueChanged += SudokuSquare_ValueChanged;

		}

		bool HasConflicts(int r, int c)
		{
			return CheckForConflicts(r, c, false);
		}

		bool CheckForConflicts(int r, int c, bool setHasConflictedProperty = true)
		{
			SudokuSquare thisSquare = SudokuBoard.squares[r, c];
			string text = thisSquare.GetText();
			if (string.IsNullOrWhiteSpace(text))
				return false;

			SudokuSquare[] column = GetColumn(c);
			SudokuSquare[] row = GetRow(r);
			SudokuSquare[] block = GetBlock(r, c);

			bool isConflicted = false;
			for (int rowIndex = 0; rowIndex < 9; rowIndex++)
				if (rowIndex != r && column[rowIndex].GetText() == text)
				{
					if (setHasConflictedProperty)
					{
						thisSquare.HasConflict = true;
						column[rowIndex].HasConflict = true;
					}
					isConflicted = true;
				}

			for (int colIndex = 0; colIndex < 9; colIndex++)
				if (colIndex != c && row[colIndex].GetText() == text)
				{
					if (setHasConflictedProperty)
					{
						thisSquare.HasConflict = true;
						row[colIndex].HasConflict = true;
					}
					isConflicted = true;
				}

			for (int squareIndex = 0; squareIndex < 9; squareIndex++)
			{
				GetSquarePosition(block[squareIndex], out int blockRow, out int blockColumn);
				if (blockRow == r && blockColumn == c)
					continue;

				if (block[squareIndex].GetText() == text)
				{
					if (setHasConflictedProperty)
					{
						thisSquare.HasConflict = true;
						block[squareIndex].HasConflict = true;
					}
					isConflicted = true;
				}
			}

			return isConflicted;
		}

		void ShowConflicts()
		{
			ClearAllConflicts();

			for (int r = 0; r < 9; r++)
				for (int c = 0; c < 9; c++)
				{
					CheckForConflicts(r, c);
				}
		}

		private void ClearAllConflicts()
		{
			for (int r = 0; r < 9; r++)
				for (int c = 0; c < 9; c++)
					SudokuBoard.squares[r, c].HasConflict = false;
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

		void InitializeSolvers()
		{
			solvers.Add(new Solver2x2());
			solvers.Add(new Solver3x3());
			solvers.Add(new Solver4x4());
			solvers.Add(new Solver5x5());
			solvers.Add(new OnlyOneSolver());
		}

		bool AllSquaresAreFilled()
		{
			for (int row = 0; row < 9; row++)
				for (int column = 0; column < 9; column++)
				{
					SudokuSquare sudokuSquare = SudokuBoard.squares[row, column];
					if (sudokuSquare.IsEmpty)
						return false;
				}
			return true;
		}

		int numCombinationsTried;
		bool BruteForceAttack(int startingRow = 0, int startingColumn = 0)
		{
			if (startingColumn >= 9)
			{
				startingColumn = 0;
				startingRow++;
			}
			for (int row = startingRow; row < 9; row++)
				for (int column = startingColumn; column < 9; column++)
				{
					startingColumn = 0;
					SudokuSquare sudokuSquare = SudokuBoard.squares[row, column];
					if (!sudokuSquare.IsEmpty)
						continue;
					// Magic - I have an empty square!!!
					if (sudokuSquare.Notes == "")
					{
						ShowNotesForSquareAt(sudokuSquare, row, column);
						if (sudokuSquare.Notes == "")  // That means we have a conflict.
							return BruteForceAttack(row, column + 1);
					}

					List<int> notes = BaseGroupSolver.GetNumbers(sudokuSquare.Notes);
					
					foreach (int number in notes)
					{
						sudokuSquare.Value = number.ToString()[0];
						sudokuSquare.HasTestValue = true;
						numCombinationsTried++;
						if (HasConflicts(row, column))
						{
							sudokuSquare.Value = Char.MinValue;
							sudokuSquare.HasTestValue = false;
						}
						else if (BruteForceAttack(row, column + 1))
						{
							sudokuSquare.Notes = "";
							return true;
						}
						else
						{
							sudokuSquare.Value = Char.MinValue;
							sudokuSquare.HasTestValue = false;
						}
					}
					return false;
				}

			return AllSquaresAreFilled();
		}

		private void btnBruteForce_Click(object sender, RoutedEventArgs e)
		{
			StartBruteForceAttack();
		}

		private void StartBruteForceAttack()
		{
			SudokuSquare.Updating = true;
			try
			{
				numCombinationsTried = 0;
				BruteForceAttack();
			}
			finally
			{
				SudokuSquare.Updating = false;
			}
		}

		private void btnHint_Click(object sender, RoutedEventArgs e)
		{
			StartBruteForceAttack();
			bool foundOneYet = false;
			for (int row = 0; row < 9; row++)
				for (int column = 0; column < 9; column++)
				{
					if (SudokuBoard.squares[row, column].HasTestValue)
					{
						if (!foundOneYet)
						{
							foundOneYet = true;
							SudokuBoard.squares[row, column].Background = new SolidColorBrush(Color.FromRgb(163, 247, 176));
						}
						else
							SudokuBoard.squares[row, column].Value = char.MinValue;

						SudokuBoard.squares[row, column].HasTestValue = false;
					}
				}
		}

		void UpdateCombinationsRemaining()
		{
			BigInteger numCombos = 1;
			for (int row = 0; row < 9; row++)
				for (int column = 0; column < 9; column++)
				{
					List<int> numbers = BaseGroupSolver.GetNumbers(SudokuBoard.squares[row, column].Notes);
					if (numbers.Count > 0)
					{
						numCombos *= numbers.Count;
					}
				}
			if (numCombos == 1)
				numCombos = 0;
			bool weHaveAReasonableNumberOfCombosWeCanSolve = numCombos < 200_000_000;
			bool shouldEnableSolveButtons = alwaysEnableSolveButtons || weHaveAReasonableNumberOfCombosWeCanSolve;
			btnBruteForce.IsEnabled = shouldEnableSolveButtons;
			btnHint.IsEnabled = shouldEnableSolveButtons;
			Title = $"The number of combinations is {numCombos}!";
		}
		//private void Button1_Click(object sender, RoutedEventArgs e)
		//{
		//	if (SelectedSquare != null)
		//		SelectedSquare.Locked = !SelectedSquare.Locked;
		//}
	}
}
