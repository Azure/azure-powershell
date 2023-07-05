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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAzureKubernetesAddonsEnableAndDisable()
        {
            TestRunner.RunTestScript("Test-EnableAndDisableAzAksAddons");
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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestOsSku()
        {
            TestRunner.RunTestScript("Test-OSSku");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNodeLabelsAndTags()
        {
            TestRunner.RunTestScript("Test-NodeLabels-Tags");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNodeTaints()
        {
            TestRunner.RunTestScript("Test-NodeTaints");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableEncryptionAtHost()
        {
            TestRunner.RunTestScript("Test-EnableEncryptionAtHost");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableUltraSSD()
        {
            TestRunner.RunTestScript("Test-EnableUltraSSD");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLinuxOSConfig()
        {
            TestRunner.RunTestScript("Test-LinuxOSConfig");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestMaxSurge()
        {
            TestRunner.RunTestScript("Test-MaxSurge");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPPG()
        {
            TestRunner.RunTestScript("Test-PPG");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSpot()
        {
            TestRunner.RunTestScript("Test-Spot");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableFIPS()
        {
            TestRunner.RunTestScript("Test-EnableFIPS");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAutoScalerProfile()
        {
            TestRunner.RunTestScript("Test-AutoScalerProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGpuInstanceProfile()
        {
            TestRunner.RunTestScript("Test-GpuInstanceProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableUptimeSLA()
        {
            TestRunner.RunTestScript("Test-EnableUptimeSLA");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEdgeZone()
        {
            TestRunner.RunTestScript("Test-EdgeZone");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAadProfile()
        {
            TestRunner.RunTestScript("Test-AadProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestHostGroupID()
        {
            TestRunner.RunTestScript("Test-HostGroupID");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestPodSubnetID()
        {
            TestRunner.RunTestScript("Test-PodSubnetID");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableOidcIssuer()
        {
            TestRunner.RunTestScript("Test-EnableOidcIssuer");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestOutboundType()
        {
            TestRunner.RunTestScript("Test-OutboundType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEnableAHUB()
        {
            TestRunner.RunTestScript("Test-EnableAHUB");
        }
    }
}