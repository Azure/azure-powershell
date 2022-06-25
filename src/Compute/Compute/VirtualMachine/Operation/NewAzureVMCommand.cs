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


namespace Microsoft.Azure.Commands.Compute
{
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
            "CoreOS",
            "Debian",
            "openSUSE-Leap",
            "RHEL",
            "SLES",
            "UbuntuLTS",
            "Win2016Datacenter",
            "Win2012R2Datacenter",
            "Win2012Datacenter",
            "Win2008R2SP1",
            "Win10",
            "Win2019Datacenter")]
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
            HelpMessage = "Specifies the number of vCPUs available for the VM. When this property is not specified in the request body the default behavior is to set it to the value of vCPUs available for that VM size exposed in api response of [List all available virtual machine sizes in a region](https://docs.microsoft.com/en-us/rest/api/compute/resource-skus/list).")]
        public int vCPUCountAvailable { get; set; }

        [Parameter(
            Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the vCPU to physical core ratio. When this property is not specified in the request body the default behavior is set to the value of vCPUsPerCore for the VM Size exposed in api response of [List all available virtual machine sizes in a region](https://docs.microsoft.com/en-us/rest/api/compute/resource-skus/list). Setting this property to 1 also means that hyper-threading is disabled.")]
        public int vCPUCountPerCore { get; set; }

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

                var resourceGroup = ResourceGroupStrategy.CreateResourceGroupConfig(_cmdlet.ResourceGroupName);
                var virtualNetwork = resourceGroup.CreateVirtualNetworkConfig(
                    name: _cmdlet.VirtualNetworkName, edgeZone: _cmdlet.EdgeZone, addressPrefix: _cmdlet.AddressPrefix);
                var subnet = virtualNetwork.CreateSubnet(_cmdlet.SubnetName, _cmdlet.SubnetAddressPrefix);
                var publicIpAddress = resourceGroup.CreatePublicIPAddressConfig(
                    name: _cmdlet.PublicIpAddressName,
                    edgeZone: _cmdlet.EdgeZone,
                    domainNameLabel: _cmdlet.DomainNameLabel,
                    allocationMethod: _cmdlet.AllocationMethod,
                    sku: _cmdlet.Zone == null ? PublicIPAddressStrategy.Sku.Basic : PublicIPAddressStrategy.Sku.Standard,
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
                        auxAuthHeader: auxAuthHeader
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
                        vCPUsPerCore: _cmdlet.IsParameterBound(c => c.vCPUCountPerCore) ? _cmdlet.vCPUCountPerCore : (int?)null
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
                            Name = SkuName.PremiumLRS
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
                                             ? new Dictionary<string, VirtualMachineIdentityUserAssignedIdentitiesValue>()
                                             {
                                                 { UserAssignedIdentity, new VirtualMachineIdentityUserAssignedIdentitiesValue() }
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