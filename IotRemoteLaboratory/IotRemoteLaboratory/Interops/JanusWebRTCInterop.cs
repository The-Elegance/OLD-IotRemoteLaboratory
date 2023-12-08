using Microsoft.JSInterop;

namespace IotRemoteLaboratory.Interops
{
    public sealed class JanusWebRTCInterop
    {
        private readonly IJSRuntime _jsRuntime;


        #region Constructors


        public JanusWebRTCInterop(IJSRuntime jSRuntime)
        {
            _jsRuntime = jSRuntime;
        }


        #endregion Constructor


        #region Public Methods


        public void InitializeJanus()
        {
            _jsRuntime.InvokeVoidAsync("janus.initialize");
        }

        public void StartVideoStreaming()
        {
            _jsRuntime.InvokeVoidAsync("startStream", 2);
        }

        public void StopVideoStreaming() 
        {
            _jsRuntime.InvokeVoidAsync("stopStream");
        }


        #endregion Public Methods
    }
}
