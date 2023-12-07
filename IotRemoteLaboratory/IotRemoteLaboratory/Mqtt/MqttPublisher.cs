using IotRemoteLaboratory.Models;
using IotRemoteLaboratory.Mqtt;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using System.Text.Json;

namespace IotRemoteLaboratory.Mqtt
{
    public sealed class MqttPublisher : MqttMember
    {
        public override string Topic { get; }
        protected override IMqttClient Client { get; }
        protected override IMqttClientOptions Options { get; }


        public MqttPublisher(MqttParams mqttParams)
        {
			Topic = mqttParams.Topic;
            Client = _mqttFactory.CreateMqttClient();
            Options = new MqttClientOptionsBuilder()
                .WithClientId(Guid.NewGuid().ToString())
                .WithTcpServer(mqttParams.Ip, mqttParams.Port)
                .WithCleanSession()
                .Build();

            Client.UseConnectedHandler(Connected);
            Client.UseDisconnectedHandler(Disconnected);
        }

        protected override async Task Connected(MqttClientConnectedEventArgs e)
        {
            Console.WriteLine("Connected to the broker successful");
            var topicFilter = new MqttTopicFilterBuilder()
                .WithTopic(Topic)
                .Build();

            await Client.SubscribeAsync(topicFilter);
        }

        protected override Task Disconnected(MqttClientDisconnectedEventArgs e)
        {
            Console.WriteLine("Disconnect from the broker successful");
            return Task.CompletedTask;
        }

        /// <summary>
        /// Получает строку либо json в виде строки
        /// </summary>
        /// <param name="payload"></param>
        public async void PublishMessageAsync(string payload)
        {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(Topic)
                .WithPayload(payload)
                .WithAtMostOnceQoS()
                .Build();

            if (Client.IsConnected)
                await Client.PublishAsync(message);
        }
    }
}
