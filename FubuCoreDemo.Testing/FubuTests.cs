using System.Linq;
using System.Threading.Tasks;
using FubuCoreDemo.Transport;
using FubuMVC.Core;
using FubuMVC.Core.ServiceBus;
using Shouldly;
using Xunit;

namespace FubuCoreDemo.Testing
{
    public class FubuTests
    {
        [Fact]
        public async Task messages_can_be_sent_and_received()
        {
            // Spin up the two applications
            var pinger = FubuRuntime.For<PingApp>();
            var ponger = FubuRuntime.For<PongApp>();

            var bus = pinger.Get<IServiceBus>();

            // This sends a PingMessage and waits for a corresponding
            // PongMessage reply
            var pong = await bus.Request<PongMessage>(new PingMessage());

            pong.ShouldNotBe(null);

            pinger.Dispose();
            ponger.Dispose();
        }

        [Fact]
        public async Task registry_AddService_creates_instance()
        {
            var runtime = FubuRuntime.For<PingApp>();

            var count = runtime.CurrentContainer.GetAllInstances<IFakeService>().Count();

            count.ShouldBe(1);
        }

        [Fact]
        public async Task behavior_for_LoggingPolicy_functions()
        {
            var pinger = FubuRuntime.For<PingApp>();
            var ponger = FubuRuntime.For<PongApp>();

            var bus = pinger.Get<IServiceBus>();

            var pong = await bus.Request<PongMessage>(new PingMessage());

            pinger.Dispose();
            ponger.Dispose();
        }

        [Fact]
        public async Task data_is_populated_into_handler_from_csv()
        {
            var localizationDemo = new LocalizationDemo();
            var stringTokens = localizationDemo.LoadDataIntoStringTokens();
            stringTokens.Count().ShouldBe(2);
        }

        [Fact]
        public async Task localization_allows_location_specific_data()
        {
            var pinger = FubuRuntime.For<PingApp>();
            var ponger = FubuRuntime.For<PongApp>();

            var bus = pinger.Get<IServiceBus>();

            var pong = await bus.Request<PongMessage>(new PingMessage());

            pinger.Get<StopwatchBehavior>().Stopwatch.Elapsed.Seconds.ShouldNotBe(0);

            pinger.Dispose();
            ponger.Dispose();
        }
    }
}
