using Microsoft.JSInterop;

namespace IotRemoteLaboratory.Interops
{
    public class ConsoleWrapper
    {
        private readonly IJSRuntime _jsRuntime;

        public ConsoleWrapper(IJSRuntime jSRuntime)
        {
            _jsRuntime = jSRuntime;
        }

        public void WriteLine(string str)
        {
            _jsRuntime.InvokeVoidAsync("consolewrapper.writeLine", str);
        }
    }
}
