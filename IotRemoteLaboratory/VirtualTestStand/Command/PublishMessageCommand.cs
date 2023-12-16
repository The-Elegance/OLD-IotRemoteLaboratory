using IotRemoteLaboratory.Mqtt;

namespace VirtualTestStand.Command
{
    internal class PublishMessageCommand : ConsoleCommand
    {
        private readonly MqttPublisher _mqttPublisher;

        public PublishMessageCommand(string name, string help, TextWriter writer, MqttPublisher mqttPublisher) : base(name, help, writer)
        {
            _mqttPublisher = mqttPublisher;
        }

        public override void Execute(string[] args)
        {
            // First Item in args - Topic
            // Second Item in args - Message

            if (args.Length < 2)
                return;

            if (args.Length >= 3)
            {
                var field = typeof(Topics).GetField(args[1]);

                if (field != null)
                    _mqttPublisher.PublishMessageAsync(field.GetValue(null).ToString(), string.Join(' ', args.Skip(2).ToArray()));
                else
                    _writer.WriteLine($"Cosnt value with name - {args[1]} doesn't exitst.");
            }
        }
    }
}
