namespace IotRemoteLaboratory.CodeExecutor
{
    public interface ICodeExecutor
    {
        public event Action<string> CodeWasExecuted;

        public void ExecuteFile(string filePath, string args);
        public bool IsCorrectFileExtension(string filePath);
    }
}
