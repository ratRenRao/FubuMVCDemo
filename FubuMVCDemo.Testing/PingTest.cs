using System.Threading.Tasks;
using FubuMVC.Core;
using FubuMVC.Core.ServiceBus;
using Shouldly;
using Xunit;

namespace FubuMVCDemo.Testing
{
    public class PingTest
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
    }
}
