using System;
using MassTransit;
using MessageConsumerSdk;
using MessageConsumerSdk.Configuration.Abstractions;
using MessageProducerSdk.Services;
using MessageProducerSdk.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MessageProducerSdk
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