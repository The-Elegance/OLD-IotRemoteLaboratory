using IotRemoteLaboratory.Core.Interfaces;

namespace IotRemoteLaboratory.Core
{
    public class STM32Nucleo64 : ObservableObjectBase, IMcuPlatform<ILedButton>
    {
        public string Name { get; }
        public UART SelectedUART { get; set; } = UART.UART1;
        public bool HasIndecators { get; }
        public McuType Type { get; }
        public List<List<ILedButton>> ListRowsButtons { get; set; }

        public STM32Nucleo64(string name, UART uart, McuType type, List<List<ILedButton>> buttons)
        {
            SelectedUART = uart;
            Type = type;
            Name = name;
            ListRowsButtons = buttons;
            HasIndecators = true;
            OnPropertyChanged(nameof(ListRowsButtons));
        }
    }
}
