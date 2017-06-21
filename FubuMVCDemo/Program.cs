using System;
using System.Threading;
using System.Threading.Tasks;
using FubuMVC.Core;
using FubuMVC.Core.ServiceBus;
using StructureMap;

namespace FubuMVCDemo
{
    class Program
    {
        private static readonly ManualResetEvent ExitHandle = new ManualResetEvent(false);

        static void Main(string[] args)
        {
            Task.Run(() =>
            {
                while((Console.ReadKey().Modifiers & ConsoleModifiers.Control) != 0) { }
                
                ExitHandle.Set();
            });

            Task.Run(() => StartDemo());

            // Runs until the handle is set by hiting ctrl + c
            ExitHandle.WaitOne();
        }

        static void StartDemo()
        {
            // Bootstrapping and runtime configuration
            var pingAppRuntime = FubuRuntime.For<PingApp>(_ =>
                // Diagnostics
                _.Features.Diagnostics.Enable(TraceLevel.Verbose)
            );
            var pongAppRuntime = FubuRuntime.For<PongApp>(_ =>
                // Diagnostics
                _.Features.Diagnostics.Enable(TraceLevel.Verbose)
            );
        }
    }
}
