using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualTestStand.Command;

namespace VirtualTestStand
{
    internal class CommandExecutor
    {
        private readonly ConsoleCommand[] _commands;
        private readonly TextWriter _writer;


        #region Constructors


        public CommandExecutor(ConsoleCommand[] commands, TextWriter writer)
        {
            _commands = commands;
            _writer = writer;
        }

        public CommandExecutor(TextWriter textWriter, params ConsoleCommand[] commands) : this(commands, textWriter)
        {

        }


        #endregion Constructors


        #region Public Methods


        public string[] GetAvaliableCommandNames() 
        {
            return _commands.Select(c => c.Name).ToArray();
        }

        public ConsoleCommand? FindCommandByName(string name) 
        {
            return _commands.FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        public void Execute(string[] args) 
        {
            if (args.Length == 0)
                _writer.WriteLine("Please specify <command> as the first command line argument!");

            var cmdRes = FindCommandByName(args[0]);

            if (cmdRes == null) 
                _writer.WriteLine("Sorry, Unknown command -> {0}!", args[0]);
            else
                cmdRes.Execute(args.Skip(1).ToArray());
        }


        #endregion Public Methods
    }
}
