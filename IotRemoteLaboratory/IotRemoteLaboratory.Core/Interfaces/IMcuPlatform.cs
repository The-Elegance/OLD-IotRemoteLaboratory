namespace IotRemoteLaboratory.Core.Interfaces
{
    public enum McuType 
    {
        MCS51,
        ESP8266,
        ESP32,
        STM32,
        NXP,
        STM9
    }


    public interface IMcuPlatform 
    {
        public string Name { get; }
        public UART SelectedUART { get; }
        public bool HasIndecators { get; }
        public McuType Type { get; }
    }

    public interface IMcuPlatform<T> : IMcuPlatform where T : IButton
    {
        public List<List<T>> ListRowsButtons { get; }
    }
}
