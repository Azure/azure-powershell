namespace Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001
{
    using Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.PowerShell;

    /// <summary>NetworkInterface properties.</summary>
    [System.ComponentModel.TypeConverter(typeof(NetworkInterfacePropertiesFormatTypeConverter))]
    public partial class NetworkInterfacePropertiesFormat
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
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfacePropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormat DeserializeFromDictionary(global::System.Collections.IDictionary content)
        {
            return new NetworkInterfacePropertiesFormat(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfacePropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        /// <returns>
        /// an instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormat"
        /// />.
        /// </returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormat DeserializeFromPSObject(global::System.Management.Automation.PSObject content)
        {
            return new NetworkInterfacePropertiesFormat(content);
        }

        /// <summary>
        /// Creates a new instance of <see cref="NetworkInterfacePropertiesFormat" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormat FromJsonString(string jsonText) => FromJson(Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.Json.JsonNode.Parse(jsonText));

        /// <summary>
        /// Deserializes a <see cref="global::System.Collections.IDictionary" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfacePropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Collections.IDictionary content that should be used.</param>
        internal NetworkInterfacePropertiesFormat(global::System.Collections.IDictionary content)
        {
            bool returnNow = false;
            BeforeDeserializeDictionary(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSetting = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceDnsSettings) content.GetValueForProperty("DnsSetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSetting, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfaceDnsSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).Nsg = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroup) content.GetValueForProperty("Nsg",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).Nsg, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkSecurityGroupTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).VirtualMachine = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource) content.GetValueForProperty("VirtualMachine",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).VirtualMachine, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).EnableAcceleratedNetworking = (bool?) content.GetValueForProperty("EnableAcceleratedNetworking",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).EnableAcceleratedNetworking, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).EnableIPForwarding = (bool?) content.GetValueForProperty("EnableIPForwarding",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).EnableIPForwarding, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).IPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration[]) content.GetValueForProperty("IPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).IPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfaceIPConfigurationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).MacAddress = (string) content.GetValueForProperty("MacAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).MacAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).Primary = (bool?) content.GetValueForProperty("Primary",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).Primary, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).ResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgEtag = (string) content.GetValueForProperty("NsgEtag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgEtag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgTag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags) content.GetValueForProperty("NsgTag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgTag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSettingInternalDnsNameLabel = (string) content.GetValueForProperty("DnsSettingInternalDnsNameLabel",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSettingInternalDnsNameLabel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSettingInternalDomainNameSuffix = (string) content.GetValueForProperty("DnsSettingInternalDomainNameSuffix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSettingInternalDomainNameSuffix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSettingInternalFqdn = (string) content.GetValueForProperty("DnsSettingInternalFqdn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSettingInternalFqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgName = (string) content.GetValueForProperty("NsgName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgType = (string) content.GetValueForProperty("NsgType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgId = (string) content.GetValueForProperty("NsgId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgLocation = (string) content.GetValueForProperty("NsgLocation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSettingDnsServer = (string[]) content.GetValueForProperty("DnsSettingDnsServer",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSettingDnsServer, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgProperty = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupPropertiesFormat) content.GetValueForProperty("NsgProperty",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgProperty, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkSecurityGroupPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSettingAppliedDnsServer = (string[]) content.GetValueForProperty("DnsSettingAppliedDnsServer",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSettingAppliedDnsServer, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).VirtualMachineId = (string) content.GetValueForProperty("VirtualMachineId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).VirtualMachineId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DefaultSecurityRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[]) content.GetValueForProperty("DefaultSecurityRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DefaultSecurityRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SecurityRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NetworkInterface = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface[]) content.GetValueForProperty("NetworkInterface",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NetworkInterface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfaceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgPropertiesProvisioningState = (string) content.GetValueForProperty("NsgPropertiesProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgPropertiesProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgPropertiesResourceGuid = (string) content.GetValueForProperty("NsgPropertiesResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgPropertiesResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).SecurityRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[]) content.GetValueForProperty("SecurityRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).SecurityRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SecurityRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).Subnet = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[]) content.GetValueForProperty("Subnet",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).Subnet, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubnetTypeConverter.ConvertFrom));
            AfterDeserializeDictionary(content);
        }

        /// <summary>
        /// Deserializes a <see cref="global::System.Management.Automation.PSObject" /> into a new instance of <see cref="Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfacePropertiesFormat"
        /// />.
        /// </summary>
        /// <param name="content">The global::System.Management.Automation.PSObject content that should be used.</param>
        internal NetworkInterfacePropertiesFormat(global::System.Management.Automation.PSObject content)
        {
            bool returnNow = false;
            BeforeDeserializePSObject(content, ref returnNow);
            if (returnNow)
            {
                return;
            }
            // actually deserialize
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSetting = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceDnsSettings) content.GetValueForProperty("DnsSetting",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSetting, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfaceDnsSettingsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).Nsg = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroup) content.GetValueForProperty("Nsg",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).Nsg, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkSecurityGroupTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).VirtualMachine = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubResource) content.GetValueForProperty("VirtualMachine",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).VirtualMachine, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubResourceTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).EnableAcceleratedNetworking = (bool?) content.GetValueForProperty("EnableAcceleratedNetworking",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).EnableAcceleratedNetworking, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).EnableIPForwarding = (bool?) content.GetValueForProperty("EnableIPForwarding",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).EnableIPForwarding, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).IPConfiguration = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration[]) content.GetValueForProperty("IPConfiguration",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).IPConfiguration, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfaceIPConfiguration>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfaceIPConfigurationTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).MacAddress = (string) content.GetValueForProperty("MacAddress",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).MacAddress, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).Primary = (bool?) content.GetValueForProperty("Primary",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).Primary, (__y)=> (bool) global::System.Convert.ChangeType(__y, typeof(bool)));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).ProvisioningState = (string) content.GetValueForProperty("ProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).ProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).ResourceGuid = (string) content.GetValueForProperty("ResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).ResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgEtag = (string) content.GetValueForProperty("NsgEtag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgEtag, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgTag = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.IResourceTags) content.GetValueForProperty("NsgTag",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgTag, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ResourceTagsTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSettingInternalDnsNameLabel = (string) content.GetValueForProperty("DnsSettingInternalDnsNameLabel",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSettingInternalDnsNameLabel, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSettingInternalDomainNameSuffix = (string) content.GetValueForProperty("DnsSettingInternalDomainNameSuffix",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSettingInternalDomainNameSuffix, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSettingInternalFqdn = (string) content.GetValueForProperty("DnsSettingInternalFqdn",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSettingInternalFqdn, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgName = (string) content.GetValueForProperty("NsgName",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgName, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgType = (string) content.GetValueForProperty("NsgType",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgType, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgId = (string) content.GetValueForProperty("NsgId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgLocation = (string) content.GetValueForProperty("NsgLocation",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgLocation, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSettingDnsServer = (string[]) content.GetValueForProperty("DnsSettingDnsServer",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSettingDnsServer, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgProperty = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkSecurityGroupPropertiesFormat) content.GetValueForProperty("NsgProperty",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgProperty, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkSecurityGroupPropertiesFormatTypeConverter.ConvertFrom);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSettingAppliedDnsServer = (string[]) content.GetValueForProperty("DnsSettingAppliedDnsServer",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DnsSettingAppliedDnsServer, __y => TypeConverterExtensions.SelectToArray<string>(__y, global::System.Convert.ToString));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).VirtualMachineId = (string) content.GetValueForProperty("VirtualMachineId",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).VirtualMachineId, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DefaultSecurityRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[]) content.GetValueForProperty("DefaultSecurityRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).DefaultSecurityRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SecurityRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NetworkInterface = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface[]) content.GetValueForProperty("NetworkInterface",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NetworkInterface, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterface>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.NetworkInterfaceTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgPropertiesProvisioningState = (string) content.GetValueForProperty("NsgPropertiesProvisioningState",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgPropertiesProvisioningState, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgPropertiesResourceGuid = (string) content.GetValueForProperty("NsgPropertiesResourceGuid",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).NsgPropertiesResourceGuid, global::System.Convert.ToString);
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).SecurityRule = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule[]) content.GetValueForProperty("SecurityRule",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).SecurityRule, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISecurityRule>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SecurityRuleTypeConverter.ConvertFrom));
            ((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).Subnet = (Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet[]) content.GetValueForProperty("Subnet",((Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.INetworkInterfacePropertiesFormatInternal)this).Subnet, __y => TypeConverterExtensions.SelectToArray<Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.ISubnet>(__y, Microsoft.Azure.PowerShell.Cmdlets.Network.Models.Api20171001.SubnetTypeConverter.ConvertFrom));
            AfterDeserializePSObject(content);
        }

        /// <summary>Serializes this instance to a json string.</summary>

        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Azure.PowerShell.Cmdlets.Network.Runtime.SerializationMode.IncludeAll)?.ToString();
    }
    /// NetworkInterface properties.
    [System.ComponentModel.TypeConverter(typeof(NetworkInterfacePropertiesFormatTypeConverter))]
    public partial interface INetworkInterfacePropertiesFormat

    {

    }
}