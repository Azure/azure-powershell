// PSNetworkProfileTrack2.cs
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.Compute.Models.Track2
{
    public class PSNetworkProfile
    {
        public IList<PSNetworkInterfaceReference> NetworkInterfaces { get; set; }
        public PSNetworkApiVersion NetworkApiVersion { get; set; }
        public PSNetworkInterfaceConfiguration NetworkInterfaceConfigurations { get; set; }
    }
    
    public class PSNetworkInterfaceReference
    {
        public string Id { get; set; }
        public bool? Primary { get; set; }
        public string DeleteOption { get; set; }
    }
    
    public class PSNetworkApiVersion
    {
        public string Version { get; set; }
    }
    
    public class PSNetworkInterfaceConfiguration
    {
        public string Name { get; set; }
        public bool? Primary { get; set; }
        public bool? EnableAcceleratedNetworking { get; set; }
        public bool? DisableTcpStateTracking { get; set; }
        public bool? EnableFpga { get; set; }
        public bool? EnableIPForwarding { get; set; }
        public PSNetworkSecurityGroup NetworkSecurityGroup { get; set; }
        public PSDnsSettings DnsSettings { get; set; }
        public IList<PSIPConfiguration> IpConfigurations { get; set; }
        public string DeleteOption { get; set; }
        public PSNetworkInterfaceAuxiliaryMode AuxiliaryMode { get; set; }
        public PSNetworkInterfaceAuxiliarySku AuxiliarySku { get; set; }
    }
    
    public class PSNetworkSecurityGroup
    {
        public string Id { get; set; }
    }
    
    public class PSDnsSettings
    {
        public IList<string> DnsServers { get; set; }
    }
    
    public class PSIPConfiguration
    {
        public string Name { get; set; }
        public PSSubnet Subnet { get; set; }
        public bool? Primary { get; set; }
        public PSPublicIPAddressConfiguration PublicIPAddressConfiguration { get; set; }
        public string PrivateIPAddressVersion { get; set; }
        public IList<PSApplicationGatewayBackendAddressPool> ApplicationGatewayBackendAddressPools { get; set; }
        public IList<PSApplicationSecurityGroup> ApplicationSecurityGroups { get; set; }
        public IList<PSBackendAddressPool> LoadBalancerBackendAddressPools { get; set; }
    }
    
    public class PSSubnet
    {
        public string Id { get; set; }
    }
    
    public class PSPublicIPAddressConfiguration
    {
        public string Name { get; set; }
        public PSPublicIPAddressSku Sku { get; set; }
        public int? IdleTimeoutInMinutes { get; set; }
        public string DeleteOption { get; set; }
        public PSDnsSettings DnsSettings { get; set; }
        public IList<PSIPTag> IpTags { get; set; }
        public string PublicIPAddressVersion { get; set; }
        public string PublicIPAllocationMethod { get; set; }
        public PSPublicIPAddressPrefix PublicIPPrefix { get; set; }
    }
    
    public class PSPublicIPAddressSku
    {
        public string Name { get; set; }
        public string Tier { get; set; }
    }
    
    public class PSIPTag
    {
        public string IpTagType { get; set; }
        public string Tag { get; set; }
    }
    
    public class PSPublicIPAddressPrefix
    {
        public string Id { get; set; }
    }
    
    public class PSApplicationGatewayBackendAddressPool
    {
        public string Id { get; set; }
    }
    
    public class PSApplicationSecurityGroup
    {
        public string Id { get; set; }
    }
    
    public class PSBackendAddressPool
    {
        public string Id { get; set; }
    }
    
    public class PSNetworkInterfaceAuxiliaryMode
    {
        public string Mode { get; set; }
    }
    
    public class PSNetworkInterfaceAuxiliarySku
    {
        public string Sku { get; set; }
    }
}