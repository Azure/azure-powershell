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

using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Commands.Common.Strategies;
using Microsoft.Azure.Commands.Compute.Strategies;
using Microsoft.Azure.Commands.Compute.Strategies.ComputeRp;
using Microsoft.Azure.Commands.Compute.Strategies.Network;
using Microsoft.Azure.Commands.Compute.Strategies.ResourceManager;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;
using Microsoft.Azure.Management.Internal.Network.Version2017_10_01;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301;
using Microsoft.Azure.Commands.Compute.Common;
using System;
using System.Collections;
using System.Linq;
using System.Management.Automation;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using Microsoft.Azure.PowerShell.Cmdlets.Compute.Strategies;

namespace Microsoft.Azure.Commands.Compute
{
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "VM_SimpleParameterSet", SupportsShouldProcess = true, DefaultParameterSetName = "SimpleParameterSet")]
    [OutputType(typeof(Microsoft.Azure.PowerShell.Cmdlets.Compute.Models.Api20190301.VirtualMachine))]
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.Profile("latest-2019-04-30")]
    public class NewAzVM_SimpleParameterSet: AzureRMAsyncCmdlet
    {
        public const string SimpleParameterSet = "SimpleParameterSet";

        //[ResourceGroupCompleter]
        [Parameter(
            Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(
            Mandatory = false)]
        [LocationCompleter("Microsoft.Compute/virtualMachines")]
        [ValidateNotNullOrEmpty]
        public string Location { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateNotNullOrEmpty]
        public string[] Zone { get; set; }

        [Parameter(
            Mandatory = false)]
        public Hashtable Tag { get; set; }

        [Parameter(
            Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Mandatory = true)]
        public PSCredential Credential { get; set; }

        [Parameter(Mandatory = false)]
        public string VirtualNetworkName { get; set; }

        [Parameter(Mandatory = false)]
        public string AddressPrefix { get; set; } = "192.168.0.0/16";

        [Parameter(Mandatory = false)]
        public string SubnetName { get; set; }

        [Parameter(Mandatory = false)]
        public string SubnetAddressPrefix { get; set; } = "192.168.1.0/24";

        [Parameter(Mandatory = false)]
        public string PublicIpAddressName { get; set; }

        [Parameter(Mandatory = false)]
        public string DomainNameLabel { get; set; }

        [Parameter(Mandatory = false)]
        [ValidateSet("Static", "Dynamic")]
        public string AllocationMethod { get; set; } = "Static";

        [Parameter(Mandatory = false)]
        public string SecurityGroupName { get; set; }

        [Parameter(Mandatory = false)]
        public int[] OpenPort { get; set; }

        [Parameter(Mandatory = false)]
        [System.Management.Automation.ArgumentCompleter(typeof(Microsoft.Azure.PowerShell.Cmdlets.Compute.ImageName))]
        [Alias("ImageName")]
        public Microsoft.Azure.PowerShell.Cmdlets.Compute.ImageName Image { get; set; } = "Win2016Datacenter";

        [Parameter(Mandatory = false)]
        public string Size { get; set; } = "Standard_DS1_v2";

        [Parameter(Mandatory = false)]
        public string AvailabilitySetName { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Use this to add system assigned identity (MSI) to the vm")]
        public SwitchParameter SystemAssignedIdentity { get; set; }

        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        [Parameter(Mandatory = false)]
        public int[] DataDiskSizeInGb { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter EnableUltraSSD { get; set; }

        [Parameter(Mandatory = false)]
        public string ProximityPlacementGroup { get; set; }

        public CancellationToken Token => Source.Token;

        public Action Cancel => Source.Cancel;

        protected override void StopProcessing()
        {
            this.Cancel();
            base.StopProcessing();
        }

        public override void ExecuteCmdlet()
        {
            base.ExecuteCmdlet();
            this.StartAndWait(StrategyExecuteCmdletAsync);
        }

        class Parameters : IParameters<VirtualMachine>
        {
            readonly NewAzVM_SimpleParameterSet _cmdlet;

            readonly Client _client;

            readonly IResourceManagementClient _resourceClient;

            public Parameters(NewAzVM_SimpleParameterSet cmdlet, Client client, IResourceManagementClient resourceClient)
            {
                _cmdlet = cmdlet;
                _client = client;
                _resourceClient = resourceClient;
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
                            var availableLocations = vmResourceType.Locations.Select(a => a.ToLower().Replace(" ", "").Replace("-", ""));
                            if (availableLocations.Any(a => a.Equals("eastus")))
                            {
                                _defaultLocation = "eastus";
                            }
                            else
                            {
                                _defaultLocation = availableLocations.FirstOrDefault() ?? "eastus";
                            }
                        }
                        else
                        {
                            _defaultLocation = "eastus";
                        }
                    }
                    return _defaultLocation;
                }
            }


            public async Task<ResourceConfig<VirtualMachine>> CreateConfigAsync()
            {
                ImageAndOsType = await _client.UpdateImageAndOsTypeAsync(
                    ImageAndOsType, _cmdlet.ResourceGroupName, _cmdlet.Image, Location);

                _cmdlet.DomainNameLabel = await PublicIPAddressStrategy.UpdateDomainNameLabelAsync(
                    domainNameLabel: _cmdlet.DomainNameLabel,
                    name: _cmdlet.Name,
                    location: Location,
                    client: _client);

                var resourceGroup = ResourceGroupStrategy.CreateResourceGroupConfig(_cmdlet.ResourceGroupName);
                var virtualNetwork = resourceGroup.CreateVirtualNetworkConfig(
                    name: _cmdlet.VirtualNetworkName, addressPrefix: _cmdlet.AddressPrefix);
                var subnet = virtualNetwork.CreateSubnet(_cmdlet.SubnetName, _cmdlet.SubnetAddressPrefix);
                var publicIpAddress = resourceGroup.CreatePublicIPAddressConfig(
                    name: _cmdlet.PublicIpAddressName,
                    domainNameLabel: _cmdlet.DomainNameLabel,
                    allocationMethod: _cmdlet.AllocationMethod,
                    sku: PublicIPAddressStrategy.Sku.Basic,
                    zones: _cmdlet.Zone);

                _cmdlet.OpenPort = ImageAndOsType.UpdatePorts(_cmdlet.OpenPort);

                var networkSecurityGroup = resourceGroup.CreateNetworkSecurityGroupConfig(
                    name: _cmdlet.SecurityGroupName,
                    openPorts: _cmdlet.OpenPort);

                bool enableAcceleratedNetwork = Utils.DoesConfigSupportAcceleratedNetwork(_client,
                    ImageAndOsType, _cmdlet.Size, Location, DefaultLocation);

                var networkInterface = resourceGroup.CreateNetworkInterfaceConfig(
                    _cmdlet.Name, subnet, publicIpAddress, networkSecurityGroup, enableAcceleratedNetwork);

                var ppgSubResourceFunc = resourceGroup.CreateProximityPlacementGroupSubResourceFunc(_cmdlet.ProximityPlacementGroup);

                var availabilitySet = _cmdlet.AvailabilitySetName == null
                    ? null
                    : resourceGroup.CreateAvailabilitySetConfig(
                        name: _cmdlet.AvailabilitySetName,
                        proximityPlacementGroup: ppgSubResourceFunc);

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
                    ultraSSDEnabled: _cmdlet.EnableUltraSSD.IsPresent,
                    identity: _cmdlet.GetVMIdentityFromArgs(),
                    proximityPlacementGroup: ppgSubResourceFunc);
            }
        }

        async Task StrategyExecuteCmdletAsync(IAsyncCmdlet asyncCmdlet)
        {
            var client = new Client(this, asyncCmdlet);

            ResourceGroupName = ResourceGroupName ?? Name;
            VirtualNetworkName = VirtualNetworkName ?? Name;
            SubnetName = SubnetName ?? Name;
            PublicIpAddressName = PublicIpAddressName ?? Name;
            SecurityGroupName = SecurityGroupName ?? Name;

            var resourceClient = AzureSession.Instance.ClientFactory.CreateArmClient<ResourceManagementClient>(
                    DefaultProfile.DefaultContext,
                    AzureEnvironment.Endpoint.ResourceManager);
            var parameters = new Parameters(this, client, resourceClient);
            var result = await client.RunAsync(SubscriptionId, parameters, asyncCmdlet);
            if (result != null)
            {
                var fqdn = PublicIPAddressStrategy.Fqdn(DomainNameLabel, Location);
                var psResult = result;
                psResult.OSProfileComputerName = fqdn;
                var connectionString = parameters.ImageAndOsType.GetConnectionString(
                    fqdn,
                    Credential?.UserName);
                asyncCmdlet.WriteVerbose(
                    Microsoft.Azure.PowerShell.Cmdlets.Compute.Resources.VirtualMachineUseConnectionString,
                    connectionString);
                asyncCmdlet.WriteObject(psResult);
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
            VirtualMachineIdentity identity = null;

            if (this.IsParameterBound(c => c.SystemAssignedIdentity))
            {
                identity = new VirtualMachineIdentity();
                identity.Type = Microsoft.Azure.PowerShell.Cmdlets.Compute.Support.ResourceIdentityType.SystemAssigned;
            }

            // ToDO: Add support for User-Assigned identities
            return identity;
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

    }
}
