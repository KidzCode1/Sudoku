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
	/// Interaction logic for SudokuSquare.xaml
	/// </summary>
	public partial class SudokuSquare : UserControl
	{
		public bool Locked { get; set; }
		public string Notes { get; set; }
		public SudokuSquare()
		{
			InitializeComponent();
		}

		private void tbxValue_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (e.Changes != null)
			{
				if (sender is TextBox textBox)
				{
					string lineText = textBox.GetLineText(0);
					TextChange textChange = e.Changes.First();
					string whatChanged = lineText.Substring(textChange.Offset, textChange.AddedLength);
					if (MainWindow.availableChars.Contains(whatChanged))
					{
						textBox.Text = whatChanged;
					}
					else
						textBox.Text = " ";
				}
			}
		}

		private void Border_PreviewMouseDown(object sender, MouseButtonEventArgs e)
		{
			tbxValue.Focus();
		}

		public void ShowSelection()
		{
			Border.Background = new SolidColorBrush(Color.FromRgb(255, 244, 176));
			tbxValue.Focus();
		}

		public void HideSelection()
		{
			Border.Background = null;
		}

		public void Clear()
		{
			tbxValue.Text = "";
			tbNotes.Text = "";
		}

		public void SetText(string text)
		{
			tbxValue.Text = text;
		}

		public string GetText()
		{
			return tbxValue.Text;
		}

		public char Char
		{
			get
			{
				if (tbxValue.Text.Length > 0)
					return tbxValue.Text[0];
				return char.MinValue;
			}
		}
		

		public void SetNotes(string notes)
		{
			tbNotes.Text = notes;
		}

		public void FillFromNotesIfPossible()
		{
			if (tbNotes.Text.Length == 1)
			{
				tbxValue.Text = tbNotes.Text;
				tbNotes.Text = "";
			}
		}
		public void ClearNotes()
		{
			tbNotes.Text = "";
		}
	}
}
