namespace IotRemoteLaboratory.Mqtt
{
    public sealed class MqttParams
    {
        public string Ip { get; }
        public int Port { get; }
        public string Topic { get; }

        public MqttParams(string ip, int port, string topic)
        {
            Ip = ip;
            Port = port;
            Topic = topic;
        }
    }
}
