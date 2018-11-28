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
using Microsoft.Azure.Commands.Compute.Automation.Models;
using Microsoft.Azure.Commands.Compute.Properties;
using Microsoft.Azure.Commands.Compute.Strategies;
using Microsoft.Azure.Commands.Compute.Strategies.ComputeRp;
using Microsoft.Azure.Commands.Compute.Strategies.Network;
using Microsoft.Azure.Commands.Compute.Strategies.ResourceManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    public partial class NewAzureRmVmss : ComputeAutomationBaseCmdlet
    {
        // SimpleParameterSet
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
            "Win10")]
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
                    domainNameLabel: _cmdlet.DomainNameLabel,
                    allocationMethod: _cmdlet.AllocationMethod,
                    //sku.Basic is not compatible with multiple placement groups
                    sku: (noZones && _cmdlet.SinglePlacementGroup.IsPresent)
                        ? PublicIPAddressStrategy.Sku.Basic
                        : PublicIPAddressStrategy.Sku.Standard,
                    zones: null);

                var virtualNetwork = resourceGroup.CreateVirtualNetworkConfig(
                    name: _cmdlet.VirtualNetworkName,
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
                    ultraSSDEnabled : _cmdlet.EnableUltraSSD.IsPresent,
                    identity: _cmdlet.GetVmssIdentityFromArgs(),
                    singlePlacementGroup : _cmdlet.SinglePlacementGroup.IsPresent);
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

            var parameters = new Parameters(this, client);

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
                                             ? new Dictionary<string, VirtualMachineScaleSetIdentityUserAssignedIdentitiesValue>()
                                             {
                                                 { UserAssignedIdentity, new VirtualMachineScaleSetIdentityUserAssignedIdentitiesValue()}
                                             }
                                             : null,
                }
                : null;
        }
    }
}
