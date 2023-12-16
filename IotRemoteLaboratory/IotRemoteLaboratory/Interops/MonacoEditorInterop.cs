using Microsoft.JSInterop;

namespace IotRemoteLaboratory.Interops
{
    public sealed class MonacoEditorInterop
    {
        private readonly IJSRuntime _runtime;
        private Action<string>? _codeChangedEvent;

        public MonacoEditorInterop(IJSRuntime runtime)
        {
            _runtime = runtime;
        }


        #region Public Methods


        public void Initialize(string elementId, string initialCode, string language, Action<string> codeChangedEvent)
        {
            _codeChangedEvent = codeChangedEvent;
            _runtime.InvokeVoidAsync("monacoInterop.initialize", elementId, initialCode, language, DotNetObjectReference.Create(this));
        }


        public async ValueTask<string> GetCode(string elementId)
        {
            return await _runtime.InvokeAsync<string>("monacoInterop.getCode", elementId); 
        }

        public void SetCode(string elementId, string code)
        {
            _runtime.InvokeAsync<object>("monacoInterop.setCode", elementId, code);
        }

        public void ReadonlyMode(string elementId, bool state) 
        {
            _runtime.InvokeVoidAsync("monacoInterop.readonlyMode", elementId, state);
        }

        public void ChangeFontSize(string elementId, uint fontSize) 
        {
            _runtime.InvokeVoidAsync("monacoInterop.changeFontSize", elementId, fontSize);
        }


        #endregion Public Methods


        #region JSInvokable Methods


        [JSInvokable]
        public void OnCodeChanged(string newValue)
        {
            _codeChangedEvent?.Invoke(newValue);
        }


        #endregion JSInvokable Methods
    }
}
