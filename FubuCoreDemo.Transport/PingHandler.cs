using System;

namespace FubuCoreDemo.Transport
{
    public class PingHandler
    {
        public PongMessage Handle(PingMessage ping)
        {
            Console.WriteLine("Received ping message");
            return new PongMessage();
        }
    }
}
