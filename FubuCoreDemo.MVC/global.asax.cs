using System;
using System.Web;
using FubuMVC.Core;

namespace FubuCoreDemo.MVC
{
    public class Global : HttpApplication
    {
        private FubuRuntime _runtime;

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000"); // Should probably lock down to just login.microsoftonline.com
            HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "X-Requested-With, POST");
        }

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