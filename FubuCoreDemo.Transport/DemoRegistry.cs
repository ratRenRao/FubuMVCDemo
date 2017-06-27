using FubuMVC.Core;
using FubuMVC.Core.ServiceBus;
using FubuMVC.Core.ServiceBus.Events;
using FubuMVC.Core.ServiceBus.Runtime;
using FubuMVC.Core.ServiceBus.Runtime.Cascading;
using FubuMVC.Core.ServiceBus.Runtime.Invocation;
using FubuMVC.Core.ServiceBus.Runtime.Serializers;
using FubuMVC.Core.ServiceBus.Subscriptions;
using NLog;
using StructureMap;

namespace FubuCoreDemo.Transport
{
    public class DemoRegistry : Registry
    {
        public DemoRegistry()
        {
            For<IFakeService>().Use<FakeService>();
            For<ILogger>().Use(LogManager.GetCurrentClassLogger());
            For<IServiceBus>().Use<ServiceBus>();
            For<IEnvelopeSender>().Use<EnvelopeSender>();
            For<IEnvelopeSerializer>().Use<EnvelopeSerializer>();
            For<ISubscriptionCache>().Use<SubscriptionCache>();
            For<IEventAggregator>().Use<EventAggregator>();
            For<IChainInvoker>().Use<ChainInvoker>();
            For<IOutgoingSender>().Use<OutgoingSender>();
            For<ISubscriptionRepository>().Use<SubscriptionRepository>();
            For<ISubscriptionPersistence>().Use<InMemorySubscriptionPersistence>();

            Scan(x =>
            {
                x.TheCallingAssembly();
                x.WithDefaultConventions();
            });
        }
    }
}
