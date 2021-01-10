using System;
using AlbedoTeam.Sdk.MessageConsumer;
using AlbedoTeam.Sdk.MessageConsumer.Configuration.Abstractions;
using AlbedoTeam.Sdk.MessageProducer.Services;
using AlbedoTeam.Sdk.MessageProducer.Services.Abstractions;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace AlbedoTeam.Sdk.MessageProducer
{
    public static class ProducerExtensions
    {
        public static IServiceCollection AddProducer(
            this IServiceCollection services,
            Action<IBrokerConfigurator> configureBroker,
            Action<IConsumerRegistration> configureConsumers,
            Action<IDestinationQueueMapper> configureDestinationQueues)
        {
            return services.AddProducerOnHub(configureBroker, configureConsumers, configureDestinationQueues);
        }

        public static IServiceCollection AddProducer(
            this IServiceCollection services,
            Action<IBrokerConfigurator> configureBroker,
            Action<IConsumerRegistration> configureConsumers,
            Action<IDestinationQueueMapper> configureDestinationQueues,
            Action<IRequestClientRegistration> configureRequestClients)
        {
            return services.AddProducerOnHub(configureBroker, configureConsumers, configureDestinationQueues,
                configureRequestClients);
        }

        public static IServiceCollection AddProducer(
            this IServiceCollection services,
            Action<IBrokerConfigurator> configureBroker,
            Action<IRequestClientRegistration> configureRequestClients)
        {
            return services.AddProducerOnHub(configureBroker, null, null,
                configureRequestClients);
        }

        private static IServiceCollection AddProducerOnHub(
            this IServiceCollection services,
            Action<IBrokerConfigurator> configureBroker,
            Action<IConsumerRegistration> configureConsumers = null,
            Action<IDestinationQueueMapper> configureDestinationQueues = null,
            Action<IRequestClientRegistration> configureRequestClients = null)
        {
            services.AddBroker(configureBroker, configureConsumers, configureDestinationQueues,
                configureRequestClients);

            services.AddMassTransitHostedService();
            services.AddScoped<IProducerService, ProducerService>();

            return services;
        }
    }
}