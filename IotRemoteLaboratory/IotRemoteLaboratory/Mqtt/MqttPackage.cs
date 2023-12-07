using IotRemoteLaboratory.Models;

namespace IotRemoteLaboratory.Mqtt
{
    public sealed class MqttPackage<T>
    {
        public User User { get; set; }
        public T Message { get; set; }

        public MqttPackage()
        {
            
        }

        public MqttPackage(User user, T obj) 
        {
            User = user;
            Message = obj;
        }
    }
}
