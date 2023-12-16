
using System.Diagnostics;
using System.Text;

namespace IotRemoteLaboratory.CodeExecutor
{
    public class PythonExecutor : ICodeExecutor
    {
        public event Action<string> CodeWasExecuted;
        public event Action<string> LineAdded;

        private readonly StringBuilder _stringBuilder;

        public PythonExecutor()
        {
            _stringBuilder = new StringBuilder();
        }

        public void ExecuteFile(string filePath, string args)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"C:\Users\HelJo\AppData\Local\Programs\Python\Python312\python.exe",
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                },
                EnableRaisingEvents = true
            };

            process.ErrorDataReceived += Process_OutputDataReceived;
            process.OutputDataReceived += Process_OutputDataReceived;

            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();
            process.WaitForExit();

            CodeWasExecuted?.Invoke(_stringBuilder.ToString());
            _stringBuilder.Clear();
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data?.Length > 0)
                _stringBuilder.AppendLine(e.Data);
        }

        public bool IsCorrectFileExtension(string filePath)
        {
            return Path.GetExtension(filePath) == ".py";
        }
    }
}
