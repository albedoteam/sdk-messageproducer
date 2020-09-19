using MessageProducerSdk.Configuration.Abstractions;

namespace MessageProducerSdk.Configuration
{
    public class ProducerOptions : IProducerOptions
    {
        public string BrokerHost { get; set; }
    }
}