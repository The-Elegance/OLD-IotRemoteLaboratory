namespace IotRemoteLaboratory.Core.Interfaces
{
    public interface IButton
    {
        public event Action<uint> Clicked;
        public uint Id { get; }
        /// <summary>
        /// Tilte of Name
        /// </summary>
        public string Title { get; }
        /// <summary>
        /// Click button button
        /// </summary>
        public void OnClick();
    }
}
