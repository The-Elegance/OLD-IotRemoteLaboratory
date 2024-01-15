namespace IotRemoteLaboratory.Core.Interfaces
{
    public interface ITerminal<T>
    {
        public event Action<T> MessageAdded;
        public IEnumerable<T> Logs { get; }
        public void Add(T message);
        public T this[int index] { get; }
    }
}
