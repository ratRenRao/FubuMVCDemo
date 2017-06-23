using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FubuMVC.Core;
using FubuMVC.Core.Http.Hosting;

namespace FubuMVCDemo
{
    public class MVCDemo
    {
        public void StartApplication()
        {
            using (var runtime = FubuRuntime.Basic(_ => _.HostWith<NOWIN>()))
            {
                Console.WriteLine("Web application available at " + runtime.BaseAddress);
            }
        }
    }

    public class HomeEndpoint
    {
        public string Index()
        {
            return "Goodbye world";
        }
    }
}
