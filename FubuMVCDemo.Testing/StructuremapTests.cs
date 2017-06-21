using System.Diagnostics;
using FubuMVC.Core.Validation;
using FubuMVCDemo.Testing.Registries;
using Shouldly;
using StructureMap;
using Xunit;
using NLog;

namespace FubuMVCDemo.Testing
{
    public class StructuremapTests
    {
        private static Logger _logger;

        public StructuremapTests()
        {
            LogManager.ThrowExceptions = true;
            _logger = LogManager.GetCurrentClassLogger();
        }

        [Fact]
        public void can_use_registry_dsls()
        {
            var registry = new Registry();
            registry.IncludeRegistry<FirstRegistry>();
            registry.IncludeRegistry<SecondRegistry>();

            var container = new Container(registry);

            // Verifies registry
            container.GetInstance<ITestClass>().ShouldBeOfType<TestClass>();
            container.GetAllInstances<ITestClass>().Count().ShouldBe(2);
        }

        [Fact]
        public void registry_scanning_functions_correctly()
        {
            var container = new Container(_ =>
            {
                _.Scan(x =>
                {
                    x.TheCallingAssembly();
                    x.WithDefaultConventions();
                    x.RegisterConcreteTypesAgainstTheFirstInterface();
                    x.SingleImplementationsOfInterface();
                });

                _.Scan(x =>
                {
                    x.Description = "Second Scanner";
                    x.AssembliesFromApplicationBaseDirectory(assem => assem.FullName.Contains("TestClass"));
                    x.AddAllTypesOf<ITestClass>();
                });
            });

            var scanResults = container.WhatDidIScan();

            _logger.Debug($"***DEBUG*** : {scanResults}");
            _logger.Error($"***ERROR*** : {scanResults}");

            scanResults.ShouldNotBeNull();
        }
    }
}
