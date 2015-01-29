using Microsoft.Azure.Common.Extensions;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Testing;
using Xunit;


namespace Commands.ApiManagement.Test.ScenarioTests
{
    public class ApiManagementTests
    {
        private EnvironmentSetupHelper helper;

        public ApiManagementTests()
        {
            helper = new EnvironmentSetupHelper();
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestApiManagement()
        {
            RunPowerShellTest("Test-ApiManagement");
        }

        private void RunPowerShellTest(params string[] scripts)
        {
            using (var context = UndoContext.Current)
            {
                context.Start(TestUtilities.GetCallingClass(), TestUtilities.GetCurrentMethodName(2));

                //SetupManagementClients();

                helper.SetupEnvironment(AzureModule.AzureResourceManager);
                helper.SetupModules(AzureModule.AzureResourceManager, "ScenarioTests\\" + GetType().Name + ".ps1");

                helper.RunPowerShellTest(scripts);
            }
        }
    }
}