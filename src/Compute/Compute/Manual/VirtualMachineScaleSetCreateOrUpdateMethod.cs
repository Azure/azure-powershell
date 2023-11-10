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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.Compute.Properties;
using Microsoft.Azure.Commands.Compute.Strategies;
using Microsoft.Azure.Commands.Compute.Strategies.ComputeRp;
using Microsoft.Azure.Commands.Compute.Strategies.Network;
using Microsoft.Azure.Commands.Compute.Strategies.ResourceManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.Commands.Compute.Common;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;
using Microsoft.Azure.Management.Compute;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    public partial class NewAzureRmVmss : ComputeAutomationBaseCmdlet
    {
        private const string flexibleOrchestrationMode = "Flexible", uniformOrchestrationMode = "Uniform";
        // SimpleParameterSet
        [Parameter(
            ParameterSetName = SimpleParameterSet, 
            Mandatory = false,
            HelpMessage = "The name of the image for VMs in this Scale Set. If no value is provided, the 'Windows Server 2016 DataCenter' image will be used.")]
        [PSArgumentCompleter(
            "CentOS85Gen2", 
            "Debian11", 
            "OpenSuseLeap154Gen2", 
            "RHELRaw8LVMGen2", 
            "SuseSles15SP3", 
            "Ubuntu2204", 
            "FlatcarLinuxFreeGen2", 
            "Win2022Datacenter", 
            "Win2022AzureEditionCore", 
            "Win2019Datacenter", 
            "Win2016Datacenter", 
            "Win2012R2Datacenter", 
            "Win2012Datacenter", 
            "Win2008R2SP1")]
        [Alias("Image")]
        public string ImageName { get; set; } = "Win2016Datacenter";

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = true)]
        public PSCredential Credential { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        public int InstanceCount { get; set; } = 2;

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        public string VirtualNetworkName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        public string SubnetName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        public string PublicIpAddressName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        public string DomainNameLabel { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        public string SecurityGroupName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        public string LoadBalancerName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        public int[] BackendPort { get; set; } = new[] { 80 };

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [LocationCompleter("Microsoft.Compute/virtualMachineScaleSets")]
        public string Location { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string EdgeZone { get; set; }

        // this corresponds to VmSku in the Azure CLI
        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        public string VmSize { get; set; } = "Standard_DS1_v2";

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        public UpgradeMode UpgradePolicyMode { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        [ValidateSet("Static", "Dynamic")]
        public string AllocationMethod { get; set; } = "Static";

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        public string VnetAddressPrefix { get; set; } = "192.168.0.0/16";

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        public string SubnetAddressPrefix { get; set; } = "192.168.1.0/24";

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        public string FrontendPoolName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        public string BackendPoolName { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false, HelpMessage = "Use this to add system assigned identity (MSI) to the vm")]
        public SwitchParameter SystemAssignedIdentity { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false, HelpMessage = "Use this to add the assign user specified identity (MSI) to the VM")]
        [ValidateNotNullOrEmpty]
        public string UserAssignedIdentity { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        public SwitchParameter EnableUltraSSD { get; set; }

        [Parameter(
            ParameterSetName = SimpleParameterSet,
            Mandatory = false,
            HelpMessage = "A list of availability zones denoting the IP allocated for the resource needs to come from.",
            ValueFromPipelineByPropertyName = true)]
        public List<string> Zone { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        public int[] NatBackendPort { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        public int[] DataDiskSizeInGb { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false, HelpMessage ="Use this to create the Scale set in a single placement group, default is multiple groups")]
        public SwitchParameter SinglePlacementGroup;

        [Alias("ProximityPlacementGroup")]
        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        public string ProximityPlacementGroupId { get; set; }

        [Alias("HostGroup")]
        [Parameter(
            ParameterSetName = SimpleParameterSet,
            Mandatory = false,
            HelpMessage = "Specifies the dedicated host group the virtual machine scale set will reside in.",
            ValueFromPipelineByPropertyName = true
        )]
        public string HostGroupId { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false,
            HelpMessage = "The priority for the virtual machine in the scale set. Only supported values are 'Regular', 'Spot' and 'Low'. 'Regular' is for regular virtual machine. 'Spot' is for spot virtual machine. 'Low' is also for spot virtual machine but is replaced by 'Spot'. Please use 'Spot' instead of 'Low'.")]
        [PSArgumentCompleter("Regular", "Spot")]
        public string Priority { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false,
            HelpMessage = "The eviction policy for the low priority virtual machine scale set.  Only supported values are 'Deallocate' and 'Delete'.")]
        [PSArgumentCompleter("Deallocate", "Delete")]
        public string EvictionPolicy { get; set; }
        
        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false,
            HelpMessage = "The max price of the billing of a low priority virtual machine scale set.")]
        public double MaxPrice { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false,
            HelpMessage = "The rules to be followed when scaling-in a virtual machine scale set.  "
                        + "Possible values are: 'Default', 'OldestVM' and 'NewestVM'.  "
                        + "'Default' when a virtual machine scale set is scaled in, the scale set will first be balanced across zones if it is a zonal scale set.  "
                        + "Then, it will be balanced across Fault Domains as far as possible.  "
                        + "Within each Fault Domain, the virtual machines chosen for removal will be the newest ones that are not protected from scale-in.  "
                        + "'OldestVM' when a virtual machine scale set is being scaled-in, the oldest virtual machines that are not protected from scale-in will be chosen for removal.  "
                        + "For zonal virtual machine scale sets, the scale set will first be balanced across zones.  "
                        + "Within each zone, the oldest virtual machines that are not protected will be chosen for removal.  "
                        + "'NewestVM' when a virtual machine scale set is being scaled-in, the newest virtual machines that are not protected from scale-in will be chosen for removal.  "
                        + "For zonal virtual machine scale sets, the scale set will first be balanced across zones.  "
                        + "Within each zone, the newest virtual machines that are not protected will be chosen for removal.")]
        [PSArgumentCompleter("Default", "OldestVM", "NewestVM")]
        public string[] ScaleInPolicy { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false,
            HelpMessage = "When Overprovision is enabled, extensions are launched only on the requested number of VMs which are finally kept. "
                        + "This property will hence ensure that the extensions do not run on the extra overprovisioned VMs.")]
        public SwitchParameter SkipExtensionsOnOverprovisionedVMs { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false)]
        public SwitchParameter EncryptionAtHost { get; set; }

        [Parameter(ParameterSetName = SimpleParameterSet, Mandatory = false,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Fault Domain count for each placement group.")]
        public int PlatformFaultDomainCount { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = SimpleParameterSet,
            ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specifies the orchestration mode for the virtual machine scale set.")]
        [PSArgumentCompleter("Uniform", "Flexible")]
        public string OrchestrationMode { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = SimpleParameterSet,
            HelpMessage = "Id of the capacity reservation Group that is used to allocate.")]
        [ResourceIdCompleter("Microsoft.Compute/capacityReservationGroups")]
        public string CapacityReservationGroupId { get; set; }

        [Parameter(
            Mandatory = false,
            ParameterSetName = SimpleParameterSet,
            HelpMessage = "Specified the gallery image unique id for vmss deployment. This can be fetched from gallery image GET call.")]
        [ResourceIdCompleter("Microsoft.Compute galleries/images/versions")]
        public string ImageReferenceId { get; set; }

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
           HelpMessage = "Specifies the SecurityType of the virtual machine. It has to be set to any specified value to enable UefiSettings. UefiSettings will not be enabled unless this property is set.",
           ParameterSetName = SimpleParameterSet,
           ValueFromPipelineByPropertyName = true,
           Mandatory = false)]
        [ValidateSet(ValidateSetValues.TrustedLaunch, ValidateSetValues.ConfidentialVM, ValidateSetValues.Standard, IgnoreCase = true)]
        [PSArgumentCompleter("TrustedLaunch", "ConfidentialVM", "Standard")]
        public string SecurityType { get; set; }

        [Parameter(
         HelpMessage = "Specifies whether vTPM should be enabled on the virtual machine.",
         ParameterSetName = SimpleParameterSet,
         ValueFromPipelineByPropertyName = true,
         Mandatory = false)]
        public bool? EnableVtpm { get; set; } = null;

        [Parameter(
           HelpMessage = "Specifies whether secure boot should be enabled on the virtual machine.",
           ParameterSetName = SimpleParameterSet,
           ValueFromPipelineByPropertyName = true,
           Mandatory = false)]
        public bool? EnableSecureBoot { get; set; } = null;

        const int FirstPortRangeStart = 50000;

        sealed class Parameters : IParameters<VirtualMachineScaleSet>
        {
            NewAzureRmVmss _cmdlet { get; }

            Client _client { get; }

            public Parameters(NewAzureRmVmss cmdlet, Client client)
            {
                _cmdlet = cmdlet;
                _client = client;
            }

            public string Location
            {
                get { return _cmdlet.Location; }
                set { _cmdlet.Location = value; }
            }

            public ImageAndOsType ImageAndOsType { get; set; }

            public string DefaultLocation => "eastus";
            
            public async Task<ResourceConfig<VirtualMachineScaleSet>> CreateConfigAsync()
            {
                if (_cmdlet.OrchestrationMode == uniformOrchestrationMode)
                {
                    return await SimpleParameterSetNormalMode();
                }
                else
                {
                    return await SimpleParameterSetOrchestrationModeFlexible();
                }
            }
            private async Task<ResourceConfig<VirtualMachineScaleSet>> SimpleParameterSetNormalMode()
            {
                ImageAndOsType = await _client.UpdateImageAndOsTypeAsync(
                        ImageAndOsType, _cmdlet.ResourceGroupName, _cmdlet.ImageName, Location);
               

                // generate a domain name label if it's not specified.
                _cmdlet.DomainNameLabel = await PublicIPAddressStrategy.UpdateDomainNameLabelAsync(
                    domainNameLabel: _cmdlet.DomainNameLabel,
                    name: _cmdlet.VMScaleSetName,
                    location: Location,
                    client: _client);

                var resourceGroup = ResourceGroupStrategy.CreateResourceGroupConfig(_cmdlet.ResourceGroupName);

                var noZones = _cmdlet.Zone == null || _cmdlet.Zone.Count == 0;

                var publicIpAddress = resourceGroup.CreatePublicIPAddressConfig(
                    name: _cmdlet.PublicIpAddressName,
                    edgeZone: _cmdlet.EdgeZone,
                    domainNameLabel: _cmdlet.DomainNameLabel,
                    allocationMethod: _cmdlet.AllocationMethod,
                    //sku.Basic is not compatible with multiple placement groups
                    sku: (noZones && _cmdlet.SinglePlacementGroup.IsPresent)
                        ? PublicIPAddressStrategy.Sku.Basic
                        : PublicIPAddressStrategy.Sku.Standard,
                    zones: null);

                var virtualNetwork = resourceGroup.CreateVirtualNetworkConfig(
                    name: _cmdlet.VirtualNetworkName,
                    edgeZone: _cmdlet.EdgeZone,
                    addressPrefix: _cmdlet.VnetAddressPrefix);

                var subnet = virtualNetwork.CreateSubnet(
                    _cmdlet.SubnetName, _cmdlet.SubnetAddressPrefix);

                var loadBalancer = resourceGroup.CreateLoadBalancerConfig(
                    name: _cmdlet.LoadBalancerName,
                    //sku.Basic is not compatible with multiple placement groups
                    sku: (noZones && _cmdlet.SinglePlacementGroup.IsPresent)
                        ? LoadBalancerStrategy.Sku.Basic
                        : LoadBalancerStrategy.Sku.Standard);

                var frontendIpConfiguration = loadBalancer.CreateFrontendIPConfiguration(
                    name: _cmdlet.FrontendPoolName,
                    publicIpAddress: publicIpAddress);

                var backendAddressPool = loadBalancer.CreateBackendAddressPool(
                    name: _cmdlet.BackendPoolName);

                if (_cmdlet.BackendPort != null)
                {
                    var loadBalancingRuleName = _cmdlet.LoadBalancerName;
                    foreach (var backendPort in _cmdlet.BackendPort)
                    {
                        loadBalancer.CreateLoadBalancingRule(
                            name: loadBalancingRuleName + backendPort.ToString(),
                            fronendIpConfiguration: frontendIpConfiguration,
                            backendAddressPool: backendAddressPool,
                            frontendPort: backendPort,
                            backendPort: backendPort);
                    }
                }

                _cmdlet.NatBackendPort = ImageAndOsType.UpdatePorts(_cmdlet.NatBackendPort);

                var inboundNatPoolName = _cmdlet.VMScaleSetName;
                var PortRangeSize = _cmdlet.InstanceCount * 2;

                var ports = _cmdlet
                    .NatBackendPort
                    ?.Select((port, i) => Tuple.Create(
                        port,
                        FirstPortRangeStart + i * 2000))
                    .ToList();

                var inboundNatPools = ports
                    ?.Select(p => loadBalancer.CreateInboundNatPool(
                        name: inboundNatPoolName + p.Item1.ToString(),
                        frontendIpConfiguration: frontendIpConfiguration,
                        frontendPortRangeStart: p.Item2,
                        frontendPortRangeEnd: p.Item2 + PortRangeSize,
                        backendPort: p.Item1))
                    .ToList();

                var networkSecurityGroup = noZones
                    ? null
                    : resourceGroup.CreateNetworkSecurityGroupConfig(
                        _cmdlet.VMScaleSetName,
                        _cmdlet.NatBackendPort.Concat(_cmdlet.BackendPort).ToList());

                var proximityPlacementGroup = resourceGroup.CreateProximityPlacementGroupSubResourceFunc(_cmdlet.ProximityPlacementGroupId);

                var hostGroup = resourceGroup.CreateDedicatedHostGroupSubResourceFunc(_cmdlet.HostGroupId);

                if (_cmdlet.IsParameterBound(c => c.UserData))
                {
                    if (!ValidateBase64EncodedString.ValidateStringIsBase64Encoded(_cmdlet.UserData))
                    {
                        _cmdlet.UserData = ValidateBase64EncodedString.EncodeStringToBase64(_cmdlet.UserData);
                        _cmdlet.WriteInformation(ValidateBase64EncodedString.UserDataEncodeNotification, new string[] { "PSHOST" });
                    }
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

                return resourceGroup.CreateVirtualMachineScaleSetConfig(
                    name: _cmdlet.VMScaleSetName,
                    subnet: subnet,
                    backendAdressPool: backendAddressPool,
                    inboundNatPools: inboundNatPools,
                    networkSecurityGroup: networkSecurityGroup,
                    imageAndOsType: ImageAndOsType,
                    adminUsername: _cmdlet.Credential.UserName,
                    adminPassword: new NetworkCredential(string.Empty, _cmdlet.Credential.Password).Password,
                    vmSize: _cmdlet.VmSize,
                    instanceCount: _cmdlet.InstanceCount,
                    upgradeMode: _cmdlet.MyInvocation.BoundParameters.ContainsKey(nameof(UpgradePolicyMode))
                        ? _cmdlet.UpgradePolicyMode
                        : (UpgradeMode?)null,
                    dataDisks: _cmdlet.DataDiskSizeInGb,
                    zones: _cmdlet.Zone,
                    ultraSSDEnabled: _cmdlet.EnableUltraSSD.IsPresent,
                    identity: _cmdlet.GetVmssIdentityFromArgs(),
                    singlePlacementGroup: _cmdlet.SinglePlacementGroup.IsPresent,
                    proximityPlacementGroup: proximityPlacementGroup,
                    hostGroup: hostGroup,
                    priority: _cmdlet.Priority,
                    evictionPolicy: _cmdlet.EvictionPolicy,
                    maxPrice: _cmdlet.IsParameterBound(c => c.MaxPrice) ? _cmdlet.MaxPrice : (double?)null,
                    scaleInPolicy: _cmdlet.ScaleInPolicy,
                    doNotRunExtensionsOnOverprovisionedVMs: _cmdlet.SkipExtensionsOnOverprovisionedVMs.IsPresent,
                    encryptionAtHost: _cmdlet.EncryptionAtHost.IsPresent,
                    platformFaultDomainCount: _cmdlet.IsParameterBound(c => c.PlatformFaultDomainCount) ? _cmdlet.PlatformFaultDomainCount : (int?)null,
                    edgeZone: _cmdlet.EdgeZone,
                    orchestrationMode: _cmdlet.IsParameterBound(c => c.OrchestrationMode) ? _cmdlet.OrchestrationMode : null,
                    capacityReservationId: _cmdlet.IsParameterBound(c => c.CapacityReservationGroupId) ? _cmdlet.CapacityReservationGroupId : null,
                    userData: _cmdlet.IsParameterBound(c => c.UserData) ? _cmdlet.UserData : null,
                    imageReferenceId: _cmdlet.IsParameterBound(c => c.ImageReferenceId) ? _cmdlet.ImageReferenceId : null,
                    auxAuthHeader: auxAuthHeader,
                    diskControllerType: _cmdlet.DiskControllerType,
                    sharedImageGalleryId: _cmdlet.IsParameterBound(c => c.SharedGalleryImageId) ? _cmdlet.SharedGalleryImageId : null,
                    securityType: _cmdlet.SecurityType,
                    enableVtpm: _cmdlet.EnableVtpm,
                    enableSecureBoot: _cmdlet.EnableSecureBoot
                    );
            }

            private async Task<ResourceConfig<VirtualMachineScaleSet>> SimpleParameterSetOrchestrationModeFlexible()
            {
                int platformFaultDomainCountFlexibleDefault = 1;

                ImageAndOsType = await _client.UpdateImageAndOsTypeAsync(
                        ImageAndOsType, _cmdlet.ResourceGroupName, _cmdlet.ImageName, Location);

                // generate a domain name label if it's not specified.
                _cmdlet.DomainNameLabel = await PublicIPAddressStrategy.UpdateDomainNameLabelAsync(
                    domainNameLabel: _cmdlet.DomainNameLabel,
                    name: _cmdlet.VMScaleSetName,
                    location: Location,
                    client: _client);

                var resourceGroup = ResourceGroupStrategy.CreateResourceGroupConfig(_cmdlet.ResourceGroupName);

                var noZones = _cmdlet.Zone == null || _cmdlet.Zone.Count == 0;

                var publicIpAddress = resourceGroup.CreatePublicIPAddressConfig(
                    name: _cmdlet.PublicIpAddressName,
                    edgeZone: _cmdlet.EdgeZone,
                    domainNameLabel: _cmdlet.DomainNameLabel,
                    allocationMethod: _cmdlet.AllocationMethod,
                    //sku.Basic is not compatible with multiple placement groups
                    sku: (noZones && _cmdlet.SinglePlacementGroup.IsPresent)
                        ? PublicIPAddressStrategy.Sku.Basic
                        : PublicIPAddressStrategy.Sku.Standard,
                    zones: null);

                var virtualNetwork = resourceGroup.CreateVirtualNetworkConfig(
                    name: _cmdlet.VirtualNetworkName,
                    edgeZone: _cmdlet.EdgeZone,
                    addressPrefix: _cmdlet.VnetAddressPrefix);

                var subnet = virtualNetwork.CreateSubnet(
                    _cmdlet.SubnetName, _cmdlet.SubnetAddressPrefix);

                var loadBalancer = resourceGroup.CreateLoadBalancerConfig(
                    name: _cmdlet.LoadBalancerName,
                    //sku.Basic is not compatible with multiple placement groups
                    sku: (noZones && _cmdlet.SinglePlacementGroup.IsPresent)
                        ? LoadBalancerStrategy.Sku.Basic
                        : LoadBalancerStrategy.Sku.Standard);

                var frontendIpConfiguration = loadBalancer.CreateFrontendIPConfiguration(
                    name: _cmdlet.FrontendPoolName,
                    publicIpAddress: publicIpAddress);

                var backendAddressPool = loadBalancer.CreateBackendAddressPool(
                    name: _cmdlet.BackendPoolName);

                if (_cmdlet.BackendPort != null)
                {
                    var loadBalancingRuleName = _cmdlet.LoadBalancerName;
                    foreach (var backendPort in _cmdlet.BackendPort)
                    {
                        loadBalancer.CreateLoadBalancingRule(
                            name: loadBalancingRuleName + backendPort.ToString(),
                            fronendIpConfiguration: frontendIpConfiguration,
                            backendAddressPool: backendAddressPool,
                            frontendPort: backendPort,
                            backendPort: backendPort);
                    }
                }
                
                if (_cmdlet.IsParameterBound(c => c.SecurityType)
                    && _cmdlet.SecurityType != null)
                {
                    if (_cmdlet.SecurityType?.ToLower() == ConstantValues.TrustedLaunchSecurityType || _cmdlet.SecurityType?.ToLower() == ConstantValues.ConfidentialVMSecurityType)
                    {
                        _cmdlet.SecurityType = _cmdlet.SecurityType;
                        _cmdlet.EnableVtpm = _cmdlet.EnableVtpm ?? true;
                        _cmdlet.EnableSecureBoot = _cmdlet.EnableSecureBoot ?? true;
                    }
                    else if (_cmdlet.SecurityType?.ToLower() == ConstantValues.StandardSecurityType)
                    {
                        _cmdlet.SecurityType = _cmdlet.SecurityType;
                    }
                }
                _cmdlet.NatBackendPort = ImageAndOsType.UpdatePorts(_cmdlet.NatBackendPort);

                var networkSecurityGroup = noZones
                    ? null
                    : resourceGroup.CreateNetworkSecurityGroupConfig(
                        _cmdlet.VMScaleSetName,
                        _cmdlet.NatBackendPort.Concat(_cmdlet.BackendPort).ToList());

                var proximityPlacementGroup = resourceGroup.CreateProximityPlacementGroupSubResourceFunc(_cmdlet.ProximityPlacementGroupId);

                var hostGroup = resourceGroup.CreateDedicatedHostGroupSubResourceFunc(_cmdlet.HostGroupId);

                return resourceGroup.CreateVirtualMachineScaleSetConfigOrchestrationModeFlexible(
                    name: _cmdlet.VMScaleSetName,
                    subnet: subnet,
                    backendAdressPool: backendAddressPool,
                    networkSecurityGroup: networkSecurityGroup,
                    imageAndOsType: ImageAndOsType,
                    adminUsername: _cmdlet.Credential.UserName,
                    adminPassword: new NetworkCredential(string.Empty, _cmdlet.Credential.Password).Password,
                    vmSize: _cmdlet.VmSize,
                    instanceCount: _cmdlet.InstanceCount,
                    dataDisks: _cmdlet.DataDiskSizeInGb,
                    zones: _cmdlet.Zone,
                    ultraSSDEnabled: _cmdlet.EnableUltraSSD.IsPresent,
                    identity: _cmdlet.GetVmssIdentityFromArgs(),
                    singlePlacementGroup: _cmdlet.SinglePlacementGroup == true,
                    proximityPlacementGroup: proximityPlacementGroup,
                    hostGroup: hostGroup,
                    priority: _cmdlet.Priority,
                    evictionPolicy: _cmdlet.EvictionPolicy,
                    maxPrice: _cmdlet.IsParameterBound(c => c.MaxPrice) ? _cmdlet.MaxPrice : (double?)null,
                    scaleInPolicy: _cmdlet.ScaleInPolicy,
                    doNotRunExtensionsOnOverprovisionedVMs: _cmdlet.SkipExtensionsOnOverprovisionedVMs.IsPresent,
                    encryptionAtHost: _cmdlet.EncryptionAtHost.IsPresent,
                    platformFaultDomainCount: _cmdlet.IsParameterBound(c => c.PlatformFaultDomainCount) ? _cmdlet.PlatformFaultDomainCount : platformFaultDomainCountFlexibleDefault,
                    edgeZone: _cmdlet.EdgeZone,
                    orchestrationMode: flexibleOrchestrationMode,
                    capacityReservationId: _cmdlet.IsParameterBound(c => c.CapacityReservationGroupId) ? _cmdlet.CapacityReservationGroupId : null,
                    securityType: _cmdlet.SecurityType,
                    enableVtpm: _cmdlet.EnableVtpm,
                    enableSecureBoot: _cmdlet.EnableSecureBoot
                    );
            }
        }
        
        async Task SimpleParameterSetExecuteCmdlet(IAsyncCmdlet asyncCmdlet)
        {
            bool loadBalancerNamePassedIn = !String.IsNullOrWhiteSpace(LoadBalancerName);

            ResourceGroupName = ResourceGroupName ?? VMScaleSetName;
            VirtualNetworkName = VirtualNetworkName ?? VMScaleSetName;
            SubnetName = SubnetName ?? VMScaleSetName;
            PublicIpAddressName = PublicIpAddressName ?? VMScaleSetName;
            SecurityGroupName = SecurityGroupName ?? VMScaleSetName;
            LoadBalancerName = LoadBalancerName ?? VMScaleSetName;
            FrontendPoolName = FrontendPoolName ?? VMScaleSetName;
            BackendPoolName = BackendPoolName ?? VMScaleSetName;

            var client = new Client(DefaultProfile.DefaultContext);

            // If the user did not specify a load balancer name, mark the LB setting to ignore
            // preexisting check. The most common scenario is users will let the cmdlet create and name the LB for them with the default
            // config. We do not want to block that scenario in case the cmdlet failed mid operation and tthe user kicks it off again.
            if (!loadBalancerNamePassedIn)
            {
                LoadBalancerStrategy.IgnorePreExistingConfigCheck = true;
            }
            else
            {
                LoadBalancerStrategy.IgnorePreExistingConfigCheck = false;
            }

            // TL default for Simple Param Set, no config object
            if (!this.IsParameterBound(c => c.SecurityType)
                && !this.IsParameterBound(c => c.ImageName)
                && !this.IsParameterBound(c => c.ImageReferenceId)
                && !this.IsParameterBound(c => c.SharedGalleryImageId))
            {
                this.SecurityType = ConstantValues.TrustedLaunchSecurityType;
                if (!this.IsParameterBound(c => c.ImageName) && !this.IsParameterBound(c => c.ImageReferenceId) && !this.IsParameterBound(c => c.SharedGalleryImageId))
                {
                    this.ImageName = ConstantValues.TrustedLaunchDefaultImageAlias;
                }
                if (!this.IsParameterBound(c => c.EnableSecureBoot))
                {
                    this.EnableSecureBoot = true;
                }
                if (!this.IsParameterBound(c => c.EnableVtpm))
                {
                    this.EnableVtpm = true;
                }
            }
            
            // API does not currently support Standard securityType value, so need to null it out here. 
            if (this.IsParameterBound(c => c.SecurityType)
                && this.SecurityType != null
                && this.SecurityType.ToString().ToLower() == ConstantValues.StandardSecurityType)
            {
                this.SecurityType = null;
            }

            //TrustedLaunch value defaulting for UEFI values.
            if (this.IsParameterBound(c => c.SecurityType))
            {
                if (this.SecurityType?.ToLower() == ConstantValues.TrustedLaunchSecurityType || this.SecurityType?.ToLower() == ConstantValues.ConfidentialVMSecurityType)
                {
                    this.SecurityType = this.SecurityType;
                    this.EnableVtpm = this.EnableVtpm ?? true;
                    this.EnableSecureBoot = this.EnableSecureBoot ?? true;
                }          
            }

            var parameters = new Parameters(this, client);

            if (parameters?.ImageAndOsType?.Image?.Version?.ToLower() != "latest")
            {
                WriteWarning("You are deploying VMSS pinned to a specific image version from Azure Marketplace. \n" +
                    "Consider using \"latest\" as the image version. This allows VMSS to auto upgrade when a newer version is available.");
            }

            var result = await client.RunAsync(client.SubscriptionId, parameters, asyncCmdlet);


            if (result != null)
            {
                var fqdn = PublicIPAddressStrategy.Fqdn(DomainNameLabel, Location);

                var psObject = new PSVirtualMachineScaleSet();
                ComputeAutomationAutoMapperProfile.Mapper.Map(result, psObject);
                psObject.FullyQualifiedDomainName = fqdn;

                var port = "<port>";
                var connectionString = parameters.ImageAndOsType.GetConnectionString(
                    fqdn,
                    Credential.UserName,
                    port);
                var range =
                    FirstPortRangeStart.ToString() +
                    ".." +
                    (FirstPortRangeStart + InstanceCount * 2 - 1).ToString();

                asyncCmdlet.WriteVerbose(
                    Resources.VmssUseConnectionString,
                    connectionString);
                asyncCmdlet.WriteVerbose(
                    Resources.VmssPortRange,
                    port, 
                    range);
                asyncCmdlet.WriteObject(psObject);
            }
        }
        
        /// <summary>
        /// Heres whats happening here :
        /// If "SystemAssignedIdentity" and "UserAssignedIdentity" are both present we set the type of identity to be SystemAssignedUsrAssigned and set the user 
        /// defined identity in the VMSS identity object.
        /// If only "SystemAssignedIdentity" is present, we just set the type of the Identity to "SystemAssigned" and no identity ids are set as its created by Azure
        /// If only "UserAssignedIdentity" is present, we set the type of the Identity to be "UserAssigned" and set the Identity in the VMSS identity object.
        /// If neither is present, we return a null.
        /// </summary>
        /// <returns>Returning the Identity generated form the cmdlet parameters "SystemAssignedIdentity" and "UserAssignedIdentity"</returns>
        private VirtualMachineScaleSetIdentity GetVmssIdentityFromArgs()
        {
            var isUserAssignedEnabled = !string.IsNullOrWhiteSpace(UserAssignedIdentity);
            return (SystemAssignedIdentity.IsPresent || isUserAssignedEnabled)
                ? new VirtualMachineScaleSetIdentity
                {
                    Type = !isUserAssignedEnabled ?
                           ResourceIdentityType.SystemAssigned :
                           (SystemAssignedIdentity.IsPresent ? ResourceIdentityType.SystemAssignedUserAssigned : ResourceIdentityType.UserAssigned),
                    UserAssignedIdentities = isUserAssignedEnabled 
                                             ? new Dictionary<string, UserAssignedIdentitiesValue>()
                                             {
                                                 { UserAssignedIdentity, new UserAssignedIdentitiesValue()}
                                             }
                                             : null,
                }
                : null;
        }
    }
}
