using Microsoft.Azure.Common.Extensions;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;


namespace Commands.ApiManagement.Test.ScenarioTests
{
    using System;
    using Microsoft.Azure.Commands.ApiManagement.Commands;
    using Microsoft.Azure.Management.ApiManagement;
    using Microsoft.Azure.Test;

    public class ApiManagementTests
    {
        private EnvironmentSetupHelper helper;

        public ApiManagementTests()
        {
            helper = new EnvironmentSetupHelper();
        }


        protected void SetupManagementClients()
        {
            var apiManagementManagementClient = GetApiManagementManagementClient();
            helper.SetupManagementClients(apiManagementManagementClient);
        }

        private ApiManagementClient GetApiManagementManagementClient()
        {
            return TestBase.GetServiceClient<ApiManagementClient>(new CSMTestEnvironmentFactory());
        }


        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestApiManagement()
        {
            RunPowerShellTest("Test-NewApiManagement");
        }

        private void RunPowerShellTest(params string[] scripts)
        {
#if DEBUG
            Environment.SetEnvironmentVariable("AZURE_TEST_MODE", "Record");

            Environment.SetEnvironmentVariable(
                "TEST_CSM_ORGID_AUTHENTICATION",
                "SubscriptionId=bb3f6f90-0996-4c18-8d61-028ab0f0f29b;Environment=Dogfood;AADTenant=83abe5cd-bcc3-441a-bd86-e6a75360cecc");

            Environment.SetEnvironmentVariable(
                "TEST_ORGID_AUTHENTICATION",
                "SubscriptionId=bb3f6f90-0996-4c18-8d61-028ab0f0f29b;Environment=Dogfood");
#endif

            using (var context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(), TestUtilities.GetCurrentMethodName(2));

                SetupManagementClients();

                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                helper.SetupModules(AzureModule.AzureResourceManager, "ScenarioTests\\" + GetType().Name + ".ps1");

                helper.RunPowerShellTest(scripts);
            }
        }
    }
}