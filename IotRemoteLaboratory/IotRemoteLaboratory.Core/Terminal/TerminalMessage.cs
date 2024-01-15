namespace IotRemoteLaboratory.Core
{
    public readonly struct TerminalMessage(string author, DateTime time, string message)
    {
        public string Author { get; } = author;
        public DateTime Time { get; } = time;
        public string Message { get; } = message;
    }
}
