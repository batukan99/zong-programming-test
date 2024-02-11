using System.Collections.Generic;
using UnityEngine;


namespace Zong.Commands 
{
    public class CommandManager : Singleton<MonoBehaviour>
    {
        private Stack<ICommand> commands = new Stack<ICommand>();

        public void OnPushCommand(ICommand command)
        {
            commands.Push(command);
            command.Execute();
        }
        public void OnPopCommand()
        {
            ICommand oldCommand = commands.Pop();
            oldCommand.Undo();
        }
    }

}
