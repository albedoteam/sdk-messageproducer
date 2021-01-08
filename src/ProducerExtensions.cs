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
            IConfiguration configuration,
            Action<IConsumerRegistration> consumers = null,
            Action<IDestinationQueueMapper> queues = null)
        {
            services.AddConsumer(configuration, consumers, queues);
            services.AddMassTransitHostedService();
            services.AddScoped<IProducerService, ProducerService>();

            return services;
        }
    }
}