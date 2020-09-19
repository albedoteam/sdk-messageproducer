using System.Threading.Tasks;

namespace MessageProducerSdk.Services.Abstractions
{
    public interface IProducerService
    {
        Task Send<T>(object command) where T : class;
        Task Publish<T>(object message) where T : class;
    }
}