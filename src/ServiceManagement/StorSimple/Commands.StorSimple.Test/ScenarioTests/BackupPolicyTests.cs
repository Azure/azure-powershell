using Xunit;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Test.ScenarioTests
{
    public class BackupPolicyTests:StorSimpleTestBase
    {
        #region New-AzureStorSimpleDeviceBackupScheduleAddConfig
        [Fact]
        [Trait("StorSimpleCmdlets", "New-BackupPolicyConfig")]
        public void TestNewBackupPolicyConfig()
        {
            RunPowerShellTest("Test-NewBackupPolicyAddConfig");
        }

        [Fact]
        [Trait("StorSimpleCmdlets", "New-BackupPolicyConfig")]
        public void TestNewBackupPolicyAddConfigDefaultValues()
        {
            RunPowerShellTest("Test-NewBackupPolicyAddConfig-DefaultValues");
        }
        #endregion New-AzureStorSimpleDeviceBackupScheduleAddConfig
    }
}
