using IotRemoteLaboratory.Core;

namespace IotRemoteLaboratory.Core.Interfaces
{
    public interface IStand<IMcuPlatformT> where IMcuPlatformT : IMcuPlatform
    {
        public uint Id { get; }
        public IMcuPlatformT McuPlatform { get; }
        public ITerminal<TerminalMessage> Terminal { get; }
    }
}
