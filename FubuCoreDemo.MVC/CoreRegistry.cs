using FubuCoreDemo.MVC.DataAccess;
using FubuMVC.Core.Registration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FubuCoreDemo.MVC
{
    public class CoreRegistry : ServiceRegistry
    {
        public CoreRegistry()
        {
            For<IListDataAccess>().Use<DataAccess.ListDataAccess>();

            ReplaceService(new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            Scan(x =>
            {
                x.TheCallingAssembly();
                x.WithDefaultConventions();
            });
        }
    }
}