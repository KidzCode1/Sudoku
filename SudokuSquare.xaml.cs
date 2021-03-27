﻿using System;
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
	public partial class SudokuSquare : UserControl, ISudokuSquare
	{
		public static bool Updating { get; set; }
		public event EventHandler ValueChanged;
		public bool HasConflict
		{
			get => hasConflict;
			set
			{
				if (hasConflict == value)
					return;

				hasConflict = value;

				if (hasConflict)
				{
					Grid1.Background = new SolidColorBrush(Color.FromRgb(255, 148, 148));
				}
				else
				{
					Grid1.Background = null;
				}
			}
		}

		int column;
		bool hasConflict;

		bool locked;
		public bool Locked
		{
			get
			{
				return locked;
			}
			set
			{
				if (locked == value)
					return;

				locked = value;
				if (locked)
				{
					tbxValue.Foreground = new SolidColorBrush(Color.FromRgb(68, 72, 99));
					tbxValue.IsReadOnly = true;
				}
				else
				{
					tbxValue.Foreground = new SolidColorBrush(Colors.Black);
					tbxValue.IsReadOnly = false;
				}
			}
		}

		public string Notes
		{
			get
			{
				return tbNotes.Text;
			}
			set
			{
				tbNotes.Text = value;
			}
		}

		public SudokuSquare()
		{
			InitializeComponent();
		}

		protected virtual void OnValueChanged(object sender, EventArgs e)
		{
			ValueChanged?.Invoke(sender, e);
		}

		public int Column => Grid.GetColumn(this);
		public int Row => Grid.GetRow(this);
		public static int NumTextChangesToSkip = 0;
		private void tbxValue_TextChanged(object sender, TextChangedEventArgs e)
		{
			if (ignoreNextTextChangedEvent)
			{
				ignoreNextTextChangedEvent = false;
				return;
			}

			if (Updating)
				return;
			if (e.Changes != null)
			{
				if (sender is TextBox textBox)
				{
					string lineText = textBox.GetLineText(0);
					TextChange textChange = e.Changes.First();
					string whatChanged = lineText.Substring(textChange.Offset, textChange.AddedLength);
					if (MainWindow.availableChars.Contains(whatChanged))
					{
						CommandInvoker.DoCommand(new TextChangedCommand(lastValue, whatChanged, Row, Column));
						//textBox.Text = whatChanged;
					}
					else
					{
						CommandInvoker.DoCommand(new TextChangedCommand(lastValue, whatChanged, Row, Column));
						//textBox.Text = " ";
					}
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
			Background = null;
			Locked = false;
			HasConflict = false;
			HasTestValue = false;
		}

		public void SetText(string text)
		{
			tbxValue.Text = text;
			OnValueChanged(this, EventArgs.Empty);
			SaveLastValue();
		}

		bool ignoreNextTextChangedEvent;
		
		public void SetTextNoInternalEvents(string text)
		{
			if (tbxValue.Text != text)
			{
				ignoreNextTextChangedEvent = true;
				tbxValue.Text = text;
			}
			OnValueChanged(this, EventArgs.Empty);
			SaveLastValue();
		}

		public string GetText()
		{
			if (Value == char.MinValue)
				return "";
			return tbxValue.Text;
		}

		public char Value
		{
			get
			{
				if (tbxValue.Text.Length > 0 && tbxValue.Text != " ")
					return tbxValue.Text[0];
				return char.MinValue;
			}
			set
			{
				tbxValue.Text = value.ToString();
			}
		}

		public bool IsEmpty => Value == char.MinValue || Value == '\0';
		public bool HasTestValue { get; set; }


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
		public void ToggleConflicts()
		{
			HasConflict = !HasConflict;
		}

		string lastValue;

		private void tbxValue_GotFocus(object sender, RoutedEventArgs e)
		{
			SaveLastValue();
		}

		private void SaveLastValue()
		{
			lastValue = tbxValue.Text;
		}
	}
}
