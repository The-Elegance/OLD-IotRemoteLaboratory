using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Client;
using MQTTnet;
using System.Text;
using System.Text.Json;
using System;
using IotRemoteLaboratory.Mqtt;

namespace IotRemoteLaboratory.Mqtt
{
	public sealed class MqttSubscriber : MqttMember
	{
		/// <summary>
		/// Когда сообщение приходит с брокера возвращает json в виде строки или просто строку.
		/// </summary>
		public event Action<string> MessageReceivedEvent;

		public override string Topic { get; }
		protected override IMqttClientOptions Options { get; }
		protected override IMqttClient Client { get; }

		public MqttSubscriber(MqttParams mqttParams)
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
			Client.UseApplicationMessageReceivedHandler(MessageReceived);
		}

		protected override async Task Connected(MqttClientConnectedEventArgs e)
		{
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
		/// Закидывает в эвент строку json 
		/// </summary>
		/// <param name="e"></param>
		private void MessageReceived(MqttApplicationMessageReceivedEventArgs e) 
		{
			var value = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
			MessageReceivedEvent?.Invoke(value);
		}
	}
}
