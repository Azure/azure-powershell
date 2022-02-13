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

        [Fact(Skip = "Please make sure you have graph directory.read permission which is required for grant acrpull permission.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzAksWithAcr()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-NewAzAksWithAcr");
        }
        
        [Fact(Skip = "Updating service principal profile is not allowed on MSI cluster.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestResetAzureKubernetesServicePrincipal()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ResetAzureKubernetesServicePrincipal");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpgradeKubernetesVersion()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-UpgradeKubernetesVersion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLoadBalancer()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-LoadBalancer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestApiServiceAccess()
        {
            TestController.NewInstance.RunPowerShellTest(_logger, "Test-ApiServiceAccess");
        }
    }
}