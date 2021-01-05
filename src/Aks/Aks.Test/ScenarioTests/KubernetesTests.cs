using Microsoft.Azure.Commands.ScenarioTest;
using Microsoft.Azure.ServiceManagement.Common.Models;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;
using Xunit.Abstractions;

namespace Commands.Aks.Test.ScenarioTests
{
    public class KubernetesTests : RMTestBase
    {
        XunitTracingInterceptor _logger;
        public KubernetesTests(ITestOutputHelper output)
        {
            _logger = new XunitTracingInterceptor(output);
            XunitTracingInterceptor.AddToContext(_logger);
            TestExecutionHelpers.SetUpSessionAndProfile();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleAzureKubernetes()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-NewAzAksSimple");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureKubernetes()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-NewAzAks");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureKubernetesByServicePrincipal()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-NewAzAksByServicePrincipal");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureKubernetesAddons()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-NewAzAksAddons");
        }
    }
}