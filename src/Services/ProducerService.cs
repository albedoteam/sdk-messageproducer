using System.Threading.Tasks;
using AlbedoTeam.Sdk.MessageProducer.Services.Abstractions;
using MassTransit;

namespace AlbedoTeam.Sdk.MessageProducer.Services
{
    public class ProducerService : IProducerService
    {
        private readonly IPublishEndpoint _publisher;
        private readonly ISendEndpointProvider _sender;

        public ProducerService(
            IPublishEndpoint publisher,
            ISendEndpointProvider sender)
        {
            _publisher = publisher;
            _sender = sender;
        }

        public async Task Send<T>(object command) where T : class
        {
            await _sender.Send<T>(command);
        }

        public async Task Publish<T>(object message) where T : class
        {
            await _publisher.Publish<T>(message);
        }
    }
}