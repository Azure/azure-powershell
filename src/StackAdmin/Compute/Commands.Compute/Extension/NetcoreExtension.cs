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
#if !NETSTANDARD

using Microsoft.Azure.Management.Storage.Models;

namespace Microsoft.Azure.Commands.Compute
{
    public static class StorageExtensions
    {
        public static SkuName? Sku(this StorageAccount account)
        {
            return account.Sku.Name;
        }

        public static bool IsPremiumLrs(this StorageAccount account)
        {
            return account.Sku.Name== SkuName.PremiumLRS;
        }

        public static void SetAsStandardGRS(this StorageAccountCreateParameters createParams)
        {
            createParams.Sku.Name = SkuName.StandardGRS;
        }

        public static string GetFirstAvailableKey(this StorageAccountListKeysResult listKeyResult)
        {
            return !string.IsNullOrEmpty(listKeyResult.Keys[0].Value) ? listKeyResult.Keys[0].Value : listKeyResult.Keys[1].Value;
        }

        public static string GetKey1(this StorageAccountListKeysResult listKeyResult)
        {
            return listKeyResult.Keys[0].Value;
        }

        public static string GetKey2(this StorageAccountListKeysResult listKeyResult)
        {
            return listKeyResult.Keys[1].Value;
        }
    }    
}
#else
using Microsoft.Azure.Commands.Common.Authentication;
using Microsoft.Azure.Commands.Common.Authentication.Abstractions;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Storage.Models;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute
{
    public static class StorageExtensions
    {
        public static Sku Sku(this StorageAccount account)
        {
            return account.Sku;
        }

        public static string SkuName(this StorageAccount account)
        {
            return account.Sku.Name.ToString();
        }

        public static bool IsPremiumLrs(this StorageAccount account)
        {
            return account.Sku.Name == Microsoft.Azure.Management.Storage.Models.SkuName.PremiumLRS;
        }

        public static void SetAsStandardGRS(this StorageAccountCreateParameters createParams)
        {
            createParams.Sku = new Sku(Microsoft.Azure.Management.Storage.Models.SkuName.StandardGRS);
        }

        public static string GetFirstAvailableKey(this StorageAccountListKeysResult listKeyResult)
        {
            return listKeyResult.Keys.ElementAt(0).Value;
        }

        public static string GetKey1(this StorageAccountListKeysResult listKeyResult)
        {
            return listKeyResult.Keys.ElementAt(0).Value;
        }

        public static string GetKey2(this StorageAccountListKeysResult listKeyResult)
        {
            return listKeyResult.Keys.ElementAt(1).Value;
        }
    }
}

#region delete after common dependancies merge
namespace Microsoft.Azure.Commands.Network
{
    public partial class NetworkClient
    {
        public INetworkManagementClient NetworkManagementClient { get; set; }

        public Action<string> VerboseLogger { get; set; }

        public Action<string> ErrorLogger { get; set; }

        public Action<string> WarningLogger { get; set; }

        public NetworkClient(IAzureContext context)
            : this(AzureSession.Instance.ClientFactory.CreateArmClient<NetworkManagementClient>(context, AzureEnvironment.Endpoint.ResourceManager))
        {
        }

        public NetworkClient(INetworkManagementClient NetworkManagementClient)
        {
            this.NetworkManagementClient = NetworkManagementClient;
        }

        public NetworkClient()
        {
        }
    }
}

namespace Microsoft.Azure.Management.Internal.Network.Common
{
    public interface IResourceReference
    {
        string Id { get; set; }
    }
}
namespace Microsoft.Azure.Management.Internal.Network.Common
{
    public interface INetworkInterfaceReference : IResourceReference
    {
        bool? Primary { get; set; }
    }
}

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSResourceId
    {
        public string Id { get; set; }
    }
}

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSChildResource : PSResourceId
    {
        public string Name { get; set; }

        public string Etag { get; set; }
    }
}
namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;

    public class PSResourceNavigationLink : PSChildResource
    {
        [JsonProperty(Order = 1)]
        public string LinkedResourceType { get; set; }

        [JsonProperty(Order = 1)]
        public string Link { get; set; }

        [JsonProperty(Order = 1)]
        public string ProvisioningState { get; set; }
    }
}

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;

    public class PSSecurityRule : PSChildResource
    {
        [JsonProperty(Order = 1)]
        public string Description { get; set; }

        [JsonProperty(Order = 1)]
        public string Protocol { get; set; }

        [JsonProperty(Order = 1)]
        public string SourcePortRange { get; set; }

        [JsonProperty(Order = 1)]
        public string DestinationPortRange { get; set; }

        [JsonProperty(Order = 1)]
        public string SourceAddressPrefix { get; set; }

        [JsonProperty(Order = 1)]
        public string DestinationAddressPrefix { get; set; }

        [JsonProperty(Order = 1)]
        public string Access { get; set; }

        [JsonProperty(Order = 1)]
        public int Priority { get; set; }

        [JsonProperty(Order = 1)]
        public string Direction { get; set; }

        [JsonProperty(Order = 1)]
        public string ProvisioningState { get; set; }
    }
}

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PSNetworkSecurityGroup : PSTopLevelResource
    {
        public List<PSSecurityRule> SecurityRules { get; set; }

        public List<PSSecurityRule> DefaultSecurityRules { get; set; }

        public List<PSNetworkInterface> NetworkInterfaces { get; set; }

        public List<PSSubnet> Subnets { get; set; }

        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string SecurityRulesText
        {
            get { return JsonConvert.SerializeObject(SecurityRules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string DefaultSecurityRulesText
        {
            get { return JsonConvert.SerializeObject(DefaultSecurityRules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string NetworkInterfacesText
        {
            get { return JsonConvert.SerializeObject(NetworkInterfaces, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SubnetsText
        {
            get { return JsonConvert.SerializeObject(Subnets, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializeSecurityRules()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeDefaultSecurityRules()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeNetworkInterfaces()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeSubnets()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;

    public class PSRoute : PSChildResource
    {
        [JsonProperty(Order = 1)]
        public string AddressPrefix { get; set; }

        [JsonProperty(Order = 1)]
        public string NextHopType { get; set; }

        [JsonProperty(Order = 1)]
        public string NextHopIpAddress { get; set; }

        [JsonProperty(Order = 1)]
        public string ProvisioningState { get; set; }
    }
}
namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PSRouteTable : PSTopLevelResource
    {
        public List<PSRoute> Routes { get; set; }

        public List<PSSubnet> Subnets { get; set; }

        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string RoutesText
        {
            get { return JsonConvert.SerializeObject(Routes, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string SubnetsText
        {
            get { return JsonConvert.SerializeObject(Subnets, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializeSubnets()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeRoutes()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PSSubnet : PSChildResource
    {
        [JsonProperty(Order = 1)]
        public string AddressPrefix { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSIPConfiguration> IpConfigurations { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSResourceNavigationLink> ResourceNavigationLinks { get; set; }

        [JsonProperty(Order = 1)]
        public PSNetworkSecurityGroup NetworkSecurityGroup { get; set; }

        [JsonProperty(Order = 1)]
        public PSRouteTable RouteTable { get; set; }

        [JsonProperty(Order = 1)]
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string IpConfigurationsText
        {
            get { return JsonConvert.SerializeObject(IpConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ResourceNavigationLinksText
        {
            get { return JsonConvert.SerializeObject(ResourceNavigationLinks, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string NetworkSecurityGroupText
        {
            get { return JsonConvert.SerializeObject(NetworkSecurityGroup, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string RouteTableText
        {
            get { return JsonConvert.SerializeObject(RouteTable, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializeIpConfigurations()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSTopLevelResource : PSChildResource
    {
        public string ResourceGroupName { get; set; }

        public string Location { get; set; }

        public string ResourceGuid { get; set; }

        public string Type { get; set; }

        public Hashtable Tag { get; set; }

        public string TagsTable
        {
            get { return ConstructTagsTable(Tag); }
        }

        public static string ConstructTagsTable(Hashtable tags)
        {
            if (tags == null || tags.Count == 0)
            {
                return null;
            }

            StringBuilder resourcesTable = new StringBuilder();
            resourcesTable.AppendLine("Surprise! No tag available for now...");
            return resourcesTable.ToString();
        }
    }
}
namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSPublicIpAddressDnsSettings
    {
        public string DomainNameLabel { get; set; }

        public string Fqdn { get; set; }

        public string ReverseFqdn { get; set; }
    }
}

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;

    public class PSPublicIpAddress : PSTopLevelResource
    {
        public string PublicIpAllocationMethod { get; set; }

        public PSIPConfiguration IpConfiguration { get; set; }

        public PSPublicIpAddressDnsSettings DnsSettings { get; set; }

        public string IpAddress { get; set; }

        public string PublicIpAddressVersion { get; set; }

        public int? IdleTimeoutInMinutes { get; set; }

        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string IpConfigurationText
        {
            get { return JsonConvert.SerializeObject(IpConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string DnsSettingsText
        {
            get { return JsonConvert.SerializeObject(DnsSettings, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;

    public class PSIPConfiguration : PSChildResource
    {
        [JsonProperty(Order = 1)]
        public string PrivateIpAddress { get; set; }

        [JsonProperty(Order = 1)]
        public string PrivateIpAllocationMethod { get; set; }

        [JsonProperty(Order = 1)]
        public PSSubnet Subnet { get; set; }

        [JsonProperty(Order = 1)]
        public PSPublicIpAddress PublicIpAddress { get; set; }

        [JsonProperty(Order = 1)]
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string SubnetText
        {
            get { return JsonConvert.SerializeObject(Subnet, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string PublicIpAddressText
        {
            get { return JsonConvert.SerializeObject(PublicIpAddress, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }
    }
}

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PSBackendAddressPool : PSChildResource
    {
        [JsonProperty(Order = 1)]
        public List<PSNetworkInterfaceIPConfiguration> BackendIpConfigurations { get; set; }

        [JsonProperty(Order = 1)]
        public List<PSResourceId> LoadBalancingRules { get; set; }

        [JsonProperty(Order = 1)]
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string BackendIpConfigurationsText
        {
            get { return JsonConvert.SerializeObject(BackendIpConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string LoadBalancingRulesText
        {
            get { return JsonConvert.SerializeObject(LoadBalancingRules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializeBackendIpConfigurations()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeLoadBalancingRules()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}
namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;

    public class PSInboundRule : PSChildResource
    {
        [JsonProperty(Order = 1)]
        public PSResourceId FrontendIPConfiguration { get; set; }

        [JsonProperty(Order = 1)]
        public int BackendPort { get; set; }

        [JsonProperty(Order = 1)]
        public string Protocol { get; set; }

        [JsonProperty(Order = 1)]
        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string FrontendIPConfigurationText
        {
            get { return JsonConvert.SerializeObject(FrontendIPConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializeBackendPort()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;

    public class PSInboundNatRule : PSInboundRule
    {
        [JsonProperty(Order = 1)]
        public int FrontendPort { get; set; }

        [JsonProperty(Order = 1)]
        public int? IdleTimeoutInMinutes { get; set; }

        [JsonProperty(Order = 1)]
        public bool? EnableFloatingIP { get; set; }

        [JsonProperty(Order = 1)]
        public PSNetworkInterfaceIPConfiguration BackendIPConfiguration { get; set; }

        [JsonIgnore]
        public string BackendIPConfigurationText
        {
            get { return JsonConvert.SerializeObject(BackendIPConfiguration, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializeFrontendPort()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSApplicationGatewayBackendAddress
    {
        public string Fqdn { get; set; }
        public string IpAddress { get; set; }
    }
}

namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSApplicationGatewayBackendAddressPool : PSChildResource
    {
        public List<PSApplicationGatewayBackendAddress> BackendAddresses { get; set; }

        public List<PSNetworkInterfaceIPConfiguration> BackendIpConfigurations { get; set; }

        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string BackendAddressesText
        {
            get { return JsonConvert.SerializeObject(BackendAddresses, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string BackendIpConfigurationsText
        {
            get { return JsonConvert.SerializeObject(BackendIpConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializeBackendAddresses()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeBackendIpConfigurations()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}

namespace Microsoft.Azure.Commands.Network.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PSNetworkInterfaceIPConfiguration : PSIPConfiguration
    {
        [JsonProperty(Order = 2)]
        public string PrivateIpAddressVersion { get; set; }

        [JsonProperty(Order = 2)]
        public List<PSBackendAddressPool> LoadBalancerBackendAddressPools { get; set; }

        [JsonProperty(Order = 2)]
        public List<PSInboundNatRule> LoadBalancerInboundNatRules { get; set; }

        [JsonProperty(Order = 2)]
        public bool Primary { get; set; }

        [JsonProperty(Order = 2)]
        public List<PSApplicationGatewayBackendAddressPool> ApplicationGatewayBackendAddressPools { get; set; }

        [JsonIgnore]
        public string LoadBalancerBackendAddressPoolsText
        {
            get { return JsonConvert.SerializeObject(LoadBalancerBackendAddressPools, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string LoadBalancerInboundNatRulesText
        {
            get { return JsonConvert.SerializeObject(LoadBalancerInboundNatRules, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string ApplicationGatewayBackendAddressPoolsText
        {
            get { return JsonConvert.SerializeObject(ApplicationGatewayBackendAddressPools, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializeLoadBalancerBackendAddressPools()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeLoadBalancerInboundNatRules()
        {
            return !string.IsNullOrEmpty(this.Name);
        }

        public bool ShouldSerializeApplicationGatewayBackendAddressPools()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}
namespace Microsoft.Azure.Commands.Network.Models
{
    public class PSNetworkInterfaceDnsSettings
    {
        public List<string> DnsServers { get; set; }

        public List<string> AppliedDnsServers { get; set; }

        public string InternalDnsNameLabel { get; set; }

        public string InternalFqdn { get; set; }

        public string InternalDomainNameSuffix { get; set; }
    }
}

namespace Microsoft.Azure.Commands.Network.Models
{
    using Microsoft.Azure.Management.Internal.Network.Common;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class PSNetworkInterface : PSTopLevelResource, INetworkInterfaceReference
    {
        public PSResourceId VirtualMachine { get; set; }

        public List<PSNetworkInterfaceIPConfiguration> IpConfigurations { get; set; }

        public PSNetworkInterfaceDnsSettings DnsSettings { get; set; }

        public string MacAddress { get; set; }

        public bool? Primary { get; set; }

        public bool? EnableAcceleratedNetworking { get; set; }

        public bool? EnableIPForwarding { get; set; }

        public PSNetworkSecurityGroup NetworkSecurityGroup { get; set; }

        public string ProvisioningState { get; set; }

        [JsonIgnore]
        public string VirtualMachineText
        {
            get { return JsonConvert.SerializeObject(VirtualMachine, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string IpConfigurationsText
        {
            get { return JsonConvert.SerializeObject(IpConfigurations, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string DnsSettingsText
        {
            get { return JsonConvert.SerializeObject(this.DnsSettings, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        [JsonIgnore]
        public string NetworkSecurityGroupText
        {
            get { return JsonConvert.SerializeObject(NetworkSecurityGroup, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }); }
        }

        public bool ShouldSerializeIpConfigurations()
        {
            return !string.IsNullOrEmpty(this.Name);
        }
    }
}
#endregion

#endif