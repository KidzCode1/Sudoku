using System;
using System.Linq;
using System.Collections.Generic;

namespace Sudoku
{
	// ![](07049D6732C152D510599E102535C493.png)
	public static class CommandInvoker
	{
		static Stack<Command> undoStack = new Stack<Command>();
		
		public static void DoCommand(Command command)
		{
			command.Execute();
			undoStack.Push(command);
		}

		public static void Undo()
		{
			if (undoStack.Count == 0)
				return;
			Command command = undoStack.Pop();
			command.Undo();
		}

		public static void Redo()
		{
			throw new NotImplementedException();
		}
	}
}
