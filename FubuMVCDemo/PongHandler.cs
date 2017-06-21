using System;

namespace FubuMVCDemo
{
    public class PongHandler
    {
        public void Handle(PongMessage pong)
        {
            Console.WriteLine("Received pong message");
        }
    }
}
