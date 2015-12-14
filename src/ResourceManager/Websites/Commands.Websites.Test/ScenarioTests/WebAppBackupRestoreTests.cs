using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;

namespace Microsoft.Azure.Commands.Websites.Test.ScenarioTests
{
    public class WebAppBackupRestoreTests : RMTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewWebApp()
        {
            WebsitesController.NewInstance.RunPsTest("Test-CreateNewWebAppBackup");
        }
    }
}