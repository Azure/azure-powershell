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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.WindowsAzure.Commands.ServiceManagement.IaaS.Extensions;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Model;
using Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests.ConfigDataInfo;
using Microsoft.WindowsAzure.Commands.Sync.Download;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Security.Cryptography;
using Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;

namespace Microsoft.WindowsAzure.Commands.ServiceManagement.Test.FunctionalTests
{
    internal class Utilities 
    {
        #region Constants

        public static string AzurePowershellPath = AppDomain.CurrentDomain.BaseDirectory;

        public const string AzurePowershellProfileModule = "Microsoft.WindowsAzure.Commands.Profile.dll";
        public const string AzurePowershellCommandsModule = "Microsoft.WindowsAzure.Commands.dll";
        public const string AzurePowershellStorageModule = "Microsoft.WindowsAzure.Commands.Storage.dll";
        public const string AzurePowershellServiceManagementModule = "Microsoft.WindowsAzure.Commands.ServiceManagement.dll";
        public const string AzurePowershellModuleServiceManagementPirModule = "Microsoft.WindowsAzure.Commands.ServiceManagement.PlatformImageRepository.dll";
        public const string AzurePowershellModuleServiceManagementPreviewModule = "Microsoft.WindowsAzure.Commands.ServiceManagement.Preview.dll";

        // AzureAffinityGroup
        public const string NewAzureAffinityGroupCmdletName = "New-AzureAffinityGroup";
        public const string GetAzureAffinityGroupCmdletName = "Get-AzureAffinityGroup";
        public const string SetAzureAffinityGroupCmdletName = "Set-AzureAffinityGroup";
        public const string RemoveAzureAffinityGroupCmdletName = "Remove-AzureAffinityGroup";

        // AzureAvailablitySet
        public const string SetAzureAvailabilitySetCmdletName = "Set-AzureAvailabilitySet";
        public const string RemoveAzureAvailabilitySetCmdletName = "Remove-AzureAvailabilitySet";

        // AzureCertificate & AzureCertificateSetting
        public const string AddAzureCertificateCmdletName = "Add-AzureCertificate";
        public const string GetAzureCertificateCmdletName = "Get-AzureCertificate";
        public const string RemoveAzureCertificateCmdletName = "Remove-AzureCertificate";
        public const string NewAzureCertificateSettingCmdletName = "New-AzureCertificateSetting";

        // AzureDataDisk
        public const string AddAzureDataDiskCmdletName = "Add-AzureDataDisk";
        public const string GetAzureDataDiskCmdletName = "Get-AzureDataDisk";
        public const string SetAzureDataDiskCmdletName = "Set-AzureDataDisk";        
        public const string RemoveAzureDataDiskCmdletName = "Remove-AzureDataDisk";

        // AzureDeployment
        public const string NewAzureDeploymentCmdletName = "New-AzureDeployment";
        public const string GetAzureDeploymentCmdletName = "Get-AzureDeployment";
        public const string SetAzureDeploymentCmdletName = "Set-AzureDeployment";
        public const string RemoveAzureDeploymentCmdletName = "Remove-AzureDeployment";
        public const string MoveAzureDeploymentCmdletName = "Move-AzureDeployment";
        public const string GetAzureDeploymentEventCmdletName = "Get-AzureDeploymentEvent";

        // AzureDisk        
        public const string AddAzureDiskCmdletName = "Add-AzureDisk";
        public const string GetAzureDiskCmdletName = "Get-AzureDisk";
        public const string UpdateAzureDiskCmdletName = "Update-AzureDisk";
        public const string RemoveAzureDiskCmdletName = "Remove-AzureDisk";

        // AzureDns
        public const string NewAzureDnsCmdletName = "New-AzureDns";
        public const string GetAzureDnsCmdletName = "Get-AzureDns";
        public const string SetAzureDnsCmdletName = "Set-AzureDns";
        public const string AddAzureDnsCmdletName = "Add-AzureDns";
        public const string RemoveAzureDnsCmdletName = "Remove-AzureDns";

        // AzureEndpoint
        public const string AddAzureEndpointCmdletName = "Add-AzureEndpoint";        
        public const string GetAzureEndpointCmdletName = "Get-AzureEndpoint";
        public const string SetAzureEndpointCmdletName = "Set-AzureEndpoint";
        public const string RemoveAzureEndpointCmdletName = "Remove-AzureEndpoint";

        // AzureLocation
        public const string GetAzureLocationCmdletName = "Get-AzureLocation";
        
        // AzureOSDisk & AzureOSVersion
        public const string GetAzureOSDiskCmdletName = "Get-AzureOSDisk";
        public const string SetAzureOSDiskCmdletName = "Set-AzureOSDisk";

        public const string GetAzureOSVersionCmdletName = "Get-AzureOSVersion";

        // AzureProvisioningConfig
        public const string AddAzureProvisioningConfigCmdletName = "Add-AzureProvisioningConfig";

        // AzurePublishSettingsFile
        public const string ImportAzurePublishSettingsFileCmdletName = "Import-AzurePublishSettingsFile";
        public const string GetAzurePublishSettingsFileCmdletName = "Get-AzurePublishSettingsFile";
        public const string AddAzureEnvironmentCmdletName = "Add-AzureEnvironment";

        // AzureQuickVM
        public const string NewAzureQuickVMCmdletName = "New-AzureQuickVM";

        // Get-AzureWinRMUri
        public const string GetAzureWinRMUriCmdletName = "Get-AzureWinRMUri";

        // AzurePlatformExtension
        public const string PublishAzurePlatformExtensionCmdletName = "Publish-AzurePlatformExtension";
        public const string SetAzurePlatformExtensionCmdletName = "Set-AzurePlatformExtension";
        public const string UnpublishAzurePlatformExtensionCmdletName = "Unpublish-AzurePlatformExtension";
        public const string NewAzurePlatformExtensionCertificateConfigCmdletName = "New-AzurePlatformExtensionCertificateConfig";
        public const string NewAzurePlatformExtensionEndpointConfigSetCmdletName = "New-AzurePlatformExtensionEndpointConfigSet";
        public const string SetAzurePlatformExtensionEndpointCmdletName = "Set-AzurePlatformExtensionEndpoint";
        public const string RemoveAzurePlatformExtensionEndpointCmdletName = "Remove-AzurePlatformExtensionEndpoint";
        public const string NewAzurePlatformExtensionLocalResourceConfigSetCmdletName = "New-AzurePlatformExtensionLocalResourceConfigSet";
        public const string SetAzurePlatformExtensionLocalResourceCmdletName = "Set-AzurePlatformExtensionLocalResource";
        public const string RemoveAzurePlatformExtensionLocalResourceCmdletName = "Remove-AzurePlatformExtensionLocalResource";

        // AzurePlatformVMImage
        public const string SetAzurePlatformVMImageCmdletName = "Set-AzurePlatformVMImage";
        public const string GetAzurePlatformVMImageCmdletName = "Get-AzurePlatformVMImage";
        public const string RemoveAzurePlatformVMImageCmdletName = "Remove-AzurePlatformVMImage";
        public const string NewAzurePlatformComputeImageConfigCmdletName = "New-AzurePlatformComputeImageConfig";
        public const string NewAzurePlatformMarketplaceImageConfigCmdletName = "New-AzurePlatformMarketplaceImageConfig";
        
        // AzureRemoteDesktopFile
        public const string GetAzureRemoteDesktopFileCmdletName = "Get-AzureRemoteDesktopFile";

        // AzureReservedIP
        public const string NewAzureReservedIPCmdletName = "New-AzureReservedIP";
        public const string GetAzureReservedIPCmdletName = "Get-AzureReservedIP";
        public const string RemoveAzureReservedIPCmdletName = "Remove-AzureReservedIP";
        public const string SetAzureReservedIPAssociationCmdletName = "Set-AzureReservedIPAssociation";
        public const string RemoveAzureReservedIPAssociationCmdletName = "Remove-AzureReservedIPAssociation";
        public const string AddAzureVirtualIPCmdletName = "Add-AzureVirtualIP";
        public const string RemoveAzureVirtualIPCmdletName = "Remove-AzureVirtualIP";


        // AzureRole & AzureRoleInstnace
        public const string GetAzureRoleCmdletName = "Get-AzureRole";
        public const string SetAzureRoleCmdletName = "Set-AzureRole";

        public const string GetAzureRoleInstanceCmdletName = "Get-AzureRoleInstance";

        // AzureRoleSize
        public const string GetAzureRoleSizeCmdletName = "Get-AzureRoleSize";

        // AzureService
        public const string NewAzureServiceCmdletName = "New-AzureService";
        public const string GetAzureServiceCmdletName = "Get-AzureService";
        public const string SetAzureServiceCmdletName = "Set-AzureService";
        public const string RemoveAzureServiceCmdletName = "Remove-AzureService";

        // AzureServiceAvailableExtension
        public const string GetAzureServiceAvailableExtensionCmdletName = "Get-AzureServiceAvailableExtension";

        // AzureServiceExtension
        public const string NewAzureServiceExtensionConfigCmdletName = "New-AzureServiceExtensionConfig";
        public const string SetAzureServiceExtensionCmdletName = "Set-AzureServiceExtension";
        public const string GetAzureServiceExtensionCmdletName = "Get-AzureServiceExtension";
        public const string RemoveAzureServiceExtensionCmdletName = "Remove-AzureServiceExtension";

        // AzureServiceRemoteDesktopExtension
        public const string NewAzureServiceRemoteDesktopExtensionConfigCmdletName = "New-AzureServiceRemoteDesktopExtensionConfig";
        public const string SetAzureServiceRemoteDesktopExtensionCmdletName = "Set-AzureServiceRemoteDesktopExtension";
        public const string GetAzureServiceRemoteDesktopExtensionCmdletName = "Get-AzureServiceRemoteDesktopExtension";
        public const string RemoveAzureServiceRemoteDesktopExtensionCmdletName = "Remove-AzureServiceRemoteDesktopExtension";

        // AzureServiceDiagnosticExtension
        public const string NewAzureServiceDiagnosticsExtensionConfigCmdletName = "New-AzureServiceDiagnosticsExtensionConfig";
        public const string SetAzureServiceDiagnosticsExtensionCmdletName = "Set-AzureServiceDiagnosticsExtension";
        public const string GetAzureServiceDiagnosticsExtensionCmdletName = "Get-AzureServiceDiagnosticsExtension";
        public const string RemoveAzureServiceDiagnosticsExtensionCmdletName = "Remove-AzureServiceDiagnosticsExtension";
        
        // AzureSSHKey
        public const string NewAzureSSHKeyCmdletName = "New-AzureSSHKey";

        // AzureStorageAccount
        public const string NewAzureStorageAccountCmdletName = "New-AzureStorageAccount";
        public const string GetAzureStorageAccountCmdletName = "Get-AzureStorageAccount";        
        public const string SetAzureStorageAccountCmdletName = "Set-AzureStorageAccount";        
        public static string RemoveAzureStorageAccountCmdletName = "Remove-AzureStorageAccount";

        //AzureDomainJoinExtension
        public const string NewAzureServiceDomainJoinExtensionConfig = "New-AzureServiceADDomainExtensionConfig";
        public const string SetAzureServiceDomainJoinExtension = "Set-AzureServiceADDomainExtension";
        public const string RemoveAzureServiceDomainJoinExtension = "Remove-AzureServiceADDomainExtension";
        public const string GetAzureServiceDomainJoinExtension = "Get-AzureServiceADDomainExtension";

        // AzureStorageKey
        public static string NewAzureStorageKeyCmdletName = "New-AzureStorageKey";
        public static string GetAzureStorageKeyCmdletName = "Get-AzureStorageKey";

        // AzureSubnet
        public static string GetAzureSubnetCmdletName = "Get-AzureSubnet";
        public static string SetAzureSubnetCmdletName = "Set-AzureSubnet";

        // AzureSubscription
        public const string GetAzureSubscriptionCmdletName = "Get-AzureSubscription";
        public const string SetAzureSubscriptionCmdletName = "Set-AzureSubscription";
        public const string SelectAzureSubscriptionCmdletName = "Select-AzureSubscription";
        public const string RemoveAzureSubscriptionCmdletName = "Remove-AzureSubscription";

        // AzureEnvironment
        public const string GetAzureEnvironmentCmdletName = "Get-AzureEnvironment";
        public const string SetAzureEnvironmentCmdletName = "Set-AzureEnvironment";

        // AzureVhd
        public static string AddAzureVhdCmdletName = "Add-AzureVhd";
        public static string SaveAzureVhdCmdletName = "Save-AzureVhd";

        // AzureVM
        public const string NewAzureVMCmdletName = "New-AzureVM";
        public const string GetAzureVMCmdletName = "Get-AzureVM";
        public const string UpdateAzureVMCmdletName = "Update-AzureVM";                
        public const string RemoveAzureVMCmdletName = "Remove-AzureVM";
        
        public const string ExportAzureVMCmdletName = "Export-AzureVM";
        public const string ImportAzureVMCmdletName = "Import-AzureVM";
        
        public const string StartAzureVMCmdletName = "Start-AzureVM";
        public const string StopAzureVMCmdletName = "Stop-AzureVM";
        public const string RestartAzureVMCmdletName = "Restart-AzureVM";

        // AzureVMConfig
        public const string NewAzureVMConfigCmdletName = "New-AzureVMConfig";

        // AzureVMImage
        
        public const string AddAzureVMImageCmdletName = "Add-AzureVMImage";
        public const string GetAzureVMImageCmdletName = "Get-AzureVMImage";
        public const string RemoveAzureVMImageCmdletName = "Remove-AzureVMImage";
        public const string SaveAzureVMImageCmdletName = "Save-AzureVMImage";
        public const string UpdateAzureVMImageCmdletName = "Update-AzureVMImage";
        
        // AzureVMSize
        public const string SetAzureVMSizeCmdletName = "Set-AzureVMSize";

        // AzureVNetConfig & AzureVNetConnection
        public const string GetAzureVNetConfigCmdletName = "Get-AzureVNetConfig";
        public const string SetAzureVNetConfigCmdletName = "Set-AzureVNetConfig";
        public const string RemoveAzureVNetConfigCmdletName = "Remove-AzureVNetConfig";
        
        public const string GetAzureVNetConnectionCmdletName = "Get-AzureVNetConnection";

        // AzureVnetGateway & AzureVnetGatewayKey
        public const string NewAzureVNetGatewayCmdletName = "New-AzureVNetGateway";
        public const string GetAzureVNetGatewayCmdletName = "Get-AzureVNetGateway";
        public const string SetAzureVNetGatewayCmdletName = "Set-AzureVNetGateway";
        public const string RemoveAzureVNetGatewayCmdletName = "Remove-AzureVNetGateway";

        public const string GetAzureVNetGatewayKeyCmdletName = "Get-AzureVNetGatewayKey";

        // AzureVNetSite
        public const string GetAzureVNetSiteCmdletName = "Get-AzureVNetSite";

        // AzureWalkUpgradeDomain
        public const string SetAzureWalkUpgradeDomainCmdletName = "Set-AzureWalkUpgradeDomain";


        public const string GetModuleCmdletName = "Get-Module";       
        public const string TestAzureNameCmdletName = "Test-AzureName";
        
        public const string CopyAzureStorageBlobCmdletName = "Copy-AzureStorageBlob";


        public static string SetAzureAclConfigCmdletName = "Set-AzureAclConfig";

        public static string NewAzureAclConfigCmdletName = "New-AzureAclConfig";

        public static string GetAzureAclConfigCmdletName = "Get-AzureAclConfig";

        public static string SetAzureLoadBalancedEndpointCmdletName = "Set-AzureLoadBalancedEndpoint";

        public const string ResetAzureRoleInstanceCmdletName = "ReSet-AzureRoleInstance";

        //Static CA cmdlets
        public const string TestAzureStaticVNetIPCmdletName = "Test-AzureStaticVNetIP";
        public const string SetAzureStaticVNetIPCmdletName = "Set-AzureStaticVNetIP";
        public const string GetAzureStaticVNetIPCmdletName = "Get-AzureStaticVNetIP";
        public const string RemoveAzureStaticVNetIPCmdletName = "Remove-AzureStaticVNetIP";

        public const string GetAzureVMBGInfoExtensionCmdletName = "Get-AzureVMBGInfoExtension";
        public const string SetAzureVMBGInfoExtensionCmdletName = "Set-AzureVMBGInfoExtension";
        public const string RemoveAzureVMBGInfoExtensionCmdletName = "Remove-AzureVMBGInfoExtension";

        // Generic Azure VM  Extension cmdlets
        public const string GetAzureVMExtensionCmdletName = "Get-AzureVMExtension";
        public const string SetAzureVMExtensionCmdletName = "Set-AzureVMExtension";
        public const string RemoveAzureVMExtensionCmdletName = "Remove-AzureVMExtension";
        public const string GetAzureVMAvailableExtensionCmdletName = "Get-AzureVMAvailableExtension";
        public const string GetAzureVMExtensionConfigTemplateCmdletName = "Get-AzureVMExtensionConfigTemplate";

        // VM Access Extesnion
        public const string GetAzureVMAccessExtensionCmdletName = "Get-AzureVMAccessExtension";
        public const string SetAzureVMAccessExtensionCmdletName = "Set-AzureVMAccessExtension";
        public const string RemoveAzureVMAccessExtensionCmdletName = "Remove-AzureVMAccessExtension";

        // Custom script extension
        public const string SetAzureVMCustomScriptExtensionCmdletName = "Set-AzureVMCustomScriptExtension";
        public const string GetAzureVMCustomScriptExtensionCmdletName = "Get-AzureVMCustomScriptExtension";
        public const string RemoveAzureVMCustomScriptExtensionCmdletName = "Remove-AzureVMCustomScriptExtension";

        public const string PaaSDiagnosticsExtensionName = "PaaSDiagnostics";

        // VM Image Disk 
        public const string GetAzureVMImageDiskConfigSetCmdletName = "Get-AzureVMImageDiskConfigSet";
        public const string SetAzureVMImageDataDiskConfigCmdletName = "Set-AzureVMImageDataDiskConfig";
        public const string SetAzureVMImageOSDiskConfigCmdletName = "Set-AzureVMImageOSDiskConfig";
        public const string NewAzureVMImageDiskConfigSetCmdletName = "New-AzureVMImageDiskConfigSet";
        
        //ILB
        public const string NewAzureInternalLoadBalancerConfigCmdletName = "New-AzureInternalLoadBalancerConfig";
        public const string AddAzureInternalLoadBalancerCmdletName = "Add-AzureInternalLoadBalancer";
        public const string GetAzureInternalLoadBalancerCmdletName = "Get-AzureInternalLoadBalancer";
        public const string SetAzureInternalLoadBalancerCmdletName = "Set-AzureInternalLoadBalancer";
        public const string RemoveAzureInternalLoadBalancerCmdletName = "Remove-AzureInternalLoadBalancer";
        public const string SetAzurePublicIPCmdletName = "Set-AzurePublicIP";
        public const string GetAzurePublicIPCmdletName = "Get-AzurePublicIP";
        
        // NetworkInterface config
        public const string AddAzureNetworkInterfaceConfig = "Add-AzureNetworkInterfaceConfig";
        public const string SetAzureNetworkInterfaceConfig = "Set-AzureNetworkInterfaceConfig";
        public const string RemoveAzureNetworkInterfaceConfig = "Remove-AzureNetworkInterfaceConfig";
        public const string GetAzureNetworkInterfaceConfig = "Get-AzureNetworkInterfaceConfig";

        // SqlServer extension
        public const string SetAzureVMSqlServerExtensionCmdletName = "Set-AzureVMSqlServerExtension";
        public const string GetAzureVMSqlServerExtensionCmdletName = "Get-AzureVMSqlServerExtension";
        public const string RemoveAzureVMSqlServerExtensionCmdletName = "Remove-AzureVMSqlServerExtension";
        #endregion

        private static ServiceManagementCmdletTestHelper vmPowershellCmdlets = new ServiceManagementCmdletTestHelper();
        

        public static string GetUniqueShortName(string prefix = "", int length = 6, string suffix = "", bool includeDate = false)
        {
            string dateSuffix = "";
            if (includeDate)
            {
                dateSuffix = string.Format("-{0}{1}", DateTime.Now.Year, DateTime.Now.DayOfYear);
            }
            return string.Format("{0}{1}{2}{3}", prefix, Guid.NewGuid().ToString("N").Substring(0, length), suffix, dateSuffix);
        }

        public static int MatchKeywords(string input, string[] keywords, bool exactMatch = true)
        { //returns -1 for no match, 0 for exact match, and a positive number for how many keywords are matched.
            int result = 0;
            if (string.IsNullOrEmpty(input) || keywords.Length == 0)
                return -1;
            foreach (string keyword in keywords)
            {
                //For whole word match, modify pattern to be "\b{0}\b"
                if (!string.IsNullOrEmpty(keyword) && Regex.IsMatch(input, string.Format(@"{0}", Regex.Escape(keyword)), RegexOptions.IgnoreCase))
                {
                    result++;
                }
            }
            if (result == keywords.Length)
            {
                return 0;
            }
            else if (result == 0)
            {
                return -1;
            }
            else
            {
                if (exactMatch)
                {
                    return -1;
                }
                else
                {
                    return result;
                }
            }
        }

        public static bool GetAzureVMAndWaitForReady(string serviceName, string vmName,int waitTime, int maxWaitTime )
        {
            Console.WriteLine("Waiting for the vm {0} to reach \"ReadyRole\" ");
            DateTime startTime = DateTime.Now;
            DateTime MaxEndTime = startTime.AddMilliseconds(maxWaitTime);
            while (true)
            {
                Console.WriteLine("Getting vm '{0}' details:",vmName);
                var vmRoleContext = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
                Console.WriteLine("Current status of the VM is {0} ", vmRoleContext.InstanceStatus);
                if (vmRoleContext.InstanceStatus == "ReadyRole")
                {
                    Console.WriteLine("Instance status reached expected ReadyRole state. Exiting wait.");
                    return true;
                }
                else
                {
                    if (DateTime.Compare(DateTime.Now, MaxEndTime) > 0)
                    {
                        Console.WriteLine("Maximum wait time reached and instance status didnt reach \"ReadyRole\" state. Exiting wait. ");
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("Waiting for {0} seconds for the {1} status to be ReadyRole", waitTime / 1000, vmName);
                        Thread.Sleep(waitTime);
                    }
                }
            }
        }

        public static bool PrintAndCompareDeployment
            (DeploymentInfoContext deployment, string serviceName, string deploymentName, string deploymentLabel, string slot, string status, int instanceCount)
        {
            Console.WriteLine("ServiceName:{0}, DeploymentID: {1}, Uri: {2}", deployment.ServiceName, deployment.DeploymentId, deployment.Url.AbsoluteUri);
            Console.WriteLine("Name - {0}, Label - {1}, Slot - {2}, Status - {3}",
                deployment.DeploymentName, deployment.Label, deployment.Slot, deployment.Status);
            Console.WriteLine("RoleInstance: {0}", deployment.RoleInstanceList.Count);
            foreach (var instance in deployment.RoleInstanceList)
            {
                Console.WriteLine("InstanceName - {0}, InstanceStatus - {1}", instance.InstanceName, instance.InstanceStatus);
            }

            Assert.AreEqual(deployment.ServiceName, serviceName);
            Assert.AreEqual(deployment.DeploymentName, deploymentName);
            Assert.AreEqual(deployment.Label, deploymentLabel);
            Assert.AreEqual(deployment.Slot, slot);
            if (status != null)
            {
                Assert.AreEqual(deployment.Status, status);
            }

            Assert.AreEqual(deployment.RoleInstanceList.Count, instanceCount);

            Assert.IsNotNull(deployment.LastModifiedTime);
            Assert.IsNotNull(deployment.CreatedTime);

            return true;
        }

        // CheckRemove checks if 'fn(name)' exists.    'fn(name)' is usually 'Get-AzureXXXXX name'
        public static bool CheckRemove<Arg, Ret>(Func<Arg, Ret> fn, Arg name)
        {
            try
            {
                fn(name);
                Console.WriteLine("{0} still exists!", name);
                return false;
            }
            catch (Exception e)
            {
                if (e.ToString().Contains("ResourceNotFound"))
                {
                    Console.WriteLine("{0} does not exist.", name);
                    return true;
                }
                else
                {
                    Console.WriteLine("Error: {0}", e.ToString());
                    return false;
                }
            }
        }

        public static PersistentVM CreateVMObjectWithDataDiskSubnetAndAvailibilitySet(string vmName, OS os, string username, string password, string subnet)
        {
            string disk1 = "Disk1";
            int diskSize = 30;
            string availabilitySetName = Utilities.GetUniqueShortName("AvailSet");
            string img = string.Empty;

            bool isWindowsOs = false;
            if (os == OS.Windows)
            {
                img = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Windows" }, false);
                isWindowsOs = true;
            }
            else
            {
                img = vmPowershellCmdlets.GetAzureVMImageName(new[] { "Linux" }, false);
                isWindowsOs = false;
            }

            PersistentVM vm = Utilities.CreateIaaSVMObject(vmName, InstanceSize.Small, img, isWindowsOs, username, password);
            AddAzureDataDiskConfig azureDataDiskConfigInfo1 = new AddAzureDataDiskConfig(DiskCreateOption.CreateNew, diskSize, disk1, 0, HostCaching.ReadWrite.ToString());
            azureDataDiskConfigInfo1.Vm = vm;

            vm = vmPowershellCmdlets.SetAzureSubnet(vm, new string[] { subnet });
            vm = vmPowershellCmdlets.SetAzureAvailabilitySet(availabilitySetName, vm);
            return vm;
        }

        // CheckRemove checks if 'fn(name)' exists.    'fn(name)' is usually 'Get-AzureXXXXX name'
        public static bool CheckRemove<Arg1, Arg2, Ret>(Func<Arg1, Arg2, Ret> fn, Arg1 name1, Arg2 name2)
        {
            try
            {
                fn(name1, name2);
                Console.WriteLine("{0}, {1} still exist!", name1, name2);
                return false;
            }
            catch (Exception e)
            {
                if (e.ToString().Contains("ResourceNotFound"))
                {
                    Console.WriteLine("{0}, {1} is successfully removed", name1, name2);
                    return true;
                }
                else
                {
                    Console.WriteLine("Error: {0}", e.ToString());
                    return false;
                }
            }
        }

        // CheckRemove checks if 'fn(name)' exists.    'fn(name)' is usually 'Get-AzureXXXXX name'
        public static bool CheckRemove<Arg1, Arg2, Arg3, Ret>(Func<Arg1, Arg2, Arg3, Ret> fn, Arg1 name1, Arg2 name2, Arg3 name3)
        {
            try
            {
                fn(name1, name2, name3);
                Console.WriteLine("{0}, {1}, {2} still exist!", name1, name2, name3);
                return false;
            }
            catch (Exception e)
            {
                if (e.ToString().Contains("ResourceNotFound"))
                {
                    Console.WriteLine("{0}, {1}, {2} is successfully removed", name1, name2, name3);
                    return true;
                }
                else
                {
                    Console.WriteLine("Error: {0}", e.ToString());
                    return false;
                }
            }
        }

        public static BlobHandle GetBlobHandle(string blob, string key)
        {
            BlobUri blobPath;
            Assert.IsTrue(BlobUri.TryParseUri(new Uri(blob), out blobPath));
            return new BlobHandle(blobPath, key);
        }

        /// <summary>
        ///  Retry the given action until success or timed out.
        /// </summary>
        /// <param name="act">the action</param>
        /// <param name="errorMessage">retry for this error message</param>
        /// <param name="maxTry">the max number of retries</param>
        /// <param name="intervalSeconds">the interval between retries</param>
        public static void RetryActionUntilSuccess(Action act, string errorMessage, int maxTry, int intervalSeconds)
        {
            int i = 0;
            while (i < maxTry)
            {
                try
                {
                    act();
                    return;
                }
                catch (Exception e)
                {
                    if (e.ToString().Contains(errorMessage) || (e.InnerException != null && e.InnerException.ToString().Contains(errorMessage)))
                    {
                        i++;
                        if (i == maxTry)
                        {
                            Console.WriteLine("Max number of retry is reached: {0}", errorMessage);
                            throw;
                        }
                        Console.WriteLine("{0} error occurs! retrying ...", errorMessage);
                        if (e.InnerException != null)
                        {
                            Console.WriteLine(e.InnerException);
                        }
                        Thread.Sleep(TimeSpan.FromSeconds(intervalSeconds));
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(e);
                        if (e.InnerException != null)
                        {
                            Console.WriteLine(e.InnerException);
                        }
                        throw;
                    }
                }
            }
        }

        /// <summary>
        ///  Retry the given action until success or timed out.
        /// </summary>
        /// <param name="act">the action</param>
        /// <param name="errorMessages">retry for this error messages</param>
        /// <param name="maxTry">the max number of retries</param>
        /// <param name="intervalSeconds">the interval between retries</param>
        public static void RetryActionUntilSuccess(Action act, string[] errorMessages, int maxTry, int intervalSeconds)
        {
            int i = 0;
            while (i < maxTry)
            {
                try
                {
                    act();
                    return;
                }
                catch (Exception e)
                {
                    bool found = false;
                    foreach (var errorMessage in errorMessages)
                    {
                        if (e.ToString().Contains(errorMessage) || (e.InnerException != null && e.InnerException.ToString().Contains(errorMessage)))
                        {
                            found = true;
                            i++;
                            if (i == maxTry)
                            {
                                Console.WriteLine("Max number of retry is reached: {0}", errorMessage);
                                throw;
                            }
                            Console.WriteLine("{0} error occurs! retrying ...", errorMessage);
                            if (e.InnerException != null)
                            {
                                Console.WriteLine(e.InnerException);
                            }
                            Thread.Sleep(TimeSpan.FromSeconds(intervalSeconds));
                            break;
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine(e);
                        if (e.InnerException != null)
                        {
                            Console.WriteLine(e.InnerException);
                        }
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// This method verifies if a given error occurs during the action.  Otherwise, it throws.
        /// </summary>
        /// <param name="act">Action item</param>
        /// <param name="errorMessage">Required error message</param>
        public static void VerifyFailure(Action act, string errorMessage)
        {            
            try
            {
                act();
                Assert.Fail("Should have failed, but it succeeded!!");
            }
            catch (Exception e)
            {
                if (e is AssertFailedException)
                {
                    throw;
                }
                if (e.ToString().Contains(errorMessage))
                {
                    Console.WriteLine("This failure is expected: {0}", e.InnerException);                    
                }
                else
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="act"></param>
        /// <param name="errorMessage"></param>
        public static void TryAndIgnore(Action act, string errorMessage)
        {
            try
            {
                act();                
            }
            catch (Exception e)
            {                
                if (e.ToString().Contains(errorMessage))
                {
                    Console.WriteLine("Ignoring exception: {0}", e.InnerException);
                }
                else
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }        

        public static X509Certificate2 InstallCert(string certFile, StoreLocation location = StoreLocation.CurrentUser, StoreName name = StoreName.My)
        {
            var cert = new X509Certificate2(certFile);
            var certStore = new X509Store(name, location);
            certStore.Open(OpenFlags.ReadWrite);
            certStore.Add(cert);
            certStore.Close();
            Console.WriteLine("Cert, {0}, is installed.", cert.Thumbprint);
            return cert;
        }

        public static void UninstallCert(X509Certificate2 cert, StoreLocation location, StoreName name)
        {
            try
            {
                X509Store certStore = new X509Store(name, location);
                certStore.Open(OpenFlags.ReadWrite);
                certStore.Remove(cert);
                certStore.Close();
                Console.WriteLine("Cert, {0}, is uninstalled.", cert.Thumbprint);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error during uninstalling the cert: {0}", e.ToString());
                throw;
            }
        }
        public static X509Certificate2 CreateCertificate(string password, string issuer = "CN=Microsoft Azure Powershell Test", string friendlyName = "PSTest")
        {

            var keyCreationParameters = new CngKeyCreationParameters
            {
                ExportPolicy = CngExportPolicies.AllowExport,
                KeyCreationOptions = CngKeyCreationOptions.None,
                KeyUsage = CngKeyUsages.AllUsages,
                Provider = CngProvider.MicrosoftSoftwareKeyStorageProvider
            };

            keyCreationParameters.Parameters.Add(new CngProperty("Length", BitConverter.GetBytes(2048), CngPropertyOptions.None));

            CngKey key = CngKey.Create(CngAlgorithm2.Rsa, null, keyCreationParameters);

            var creationParams = new X509CertificateCreationParameters(new X500DistinguishedName(issuer))
            {
                TakeOwnershipOfKey = true
            };

            X509Certificate2 cert = key.CreateSelfSignedCertificate(creationParams);
            key = null;
            cert.FriendlyName = friendlyName;

            byte[] bytes = cert.Export(X509ContentType.Pfx, password);
            X509Certificate2 returnCert = new X509Certificate2();
            returnCert.Import(bytes, password, X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);
            return returnCert;
        }        

        public static SecureString convertToSecureString(string str)
        {
            SecureString secureStr = new SecureString();
            foreach (char c in str)
            {
                secureStr.AppendChar(c);
            }
            return secureStr;
        }

        public static string FindSubstring(string givenStr, char givenChar, int i)
        {
            if (i > 0)
            {
                return FindSubstring(givenStr.Substring(givenStr.IndexOf(givenChar) + 1), givenChar, i - 1);
            }
            else
            {
                return givenStr;
            }
        }

        public static bool CompareDateTime(DateTime expectedDate, string givenDate)
        {
            DateTime resultExpDate = DateTime.Parse(givenDate);
            bool result = (resultExpDate.Day == expectedDate.Day);
            result &= (resultExpDate.Month == expectedDate.Month);
            result &= (resultExpDate.Year == expectedDate.Year);
            return result;
        }

        public static string GetInnerXml(string xmlString, string tag)
        {
            string removedHeader = "<" + Utilities.FindSubstring(xmlString, '<', 2);

            byte[] encodedString = Encoding.UTF8.GetBytes(xmlString);
            MemoryStream stream = new MemoryStream(encodedString);
            stream.Flush();
            stream.Position = 0;

            XmlDocument xml = new XmlDocument();
            xml.Load(stream);
            return xml.GetElementsByTagName(tag)[0].InnerXml;
        }

        public static void CompareWadCfg(string wadcfg, XmlDocument daconfig)
        {
            if (string.IsNullOrWhiteSpace(wadcfg))
            {
                Assert.IsNull(wadcfg);
            }
            else
            {
                string innerXml = daconfig.InnerXml;
                StringAssert.Contains(Utilities.FindSubstring(innerXml, '<', 2), Utilities.FindSubstring(wadcfg, '<', 2));
            }
        }

        static public string GenerateSasUri(string blobStorageEndpointFormat, string storageAccount, string storageAccountKey,
            string blobContainer, string vhdName, int hours = 10, bool read = true, bool write = true, bool delete = true, bool list = true)
        {
            string destinationSasUri = string.Format(@blobStorageEndpointFormat, storageAccount) + string.Format("/{0}/{1}", blobContainer, vhdName);
            var destinationBlob = new CloudPageBlob(new Uri(destinationSasUri), new StorageCredentials(storageAccount, storageAccountKey));
            SharedAccessBlobPermissions permission = 0;
            permission |= (read) ? SharedAccessBlobPermissions.Read : 0;
            permission |= (write) ? SharedAccessBlobPermissions.Write : 0;
            permission |= (delete) ? SharedAccessBlobPermissions.Delete : 0;
            permission |= (list) ? SharedAccessBlobPermissions.List : 0;

            var policy = new SharedAccessBlobPolicy()
            {
                Permissions = permission,
                SharedAccessExpiryTime = DateTime.UtcNow + TimeSpan.FromHours(hours)
            };

            string destinationBlobToken = destinationBlob.GetSharedAccessSignature(policy);
            return (destinationSasUri + destinationBlobToken);
        }

        static public void RecordTimeTaken(ref DateTime prev)
        {
            var period = DateTime.Now - prev;
            Console.WriteLine("{0} minutes {1} seconds and {2} ms passed...", period.Minutes.ToString(), period.Seconds.ToString(), period.Milliseconds.ToString());
            prev = DateTime.Now;
        }

        public static void PrintContext<T>(T obj)
        {
            PrintTypeContents(typeof(T), obj);
        }

        public static void PrintContextAndItsBase<T>(T obj)
        {
            Type type = typeof(T);
            PrintTypeContents(type, obj);
            PrintTypeContents(type.BaseType, obj);
        }

        private static void PrintTypeContents<T>(Type type, T obj)
        {
            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly))
            {
                string typeName = property.PropertyType.FullName;
                if (typeName.Equals("System.String") || typeName.Equals("System.Int32") || typeName.Equals("System.Uri") ||
                    typeName.Contains("Nullable"))
                {
                    Console.WriteLine("{0}: {1}", property.Name, property.GetValue(obj, null));
                }
                else if (typeName.Contains("Boolean"))
                {
                    Console.WriteLine("{0}: {1}", property.Name, property.GetValue(obj, null).ToString());
                }
                else
                {
                    Console.WriteLine("This type is not printed: {0}", typeName);
                }
            }
        }

        public static void PrintCompleteContext<T>(T obj)
        {
            Type type = typeof(T);

            foreach (PropertyInfo property in type.GetProperties())
            {
                string typeName = property.PropertyType.FullName;
                if (typeName.Equals("System.String") || typeName.Equals("System.Int32") || typeName.Equals("System.Uri") ||
                    typeName.Contains("Nullable"))
                {
                    Console.WriteLine("{0}: {1}", property.Name, property.GetValue(obj, null));
                }
                else if (typeName.Contains("Boolean"))
                {
                    Console.WriteLine("{0}: {1}", property.Name, property.GetValue(obj, null).ToString());
                }
                else
                {
                    Console.WriteLine("This type is not printed: {0}", typeName);
                }
            }
        }

        public static bool validateHttpUri(string uri)
        {
            Uri uriResult;
            return Uri.TryCreate(uri, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
        }

        public static PersistentVM CreateIaaSVMObject(string vmName,InstanceSize size,string imageName,bool isWindows = true,string username = null,string password = null,bool disableGuestAgent = false)
        {
            //Create an IaaS VM
            var azureVMConfigInfo = new AzureVMConfigInfo(vmName, size.ToString(), imageName);
            AzureProvisioningConfigInfo azureProvisioningConfig = null;
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(username))
            {
                azureProvisioningConfig = new AzureProvisioningConfigInfo(isWindows ? OS.Windows:OS.Linux, username, password,disableGuestAgent);
            }
            var persistentVMConfigInfo = new PersistentVMConfigInfo(azureVMConfigInfo, azureProvisioningConfig, null, null);
            return vmPowershellCmdlets.GetPersistentVM(persistentVMConfigInfo);
        }

        public static void PrintHeader(string title)
        {
            if (title.Length > 100)
            {
                Console.WriteLine(string.Format("{0}{1}{0}", "> > >", title));
            }
            else
            {
                int headerLineLength = 100;
                Console.WriteLine();
                Console.WriteLine(string.Format("{0}{1}{0}", new String('>', (headerLineLength - title.Length) / 2), title));
            }
        }

        public static void PrintFooter(string title)
        {
            if (title.Length > 100)
            {
                Console.WriteLine(string.Format("{0}{1}{0}", "< < <", title));
            }
            else
            {
                int headerLineLength = 100;
                string completed = ": Completed";
                Console.WriteLine(string.Format("{0}{1}{0}", new String('<', (headerLineLength - (title.Length + completed.Length)) / 2), title + completed));
            }
        }

        public static void PrintSeperationLineStart(string title,char seperator)
        {
            int headerLineLength = 100;
            string completed = ": Completed";
            Console.WriteLine(string.Format("{0}{1}{0}", new String(seperator, (headerLineLength - (title.Length + completed.Length)) / 2), title + completed));
        }
        public static void PrintSeperationLineEnd(string title,string successMessage, char seperator)
        {
            int headerLineLength = 100;
            Console.WriteLine(string.Format("{0}{1}{0}", new String(seperator, (headerLineLength - (title.Length + successMessage.Length)) / 2), title + successMessage));
        }

        public static string ConvertToJsonArray(string[] values)
        {
            List<string> files = new List<string>();
            foreach (string s in values)
            {
               files.Add(string.Format("'{0}'", s));
            }
            return string.Join(",", files);
        }

        public static string GetSASUri(string blobUrlRoot,string storageAccoutnName,string primaryKey, string container, string filename, TimeSpan persmissionDuration,SharedAccessBlobPermissions permissionType)
        {
            // Set the destination
            string httpsBlobUrlRoot = string.Format("https:{0}", blobUrlRoot.Substring(blobUrlRoot.IndexOf('/')));
            string vhdDestUri = httpsBlobUrlRoot + string.Format("{0}/{1}", container, filename);

            var destinationBlob = new CloudPageBlob(new Uri(vhdDestUri), new StorageCredentials(storageAccoutnName, primaryKey));
            var policy2 = new SharedAccessBlobPolicy()
            {
                Permissions = permissionType,
                SharedAccessExpiryTime = DateTime.UtcNow.Add(persmissionDuration)
            };
            var destinationBlobToken2 = destinationBlob.GetSharedAccessSignature(policy2);
            vhdDestUri += destinationBlobToken2;
            return vhdDestUri;
        }

        public static PersistentVM GetAzureVM(string vmName, string serviceName)
        {
            var vmroleContext = vmPowershellCmdlets.GetAzureVM(vmName, serviceName);
            return vmroleContext.VM;
        }

        public static void LogAssert(Action method,string actionTitle)
        {
            Console.Write(actionTitle);
            method();
            Console.WriteLine(": verified");
        }

        public static void ExecuteAndLog(Action method,string actionTitle)
        {
            PrintHeader(actionTitle);
            method();
            PrintFooter(actionTitle);
        }

        public static VirtualMachineExtensionImageContext GetAzureVMExtenionInfo(string extensionName)
        {
            List<VirtualMachineExtensionImageContext> extensionInfo = new List<VirtualMachineExtensionImageContext>();
            extensionInfo.AddRange(vmPowershellCmdlets.GetAzureVMAvailableExtension());
            return extensionInfo.Find(c => c.ExtensionName.Equals(extensionName));
        }

    }
}
