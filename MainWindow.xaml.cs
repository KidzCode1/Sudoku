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
		/* 
	 ![](39E2DF101A5C3558D58B7B46582D30B6.png;;;0.02032,0.02032)
	 */
		string initialGame = @"
53  7
6  195
 98    6
8   6   3
4  8 3  1
7   2   6
 6    28 
   419  5
    8  7 9
";

		Square[,] squares = new Square[9, 9];
		Square selectedSquare;
		public static string availableChars;
		public Square SelectedSquare
		{
			get => selectedSquare;
			set
			{
				if (selectedSquare == value)
					return;

				Square oldSelectedSquare = selectedSquare;
				if (oldSelectedSquare != null)
					oldSelectedSquare.HideSelection();

				selectedSquare = value;
				selectedSquare.ShowSelection();
			}
		}
		public MainWindow()
		{
			InitializeComponent();
			squares[0, 0] = new Square(tbx0_0);
			squares[0, 1] = new Square(tbx0_1);
			squares[0, 2] = new Square(tbx0_2);
			squares[0, 3] = new Square(tbx0_3);
			squares[0, 4] = new Square(tbx0_4);
			squares[0, 5] = new Square(tbx0_5);
			squares[0, 6] = new Square(tbx0_6);
			squares[0, 7] = new Square(tbx0_7);
			squares[0, 8] = new Square(tbx0_8);

			squares[1, 0] = new Square(tbx1_0);
			squares[1, 1] = new Square(tbx1_1);
			squares[1, 2] = new Square(tbx1_2);
			squares[1, 3] = new Square(tbx1_3);
			squares[1, 4] = new Square(tbx1_4);
			squares[1, 5] = new Square(tbx1_5);
			squares[1, 6] = new Square(tbx1_6);
			squares[1, 7] = new Square(tbx1_7);
			squares[1, 8] = new Square(tbx1_8);

			squares[2, 0] = new Square(tbx2_0);
			squares[2, 1] = new Square(tbx2_1);
			squares[2, 2] = new Square(tbx2_2);
			squares[2, 3] = new Square(tbx2_3);
			squares[2, 4] = new Square(tbx2_4);
			squares[2, 5] = new Square(tbx2_5);
			squares[2, 6] = new Square(tbx2_6);
			squares[2, 7] = new Square(tbx2_7);
			squares[2, 8] = new Square(tbx2_8);

			squares[3, 0] = new Square(tbx3_0);
			squares[3, 1] = new Square(tbx3_1);
			squares[3, 2] = new Square(tbx3_2);
			squares[3, 3] = new Square(tbx3_3);
			squares[3, 4] = new Square(tbx3_4);
			squares[3, 5] = new Square(tbx3_5);
			squares[3, 6] = new Square(tbx3_6);
			squares[3, 7] = new Square(tbx3_7);
			squares[3, 8] = new Square(tbx3_8);

			squares[4, 0] = new Square(tbx4_0);
			squares[4, 1] = new Square(tbx4_1);
			squares[4, 2] = new Square(tbx4_2);
			squares[4, 3] = new Square(tbx4_3);
			squares[4, 4] = new Square(tbx4_4);
			squares[4, 5] = new Square(tbx4_5);
			squares[4, 6] = new Square(tbx4_6);
			squares[4, 7] = new Square(tbx4_7);
			squares[4, 8] = new Square(tbx4_8);

			squares[5, 0] = new Square(tbx5_0);
			squares[5, 1] = new Square(tbx5_1);
			squares[5, 2] = new Square(tbx5_2);
			squares[5, 3] = new Square(tbx5_3);
			squares[5, 4] = new Square(tbx5_4);
			squares[5, 5] = new Square(tbx5_5);
			squares[5, 6] = new Square(tbx5_6);
			squares[5, 7] = new Square(tbx5_7);
			squares[5, 8] = new Square(tbx5_8);

			squares[6, 0] = new Square(tbx6_0);
			squares[6, 1] = new Square(tbx6_1);
			squares[6, 2] = new Square(tbx6_2);
			squares[6, 3] = new Square(tbx6_3);
			squares[6, 4] = new Square(tbx6_4);
			squares[6, 5] = new Square(tbx6_5);
			squares[6, 6] = new Square(tbx6_6);
			squares[6, 7] = new Square(tbx6_7);
			squares[6, 8] = new Square(tbx6_8);

			squares[7, 0] = new Square(tbx7_0);
			squares[7, 1] = new Square(tbx7_1);
			squares[7, 2] = new Square(tbx7_2);
			squares[7, 3] = new Square(tbx7_3);
			squares[7, 4] = new Square(tbx7_4);
			squares[7, 5] = new Square(tbx7_5);
			squares[7, 6] = new Square(tbx7_6);
			squares[7, 7] = new Square(tbx7_7);
			squares[7, 8] = new Square(tbx7_8);

			squares[8, 0] = new Square(tbx8_0);
			squares[8, 1] = new Square(tbx8_1);
			squares[8, 2] = new Square(tbx8_2);
			squares[8, 3] = new Square(tbx8_3);
			squares[8, 4] = new Square(tbx8_4);
			squares[8, 5] = new Square(tbx8_5);
			squares[8, 6] = new Square(tbx8_6);
			squares[8, 7] = new Square(tbx8_7);
			squares[8, 8] = new Square(tbx8_8);

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

		void GetSquarePosition(Square square, out int row, out int column)
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
	}
}
