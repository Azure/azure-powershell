using Commands.StorSimple.Test;
using Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets;
using Xunit;

namespace Microsoft.Azure.Commands.StorSimple.Test.ScenarioTests
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
        public void TestGetAllDevices_DefaultValues()
        {
            RunPowerShellTest("Test-NewBackupPolicyAddConfig-DefaultValues");
        }
        #endregion New-AzureStorSimpleDeviceBackupScheduleAddConfig
    }
}
