using IotRemoteLaboratory.Mqtt;
using VirtualTestStand.Command;

namespace VirtualTestStand
{
    public class ConsoleApp 
    {
        private readonly MqttPublisher _mqttPublisher;
        private readonly MqttSubscriber _mqttSubscriber;
        private readonly CommandExecutor _commandExecutor;

        public ConsoleApp(MqttPublisher mqttPublisher, MqttSubscriber mqttSubscriber)
        {
            _mqttPublisher = mqttPublisher;
            _mqttSubscriber = mqttSubscriber;
            _commandExecutor = new CommandExecutor(RegisterCommands(), Console.Out);
        }

        public async Task ToCommandAwaitMode()
        {
            await Task.Run(() => 
            {
                while (true) 
                {
                    var line = Console.ReadLine();
                    if (line == null || line == "exit")
                        return;
                    _commandExecutor.Execute(line.Split(' '));
                }
            });
        }

        private ConsoleCommand[] RegisterCommands() 
        {
            return
            [
                new PublishMessageCommand("PubMsg", "PublishMessage <topic> <message>", Console.Out, _mqttPublisher),
            ];
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            var mqttParams = new MqttParams(
                "test.mosquitto.org", // ip
                1883, // port
                Topics.TerminalDataFrom,
                Topics.TerminalDataTo,
                Topics.LedButtonState,
                Topics.ButtonNoLedState,
                Topics.DebugCodeOutput,
                Topics.LedButtonState,
                Topics.Webcamera
                );

            var mqttSubscriber = new MqttSubscriber(mqttParams);
            mqttSubscriber.Connect();

            var mqttPublisher = new MqttPublisher(mqttParams);
            mqttPublisher.Connect();

            var app = new ConsoleApp(mqttPublisher, mqttSubscriber);
            app.ToCommandAwaitMode().Wait();
        }
    }
}
