using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace IotRemoteLaboratory.Core
{
    public abstract class ObservableObjectBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "") 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
