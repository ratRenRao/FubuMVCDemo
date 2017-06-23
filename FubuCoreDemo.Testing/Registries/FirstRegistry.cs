using FubuCoreDemo.Testing.FakeObjects;
using StructureMap;

namespace FubuCoreDemo.Testing.Registries
{
    public class FirstRegistry : Registry
    {
        public FirstRegistry()
        {
            For<ITestClass>().Use<TestClass>();
        }
    }
}