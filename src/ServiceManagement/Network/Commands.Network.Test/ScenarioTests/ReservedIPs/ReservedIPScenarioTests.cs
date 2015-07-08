namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Network.Test.ScenarioTests.ReservedIPs
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

    public class ReservedIPScenarioTests
    {
        private readonly EnvironmentSetupHelper helper = new EnvironmentSetupHelper();
        
        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void AzureReservedIPSimpleOperations()
        {
            RunPowerShellTest("Test-AzureReservedIPSimpleOperations");
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void CreateVMWithReservedIP()
        {
            RunPowerShellTest("Test-CreateVMWithReservedIP");
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void SetReservedIPAssociationSimple()
        {
            RunPowerShellTest("Test-SetAzureReservedIPAssociationSingleVip");
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void RemoveReservedIPAssociationSimple()
        {
            RunPowerShellTest("Test-RemoveAzureReservedIPAssociationSingleVip");
        }

        [Fact]
        [Trait(Category.Service, Category.Network)]
        [Trait(Category.RunType, Category.LiveOnly)]
        public void ReserveExistingDeploymentIP()
        {
            RunPowerShellTest("Test-ReserveExistingDeploymentIP");
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

                List<string> modules = Directory.GetFiles("ScenarioTests\\ReservedIPs", "*.ps1").ToList();
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
