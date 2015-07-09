namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.ScenarioTests.MultiVip
{
    using Microsoft.Azure.Common.Authentication;
    using Microsoft.Azure.Test;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Microsoft.WindowsAzure.Management;
    using Microsoft.WindowsAzure.Management.Network;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Xunit;

    public class MultiVipScenarioTests
    {
        private readonly EnvironmentSetupHelper helper = new EnvironmentSetupHelper();

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.RunType, Category.CheckIn)]
        public void AdditionalVipLifecycle()
        {
            RunPowerShellTest("Test-AdditionalVipLifecycle");
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.RunType, Category.CheckIn)]
        public void AdditionalVipMobility()
        {
            RunPowerShellTest("Test-AdditionalVipMobility");
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.RunType, Category.CheckIn)]
        public void ReserveMultivipDepIP()
        {
            RunPowerShellTest("Test-ReserveExistingDeploymentIPMultivip");
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.RunType, Category.CheckIn)]
        public void SetLBEndpointMultivipDep()
        {
            RunPowerShellTest("Test-SetLBEndpoint");
        }

        #region Test setup

        protected void SetupManagementClients()
        {
            var client = TestBase.GetServiceClient<NetworkManagementClient>(new RDFETestEnvironmentFactory());
            var client2 = TestBase.GetServiceClient<ManagementClient>(new RDFETestEnvironmentFactory());
            helper.SetupSomeOfManagementClients(client, client2);
        }

        protected void RunPowerShellTest(params string[] scripts)
        {
            using (UndoContext context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(2), TestUtilities.GetCurrentMethodName(2));

                List<string> modules = Directory.GetFiles("ScenarioTests\\MultiVip", "*.ps1").ToList();
                modules.AddRange(Directory.GetFiles("ScenarioTests", "*.ps1"));
                modules.Add("Common.ps1");

                SetupManagementClients();

                helper.SetupEnvironment(AzureModule.AzureServiceManagement);
                helper.SetupModules(AzureModule.AzureServiceManagement, modules.ToArray());

                helper.RunPowerShellTest(scripts);
            }
        }
        #endregion
    }
}
