using System;

namespace FubuCoreDemo.Transport
{
    public class PongHandler
    {
        public void Handle(PongMessage pong)
        {
            Console.WriteLine("Received pong message");
        }
    }
}
