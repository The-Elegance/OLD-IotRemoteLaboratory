namespace VirtualTestStand.Command
{
    internal abstract class ConsoleCommand
    {
        protected TextWriter _writer;

        public string Name { get; }
        public string Help { get; }
        
        public ConsoleCommand(string name, string help, TextWriter writer)
        {
            Name = name;
            Help = help;
            _writer = writer;
        }

        public abstract void Execute(string[] args);
    }
}
