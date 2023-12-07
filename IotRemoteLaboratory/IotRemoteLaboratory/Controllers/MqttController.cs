using S.Mqtt;

namespace IotRemoteLaboratory.Controllers
{
    public sealed class MqttController
    {
        public event Action<string> MessageReceivedEvent;

        private readonly MqttPublisher _publisher;
        private readonly MqttSubscriber _subscriber;

        public MqttController(MqttPublisher publisher, MqttSubscriber subdcriber) 
        {
            _publisher = publisher;
            _subscriber = subdcriber;
            _subscriber.MessageReceivedEvent += (s) =>
            {
                Console.WriteLine(s);
                MessageReceivedEvent?.Invoke(s);
            };

            if (!publisher.IsConnected) 
            {
                publisher.Connect();
            }
            if (!subdcriber.IsConnected) 
            {
                subdcriber.Connect();
            }
        }

        public void PublishMessage(string payload) 
        {
            _publisher.PublishMessageAsync(payload);
        }
    }
}
