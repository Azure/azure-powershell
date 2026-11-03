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

using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.Compute.Strategies.ComputeRp;
using Microsoft.Azure.Commands.Compute.Strategies.Network;
using Microsoft.Azure.Commands.Compute.Strategies.ResourceManager;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.Azure;
using Microsoft.WindowsAzure.Commands.ScenarioTest;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
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
        public void TestVirtualMachineStopForceDeallocate()
        {
            TestRunner.RunTestScript("Test-VirtualMachineStopForceDeallocate");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineStopForceDeallocateExecution()
        {
            TestRunner.RunTestScript("Test-VirtualMachineStopForceDeallocateExecution");
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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCapacityReservationFutureReservation()
        {
            TestRunner.RunTestScript("Test-CapacityReservationFutureReservation");
        }

        [Fact]
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
        public void TestVMWithPublicIPAddressStandardSku()
        {
            TestRunner.RunTestScript("Test-VMWithPublicIPAddressStandardSku");
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
        public void TestVMProcessorModeFeatures()
        {
            TestRunner.RunTestScript("Test-VMProcessorModeFeatures");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineSpotPlusPriority()
        {
            TestRunner.RunTestScript("Test-VirtualMachineSpotPlusPriority");
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

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMDefaultsToTrustedLaunchWithNullEncryptionAtHost()
        {
            TestRunner.RunTestScript("Test-VMDefaultsToTrustedLaunchWithNullEncryptionAtHost");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestVMTLWithGallerySourceImage()
        {
            TestRunner.RunTestScript("Test-VMTLWithGallerySourceImage");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestCapacityReservationSharingProfile()
        {
            TestRunner.RunTestScript("Test-CapacityReservationSharingProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestOpenCapacityReservationGroup()
        {
            TestRunner.RunTestScript("Test-OpenCapacityReservationGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestVMDisableCapacityReservationAssignment()
        {
            TestRunner.RunTestScript("Test-VMDisableCapacityReservationAssignment");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.LiveOnly)]
        public void TestVMDefaultsToTrustedLaunchImgWhenStnd()
        {
            TestRunner.RunTestScript("Test-VMDefaultsToTrustedLaunchImgWhenStnd");
        }
        
        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestCapacityReservationGroupResourceIdsOnly()
        {
            TestRunner.RunTestScript("Test-CapacityReservationGroupResourceIdsOnly");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddVMDataDisk()
        {
            TestRunner.RunTestScript("Test-AddRemoveVMDataDisk");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMSetAzOSCredentialNullRef()
        {
            TestRunner.RunTestScript("Test-VMSetAzOSCredentialNullRef");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestAddEncryptionIdentityInAzureVmConfig()
        {
            TestRunner.RunTestScript("Test-AddEncryptionIdentityInAzureVmConfig");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestEncryptionIdentityNotPartOfAssignedIdentitiesInAzureVm()
        {
            TestRunner.RunTestScript("Test-EncryptionIdentityNotPartOfAssignedIdentitiesInAzureVm");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachinePlacement()
        {
            TestRunner.RunTestScript("Test-VirtualMachinePlacement");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineAddProxyAgentExtension()
        {
            TestRunner.RunTestScript("Test-VirtualMachineAddProxyAgentExtension");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineProxyAgentUseLocalFileRules()
        {
            TestRunner.RunTestScript("Test-VirtualMachineProxyAgentUseLocalFileRules");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVirtualMachineGalleryApplicationFlags()
        {
            TestRunner.RunTestScript("Test-VirtualMachineGalleryApplicationFlags");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMDataDiskIOPSMBPS()
        {
            TestRunner.RunTestScript("Test-VMDataDiskIOPSMBPS");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestVMStorageFaultDomainAlignment()
        {
            TestRunner.RunTestScript("Test-VMStorageFaultDomainAlignment");
        }

        #region FlexProfile

        private const string PreferredSize = "Standard_D2s_v5";
        private const string DeployedSize = "Standard_D4s_v5";

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFlexProfile()
        {
            TestRunner.RunTestScript("Test-FlexProfile");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFlexProfileAvailabilitySetValidation()
        {
            TestRunner.RunTestScript("Test-FlexProfileValidation -ValidationCase AvailabilitySet");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFlexProfileProximityPlacementGroupValidation()
        {
            TestRunner.RunTestScript("Test-FlexProfileValidation -ValidationCase ProximityPlacementGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFlexProfileCapacityReservationValidation()
        {
            TestRunner.RunTestScript("Test-FlexProfileValidation -ValidationCase CapacityReservation");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFlexProfileVmssValidation()
        {
            TestRunner.RunTestScript("Test-FlexProfileValidation -ValidationCase Vmss");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFlexProfileHostValidation()
        {
            TestRunner.RunTestScript("Test-FlexProfileValidation -ValidationCase Host");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFlexProfileHostGroupValidation()
        {
            TestRunner.RunTestScript("Test-FlexProfileValidation -ValidationCase HostGroup");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFlexProfileEmptyPreferredSizeValidation()
        {
            TestRunner.RunTestScript("Test-FlexProfileValidation -ValidationCase EmptyPreferredSize");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFlexProfileInvalidPreferredSizeValidation()
        {
            TestRunner.RunTestScript("Test-FlexProfileValidation -ValidationCase InvalidPreferredSize");
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void TestFlexProfileNullPreferredSizeValidation()
        {
            TestRunner.RunTestScript("Test-FlexProfileValidation -ValidationCase NullPreferredSize");
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConfigCreatesPreferredProfileWithoutFixedSize(bool cpuOptions)
        {
            PSVirtualMachine output = null;
            var runtime = new Mock<ICommandRuntime>();
            runtime.Setup(r => r.WriteObject(It.IsAny<object>()))
                .Callback<object>(value => output = Assert.IsType<PSVirtualMachine>(value));
            var command = new NewAzureVMConfigCommand
            {
                CommandRuntime = runtime.Object,
                VMName = "flex-vm",
                PreferredVMSize = PreferredSize
            };
            command.MyInvocation.BoundParameters.Add("PreferredVMSize", PreferredSize);
            if (cpuOptions)
            {
                command.vCPUCountAvailable = 2;
                command.vCPUCountPerCore = 1;
                command.ProcessorMode = "Deterministic";
                command.MyInvocation.BoundParameters.Add("vCPUCountAvailable", 2);
                command.MyInvocation.BoundParameters.Add("vCPUCountPerCore", 1);
                command.MyInvocation.BoundParameters.Add("ProcessorMode", "Deterministic");
            }

            command.ExecuteCmdlet();

            Assert.NotNull(output);
            Assert.Equal(PreferredSize, output.FlexProfile.PreferredVMSize);
            Assert.Null(output.HardwareProfile?.VmSize);
            if (cpuOptions)
            {
                Assert.Equal(2, output.HardwareProfile.VmSizeProperties.VCPUsAvailable);
                Assert.Equal(1, output.HardwareProfile.VmSizeProperties.VCPUsPerCore);
                Assert.Equal("Deterministic", output.HardwareProfile.ProcessorMode);
            }
            runtime.Verify(r => r.WriteObject(It.IsAny<object>()), Times.Once());
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void ConfigRequiresExactlyOneBoundSize(bool bothBound)
        {
            var command = new NewAzureVMConfigCommand { VMName = "flex-vm" };
            if (bothBound)
            {
                command.VMSize = DeployedSize;
                command.PreferredVMSize = PreferredSize;
                command.MyInvocation.BoundParameters.Add("VMSize", DeployedSize);
                command.MyInvocation.BoundParameters.Add("PreferredVMSize", PreferredSize);
            }

            var error = Assert.Throws<ArgumentException>(() => command.ExecuteCmdlet());
            Assert.Contains("VMSize", error.Message);
            Assert.Contains("PreferredVMSize", error.Message);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void PreferredSizeMetadataPreservesExistingBinding()
        {
            var size = Assert.Single(typeof(NewAzureVMConfigCommand).GetProperty("VMSize")
                .GetCustomAttributes(typeof(ParameterAttribute), false).Cast<ParameterAttribute>());
            Assert.False(size.Mandatory);
            Assert.Equal(1, size.Position);
            Assert.True(size.ValueFromPipelineByPropertyName);
            var preferred = Assert.Single(typeof(NewAzureVMConfigCommand).GetProperty("PreferredVMSize")
                .GetCustomAttributes(typeof(ParameterAttribute), false).Cast<ParameterAttribute>());
            Assert.False(preferred.Mandatory);
            Assert.True(preferred.ValueFromPipelineByPropertyName);
            Assert.Equal(ParameterAttribute.AllParameterSets, preferred.ParameterSetName);
            Assert.Equal(typeof(FlexProfile), typeof(PSVirtualMachine).GetProperty("FlexProfile").PropertyType);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SimpleNewRejectsBothSizesBeforeCallingAzure()
        {
            var command = new NewAzureVMCommand { Size = DeployedSize, PreferredVMSize = PreferredSize };
            command.MyInvocation.BoundParameters.Add("Size", DeployedSize);
            command.MyInvocation.BoundParameters.Add("PreferredVMSize", PreferredSize);

            var error = Assert.Throws<ArgumentException>(() => command.ExecuteCmdlet());

            Assert.Contains("Size", error.Message);
            Assert.Contains("PreferredVMSize", error.Message);
        }

        [Theory]
        [InlineData(null, false)]
        [InlineData(null, true)]
        [InlineData("", false)]
        [InlineData("", true)]
        [InlineData("Standard_D2s_v5", false)]
        [InlineData("Standard_D2s_v5", true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void SimpleCreateStrategySerializesExactlyOneSize(string preferredSize, bool cpuOptions)
        {
            const string nicId = "/subscriptions/test/resourceGroups/flex-rg/providers/Microsoft.Network/networkInterfaces/flex-nic";
            var group = ResourceGroupStrategy.CreateResourceGroupConfig("flex-rg");
            var nic = new ResourceConfig<Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Network.Models.NetworkInterface>(
                NetworkInterfaceStrategy.Strategy, group, "flex-nic", _ => null, null);
            var flex = preferredSize == null ? null : new FlexProfile(preferredSize);
            var config = VirtualMachineStrategy.CreateVirtualMachineConfig(
                resourceGroup: group,
                name: "flex-vm",
                networkInterface: nic,
                imageAndOsType: null,
                adminUsername: "admin01",
                adminPassword: null,
                size: DeployedSize,
                availabilitySet: null,
                identity: null,
                dataDisks: null,
                zones: null,
                proximityPlacementGroup: _ => null,
                hostId: null,
                hostGroupId: null,
                capacityReservationGroupId: null,
                VmssId: null,
                priority: null,
                evictionPolicy: null,
                maxPrice: null,
                encryptionAtHostPresent: null,
                sshPublicKeys: null,
                vCPUsAvailable: cpuOptions ? 2 : (int?)null,
                vCPUsPerCore: cpuOptions ? 1 : (int?)null,
                processorMode: cpuOptions ? "Deterministic" : null,
                flexProfile: flex);
            var engine = new Mock<IEngine>();
            engine.Setup(e => e.GetId(nic)).Returns(nicId);

            var request = config.CreateModel(engine.Object);

            Assert.Same(flex, request.FlexProfile);
            Assert.Equal(preferredSize == null ? DeployedSize : null, request.HardwareProfile.VmSize);
            Assert.Equal(nicId, Assert.Single(request.NetworkProfile.NetworkInterfaces).Id);
            Assert.Equal(cpuOptions ? 2 : (int?)null, request.HardwareProfile.VmSizeProperties?.VCPUsAvailable);
            Assert.Equal(cpuOptions ? 1 : (int?)null, request.HardwareProfile.VmSizeProperties?.VCPUsPerCore);
            Assert.Equal(cpuOptions ? "Deterministic" : null, request.HardwareProfile.ProcessorMode);
            var json = SerializeRequest(request);
            Assert.Equal(preferredSize == null ? DeployedSize : null,
                (string)json.SelectToken("properties.hardwareProfile.vmSize"));
            Assert.Equal(preferredSize, (string)json.SelectToken("properties.flexProfile.preferredVMSize"));
            Assert.Equal(preferredSize == null, json.SelectToken("properties.flexProfile") == null);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("Standard_D2s_v5")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MappingPreservesPreferredAndActualSizes(string preferredSize)
        {
            var model = new VirtualMachine(location: "eastus2", name: "flex-vm")
            {
                HardwareProfile = new HardwareProfile(DeployedSize),
                FlexProfile = preferredSize == null ? null : new FlexProfile(preferredSize)
            };

            var output = ComputeAutoMapperProfile.Mapper.Map<PSVirtualMachine>(model);
            var list = ComputeAutoMapperProfile.Mapper.Map<PSVirtualMachineList>(output);
            var roundTrip = list.ToPSVirtualMachine();
            var status = ComputeAutoMapperProfile.Mapper.Map<PSVirtualMachineListStatus>(model);

            Assert.Equal(DeployedSize, output.HardwareProfile.VmSize);
            Assert.Equal(DeployedSize, roundTrip.HardwareProfile.VmSize);
            Assert.Equal(DeployedSize, status.HardwareProfile.VmSize);
            Assert.Equal(preferredSize, output.FlexProfile?.PreferredVMSize);
            Assert.Equal(preferredSize, roundTrip.FlexProfile?.PreferredVMSize);
            Assert.Equal(preferredSize, status.FlexProfile?.PreferredVMSize);
            Assert.Equal(model.FlexProfile == null, roundTrip.FlexProfile == null);
        }

        [Theory]
        [InlineData(false, "Standard_D2s_v5")]
        [InlineData(true, "Standard_D2s_v5")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdatePreferredSizeOmitsFixedSizeWithoutMutatingInput(bool noWait, string preferredSize)
        {
            var vm = CreateInput();
            var hardware = vm.HardwareProfile;
            var flex = vm.FlexProfile;
            var before = JsonConvert.SerializeObject(vm);
            var command = CreateUpdate(vm, noWait, out var operations, out var runtime);
            command.PreferredVMSize = preferredSize;
            command.MyInvocation.BoundParameters.Add("PreferredVMSize", preferredSize);

            command.ExecuteCmdlet();

            var request = GetRequest(operations, noWait);
            Assert.NotSame(hardware, request.HardwareProfile);
            Assert.NotSame(flex, request.FlexProfile);
            Assert.Null(request.HardwareProfile.VmSize);
            Assert.Equal(preferredSize, request.FlexProfile.PreferredVMSize);
            Assert.Equal(2, request.HardwareProfile.VmSizeProperties.VCPUsAvailable);
            Assert.Equal(1, request.HardwareProfile.VmSizeProperties.VCPUsPerCore);
            Assert.Equal("Deterministic", request.HardwareProfile.ProcessorMode);
            Assert.Same(hardware, vm.HardwareProfile);
            Assert.Same(flex, vm.FlexProfile);
            Assert.Equal(before, JsonConvert.SerializeObject(vm));
            var json = SerializeRequest(request);
            Assert.Null(json.SelectToken("properties.hardwareProfile.vmSize"));
            Assert.Equal(preferredSize, (string)json.SelectToken("properties.flexProfile.preferredVMSize"));
            runtime.Verify(r => r.WriteObject(It.IsAny<object>()), Times.Once());
        }

        [Theory]
        [InlineData(false, false)]
        [InlineData(true, false)]
        [InlineData(false, true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateWithoutPreferredSizeForwardsExistingProfiles(bool noWait, bool fixedSize)
        {
            var vm = CreateInput();
            if (fixedSize)
            {
                vm.FlexProfile = null;
            }
            var command = CreateUpdate(vm, noWait, out var operations, out _);
            command.Tag = new Hashtable { { "purpose", "flex-test" } };

            command.ExecuteCmdlet();

            var request = GetRequest(operations, noWait);
            Assert.Same(vm.FlexProfile, request.FlexProfile);
            Assert.Same(vm.HardwareProfile, request.HardwareProfile);
            Assert.Equal(DeployedSize, request.HardwareProfile.VmSize);
            Assert.Equal("flex-test", request.Tags["purpose"]);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdatePreferredSizeHandlesMissingHardwareProfile()
        {
            var vm = CreateInput();
            vm.HardwareProfile = null;
            vm.FlexProfile = null;
            var command = CreateUpdate(vm, false, out var operations, out _);
            command.PreferredVMSize = PreferredSize;
            command.MyInvocation.BoundParameters.Add("PreferredVMSize", PreferredSize);

            command.ExecuteCmdlet();

            var request = GetRequest(operations, false);
            Assert.Equal(PreferredSize, request.FlexProfile.PreferredVMSize);
            Assert.Null(request.HardwareProfile.VmSize);
            Assert.Null(vm.HardwareProfile);
            Assert.Null(vm.FlexProfile);
        }

        [Fact]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateConvertsFixedSizeVmWithoutChangingItsInput()
        {
            var vm = CreateInput();
            vm.FlexProfile = null;
            var command = CreateUpdate(vm, false, out var operations, out _);
            command.PreferredVMSize = PreferredSize;
            command.MyInvocation.BoundParameters.Add("PreferredVMSize", PreferredSize);

            command.ExecuteCmdlet();

            var request = GetRequest(operations, false);
            Assert.Equal(PreferredSize, request.FlexProfile.PreferredVMSize);
            Assert.Null(request.HardwareProfile.VmSize);
            Assert.Equal(DeployedSize, vm.HardwareProfile.VmSize);
            Assert.Null(vm.FlexProfile);
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdatePreferredSizeAndCpuOptionsDoesNotMutateOriginalHardware(bool noWait)
        {
            var vm = CreateInput();
            var before = JsonConvert.SerializeObject(vm);
            var command = CreateUpdate(vm, noWait, out var operations, out _);
            command.PreferredVMSize = PreferredSize;
            command.vCPUCountAvailable = 1;
            command.vCPUCountPerCore = 2;
            command.ProcessorMode = "Opportunistic";
            command.MyInvocation.BoundParameters.Add("PreferredVMSize", PreferredSize);
            command.MyInvocation.BoundParameters.Add("vCPUCountAvailable", 1);
            command.MyInvocation.BoundParameters.Add("vCPUCountPerCore", 2);
            command.MyInvocation.BoundParameters.Add("ProcessorMode", "Opportunistic");

            command.ExecuteCmdlet();

            var request = GetRequest(operations, noWait);
            Assert.Null(request.HardwareProfile.VmSize);
            Assert.NotSame(vm.HardwareProfile.VmSizeProperties, request.HardwareProfile.VmSizeProperties);
            Assert.Equal(1, request.HardwareProfile.VmSizeProperties.VCPUsAvailable);
            Assert.Equal(2, request.HardwareProfile.VmSizeProperties.VCPUsPerCore);
            Assert.Equal("Opportunistic", request.HardwareProfile.ProcessorMode);
            Assert.Equal(before, JsonConvert.SerializeObject(vm));
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateOptOutOmitsFlexProfileAndSendsSelectedFixedSize(bool noWait)
        {
            var vm = CreateInput();
            vm.FlexProfile = null;
            vm.HardwareProfile.VmSize = PreferredSize;
            var before = JsonConvert.SerializeObject(vm);
            var command = CreateUpdate(vm, noWait, out var operations, out _);

            command.ExecuteCmdlet();

            var request = GetRequest(operations, noWait);
            Assert.Null(request.FlexProfile);
            Assert.Equal(PreferredSize, request.HardwareProfile.VmSize);
            var json = SerializeRequest(request);
            Assert.Null(json.SelectToken("properties.flexProfile"));
            Assert.Equal(PreferredSize, (string)json.SelectToken("properties.hardwareProfile.vmSize"));
            Assert.Equal(before, JsonConvert.SerializeObject(vm));
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateDirectFixedToFlowSwitchForwardsConflictingSizesToService(bool noWait)
        {
            var vm = CreateInput();
            vm.FlexProfile = new FlexProfile(PreferredSize);
            var serviceError = new CloudException("InvalidParameter: hardwareProfile.vmSize must be cleared.");
            var command = CreateUpdate(vm, noWait, out var operations, out var runtime, serviceError);

            var error = Assert.Throws<ComputeCloudException>(() => command.ExecuteCmdlet());

            Assert.Same(serviceError, error.InnerException);
            var request = GetRequest(operations, noWait);
            Assert.Equal(PreferredSize, request.FlexProfile.PreferredVMSize);
            Assert.Equal(DeployedSize, request.HardwareProfile.VmSize);
            runtime.Verify(r => r.WriteObject(It.IsAny<object>()), Times.Never());
        }

        [Theory]
        [InlineData(false, "InvalidParameter", "Not_A_Real_VM_Size")]
        [InlineData(true, "InvalidParameter", "Not_A_Real_VM_Size")]
        [InlineData(false, "OperationNotAllowed", "Standard_D2s_v5")]
        [InlineData(true, "OperationNotAllowed", "Standard_D2s_v5")]
        [InlineData(false, "RequiredParameterMissing", "")]
        [InlineData(true, "RequiredParameterMissing", "")]
        [InlineData(false, "SubscriptionNotRegisteredForFeature", "Standard_D2s_v5")]
        [InlineData(true, "SubscriptionNotRegisteredForFeature", "Standard_D2s_v5")]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void UpdateForwardsPreferredSizeServiceErrors(bool noWait, string errorCode, string preferredSize)
        {
            var message = errorCode == "SubscriptionNotRegisteredForFeature"
                ? "The subscription is not registered for the requested Microsoft.Compute preview feature."
                : errorCode == "RequiredParameterMissing"
                    ? "Required parameter 'flexProfile.preferredVMSize' is missing."
                    : "The requested flexProfile.preferredVMSize is not allowed.";
            var serviceError = new CloudException(message)
            {
                Body = new CloudError
                {
                    Code = errorCode,
                    Message = message,
                    Target = "flexProfile.preferredVMSize"
                }
            };
            var vm = CreateInput();
            var before = JsonConvert.SerializeObject(vm);
            var command = CreateUpdate(vm, noWait, out var operations, out var runtime, serviceError);
            command.PreferredVMSize = preferredSize;
            command.MyInvocation.BoundParameters.Add("PreferredVMSize", preferredSize);

            var error = Assert.Throws<ComputeCloudException>(() => command.ExecuteCmdlet());

            Assert.Same(serviceError, error.InnerException);
            Assert.Contains(message, error.Message);
            var inner = Assert.IsType<CloudException>(error.InnerException);
            Assert.Equal(errorCode, inner.Body.Code);
            Assert.Equal("flexProfile.preferredVMSize", inner.Body.Target);
            Assert.Equal(preferredSize, GetRequest(operations, noWait).FlexProfile.PreferredVMSize);
            Assert.Equal(before, JsonConvert.SerializeObject(vm));
            runtime.Verify(r => r.WriteObject(It.IsAny<object>()), Times.Never());
        }

        private static PSVirtualMachine CreateInput()
        {
            return new PSVirtualMachine
            {
                Name = "flex-vm",
                Location = "eastus2",
                HardwareProfile = new HardwareProfile(DeployedSize,
                    new VMSizeProperties(2, 1), "Deterministic"),
                FlexProfile = new FlexProfile(DeployedSize)
            };
        }

        private static UpdateAzureVMCommand CreateUpdate(PSVirtualMachine vm, bool noWait,
            out Mock<IVirtualMachinesOperations> operations, out Mock<ICommandRuntime> runtime,
            Exception requestError = null)
        {
            operations = new Mock<IVirtualMachinesOperations>(MockBehavior.Strict);
            var response = new AzureOperationResponse<VirtualMachine, VirtualMachinesCreateOrUpdateHeaders>
            {
                Body = new VirtualMachine(location: vm.Location, name: vm.Name),
                Response = new HttpResponseMessage(HttpStatusCode.OK),
                Headers = new VirtualMachinesCreateOrUpdateHeaders()
            };
            var task = requestError == null
                ? Task.FromResult(response)
                : Task.FromException<AzureOperationResponse<VirtualMachine, VirtualMachinesCreateOrUpdateHeaders>>(requestError);
            if (noWait)
            {
                operations.Setup(o => o.BeginCreateOrUpdateWithHttpMessagesAsync(
                    "flex-rg", vm.Name, It.IsAny<VirtualMachine>(), null, null, null, It.IsAny<CancellationToken>()))
                    .Returns(task);
            }
            else
            {
                operations.Setup(o => o.CreateOrUpdateWithHttpMessagesAsync(
                    "flex-rg", vm.Name, It.IsAny<VirtualMachine>(), null, null, null, It.IsAny<CancellationToken>()))
                    .Returns(task);
            }
            var client = new Mock<IComputeManagementClient>();
            client.SetupGet(c => c.VirtualMachines).Returns(operations.Object);
            runtime = new Mock<ICommandRuntime>();
            runtime.Setup(r => r.ShouldProcess(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            runtime.Setup(r => r.WriteObject(It.IsAny<object>())).Callback<object>(value =>
            {
                var output = Assert.IsType<PSAzureOperationResponse>(value);
                Assert.Equal(HttpStatusCode.OK, output.StatusCode);
                Assert.True(output.IsSuccessStatusCode);
            });
            var command = new UpdateAzureVMCommand
            {
                CommandRuntime = runtime.Object,
                ComputeClient = new ComputeClient(client.Object),
                ResourceGroupName = "flex-rg",
                VM = vm,
                NoWait = new SwitchParameter(noWait)
            };
            // Direct ExecuteCmdlet tests bypass the binder, which normally initializes this field.
            var type = typeof(PSCmdlet);
            FieldInfo parameterSet = null;
            while (type != null && parameterSet == null)
            {
                parameterSet = type.GetField("_parameterSetName", BindingFlags.Instance | BindingFlags.NonPublic);
                type = type.BaseType;
            }
            Assert.NotNull(parameterSet);
            parameterSet.SetValue(command, "ResourceGroupNameParameterSetName");
            return command;
        }

        private static VirtualMachine GetRequest(Mock<IVirtualMachinesOperations> operations, bool noWait)
        {
            var invocation = Assert.Single(operations.Invocations);
            Assert.Equal(noWait ? "BeginCreateOrUpdateWithHttpMessagesAsync" : "CreateOrUpdateWithHttpMessagesAsync",
                invocation.Method.Name);
            return Assert.IsType<VirtualMachine>(invocation.Arguments[2]);
        }

        private static JObject SerializeRequest(VirtualMachine request)
        {
            using (var client = new ComputeManagementClient(new Microsoft.Rest.TokenCredentials("unused")))
            {
                return JObject.Parse(Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(
                    request, client.SerializationSettings));
            }
        }
        #endregion
    }
}

namespace Microsoft.Azure.Commands.Compute.Test.ScenarioTests
{
    using Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption;
    using Microsoft.Azure.Commands.Compute.Models;
    using Microsoft.Azure.Management.Compute;
    using Microsoft.Azure.Management.Compute.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.WindowsAzure.Commands.ScenarioTest;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Management.Automation;
    using System.Net;
    using System.Net.Http;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    // FlexProfile preservation tests for disk encryption and AEM (Azure Enhanced Monitoring) VM update paths.
    // Kept in a separate namespace block so its using directives take precedence over Microsoft.Azure.* types.
    public partial class VirtualMachineTests
    {
        private const string ResourceGroup = "flex-rg";
        private const string VMName = "flex-vm";
        private const string IdentityId = "/subscriptions/test/resourceGroups/flex-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/flex-identity";
        private const string SecretUrl = "https://flex-vault.vault.azure.net/secrets/disk-key/version";

        [Theory]
        [InlineData(false, false)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        [InlineData(true, true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EnableEncryptionPreservesProfilesOnEveryVmRebuild(bool reencrypt, bool flowVm)
        {
            var harness = new VmUpdateHarness(flowVm);
            var command = CreateEncryptionCommand(harness);
            var osType = typeof(SetAzureDiskEncryptionExtensionCommand)
                .GetField("currentOSType", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(osType);
            osType.SetValue(command, OperatingSystemTypes.Windows);

            var result = InvokePrivate(command, "UpdateVmEncryptionSettings",
                new DiskEncryptionSettings { Enabled = reencrypt });

            Assert.IsType<AzureOperationResponse<VirtualMachine, VirtualMachinesCreateOrUpdateHeaders>>(result);
            Assert.Equal(reencrypt ? 2 : 1, harness.Requests.Count);
            Assert.Equal(reencrypt ? new bool?[] { false, true } : new bool?[] { true },
                harness.EncryptionEnabled);
            foreach (var request in harness.Requests)
            {
                Assert.NotSame(harness.VM, request);
                harness.AssertProfiles(request);
            }
            Assert.Equal(SecretUrl, harness.VM.StorageProfile.OsDisk.EncryptionSettings.DiskEncryptionKey.SecretUrl);
            harness.AssertProfiles(harness.VM);
            harness.Operations.Verify(o => o.GetWithHttpMessagesAsync(ResourceGroup, VMName, null, null,
                It.IsAny<CancellationToken>()), Times.Exactly(reencrypt ? 3 : 1));
            harness.Operations.Verify(o => o.DeallocateWithHttpMessagesAsync(ResourceGroup, VMName,
                null, null, null, It.IsAny<CancellationToken>()), reencrypt ? Times.Once() : Times.Never());
            harness.Operations.Verify(o => o.StartWithHttpMessagesAsync(ResourceGroup, VMName,
                null, It.IsAny<CancellationToken>()), reencrypt ? Times.Once() : Times.Never());
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void DisableEncryptionPreservesProfilesOnVmRebuild(bool flowVm)
        {
            var harness = new VmUpdateHarness(flowVm);
            var command = new DisableAzureDiskEncryptionCommand
            {
                ComputeClient = harness.Client,
                ResourceGroupName = ResourceGroup,
                VMName = VMName
            };

            InvokePrivate(command, "UpdateVmEncryptionSettings");

            var request = Assert.Single(harness.Requests);
            Assert.NotSame(harness.VM, request);
            harness.AssertProfiles(request);
            Assert.False(request.StorageProfile.OsDisk.EncryptionSettings.Enabled);
            Assert.Null(request.StorageProfile.OsDisk.EncryptionSettings.DiskEncryptionKey);
            harness.AssertProfiles(harness.VM);
        }

        [Theory]
        [InlineData("UpdateVmEncryptionSettingsForMigration", false)]
        [InlineData("UpdateVmEncryptionSettingsForMigration", true)]
        [InlineData("ClearVmEncryptionSettingsForMigration", false)]
        [InlineData("ClearVmEncryptionSettingsForMigration", true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void MigrationPreservesProfilesOnDirectVmSend(string method, bool flowVm)
        {
            var harness = new VmUpdateHarness(flowVm);

            InvokePrivate(CreateEncryptionCommand(harness), method);

            var request = Assert.Single(harness.Requests);
            Assert.Same(harness.VM, request);
            harness.AssertProfiles(request);
            if (method == "ClearVmEncryptionSettingsForMigration")
            {
                Assert.Null(request.StorageProfile.OsDisk.EncryptionSettings);
            }
            else
            {
                Assert.False(request.StorageProfile.OsDisk.EncryptionSettings.Enabled);
            }
        }

        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void EncryptionIdentityPreservesProfilesOnDirectVmSend(bool flowVm)
        {
            var harness = new VmUpdateHarness(flowVm);
            harness.VM.Identity = new VirtualMachineIdentity
            {
                Type = ResourceIdentityType.UserAssigned,
                UserAssignedIdentities = new Dictionary<string, UserAssignedIdentitiesValue>
                {
                    { IdentityId, new UserAssignedIdentitiesValue() }
                }
            };
            var command = CreateEncryptionCommand(harness);
            command.EncryptionIdentity = IdentityId;
            command.CommandRuntime = new Mock<ICommandRuntime>().Object;

            Assert.True((bool)InvokePrivate(command, "UpdateVmEncryptionIdentity"));

            var request = Assert.Single(harness.Requests);
            Assert.Same(harness.VM, request);
            harness.AssertProfiles(request);
            Assert.Equal(IdentityId, request.SecurityProfile.EncryptionIdentity.UserAssignedIdentityResourceId);
            Assert.Same(harness.VM.Identity, request.Identity);
        }

        [Theory]
        [InlineData(false, false)]
        [InlineData(false, true)]
        [InlineData(true, false)]
        [InlineData(true, true)]
        [Trait(Category.AcceptanceType, Category.CheckIn)]
        public void AemIdentityUpdatePreservesProfilesAndExistingIdentity(bool userAssigned, bool flowVm)
        {
            var harness = new VmUpdateHarness(flowVm) { StopAfterRequest = true };
            harness.VM.Identity = new VirtualMachineIdentity
            {
                Type = userAssigned ? ResourceIdentityType.SystemAssigned : ResourceIdentityType.UserAssigned,
                UserAssignedIdentities = userAssigned ? null : new Dictionary<string, UserAssignedIdentitiesValue>
                {
                    { IdentityId, new UserAssignedIdentitiesValue() }
                }
            };
            var command = new SetAzureRmVMAEMExtension
            {
                ComputeClient = harness.Client,
                ResourceGroupName = ResourceGroup,
                VMName = VMName,
                PathUserIdentity = userAssigned ? IdentityId : null
            };

            // Stop at the VM send: subsequent authorization and extension deployment are unrelated to profile preservation.
            var error = Assert.Throws<TargetInvocationException>(() =>
                InvokePrivate(command, "SetNewExtension", harness.VM, new VirtualMachineInstanceView()));
            Assert.IsType<RequestCapturedException>(error.InnerException);

            var request = Assert.Single(harness.Requests);
            harness.AssertProfiles(request);
            Assert.NotNull(request.Identity);
            Assert.Equal(ResourceIdentityType.SystemAssignedUserAssigned, request.Identity.Type);
            Assert.True(request.Identity.UserAssignedIdentities.ContainsKey(IdentityId));
            harness.AssertProfiles(harness.VM);
        }

        private static SetAzureDiskEncryptionExtensionCommand CreateEncryptionCommand(VmUpdateHarness harness)
        {
            return new SetAzureDiskEncryptionExtensionCommand
            {
                ComputeClient = harness.Client,
                ResourceGroupName = ResourceGroup,
                VMName = VMName,
                Name = AzureDiskEncryptionExtensionContext.ExtensionDefaultName,
                DiskEncryptionKeyVaultId = "/subscriptions/test/resourceGroups/flex-rg/providers/Microsoft.KeyVault/vaults/flex-vault"
            };
        }

        private static object InvokePrivate(object command, string name, params object[] arguments)
        {
            var method = command.GetType().GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(method);
            return method.Invoke(command, arguments);
        }

        private sealed class RequestCapturedException : Exception
        {
        }

        private sealed class VmUpdateHarness
        {
            private readonly bool flowVm;

            public VirtualMachine VM { get; }
            public ComputeClient Client { get; }
            public Mock<IVirtualMachinesOperations> Operations { get; }
            public List<VirtualMachine> Requests { get; } = new List<VirtualMachine>();
            public List<bool?> EncryptionEnabled { get; } = new List<bool?>();
            public bool StopAfterRequest { get; set; }

            public VmUpdateHarness(bool flowVm)
            {
                this.flowVm = flowVm;
                VM = new VirtualMachine(location: "eastus2", name: VMName)
                {
                    HardwareProfile = new HardwareProfile(DeployedSize,
                        new VMSizeProperties(2, 1), "Deterministic"),
                    FlexProfile = flowVm ? new FlexProfile(PreferredSize) : null,
                    StorageProfile = new StorageProfile
                    {
                        OsDisk = new OSDisk
                        {
                            OsType = OperatingSystemTypes.Windows,
                            EncryptionSettings = new DiskEncryptionSettings { Enabled = true }
                        }
                    }
                };
                Operations = new Mock<IVirtualMachinesOperations>(MockBehavior.Strict);
                Operations.Setup(o => o.GetWithHttpMessagesAsync(ResourceGroup, VMName, null, null,
                    It.IsAny<CancellationToken>()))
                    .Returns(() => Task.FromResult(new AzureOperationResponse<VirtualMachine> { Body = VM }));
                Operations.Setup(o => o.CreateOrUpdateWithHttpMessagesAsync(ResourceGroup, VMName,
                    It.IsAny<VirtualMachine>(), null, null, null, It.IsAny<CancellationToken>()))
                    .Returns((string group, string name, VirtualMachine request, string ifMatch,
                        string ifNoneMatch, Dictionary<string, List<string>> headers, CancellationToken token) =>
                    {
                        Requests.Add(request);
                        EncryptionEnabled.Add(request.StorageProfile.OsDisk.EncryptionSettings?.Enabled);
                        AssertProfiles(request);
                        if (StopAfterRequest)
                        {
                            throw new RequestCapturedException();
                        }
                        return Task.FromResult(new AzureOperationResponse<VirtualMachine, VirtualMachinesCreateOrUpdateHeaders>
                        {
                            Body = request,
                            Response = new HttpResponseMessage(HttpStatusCode.OK),
                            Headers = new VirtualMachinesCreateOrUpdateHeaders()
                        });
                    });
                Operations.Setup(o => o.DeallocateWithHttpMessagesAsync(ResourceGroup, VMName, null, null,
                    null, It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult(new AzureOperationResponse()));
                Operations.Setup(o => o.StartWithHttpMessagesAsync(ResourceGroup, VMName, null,
                    It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult(new AzureOperationResponse()));
                var extensions = new Mock<IVirtualMachineExtensionsOperations>(MockBehavior.Strict);
                extensions.Setup(o => o.GetWithHttpMessagesAsync(ResourceGroup, VMName,
                    AzureDiskEncryptionExtensionContext.ExtensionDefaultName, "instanceView", null,
                    It.IsAny<CancellationToken>()))
                    .Returns(Task.FromResult(new AzureOperationResponse<VirtualMachineExtension>
                    {
                        Body = new VirtualMachineExtension
                        {
                            Publisher = AzureDiskEncryptionExtensionContext.ExtensionDefaultPublisher,
                            VirtualMachineExtensionType = AzureDiskEncryptionExtensionContext.ExtensionDefaultType,
                            InstanceView = new VirtualMachineExtensionInstanceView
                            {
                                Statuses = new List<InstanceViewStatus>
                                {
                                    new InstanceViewStatus { Code = "ProvisioningState/succeeded", Message = SecretUrl }
                                }
                            }
                        }
                    }));
                var client = new Mock<IComputeManagementClient>(MockBehavior.Strict);
                client.SetupGet(c => c.VirtualMachines).Returns(Operations.Object);
                client.SetupGet(c => c.VirtualMachineExtensions).Returns(extensions.Object);
                Client = new ComputeClient(client.Object);
            }

            public void AssertProfiles(VirtualMachine request)
            {
                Assert.Equal(flowVm ? PreferredSize : null, request.FlexProfile?.PreferredVMSize);
                if (!flowVm)
                {
                    Assert.Null(request.FlexProfile);
                }
                Assert.NotNull(request.HardwareProfile);
                Assert.Equal(DeployedSize, request.HardwareProfile.VmSize);
                Assert.Equal(2, request.HardwareProfile.VmSizeProperties.VCPUsAvailable);
                Assert.Equal(1, request.HardwareProfile.VmSizeProperties.VCPUsPerCore);
                Assert.Equal("Deterministic", request.HardwareProfile.ProcessorMode);
            }
        }
    }
}
