using IotRemoteLaboratory.Controllers;

namespace IotRemoteLaboratory.Models
{
    public sealed class Session
    {
        public User User { get; }
        public MqttController MqttController { get; }

        public Session(User user, MqttController mqttController)
        {
            User = user;
            MqttController = mqttController;
        }
    }
}
