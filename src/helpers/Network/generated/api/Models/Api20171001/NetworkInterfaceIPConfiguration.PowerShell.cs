namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>IPConfiguration in a network interface.</summary>
    [System.ComponentModel.TypeConverter(typeof(NetworkInterfaceIPConfigurationTypeConverter))]
    public partial class NetworkInterfaceIPConfiguration
    {

        /// <summary>
        /// <c>AfterDeserializeDictionary</c> will be called after the deserialization has finished, allowing customization of the
        /// object before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>

        partial void AfterDeserializeDictionary(global::System.Collections.IDictionary content);

        /// <summary>
        /// <c>AfterDeserializePSObject</c> will be called after the deserialization has finished, allowing customization of the object
        /// before it is returned. Implement this method in a partial class to enable this behavior
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>

        partial void AfterDeserializePSObject(global::System.Management.Automation.PSObject content);

        /// <summary>
        /// <c>BeforeDeserializeDictionary</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializeDictionary(global::System.Collections.IDictionary content, ref bool returnNow);

        /// <summary>
        /// <c>BeforeDeserializePSObject</c> will be called before the deserialization has commenced, allowing complete customization
        /// of the object before it is deserialized.
        /// If you wish to disable the default deserialization entirely, return <c>true</c> in the <see "returnNow" /> output parameter.
        /// Implement this method in a partial class to enable this behavior.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <param name="returnNow">Determines if the rest of the serialization should be processed, or if the method should return
        /// instantly.</param>

        partial void BeforeDeserializePSObject(global::System.Management.Automation.PSObject content, ref bool returnNow);

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfaceIPConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new NetworkInterfaceIPConfiguration(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfaceIPConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new NetworkInterfaceIPConfiguration(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="NetworkInterfaceIPConfiguration" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfaceIPConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal NetworkInterfaceIPConfiguration(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfaceIPConfigurationPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).Subnet = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet) content.GetValueForProperty("Subnet",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).Subnet, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubnetTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PrivateIPAllocationMethod = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod?) content.GetValueForProperty("PrivateIPAllocationMethod",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PrivateIPAllocationMethod, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).LoadBalancerBackendAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBackendAddressPool[]) content.GetValueForProperty("LoadBalancerBackendAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).LoadBalancerBackendAddressPool, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBackendAddressPool>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.BackendAddressPoolTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).LoadBalancerInboundNatRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRule[]) content.GetValueForProperty("LoadBalancerInboundNatRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).LoadBalancerInboundNatRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.InboundNatRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).Primary = (bool?) content.GetValueForProperty("Primary",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).Primary, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PrivateIPAddress = (string) content.GetValueForProperty("PrivateIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PrivateIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PrivateIPAddressVersion = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion?) content.GetValueForProperty("PrivateIPAddressVersion",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PrivateIPAddressVersion, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).ApplicationSecurityGroup = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationSecurityGroup[]) content.GetValueForProperty("ApplicationSecurityGroup",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).ApplicationSecurityGroup, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationSecurityGroup>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationSecurityGroupTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddress = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddress) content.GetValueForProperty("PublicIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddress, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.PublicIPAddressTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressSku = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressSku) content.GetValueForProperty("PublicIPAddressSku",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressSku, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.PublicIPAddressSkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressEtag = (string) content.GetValueForProperty("PublicIPAddressEtag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressEtag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressZone = (string[]) content.GetValueForProperty("PublicIPAddressZone",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressZone, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).ApplicationGatewayBackendAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendAddressPool[]) content.GetValueForProperty("ApplicationGatewayBackendAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).ApplicationGatewayBackendAddressPool, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendAddressPool>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayBackendAddressPoolTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressTag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags) content.GetValueForProperty("PublicIPAddressTag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressTag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressProperty = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressPropertiesFormat) content.GetValueForProperty("PublicIPAddressProperty",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressProperty, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.PublicIPAddressPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressId = (string) content.GetValueForProperty("PublicIPAddressId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressName = (string) content.GetValueForProperty("PublicIPAddressName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressLocation = (string) content.GetValueForProperty("PublicIPAddressLocation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).IPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration) content.GetValueForProperty("IPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).IPConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressType = (string) content.GetValueForProperty("PublicIPAddressType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName?) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).IPAddress = (string) content.GetValueForProperty("IPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).IPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).DnsSetting = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressDnsSettings) content.GetValueForProperty("DnsSetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).DnsSetting, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.PublicIPAddressDnsSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressPropertiesProvisioningState = (string) content.GetValueForProperty("PublicIPAddressPropertiesProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressPropertiesProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressVersion = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion?) content.GetValueForProperty("PublicIPAddressVersion",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressVersion, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).IdleTimeoutInMinutes = (int?) content.GetValueForProperty("IdleTimeoutInMinutes",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).IdleTimeoutInMinutes, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).ResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAllocationMethod = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod?) content.GetValueForProperty("PublicIPAllocationMethod",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAllocationMethod, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).DnsSettingDomainNameLabel = (string) content.GetValueForProperty("DnsSettingDomainNameLabel",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).DnsSettingDomainNameLabel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).DnsSettingFqdn = (string) content.GetValueForProperty("DnsSettingFqdn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).DnsSettingFqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).DnsSettingReverseFqdn = (string) content.GetValueForProperty("DnsSettingReverseFqdn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).DnsSettingReverseFqdn, global::System.Convert.ToString);
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfaceIPConfiguration"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal NetworkInterfaceIPConfiguration(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).Property = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationPropertiesFormat) content.GetValueForProperty("Property",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).Property, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfaceIPConfigurationPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).Name = (string) content.GetValueForProperty("Name",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).Name, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).Etag = (string) content.GetValueForProperty("Etag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).Etag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)this).Id = (string) content.GetValueForProperty("Id",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResourceInternal)this).Id, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).Subnet = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet) content.GetValueForProperty("Subnet",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).Subnet, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubnetTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PrivateIPAllocationMethod = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod?) content.GetValueForProperty("PrivateIPAllocationMethod",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PrivateIPAllocationMethod, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).LoadBalancerBackendAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBackendAddressPool[]) content.GetValueForProperty("LoadBalancerBackendAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).LoadBalancerBackendAddressPool, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IBackendAddressPool>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.BackendAddressPoolTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).LoadBalancerInboundNatRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRule[]) content.GetValueForProperty("LoadBalancerInboundNatRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).LoadBalancerInboundNatRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IInboundNatRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.InboundNatRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).Primary = (bool?) content.GetValueForProperty("Primary",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).Primary, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PrivateIPAddress = (string) content.GetValueForProperty("PrivateIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PrivateIPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PrivateIPAddressVersion = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion?) content.GetValueForProperty("PrivateIPAddressVersion",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PrivateIPAddressVersion, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).ApplicationSecurityGroup = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationSecurityGroup[]) content.GetValueForProperty("ApplicationSecurityGroup",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).ApplicationSecurityGroup, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationSecurityGroup>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationSecurityGroupTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddress = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddress) content.GetValueForProperty("PublicIPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddress, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.PublicIPAddressTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressSku = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressSku) content.GetValueForProperty("PublicIPAddressSku",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressSku, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.PublicIPAddressSkuTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressEtag = (string) content.GetValueForProperty("PublicIPAddressEtag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressEtag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressZone = (string[]) content.GetValueForProperty("PublicIPAddressZone",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressZone, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).ApplicationGatewayBackendAddressPool = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendAddressPool[]) content.GetValueForProperty("ApplicationGatewayBackendAddressPool",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).ApplicationGatewayBackendAddressPool, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IApplicationGatewayBackendAddressPool>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ApplicationGatewayBackendAddressPoolTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressTag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags) content.GetValueForProperty("PublicIPAddressTag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressTag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressProperty = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressPropertiesFormat) content.GetValueForProperty("PublicIPAddressProperty",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressProperty, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.PublicIPAddressPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressId = (string) content.GetValueForProperty("PublicIPAddressId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressName = (string) content.GetValueForProperty("PublicIPAddressName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressLocation = (string) content.GetValueForProperty("PublicIPAddressLocation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).IPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IIPConfiguration) content.GetValueForProperty("IPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).IPConfiguration, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPConfigurationTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressType = (string) content.GetValueForProperty("PublicIPAddressType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).SkuName = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName?) content.GetValueForProperty("SkuName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).SkuName, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.PublicIPAddressSkuName.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).IPAddress = (string) content.GetValueForProperty("IPAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).IPAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).DnsSetting = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IPublicIPAddressDnsSettings) content.GetValueForProperty("DnsSetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).DnsSetting, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.PublicIPAddressDnsSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressPropertiesProvisioningState = (string) content.GetValueForProperty("PublicIPAddressPropertiesProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressPropertiesProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressVersion = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion?) content.GetValueForProperty("PublicIPAddressVersion",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAddressVersion, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPVersion.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).IdleTimeoutInMinutes = (int?) content.GetValueForProperty("IdleTimeoutInMinutes",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).IdleTimeoutInMinutes, (__y)=> (int) global::System.Convert.ChangeType(__y, typeof(int)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).ResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAllocationMethod = (Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod?) content.GetValueForProperty("PublicIPAllocationMethod",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).PublicIPAllocationMethod, Microsoft.Azure.PowerShell.Cmdlets.Network.Support.IPAllocationMethod.CreateFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).DnsSettingDomainNameLabel = (string) content.GetValueForProperty("DnsSettingDomainNameLabel",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).DnsSettingDomainNameLabel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).DnsSettingFqdn = (string) content.GetValueForProperty("DnsSettingFqdn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).DnsSettingFqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).DnsSettingReverseFqdn = (string) content.GetValueForProperty("DnsSettingReverseFqdn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfigurationInternal)this).DnsSettingReverseFqdn, global::System.Convert.ToString);
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// IPConfiguration in a network interface.
    [System.ComponentModel.TypeConverter(typeof(NetworkInterfaceIPConfigurationTypeConverter))]
    public partial interface INetworkInterfaceIPConfiguration

    {

    }
}