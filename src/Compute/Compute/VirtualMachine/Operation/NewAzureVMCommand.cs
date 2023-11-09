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

using AutoMapper;
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.Azure.Commands.Compute.Models;
using Microsoft.Azure.Commands.Compute.Properties;
using Microsoft.Azure.Commands.Compute.StorageServices;
using Microsoft.Azure.Commands.Compute.Strategies;
using Microsoft.Azure.Commands.Compute.Strategies.ComputeRp;
using Microsoft.Azure.Commands.Compute.Strategies.Network;
using Microsoft.Azure.Commands.Compute.Strategies.ResourceManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.Internal.Resources.Models;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Network;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Storage;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Storage.Models;
using Microsoft.WindowsAzure.Commands.Sync.Download;
using Microsoft.WindowsAzure.Commands.Tools.Vhd;
using Microsoft.WindowsAzure.Commands.Tools.Vhd.Model;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using System.Diagnostics;
using CM = Microsoft.Azure.Management.Compute.Models;
using SM = Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Storage.Models;
using Microsoft.Azure.Commands.Compute;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Network.Models;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using System.Security.AccessControl;
using System.Security.Principal;
using Microsoft.Azure.Commands.Common.Strategies.Compute;

namespace Microsoft.Azure.Commands.Compute
{
    [GenericBreakingChangeWithVersion("Starting in November 2023 the \"New-AzVM\" cmdlet will deploy with the Trusted Launch configuration by default. To know more about Trusted Launch, please visit https://aka.ms/TLaD", "11.0.0", "7.0.0")]
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VM", SupportsShouldProcess = true, DefaultParameterSetName = "SimpleParameterSet")]
    [OutputType(typeof(PSAzureOperationResponse), typeof(PSVirtualMachine))]
    public class NewAzureVMCommand : VirtualMachineBaseCmdlet
    {
        public const string DefaultParameterSet = "DefaultParameterSet";
        public const string SimpleParameterSet = "SimpleParameterSet";
        public const string DiskFileParameterSet = "DiskFileParameterSet";
        public bool ConfigAsyncVisited = false;
        
        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            Position = 0,
            ValueFromPipelineByPropertyName = true)]
        [ResourceGroupCompleter]
        [Parameter(
            ParameterSetName = SimpleParameterSet,
            Mandatory = false)]
        [Parameter(
            ParameterSetName = DiskFileParameterSet,
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            Position = 1,
            ValueFromPipelineByPropertyName = true)]
        [Parameter(
            ParameterSetName = SimpleParameterSet,
            Mandatory = false)]
        [Parameter(
            ParameterSetName = DiskFileParameterSet,
            Mandatory = false)]
        [LocationCompleter("Microsoft.Compute/virtualMachines")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public string EdgeZone { get; set; }

        [Alias("VMProfile")]
        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = true,
            Position = 2,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        [ValidateNotNullOrEmpty]
        public PSVirtualMachine VM { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = false,
            Position = 3,
            ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string[] Zone { get; set; }

        [Parameter(
            ParameterSetName = SimpleParameterSet, 
            Mandatory = false,
            HelpMessage = "Specify public IP sku name")]
        [Parameter(
            ParameterSetName = DiskFileParameterSet,
            Mandatory = false,
            HelpMessage = "Specify public IP sku name")]
        [PSArgumentCompleter("Basic","Standard")]
        public string PublicIpSku { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            HelpMessage = "Disable BG Info Extension")]
        public SwitchParameter DisableBginfoExtension { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true)]
        public Hashtable Tag { get; set; }

        [Parameter(
            ParameterSetName = DefaultParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = false)]
        [ValidateNotNullOrEmpty]
        public string LicenseType { get; set; }

        [Parameter(
            ParameterSetName = SimpleParameterSet,
            Mandatory = true)]
        [Parameter(
            ParameterSetName = DiskFileParameterSet,
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = true)]
        public PSCredential Credential { get; set; }

        [Parameter(
            ParameterSetName = SimpleParameterSet,
            HelpMessage = "Specifies Network Interface delete option after VM deletion. Options are Detach or Delete.",
            Mandatory = false)]
        [Parameter(
            ParameterSetName = DiskFileParameterSet,
            HelpMessage = "Specifies Network Interface delete option after VM deletion. Options are Detach or Delete.",
            Mandatory = false)]
        public string NetworkInterfaceDeleteOption { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string VirtualNetworkName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string AddressPrefix { get; set; } = "192.168.0.0/16";

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string SubnetName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string SubnetAddressPrefix { get; set; } = "192.168.1.0/24";

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string PublicIpAddressName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string DomainNameLabel { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        [ValidateSet("Static", "Dynamic")]
        public string AllocationMethod { get; set; } = "Static";

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string SecurityGroupName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public int[] OpenPorts { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [PSArgumentCompleter(
            "CentOS",
            "CentOS85Gen2",
            "Debian",
            "Debian11",
            "OpenSuseLeap154Gen2",
            "RHEL",
            "RHELRaw8LVMGen2",
            "SuseSles15SP3",
            "UbuntuLTS",
            "Ubuntu2204",
            "FlatcarLinuxFreeGen2",
            "Win2022Datacenter",
            "Win2022AzureEditionCore",
            "Win2019Datacenter",
            "Win2016Datacenter",
            "Win2012R2Datacenter",
            "Win2012Datacenter",
            "Win10",
            "Win2016DataCenterGenSecond")]
        [Alias("ImageName")]
        public string Image { get; set; } = "Win2016Datacenter";

        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string DiskFile { get; set; }

        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public SwitchParameter Linux { get; set; } = false;

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string Size { get; set; } = "Standard_D2s_v3";

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string AvailabilitySetName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false, HelpMessage = "Use this to add system assigned identity (MSI) to the vm")]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false, HelpMessage = "Use this to add system assigned identity (MSI) to the vm")]
        public SwitchParameter SystemAssignedIdentity { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false, HelpMessage = "Use this to add the assign user specified identity (MSI) to the VM")]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false, HelpMessage = "Use this to add the assign user specified identity (MSI) to the VM")]
        [ValidateNotNullOrEmpty]
        public string UserAssignedIdentity { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false)]
        public string OSDiskDeleteOption { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public int[] DataDiskSizeInGb { get; set; }

        [Parameter(Mandatory = false)]
        public string DataDiskDeleteOption { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public SwitchParameter EnableUltraSSD { get; set; }

        [Alias("ProximityPlacementGroup")]
        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string ProximityPlacementGroupId { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string HostId { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false)]
        public string VmssId { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false,
            HelpMessage = "The priority for the virtual machine. Only supported values are 'Regular', 'Spot' and 'Low'. 'Regular' is for regular virtual machine. 'Spot' is for spot virtual machine. 'Low' is also for spot virtual machine but is replaced by 'Spot'. Please use 'Spot' instead of 'Low'.")]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false,
            HelpMessage = "The priority for the virtual machine. Only supported values are 'Regular', 'Spot' and 'Low'. 'Regular' is for regular virtual machine. 'Spot' is for spot virtual machine. 'Low' is also for spot virtual machine but is replaced by 'Spot'. Please use 'Spot' instead of 'Low'.")]
        [PSArgumentCompleter("Regular", "Spot")]
        public string Priority { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false,
            HelpMessage = "The eviction policy for the Azure Spot virtual machine.  Supported values are 'Deallocate' and 'Delete'.")]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false,
            HelpMessage = "The eviction policy for the Azure Spot virtual machine.  Supported values are 'Deallocate' and 'Delete'.")]
        [PSArgumentCompleter("Deallocate", "Delete")]
        public string EvictionPolicy { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false,
            HelpMessage = "The max price of the billing of a low priority virtual machine.")]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false,
            HelpMessage = "The max price of the billing of a low priority virtual machine.")]
        public double MaxPrice { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false,
            HelpMessage = "EncryptionAtHost property can be used by user in the request to enable or disable the Host Encryption for the virtual machine. This will enable the encryption for all the disks including Resource/Temp disk at host itself.")]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false,
            HelpMessage = "EncryptionAtHost property can be used by user in the request to enable or disable the Host Encryption for the virtual machine. This will enable the encryption for all the disks including Resource/Temp disk at host itself.")]
        public SwitchParameter EncryptionAtHost { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false,
            HelpMessage = "The resource id of the dedicated host group, on which the customer wants their VM placed using automatic placement.",
            ValueFromPipelineByPropertyName = true)]
        [Parameter(ParameterSetName = DiskFileParameterSet, Mandatory = false,
            HelpMessage = "The resource id of the dedicated host group, on which the customer wants their VM placed using automatic placement.",
            ValueFromPipelineByPropertyName = true)]
        public string HostGroupId { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Name of the SSH Public Key resource.",
            ParameterSetName = DefaultParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Name of the SSH Public Key resource.",
            ParameterSetName = SimpleParameterSet)]
        public string SshKeyName { get; set; }

        [Parameter(
            Mandatory = false,
            HelpMessage = "Generate a SSH Public/Private key pair and create a SSH Public Key resource on Azure.",
            ParameterSetName = DefaultParameterSet)]
        [Parameter(
            Mandatory = false,
            HelpMessage = "Generate a SSH Public/Private key pair and create a SSH Public Key resource on Azure.",
            ParameterSetName = SimpleParameterSet)]
        public SwitchParameter GenerateSshKey { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = SimpleParameterSet,
            HelpMessage = "Id of the capacity reservation Group that is used to allocate.")]
        [Parameter(
            Mandatory = false,
            ParameterSetName = DiskFileParameterSet,
            HelpMessage = "Id of the capacity reservation Group that is used to allocate.")]
        [ResourceIdCompleter("Microsoft.Compute/capacityReservationGroups")]
        public string CapacityReservationGroupId { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = SimpleParameterSet,
            HelpMessage = "UserData for the VM, which will be Base64 encoded. Customer should not pass any secrets in here.",
            ValueFromPipelineByPropertyName = true)]
        [Parameter(
            Mandatory = false,
            ParameterSetName = DiskFileParameterSet,
            HelpMessage = "UserData for the VM, which will be Base64 encoded. Customer should not pass any secrets in here.",
            ValueFromPipelineByPropertyName = true)]
        public string UserData { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = SimpleParameterSet,
            HelpMessage = "Specified the gallery image unique id for vm deployment. This can be fetched from gallery image GET call.")]
        [ResourceIdCompleter("Microsoft.Compute galleries/images/versions")]
        public string ImageReferenceId { get; set; }

        [Parameter(
            ParameterSetName = SimpleParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the fault domain of the virtual machine.")]
        [Parameter(
            ParameterSetName = DiskFileParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the fault domain of the virtual machine.")]
        public int PlatformFaultDomain { get; set; }

        [Parameter(
            ParameterSetName = SimpleParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The flag that enables or disables hibernation capability on the VM.")]
        [Parameter(
            ParameterSetName = DiskFileParameterSet,
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "The flag that enables or disables hibernation capability on the VM.")]
        public SwitchParameter HibernationEnabled { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the number of vCPUs available for the VM. When this property is not specified in the request body the default behavior is to set it to the value of vCPUs available for that VM size exposed in api response of [List all available virtual machine sizes in a region](https://learn.microsoft.com/en-us/rest/api/compute/resource-skus/list).")]
        public int vCPUCountAvailable { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the vCPU to physical core ratio. When this property is not specified in the request body the default behavior is set to the value of vCPUsPerCore for the VM Size exposed in api response of [List all available virtual machine sizes in a region](https://learn.microsoft.com/en-us/rest/api/compute/resource-skus/list). Setting this property to 1 also means that hyper-threading is disabled.")]
        public int vCPUCountPerCore { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = SimpleParameterSet,
            HelpMessage = "Specifies the disk controller type configured for the VM and VirtualMachineScaleSet. This property is only supported for virtual machines whose operating system disk and VM sku supports Generation 2 (https://learn.microsoft.com/en-us/azure/virtual-machines/generation-2), please check the HyperVGenerations capability returned as part of VM sku capabilities in the response of Microsoft.Compute SKUs api for the region contains V2 (https://learn.microsoft.com/rest/api/compute/resourceskus/list) . <br> For more information about Disk Controller Types supported please refer to https://aka.ms/azure-diskcontrollertypes.")]
        [PSArgumentCompleter("SCSI", "NVMe")]
        public string DiskControllerType { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = SimpleParameterSet,
            HelpMessage = "Specified the shared gallery image unique id for vm deployment. This can be fetched from shared gallery image GET call.")]
        public string SharedGalleryImageId { get; set; }
        
        [Parameter(
           ParameterSetName = SimpleParameterSet,
           HelpMessage = "Specifies the SecurityType of the virtual machine. It has to be set to any specified value to enable UefiSettings. By default, UefiSettings will not be enabled unless this property is set.",
           ValueFromPipelineByPropertyName = true,
           Mandatory = false)]
        [ValidateSet(ValidateSetValues.TrustedLaunch, ValidateSetValues.ConfidentialVM, ValidateSetValues.Standard, IgnoreCase = true)]
        [PSArgumentCompleter("TrustedLaunch", "ConfidentialVM", "Standard")]
        public string SecurityType { get; set; }

        [Parameter(
           ParameterSetName = SimpleParameterSet,
           HelpMessage = "Specifies whether vTPM should be enabled on the virtual machine.",
           ValueFromPipelineByPropertyName = true,
           Mandatory = false)]
        public bool? EnableVtpm { get; set; } = null;

        [Parameter(
           ParameterSetName = SimpleParameterSet,
           HelpMessage = "Specifies whether secure boot should be enabled on the virtual machine.",
           ValueFromPipelineByPropertyName = true,
           Mandatory = false)]
        public bool? EnableSecureBoot { get; set; } = null;

        public override void ExecuteCmdlet()
        {
            if (this.IsParameterBound(c => c.UserData))
            {
                if (!ValidateBase64EncodedString.ValidateStringIsBase64Encoded(this.UserData))
                {
                    this.UserData = ValidateBase64EncodedString.EncodeStringToBase64(this.UserData);
                    this.WriteInformation(ValidateBase64EncodedString.UserDataEncodeNotification, new string[] { "PSHOST" });
                }
            }

            switch (ParameterSetName)
            {
                case SimpleParameterSet:
                    this.StartAndWait(StrategyExecuteCmdletAsync);
                    break;
                case DiskFileParameterSet:
                    this.StartAndWait(StrategyExecuteCmdletAsync);
                    break;
                default:
                    DefaultExecuteCmdlet();
                    break;
            }
        }

        class Parameters : IParameters<VirtualMachine>
        {
            readonly NewAzureVMCommand _cmdlet;

            readonly Client _client;

            readonly IResourceManagementClient _resourceClient;

            public Parameters(NewAzureVMCommand cmdlet, Client client, IResourceManagementClient resourceClient)
            {
                _cmdlet = cmdlet;
                _client = client;
                _resourceClient = resourceClient;
                _cmdlet.validate();
            }

            public ImageAndOsType ImageAndOsType { get; set; }

            public string Location
            {
                get { return _cmdlet.Location; }
                set { _cmdlet.Location = value; }
            }

            string _defaultLocation = null;

            public string DefaultLocation
            {
                get
                {
                    if (_defaultLocation == null)
                    {
                        var vmResourceType = _resourceClient.Providers.GetAsync("Microsoft.Compute").ConfigureAwait(false).GetAwaiter().GetResult()
                        .ResourceTypes.Where(a => String.Equals(a.ResourceType, "virtualMachines", StringComparison.OrdinalIgnoreCase))
                                      .FirstOrDefault();
                        if (vmResourceType != null)
                        {
                            var availableLocations = vmResourceType.Locations.Select(a => a.ToLower().Replace(" ", ""));
                            if (availableLocations.Any(a => a.Equals("eastus")))
                            {
                                _defaultLocation = "eastus";
                            }
                            _defaultLocation = availableLocations.FirstOrDefault() ?? "eastus";
                        }
                        else
                        {
                            _defaultLocation = "eastus";
                        }
                    }
                    return _defaultLocation;
                }
            }

            public BlobUri DestinationUri;

            public string StorageAccountId;

            public async Task<ResourceConfig<VirtualMachine>> CreateConfigAsync()
            {

                if (_cmdlet.DiskFile == null)
                {
                    ImageAndOsType = await _client.UpdateImageAndOsTypeAsync(
                        ImageAndOsType, _cmdlet.ResourceGroupName, _cmdlet.Image, Location);
                }

                _cmdlet.DomainNameLabel = await PublicIPAddressStrategy.UpdateDomainNameLabelAsync(
                    domainNameLabel: _cmdlet.DomainNameLabel,
                    name: _cmdlet.Name,
                    location: Location,
                    client: _client);

                Dictionary<string, List<string>> auxAuthHeader = null;
                if (!string.IsNullOrEmpty(_cmdlet.ImageReferenceId))
                {
                    var resourceId = ResourceId.TryParse(_cmdlet.ImageReferenceId);

                    if (string.Equals(ComputeStrategy.Namespace, resourceId?.ResourceType?.Namespace, StringComparison.OrdinalIgnoreCase)
                     && string.Equals("galleries", resourceId?.ResourceType?.Provider, StringComparison.OrdinalIgnoreCase)
                     && !string.Equals(_cmdlet.ComputeClient?.ComputeManagementClient?.SubscriptionId, resourceId?.SubscriptionId, StringComparison.OrdinalIgnoreCase))
                    {
                        List<string> resourceIds = new List<string>();
                        resourceIds.Add(_cmdlet.ImageReferenceId);
                        var auxHeaderDictionary = _cmdlet.GetAuxilaryAuthHeaderFromResourceIds(resourceIds);
                        if (auxHeaderDictionary != null && auxHeaderDictionary.Count > 0)
                        {
                            auxAuthHeader = new Dictionary<string, List<string>>(auxHeaderDictionary);
                        }
                    }
                }

                //Override Zone logic if PublicIpSku is explicitly provided
                PublicIPAddressStrategy.Sku publicIpSku;
                if (_cmdlet.PublicIpSku != null) {
                    if (_cmdlet.PublicIpSku != "Basic" && _cmdlet.PublicIpSku != "Standard")
                    {
                        throw new InvalidDataException("Invalid PublicIpSku parameter entry. Acceptable values for PublicIpSku parameter are \"Basic\" or \"Standard\" only");
                    }
                    publicIpSku = _cmdlet.PublicIpSku == "Basic" ? PublicIPAddressStrategy.Sku.Basic : PublicIPAddressStrategy.Sku.Standard;
                }
                else {
                    publicIpSku = _cmdlet.Zone == null ? PublicIPAddressStrategy.Sku.Basic : PublicIPAddressStrategy.Sku.Standard;
                }
                
                if (_cmdlet.IsParameterBound(c => c.SecurityType))
                {
                    if (_cmdlet.SecurityType?.ToLower() == ConstantValues.TrustedLaunchSecurityType || _cmdlet.SecurityType?.ToLower() == ConstantValues.ConfidentialVMSecurityType)
                    {
                        _cmdlet.SecurityType = _cmdlet.SecurityType;
                        _cmdlet.EnableVtpm = _cmdlet.EnableVtpm ?? true;
                        _cmdlet.EnableSecureBoot = _cmdlet.EnableSecureBoot ?? true;
                    }
                }

                // Standard security type removing value since API does not support it.
                if (_cmdlet.IsParameterBound(c => c.SecurityType)  
                    && _cmdlet.SecurityType != null
                    && _cmdlet.SecurityType.ToString().ToLower() == ConstantValues.StandardSecurityType)
                {
                    _cmdlet.SecurityType = null;
                }

                var resourceGroup = ResourceGroupStrategy.CreateResourceGroupConfig(_cmdlet.ResourceGroupName);
                var virtualNetwork = resourceGroup.CreateVirtualNetworkConfig(
                    name: _cmdlet.VirtualNetworkName, edgeZone: _cmdlet.EdgeZone, addressPrefix: _cmdlet.AddressPrefix);
                var subnet = virtualNetwork.CreateSubnet(_cmdlet.SubnetName, _cmdlet.SubnetAddressPrefix);
                var publicIpAddress = resourceGroup.CreatePublicIPAddressConfig(
                    name: _cmdlet.PublicIpAddressName,
                    edgeZone: _cmdlet.EdgeZone,
                    domainNameLabel: _cmdlet.DomainNameLabel,
                    allocationMethod: _cmdlet.AllocationMethod,
                    sku: publicIpSku,
                    zones: _cmdlet.Zone);

                _cmdlet.OpenPorts = ImageAndOsType.UpdatePorts(_cmdlet.OpenPorts);

                var networkSecurityGroup = resourceGroup.CreateNetworkSecurityGroupConfig(
                    name: _cmdlet.SecurityGroupName,
                    openPorts: _cmdlet.OpenPorts);

                bool enableAcceleratedNetwork = Utils.DoesConfigSupportAcceleratedNetwork(_client,
                    ImageAndOsType, _cmdlet.Size, Location, DefaultLocation);

                ResourceConfig<NetworkInterface> networkInterface;
                if (string.IsNullOrEmpty(publicIpAddress.Name))
                {
                    networkInterface = resourceGroup.CreateNetworkInterfaceConfigNoPublicIP(
                        _cmdlet.Name, _cmdlet.EdgeZone, subnet,
                        networkSecurityGroup, enableAcceleratedNetwork);
                }
                else
                {
                    networkInterface = resourceGroup.CreateNetworkInterfaceConfig(
                        _cmdlet.Name, _cmdlet.EdgeZone, subnet, publicIpAddress, networkSecurityGroup, enableAcceleratedNetwork);
                }

                var ppgSubResourceFunc = resourceGroup.CreateProximityPlacementGroupSubResourceFunc(_cmdlet.ProximityPlacementGroupId);

                var availabilitySet = _cmdlet.AvailabilitySetName == null
                    ? null
                    : resourceGroup.CreateAvailabilitySetConfig(
                        name: _cmdlet.AvailabilitySetName,
                        proximityPlacementGroup: ppgSubResourceFunc);


                List<SshPublicKey> sshPublicKeyList = null;
                if (!String.IsNullOrEmpty(_cmdlet.SshKeyName))
                {
                    SshPublicKey sshPublicKey = _cmdlet.createPublicKeyObject(_cmdlet.Credential.UserName);
                    sshPublicKeyList = new List<SshPublicKey>()
                    {
                        sshPublicKey
                    };
                }

                // AdditionalCapabilities
                var vAdditionalCapabilities = new AdditionalCapabilities();
                if (_cmdlet.IsParameterBound(c => c.HibernationEnabled))
                {
                    vAdditionalCapabilities.HibernationEnabled = _cmdlet.HibernationEnabled;
                }
                if (_cmdlet.IsParameterBound(c => c.EnableUltraSSD))
                {
                    vAdditionalCapabilities.UltraSSDEnabled = _cmdlet.EnableUltraSSD;
                }

                _cmdlet.ConfigAsyncVisited = true;

                // ExtendedLocation
                CM.ExtendedLocation extLoc = null;
                if (_cmdlet.EdgeZone != null)
                {
                    extLoc = new CM.ExtendedLocation { Name = _cmdlet.EdgeZone, Type = CM.ExtendedLocationTypes.EdgeZone };
                }

                if (_cmdlet.DiskFile == null)
                { 
                    return resourceGroup.CreateVirtualMachineConfig(
                        name: _cmdlet.Name,
                        networkInterface: networkInterface,
                        imageAndOsType: ImageAndOsType,
                        adminUsername: _cmdlet.Credential.UserName,
                        adminPassword:
                            new NetworkCredential(string.Empty, _cmdlet.Credential.Password).Password,
                        size: _cmdlet.Size,
                        availabilitySet: availabilitySet,
                        dataDisks: _cmdlet.DataDiskSizeInGb,
                        zones: _cmdlet.Zone,
                        identity: _cmdlet.GetVMIdentityFromArgs(),
                        proximityPlacementGroup: ppgSubResourceFunc,
                        hostId: _cmdlet.HostId,
                        hostGroupId: _cmdlet.HostGroupId,
                        capacityReservationGroupId: _cmdlet.CapacityReservationGroupId,
                        VmssId: _cmdlet.VmssId,
                        priority: _cmdlet.Priority,
                        evictionPolicy: _cmdlet.EvictionPolicy,
                        maxPrice: _cmdlet.IsParameterBound(c => c.MaxPrice) ? _cmdlet.MaxPrice : (double?)null,
                        encryptionAtHostPresent: _cmdlet.EncryptionAtHost.IsPresent,
                        sshPublicKeys: sshPublicKeyList,
                        networkInterfaceDeleteOption: _cmdlet.NetworkInterfaceDeleteOption,
                        osDiskDeleteOption: _cmdlet.OSDiskDeleteOption,
                        dataDiskDeleteOption: _cmdlet.DataDiskDeleteOption,
                        userData: _cmdlet.UserData,
                        platformFaultDomain: _cmdlet.IsParameterBound(c => c.PlatformFaultDomain) ? _cmdlet.PlatformFaultDomain : (int?) null,
                        additionalCapabilities: vAdditionalCapabilities,
                        vCPUsAvailable: _cmdlet.IsParameterBound(c => c.vCPUCountAvailable) ? _cmdlet.vCPUCountAvailable : (int?)null,
                        vCPUsPerCore: _cmdlet.IsParameterBound(c => c.vCPUCountPerCore) ? _cmdlet.vCPUCountPerCore : (int?)null,
                        imageReferenceId: _cmdlet.ImageReferenceId,
                        auxAuthHeader: auxAuthHeader,
                        diskControllerType: _cmdlet.DiskControllerType,
                        extendedLocation: extLoc,
                        sharedGalleryImageId: _cmdlet.SharedGalleryImageId,
                        securityType: _cmdlet.SecurityType,
                        enableVtpm: _cmdlet.EnableVtpm,
                        enableSecureBoot: _cmdlet.EnableSecureBoot
                        );
                }
                else
                {
                    var disk = resourceGroup.CreateManagedDiskConfig(
                        name: _cmdlet.Name,
                        sourceUri: DestinationUri.Uri.ToString());

                    return resourceGroup.CreateVirtualMachineConfig(
                        name: _cmdlet.Name,
                        networkInterface: networkInterface,
                        osType: ImageAndOsType.OsType,
                        disk: disk,
                        size: _cmdlet.Size,
                        availabilitySet: availabilitySet,
                        dataDisks: _cmdlet.DataDiskSizeInGb,
                        zones: _cmdlet.Zone,
                        ultraSSDEnabled: _cmdlet.EnableUltraSSD,
                        identity: _cmdlet.GetVMIdentityFromArgs(),
                        proximityPlacementGroup: ppgSubResourceFunc,
                        hostId: _cmdlet.HostId,
                        hostGroupId: _cmdlet.HostGroupId,
                        capacityReservationGroupId: _cmdlet.CapacityReservationGroupId,
                        VmssId: _cmdlet.VmssId,
                        priority: _cmdlet.Priority,
                        evictionPolicy: _cmdlet.EvictionPolicy,
                        maxPrice: _cmdlet.IsParameterBound(c => c.MaxPrice) ? _cmdlet.MaxPrice : (double?)null,
                        encryptionAtHostPresent: _cmdlet.EncryptionAtHost.IsPresent,
                        networkInterfaceDeleteOption: _cmdlet.NetworkInterfaceDeleteOption,
                        osDiskDeleteOption: _cmdlet.OSDiskDeleteOption,
                        dataDiskDeleteOption: _cmdlet.DataDiskDeleteOption,
                        userData: _cmdlet.UserData,
                        platformFaultDomain: _cmdlet.IsParameterBound(c => c.PlatformFaultDomain) ? _cmdlet.PlatformFaultDomain : (int?)null,
                        additionalCapabilities: vAdditionalCapabilities,
                        vCPUsAvailable: _cmdlet.IsParameterBound(c => c.vCPUCountAvailable) ? _cmdlet.vCPUCountAvailable : (int?)null,
                        vCPUsPerCore: _cmdlet.IsParameterBound(c => c.vCPUCountPerCore) ? _cmdlet.vCPUCountPerCore : (int?)null,
                        extendedLocation: extLoc,
                        securityType: _cmdlet.SecurityType,
                        enableVtpm: _cmdlet.EnableVtpm,
                        enableSecureBoot: _cmdlet.EnableSecureBoot
                    );
                }
            }
        }

        async Task StrategyExecuteCmdletAsync(IAsyncCmdlet asyncCmdlet)
        {
            var client = new Client(DefaultProfile.DefaultContext);

            ResourceGroupName = ResourceGroupName ?? Name;
            VirtualNetworkName = VirtualNetworkName ?? Name;
            SubnetName = SubnetName ?? Name;
            PublicIpAddressName = PublicIpAddressName;
            SecurityGroupName = SecurityGroupName ?? Name;

            // Check TrustedLaunch UEFI values defaulting
            if (this.IsParameterBound(c => c.SecurityType)
                && this.SecurityType != null)
            {
                if (this.SecurityType?.ToLower() == ConstantValues.TrustedLaunchSecurityType || this.SecurityType?.ToLower() == ConstantValues.ConfidentialVMSecurityType)
                {
                    this.SecurityType = this.SecurityType;
                    this.EnableVtpm = this.EnableVtpm ?? true;
                    this.EnableSecureBoot = this.EnableSecureBoot ?? true;
                }
                else if (this.SecurityType?.ToLower() == ConstantValues.StandardSecurityType)
                {
                    this.SecurityType = this.SecurityType;
                }
                
            }
            // Default TrustedLaunch values for SimpleParameterSet (no config)
            // imagerefid is specifically shared gallery id, so don't want it.
            else
            {
                if (!this.IsParameterBound(c => c.Image) 
                    && !this.IsParameterBound(c => c.ImageReferenceId) 
                    && !this.IsParameterBound(c => c.SharedGalleryImageId))
                {
                    this.SecurityType = ConstantValues.TrustedLaunchSecurityType;
                    this.Image = ConstantValues.TrustedLaunchDefaultImageAlias;
                    if (!this.IsParameterBound(c => c.EnableSecureBoot))
                    {
                        this.EnableSecureBoot = true;
                    }
                    if (!this.IsParameterBound(c => c.EnableVtpm))
                    {
                        this.EnableVtpm = true;
                    }
                }
            } 

            var resourceClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(
                    DefaultProfile.DefaultContext,
                    AzureEnvironment.Endpoint.ResourceManager);

            var parameters = new Parameters(this, client, resourceClient);
            
            // Information message if the default Size value is used. 
            if (!this.IsParameterBound(c => c.Size))
            {
                WriteInformation("No Size value has been provided. The VM will be created with the default size Standard_D2s_v3.", new string[] { "PSHOST" });
            }
            if (DiskFile != null)
            {
                if (!resourceClient.ResourceGroups.CheckExistence(ResourceGroupName))
                {
                    Location = Location ?? parameters.DefaultLocation;
                    var st0 = resourceClient.ResourceGroups.CreateOrUpdate(
                        ResourceGroupName,
                        new ResourceGroup
                        {
                            Location = Location,
                            Name = ResourceGroupName
                        });
                }
                parameters.ImageAndOsType = new ImageAndOsType(
                    Linux ? OperatingSystemTypes.Linux : OperatingSystemTypes.Windows,
                    null,
                    null);

                var storageClient = AzureSession.Instance.ClientFactory.CreateArmClient<StorageManagementClient>(
                    DefaultProfile.DefaultContext,
                    AzureEnvironment.Endpoint.ResourceManager);
                var st1 = storageClient.StorageAccounts.Create(
                    ResourceGroupName,
                    Name,
                    new StorageAccountCreateParameters
                    {
                        Kind = "StorageV2",
                        Sku = new Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Storage.Models.Sku
                        {
                            Name = Microsoft.Azure.PowerShell.Cmdlets.Compute.Helpers.Storage.Models.SkuName.PremiumLRS
                        },
                        Location = Location
                    });
                var filePath = new FileInfo(SessionState.Path.GetUnresolvedProviderPathFromPSPath(DiskFile));
                using (var vds = new VirtualDiskStream(filePath.FullName))
                {
                    // 2 ^ 9 == 512
                    if (vds.DiskType == DiskType.Fixed && filePath.Length % 512 != 0)
                    {
                        throw new ArgumentOutOfRangeException(
                            "filePath",
                            string.Format("Given vhd file '{0}' is a corrupted fixed vhd", filePath));
                    }
                }
                var storageAccount = storageClient.StorageAccounts.GetProperties(ResourceGroupName, Name);
                parameters.StorageAccountId = storageAccount.Id;
                // BlobUri destinationUri = null;
                BlobUri.TryParseUri(
                    new Uri(string.Format(
                        "{0}{1}/{2}{3}",
                        storageAccount.PrimaryEndpoints.Blob,
                        ResourceGroupName.ToLower(),
                        Name.ToLower(),
                        ".vhd")),
                    out parameters.DestinationUri);
                if (parameters.DestinationUri?.Uri == null)
                {
                    throw new ArgumentNullException("destinationUri");
                }
                var storageCredentialsFactory = new StorageCredentialsFactory(
                    ResourceGroupName, storageClient, DefaultContext.Subscription);
                var uploadParameters = new UploadParameters(parameters.DestinationUri, null, filePath, true, 2)
                {
                    Cmdlet = this,
                    BlobObjectFactory = new CloudPageBlobObjectFactory(storageCredentialsFactory, TimeSpan.FromMinutes(1))
                };
                if (!string.Equals(
                    Environment.GetEnvironmentVariable("AZURE_TEST_MODE"), "Playback", StringComparison.OrdinalIgnoreCase))
                {
                    var st2 = VhdUploaderModel.Upload(uploadParameters);
                }
            }

            VirtualMachine result;
            try
            {
                result = await client.RunAsync(client.SubscriptionId, parameters, asyncCmdlet);
            }
            catch (Microsoft.Rest.Azure.CloudException ex)
            {
                cleanUp();
                throw ex;
            }

            
            if (result != null)
            {
                var fqdn = PublicIPAddressStrategy.Fqdn(DomainNameLabel, Location);
                var psResult = ComputeAutoMapperProfile.Mapper.Map<PSVirtualMachine>(result);
                psResult.FullyQualifiedDomainName = fqdn;
                var connectionString = parameters.ImageAndOsType.GetConnectionString(
                    fqdn,
                    Credential?.UserName);
                asyncCmdlet.WriteVerbose(
                    Resources.VirtualMachineUseConnectionString,
                    connectionString);
                asyncCmdlet.WriteObject(psResult);
            }
        }

        public void DefaultExecuteCmdlet()
        {
            validate();

            base.ExecuteCmdlet();
            if (this.VM.DiagnosticsProfile == null)
            {
                var storageUri = GetOrCreateStorageAccountForBootDiagnostics();

                if (storageUri != null)
                {
                    this.VM.DiagnosticsProfile = new DiagnosticsProfile
                    {
                        BootDiagnostics = new BootDiagnostics
                        {
                            Enabled = true,
                            StorageUri = storageUri.ToString(),
                        }
                    };
                }
            }

            CM.ExtendedLocation ExtendedLocation = null;
            if (this.EdgeZone != null)
            {
                ExtendedLocation = new CM.ExtendedLocation { Name = this.EdgeZone, Type = CM.ExtendedLocationTypes.EdgeZone };
            }

            // Normal TL defaulting check, minimal params
            if (this.VM.SecurityProfile?.SecurityType == null
             && this.VM.StorageProfile?.ImageReference == null
             && this.VM.StorageProfile?.OsDisk?.ManagedDisk?.Id == null
             && this.VM.StorageProfile?.ImageReference?.SharedGalleryImageId == null) //had to add this
            {
                defaultTrustedLaunchAndUefi();

                setTrustedLaunchImage();
            }

            // Disk attached scenario for TL defaulting
            // Determines if the disk has SecurityType enabled.
            // If so, turns on TrustedLaunch for this VM.
            if (this.VM.SecurityProfile?.SecurityType == null
                && this.VM.StorageProfile?.OsDisk?.ManagedDisk?.Id != null)
            {
                var mDiskId = this.VM.StorageProfile?.OsDisk?.ManagedDisk.Id.ToString();
                var diskIdParts = mDiskId.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                string rgName = diskIdParts[Array.IndexOf(diskIdParts, "resourceGroups") + 1];
                string diskName = diskIdParts[Array.IndexOf(diskIdParts, "disks") + 1];
                var getManagedDisk = ComputeClient.ComputeManagementClient.Disks.Get(rgName, diskName);
                if (getManagedDisk.SecurityProfile?.SecurityType != null
                    && getManagedDisk.SecurityProfile?.SecurityType?.ToString().ToLower() == ConstantValues.TrustedLaunchSecurityType)
                {
                    defaultTrustedLaunchAndUefi();
                }
            }

            // Guest Attestation extension defaulting scenario check.
            // And SecureBootEnabled and VtpmEnabled defaulting scenario.
            if (this.VM.SecurityProfile?.SecurityType != null
                && (this.VM.SecurityProfile?.SecurityType?.ToLower() == ConstantValues.TrustedLaunchSecurityType 
                || this.VM.SecurityProfile?.SecurityType?.ToLower() == ConstantValues.ConfidentialVMSecurityType))
            {
                if (this.VM?.SecurityProfile?.UefiSettings != null)
                {
                    this.VM.SecurityProfile.UefiSettings.SecureBootEnabled = this.VM.SecurityProfile.UefiSettings.SecureBootEnabled ?? true;
                    this.VM.SecurityProfile.UefiSettings.VTpmEnabled = this.VM.SecurityProfile.UefiSettings.VTpmEnabled ?? true;
                }
                else
                {
                    this.VM.SecurityProfile.UefiSettings = new UefiSettings(true, true);
                }
            }
            

            // ImageReference provided, TL defaulting occurs if image is Gen2. 
            if (this.VM.SecurityProfile?.SecurityType == null
                && this.VM.StorageProfile?.ImageReference != null)
            {
                if (this.VM.StorageProfile?.ImageReference?.Id != null)//This code should never happen apparently
                {
                    string imageRefString = this.VM.StorageProfile.ImageReference.Id.ToString();

                    var parts = imageRefString.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                    string imagePublisher = parts[Array.IndexOf(parts, "Publishers") + 1];
                    string imageOffer = parts[Array.IndexOf(parts, "Offers") + 1];
                    string imageSku = parts[Array.IndexOf(parts, "Skus") + 1];
                    string imageVersion = parts[Array.IndexOf(parts, "Versions") + 1];
                    //location is required when config object provided. 
                    var imgResponse = ComputeClient.ComputeManagementClient.VirtualMachineImages.GetWithHttpMessagesAsync(
                            this.Location.Canonicalize(),
                            imagePublisher,
                            imageOffer,
                            imageSku,
                            version: imageVersion).GetAwaiter().GetResult();

                    setHyperVGenForImageCheckAndTLDefaulting(imgResponse);
                }
                else
                {
                    // handle each field in image reference itself to then call it.
                    Microsoft.Rest.Azure.AzureOperationResponse<VirtualMachineImage> specificImageRespone = retrieveSpecificImageFromNotId();
                    setHyperVGenForImageCheckAndTLDefaulting(specificImageRespone);
                }
            }

            if (this.VM.SecurityProfile?.SecurityType == ConstantValues.TrustedLaunchSecurityType
             && this.VM.StorageProfile?.ImageReference == null
             && this.VM.StorageProfile?.OsDisk?.ManagedDisk?.Id == null //had to add this
             && this.VM.StorageProfile?.ImageReference?.SharedGalleryImageId == null) 
            {
                defaultTrustedLaunchAndUefi();

                setTrustedLaunchImage();
            }

            // Standard security type removing value since API does not support it yet.
            if (this.VM.SecurityProfile?.SecurityType != null
                && this.VM.SecurityProfile?.SecurityType?.ToString().ToLower() == ConstantValues.StandardSecurityType)
            {
                if (this.VM.SecurityProfile.UefiSettings?.SecureBootEnabled == null
                    && this.VM.SecurityProfile.UefiSettings?.VTpmEnabled == null
                    && this.VM.SecurityProfile.EncryptionAtHost == null)
                {
                    this.VM.SecurityProfile = null;
                }
                else
                {
                    this.VM.SecurityProfile.SecurityType = null;
                }
            }


            if (ShouldProcess(this.VM.Name, VerbsCommon.New))
            {
                ExecuteClientAction(() =>
                {
                    var parameters = new VirtualMachine
                    {
                        DiagnosticsProfile = this.VM.DiagnosticsProfile,
                        HardwareProfile = this.VM.HardwareProfile,
                        StorageProfile = this.VM.StorageProfile,
                        NetworkProfile = this.VM.NetworkProfile,
                        OsProfile = this.VM.OSProfile,
                        Plan = this.VM.Plan,
                        LicenseType = this.LicenseType ?? this.VM.LicenseType,
                        AvailabilitySet = this.VM.AvailabilitySetReference,
                        Location = this.Location ?? this.VM.Location,
                        ExtendedLocation = ExtendedLocation,
                        Tags = this.Tag != null ? this.Tag.ToDictionary() : this.VM.Tags,
                        Identity = ComputeAutoMapperProfile.Mapper.Map<VirtualMachineIdentity>(this.VM.Identity),
                        Zones = this.Zone ?? this.VM.Zones,
                        ProximityPlacementGroup = this.VM.ProximityPlacementGroup,
                        Host = this.VM.Host,
                        VirtualMachineScaleSet = this.VM.VirtualMachineScaleSet,
                        AdditionalCapabilities = this.VM.AdditionalCapabilities,
                        Priority = this.VM.Priority,
                        EvictionPolicy = this.VM.EvictionPolicy,
                        BillingProfile = this.VM.BillingProfile,
                        SecurityProfile = this.VM.SecurityProfile,
                        CapacityReservation = this.VM.CapacityReservation,
                        UserData = this.VM.UserData,
                        PlatformFaultDomain = this.VM.PlatformFaultDomain
                    };

                    Dictionary<string, List<string>> auxAuthHeader = null;
                    if (!string.IsNullOrEmpty(parameters.StorageProfile?.ImageReference?.Id))
                    {
                        var resourceId = ResourceId.TryParse(parameters.StorageProfile.ImageReference.Id);

                        if (string.Equals(ComputeStrategy.Namespace, resourceId?.ResourceType?.Namespace, StringComparison.OrdinalIgnoreCase)
                         && string.Equals("galleries", resourceId?.ResourceType?.Provider, StringComparison.OrdinalIgnoreCase)
                         && !string.Equals(this.ComputeClient?.ComputeManagementClient?.SubscriptionId, resourceId?.SubscriptionId, StringComparison.OrdinalIgnoreCase))
                        {
                            List<string> resourceIds = new List<string>();
                            resourceIds.Add(parameters.StorageProfile.ImageReference.Id);
                            var auxHeaderDictionary = GetAuxilaryAuthHeaderFromResourceIds(resourceIds);
                            if (auxHeaderDictionary != null && auxHeaderDictionary.Count > 0)
                            {
                                auxAuthHeader = new Dictionary<string, List<string>>(auxHeaderDictionary);
                            }
                        }
                    }

                    Rest.Azure.AzureOperationResponse<VirtualMachine> result;

                    if (this.IsParameterBound(c => c.SshKeyName))
                    {
                        parameters = addSshPublicKey(parameters);
                    }

                    try
                    {
                        result = this.VirtualMachineClient.CreateOrUpdateWithHttpMessagesAsync(
                        this.ResourceGroupName,
                        this.VM.Name,
                        parameters,
                        auxAuthHeader).GetAwaiter().GetResult();
                    }
                    catch (Exception ex)
                    {
                        cleanUp();
                        throw ex;
                    }

                    var psResult = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(result);

                    if (!(this.DisableBginfoExtension.IsPresent || IsLinuxOs()))
                    {
                        var currentBginfoVersion = GetBginfoExtension();

                        if (!string.IsNullOrEmpty(currentBginfoVersion))
                        {
                            var extensionParameters = new VirtualMachineExtension
                            {
                                Location = this.Location,
                                Publisher = VirtualMachineBGInfoExtensionContext.ExtensionDefaultPublisher,
                                VirtualMachineExtensionType = VirtualMachineBGInfoExtensionContext.ExtensionDefaultName,
                                TypeHandlerVersion = currentBginfoVersion,
                                AutoUpgradeMinorVersion = true,
                            };

                            typeof(CM.ResourceWithOptionalLocation).GetRuntimeProperty("Name")
                                .SetValue(extensionParameters, VirtualMachineBGInfoExtensionContext.ExtensionDefaultName);
                            typeof(CM.ResourceWithOptionalLocation).GetRuntimeProperty("Type")
                                .SetValue(extensionParameters, VirtualMachineExtensionType);

                            var op2 = ComputeClient.ComputeManagementClient.VirtualMachineExtensions.CreateOrUpdateWithHttpMessagesAsync(
                                this.ResourceGroupName,
                                this.VM.Name,
                                VirtualMachineBGInfoExtensionContext.ExtensionDefaultName,
                                extensionParameters).GetAwaiter().GetResult();
                            psResult = ComputeAutoMapperProfile.Mapper.Map<PSAzureOperationResponse>(op2);
                        }
                    }

                    WriteObject(psResult);
                });
            }
        }
        
        private void setTrustedLaunchImage()
        {
            if (this.VM.StorageProfile == null)
            {
                this.VM.StorageProfile = new StorageProfile();
            }
            if (this.VM.StorageProfile.ImageReference == null)
            {
                this.VM.StorageProfile.ImageReference = new ImageReference
                {
                    Publisher = "MicrosoftWindowsServer",
                    Offer = "WindowsServer",
                    Sku = "2022-datacenter-azure-edition",
                    Version = "latest"
                };
            } 
        }

        /// <summary>
        /// Default the TrustedLaunch SecurityType and UEFI values
        /// </summary>
        private void defaultTrustedLaunchAndUefi()
        {
            if (this.VM.SecurityProfile == null)
            {
                this.VM.SecurityProfile = new SecurityProfile();
            }
            this.VM.SecurityProfile.SecurityType = ConstantValues.TrustedLaunchSecurityType;

            if (this.VM.SecurityProfile.UefiSettings == null)
            {
                this.VM.SecurityProfile.UefiSettings = new UefiSettings(true, true);
            }

            if (this.VM.SecurityProfile.UefiSettings.VTpmEnabled == null)
            {
                this.VM.SecurityProfile.UefiSettings.VTpmEnabled = true;
            }
            if (this.VM.SecurityProfile.UefiSettings.SecureBootEnabled == null)
            {
                this.VM.SecurityProfile.UefiSettings.SecureBootEnabled = true;
            }
        }

        private void setHyperVGenForImageCheckAndTLDefaulting(Microsoft.Rest.Azure.AzureOperationResponse<VirtualMachineImage> specificImageRespone)
        {
            if (specificImageRespone.Body.HyperVGeneration.ToUpper() == "V2")
            {
                defaultTrustedLaunchAndUefi();
            }
            else if (specificImageRespone.Body.HyperVGeneration.ToUpper() == "V1")
            {
                if (this.VM.VirtualMachineScaleSet == null && !this.IsParameterBound(c => c.VmssId)) // for now, does not support adding vm to vmss directly, not worth the extra api call to see if the vmss is flex.
                {
                    if (this.VM.SecurityProfile == null)
                    {
                        this.VM.SecurityProfile = new SecurityProfile();
                    }
                    this.VM.SecurityProfile.SecurityType = ConstantValues.StandardSecurityType;
                    
                }

                if (this.AsJobPresent() == false) // to avoid a failure when it is a job. Seems to fail when it is a job.
                {
                    WriteInformation(HelpMessages.TrustedLaunchUpgradeMessage, new string[] { "PSHOST" });
                }
            }
        }

        /// <summary>
        /// Query for the given image if the ImageId is not used. 
        /// </summary>
        /// <returns> The API response of the VirtualMachineImage with the HyperVGeneration property. </returns>
        private Microsoft.Rest.Azure.AzureOperationResponse<VirtualMachineImage> retrieveSpecificImageFromNotId()
        {
            var imageVersion = retrieveImageVersion(this.VM.StorageProfile.ImageReference.Publisher,
                                                    this.VM.StorageProfile.ImageReference.Offer,
                                                    this.VM.StorageProfile.ImageReference.Sku,
                                                    this.VM.StorageProfile.ImageReference.Version);
            var imgResponse = ComputeClient.ComputeManagementClient.VirtualMachineImages.GetWithHttpMessagesAsync(
                    this.Location.Canonicalize(),
                    this.VM.StorageProfile.ImageReference.Publisher,
                    this.VM.StorageProfile.ImageReference.Offer,
                    this.VM.StorageProfile.ImageReference.Sku,
                    version: imageVersion).GetAwaiter().GetResult();
            return imgResponse;
        }

        /// <summary>
        /// Retrieves the specific image value if the version is 'latest' to use in Get calls.
        /// </summary>
        /// <param name="publisher"></param>
        /// <param name="offer"></param>
        /// <param name="sku"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        private string retrieveImageVersion(string publisher, string offer, string sku, string version)
        {
            if (version.ToLower() == "latest")
            {
                var imgResponse = ComputeClient.ComputeManagementClient.VirtualMachineImages.ListWithHttpMessagesAsync(
                            this.Location.Canonicalize(),
                            publisher,
                            offer,
                            sku,
                            top: 1,
                            orderby: "name desc").GetAwaiter().GetResult();

                var parts = imgResponse.Body[0].Id.ToString().Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                
                string imageVersion = parts[Array.IndexOf(parts, "Versions") + 1];

                return imageVersion;
            }
            else 
            {
                return version;
            }
        }

        /// <summary>
        /// Heres whats happening here :
        /// If "SystemAssignedIdentity" and "UserAssignedIdentity" are both present we set the type of identity to be SystemAssignedUsrAssigned and set the user 
        /// defined identity in the VM identity object.
        /// If only "SystemAssignedIdentity" is present, we just set the type of the Identity to "SystemAssigned" and no identity ids are set as its created by Azure
        /// If only "UserAssignedIdentity" is present, we set the type of the Identity to be "UserAssigned" and set the Identity in the VM identity object.
        /// If neither is present, we return a null.
        /// </summary>
        /// <returns>Returning the Identity generated form the cmdlet parameters "SystemAssignedIdentity" and "UserAssignedIdentity"</returns>
        private VirtualMachineIdentity GetVMIdentityFromArgs()
        {
            var isUserAssignedEnabled = !string.IsNullOrWhiteSpace(UserAssignedIdentity);
            return (SystemAssignedIdentity.IsPresent || isUserAssignedEnabled)
                ? new VirtualMachineIdentity
                {
                    Type = !isUserAssignedEnabled ?
                           CM.ResourceIdentityType.SystemAssigned :
                           (SystemAssignedIdentity.IsPresent ? CM.ResourceIdentityType.SystemAssignedUserAssigned : CM.ResourceIdentityType.UserAssigned),

                    UserAssignedIdentities = isUserAssignedEnabled
                                             ? new Dictionary<string, UserAssignedIdentitiesValue>()
                                             {
                                                 { UserAssignedIdentity, new UserAssignedIdentitiesValue() }
                                             }
                                             : null,
                }
                : null;
        }

        private string GetBginfoExtension()
        {
            var canonicalizedLocation = this.Location.Canonicalize();

            var publishers =
                ComputeClient.ComputeManagementClient.VirtualMachineImages.ListPublishers(canonicalizedLocation);

            var publisher = publishers.FirstOrDefault(e => e.Name.Equals(VirtualMachineBGInfoExtensionContext.ExtensionDefaultPublisher));

            if (publisher == null || !publisher.Name.Equals(VirtualMachineBGInfoExtensionContext.ExtensionDefaultPublisher))
            {
                return null;
            }

            var virtualMachineImageClient = ComputeClient.ComputeManagementClient.VirtualMachineExtensionImages;


            var imageTypes =
                virtualMachineImageClient.ListTypes(canonicalizedLocation,
                    VirtualMachineBGInfoExtensionContext.ExtensionDefaultPublisher);

            var extensionType = imageTypes.FirstOrDefault(
                e => e.Name.Equals(VirtualMachineBGInfoExtensionContext.ExtensionDefaultName));

            if (extensionType == null || !extensionType.Name.Equals(VirtualMachineBGInfoExtensionContext.ExtensionDefaultName))
            {
                return null;
            }

            var bginfoVersions =
                virtualMachineImageClient.ListVersions(canonicalizedLocation,
                    VirtualMachineBGInfoExtensionContext.ExtensionDefaultPublisher,
                    VirtualMachineBGInfoExtensionContext.ExtensionDefaultName);

            if (bginfoVersions != null
                && bginfoVersions.Count > 0)
            {
                return bginfoVersions.Max(ver =>
                {
                    Version result;
                    return (Version.TryParse(ver.Name, out result))
                        ? string.Format("{0}.{1}", result.Major, result.Minor)
                        : VirtualMachineBGInfoExtensionContext.ExtensionDefaultVersion;
                });
            }

            return null;
        }

        private bool IsLinuxOs()
        {
            if (this.VM == null)
            {
                return false;
            }

            if ((this.VM.StorageProfile != null)
                && (this.VM.StorageProfile.OsDisk != null)
                && (this.VM.StorageProfile.OsDisk.OsType != null))
            {
                return (this.VM.StorageProfile.OsDisk.OsType.Equals(OperatingSystemTypes.Linux));
            }

            return ((this.VM.OSProfile != null)
                    && (this.VM.OSProfile.LinuxConfiguration != null));
        }

        private string GetOrCreateStorageAccountForBootDiagnostics()
        {
            var storageAccountName = GetStorageAccountNameFromStorageProfile();
            var storageClient =
                    AzureSession.Instance.ClientFactory.CreateArmClient<StorageManagementClient>(DefaultProfile.DefaultContext,
                        AzureEnvironment.Endpoint.ResourceManager);

            if (!string.IsNullOrEmpty(storageAccountName))
            {
                try
                {
                    var storageAccountList = storageClient.StorageAccounts.List();
                    if (storageAccountList != null)
                    {
                        var osDiskStorageAccount = storageAccountList.First(e => e.Name.Equals(storageAccountName));

                        if (osDiskStorageAccount != null
                            && osDiskStorageAccount.Sku() != null
                            && !osDiskStorageAccount.SkuName().ToLowerInvariant().Contains("premium"))
                        {
                            return osDiskStorageAccount.PrimaryEndpoints.Blob;
                        }
                    }
                }
                catch (Exception e)
                {
                    if (e.Message.Contains("ResourceNotFound"))
                    {
                        WriteWarning(string.Format(
                            Properties.Resources.StorageAccountNotFoundForBootDiagnostics, storageAccountName));
                    }
                    else
                    {
                        WriteWarning(string.Format(
                            Properties.Resources.ErrorDuringGettingStorageAccountForBootDiagnostics, storageAccountName, e.Message));
                    }
                }
            }

            var storagePrimaryEndpointBlob = CreateStandardStorageAccount(storageClient);
            return storagePrimaryEndpointBlob;
            
        }

        private string GetStorageAccountNameFromStorageProfile()
        {
            if (this.VM == null
                || this.VM.StorageProfile == null
                || this.VM.StorageProfile.OsDisk == null
                || this.VM.StorageProfile.OsDisk.Vhd == null
                || this.VM.StorageProfile.OsDisk.Vhd.Uri == null)
            {
                return null;
            }

            return GetStorageAccountNameFromUriString(this.VM.StorageProfile.OsDisk.Vhd.Uri);
        }

        private StorageAccount TryToChooseExistingStandardStorageAccount(StorageManagementClient client)
        {
            IEnumerable<StorageAccount> storageAccountList = client.StorageAccounts.ListByResourceGroup(this.ResourceGroupName);
            if (storageAccountList == null || storageAccountList.Count() == 0)
            {
                storageAccountList = client.StorageAccounts.List().Where(e => e.Location.Canonicalize().Equals(this.Location.Canonicalize()));
                if (storageAccountList == null || storageAccountList.Count() == 0)
                {
                    return null;
                }
            }

            try
            {
                return storageAccountList.First(
                    e => e.Location.Canonicalize().Equals(this.Location.Canonicalize())
                      && e.Sku() != null
                      && !e.SkuName().ToLowerInvariant().Contains("premium"));
            }
            catch (InvalidOperationException e)
            {
                WriteWarning(string.Format(
                            Properties.Resources.ErrorDuringChoosingStandardStorageAccount, e.Message));
                return null;
            }
        }

        private string CreateStandardStorageAccount(StorageManagementClient client)
        {
            string storageAccountName;

            var i = 0;
            do
            {
                storageAccountName = GetRandomStorageAccountName(i);
                i++;
            }
            while (i < 10 && (bool)!client.StorageAccounts.CheckNameAvailability(storageAccountName).NameAvailable);

            SM.ExtendedLocation extendedLocation = null;
            if (this.EdgeZone != null)
            {
                extendedLocation = new SM.ExtendedLocation { Name = this.EdgeZone, Type = CM.ExtendedLocationTypes.EdgeZone };
            }

            var storaeAccountParameter = new StorageAccountCreateParameters
            {
                Kind = "StorageV2",
                Location = this.Location ?? this.VM.Location,
                ExtendedLocation = extendedLocation
            };
            storaeAccountParameter.SetAsStandardGRS();

            try
            {
                client.StorageAccounts.Create(this.ResourceGroupName, storageAccountName, storaeAccountParameter);
                var getresponse = client.StorageAccounts.GetProperties(this.ResourceGroupName, storageAccountName);
                WriteWarning(string.Format(Properties.Resources.CreatingStorageAccountForBootDiagnostics, storageAccountName));

                return getresponse.PrimaryEndpoints.Blob;
            }
            catch (Exception e)
            {
                // Failed to create a storage account for boot diagnostics.
                WriteWarning(string.Format(Properties.Resources.ErrorDuringCreatingStorageAccountForBootDiagnostics, e));
                return null;
            }
        }

        private string GetRandomStorageAccountName(int interation)
        {
            const int maxSubLength = 5;
            const int maxResLength = 6;
            const int maxVMLength = 4;

            var subscriptionName = VirtualMachineCmdletHelper.GetTruncatedStr(this.DefaultContext.Subscription.Name, maxSubLength);
            var resourcename = VirtualMachineCmdletHelper.GetTruncatedStr(this.ResourceGroupName, maxResLength);
            var vmname = VirtualMachineCmdletHelper.GetTruncatedStr(this.VM.Name, maxVMLength);
            var datetimestr = DateTime.Now.ToString("MMddHHmm");

            var output = subscriptionName + resourcename + vmname + datetimestr + interation;

            output = new string((from c in output where char.IsLetterOrDigit(c) select c).ToArray());

            return output.ToLowerInvariant();
        }

        private static string GetStorageAccountNameFromUriString(string uriStr)
        {
            Uri uri;

            if (!Uri.TryCreate(uriStr, UriKind.RelativeOrAbsolute, out uri))
            {
                return null;
            }

            var storageUri = uri.Authority;
            var index = storageUri.IndexOf('.');
            return storageUri.Substring(0, index);
        }

        private SshPublicKey createPublicKeyObject(string username)
        {
            string publicKeyPath = "/home/" + username + "/.ssh/authorized_keys";
            string publicKey = GenerateOrFindSshKey();
            SshPublicKey sshPublicKey = new SshPublicKey(publicKeyPath, publicKey);
            return sshPublicKey;

        }
        private string GenerateOrFindSshKey()
        {
            string publicKey = "";
            SshPublicKeyResource SshPublicKey;
            if (!this.ConfigAsyncVisited && this.GenerateSshKey.IsPresent)
            {
                try
                {
                    SshPublicKey = this.ComputeClient.ComputeManagementClient.SshPublicKeys.Get(this.ResourceGroupName, this.SshKeyName);
                    publicKey = SshPublicKey.PublicKey;
                }
                catch (Rest.Azure.CloudException)
                {
                    //create key 
                    SshPublicKeyResource sshkey = new SshPublicKeyResource();
                    sshkey.Location = this.Location != null ? this.Location : "eastus";
                    SshPublicKey = this.ComputeClient.ComputeManagementClient.SshPublicKeys.Create(this.ResourceGroupName, this.SshKeyName, sshkey);
                    SshPublicKeyGenerateKeyPairResult keypair = this.ComputeClient.ComputeManagementClient.SshPublicKeys.GenerateKeyPair(this.ResourceGroupName, this.SshKeyName);

                    string sshFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".ssh");
                    if (!Directory.Exists(sshFolder))
                    {
                        Directory.CreateDirectory(sshFolder);
                    }

                    DateTimeOffset now = DateTimeOffset.UtcNow;
                    string privateKeyFileName = now.ToUnixTimeSeconds().ToString();
                    string publicKeyFileName = now.ToUnixTimeSeconds().ToString() + ".pub";
                    string privateKeyFilePath = Path.Combine(sshFolder, privateKeyFileName);
                    string publicKeyFilePath = Path.Combine(sshFolder, publicKeyFileName);
                    using (StreamWriter writer = new StreamWriter(privateKeyFilePath))
                    {
                        writer.WriteLine(keypair.PrivateKey);
                    }
                    Console.WriteLine("Private key is saved to " + privateKeyFilePath);

                    FileSecurity fileSecurity = new FileSecurity(privateKeyFilePath, AccessControlSections.Access);
                    // Define the owner's identity
                    IdentityReference owner = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);

                    // Create an access rule for the owner with read and write permissions (0600)
                    FileSystemAccessRule rule = new FileSystemAccessRule(
                        owner,
                        FileSystemRights.Read | FileSystemRights.Write,
                        AccessControlType.Allow
                    );

                    // Add the access rule to the file security
                    fileSecurity.AddAccessRule(rule);

                    FileInfo fileinfo = new FileInfo(privateKeyFilePath);
                    fileinfo.SetAccessControl(fileSecurity);

                    using (StreamWriter writer = new StreamWriter(publicKeyFilePath))
                    {
                        writer.WriteLine(keypair.PublicKey);
                    }
                    Console.WriteLine("Public key is saved to " + publicKeyFilePath);

                    return keypair.PublicKey;
                }

                throw new Exception("The SSH Public Key resource with name '-SshKeyName' already exists. Either remove '-GenerateSshKey' to use the existing resource or update '-SshKeyName' to create a SSH Public Key resource with a different name.");

            }
            else
            {
                try
                {
                    SshPublicKey = this.ComputeClient.ComputeManagementClient.SshPublicKeys.Get(this.ResourceGroupName, this.SshKeyName);
                    publicKey = SshPublicKey.PublicKey;
                }
                catch (Rest.Azure.CloudException)
                {
                    throw new Exception("The SSH Public Key resource with name '-SshKeyName' was not found. Either provide '-GenerateSshKey' to create the resource or provide a '-SshKeyName' that exists in the provided Resource Group.");
                }

                return publicKey;
            }
        }

        private VirtualMachine addSshPublicKey(VirtualMachine parameters)
        {
            SshPublicKey sshPublicKey = createPublicKeyObject(parameters.OsProfile.AdminUsername);
            List<SshPublicKey> sshPublicKeys = new List<SshPublicKey>()
            {
                sshPublicKey
            };
            if (parameters.OsProfile.LinuxConfiguration.Ssh == null)
            {
                SshConfiguration sshConfig = new SshConfiguration();
                parameters.OsProfile.LinuxConfiguration.Ssh = sshConfig;
            }
            parameters.OsProfile.LinuxConfiguration.Ssh.PublicKeys = sshPublicKeys;

            return parameters;
        }

        private void cleanUp()
        {
            if (this.GenerateSshKey.IsPresent)
            {
                //delete the created ssh key resource
                WriteInformation("VM creation failed. Deleting the SSH key resource that was created.", new string[] { "PSHOST" });
                this.ComputeClient.ComputeManagementClient.SshPublicKeys.Delete(this.ResourceGroupName, this.SshKeyName);
            }
        }

        private void validate()
        {
            if (this.IsParameterBound(c => c.SshKeyName))
            {
                if (this.ParameterSetName == "DefaultParameterSet" && !IsLinuxOs())
                {
                    throw new Exception("Parameters '-SshKeyName' and '-GenerateSshKey' are only allowed with Linux VMs");
                }

                if (this.ParameterSetName == "SimpleParameterSet")
                {
                    var client = new Client(DefaultProfile.DefaultContext);
                    ImageAndOsType ImageAndOsType = client.UpdateImageAndOsTypeAsync(
                            null, this.ResourceGroupName, this.Image, "").Result;
                    if (ImageAndOsType?.OsType != OperatingSystemTypes.Linux)
                    {
                        throw new Exception("Parameters '-SshKeyName' and '-GenerateSshKey' are only allowed with Linux VMs");
                    }
                }
            }
            else
            {
                if (this.GenerateSshKey.IsPresent)
                {
                    throw new Exception("Please provide parameter '-SshKeyName' to be used with '-GenerateSshKey'");
                }
            }
        }
    }
}
