using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ3_NetworkService.Commands
{
    public static class CommandExecuter
    {
		private static readonly Stack<ICommand> commands = new Stack<ICommand>();

		public static void ExecuteAndAdd(ICommand command)
		{
			try
			{
				command.Execute();
			}
			catch(Exception e)
			{
				throw;
			}
			commands.Push(command);
		}
		public static void Undo()
		{
			if(commands.Count > 0)
			{
				ICommand undoCommand = commands.Pop();
				undoCommand.Undo();
			}
		}
    }
}
