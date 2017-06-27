using System.Threading.Tasks;
using FubuCoreDemo.Transport;
using FubuMVC.Core;
using FubuMVC.Core.ServiceBus;
using Xunit;
using Moq;
using Shouldly;

namespace FubuCoreDemo.Testing
{
    public class BuildChainTests
    {
        [Fact]
        public async Task chain_reordering_functions()
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
    }
}
