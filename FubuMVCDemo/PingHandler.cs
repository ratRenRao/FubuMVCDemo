using System;

namespace FubuMVCDemo
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
