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
using Microsoft.Azure.Commands.ServiceFabric.Common;
using Microsoft.Azure.Commands.ServiceFabric.Models;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.ServiceFabric;
using Microsoft.Azure.Management.Storage;
using Microsoft.Azure.Management.Storage.Models;
using ServiceFabricProperties = Microsoft.Azure.Commands.ServiceFabric.Properties;

namespace Microsoft.Azure.Commands.ServiceFabric.Commands
{
    [Cmdlet(VerbsCommon.Add, CmdletNoun.AzureRmServiceFabricNodeType), OutputType(typeof(PSCluster))]
    public class AddAzureRmServiceFabricNodeType : ServiceFabricVmssCmdletBase
    {
        private const string LoadBalancerIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/loadBalancers/{2}";
        private const string BackendAddressIdFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/loadBalancers/{2}/backendAddressPools/{3}";
        private const string FrontendIDFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/loadBalancers/{2}/frontendIPConfigurations/{3}";
        private const string ProbeIDFormat = "/subscriptions/{0}/resourceGroups/{1}/providers/Microsoft.Network/loadBalancers/{2}/probes/{3}";

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The sku name")]
        [ValidateNotNullOrEmpty()]
        public string Sku
        {
            get { return string.IsNullOrWhiteSpace(this.sku) ? Constants.DefaultSku : this.sku; }
            set { this.sku = value; }
        }
        private string sku;

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Tier")]
        [ValidateNotNullOrEmpty()]
        public string Tier
        {
            get { return string.IsNullOrWhiteSpace(this.tier) ? Constants.DefaultTier : this.tier; }
            set { this.tier = value; }
        }
        private string tier;

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "Capacity")]
        [ValidateNotNullOrEmpty()]
        public int Capacity { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The user name for login to Vm")]
        [ValidateNotNullOrEmpty()]
        public string VmUserName { get; set; }

        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true,
                   HelpMessage = "The password of login to the Vm")]
        [ValidateNotNullOrEmpty()]
        public string VmPassword { get; set; }

        private string diagnosticsStorageName;
        private string addressPrefix;

        //For testing
        internal static bool dontRandom = false;

        public override void ExecuteCmdlet()
        {
            if (CheckNodeTypeExistence())
            {
                throw new PSArgumentException(string.Format("{0} exists", this.NodeTypeName));
            }

            var cluster = AddNodeTypeToSFRP();
            try
            {
                CreateVmss();
            }
            catch (Exception )
            {
                RemoveNodeTypeFromSfrp();
                throw;
            }

            WriteObject(cluster,true);
        }

        private PSCluster AddNodeTypeToSFRP()
        {
            var cluster = SFRPClient.Clusters.Get(this.ResourceGroupName, this.ClusterName);

            if (cluster.NodeTypes == null)
            {
                throw new PSInvalidOperationException(ServiceFabricProperties.Resources.NoneNodeTypeFound);
            }

            var existingNodeType = cluster.NodeTypes.SingleOrDefault(n =>
            string.Equals(
                this.NodeTypeName,
                n.Name,
                StringComparison.InvariantCultureIgnoreCase));

            if (existingNodeType != null)
            {
                throw new PSInvalidOperationException(
                    string.Format(
                        ServiceFabricProperties.Resources.NodeTypeAlreadyExist,
                        this.NodeTypeName));
            }

            cluster.NodeTypes.Add(new Management.ServiceFabric.Models.NodeTypeDescription()
            {
                Name = this.NodeTypeName,
                ApplicationPorts = new Management.ServiceFabric.Models.EndpointRangeDescription()
                {
                    StartPort = Constants.DefaultApplicationStartPort,
                    EndPort = Constants.DefaultApplicationEndPort
                },
                ClientConnectionEndpointPort = Constants.DefaultClientConnectionEndpoint,
                DurabilityLevel = Constants.DefaultDurabilityLevel,
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

            ComputeClient.VirtualMachineScaleSets.CreateOrUpdate(
                this.ResourceGroupName,
                this.NodeTypeName,
                new VirtualMachineScaleSet()
                {
                    Location = GetLocation(),
                    Sku = new Management.Compute.Models.Sku(this.Sku, this.Tier, this.Capacity),
                    Overprovision = false,
                    Tags = GetServiceFabricTags(),
                    UpgradePolicy = new UpgradePolicy()
                    {
                        Mode = UpgradeMode.Automatic
                    },
                    VirtualMachineProfile = virtualMachineScaleSetProfile
                });
        }

        private IDictionary<string, string> GetServiceFabricTags()
        {
            return new Dictionary<string, string>()
            {
                { "clusterName",this.ClusterName },
                { "resourceType" ,Constants.ServieFabricTag }
            };
        }

        private string GetLocation()
        {
            return this.ResourcesClient.ResourceGroups.Get(this.ResourceGroupName).ResourceGroup.Location;
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

            VirtualMachineScaleSetExtension fabircExtension = null;
            VirtualMachineScaleSetExtension diagnosticsVmExt = null;

            VirtualMachineScaleSetStorageProfile existingStorageProfile = null;
            VirtualMachineScaleSetNetworkProfile existingNetworkProfile = null;
            var vms = ComputeClient.VirtualMachineScaleSets.List(this.ResourceGroupName);
            if (vms != null)
            {
                foreach (var vm in vms)
                {
                    //TODO
                    var ext = vm.VirtualMachineProfile.ExtensionProfile.Extensions.FirstOrDefault(
                        e =>
                        string.Equals(
                            e.Type, 
                            Constants.ServiceFabricWindowsNodeExtName, 
                            StringComparison.OrdinalIgnoreCase));

                    if (ext == null)
                    {
                        ext = vm.VirtualMachineProfile.ExtensionProfile.Extensions.FirstOrDefault(
                            e =>
                            string.Equals(
                                e.Type, 
                                Constants.ServiceFabricLinuxNodeExtName, 
                                StringComparison.OrdinalIgnoreCase));
                    }

                    if (ext != null)
                    {
                        fabircExtension = ext;

                        osProfile = vm.VirtualMachineProfile.OsProfile;
                        existingStorageProfile = vm.VirtualMachineProfile.StorageProfile;
                        existingNetworkProfile = vm.VirtualMachineProfile.NetworkProfile;
                    }

                    ext = vm.VirtualMachineProfile.ExtensionProfile.Extensions.FirstOrDefault(e =>
                    string.Equals(e.Type, "IaaSDiagnostics", StringComparison.InvariantCultureIgnoreCase));
                    if (ext != null)
                    {
                        diagnosticsVmExt = ext;
                    }

                    if (ext != null && diagnosticsVmExt != null)
                    {
                        break;
                    }
                }
            }

            osProfile = GetOsProfile(osProfile);
            storageProfile = GetStorageProfile(existingStorageProfile);
            networkProfile = CreateNetworkResource(
                existingNetworkProfile.NetworkInterfaceConfigurations.FirstOrDefault()
                );

            if (fabircExtension == null || diagnosticsVmExt == null || existingStorageProfile == null)
            {
                throw new NotSupportedException("The resource group should have at least one valid vmext for service fabric");
            }

            fabircExtension.Name = string.Format("{0}_ServiceFabricNode", this.NodeTypeName);
            diagnosticsVmExt.Name = string.Format("{0}_VMDiagnosticsVmExt", this.NodeTypeName);

            fabircExtension = GetFabriExtension(fabircExtension);
            diagnosticsVmExt = GetDiagnosticsExtension(diagnosticsVmExt);
            vmExtProfile = new VirtualMachineScaleSetExtensionProfile()
            {
                Extensions = new[] { fabircExtension, diagnosticsVmExt }
            };
        }

        private VirtualMachineScaleSetOSProfile GetOsProfile(VirtualMachineScaleSetOSProfile osProfile)
        {
            osProfile.ComputerNamePrefix = this.NodeTypeName;
            osProfile.AdminPassword = this.VmPassword;
            osProfile.AdminUsername = this.VmUserName;
            return osProfile;
        }

        private VirtualMachineScaleSetExtension GetFabriExtension(VirtualMachineScaleSetExtension fabircExtension)
        {
            var settings = fabircExtension.Settings as Newtonsoft.Json.Linq.JObject;
            settings["nodeTypeRef"] = this.NodeTypeName;
            if (settings["nicPrefixOverride"] != null)
            {
                settings["nicPrefixOverride"] = this.addressPrefix;
            }

            var keys = GetStorageAccountKey(this.diagnosticsStorageName);

            var protectedSettings = new Newtonsoft.Json.Linq.JObject();
            protectedSettings["StorageAccountKey1"] = keys[0];
            protectedSettings["StorageAccountKey2"] = keys[1];
            fabircExtension.ProtectedSettings = protectedSettings;
            return fabircExtension;
        }

        private VirtualMachineScaleSetExtension GetDiagnosticsExtension(
            VirtualMachineScaleSetExtension diagnosticsExtension)
        {
            var settings = diagnosticsExtension.Settings as Newtonsoft.Json.Linq.JObject;

            var accountName = settings["StorageAccount"];
            var protectedSettings = new Newtonsoft.Json.Linq.JObject();
            protectedSettings["storageAccountName"] = accountName;
            protectedSettings["storageAccountKey"] = GetStorageAccountKey((string)accountName).First();
            //TODO
            protectedSettings["storageAccountEndPoint"] = "https://core.windows.net/";
            diagnosticsExtension.ProtectedSettings = protectedSettings;
            return diagnosticsExtension;
        }

        private List<string> GetStorageAccountKey(string accoutName)
        {
            //return new List<string>() {
            //    string.Format("[listKeys(resourceId('Microsoft.Storage/storageAccounts', {0}),'2015-05-01-preview').key1]",accoutName),
            //    string.Format("[listKeys(resourceId('Microsoft.Storage/storageAccounts', {0}),'2015-05-01-preview').key2]",accoutName)
            //};

            var keys = this.StorageManagementClient.StorageAccounts.ListKeys(this.ResourceGroupName, accoutName);
            return new List<string>() { keys.Keys.ElementAt(0).Value, keys.Keys.ElementAt(1).Value };
        }

        private List<StorageAccount> CreateStorageAccount()
        {
            var randomName = GetRandomName();
            var accounts = new List<StorageAccount>();
            for (int i = 0, start = 0; i < this.Capacity; i++)
            {
                string accountName = string.Empty;
                int retry = 10;
                while (retry-- >= 0)
                {
                    try
                    {
                        start++;
                        accountName = randomName + start.ToString();
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

        private string GetRandomName()
        {
            var name = string.Empty;

            if (!dontRandom)
            {
                name = string.Concat(
                    this.NodeTypeName,
                    System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetRandomFileName()));
            }
            else
            {
                name = "powershelltest";
            }

            if (name.Length > 22)
            {
                name = name.Substring(0, 22);
            }

            return name;
        }

        private VirtualMachineScaleSetStorageProfile GetStorageProfile(
            VirtualMachineScaleSetStorageProfile existingProfile)
        {
            var vhds = CreateStorageAccount().Select(a => string.Concat(a.PrimaryEndpoints.Blob, "vhd")).ToList();
            return new VirtualMachineScaleSetStorageProfile()
            {
                ImageReference = existingProfile.ImageReference,
                OsDisk = new VirtualMachineScaleSetOSDisk()
                {
                    Caching = existingProfile.OsDisk.Caching,
                    OsType = existingProfile.OsDisk.OsType,
                    Image = existingProfile.OsDisk.Image,
                    Name = existingProfile.OsDisk.Name,
                    CreateOption = existingProfile.OsDisk.CreateOption,
                    VhdContainers = vhds
                }
            };
        }

        private VirtualMachineScaleSetNetworkProfile CreateNetworkResource(
            VirtualMachineScaleSetNetworkConfiguration existingNetworkConfig)
        {
            var subsetName = string.Format("Subnet-{0}", this.NodeTypeName);
           
            var ipConfiguration = existingNetworkConfig.IpConfigurations.FirstOrDefault();
            var subNetId = ipConfiguration.Subnet.Id;
            const string virtualNetworks = "Microsoft.Network/virtualNetworks/";
            var virtualNetwork = string.Empty;
            int index = -1;
            if ((index = subNetId.IndexOf(
                virtualNetworks,
                StringComparison.InvariantCultureIgnoreCase)) != -1)
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
                            if (details != null)
                            {
                                network.Subnets.Remove(subnet);
                                continue;
                            }
                        }
                    }

                    throw;
                }
            }

            var publicAddressName = string.Format("LBIP-{0}{1}", this.NodeTypeName, index);
            var dnsLable = string.Format("dnslable-{0}{1}", this.NodeTypeName.ToLower(), index);
            var lbName = string.Format("LB-{0}{1}", this.NodeTypeName, index);

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
                        Name = string.Format("NIC-{0}-{1}", this.NodeTypeName,start),
                        Primary = true
                    }
                }
            };
        }
    }
}