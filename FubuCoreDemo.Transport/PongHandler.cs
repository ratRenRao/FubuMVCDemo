using System;
using System.Threading.Tasks;

namespace FubuCoreDemo.Transport
{
    public class PongHandler
    {
        private readonly IPongWriter _writer;

        public PongHandler(IPongWriter writer)
        {
            _writer = writer;
        }

        public Task Handle(PongMessage pong)
        {
            Console.WriteLine("Received pong message");
            return _writer.WritePong(pong);
        }
    }

    public interface IPongWriter
    {
        Task WritePong(PongMessage message);
    }
}
