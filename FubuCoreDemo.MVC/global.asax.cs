using System;
using System.Web;
using FubuMVC.Core;

namespace FubuCoreDemo.MVC
{
    public class Global : HttpApplication
    {
        private FubuRuntime _runtime;

        protected void Application_Start(object sender, EventArgs e)
        {
            _runtime = FubuRuntime.For<AppRegistry>();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            _runtime.Dispose();
        }
    }
}