using FubuCoreDemo.Testing.FakeObjects;
using StructureMap;

namespace FubuCoreDemo.Testing.Registries
{
    public class SecondRegistry : Registry
    {
        public SecondRegistry()
        {
            For<ITestClass>().Use<TestClass>();
        }
    }
}