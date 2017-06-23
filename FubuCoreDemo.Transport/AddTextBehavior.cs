using System;
using FubuMVC.Core.Behaviors;
using FubuMVC.Core.Http;
using NLog;
using StructureMap;

namespace FubuCoreDemo.Transport
{
    public class AddTextBehavior : WrappingBehavior
    {
        private readonly ICurrentChain _chain;
        private readonly ILogger _logger;
        private readonly IContainer _container;

        public AddTextBehavior(ICurrentChain chain, IContainer container)
        {
            _chain = chain;
            _container = container;
        }

        protected override void invoke(Action action)
        {
            var message = _container.TryGetInstance<PingMessage>();
            if (message != null)
            {
                message.Text = "Behavior added text";
            }

            action();
        }
    }
}