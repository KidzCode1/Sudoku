using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace Sudoku
{
	public class Square
	{
		public TextBox TextBox { get; set; }
		public string Notes { get; set; }
		public bool Locked { get; set; }

		public Square(TextBox textBox)
		{
			TextBox = textBox;
			//textBox.PreviewKeyDown += TextBox_PreviewKeyDown;
			textBox.TextChanged += TextBox_TextChanged;
			textBox.TextAlignment = System.Windows.TextAlignment.Center;
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
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
