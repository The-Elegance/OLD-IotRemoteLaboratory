using IotRemoteLaboratory.Core.Interfaces;

namespace IotRemoteLaboratory.Core.Terminal
{
    public class Terminal<T, C> : ITerminal<T> where C : IList<T>
    {
        public T this[int index] => _logs[index];

        private C _logs = default;
        public IEnumerable<T> Logs => _logs;
        public event Action<T> MessageAdded;

        public void Add(T message)
        {
            MessageAdded?.Invoke(message);
        }
    }
}
