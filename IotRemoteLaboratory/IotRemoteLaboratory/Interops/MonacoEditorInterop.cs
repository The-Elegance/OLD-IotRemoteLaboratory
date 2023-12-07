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


        public string GetCode(string elementId)
        {
            try
            {
                return _runtime.InvokeAsync<string>("monacoInterop.getCode", elementId).Result;
            }
            catch (JSDisconnectedException e)
            {

            }
            return null;
        }


        public void SetCode(string elementId, string code)
        {
            _runtime.InvokeAsync<object>("monacoInterop.setCode", elementId, code);
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
