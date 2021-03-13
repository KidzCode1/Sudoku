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
	}
}
