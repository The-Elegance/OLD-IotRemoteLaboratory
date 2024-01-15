namespace IotRemoteLaboratory.Core.Interfaces
{
    public interface ILedButton : IButton
    {
        public event Action<uint, bool> ToggleClicked;
        /// <summary>
        /// Is button checked;
        /// </summary>
        public bool IsActive { get; set; }
    }
}
