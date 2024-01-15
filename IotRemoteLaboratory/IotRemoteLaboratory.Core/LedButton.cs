using IotRemoteLaboratory.Core.Interfaces;

namespace IotRemoteLaboratory.Core
{
    public class LedButton : ObservableObjectBase, ILedButton
    {
        public event Action<uint, bool> ToggleClicked;
        public event Action<uint> Clicked;

        public uint Id { get; }
        public string Title { get; }

        private bool _isActive;
        public bool IsActive
        {
            get => _isActive; set
            {
                _isActive = value;
                OnPropertyChanged();
            }
        }

        public LedButton(uint id, string title)
        {
            Id = id;
            Title = title;
        }
        public void OnClick()
        {
            IsActive = !IsActive;
            Clicked?.Invoke(Id);
            ToggleClicked?.Invoke(Id, IsActive);
        }
    }
}
