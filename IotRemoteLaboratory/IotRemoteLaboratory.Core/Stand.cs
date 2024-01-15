using IotRemoteLaboratory.Core.Interfaces;
using IotRemoteLaboratory.Core.Terminal;

namespace IotRemoteLaboratory.Core
{
    public class Stand : IStand<IMcuPlatform<ILedButton>>
    {
        public uint Id { get; }
        public IMcuPlatform<ILedButton> McuPlatform { get; }
        public ITerminal<TerminalMessage> Terminal { get; }

        public Stand(uint id, IMcuPlatform<ILedButton> mcuPlatform)
        {
            Id = id;
            McuPlatform = mcuPlatform;
            Terminal = new Terminal<TerminalMessage, List<TerminalMessage>>();
        }
    }
}
