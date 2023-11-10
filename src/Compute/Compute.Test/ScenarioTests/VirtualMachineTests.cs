// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Xunit;

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    public partial class VirtualMachineTests : ComputeTestRunner
    {
        public VirtualMachineTests(Xunit.Abstractions.ITestOutputHelper output)
            : base(output)
        {
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachine()
        {
            TestRunner.RunTestScript("Test-VirtualMachine 'eastus2euap'");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachine_Managed()
        {
            TestRunner.RunTestScript("Test-VirtualMachine 'eastus2euap' $true");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineInEdgeZone()
        {
            TestRunner.RunTestScript("Test-VirtualMachineInEdgeZone");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePiping()
        {
            TestRunner.RunTestScript("Test-VirtualMachinePiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineUpdateWithoutNic()
        {
            TestRunner.RunTestScript("Test-VirtualMachineUpdateWithoutNic");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLinuxVirtualMachine()
        {
            TestRunner.RunTestScript("Test-LinuxVirtualMachine");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithVMAgentAutoUpdate()
        {
            TestRunner.RunTestScript("Test-VirtualMachineWithVMAgentAutoUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineImageList()
        {
            TestRunner.RunTestScript("Test-VirtualMachineImageList");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineList()
        {
            TestRunner.RunTestScript("Test-VirtualMachineList");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineSizeAndUsage()
        {
            TestRunner.RunTestScript("Test-VirtualMachineSizeAndUsage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCapture()
        {
            TestRunner.RunTestScript("Test-VirtualMachineCapture");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineCaptureNegative()
        {
            TestRunner.RunTestScript("Test-VirtualMachineCaptureNegative");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineDataDisk()
        {
            TestRunner.RunTestScript("Test-VirtualMachineDataDisk");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineDataDiskNegative()
        {
            TestRunner.RunTestScript("Test-VirtualMachineDataDiskNegative");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePIRv2()
        {
            TestRunner.RunTestScript("Test-VirtualMachinePIRv2");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePlan()
        {
            TestRunner.RunTestScript("Test-VirtualMachinePlan");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePlan2()
        {
            TestRunner.RunTestScript("Test-VirtualMachinePlan2");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineTags()
        {
            TestRunner.RunTestScript("Test-VirtualMachineTags");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMImageCmdletOutputFormat()
        {
            TestRunner.RunTestScript("Test-VMImageCmdletOutputFormat");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMImageEdgeZoneCmdletOutputFormat()
        {
            TestRunner.RunTestScript("Test-VMImageEdgeZoneCmdletOutputFormat");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVMSizeFromAllLocations()
        {
            TestRunner.RunTestScript("Test-GetVMSizeFromAllLocations");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineListWithPaging()
        {
            TestRunner.RunTestScript("Test-VirtualMachineListWithPaging");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithDifferentStorageResource()
        {
            TestRunner.RunTestScript("Test-VirtualMachineWithDifferentStorageResource");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithPremiumStorageAccount()
        {
            TestRunner.RunTestScript("Test-VirtualMachineWithPremiumStorageAccount");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithEmptyAuc()
        {
            TestRunner.RunTestScript("Test-VirtualMachineWithEmptyAuc");
        }

        [Fact(Skip = "Unknown issue/update, needs re-recorded")]
        [Trait(Category.RunType, Category.DesktopOnly)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWithBYOL()
        {
            TestRunner.RunTestScript("Test-VirtualMachineWithBYOL");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineRedeploy()
        {
            TestRunner.RunTestScript("Test-VirtualMachineRedeploy");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineReapply()
        {
            TestRunner.RunTestScript("Test-VirtualMachineReapply");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineGetStatus()
        {
            TestRunner.RunTestScript("Test-VirtualMachineGetStatus");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VirtualMachineGetStatusWithHealhtExtension()
        {
            TestRunner.RunTestScript("Test-VirtualMachineGetStatusWithHealhtExtension");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void VirtualMachineRemoveExtension()
        {
            TestRunner.RunTestScript("Test-VirtualMachineRemoveExtension");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineGetHost()
        {
            TestRunner.RunTestScript("Test-VirtualMachineGetHost");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineGetStatusWithAssignedHost()
        {
            TestRunner.RunTestScript("Test-VirtualMachineGetStatusWithAssignedHost");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineManagedDiskConversion()
        {
            TestRunner.RunTestScript("Test-VirtualMachineManagedDiskConversion");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineDiskDeleteOption()
        {
            TestRunner.RunTestScript("Test-VirtualMachineDiskDeleteOption");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePerformanceMaintenance()
        {
            TestRunner.RunTestScript("Test-VirtualMachinePerformanceMaintenance");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineIdentity()
        {
            TestRunner.RunTestScript("Test-VirtualMachineIdentity");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineIdentityUpdate()
        {
            TestRunner.RunTestScript("Test-VirtualMachineIdentityUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineWriteAcceleratorUpdate()
        {
            TestRunner.RunTestScript("Test-VirtualMachineWriteAcceleratorUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineManagedDisk()
        {
            TestRunner.RunTestScript("Test-VirtualMachineManagedDisk");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineReimage()
        {
            TestRunner.RunTestScript("Test-VirtualMachineReimage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineStop()
        {
            TestRunner.RunTestScript("Test-VirtualMachineStop");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineRemoteDesktop()
        {
            TestRunner.RunTestScript("Test-VirtualMachineRemoteDesktop");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestLowPriorityVirtualMachine()
        {
            TestRunner.RunTestScript("Test-LowPriorityVirtualMachine");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEncryptionAtHostVMNull()
        {
            TestRunner.RunTestScript("Test-EncryptionAtHostVMNull");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEncryptionAtHostVM()
        {
            TestRunner.RunTestScript("Test-EncryptionAtHostVM");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEncryptionAtHostVMDefaultParameterSet()
        {
            TestRunner.RunTestScript("Test-EncryptionAtHostVMDefaultParamSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzVMOperatingSystem()
        {
            TestRunner.RunTestScript("Test-SetAzVMOperatingSystem");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestSetAzVMOperatingSystemError()
        {
            TestRunner.RunTestScript("Test-SetAzVMOperatingSystemError");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestHostGroupPropertySetOnVirtualMachine()
        {
            TestRunner.RunTestScript("Test-HostGroupPropertySetOnVirtualMachine");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineImageListTopOrderExpand()
        {
            TestRunner.RunTestScript("Test-VirtualMachineImageListTopOrderExpand");
        }
         
        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestVirtualMachineBootDiagnostics()
        {
            TestRunner.RunTestScript("Test-VirtualMachineBootDiagnostics");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineGetVMNameAcrossResourceGroups()
        {
            TestRunner.RunTestScript("Test-VirtualMachineGetVMNameAcrossResourceGroups");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineGetVMExtensionPiping()
        {
            TestRunner.RunTestScript("Test-VirtualMachineGetVMExtensionPiping");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePatchAPI()
        {
            TestRunner.RunTestScript("Test-VirtualMachinePatchAPI");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestNewAzVMDefaultingSize()
        {
            TestRunner.RunTestScript("Test-NewAzVMDefaultingSize");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestInvokeAzVMInstallPatch()
        {
            TestRunner.RunTestScript("Test-InvokeAzVMInstallPatch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineAssessmentMode()
        {
            TestRunner.RunTestScript("Test-VirtualMachineAssessmentMode");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineEnableAutoUpdate()
        {
            TestRunner.RunTestScript("Test-VirtualMachineEnableAutoUpdate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCapacityReservation()
        {
            TestRunner.RunTestScript("Test-CapacityReservation");
        }

        [Fact(Skip = "Cannot run on Github Platform due to ACL API")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMwithSSHKey()
        {
            TestRunner.RunTestScript("Test-VMwithSSHKey");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMUserData()
        {
            TestRunner.RunTestScript("Test-VMUserData");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMUserDataBase64Encoded()
        {
            TestRunner.RunTestScript("Test-VMUserDataBase64Encoded");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMNoPublicIPAddress()
        {
            TestRunner.RunTestScript("Test-VMNoPublicIPAddress");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMForceDelete()
        {
            TestRunner.RunTestScript("Test-ForceDelete");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineDiffDiskPlacement()
        {
            TestRunner.RunTestScript("Test-VirtualMachineDiffDiskPlacement");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineHibernate()
        {
            TestRunner.RunTestScript("Test-VirtualMachineHibernate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMvCPUFeatures()
        {
            TestRunner.RunTestScript("Test-VMvCPUFeatures");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestGetVirtualMachineById()
        {
            TestRunner.RunTestScript("Test-GetVirtualMachineById");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePlatformFaultDomain()
        {
            TestRunner.RunTestScript("Test-VirtualMachinePlatformFaultDomain");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMandVMSSTimeCreated()
        {
            TestRunner.RunTestScript("Test-VMandVMSSTimeCreated");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConfidentialVMSetAzVmOsDisk()
        {
            TestRunner.RunTestScript("Test-ConfidentialVMSetAzVmOsDisk");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConfVMSetAzVMSecurityProfile()
        {
            TestRunner.RunTestScript("Test-ConfVMSetAzVMSecurityProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConfVMSetAzDiskSecurityProfile()
        {
            TestRunner.RunTestScript("Test-ConfVMSetAzDiskSecurityProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConfVMSetAzDiskEncryptionSetConfig()
        {
            TestRunner.RunTestScript("Test-ConfVMSetAzDiskEncryptionSetConfig");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConfVMSetAzDiskSecurityProfileNoDES()
        {
            TestRunner.RunTestScript("Test-ConfVMSetAzDiskSecurityProfileNoDES");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestConfidentialVMSetAzVmOsDiskDesIdDiskWithVMGuestManual()
        {
            TestRunner.RunTestScript("Test-ManualConfidentialVMSetAzVmOsDiskDesIdDiskWithVMGuest");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineEdgeZoneSimpleParameterSet()
        {
            TestRunner.RunTestScript("Test-VirtualMachineEdgeZoneSimpleParameterSet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineSecurityType()
        {
            TestRunner.RunTestScript("Test-VirtualMachineSecurityType");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineSecurityTypeWithoutConfig()
        {
            TestRunner.RunTestScript("Test-VirtualMachineSecurityTypeWithoutConfig");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineSecurityTypeStandard()
        {
            TestRunner.RunTestScript("Test-VirtualMachineSecurityTypeStandard");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineSecurityTypeStandardWithConfig()
        {
            TestRunner.RunTestScript("Test-VirtualMachineSecurityTypeStandardWithConfig");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMDefaultsToTrustedLaunch()
        {
            TestRunner.RunTestScript("Test-VMDefaultsToTrustedLaunch");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestVMDefaultsToTrustedLaunchWithManagedDisk()
        {
            TestRunner.RunTestScript("Test-VMDefaultsToTrustedLaunchWithManagedDisk");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMDefaultsToTrustedLaunchWithGen2Image()
        {
            TestRunner.RunTestScript("Test-VMDefaultsToTrustedLaunchWithGen2Image");
        }
    }
}
