using System;
using FubuCore.Logging;
using FubuMVC.Core.Behaviors;
using FubuMVC.Core.Http;
using FubuMVC.Core.Registration.Nodes;

namespace FubuCoreDemo.MVC
{
    public class FirstLoggingBehavior : WrappingBehavior
    {
        private readonly ICurrentChain _chain;
        private readonly ILogger _logger;

        public FirstLoggingBehavior(ICurrentChain chain, ILogger logger)
        {
            _chain = chain;
            _logger = logger;
        }

        protected override void invoke(Action action)
        {
            _logger.Debug($"Running FirstLoggingBehavior");
            action();
        }
    }
}
