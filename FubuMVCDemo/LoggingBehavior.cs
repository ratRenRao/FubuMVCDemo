using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FubuCore.Logging;
using FubuMVC.Core.Behaviors;
using FubuMVC.Core.Http;

namespace FubuMVCDemo
{
    public class LoggingBehavior : WrappingBehavior
    {
        private readonly ICurrentChain _chain;
        private readonly ILogger _logger;

        public LoggingBehavior(ICurrentChain chain, ILogger logger)
        {
            _chain = chain;
            _logger = logger;
        }

        protected override void invoke(Action action)
        {
            _logger.Debug($"Entered LogginBehavior");
            action();
        }
    }
}
