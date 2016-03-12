using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Microsoft.WindowsAzure.Commands.Test.Utilities.Common;
using Xunit;

namespace Microsoft.Azure.Commands.Websites.Test.ScenarioTests
{
    public class WebAppBackupRestoreTests : RMTestBase
    {
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewWebAppBackup()
        {
            WebsitesController.NewInstance.RunPsTest("Test-CreateNewWebAppBackup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCreateNewWebAppBackupPiping()
        {
            WebsitesController.NewInstance.RunPsTest("Test-CreateNewWebAppBackupPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWebAppBackup()
        {
            WebsitesController.NewInstance.RunPsTest("Test-GetWebAppBackup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetWebAppBackupList()
        {
            WebsitesController.NewInstance.RunPsTest("Test-GetWebAppBackupList");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestRemoveWebAppBackup()
        {
            WebsitesController.NewInstance.RunPsTest("Test-RemoveAzureWebAppBackup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEditAndGetWebAppBackupConfiguration()
        {
            WebsitesController.NewInstance.RunPsTest("Test-EditAndGetWebAppBackupConfiguration");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEditWebAppBackupConfigurationPiping()
        {
            WebsitesController.NewInstance.RunPsTest("Test-EditAndGetWebAppBackupConfigurationPiping");
        }
    }
}