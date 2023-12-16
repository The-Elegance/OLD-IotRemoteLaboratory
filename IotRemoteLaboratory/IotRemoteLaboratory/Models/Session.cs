namespace IotRemoteLaboratory.Models
{
    public sealed class Session
    {
        public User User { get; }

        public Session(User user)
        {
            User = user;
        }
    }
}
