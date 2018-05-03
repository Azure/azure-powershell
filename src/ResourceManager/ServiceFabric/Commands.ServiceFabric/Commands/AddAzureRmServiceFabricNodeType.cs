// ----------------------------------------------------------------------------------
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
using System.Security;
using System.Threading.Tasks;
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Internal.Resources;
using Microsoft.Azure.Management.ServiceFabric.Models;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.WindowsAzure.Commands.Common;
using Newtonsoft.Json.Linq;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;
using System.Text;
using Microsoft.Azure.Commands.ResourceManager.Common.ArgumentCompleters;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Add, CmdletNoun.AzureRmServiceFabricNodeType, SupportsShouldProcess = true), OutputType(typeof(PSCluster))]
    public class AddAzureRmServiceFabricNodeType : ServiceFabricNodeTypeCmdletBase
    {
        private const string LoadBalancerIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/loadBalancers/{2}";
        private const string BackendAddressIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/loadBalancers/{2}/backendAddressPools/{3}";
        private const string FrontendIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/loadBalancers/{2}/frontendIPConfigurations/{3}";
        private const string ProbeIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/loadBalancers/{2}/probes/{3}";
        private readonly HashSet<string> skusSupportGoldDurability =
         new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "Standard_D15_v2", "Standard_G5" };

        private string sku;
        private string diagnosticsStorageName;
        private string addressPrefix;

        //For testing
        internal static bool dontRandom = false;

        /// <summary>
        /// Resource group name
        /// </summary>
        [Parameter(Mandatory = true, Position = 0, ValueFromPipelineByPropertyName = true,
            HelpMessage = "Specify the name of the resource group.")]
        [ResourceGroupCompleter]
        [ValidateNotNullOrEmpty()]
        public override string ResourceGroupName { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Specify the name of the cluster")]
        [ValidateNotNullOrEmpty()]
        [Alias("ClusterName")]
        public override string Name { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true,
                   HelpMessage = "Capacity")]
        [ValidateRange(1, 99)]  
        public int Capacity { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true,
                   HelpMessage = "The user name for logging to Vm")]
        [ValidateNotNullOrEmpty()]
        public string VmUserName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipeline = true,
                   HelpMessage = "The password for login to the Vm")]
        [ValidateNotNullOrEmpty()]
        public SecureString VmPassword { get; set; }

        [Parameter(Mandatory = false, ValueFromPipeline = true,
                   HelpMessage = "The sku name")]
        [ValidateNotNullOrEmpty()]
        public string VmSku
        {
            get { return string.IsNullOrWhiteSpace(this.sku) ? Constants.DefaultSku : this.sku; }
            set { this.sku = value; }
        }

        private string tier;
        [Parameter(Mandatory = false, ValueFromPipeline = true,
                   HelpMessage = "Vm Sku Tier")]
        [ValidateNotNullOrEmpty()]
        public string Tier
        {
            get { return string.IsNullOrWhiteSpace(this.tier) ? Constants.DefaultTier : this.tier; }
            set { this.tier = value; }
        }

        [Parameter(Mandatory = false, ValueFromPipeline = true,
                   HelpMessage = "Specify the durability level of the NodeType.")]
        [ValidateNotNullOrEmpty()]
        public DurabilityLevel DurabilityLevel { get; set; } = DurabilityLevel.Bronze;

        public override void ExecuteCmdlet()
        {
            if (this.DurabilityLevel == DurabilityLevel.Gold && !skusSupportGoldDurability.Contains(this.VmSku))
            {
                throw new PSArgumentException(
                    string.Format(
                        ServiceFabricProperties.Resources.UnsupportedVmSkuForGold,
                        string.Join(" / ", skusSupportGoldDurability)));
            }

            if (ShouldProcess(target: this.NodeType, action: string.Format("Add an new node type {0}", this.NodeType)))
            {
                var cluster = GetCurrentCluster();
                this.diagnosticsStorageName = cluster.DiagnosticsStorageAccountConfig.StorageAccountName;
                CreateVmss();
                var pscluster = AddNodeTypeToSfrp(cluster);
                WriteObject(pscluster, true);
            }
        }

        private PSCluster AddNodeTypeToSfrp(Cluster cluster)
        {
            if (cluster.NodeTypes == null)
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.NoneNodeTypeFound,
                        this.ResourceGroupName));
            }

            var existingNodeType = GetNodeType(cluster, this.NodeType, ignoreErrors:true);
            if (existingNodeType != null)
            {
                return new PSCluster(cluster);
            }

            cluster.NodeTypes.Add(new Management.ServiceFabric.Models.NodeTypeDescription()
            {
                Name = this.NodeType,
                ApplicationPorts = new Management.ServiceFabric.Models.EndpointRangeDescription()
                {
                    StartPort = Constants.DefaultApplicationStartPort,
                    EndPort = Constants.DefaultApplicationEndPort
                },
                ClientConnectionEndpointPort = Constants.DefaultClientConnectionEndpoint,
                DurabilityLevel = this.DurabilityLevel.ToString(),
                EphemeralPorts = new Management.ServiceFabric.Models.EndpointRangeDescription()
                {
                    StartPort = Constants.DefaultEphemeralStart,
                    EndPort = Constants.DefaultEphemeralEnd
                },
                HttpGatewayEndpointPort = Constants.DefaultHttpGatewayEndpoint,
                IsPrimary = false,
                VmInstanceCount = this.Capacity
            });

            return SendPatchRequest(new Management.ServiceFabric.Models.ClusterUpdateParameters()
            {
                NodeTypes = cluster.NodeTypes
            });
        }

        private void CreateVmss()
        {
            VirtualMachineScaleSetExtensionProfile vmExtProfile;
            VirtualMachineScaleSetOSProfile osProfile;
            VirtualMachineScaleSetStorageProfile storageProfile;
            VirtualMachineScaleSetNetworkProfile networkProfile;

            GetProfiles(out vmExtProfile, out osProfile, out storageProfile, out networkProfile);

            var virtualMachineScaleSetProfile = new VirtualMachineScaleSetVMProfile()
            {
                ExtensionProfile = vmExtProfile,
                OsProfile = osProfile,
                StorageProfile = storageProfile,
                NetworkProfile = networkProfile
            };

            virtualMachineScaleSetProfile.Validate();

            var vmssTask = ComputeClient.VirtualMachineScaleSets.CreateOrUpdateAsync(
                 this.ResourceGroupName,
                 this.NodeType,
                 new VirtualMachineScaleSet()
                 {
                     Location = GetLocation(),
                     Sku = new Management.Compute.Models.Sku(this.VmSku, this.Tier, this.Capacity),
                     Overprovision = false,
                     Tags = GetServiceFabricTags(),
                     UpgradePolicy = new UpgradePolicy()
                     {
                         Mode = UpgradeMode.Automatic
                     },
                     VirtualMachineProfile = virtualMachineScaleSetProfile
                 });

            WriteClusterAndVmssVerboseWhenUpdate(new List<Task>() { vmssTask }, false, this.NodeType);
        }

        private string GetLocation()
        {
            return this.ResourcesClient.ResourceGroups.Get(this.ResourceGroupName).Location;
        }

        private void GetProfiles(
            out VirtualMachineScaleSetExtensionProfile vmExtProfile,
            out VirtualMachineScaleSetOSProfile osProfile,
            out VirtualMachineScaleSetStorageProfile storageProfile,
            out VirtualMachineScaleSetNetworkProfile networkProfile)
        {
            vmExtProfile = null;
            osProfile = null;
            storageProfile = null;
            networkProfile = null;

            VirtualMachineScaleSetExtension existingFabricExtension = null;
            VirtualMachineScaleSetExtension diagnosticsVmExt = null;

            VirtualMachineScaleSetStorageProfile existingStorageProfile = null;
            VirtualMachineScaleSetNetworkProfile existingNetworkProfile = null;
            var vmss = ComputeClient.VirtualMachineScaleSets.List(this.ResourceGroupName);
            if (vmss != null)
            {
                foreach (var vm in vmss)
                {
                    var ext = vm.VirtualMachineProfile.ExtensionProfile.Extensions.FirstOrDefault(
                        e =>
                        string.Equals(
                            e.Type,
                            Constants.ServiceFabricWindowsNodeExtName,
                            StringComparison.OrdinalIgnoreCase));

                    // Try to get Linux ext
                    if (ext == null)
                    {
                        ext = vm.VirtualMachineProfile.ExtensionProfile.Extensions.FirstOrDefault(
                            e =>
                            e.Type.Equals(
                                Constants.ServiceFabricLinuxNodeExtName,
                                StringComparison.OrdinalIgnoreCase));
                    }

                    if (ext != null)
                    {
                        existingFabricExtension = ext;
                        osProfile = vm.VirtualMachineProfile.OsProfile;
                        existingStorageProfile = vm.VirtualMachineProfile.StorageProfile;
                        existingNetworkProfile = vm.VirtualMachineProfile.NetworkProfile;
                    }

                    ext = vm.VirtualMachineProfile.ExtensionProfile.Extensions.FirstOrDefault(
                        e =>
                        e.Type.Equals(Constants.IaaSDiagnostics, StringComparison.OrdinalIgnoreCase));

                    if (ext != null)
                    {
                        diagnosticsVmExt = ext;
                        break;
                    }
                }
            }

            if (existingFabricExtension == null || existingStorageProfile == null || existingNetworkProfile == null)
            {
                throw new InvalidOperationException(ServiceFabricProperties.Resources.VmExtensionNotFound);
            }

            osProfile = GetOsProfile(osProfile);
            storageProfile = GetStorageProfile(existingStorageProfile);
            networkProfile = CreateNetworkResource(existingNetworkProfile.NetworkInterfaceConfigurations.FirstOrDefault());

            existingFabricExtension.Name = string.Format("{0}_ServiceFabricNode", this.NodeType);
            existingFabricExtension = GetFabricExtension(existingFabricExtension);

            if (diagnosticsVmExt != null)
            {
                diagnosticsVmExt.Name = string.Format("{0}_VMDiagnosticsVmExt", this.NodeType);
                diagnosticsVmExt = GetDiagnosticsExtension(diagnosticsVmExt);
                vmExtProfile = new VirtualMachineScaleSetExtensionProfile()
                {
                    Extensions = new[] { existingFabricExtension, diagnosticsVmExt }
                };
            }
            else
            {
                vmExtProfile = new VirtualMachineScaleSetExtensionProfile()
                {
                    Extensions = new[] { existingFabricExtension }
                };
            }
        }

        private VirtualMachineScaleSetOSProfile GetOsProfile(VirtualMachineScaleSetOSProfile osProfile)
        {
            osProfile.ComputerNamePrefix = this.NodeType;
            osProfile.AdminPassword = this.VmPassword.ConvertToString();
            osProfile.AdminUsername = this.VmUserName;
            return osProfile;
        }

        private VirtualMachineScaleSetExtension GetFabricExtension(VirtualMachineScaleSetExtension fabricExtension)
        {
            var settings = fabricExtension.Settings as JObject;
            if (settings == null)
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.InvalidVmssConfiguration);
            }

            settings["nodeTypeRef"] = this.NodeType;
            settings["durabilityLevel"] = this.DurabilityLevel.ToString();

            if (settings["nicPrefixOverride"] != null)
            {
                settings["nicPrefixOverride"] = this.addressPrefix;
            }

            var keys = GetStorageAccountKey(this.diagnosticsStorageName);

            var protectedSettings = new JObject
            {
                ["StorageAccountKey1"] = keys[0],
                ["StorageAccountKey2"] = keys[1]
            };

            fabricExtension.ProtectedSettings = protectedSettings;
            return fabricExtension;
        }

        private VirtualMachineScaleSetExtension GetDiagnosticsExtension(VirtualMachineScaleSetExtension diagnosticsExtension)
        {
            var settings = diagnosticsExtension.Settings as JObject;

            if (settings == null)
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.InvalidVmssConfiguration);
            }

            var accountName = settings.GetValue("StorageAccount", StringComparison.OrdinalIgnoreCase)?.Value<string>();
            if (accountName == null)
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.InvalidVmssConfiguration);
            }

            var protectedSettings = new JObject
            {
                ["storageAccountName"] = accountName,
                ["storageAccountKey"] = GetStorageAccountKey((string)accountName).First(),
                ["storageAccountEndPoint"] = "https://core.windows.net/"
            };

            diagnosticsExtension.ProtectedSettings = protectedSettings;
            return diagnosticsExtension;
        }

        private List<string> GetStorageAccountKey(string accoutName)
        {
            var keys = this.StorageManagementClient.StorageAccounts.ListKeys(this.ResourceGroupName, accoutName);
            return new List<string>() { keys.Keys.ElementAt(0).Value, keys.Keys.ElementAt(1).Value };
        }

        private VirtualMachineScaleSetStorageProfile GetStorageProfile(VirtualMachineScaleSetStorageProfile existingProfile)
        {
            var storageType = existingProfile.OsDisk.ManagedDisk != null
                ? existingProfile.OsDisk.ManagedDisk.StorageAccountType
                : StorageAccountTypes.StandardLRS;

            var osDisk = new VirtualMachineScaleSetOSDisk()
            {
                Caching = existingProfile.OsDisk.Caching,
                OsType = existingProfile.OsDisk.OsType,
                CreateOption = existingProfile.OsDisk.CreateOption,
                ManagedDisk = new VirtualMachineScaleSetManagedDiskParameters()
                {
                    StorageAccountType = storageType
                }
            };

            return new VirtualMachineScaleSetStorageProfile()
            {
                ImageReference = existingProfile.ImageReference,
                OsDisk = osDisk
            };
        }

        private VirtualMachineScaleSetNetworkProfile CreateNetworkResource(VirtualMachineScaleSetNetworkConfiguration existingNetworkConfig)
        {
            var suffix = $"{this.Name.ToLower()}-{this.NodeType.ToLower()}";
            var publicAddressName = $"LBIP-{suffix}";
            var dnsLabel = $"dns-{suffix}";
            var lbName = $"LB-{suffix}";
            var nicName = $"NIC-{suffix}";
            var ipconfigName = $"IpCfg-{suffix}";

            var ipConfiguration = existingNetworkConfig.IpConfigurations.FirstOrDefault();

            if (ipConfiguration == null)
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.InvalidVmssNetworkConfiguration);
            }

            this.addressPrefix = GetSubnetAddressPrefix(ipConfiguration);

            var publicIp = NetworkManagementClient.PublicIPAddresses.CreateOrUpdate(
                this.ResourceGroupName,
                publicAddressName,
                new PublicIPAddress()
                {
                    PublicIPAllocationMethod = "Dynamic",
                    Location = GetLocation(),
                    DnsSettings = new PublicIPAddressDnsSettings(dnsLabel)
                });

            var backendAddressPoolName = "LoadBalancerBEAddressPool";
            var frontendIpConfigurationName = "LoadBalancerIPConfig";
            var probeName = "FabricGatewayProbe";
            var probeHTTPName = "FabricHttpGatewayProbe";
            var inboundNatPoolName = "LoadBalancerBEAddressNatPool";

            var newLoadBalancerId = string.Format(
                LoadBalancerIdFormat,
                this.NetworkManagementClient.SubscriptionId,
                this.ResourceGroupName,
                lbName);

            var newLoadBalancer = new LoadBalancer(newLoadBalancerId, lbName)
            {
                Location = GetLocation(),
                FrontendIPConfigurations = new List<FrontendIPConfiguration>()
                {
                    new FrontendIPConfiguration()
                    {
                        Name= frontendIpConfigurationName,
                        PublicIPAddress = new PublicIPAddress()
                        {
                            Id = publicIp.Id
                        }
                    }
                },
                BackendAddressPools = new List<BackendAddressPool>()
                {
                    new BackendAddressPool()
                    {
                        Name = backendAddressPoolName
                    }
                },
                LoadBalancingRules = new List<LoadBalancingRule>()
                {
                    new LoadBalancingRule()
                    {
                        Name = "LBRule",
                        BackendAddressPool = new Management.Network.Models.SubResource()
                        {
                           Id = string.Format(
                               BackendAddressIdFormat,
                               NetworkManagementClient.SubscriptionId,
                               this.ResourceGroupName,
                               lbName,
                               backendAddressPoolName)
                        },
                        BackendPort = Constants.DefaultTcpPort,
                        EnableFloatingIP = false,
                        FrontendIPConfiguration = new Management.Network.Models.SubResource()
                        {
                            Id = string.Format(
                                FrontendIdFormat,
                                NetworkManagementClient.SubscriptionId,
                                this.ResourceGroupName,
                                lbName,
                                frontendIpConfigurationName)
                        },
                       FrontendPort = Constants.DefaultTcpPort,
                       IdleTimeoutInMinutes = 5,
                       Protocol = "tcp",
                       Probe = new Management.Network.Models.SubResource()
                       {
                           Id = string.Format(
                                ProbeIdFormat,
                                NetworkManagementClient.SubscriptionId,
                                this.ResourceGroupName,
                                lbName,
                                probeName)
                       }
                    },
                    new LoadBalancingRule()
                    {
                        Name = "LBHttpRule",
                        BackendAddressPool = new Management.Network.Models.SubResource()
                        {
                           Id = string.Format(
                               BackendAddressIdFormat,
                               NetworkManagementClient.SubscriptionId,
                               this.ResourceGroupName,
                               lbName,
                               backendAddressPoolName)
                        },
                        BackendPort = Constants.DefaultHttpPort,
                        EnableFloatingIP = false,
                        FrontendIPConfiguration = new Management.Network.Models.SubResource()
                        {
                            Id = string.Format(
                                FrontendIdFormat,
                                NetworkManagementClient.SubscriptionId,
                                this.ResourceGroupName,
                                lbName,
                                frontendIpConfigurationName)
                        },
                        FrontendPort = Constants.DefaultHttpPort,
                        IdleTimeoutInMinutes = 5,
                        Protocol = "tcp",
                        Probe = new Management.Network.Models.SubResource()
                        {
                           Id = string.Format(
                                ProbeIdFormat,
                                NetworkManagementClient.SubscriptionId,
                                this.ResourceGroupName,
                                lbName,
                                probeHTTPName)
                       }
                    }
                },
                Probes = new List<Probe>()
                {
                    new Probe()
                    {
                        Name = probeName,
                        IntervalInSeconds = 5,
                        NumberOfProbes = 2,
                        Port= Constants.DefaultTcpPort
                    },
                    new Probe()
                    {
                        Name = probeHTTPName,
                        IntervalInSeconds = 5,
                        NumberOfProbes = 2,
                        Port= Constants.DefaultHttpPort
                    },
                },
                InboundNatPools = new List<InboundNatPool>()
                {
                    new InboundNatPool()
                    {
                        Name = inboundNatPoolName,
                        BackendPort = Constants.DefaultBackendPort,
                        FrontendIPConfiguration = new Management.Network.Models.SubResource()
                        {
                             Id = string.Format(
                                FrontendIdFormat,
                                NetworkManagementClient.SubscriptionId,
                                this.ResourceGroupName,
                                lbName,
                                frontendIpConfigurationName)
                        },
                        FrontendPortRangeStart = Constants.DefaultFrontendPortRangeStart,
                        FrontendPortRangeEnd = Constants.DefaultFrontendPortRangeEnd,
                        Protocol = "tcp"
                    }
                }
            };

            NetworkManagementClient.LoadBalancers.BeginCreateOrUpdate(
                this.ResourceGroupName,
                lbName,
                newLoadBalancer);

            newLoadBalancer = NetworkManagementClient.LoadBalancers.Get(this.ResourceGroupName, lbName);

            return new VirtualMachineScaleSetNetworkProfile()
            {
                NetworkInterfaceConfigurations = new List<VirtualMachineScaleSetNetworkConfiguration>()
                {
                    new VirtualMachineScaleSetNetworkConfiguration()
                    {
                        IpConfigurations = new List<VirtualMachineScaleSetIPConfiguration>()
                        {
                            new VirtualMachineScaleSetIPConfiguration()
                            {
                                Name = ipconfigName,
                                LoadBalancerBackendAddressPools = newLoadBalancer.BackendAddressPools.Select(
                                    b => new Management.Compute.Models.SubResource()
                                    {
                                        Id = b.Id
                                    }
                                    ).ToList(),

                                LoadBalancerInboundNatPools = newLoadBalancer.InboundNatPools.Select(
                                    p => new Management.Compute.Models.SubResource()
                                    {
                                        Id = p.Id
                                    }
                                    ).ToList(),
                                Subnet = new ApiEntityReference() {Id = ipConfiguration.Subnet.Id}
                            }
                        },
                        Name = nicName,
                        Primary = true
                    }
                }
            };
        }

        private string GetSubnetAddressPrefix(VirtualMachineScaleSetIPConfiguration ipConfiguration)
        {
            if (ipConfiguration?.Subnet == null)
            {
                throw new InvalidOperationException(ServiceFabricProperties.Resources.InvalidVmssIpConfiguration);
            }

            var subnetId = ipConfiguration.Subnet.Id;
            var segments = subnetId.Split('/');
            if (!segments[segments.Length - 2].Equals("subnets", StringComparison.OrdinalIgnoreCase) || 
                !segments[segments.Length - 4].Equals("virtualNetworks", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.InvalidNetworkNameInResourceId, 
                        subnetId));
            }

            var subnetName = segments[segments.Length - 1];
            var virtualNetworkName = segments[segments.Length - 3];

            var subnet = NetworkManagementClient.Subnets.Get(this.ResourceGroupName, virtualNetworkName, subnetName);
            return subnet.AddressPrefix;
        }
    }
}