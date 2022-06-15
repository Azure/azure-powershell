using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;
using Xunit.Abstractions;

namespace Commands.Aks.Test.ScenarioTests
{
    public class KubernetesTests : AksTestRunner
    {
        public KubernetesTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSimpleAzureKubernetes()
        {
            TestRunner.RunTestScript("Test-NewAzAksSimple");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureKubernetes()
        {
            TestRunner.RunTestScript("Test-NewAzAks");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzureKubernetesByServicePrincipal()
        {
            TestRunner.RunTestScript("Test-NewAzAksByServicePrincipal");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureKubernetesAddons()
        {
            TestRunner.RunTestScript("Test-NewAzAksAddons");
        }

        [Fact(Skip = "Please make sure you have graph directory.read permission which is required for grant acrpull permission.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzAksWithAcr()
        {
            TestRunner.RunTestScript("Test-NewAzAksWithAcr");
        }
        
        [Fact(Skip = "Updating service principal profile is not allowed on MSI cluster.")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestResetAzureKubernetesServicePrincipal()
        {
            TestRunner.RunTestScript("Test-ResetAzureKubernetesServicePrincipal");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestUpgradeKubernetesVersion()
        {
            TestRunner.RunTestScript("Test-UpgradeKubernetesVersion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLoadBalancer()
        {
            TestRunner.RunTestScript("Test-LoadBalancer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestApiServiceAccess()
        {
            TestRunner.RunTestScript("Test-ApiServiceAccess");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestManagedIdentity()
        {
            TestRunner.RunTestScript("Test-ManagedIdentity");
        }
    }
}