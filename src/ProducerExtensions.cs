using System;
using AlbedoTeam.Sdk.MessageConsumer;
using AlbedoTeam.Sdk.MessageConsumer.Configuration.Abstractions;
using AlbedoTeam.Sdk.MessageProducer.Services;
using AlbedoTeam.Sdk.MessageProducer.Services.Abstractions;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlbedoTeam.Sdk.MessageProducer
{
    public static class ProducerExtensions
    {
        public static IServiceCollection AddProducer(
            this IServiceCollection services,
            Action<IMessageBrokerOptions> configureBroker,
            Action<IConsumerRegistration> consumers)
        {
            return services.AddProducerOnHub(configureBroker, consumers);
        }

        public static IServiceCollection AddProducer(
            this IServiceCollection services,
            Action<IMessageBrokerOptions> configureBroker,
            Action<IConsumerRegistration> consumers,
            Action<IDestinationQueueMapper> queues)
        {
            return services.AddProducerOnHub(configureBroker, consumers, queues);
        }

        public static IServiceCollection AddProducerOnHub(
            this IServiceCollection services,
            Action<IMessageBrokerOptions> configureBroker,
            Action<IConsumerRegistration> consumers = null,
            Action<IDestinationQueueMapper> queues = null)
        {
            services.AddBroker(configureBroker, consumers, queues);
            services.AddMassTransitHostedService();
            services.AddScoped<IProducerService, ProducerService>();

            return services;
        }
    }
}