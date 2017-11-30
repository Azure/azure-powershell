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
using Microsoft.Azure.Management.ServiceFabric;
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
        private const string FrontendIDFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/loadBalancers/{2}/frontendIPConfigurations/{3}";
        private const string ProbeIDFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/loadBalancers/{2}/probes/{3}";
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
                  HelpMessage = "The node type name")]
        [ValidateNotNullOrEmpty()]
        public override string NodeType { get; set; }

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

        private DurabilityLevel durabilityLevel = DurabilityLevel.Bronze;
        [Parameter(Mandatory = false, ValueFromPipeline = true,
                   HelpMessage = "Specify the durability level of the NodeType.")]
        [ValidateNotNullOrEmpty()]
        public DurabilityLevel DurabilityLevel
        {
            get { return this.durabilityLevel; }
            set
            {
                this.durabilityLevel = value;
            }
        }

        public override void ExecuteCmdlet()
        {
            if (this.DurabilityLevel == DurabilityLevel.Gold && !skusSupportGoldDurability.Contains(this.VmSku))
            {
                throw new PSArgumentException("Only Standard_D15_v2 and Standard_G5 supports Gold durability,please specify -VmSku to right value");
            }

            if (CheckNodeTypeExistence())
            {
                throw new PSArgumentException(string.Format("{0} exists", this.NodeType));
            }

            if (ShouldProcess(target: this.NodeType, action: string.Format("Add an new node type {0}", this.NodeType)))
            {
                var cluster = AddNodeTypeToSfrp();
                try
                {
                    CreateVmss();
                }
                catch (Exception)
                {
                    WriteWarning("Rolling back the changes to the cluster");
                    RemoveNodeTypeFromSfrp();
                    throw;
                }

                WriteObject(cluster, true);
            }
        }

        private PSCluster AddNodeTypeToSfrp()
        {
            var cluster = SFRPClient.Clusters.Get(this.ResourceGroupName, this.Name);

            if (cluster.NodeTypes == null)
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.NoneNodeTypeFound);
            }

            var existingNodeType = cluster.NodeTypes.SingleOrDefault(
                n =>
                string.Equals(
                    this.NodeType,
                    n.Name,
                    StringComparison.OrdinalIgnoreCase));

            if (existingNodeType != null)
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.NodeTypeAlreadyExist,
                        this.NodeType));
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

            this.diagnosticsStorageName = cluster.DiagnosticsStorageAccountConfig.StorageAccountName;

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

            WriteClusterAndVmssVerboseWhenUpdate(new List<Task>() { vmssTask }, false);
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

            VirtualMachineScaleSetExtension existingFabircExtension = null;
            VirtualMachineScaleSetExtension diagnosticsVmExt = null;

            VirtualMachineScaleSetStorageProfile existingStorageProfile = null;
            VirtualMachineScaleSetNetworkProfile existingNetworkProfile = null;
            var vms = ComputeClient.VirtualMachineScaleSets.List(this.ResourceGroupName);
            if (vms != null)
            {
                foreach (var vm in vms)
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
                        existingFabircExtension = ext;
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

            if (existingFabircExtension == null || existingStorageProfile == null || existingNetworkProfile == null)
            {
                throw new NotSupportedException("The resource group should have at least one valid vmext for service fabric");
            }

            osProfile = GetOsProfile(osProfile);
            storageProfile = GetStorageProfile(existingStorageProfile);
            networkProfile = CreateNetworkResource(existingNetworkProfile.NetworkInterfaceConfigurations.FirstOrDefault());

            existingFabircExtension.Name = string.Format("{0}_ServiceFabricNode", this.NodeType);
            existingFabircExtension = GetFabriExtension(existingFabircExtension);

            if (diagnosticsVmExt != null)
            {
                diagnosticsVmExt.Name = string.Format("{0}_VMDiagnosticsVmExt", this.NodeType);
                diagnosticsVmExt = GetDiagnosticsExtension(diagnosticsVmExt);
                vmExtProfile = new VirtualMachineScaleSetExtensionProfile()
                {
                    Extensions = new[] { existingFabircExtension, diagnosticsVmExt }
                };
            }
            else
            {
                vmExtProfile = new VirtualMachineScaleSetExtensionProfile()
                {
                    Extensions = new[] { existingFabircExtension }
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

        private VirtualMachineScaleSetExtension GetFabriExtension(VirtualMachineScaleSetExtension fabircExtension)
        {
            var settings = fabircExtension.Settings as JObject;
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

            fabircExtension.ProtectedSettings = protectedSettings;
            return fabircExtension;
        }

        private VirtualMachineScaleSetExtension GetDiagnosticsExtension(VirtualMachineScaleSetExtension diagnosticsExtension)
        {
            var settings = diagnosticsExtension.Settings as JObject;

            if (settings == null)
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.InvalidVmssConfiguration);
            }

            var accountName = settings["StorageAccount"];
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

        private List<StorageAccount> CreateStorageAccount()
        {
            var randomName = GetStorageRandomName();
            var accounts = new List<StorageAccount>();
            for (int i = 0, start = 0; i < Constants.StorageAccountsPerNodeType; i++)
            {
                string accountName = string.Empty;
                int retry = 10;
                while (retry-- >= 0)
                {
                    try
                    {
                        start++;
                        accountName = randomName + start;
                        StorageManagementClient.StorageAccounts.Create(
                             this.ResourceGroupName,
                             accountName,
                             new StorageAccountCreateParameters()
                             {
                                 Sku = new Management.Storage.Models.Sku(SkuName.StandardLRS),
                                 Location = GetLocation(),
                                 Tags = GetServiceFabricTags()
                             });

                        break;
                    }
                    catch (Rest.Azure.CloudException e)
                    {
                        if (e.Body.Code == "StorageAccountAlreadyExists")
                        {
                            continue;
                        }

                        throw;
                    }
                }

                if (retry < 0)
                {
                    throw new PSInvalidOperationException(ServiceFabricProperties.Resources.FailedToCreateStorageAccount);
                }

                var account = StorageManagementClient.StorageAccounts.GetProperties(this.ResourceGroupName, accountName);
                accounts.Add(account);
            }

            return accounts;
        }

        private string GetStorageRandomName()
        {
            var name = this.NodeType.ToLower();

            if (!dontRandom)
            {
                do
                {
                    name = string.Concat(
                        name,
                        System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetRandomFileName()));

                    StringBuilder sb = new StringBuilder();
                    foreach (var n in name)
                    {
                        if ((n >= 'a' && n <= 'z') || (n >= '0' && n <= '9'))
                        {
                            sb.Append(n);
                        }
                    }

                    name = sb.ToString();
                } while (name.Length < 3);
            }
            else
            {
                // for testing
                name = "powershelltest";
            }

            if (name.Length > 22)
            {
                name = name.Substring(0, 22);
            }

            return name;
        }

        private VirtualMachineScaleSetStorageProfile GetStorageProfile(VirtualMachineScaleSetStorageProfile existingProfile)
        {
            var osDisk = new VirtualMachineScaleSetOSDisk()
            {
                Caching = existingProfile.OsDisk.Caching,
                OsType = existingProfile.OsDisk.OsType,
                CreateOption = existingProfile.OsDisk.CreateOption
            };

            if(existingProfile.OsDisk.ManagedDisk != null)
            {
                osDisk.ManagedDisk = existingProfile.OsDisk.ManagedDisk;
            }
            else
            {
                osDisk.Image = existingProfile.OsDisk.Image;
                osDisk.Name = existingProfile.OsDisk.Name;
                osDisk.VhdContainers = CreateStorageAccount().Select(a => string.Concat(a.PrimaryEndpoints.Blob, "vhd")).ToList();
            }

            return new VirtualMachineScaleSetStorageProfile()
            {
                ImageReference = existingProfile.ImageReference,
                OsDisk = osDisk
            };
        }

        private VirtualMachineScaleSetNetworkProfile CreateNetworkResource(VirtualMachineScaleSetNetworkConfiguration existingNetworkConfig)
        {
            var subsetName = string.Format("Subnet-{0}", this.NodeType);

            var ipConfiguration = existingNetworkConfig.IpConfigurations.FirstOrDefault();

            if (ipConfiguration == null)
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.InvalidVmssConfiguration);
            }

            var subNetId = ipConfiguration.Subnet.Id;
            const string virtualNetworks = "Microsoft.Network/virtualNetworks/";
            var virtualNetwork = string.Empty;
            int index = -1;
            if ((index = subNetId.IndexOf(virtualNetworks, StringComparison.OrdinalIgnoreCase)) != -1)
            {
                var end = subNetId.IndexOf("/", index + virtualNetworks.Length);
                virtualNetwork = subNetId.Substring(index + virtualNetworks.Length, end - index - virtualNetworks.Length);
            }

            if (string.IsNullOrEmpty(virtualNetwork))
            {
                throw new InvalidOperationException();
            }

            var network = NetworkManagementClient.VirtualNetworks.Get(this.ResourceGroupName, virtualNetwork);

            var start = 1;
            Subnet subnet = null;
            var retry = 5;
            while (retry-- >= 0)
            {
                try
                {
                    subnet = NetworkManagementClient.Subnets.CreateOrUpdate(
                       this.ResourceGroupName,
                       virtualNetwork,
                       string.Format("{0}-{1}", subsetName, start),
                       new Subnet()
                       {
                           AddressPrefix = string.Format("10.0.{0}.0/24", start++)
                       });

                    network.Subnets.Add(subnet);
                    network = NetworkManagementClient.VirtualNetworks.CreateOrUpdate(
                        this.ResourceGroupName,
                        virtualNetwork,
                        network);

                    this.addressPrefix = subnet.AddressPrefix;
                    break;
                }
                catch (Rest.Azure.CloudException ex)
                {
                    if (ex.Body.Code == "NetcfgInvalidSubnet" ||
                        ex.Body.Code == "InUseSubnetCannotBeUpdated")
                    {
                        network.Subnets.Remove(subnet);
                        continue;
                    }

                    if (ex.Body.Code == "InvalidRequestFormat")
                    {
                        if (ex.Body.Details != null)
                        {
                            var details = ex.Body.Details.Where(d => d.Code == "DuplicateResourceName");
                            if (details.Any())
                            {
                                network.Subnets.Remove(subnet);
                                continue;
                            }
                        }
                    }

                    throw;
                }
            }

            var publicAddressName = string.Format("LBIP-{0}-{1}{2}", this.Name.ToLower(), this.NodeType.ToLower(), index);
            var dnsLable = string.Format("{0}-{1}{2}", this.Name.ToLower(), this.NodeType.ToLower(), index);
            var lbName = string.Format("LB-{0}-{1}{2}", this.Name.ToLower(), this.NodeType.ToLower(), index);

            var publicIp = NetworkManagementClient.PublicIPAddresses.CreateOrUpdate(
                this.ResourceGroupName,
                publicAddressName,
                new PublicIPAddress()
                {
                    PublicIPAllocationMethod = "Dynamic",
                    Location = GetLocation(),
                    DnsSettings = new PublicIPAddressDnsSettings(dnsLable)
                });

            var backendAdressPollName = "LoadBalancerBEAddressPool";
            var frontendIpConfigurationName = "LoadBalancerIPConfig";
            var probeName = "FabricGatewayProbe";
            var probeHTTPName = "FabricHttpGatewayProbe";
            var inboundNatPoolsName = "LoadBalancerBEAddressNatPool";

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
                        Name = backendAdressPollName
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
                               backendAdressPollName)
                        },
                        BackendPort = Constants.DefaultTcpPort,
                        EnableFloatingIP = false,
                        FrontendIPConfiguration = new Management.Network.Models.SubResource()
                        {
                            Id = string.Format(
                                FrontendIDFormat,
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
                                ProbeIDFormat,
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
                               backendAdressPollName)
                        },
                        BackendPort = Constants.DefaultHttpPort,
                        EnableFloatingIP = false,
                        FrontendIPConfiguration = new Management.Network.Models.SubResource()
                        {
                            Id = string.Format(
                                FrontendIDFormat,
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
                                ProbeIDFormat,
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
                        Name = inboundNatPoolsName,
                        BackendPort = Constants.DefaultBackendPort,
                        FrontendIPConfiguration = new Management.Network.Models.SubResource()
                        {
                             Id = string.Format(
                                FrontendIDFormat,
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
                                Name = string.Format("Nic-{0}",start),
                                LoadBalancerBackendAddressPools = newLoadBalancer.BackendAddressPools.Select(
                                    b=> new Management.Compute.Models.SubResource()
                                    {
                                        Id =b.Id
                                    }
                                    ).ToList(),

                                LoadBalancerInboundNatPools = newLoadBalancer.InboundNatPools.Select(
                                    p=>new Management.Compute.Models.SubResource()
                                    {
                                        Id = p.Id
                                    }
                                    ).ToList(),
                                Subnet = new ApiEntityReference(){Id = subnet.Id}
                            }
                        },
                        Name = string.Format("NIC-{0}-{1}", this.NodeType,start),
                        Primary = true
                    }
                }
            };
        }
    }
}